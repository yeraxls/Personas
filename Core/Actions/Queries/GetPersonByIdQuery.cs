using Core.Entities;
using MediatR;

namespace Core.Actions.Queries
{
    public record GetAllPersonQuery : IRequest<List<Person>>;
}
