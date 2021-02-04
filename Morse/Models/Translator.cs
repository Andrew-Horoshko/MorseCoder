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

        ~Translator(){
            File.Delete(@"wwwroot\sound\" + fromText + "res" + ".mp3");
        }
        public string MorseCode()
        {
            Initiate();
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
       
    }
}
