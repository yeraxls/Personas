using Core.Actions.Command;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Aplication.Handlers.Person
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Core.Entities.Person>
    {
        private readonly IPersonRepository _repository;

        public UpdatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Core.Entities.Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetByIdAsync(request.id);
            if(person == null)
                return null;
            person.Name = request.name;
            person.Lastname = request.lastname;
            await _repository.SaveAll();
            return person;
        }
    }
}
