using LabBill.Server.Service.HelperService;
using LabBill.Shared.Helper;
using LabBill.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LabBill.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase {
        private readonly IHelperService _helperService;
        public HelperController(IHelperService helperService)
        {
            _helperService = helperService;
        }

        [HttpPost("update-bill-person")]
        public async Task UpdateBillPerson(BillPersonModifyMap billPersonInfos)
        {
            BillPerson billPerson = billPersonInfos.billPerson;
            List<BillPerson> targetBillPersons = billPersonInfos.targetBillPersons;
            await _helperService.UpdateBillPerson(billPerson, targetBillPersons);
        }
    }
}