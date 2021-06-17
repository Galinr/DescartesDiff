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





            //var test = db.data.ToList();
            //if (test.Count() <= 0)
            //{
            //    a = new Data
            //    {
            //        ID = 1,
            //        Base = "aaadafa==",
            //        Side = "left"
            //    };
            //    Post(a);

            //    a = new Data
            //    {
            //        ID = 1,
            //        Base = "aaadafa==",
            //        Side = "right"
            //    };
            //    Post(a);
            //}



        }


        /// <summary>
        /// Metoda za primerjavo obeh objektov z enakim id-jem. 
        /// </summary>
        /// <param name="id">ID Modela katerega bomo preverjali</param>
        /// <returns>
        /// Vrne Model Output kateri vsebuje Tip napravilnosti in offset in length če je napaka to vsebovala
        /// </returns>
        [Route("/v1/diff/{id}")]
        public IActionResult Get(int id)
        {
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
        /// return data za določen ID in Stran
        /// </summary>
        /// <param name="Data">Data model</param>
        /// <returns></returns>
        [Route("/v1/diff/{id}/{side}")]
        public IActionResult Get([FromRoute]Data data)
        {
            List<Data> date = new List<Data>();
            date = db.data.ToList();
            var iskaniPodatek = this.db.data.Find(data.ID);

            if(iskaniPodatek == null)
            {
                return BadRequest("Napaka");
            }
            js = new DiffLibrary.JSON.JsonSaver(iskaniPodatek);
             return Ok(js.ReturnJSON);
        }



        /// <summary>
        /// Metoda za shranjevanje Modela v bazo podatkov
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/v1/diff/{id}/{side}")]
        public async Task<IActionResult> Post([FromBody]Data data)
        {
            if(string.IsNullOrEmpty(data.Base))
            {
                return StatusCode(400);
            }

            await db.data.AddAsync(data);
            await db.SaveChangesAsync();

            return Created($@"/v1/diff/{data.ID}/{data.Side}", data);
        }


    }
}
