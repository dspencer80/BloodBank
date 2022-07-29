using BloodBank.Data;
using BloodBank.Models;
using BloodBank.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index()
        {
            var donors = await bloodBankDbContext.Donors.ToListAsync();
            return View(donors);
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
                Social = addDonorRequest.Social,
                Email = addDonorRequest.Email,
                Race = addDonorRequest.Race,
                DateofBirth = addDonorRequest?.DateofBirth,
                DonationDate = addDonorRequest?.DonationDate,
            };

            await bloodBankDbContext.Donors.AddAsync(donor);
            await bloodBankDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var donor = await bloodBankDbContext.Donors.FirstOrDefaultAsync(x => x.Id == id);

            if (donor != null)
            {
                var viewModel = new UpdateDonorViewModel()
                {
                    Id = donor.Id,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Social = donor.Social,
                    Email = donor.Email,
                    Race = donor.Race,
                    DateofBirth = donor?.DateofBirth,
                    DonationDate = donor?.DonationDate,
                };

                return await Task.Run(() =>View("view", viewModel));
            }

            
                return RedirectToAction("Index");
        }

           [HttpPost]
           public async Task<IActionResult> View(UpdateDonorViewModel model)
        {
            var donor = await bloodBankDbContext.Donors.FindAsync(model.Id);

            if (donor != null)
            {
                donor.FirstName = model.FirstName;
                donor.LastName = model.LastName;
                donor.Social = model.Social;    
                donor.Email = model.Email;
                donor.Race = model.Race;
                donor.DateofBirth = model.DateofBirth;
                donor.DonationDate = model.DonationDate;

                await bloodBankDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
