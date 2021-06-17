using DiffLibrary.Models;
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
        /// <param name="Data">Data model</param>
        /// <returns></returns>
        [Route("/v1/diff/{id}/{side}")]
        public IActionResult Get([FromRoute]Data data)
        {
                return Ok($"returning value for id: {data.ID} on {data.Side} side");
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
        public IActionResult Post(int id, side side, string base64)
        {
            return StatusCode(201);
        }


    }
}
