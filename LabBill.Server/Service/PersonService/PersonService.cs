using LabBill.Server.Data;
using LabBill.Shared;
using LabBill.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace LabBill.Server.Service.PersonService;

public class PersonService : IPersonService {
    private readonly DataContext _dataContext;

    public PersonService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceResponse<List<Person>>> GetPersons()
    {
        var persons = await _dataContext.Persons.ToListAsync();
        return new ServiceResponse<List<Person>>
        {
            Data = persons
        };
    }
    public async Task<ServiceResponse<Person>> GetPersonById(int personId)
    {
        var response = new ServiceResponse<Person>();
        var person = await _dataContext.Persons.FirstOrDefaultAsync(a => a.Id.Equals(personId));
        if (person == null)
        {
            response.Success = false;
            response.Message = "Sorry, asset not exists.";
        }
        else
        {
            response.Data = person;
            response.Success = true;
        }
        return response;
    }

    public async Task UpdatePerson(Person person)
    {
        _dataContext.Persons.Update(person);
        await _dataContext.SaveChangesAsync();
    }
}