using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Morse.Models
{
    public class Translator
    {
        public string fromText { get; set; }

        public string path { get; set; }

        public string toMorseCode { get; set; }

        public int counter { get; set; }

        /// <summary>
        /// Morse-Alphabet
        /// Further morse characters may be found e.g. here:  https://rn-wissen.de/wiki/index.php/RP6_-_Morse-Code
        /// </summary>
        private readonly Dictionary<char, string> morseLettersCodes = new Dictionary<char, string> {
            // a-z
            { 'a', ".-" },{ 'b', "-..." },{'c' , "-.-."} ,{'d',"-.." },{'e',"." },{'f',"..-." },{'g',"--." },
            {'h',"...." },{'i',".."},{'j',".---" },{'k',"-.-" },{'l',".-.." },{'m',"--"},{'n',"-." },
            {'o',"---"},{'p',".--." },{'q',"--.-"},{'r',".-." },{'s',"..."},{ 't',"-"},
            {'u',"..-" },{'v',"...-" },{'w',".--" },{'x',"-..-" },{'y',"-.--" } ,{'z',"--.." } ,
            
            // Numbers (1-9,0)
            {'1',".----" } ,{ '2',"..---"},{'3',"...--" },{'4',"....-"},{'5'," ....." },
            {'6',"-...." },{'7',"--..." },{'8',"---.." } ,{'9',"----." },{'0',"-----" },

            //TODO: the mp3 files for the umlauts and special chars are still missing

            // umlauts (äöüß) 
            {'ä',".-.-" },{'ö',"---." },{'ü',"..--" } ,{'ß',"...--.." },
            
            
            // special characters
            {'@',".--.-." },{'!',"-.-.--" },{'\"',".-..-." },{'$',"...-..-" },{'&',".-..." },{'´',".---." },
            {'(',"-.--." },{')',"-.--.-" },{'*',"-..-" },{'+',".-.-." }, {',',"--..--" },{'-',"-....-" },
            {'.',".-.-.-" },{'/',"-..-." },{':',"---..." },{';',"-.-.-." },{'=',"-...-" },{'?',"..--.." },

            //line break
            {'\n',".-.-" } 

        };



        public string MorseCode()
        {
            Initiate();
            GetTextCode();
            return path;
        }
        private bool Initiate()
        {
            try
            {
                var validMorsechars = string.Join("", morseLettersCodes.Keys);

                fromText = Regex.Replace(fromText.ToLower(), $"[^{validMorsechars}]", " ");
                string sanitizedFilename = SanitizeFileName(fromText);
                sanitizedFilename = sanitizedFilename.Substring(0, Math.Min(20, sanitizedFilename.Length));

                string pathAbsolute = @"wwwroot\sound\";
                path = @"~/sound/" + sanitizedFilename + "res.mp3";
                var invalidChars = Path.GetInvalidFileNameChars();

                FileStream mp3FileStream = File.Create(@"wwwroot\sound\" + sanitizedFilename + "res.mp3");
                char[] textToLetters = fromText.ToCharArray();
                for (int i = 0; i < textToLetters.Length; i++)
                {
                    char morseLetter = textToLetters[i];
                    if (char.IsLetterOrDigit(morseLetter))
                    {
                        try
                        {
                            mp3FileStream.Write(File.ReadAllBytes(pathAbsolute + morseLetter + ".mp3"));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.Write($"Mp3 file '{morseLetter}.mp3' for character '{morseLetter}' is probably missing.");
                            System.Diagnostics.Debug.Write(ex.Message);
                        }
                    }
                }
                mp3FileStream.Close();
                return true;
            }
            catch
            {
                fromText = "Incorrect Value";
                return false;
            }
        }
        private bool GetTextCode()
        {
            try
            {
                toMorseCode = "";
                char[] textToLetters = fromText.ToCharArray();
                for (int i = 0; i < textToLetters.Length; i++)
                {
                    if (Char.IsLetterOrDigit(textToLetters[i]))
                    {
                        toMorseCode += morseLettersCodes[textToLetters[i]] + "\t";
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string SanitizeFileName(string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
