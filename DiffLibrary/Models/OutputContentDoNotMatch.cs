using System;
using System.Collections.Generic;
using System.Text;

namespace DiffLibrary.Models
{
    public class OutputContentDoNotMatch : IOutput
    {
        public string DiffResultType { get; set; }
        //public int Offset { get; set; }
        //public int Length { get; set; }

        public List<IOutputLengthOffset> Diffs { get; set; } = new List<IOutputLengthOffset>();
    }
}
