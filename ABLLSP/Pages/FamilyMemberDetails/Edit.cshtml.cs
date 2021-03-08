using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.FamilyMemberDetails
{
    public class EditModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public EditModel(ABLLSP.Models.ABLLSPContext context)
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
           ViewData["FamilyId"] = new SelectList(_context.FamilyHeadInfos, "FamilyId", "FamilyHeadName");
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

            _context.Attach(FamilyMemberInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyMemberInfoExists(FamilyMemberInfo.FamilyMemberId))
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

        private bool FamilyMemberInfoExists(long id)
        {
            return _context.FamilyMemberInfos.Any(e => e.FamilyMemberId == id);
        }
    }
}
