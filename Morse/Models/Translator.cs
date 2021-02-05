using System;
using System.Collections.Generic;
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

        private readonly Dictionary<char, string> morseLettersCodes = new Dictionary<char, string> { { 'a', ".-" },{ 'b', "-..." },
            {'c' , "-.-."} ,{'d',"-.." },{'e',"." },{'f',"..-." },{'g',"--." },{'h',"...." }
            ,{'i',".."},{'j',".---" },{'k',"-.-" },{'l',".-.." },{'m',"--"},{'n',"-." },
            {'o',"---"},{'p',".--." },{'q',"--.-"},{'r',".-." },{'s',"..."},{ 't',"-"},
            {'u',"..-" },{'v',"...-" },{'w',".--" },{'x',"-..-" },{'y',"-.--" } ,{'z',"--.." } };


        ~Translator(){
            File.Delete(@"wwwroot\sound\" + fromText + "res" + ".mp3");
        }
        public string MorseCode()
        {
            Initiate();
            GetTextCode();
            return path;
        }
       
        public string Initiate()
        {
            string pathAbsolute = @"wwwroot\sound\";
            path = @"~/sound/" + fromText +"res"+".mp3";
            var v = File.Create(@"wwwroot\sound\"+fromText+"res"+".mp3");
            char[] textToLetters = fromText.ToCharArray();
            for (int i = 0; i < textToLetters.Length; i++) { 
                v.Write(File.ReadAllBytes(pathAbsolute + textToLetters[i] + ".mp3"));
            }
            v.Close();
            return null;
        }
        private void GetTextCode()
        {
            toMorseCode = "";
            char[] textToLetters = fromText.ToCharArray();
            for(int i = 0; i < textToLetters.Length;i++)
            {
                toMorseCode += morseLettersCodes[textToLetters[i]]+"\t" ;
            }
        }
       
    }
}
