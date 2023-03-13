
using HW.Interfaces;
using HW.Models;
using HW.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FintechRestAPI.Controllers
{
    /// <summary>
    ///  FintechController class handles HTTP GET, POST, PUT, and DELETE requests.
    /// </summary>
    /// 
    [ApiController]
    [Route("[controller]")]

    public class FintechController : ControllerBase
    {
        /// <summary>
        /// _logger is property of  Controller  that implements ILogger interface. 
		/// It is used for logging purpose,it is defined  as private and readonly
        /// </summary>

        private readonly ILogger<FintechController> _logger;
        private readonly IFintechRepository _fintech;

        public FintechController(ILogger<FintechController> logger, IFintechRepository fintech)
        {
            _logger = logger;
            _fintech = fintech;
        }



        /// <summary>
        /// Action for getting Item
        /// </summary>
        /// <returns>action will return a 200 Ok status code when it runs successfully</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Fintech>))]

        public IActionResult getItems()
        {
            _logger.Log(LogLevel.Information, "Get Items");
            return Ok(_fintech.getItems());
        }


        /// <summary>
        /// Action for getting Item based on id
        /// </summary>
        /// <returns>action will return a 200 Ok status code when it runs successfully</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Fintech))]
        [ProducesResponseType(404)]

        public IActionResult GetItem(int id)
        {
            Fintech get_data = _fintech.GetItem(id);
            if (get_data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(get_data);
            }

        }

        /// <summary>
        /// Action for checking if the Account exists
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>action will return a 200 Ok status code when it runs successfully</returns>

        [HttpGet("AccountExists")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult AccountExists(int id)
        {
            bool result = _fintech.AccountExists(id);

            if (!result)
            {
                return NotFound("No matching id");
            }
            else
            {
                return Ok("Account exists");
            }
        }


        /// <summary>
        /// Action for creating Item
        /// </summary>
        /// <returns>action will return a 200 Ok status code when it runs successfully</returns>

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult AddAccount([FromBody] Fintech account)
        {
            if (account == null)
            {
                return BadRequest("Account is null");
            }

            bool result = _fintech.AddAccount(account);
            return result ? Ok(result) : BadRequest();
        }


        /// <summary>
        /// Action for updating Item
        /// </summary>
        /// <returns>action will return a 200 Ok status code when it runs successfully</returns>

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public IActionResult EditAccount([FromBody] Fintech updated)
        {
            if (updated == null)
            {
                return BadRequest("Account is null");
            }
            bool result = _fintech.EditAccount(updated);

            return result ? Ok(result) : BadRequest();
        }


        /// <summary>
        /// Action for deleting Item
        /// </summary>
        /// <returns>action will return a 200 Ok status code when it runs successfully</returns>

        [HttpDelete]
        public IActionResult DeleteAccount(Fintech account)
        {
            bool result = _fintech.DeleteAccount(account);

            return result ? Ok(result) : BadRequest();
        }




        /// <summary>
        /// //This is a get request to Analyse mean, median and mode.
        /// </summary>
        /// <returns></returns>

        [HttpGet("Analyse")]
        public IActionResult Analyse()
        {
            return Ok(_fintech.analyzeBill());

        }

    }



}