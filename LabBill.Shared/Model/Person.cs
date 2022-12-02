using System.Text.Json.Serialization;

namespace LabBill.Shared.Model;

public class Person {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Bill> Bills { get; set; }
}