﻿using Nop.Services.Logging;
using System.Collections.Generic;
using System.Web.Http;

namespace Nop.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private readonly IUserActivityService _userActivityService;

        public ValuesController(IUserActivityService userActivityService)
        {
            _userActivityService = userActivityService;
        }
        // GET api/<controller>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route()]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [Route()]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [Route("{id:int}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Route("{id:int}")]
        public void Delete(int id)
        {
        }
    }
}