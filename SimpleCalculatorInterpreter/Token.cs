using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorInterpreter
{
    public class Token
    {
        public readonly TokenType type;
        public readonly string value;
        public Token(string token)
        {
            this.value = token;
            switch (token)
            {
                case "+":
                    this.type = TokenType.OpPluse;
                    break;
                case "-":
                    this.type = TokenType.OpMinus;
                    break;
                case "*":
                    this.type = TokenType.OpMultiply;
                    break;
                case "/":
                    this.type = TokenType.OpDivide;
                    break;
                default:
                    this.type = double.TryParse(token, out _) ?TokenType.Num :TokenType.Unexpexted;
                    break;
            }
        }
    }
    public enum TokenType { 
        Num,
        OpPluse,
        OpMinus,
        OpMultiply,
        OpDivide,
        Unexpexted
    }
}
