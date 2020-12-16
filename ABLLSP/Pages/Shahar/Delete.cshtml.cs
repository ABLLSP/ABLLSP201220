using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.Shahar
{
    public class DeleteModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DeleteModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShaharMaster ShaharMaster { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShaharMaster = await _context.ShaharMasters.FirstOrDefaultAsync(m => m.ShaharId == id);

            if (ShaharMaster == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShaharMaster = await _context.ShaharMasters.FindAsync(id);

            if (ShaharMaster != null)
            {
                _context.ShaharMasters.Remove(ShaharMaster);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
