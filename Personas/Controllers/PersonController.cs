using Aplication.Interfaces;
using Core.Actions.Command;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Personas.DTOs;

namespace Personas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;
        private readonly IMediator _mediator;
        public PersonController(IPersonService personService, IMediator mediator)
        {
            _personService = personService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _personService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Person> GetById(int id)
        {
            return await _personService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewPerson newPerson)
        {
            var person = await _personService.Create(new Person { Name=newPerson.Name, Lastname = newPerson.Lastname });
            return Ok(person);
        }

        [HttpPut]
        public async Task<ActionResult> Update(PersonDto personDto)
        {
            var person = await _personService.Update(personDto.Id, personDto.Name, personDto.Lastname);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _personService.Delete(id);
            if(!result)
                return BadRequest();
            return Ok();
        }
    }
}
