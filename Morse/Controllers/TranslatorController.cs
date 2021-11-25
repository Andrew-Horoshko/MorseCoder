using Microsoft.AspNetCore.Mvc;
using Morse.Models;

namespace Morse.Controllers
{
    public class TranslatorController : Controller
    {
        public Translator obj = new Translator();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Translated( string fromText)
        {
            
            obj.fromText = fromText;
            obj.path = obj.MorseCode();
            return View(obj);
        }
       
    }
}
