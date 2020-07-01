using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDAO dao;

        public AccountController(IAccountDAO accountDao)
        {
            this.dao = accountDao;
        }
        

        [HttpGet]
        public IActionResult GetCurrentAccountBalance()
        {
            Account a = dao.GetAccountByName(User.Identity.Name);
            return Ok(a.Balance);
        }
    }
}