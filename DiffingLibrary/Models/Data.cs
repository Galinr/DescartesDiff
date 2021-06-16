using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffingLibrary.Models
{
    public class Data
    {
        private string _base;

        public string MyProperty
        {
            get { return _base; }
            set { _base = value; }
        }

    }
}
