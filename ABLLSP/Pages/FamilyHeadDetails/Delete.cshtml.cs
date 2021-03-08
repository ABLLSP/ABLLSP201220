using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.FamilyHeadDetails
{
    public class DeleteModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DeleteModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FamilyHeadInfo FamilyHeadInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FamilyHeadInfo = await _context.FamilyHeadInfos
                .Include(f => f.ShaharMaster).FirstOrDefaultAsync(m => m.FamilyId == id);

            if (FamilyHeadInfo == null)
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

            FamilyHeadInfo = await _context.FamilyHeadInfos.FindAsync(id);

            if (FamilyHeadInfo != null)
            {
                _context.FamilyHeadInfos.Remove(FamilyHeadInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
