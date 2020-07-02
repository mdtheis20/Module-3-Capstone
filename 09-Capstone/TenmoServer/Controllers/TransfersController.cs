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
    public class TransfersController : ControllerBase
    {
        private readonly IAccountDAO dao;
        private readonly IUserDAO udao;
        private readonly ITransferDAO tdao;

        public TransfersController(IUserDAO userDAO, ITransferDAO transferDAO, IAccountDAO accountDAO)
        {
            this.dao = accountDAO;
            this.udao = userDAO;
            this.tdao = transferDAO;

        }

        [HttpGet]
        public IActionResult GetTransfersList()
        {
            List<Transfer> transferList = tdao.GetTransfers(User.Identity.Name);  ///DANGERZONE THIS IS WRONG//PROBABLY
            return Ok(transferList);

        }

        [HttpPost]
        public IActionResult AddTransfer(Transfer transfer)  //THIS IS PROBABLY WRONG TOO
        {
            Transfer transferAdded = tdao.CreateTransfer(transfer);
            return Ok(transferAdded);
        }

    }
}