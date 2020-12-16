using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.PrantMember
{
    public class DetailsModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DetailsModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public PrantMemberMaster PrantMemberMaster { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PrantMemberMaster = await _context.PrantMemberMasters.Include(pm => pm.PrantMaster).Include(pdm => pdm.PrantDesignationMaster).FirstOrDefaultAsync(m => m.MemberId == id);

            if (PrantMemberMaster == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
