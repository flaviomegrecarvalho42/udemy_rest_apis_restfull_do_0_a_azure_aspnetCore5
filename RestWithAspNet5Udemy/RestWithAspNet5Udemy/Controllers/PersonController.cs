﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNet5Udemy.Models;
using RestWithAspNet5Udemy.BLL.Interfaces;

namespace RestWithAspNet5Udemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBLL _personBll;

        public PersonController(ILogger<PersonController> logger, IPersonBLL personBll)
        {
            _logger = logger;
            _personBll = personBll;
        }

        /// <summary>
        /// Maps GET requests to https://localhost:{port}/api/person
        /// Get no parameters for FindAll -> Search All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBll.FindAll());
        }

        /// <summary>
        /// Maps GET requests to https://localhost:{port}/api/person/{id}
        /// receiving an ID as in the Request Path
        /// Get with parameters for FindById -> Search by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personBll.FindById(id);
            
            if (person == null)
                return NotFound();
            
            return Ok(person);
        }

        /// <summary>
        /// Maps POST requests to https://localhost:{port}/api/person/
        /// [FromBody] consumes the JSON object sent in the request body
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personBll.Create(person));
        }

        /// <summary>
        /// Maps PUT requests to https://localhost:{port}/api/person/
        /// [FromBody] consumes the JSON object sent in the request body
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return Ok(_personBll.Update(person));
        }

        /// <summary>
        /// Maps DELETE requests to https://localhost:{port}/api/person/{id}
        /// receiving an ID as in the Request Path
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("{id}")]
        public IActionResult Delete(long id)
        {
            _personBll.Delete(id);

            return NoContent();
        }
    }
}
