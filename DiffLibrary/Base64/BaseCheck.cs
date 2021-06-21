using DiffLibrary.Models;
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
        /// Metoda preverja znak po znak stringa katerega najprej dekodiramo iz Base64.
        /// </summary>
        /// <param name="prva">Model Data</param>
        /// <param name="druga">Model Data</param>
        /// <returns>
        /// Model output z vrednostmi glede na preverbo stringov. 
        /// - Equals če sta dekodirana stringa enaka,
        /// - SizeDoNotMatch če je dolžina stringa drugačna
        /// - ContentDoNotMatch če se indexi v stringu ne ujemajo
        /// </returns>
        public static Models.IOutput BaseChecker(Models.Data prva, Models.Data druga)
        {
            var outputContentDoNotMatch = new Models.OutputContentDoNotMatch();
            int zacetek = 0;
            bool razlikovanje = false;
            string a = Base64Helper.Base64Decode(prva.Base);
            string b = Base64Helper.Base64Decode(druga.Base);
            int stevec = 0;

            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        razlikovanje = true;
                        stevec++;
                    }
                    else
                    {
                        razlikovanje = false;
                    }

                    if (razlikovanje && stevec == 1)
                    {
                        zacetek = i;
                    }
                    else if (!razlikovanje && stevec != 0)
                    {
                        if(outputContentDoNotMatch.DiffResultType != DiffResultType.ContentDoNotMatch.ToString())
                        {
                            outputContentDoNotMatch.DiffResultType = DiffResultType.ContentDoNotMatch.ToString();
                        }
                        outputContentDoNotMatch.Diffs.Add(new OutputLengthOffset
                        {
                            Length = stevec,
                            Offset = zacetek
                        });
                        stevec = 0;
                    }


                    if (i == a.Length -1 && outputContentDoNotMatch.Diffs.Count > 0)
                    {
                        if (razlikovanje)
                        {
                            outputContentDoNotMatch.Diffs.Add(new OutputLengthOffset
                            {
                                Length = stevec,
                                Offset = zacetek
                            });
                        }
                        return outputContentDoNotMatch;
                    }
                }
                return new Models.Output
                {
                    DiffResultType = Models.DiffResultType.Equals.ToString()
                };
            }
            else
            {
                return new Models.Output
                {
                    DiffResultType = Models.DiffResultType.SizeDoNotMatch.ToString()
                };
            }

        }
    }
}
