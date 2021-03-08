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
    public class IndexModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public IndexModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public IList<FamilyMemberInfo> FamilyMemberInfo { get;set; }

        public async Task OnGetAsync()
        {
            FamilyMemberInfo = await _context.FamilyMemberInfos
                .Include(fhi => fhi.FamilyHeadInfo).Take(10).ToListAsync();
            //.Include(fhi => fhi.FamilyHeadInfo).ToListAsync();
        }
    }
}
