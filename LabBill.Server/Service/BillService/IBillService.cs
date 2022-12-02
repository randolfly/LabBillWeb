using LabBill.Shared;
using LabBill.Shared.Model;

namespace LabBill.Server.Service.BillService; 

public interface IBillService { 
    Task<ServiceResponse<List<Bill>>> GetBills();
    Task<ServiceResponse<List<Bill>>> GetBillsByPerson(int personId);
    Task<ServiceResponse<Bill>> GetBillById(int billId);

    Task RemoveBill(int billId);

    Task UpdateBill(Bill bill);
}