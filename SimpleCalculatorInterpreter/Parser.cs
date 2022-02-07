using System;
using System.Linq;
using System.Collections.Generic;

namespace SimpleCalculatorInterpreter
{
    public class Parser
    {
        public static Operation Parse(string cmd, LanguageManager languageManager)
        {
            if (cmd.ToLower().Equals("exit"))
            {
                return new Operation(OperationType.Exit);
            }
            if (cmd.ToLower().Equals("clear"))
            {
                return new Operation(OperationType.Clear);
            }
            if (cmd.ToLower().Equals("undo"))
            {
                return new Operation(OperationType.Undo);
            }
            var tokens = cmd.Replace("+", " + ")
                            .Replace("-", " - ")
                            .Replace("*", " * ")
                            .Replace("/", " / ")
                            .Split(new string[] { " " }, StringSplitOptions.None)
                            .Where(input => !string.IsNullOrEmpty(input))
                            .Select(x => new Token(x))
                            .ToList();
            if (tokens.Any(x=>x.type == TokenType.Unexpexted))
            {
                return new Operation(languageManager.unexpectedTokenMsg(tokens.First(x => x.type == TokenType.Unexpexted).value));
            }

            double v1, v2;
            if (tryParseNum(tokens,out v1))
            {
                // modify this
            }

            if (tokens[0].type == TokenType.Num)
            {
                return new Operation(languageManager.unexpectedTokenMsg(tokens.First(x => x.type == TokenType.Unexpexted).value));
            }

            if (tryParseNum(tokens, out v2))
            {
                // modify this
            }
            if (tokens.Count() != 3)
            {
                return new Operation(languageManager.formatMsg());
            }
            return (double.TryParse(tokens[0].value, out v1)) ?
                       (double.TryParse(tokens[2].value, out v2)) ?
                           new Operation(tokens[1].value, v1, v2, languageManager)
                       : new Operation(languageManager.NaNMsg(tokens[2].value))
                   : new Operation(languageManager.NaNMsg(tokens[0].value));
        }

        private static bool tryParseNum(List<Token> tokens, out double v)
        {
            v = 0;
            return true;
        }
    }


    
}