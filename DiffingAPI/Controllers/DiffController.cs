using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffingAPI.Controllers
{
    public enum side
    {
        left = 0,
        right
    }
    [ApiController]
    public class DiffController : ControllerBase
    {
        /// <summary>
        /// return data za določen ID in Stran
        /// </summary>
        /// <param name="id">ID vnosa</param>
        /// <param name="side">Stran vnosa</param>
        /// <returns></returns>
        [Route("/v1/diff/{id}/{side}")]
        public IActionResult Get(int id, side side)
        {
                return Ok($"returning value for id: {id} on {side} side");
        }

        /// <summary>
        /// Save data(base64) za določen ID in stran 
        /// </summary>
        /// <param name="id">id vnosa</param>
        /// <param name="side">stran vnosa</param>
        /// <param name="base64">Base64 string</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/v1/diff/{id}/{side}")]
        public IActionResult Put(int id, side side, string base64)
        {

            return StatusCode(201);
        }


    }
}
