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

        public string MorseCode()
        {
            Initiate();
            return @"~/sound/candy.mp3";
        }
        public string Initiate()
        {
            string path = @"wwwroot\sound\";
            var v = File.Create(@"wwwroot\sound\candy.mp3");
            char[] textToLetters = fromText.ToCharArray();
            for (int i = 0; i < textToLetters.Length; i++) { 
                v.Write(File.ReadAllBytes(path + textToLetters[i] + ".mp3"));
            }
            v.Close();
            return null;
        }
       
    }
}
