using Core.Actions.Command;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Aplication.Handlers.Person
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Core.Entities.Person>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Core.Entities.Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.AddAsync(request.person);
            await _repository.SaveAll();
            return person;
        }
    }
}
