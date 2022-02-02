using CodeExchangeAPI.Utils;
using CodeExchangeEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly CodeExchangeContext dbContext;
        public QuestionController()
        {
            if (dbContext == null) dbContext = new CodeExchangeContext();
        }

        /// <summary>
        /// An example http request
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpGet("action")]
        public IActionResult Action()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response.Data = null;
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.ErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    response.ErrorMessage += ": " + ex.InnerException.Message;
                }
            }
            return Ok(response);
        }
    }
}
