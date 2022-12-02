using LabBill.Server.Data;
using LabBill.Shared;
using LabBill.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace LabBill.Server.Service.BillService; 

public class BillService : IBillService{
    private readonly DataContext _dataContext;

    public BillService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<ServiceResponse<List<Bill>>> GetBills()
    {
        var bills = await _dataContext.Bills
            .Include(b=>b.Persons)
            .ToListAsync();
        return new ServiceResponse<List<Bill>>
        {
            Data = bills
        };
    }
    public async Task<ServiceResponse<List<Bill>>> GetBillsByPerson(int personId)
    {
        var bills = await _dataContext.Bills
            .Include(b=>b.Persons)
            .Where(b=>b.Persons.Any(p=>p.Id == personId))
            .ToListAsync();
        return new ServiceResponse<List<Bill>>
        {
            Data = bills
        };
    }
    public async Task<ServiceResponse<Bill>> GetBillById(int billId)
    {
        var bill = await _dataContext.Bills
            .Include(b=>b.Persons)
            .Where(b=>b.Id==billId)
            .FirstOrDefaultAsync();
        if (bill == null)
        {
            return new ServiceResponse<Bill>
            {
                Data = new Bill(),
                Success = false,
                Message = "No such bill"
            };
        }
        return new ServiceResponse<Bill>
        {
            Data = bill
        };

    }
    public async Task RemoveBill(int billId)
    {
        var bill = await _dataContext.Bills
            .Include(b=>b.Persons)
            .Where(b=>b.Id==billId)
            .FirstOrDefaultAsync();
        if (bill != null)
        {
            _dataContext.Bills.Remove(bill);
            _dataContext.SaveChangesAsync();
        }
    }
    public async Task UpdateBill(Bill bill)
    {
        _dataContext.Bills.Update(bill);
        await _dataContext.SaveChangesAsync();
    }
}