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
    public class AccountController : ControllerBase
    {
        private readonly IAccountDAO _dao;

        public AccountController(IAccountDAO accountDao = null)
        {
            if (accountDao == null)
                _dao = new AccountSqlDAO();
            else
                _dao = accountDao;
        }
        

        [HttpGet]
        public IActionResult GetCurrentAccountBalance()
        {
            Account a = _dao.GetAccountByName(User.Identity.Name);
            return Ok(a.Balance);
        }
    }
}