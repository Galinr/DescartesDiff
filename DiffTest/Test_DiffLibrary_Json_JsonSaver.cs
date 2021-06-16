using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace DiffTest
{
    public partial class Test_DiffLibrary_Json_JsonSaver : Component
    {
        public Test_DiffLibrary_Json_JsonSaver()
        {
            InitializeComponent();
        }

        public Test_DiffLibrary_Json_JsonSaver(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
