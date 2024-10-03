using Core.Actions.Command;
using Core.Actions.Queries;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Handlers.Person
{
    public class GeetAllPersonHandler : IRequestHandler<GetAllPersonQuery, List<Core.Entities.Person>>
    {
        private readonly IPersonRepository _repository;

        public GeetAllPersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Core.Entities.Person>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

