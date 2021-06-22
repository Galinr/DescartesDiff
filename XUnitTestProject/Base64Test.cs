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
            ArgumentException aEx = Assert.Throws<ArgumentException>(() => DiffLibrary.Base64.Base64Helper.Base64Encode(""));
            Assert.Equal("String je bil prazen", aEx.Message);
        }

        [Fact]
        public void BaseDecode_success()
        {
            var pricakovanRezultat = "Hello world";

            var rezultat = "SGVsbG8gd29ybGQ=";
            var testiraniRezultat = DiffLibrary.Base64.Base64Helper.Base64Decode(rezultat);

            Assert.Equal(testiraniRezultat, pricakovanRezultat);
        }

        [Fact]
        public void BaseDecode_Fail_Throw_ArgumentException()
        {
            ArgumentException aEx = Assert.Throws<ArgumentException>(() => DiffLibrary.Base64.Base64Helper.Base64Decode(""));
            Assert.Equal("String je bil prazen", aEx.Message);
        }


    }
}
