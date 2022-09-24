using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetailBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBanking.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public static RetailBankingContext db = new RetailBankingContext();

        [HttpPost]
        //[Route("AddCustomer")]
        public async Task<ActionResult> AddCustomer(Customer C)
        {
            if (ModelState.IsValid)
            {
                db.Add(C);
                await db.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest(); }

        }

        [HttpGet]
        //[Route("GetCustomerDetails")]
        public async Task<ActionResult> GetCustomerDetails()
        {
            return Ok(await db.Customers.ToListAsync());
        }

        [HttpGet]
        [Route("{Customer_ID}")]
        public async Task<ActionResult> GetCustomerDetailsById(int Customer_ID)
        {
            var C = await db.Customers.FindAsync(Customer_ID);

            if (C != null) { return Ok(C); }
            else { return NotFound(); }

        }
    }
}
