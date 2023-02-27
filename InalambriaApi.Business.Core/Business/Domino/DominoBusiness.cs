using InalambriaApi.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InalambriaApi.Business.Core.Business.Domino
{
    public class DominoBusiness
    { 

        public dynamic DataInTokens(List<DominoToken> tokens)
        {
            try
            {
                var JsonString = JsonConvert.SerializeObject(tokens);
                List<DominoToken> final = JsonConvert.DeserializeObject<List<DominoToken>>(JsonString);

                if (ValidateOPtions(final) == false)
                {
                    return null;
                }

                List<DominoToken> result = new List<DominoToken>();
                result.Add(final[0]);
                final.Remove(final[0]);
                int index = 0;

                while (final.Count > 0)
                {
                    for (int i = 0; i < final.Count; i++)
                    {

                        if (result[index].bvalue == final[i].avalue)
                        {
                            result.Add(final[i]);
                            final.Remove(final[i]);
                            index++;
                        }
                        else if (result[index].bvalue == final[i].bvalue)
                        {
                            result.Add(InvertToken(final[i]));
                            final.Remove(final[i]);
                            index++;
                        }
                    }
                }
                return result;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
                
        }

        public DominoToken InvertToken(DominoToken token)
        {
            DominoToken result = new DominoToken
            {
                avalue = token.bvalue,
                bvalue = token.avalue
            };

            return result;
        }

        public bool ValidateOPtions(List<DominoToken> tokens)
        {
            List<int> regla = new List<int>();
            foreach(DominoToken test in tokens)
            {
                regla.Add(test.avalue);
                regla.Add(test.bvalue);
            }

            Dictionary<int, int> frecuenciaNumeros = new Dictionary<int, int>();
            foreach (int numero in regla)
            {
                if (frecuenciaNumeros.ContainsKey(numero))
                {
                    frecuenciaNumeros[numero]++;
                }
                else
                {
                    frecuenciaNumeros[numero] = 1;
                }
            }

            foreach(int valor in frecuenciaNumeros.Values)
            {
                if (valor % 2 != 0 || valor<0 || valor>6)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
