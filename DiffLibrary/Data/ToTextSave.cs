using DiffLibrary.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiffLibrary.Data
{
    class ToTextSave
    {
        StreamWriter _sw;
        JsonSaver _js;

        public ToTextSave()
        {
            _sw = new StreamWriter(@"..\..\DiffingAPI\JSON.txt");
            _js = new JsonSaver(new Models.Data());
        }
        void JsonToFile()
        {
            _sw.WriteLine(_js.ReturnJSON);
        }

    }
}
