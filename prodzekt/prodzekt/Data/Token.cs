using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prodzekt.Data
{
    public class Token
    {
        public string type;
        public char value;
        public Token(string typ, char wartosc) { type = typ; value = wartosc; }
        public override string ToString() {
            return "token: type " + type + " value: " + value;
        }
    }
}
