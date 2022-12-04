using LabBill.Server.Service.PersonService;
using LabBill.Shared;
using LabBill.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabBill.Server.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase {
    private readonly IPersonService _personService;
    public PersonController(IPersonService personService)
    {
        _personService = personService;

    }
    // GET: api/Person
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Person>>>> GetPersons()
    {
        var result = await _personService.GetPersons();
        return Ok(result);
    }

    // GET: api/Person/5
    [HttpGet("{personId}")]
    public async Task<ActionResult<ServiceResponse<Person>>> GetPersonById(int personId)
    {
        var result = await _personService.GetPersonById(personId);
        return Ok(result);
    }

    [HttpPost("update-person")]
    public async Task UpdatePerson(Person person)
    {
        await _personService.UpdatePerson(person);
    }


}