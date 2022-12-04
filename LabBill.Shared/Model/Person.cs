﻿using System.Text.Json.Serialization;

namespace LabBill.Shared.Model;

public class Person {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<BillPerson> BillPersons { get; set; } = new();
}