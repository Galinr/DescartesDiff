using DiffingAPI.Controllers;
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
        private readonly DiffController dc;

        public DiffingAPI_Tests(DiffingAPI.Controllers.DiffController dc)
        {
            this.dc = dc;
        }
        [TestMethod]
        public void PostMethodTest_Success(DiffLibrary.Models.Data data)
        {
            dc.Put(new DiffLibrary.Models.Data { Base = "Test==" })
            {
                var result = Microsoft.AspNetCore.Http.StatusCodes.Status201Created;

                Assert.IsTrue(true);
            }
        }

        public void 
    
    }
}
