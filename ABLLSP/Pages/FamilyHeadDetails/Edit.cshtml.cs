using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.FamilyHeadDetails
{
    public class EditModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public EditModel(ABLLSP.Models.ABLLSPContext context)
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
           ViewData["ShaharId"] = new SelectList(_context.ShaharMasters, "ShaharId", "ShaharName");
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

            _context.Attach(FamilyHeadInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyHeadInfoExists(FamilyHeadInfo.FamilyId))
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

        private bool FamilyHeadInfoExists(long id)
        {
            return _context.FamilyHeadInfos.Any(e => e.FamilyId == id);
        }
    }
}
