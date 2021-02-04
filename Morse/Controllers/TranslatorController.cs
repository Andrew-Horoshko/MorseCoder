using Microsoft.AspNetCore.Mvc;
using Morse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morse.Controllers
{
    public class TranslatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Translated( string fromText)
        {
            Translator temp = new Translator
            {
                fromText = fromText
            };
            return View(temp);
        }
    }
}
