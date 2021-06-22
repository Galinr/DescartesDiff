using DiffingAPI.Controllers;
using DiffLibrary.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDiffingAPI
{
    [TestClass]
    public class DiffingAPI_Tests
    {
        DiffLibrary.DataBase.DiffDbContext database;
        DiffController diffController;


        /// <summary>
        /// Metoda za inicializacijo potrebnih objektov. 
        /// za ustvarjanje FAKE baze uprabljen FAKEITEASY NuGet package
        /// </summary>
        [ClassInitialize()]
        public void SetUp()
        {
            database = A.Fake<DiffLibrary.DataBase.DiffDbContext>();
            diffController = new DiffController(database);
        }


        /// <summary>
        /// Test Put metode. Ta metoda bo uspešna
        /// </summary>
        /// <param name="data">
        /// Model data
        /// </param>
        [TestMethod]
        public async Task PutMethod_Success([FromBody] DiffLibrary.Models.Data data)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            //Arrange
            var podatek = new Data
=======
            dc.Post(new DiffLibrary.Models.Data { Base = "Test==" })
>>>>>>> parent of d8990d3 (Spremnil izpis v primeru ContentDoNotMatch)
=======
            dc.Post(new DiffLibrary.Models.Data { Base = "Test==" })
>>>>>>> parent of d8990d3 (Spremnil izpis v primeru ContentDoNotMatch)
            {
                Base = "bbb=",
                ID = 1,
                Side = DiffLibrary.Models.Side.left.ToString()
            };

            //Act
            var actionResult = await diffController.Put(podatek);

            //Assert
            var result = actionResult as OkObjectResult;

            Assert.Equals(result, 201);


        }


        [TestMethod]
        public void GetMethod_Success() 
        {
            var podatki = diffController.GetAll();

            Assert.IsNotNull(podatki);



        }
    
    }
}
