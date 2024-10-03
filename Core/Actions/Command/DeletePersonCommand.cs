using Core.Entities;
using MediatR;

namespace Core.Actions.Command
{
    public record DeletePersonCommand(int id) : IRequest<bool>;
}
