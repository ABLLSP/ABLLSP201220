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
    public class DetailsModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DetailsModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

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
    }
}
