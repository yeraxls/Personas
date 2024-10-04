using Aplication.Redis;
using Core.Actions.Command;
using Core.Actions.Queries;
using Core.Repositories;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Handlers.Person
{
    public class GetAllPersonHandler : IRequestHandler<GetAllPersonQuery, List<Core.Entities.Person>>
    {
        private readonly IPersonRepository _repository;
        private readonly IDistributedCache _cache;
        private const string key = "People";

        public GetAllPersonHandler(IPersonRepository repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<List<Core.Entities.Person>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var people = await _cache.GetRecordAsync<List<Core.Entities.Person>>(key);
            if(people == null || people.Count == 0)
            {
                people = await _repository.GetAllAsync();
                await _cache.SetRecordAsync(key, people);
            }
            return people;
        }
    }
}

