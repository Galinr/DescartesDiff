using DiffLibrary.DataBase;
using DiffLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiffingAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class DiffController : ControllerBase
    {
        private readonly DiffDbContext db;
        Data a;

        DiffLibrary.JSON.JsonSaver js; 

        public DiffController(DiffLibrary.DataBase.DiffDbContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Metoda za primerjavo obeh objektov z enakim id-jem. 
        /// </summary>
        /// <param name="id">ID Modela katerega bomo preverjali</param>
        /// <returns>
        /// Vrne Model Output kateri vsebuje Tip napravilnosti, offset in length če je napaka to vsebovala
        /// </returns>
        [Route("/v1/diff/{id}")]
        public IActionResult Get()
        {
            int id;
            if (!Int32.TryParse(RouteData.Values["id"].ToString(), out id))
            {
                throw new ArithmeticException("V URI je zahtevan vnos ID v obliki številke\nhttps://localhost:5001/v1/diff/<id>/left.");
            }

            List<Data> date = new List<Data>();
            date = db.data.Where(x=>x.ID.Equals(id)).ToList();
            if (date == null)
            {
                return BadRequest("Napaka");
            }
            else if(date.Count <= 2)
            {
                return NotFound("404 Not Found");
            }
            return Ok(DiffLibrary.Base64.BaseCheck.BaseChecker(date[0], date[1]));
        }


        /// <summary>
        /// Metoda POST za vnos novih podatkov v podatkovno bazo.
        /// </summary>
        /// <param name="data">pridobljeni podatki</param>
        /// <returns>
        /// </returns>
        [HttpPost]
        [Route("/v1/diff/{id}/{side}")]
        public async Task<IActionResult> Post([FromBody] Data data)
        {
            int id;
            if(!Int32.TryParse(RouteData.Values["id"].ToString(), out id))
            {
                throw new ArithmeticException("V URI je zahtevan vnos ID v obliki številke\nhttps://localhost:5001/v1/diff/<id>/left.");
            }

            string left = Side.left.ToString();
            string right = Side.right.ToString();

            string side = (string)RouteData.Values["side"];
            if (side.ToLower() != Side.left.ToString() && side.ToLower() != Side.right.ToString())
            {
                throw new FormatException("V URI je zahtevan vnos side v izbiri LEFT ali RIGHT zapisano z malimi črkami.");
            }
            

            var obstaja = db.data.ToList();
            foreach (var vnos in obstaja)
            {
                if(vnos.ID == id && vnos.Side == side)
                {
                    return Content("Podatek z tem ID in STRANJO že obstaja. Izberi nov ID.");
                }
            }


            if (string.IsNullOrEmpty(data.Base))
            {
                return BadRequest("Base64 je bil prezen oziroma ne obstaja.");
            }

            data.ID = id;
            data.Side = side;

            
            await db.SaveChangesAsync();

            return Created($@"/v1/diff/{data.ID}/{data.Side}", data);
        }
    }
}
