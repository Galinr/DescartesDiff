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

        public DiffController(DiffLibrary.DataBase.DiffDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Metoda za primerjavo obeh objektov z enakim id-jem katerega pridobino iz URI. 
        /// </summary>
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
            else if(date.Count < 2)
            {
                return NotFound("404 Not Found");
            }
            return Ok(DiffLibrary.Base64.BaseCheck.BaseChecker(date[0], date[1]));
        }


        /// <summary>
        /// Metoda PUT za vnos novih podatkov v podatkovno bazo ali update starih vnosov (base).
        /// </summary>
        /// <param name="json">pridobljeni podatki FromBody</param>
        /// <returns>
        /// 
        /// </returns>
        [HttpPut]
        [Route("/v1/diff/{id}/{side}")]
        public async Task<IActionResult> Put([FromBody] IData json)
        {
            
            int id;
            if(!Int32.TryParse(RouteData.Values["id"].ToString(), out id))
            {
                throw new ArithmeticException("V URI je zahtevan vnos ID v obliki številke\nhttps://localhost:5001/v1/diff/<id>/left.");
            }

            string side = (string)RouteData.Values["side"];
            if (side.ToLower() != Side.left.ToString() && side.ToLower() != Side.right.ToString())
            {
                throw new FormatException("V URI je zahtevan vnos side v izbiri LEFT ali RIGHT zapisano z malimi črkami.");
            }

            if (string.IsNullOrEmpty(json.Base))
            {
                return BadRequest("Base64 je bil prezen oziroma ne obstaja.");
            }

            var podatek = db.data.Where(x => x.ID == id && x.Side == side).FirstOrDefault();
            
            if (podatek != null)
            {
                podatek.Base = json.Base;
                db.Entry(podatek).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Update v bazi.

                await db.SaveChangesAsync();

                return Created($@"/v1/diff/{id}/{side}", podatek);
            }
            else
            {
                var novVnos = new Data
                {
                    ID = id,
                    Side = side,
                    Base = json.Base
                };
                await db.data.AddAsync(novVnos);

                await db.SaveChangesAsync();
                return Created($@"/v1/diff/{id}/{side}", novVnos);
            }
            
        }






        /// <summary>
        /// Testna metoda za pridobivanje vseh zapisov v bazi
        /// </summary>
        /// <returns></returns>
        [Route("/v1/diff/")]
        public IActionResult GetAll()
        {
            return Ok(db.data.ToList());
        }






    }
}
