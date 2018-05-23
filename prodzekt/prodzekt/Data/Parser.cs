using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace prodzekt.Data
{
    class Parser
    {
        public string text;
        int pos;
        char currentChar;
        char tmpChar;
        Token currentToken;
        string EOF = "EOF";
        string VAR = "VAR";
        string AND = "AND";
        string OR = "OR";
        string RIMPL = "RIMPL";
        string LIMPL = "LIMPL";
        string EQV = "EQV";
        public Parser(string text) {
            this.text = text;
            pos = 0;
            currentChar = text[pos];
            currentToken = null; 
        }
        void advance()
        {
            pos++;
            if(pos > text.Length - 1)
            {
                currentChar = '\0';
            }
            else
            {
                currentChar = text[pos];
            }
        }
        void skipWhitespace()
        {
            while(currentChar == ' ' && currentChar != '\0')
            {
                advance();
            }
        }
        
        public Token GetNextToken()
        {
            while (currentChar != '\0')
            {
                if(currentChar == ' ')
                {
                    skipWhitespace();
                    continue;
                }
                if ( Char.IsLetter(currentChar) )
                {
                    advance();
                    return new Token(VAR, currentChar);
                }
                if( currentChar == '∧')
                {
                    tmpChar = currentChar;
                    advance();
                    MessageBox.Show(currentChar.ToString());
                    return new Token(AND, tmpChar);

                }
                if (currentChar == '∨')
                {
                    
                    advance();
                    return new Token(OR, currentChar);
                }
                if (currentChar == '⇐')
                {
                    advance();
                    return new Token(LIMPL, currentChar);
                }
                if (currentChar == '⇒')
                {
                    
                    advance();
                    return new Token(RIMPL, currentChar);
                }
                if (currentChar == '⇔')
                {
                    advance();
                    return new Token(EQV, currentChar);
                }

                error();
                
                
            }
            return new Token(EOF, '\0');

        }
        public void eat(string tokenType)
        {
            if (currentToken.type == tokenType)
            {
                currentToken = GetNextToken();
            }
            else
            {
                error();
            }
        }
        public void error()
        {
            throw new Exception("Syntax error");
        }
        public bool checkIfValid()
        {
            currentToken = GetNextToken();
            MessageBox.Show(currentToken.ToString());
            return true;
        }

    }
}
