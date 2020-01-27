using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCardToolApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditCardToolApp.Controllers
{
    public class ApplicationFormController : Controller
    {

        private readonly IApplicationFormRepository _applicationFormRepository;

        public ApplicationFormController(IApplicationFormRepository applicationFormRepository)
        {
            _applicationFormRepository = applicationFormRepository;
        }

        // GET: /<controller>/
        public IActionResult Results()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Results(ApplicationForm applicationForm)
        {
            if (ModelState.IsValid)
            {
                //check the age 
                string dob = applicationForm.DateOfBirth;
                DateTime dateOfBirth = Convert.ToDateTime(dob);
                int age = CalculateAge(dateOfBirth);

                //check the income
                decimal income = applicationForm.AnnualIncome;

                //if they 18 and under show no credits cards availabe
                if (age < 18)
                {
                    
                        
                    _applicationFormRepository.CreateApplication(applicationForm);
                    
                    //save type of card to database by calling method
                    _applicationFormRepository.SaveCardType("No Cards Available");

                

                    return RedirectToAction("ApplicationComplete");

                }
                //if they 18 and over and have income over 30000 then show barclays
                else if (age > 18 && income > 30000)
                {
                    
                    _applicationFormRepository.CreateApplication(applicationForm);
                    //save type of card to database by calling method

                    _applicationFormRepository.SaveCardType("Barclays");

                    return RedirectToAction("BarclaysPage");
                }
                else
                {

                    _applicationFormRepository.CreateApplication(applicationForm);
                    //save type of card to database by calling method

                    _applicationFormRepository.SaveCardType("Vanquis");

                    return RedirectToAction("VanquisPage");
                }                
            }
            return View(applicationForm);
        }



        public IActionResult ApplicationComplete()
        {
            ViewBag.ApplicationCompleteMessage = "No Credit Cards Available";
            return View();
        }

        public IActionResult BarclaysPage()
        {
            ViewBag.BarclaysMessage = "Barclays Page";
            return View();
        }

        public IActionResult VanquisPage()
        {
            ViewBag.VanquisMessage = "Vanquis Page";
            return View();
        }

        public static int CalculateAge(DateTime birthDay)
        {
            int years = DateTime.Now.Year - birthDay.Year;

            if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
                years--;

            return years;
        }
    }
}
