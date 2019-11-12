using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AlmApp.Web.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }
    }
}
