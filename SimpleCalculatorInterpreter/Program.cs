using System;
using System.Globalization;

namespace SimpleCalculatorInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var spaces = many(satisfy(System.Char.IsWhiteSpace));
            var word = from w in many1(letter)   // letter = satisfy(Char.IsLetter)
                       from s in spaces
                       select w;
            var parser = many1(word);
            var result = parse(parser, "two words");
            Console.WriteLine(result);

            LanguageManager langManager = new LanguageManager(CultureInfo.InstalledUICulture.Name);
            Calculator calculator = new Calculator(langManager);
            Operation operation = Parser.Parse(Console.ReadLine(), langManager);
            while (operation.type != 0)
            {
                switch (operation.type)
                {
                    case OperationType.Clear:
                        calculator.Clear();
                        break;
                    case OperationType.Undo:
                        calculator.Undo();
                        break;
                    case OperationType.Plus:
                        calculator.Sum(operation.val1, operation.val2);
                        break;
                    case OperationType.Minus:
                        calculator.Difference(operation.val1, operation.val2);
                        break;
                    case OperationType.Multiply:
                        calculator.Product(operation.val1, operation.val2);
                        break;
                    case OperationType.Divide:
                        calculator.Divide(operation.val1, operation.val2);
                        break;
                    case OperationType.Error:
                        Console.WriteLine(operation.errMsg);
                        break;

                }
                operation = Parser.Parse(Console.ReadLine(), langManager);
            }
            Console.ReadKey();
        }

    }
}
