using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.Models.Customer;

namespace GeneralStoreMVC.Views.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly GeneralStoreMVC.Data.GeneralStoreDBContext _context;

        public DetailsModel(GeneralStoreMVC.Data.GeneralStoreDBContext context)
        {
            _context = context;
        }

      public CustomerDetailModel CustomerDetailModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerDetailModel == null)
            {
                return NotFound();
            }

            var customerdetailmodel = await _context.CustomerDetailModel.FirstOrDefaultAsync(m => m.Id == id);
            if (customerdetailmodel == null)
            {
                return NotFound();
            }
            else 
            {
                CustomerDetailModel = customerdetailmodel;
            }
            return Page();
        }
    }
}
