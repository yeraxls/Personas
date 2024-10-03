using Core.Actions.Command;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Aplication.Handlers.Person
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;

        public DeletePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetByIdAsync(request.id);
            if(person == null)
                return false;
            await _repository.DeleteAsync(person);
            await _repository.SaveAll();
            return true;
        }
    }
}
