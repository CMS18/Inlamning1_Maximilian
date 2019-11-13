using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmApp.Web.Data;
using AlmApp.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlmApp.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AccountViewModel model, string command)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var msg = "";

            if (command.Equals("withdraw"))
            {
                msg = BankRepository.Withdrawal(model.AccountNumber, model.Amount);
            }

            if (command.Equals("deposit"))
            {
                msg = BankRepository.Deposit(model.AccountNumber, model.Amount);
            }

            TempData["msg"] = msg;

            return View();
        }
    }
}