using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InalambriaApi.Data.StringsC
{
    public class AutherManagerConfiguration
    {
        public AutherManagerConfiguration(string autherString)
        {
            AutherString= autherString;
        }

        public string AutherString { get; set;}
    }
}
