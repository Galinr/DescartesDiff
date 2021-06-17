using System;
using System.Collections.Generic;
using System.Text;

namespace DiffLibrary.Base64
{
    /// <summary>
    /// Razred vsebuje metodo za preverjanje enakosti BASE64 stringov
    /// </summary>
    public class BaseCheck
    {
        /// <summary>
        /// Metoda preverja znak po znak stringa.
        /// </summary>
        /// <param name="a">Model Data</param>
        /// <param name="b">Model Data</param>
        /// <returns>
        /// Model output z vrednostmi glede na preverbo stringov
        /// </returns>
        public static Models.Output BaseChecker(Models.Data a, Models.Data b)
        {
            if(a.Base.Length == b.Base.Length)
            {
                for (int i = 0; i < a.Base.Length; i++)
                {
                    if (a.Base[i] != b.Base[i])
                        return new Models.Output
                        {
                            Type = Models.DiffResultType.ContentDoNotMatch.ToString(),
                            Length = i,
                            Offset = i
                        };

                }
                return new Models.Output
                {
                    Type = Models.DiffResultType.Equals.ToString()
                };
            }
            return new Models.Output
            {
                Type = Models.DiffResultType.SizeDoNotMatch.ToString()
            };
        }
    }
}
