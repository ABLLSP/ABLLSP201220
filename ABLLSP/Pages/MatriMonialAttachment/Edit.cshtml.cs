using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.MatriMonialAttachment
{
    public class EditModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public EditModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MatriMonialProfileAttachment MatriMonialProfileAttachment { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MatriMonialProfileAttachment = await _context.MatriMonialProfileAttachments.FirstOrDefaultAsync(m => m.AttachmentId == id);

            if (MatriMonialProfileAttachment == null)
            {
                return NotFound();
            }
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

            _context.Attach(MatriMonialProfileAttachment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriMonialProfileAttachmentExists(MatriMonialProfileAttachment.AttachmentId))
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

        private bool MatriMonialProfileAttachmentExists(long id)
        {
            return _context.MatriMonialProfileAttachments.Any(e => e.AttachmentId == id);
        }
    }
}
