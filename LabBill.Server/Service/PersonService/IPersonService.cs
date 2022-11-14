using LabBill.Shared;
using LabBill.Shared.Model;

namespace LabBill.Server.Service.PersonService;

public interface IPersonService {
    Task<ServiceResponse<List<Person>>> GetPersons();

    Task<ServiceResponse<Person?>> GetPersonById(int personId);
    Task AddPerson(Person person);
}