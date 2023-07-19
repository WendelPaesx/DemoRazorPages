﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly DemoRazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(DemoRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public aluno aluno { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.aluno.FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            else 
            {
                aluno = aluno;
            }
            return Page();
        }
    }
}
