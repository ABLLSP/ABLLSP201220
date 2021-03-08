using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.FamilyMemberDetails
{
    public class DeleteModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DeleteModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FamilyMemberInfo FamilyMemberInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FamilyMemberInfo = await _context.FamilyMemberInfos
                .Include(f => f.FamilyHeadInfo).FirstOrDefaultAsync(m => m.FamilyMemberId == id);

            if (FamilyMemberInfo == null)
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

            FamilyMemberInfo = await _context.FamilyMemberInfos.FindAsync(id);

            if (FamilyMemberInfo != null)
            {
                _context.FamilyMemberInfos.Remove(FamilyMemberInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
