using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.Models.Customer;

namespace GeneralStoreMVC.Views.Customer
{
    public class EditModel : PageModel
    {
        private readonly GeneralStoreMVC.Data.GeneralStoreDBContext _context;

        public EditModel(GeneralStoreMVC.Data.GeneralStoreDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerEditModel CustomerEditModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerEditModel == null)
            {
                return NotFound();
            }

            var customereditmodel =  await _context.CustomerEditModel.FirstOrDefaultAsync(m => m.Id == id);
            if (customereditmodel == null)
            {
                return NotFound();
            }
            CustomerEditModel = customereditmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerEditModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEditModelExists(CustomerEditModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerEditModelExists(int id)
        {
          return (_context.CustomerEditModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
