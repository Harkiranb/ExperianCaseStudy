using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardToolApp.Models
{
    public interface IApplicationFormRepository
    {
        void CreateApplication(ApplicationForm application);



        
        void SaveCardType(string card);
    }
}
