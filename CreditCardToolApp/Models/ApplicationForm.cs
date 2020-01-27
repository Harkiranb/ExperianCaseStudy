using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardToolApp.Models
{
    public class ApplicationForm
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public decimal AnnualIncome { get; set;}
        public string CardType { get; set; }

    }
}
