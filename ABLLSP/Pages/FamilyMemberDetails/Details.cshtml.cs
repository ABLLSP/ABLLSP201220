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
    public class DetailsModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DetailsModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

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
    }
}
