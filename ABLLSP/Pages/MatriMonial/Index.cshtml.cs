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
    public class IndexModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public IndexModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public IList<MatriMonialProfile> MatriMonialProfile { get;set; }

        //public async Task OnGetAsync()
        //{
  
        //    MatriMonialProfile = await _context.MatriMonialProfiles.ToListAsync();
        //}

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                MatriMonialProfile = await _context.MatriMonialProfiles.ToListAsync();
            }
            else
            {
                MatriMonialProfile = await _context.MatriMonialProfiles.Where(mm => mm.Gender == id).ToListAsync();
            }            

            if (MatriMonialProfile == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
