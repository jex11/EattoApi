using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eatto.Application;
using Eatto.Application.Interfaces;
using Eatto.Core.Database;
using Eatto.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eatto.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository, IAutoInjectable
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }

}
