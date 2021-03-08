using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.MatriMonial
{
    public class DeleteModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DeleteModel(ABLLSP.Models.ABLLSPContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MatriMonialProfile = await _context.MatriMonialProfiles.FindAsync(id);

            if (MatriMonialProfile != null)
            {
                _context.MatriMonialProfiles.Remove(MatriMonialProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
