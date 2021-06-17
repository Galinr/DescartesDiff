using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffLibrary.Models
{
    public class Data
    {
        private int id;
        private string side;
        private string _base;

        [FromRoute(Name = "id")]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [FromRoute(Name = "side")]
        public string Side
        {
            get { return side; }
            set { side = value; }
        }

        public string Base
        {
            get { return _base; }
            set { _base = value; }
        }
    }
}
