using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eatto.Application.Interfaces;
using Eatto.Core.Database.Entities;
using MediatR;

namespace Eatto.Application.UseCases.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>> { }

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _repo;

        public GetAllCategoriesHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }

}
