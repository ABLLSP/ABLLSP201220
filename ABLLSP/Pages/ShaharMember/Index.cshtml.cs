using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.ShaharMember
{
    public class IndexModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public IndexModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public IList<ShaharMemberMaster> ShaharMemberMaster { get;set; }

        public async Task OnGetAsync()
        {
            ShaharMemberMaster = await _context.ShaharMemberMasters.
                Include(sm => sm.ShaharMaster).
                Include(sdm => sdm.ShaharDesignationMaster).ToListAsync();
            }
    }
}
