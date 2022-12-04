namespace LabBill.Shared.Model;

public class Bill {
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Brief { get; set; } = String.Empty;
    public List<BillPerson> BillPersons { get; set; } = new();
    public decimal Price { get; set; }
    public string Detail { get; set; } = string.Empty;
    public BillState BillState { get; set; }
    public RbsType BillType { get; set; }
    public List<BillType> BillTypes { get; set; } = new();
    public List<Asset>? Assets { get; set; } = new();
}

// 显示订单是否被报销
public enum RbsType {
    Rbs,// 可报销文件
    Nrbs// 不可报销文件
}

public enum BillState {
    Done,// 已完成 
    Todo// 未完成
}