using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.MatriMonial
{
    public class EditModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public EditModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MatriMonialProfile MatriMonialProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MatriMonialProfile = await _context.MatriMonialProfiles.FirstOrDefaultAsync(m => m.ProfileId == id);

            if (MatriMonialProfile == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MatriMonialProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriMonialProfileExists(MatriMonialProfile.ProfileId))
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

        private bool MatriMonialProfileExists(long id)
        {
            return _context.MatriMonialProfiles.Any(e => e.ProfileId == id);
        }
    }
}
