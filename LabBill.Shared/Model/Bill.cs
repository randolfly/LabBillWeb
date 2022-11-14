namespace LabBill.Shared.Model;

public class Bill {
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Brief { get; set; } = String.Empty;
    public List<Person> Persons { get; set; }
    public decimal Price { get; set; }
    public string? Detail { get; set; }
    public BillState BillState { get; set; }
    public List<BillType> BillTypes { get; set; }
    public RbsType BillType { get; set; }
    public List<Asset>? Assets { get; set; }
}

// 显示订单是否被报销
public enum RbsType {
    RBS,// 可报销文件
    NRBS// 不可报销文件
}

public enum BillState {
    Done,// 已完成 
    Todo// 未完成
}