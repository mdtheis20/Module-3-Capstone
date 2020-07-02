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
        private readonly IUserDAO udao;

        public AccountController(IAccountDAO accountDao, IUserDAO userDAO)
        {
            this.dao = accountDao;
            this.udao = userDAO;
        }


        [HttpGet]

        public IActionResult GetCurrentAccountBalance()
        {
            Account a = dao.GetAccount(User.Identity.Name);
            return Ok(a);
        }

        [HttpGet("User")]
        public IActionResult GetAllRegisteredUsers()
        {
            List<User> userList = udao.GetUsers();
            return Ok(userList);
        }
    }
}