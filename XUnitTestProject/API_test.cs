using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class API_test
    {
        [Fact]
        public void Get_Success()
        {
            var options = new DbContextOptionsBuilder<DiffLibrary.DataBase.DiffDbContext>()
            .UseInMemoryDatabase(databaseName: "UnitTesting")
            .Options;

            using(var db = new DiffLibrary.DataBase.DiffDbContext(options))
            {
                db.data.Add(new DiffLibrary.Models.Data
                {
                    ID = 1,
                    Base = "SGVsbG8gd29ybGQ=",
                    Key = 1,
                    Side = DiffLibrary.Models.Side.left.ToString()
                });

                db.data.Add(new DiffLibrary.Models.Data
                {
                    ID = 1,
                    Base = "SGVsbG8gd29ybGQ=",
                    Key = 2,
                    Side = DiffLibrary.Models.Side.right.ToString()
                });
                db.SaveChanges();
            }


            using (var db = new DiffLibrary.DataBase.DiffDbContext(options))
            {
                DiffingAPI.Controllers.DiffController controller = new DiffingAPI.Controllers.DiffController(db);

                var get = controller.Get();


            }


        }
    }
}
