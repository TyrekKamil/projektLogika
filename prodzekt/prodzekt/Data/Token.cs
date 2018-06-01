using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaChecker.Data
{
    public class Token
    {

        public enum Types { EOF, VAR, AND, OR, RIMPL, LIMPL, EQV, NEG, LPAREN, RPAREN};
        public string type;
        public char value;
        public Token(string typ, char wartosc) { type = typ; value = wartosc; }
        public override string ToString() {
            return "token: type " + type + " value: " + value;
        }
    }
}
