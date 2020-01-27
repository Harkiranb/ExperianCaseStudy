using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CreditCardToolApp.Models
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly AppDbContext _appDbContext;
      

        public ApplicationFormRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }

        public void CreateApplication(ApplicationForm application)
        {

            _appDbContext.ApplicationForm.Add(application);

            _appDbContext.SaveChanges();
        }
        
        public void SaveCardType(string card)
        {
            var type = new ApplicationForm { CardType = card };

            //_appDbContext.ApplicationForm.Add(type);
            _appDbContext.ApplicationForm.Update(type);
           // _appDbContext.SaveChanges();
            
        }
    }
}

