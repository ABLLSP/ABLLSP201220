using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABLLSP.Pages.PrantMember
{
    public class IndexModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public IndexModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public IList<PrantMemberMaster> PrantMemberMaster { get;set; }

        //public IList<PrantMaster> PrantMaster { get; set; }
        public SelectList PrantList { get; set; }

        public void PopulatePrantList()
        {
            var Prants = from p in _context.PrantMasters
                            orderby p.PrantId
                            select p;
            PrantList = new SelectList(Prants, "PrantId", "PrantName");
            
        }

        public async Task OnGetAsync()
        {
            //PopulatePrantList();

            PrantMemberMaster = await _context.PrantMemberMasters.
                //Where(pmm => pmm.PrantId == PrantList.SelectedValue).
                Include(pm=>pm.PrantMaster).
                Include(pdm => pdm.PrantDesignationMaster).
                
                ToListAsync();                        
        }
    }
}
