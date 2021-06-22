using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDiffingAPI
{
    [TestClass]
    public class DiffLibrary_Tests
    {
        [TestMethod]
        public bool BaseCheck_Success()
        {
            DiffLibrary.Models.Data a = new DiffLibrary.Models.Data({ });
            DiffLibrary.Models.Data b = new DiffLibrary.Models.Data();


            DiffLibrary.Models.IOutput

        }

    }
}
