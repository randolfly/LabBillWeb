using LabBill.Shared.Model;

namespace LabBill.Server.Service.HelperService;

public interface IHelperService
{
    // update the bill-person map 
    public Task UpdateBillPerson(BillPerson billPerson, List<BillPerson> targetBillPersons);
}