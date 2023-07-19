using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoRazorPages.Data;
using DemoRazorPages.models;

namespace DemoRazorPages.Pages.Alunos
{
    public class EditModel : PageModel
    {
        private readonly DemoRazorPages.Data.ApplicationDbContext _context;

        public EditModel(DemoRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public aluno aluno { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.aluno == null)
            {
                return NotFound();
            }

            var aluno =  await _context.aluno.FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            aluno = aluno;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!alunoExists(aluno.Id))
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

        private bool alunoExists(int id)
        {
          return (_context.aluno?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
