using LabBill.Server.Data;
using LabBill.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace LabBill.Server.Service.HelperService;

public class HelperService : IHelperService {
    private readonly DataContext _dataContext;
    public HelperService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task UpdateBillPerson(BillPerson billPerson, List<BillPerson> targetBillPersons)
    {
        // TODO 增加更好的修改方法/删除方法
        // 在本地测试时，别的项目类似的多对多关系可以直接：
        // // _dataContext.BillPersons.Remove(rawBillPerson);
        // 都不需要查找，直接remove就行了
        // 在这里如果直接remove 这个entry的 state会显示为 detached
        // 也就是 dbcontext 未跟踪，好像就没法删除

        var rawBillPerson = await _dataContext.BillPersons
            .Where(bp => bp.PersonId == billPerson.PersonId && bp.BillId == billPerson.BillId)
            .FirstOrDefaultAsync();

        if (rawBillPerson != null)
        {
            _dataContext.BillPersons.Remove(rawBillPerson);
            await _dataContext.SaveChangesAsync();
        }

        _dataContext.AddRange(targetBillPersons);
        await _dataContext.SaveChangesAsync();
    }
}