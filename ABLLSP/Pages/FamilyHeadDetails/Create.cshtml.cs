using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ABLLSP.Models;

namespace ABLLSP.Pages.FamilyHeadDetails
{
    public class CreateModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public CreateModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ShaharId"] = new SelectList(_context.ShaharMasters, "ShaharId", "ShaharName");
            return Page();
        }

        [BindProperty]
        public FamilyHeadInfo FamilyHeadInfo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FamilyHeadInfos.Add(FamilyHeadInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
