using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class Base64Test
    {
        [Fact]
        public void BaseEncode_success()
        {
            var pricakovanRezultat = "SGVsbG8gd29ybGQ=";

            var rezultat = "Hello world";
            var testiraniRezultat = DiffLibrary.Base64.Base64Helper.Base64Encode(rezultat);

            Assert.Equal(testiraniRezultat, pricakovanRezultat);
        }

        [Fact]
        public void BaseEncode_Fail_Throw_ArgumentException()
        {
            var pricakovanRezultat = "SGVsbG8gd29ybGQ=";

            var rezultat = "";
            var testiraniRezultat = DiffLibrary.Base64.Base64Helper.Base64Encode(rezultat);



        }



    }
}
