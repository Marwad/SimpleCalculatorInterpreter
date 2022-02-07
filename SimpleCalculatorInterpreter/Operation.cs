using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorInterpreter
{
    public class Operation
    {
        public OperationType type { set; get; }
        public double val1 { set; get; }
        public double val2 { set; get; }
        public string errMsg { set; get; }

        public Operation(string message)
        {
            type = OperationType.Error;
            errMsg = message;
        }
        public Operation(string type, double v1, double v2, LanguageManager languageManager)
        {
            this.val1 = v1;
            this.val2 = v2;
            switch (type)
            {
                case "+":
                    this.type = OperationType.Plus;
                    break;
                case "-":
                    this.type = OperationType.Minus;
                    break;
                case "*":
                    this.type = OperationType.Multiply;
                    break;
                case "/":
                    if (v2 == 0)
                    {
                        this.type = OperationType.Error;
                        this.errMsg = languageManager.divByZeroMsg();
                    }
                    else this.type = OperationType.Divide;
                    break;
                default:
                    break;
            }
        }
        public Operation(OperationType type)
        {
            this.type = type;
        }

    }

    public enum OperationType
    {
        Error,
        Undo,
        Plus,
        Minus,
        Multiply,
        Divide,
        Clear,
        Exit
    }
}
