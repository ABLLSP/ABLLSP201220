using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ABLLSP.Models;

namespace ABLLSP.Pages.ABLLSPMember
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
            return Page();
        }

        [BindProperty]
        public AbllspmemberMaster AbllspmemberMaster { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AbllspmemberMasters.Add(AbllspmemberMaster);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
