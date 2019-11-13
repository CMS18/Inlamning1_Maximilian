using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmApp.Web.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        public int AccountNumber { get; set; }
    }
}
