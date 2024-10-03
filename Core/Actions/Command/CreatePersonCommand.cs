using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Actions.Command
{
    public record CreatePersonCommand(Person person)
    : IRequest<Person>;
}
