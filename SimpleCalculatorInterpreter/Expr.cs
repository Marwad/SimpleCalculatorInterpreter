using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorInterpreter
{
    public class Expr
    {
        public Term term;
        public OperationType? operation;
        public Expr expr;
    }

    public class Term
    {
        public Factor factor;
        public OperationType? operation;
        public Term term;
    }
    public class Factor
    {

    }

}
