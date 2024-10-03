using Aplication.Interfaces;
using Core.Actions.Command;
using Core.Actions.Queries;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;


namespace Aplication.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMediator _mediator;

        public PersonService(IPersonRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<List<Person>> GetAll()
        {
            var command = new GetAllPersonQuery();
            return await _mediator.Send(command);
        }

        public async Task<Person> GetById(int id)
        {
            var command = new GetPersonByIdQuery(id);
            return await _mediator.Send(command);
        }

        public async Task<Person> Create(Person person)
        {
            var command = new CreatePersonCommand(person);
            return await _mediator.Send(command);
        }

        public async Task<Person> Update(int id, string name, string lastname)
        {
            var command = new UpdatePersonCommand(id,name,lastname);
            return await _mediator.Send(command);
        }

        public async Task<bool> Delete(int id)
        {
            var command = new DeletePersonCommand(id);
            return await _mediator.Send(command);
        }
    }
}
