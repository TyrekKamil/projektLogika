using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace FormulaChecker.Data
{
    class Lexer
    {
        public string text;
        int pos;

        char currentChar;
        char tmpChar;
        
        public Lexer(string text) {
            this.text = text;
            pos = 0;
            currentChar = text[pos];
            
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
                    tmpChar = currentChar;
                    advance();
                    return new Token(Token.Types.VAR.ToString(), tmpChar);
                }
                if( currentChar == '∧')
                {
                    advance();
                    return new Token(Token.Types.AND.ToString(), '∧');

                }
                if (currentChar == '∨')
                {
                    
                    advance();
                    return new Token(Token.Types.OR.ToString(), '∨');
                }
                if (currentChar == '⇐')
                {
                    advance();
                    return new Token(Token.Types.LIMPL.ToString(), '⇐');
                }
                if (currentChar == '⇒')
                {
                    
                    advance();
                    return new Token(Token.Types.RIMPL.ToString(), '⇒');
                }
                if (currentChar == '⇔')
                {
                    advance();
                    return new Token(Token.Types.EQV.ToString(), '⇔');
                }

                if(currentChar == '¬')
                {
                    while(currentChar == '¬')
                    advance();

                    return new Token(Token.Types.NEG.ToString(), '¬');
                }

                if (currentChar == '(')
                {
                    advance();
                    return new Token(Token.Types.LPAREN.ToString(), '(');
                }

                if (currentChar == ')')
                {
                    advance();
                    return new Token(Token.Types.RPAREN.ToString(), ')');
                }

                error();
                
            }
            return new Token(Token.Types.EOF.ToString(), '\0');

        }
        
        public void error()
        {
            throw new Exception("Invalid character");
        }

    }
}
