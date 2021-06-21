using System;
using System.Collections.Generic;
using System.Text;

namespace DiffLibrary.Models
{
    public class OutputLengthOffset : IOutputLengthOffset
    {
        public int Length { get; set; }
        public int Offset { get; set; }
    }
}
