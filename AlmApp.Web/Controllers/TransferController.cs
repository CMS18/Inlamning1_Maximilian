using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmApp.Web.Data;
using AlmApp.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlmApp.Web.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["msg"] = BankRepository.Transfer(model.AccountFrom, model.AccountTo, model.Amount);
                return View("Index");
            }
            return View("Index");
        }
    }
}
