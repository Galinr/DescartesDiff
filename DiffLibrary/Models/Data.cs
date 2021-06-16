using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffingLibrary.Models
{
    public class Data
    {
        private int id;
        private string side;
        private string _base;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

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
