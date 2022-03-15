using Microsoft.AspNetCore.Mvc;
using Projet_API_P_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_API_P_WEB.Controllers
{

    
    public class PaysController : Controller
    {
        public IActionResult CreatePays()
        {
            return View();
        }

        // POST: Pays/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pays pays)
        {
            if (ModelState.IsValid)
            {
                //var URI = API.Instance.AjoutEcurieAsync(pays);
                return RedirectToAction(nameof(Index));
            }
            return View(pays);
        }
    }
}
