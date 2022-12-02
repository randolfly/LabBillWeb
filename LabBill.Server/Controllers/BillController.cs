using LabBill.Server.Service.BillService;
using LabBill.Shared;
using LabBill.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using  Microsoft.AspNetCore.Mvc;

namespace LabBill.Server.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class BillController : ControllerBase {
    private readonly IBillService _billService;
    public BillController(IBillService billService)
    {
        _billService = billService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Bill>>>> GetBills()
    {
        var result = await _billService.GetBills();
        return Ok(result);
    }
    
    [HttpGet("bill/{billid}")]
    public async Task<ActionResult<ServiceResponse<Bill>>> GetBillsById(int billid)
    {
        var result = await _billService.GetBillById(billid);
        return Ok(result);
    }
    
    [HttpGet("person/{personId}")]
    public async Task<ActionResult<ServiceResponse<Bill>>> GetBillsByPerson(int personId)
    {
        var result = await _billService.GetBillsByPerson(personId);
        return Ok(result);
    }
    
    [HttpDelete("delete-bill/{billId}")]
    public async Task RemoveBill(int billId)
    {
        await _billService.RemoveBill(billId);
    }
    
    [HttpPost("update-bill")]
    public async Task UpdateBill(Bill bill)
    {
        await _billService.UpdateBill(bill);
    }
    
}