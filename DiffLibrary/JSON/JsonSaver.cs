using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiffingLibrary.JSON
{
    /// <summary>
    /// Helper class za shranjvanje in obdelavo modela v json
    /// </summary>
    public class JsonSaver
    {
        StreamWriter _sw;
        Models.Data _data;
        
        /// <summary>
        /// konstruktor razreda zahteva podatke tipa Data
        /// </summary>
        /// <param name="data">Model kateri vsebuje (id, base in stran)</param>
        public JsonSaver(Models.Data data)
        {
            _data = new Models.Data
            {
                ID = data.ID,
                Side = data.Side,
                Base = data.Base
            };
        }

        /// <summary>
        /// metoda katera bo vrnila model spremenjen (serializiran) v formatu JSON
        /// </summary>
        /// <returns>JSON format podatkov</returns>
        string JsonSerializator()
        {
            return System.Text.Json.JsonSerializer.Serialize(_data);
        }

        /// <summary>
        /// Metoda odgovorna za shranjevanje podatkov v TXT datoteko
        /// </summary>
        void JsonToFile()
        {
            _sw = new StreamWriter(@"..\..\DiffingAPI\JSON.txt");
            _sw.WriteLine(JsonSerializator());
        }

    }
}
