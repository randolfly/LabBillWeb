﻿using LabBill.Shared.Model;

namespace LabBill.Shared.Helper; 

// 删除1个BillPerson联系，添加多个BillPerson联系
public class BillPersonModifyMap {
    public BillPerson billPerson { get; set; }
    public List<BillPerson> targetBillPersons { get; set; }
    
}