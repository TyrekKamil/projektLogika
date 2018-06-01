using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FormulaChecker.Data
{
    class Interpreter
    {
        Lexer lexer;
        Token currentToken;
        bool isValid;

    public Interpreter(Lexer lexer)
    {
            this.lexer = lexer;
            currentToken = lexer.GetNextToken();
            isValid = true;

    }

        public void eat(string tokenType)
        {
            if (currentToken.type == tokenType)
            {
                currentToken = lexer.GetNextToken();
            }
            else
            {
                MessageBox.Show("Syntax error! Expected: " + tokenType);
                error();
            }
        }

        void error()
        {
            isValid = false;
        }



        void factor()
        {
            Token token = currentToken;
            if(token.type == Token.Types.VAR.ToString())
            {
                eat(Token.Types.VAR.ToString());
            }
            else if(token.type == Token.Types.NEG.ToString())
            {
                eat(Token.Types.NEG.ToString());
                factor();
            }
            else if(token.type == Token.Types.LPAREN.ToString())
            {
                eat(Token.Types.LPAREN.ToString());
                expr();
                eat(Token.Types.RPAREN.ToString());
            }
            else
            {
                error();
            }

        }

        bool isOperator(Token currentToken)
        {
            if (currentToken.type == Token.Types.AND.ToString() || currentToken.type == Token.Types.OR.ToString() ||
               currentToken.type == Token.Types.EQV.ToString() || currentToken.type == Token.Types.LIMPL.ToString() ||
               currentToken.type == Token.Types.RIMPL.ToString())
            {
                return true;
            }
            return false;
        }
        void expr()
        {
            factor();

            while (isOperator(currentToken))
            {
                if (currentToken.type == Token.Types.AND.ToString())
                {
                    eat(Token.Types.AND.ToString());
                    factor();
                }
                else if (currentToken.type == Token.Types.OR.ToString())
                {
                    eat(Token.Types.OR.ToString());
                    factor();
                }
                else if (currentToken.type == Token.Types.EQV.ToString())
                {
                    eat(Token.Types.EQV.ToString());
                    factor();
                }
                else if (currentToken.type == Token.Types.LIMPL.ToString())
                {
                    eat(Token.Types.LIMPL.ToString());
                    factor();
                }
                else if (currentToken.type == Token.Types.RIMPL.ToString())
                {
                    eat(Token.Types.RIMPL.ToString());
                    factor();
                }
                else
                {
                    error();
                }
            }
        }
        public bool checkIfValid()
        {
            expr();
            eat(Token.Types.EOF.ToString());
            return isValid;
        }
    }
}
