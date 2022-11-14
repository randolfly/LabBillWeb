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
    public async Task<ServiceResponse<Person?>> GetPersonById(int personId)
    {
        var result = new Person();
        string message = String.Empty;
        bool state = true;
        try
        {
            result = await _dataContext.Persons.FirstAsync(p => p.Id.Equals(personId));
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e);
            state = false;
            message = "No Person Found, Please Check Id";
        }

        return new ServiceResponse<Person?>
        {
            Data = result,
            Success = state,
            Message = message
        };
    }
    public async Task AddPerson(Person person)
    {
        await _dataContext.Persons.AddAsync(person);
    }
}