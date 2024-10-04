using Aplication.Redis;
using Core.Actions.Queries;
using Core.Repositories;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Aplication.Handlers.Person
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Core.Entities.Person>
    {
        private readonly IPersonRepository _repository;
        private readonly IDistributedCache _cache;
        private const string key = "Person";

        public GetPersonByIdHandler(IPersonRepository repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<Core.Entities.Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _cache.GetRecordAsync<Core.Entities.Person>($"{key}:{request.id}");
            if (person == null)
            {
                person = await _repository.GetByIdAsync(request.id);
                await _cache.SetRecordAsync($"{key}:{request.id}", person);
            }
            return person;
        }
    }
}

