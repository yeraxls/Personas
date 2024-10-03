using Core.Entities;
using MediatR;

namespace Core.Actions.Queries
{
    public record GetPersonByIdQuery(int id) : IRequest<Person>;
}
