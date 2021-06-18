using System;
using System.Collections.Generic;
using System.Text;

namespace DiffLibrary.Models
{
    public class OutputContentDoNotMatch : IOutputLengthOffset
    {
        public string DiffResultType { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }

    }
}
