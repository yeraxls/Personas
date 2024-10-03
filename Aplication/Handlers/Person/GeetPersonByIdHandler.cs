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
    public class GeetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Core.Entities.Person>
    {
        private readonly IPersonRepository _repository;

        public GeetPersonByIdHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Task<Core.Entities.Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByIdAsync(request.id);
        }
    }
}

