using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.Prant
{
    public class DetailsModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DetailsModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public PrantMaster PrantMaster { get; set; }

        public async Task<IActionResult> OnGetAsync(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PrantMaster = await _context.PrantMasters.FirstOrDefaultAsync(m => m.PrantId == id);

            if (PrantMaster == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
