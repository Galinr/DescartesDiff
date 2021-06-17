using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiffLibrary.JSON
{
    /// <summary>
    /// Helper class obdelavo modela v json
    /// </summary>
    public class JsonSaver
    {
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
        /// Properti za vračanje vrednosti _data
        /// </summary>
        public string ReturnJSON
        {
            get
            {
                return JsonSerializator();
            }
        }


        /// <summary>
        /// metoda katera bo vrnila model spremenjen (serializiran) v formatu JSON
        /// </summary>
        /// <returns>JSON format podatkov</returns>
        string JsonSerializator()
        {
            return System.Text.Json.JsonSerializer.Serialize(_data);
        }
    }
}
