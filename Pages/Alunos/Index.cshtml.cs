using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoRazorPages.Data;
using DemoRazorPages.models;

namespace DemoRazorPages.Pages.Alunos
{
    public class IndexModel : PageModel
    {
        private readonly DemoRazorPages.Data.ApplicationDbContext _context;

        public IndexModel(DemoRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<aluno> aluno { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.aluno != null)
            {
                aluno = await _context.aluno.ToListAsync();
            }
        }
    }
}
