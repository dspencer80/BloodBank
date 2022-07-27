using BloodBank.Data;
using BloodBank.Models;
using BloodBank.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class DonorsController : Controller
    {
        private readonly BloodBankDbContext bloodBankDbContext;

        public DonorsController(BloodBankDbContext bloodBankDbContext)
        {
            this.bloodBankDbContext = bloodBankDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDonorViewModel addDonorRequest)
        {
            var donor = new Donor()
            {
                Id = Guid.NewGuid(),
                FirstName = addDonorRequest.FirstName,
                LastName = addDonorRequest.LastName,
                SSN = addDonorRequest.SSN,
                Email = addDonorRequest.Email,
                Race = addDonorRequest.Race,
                DateofBirth = addDonorRequest?.DateofBirth,
                DonationDate = addDonorRequest?.DonationDate,
            };

            await bloodBankDbContext.Donors.AddAsync(donor);
            await bloodBankDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }


    }
}
