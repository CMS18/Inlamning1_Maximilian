using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmApp.Web.Models.ViewModels
{
    public class TransferViewModel
    {
        [Required]
        public int AccountFrom { get; set; }
        [Required]
        public int AccountTo { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}
