using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Morse.Models
{
    public class Translator
    {
        public string fromText { get; set; }

        public string path { get; set; }

        public string toMorseCode { get; set; }

        public int counter { get; set;} 

        private readonly Dictionary<char, string> morseLettersCodes = new Dictionary<char, string> { { 'a', ".-" },{ 'b', "-..." },
            {'c' , "-.-."} ,{'d',"-.." },{'e',"." },{'f',"..-." },{'g',"--." },{'h',"...." }
            ,{'i',".."},{'j',".---" },{'k',"-.-" },{'l',".-.." },{'m',"--"},{'n',"-." },
            {'o',"---"},{'p',".--." },{'q',"--.-"},{'r',".-." },{'s',"..."},{ 't',"-"},
            {'u',"..-" },{'v',"...-" },{'w',".--" },{'x',"-..-" },{'y',"-.--" } ,{'z',"--.." } ,
            {'1',".----" } ,{ '2',"..---"},{'3',"...--" },{'4',"....-"},{'5'," ....." },
            {'6',"-...." },{'7',"--..." },{'8',"---.." } ,{'9',"----." },{'0',"-----" } };


        public string MorseCode()
        {
           

            Initiate();
            GetTextCode();
            return path;
        }
        private void Initiate()
        {
            WhiteSpaceDemlisher();
            string pathAbsolute = @"wwwroot\sound\";
            path = @"~/sound/" + fromText +"res"+".mp3";
            var v = File.Create(@"wwwroot\sound\"+fromText+"res"+".mp3");
            char[] textToLetters = fromText.ToCharArray();
            for (int i = 0; i < textToLetters.Length; i++) {
                if (Char.IsLetterOrDigit(textToLetters[i]))
                {
                    v.Write(File.ReadAllBytes(pathAbsolute + textToLetters[i] + ".mp3"));
                }
            }
            v.Close();
        }
        private void GetTextCode()
        {
            toMorseCode = "";
            char[] textToLetters = fromText.ToCharArray();
            for(int i = 0; i < textToLetters.Length;i++)
            {
                if (Char.IsLetterOrDigit(textToLetters[i]))
                {
                    toMorseCode += morseLettersCodes[textToLetters[i]] + "\t";
                }
            }
        }
        private void WhiteSpaceDemlisher()
        {
            char[] textForCheck = fromText.ToCharArray();
            fromText = "";
            for (int i = 0; i < textForCheck.Length; i++)
            {
                if (!Char.IsLetterOrDigit(textForCheck[i]) || Char.IsWhiteSpace(textForCheck[i])) textForCheck[i] = '-';
                fromText += Char.ToLower(textForCheck[i]);
            }
        }
       
    }
}
