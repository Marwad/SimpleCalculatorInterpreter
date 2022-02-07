using System;                      // to use : Console
using System.Collections.Generic;  // to use : List

namespace SimpleCalculatorInterpreter
{
    public class LanguageManager
    {
        private string lang;
        public LanguageManager(string lang)
        {
            lang = lang.Substring(0, 2);
            List<string> supportedLanguages;
            supportedLanguages = new List<string>();
            supportedLanguages.Add("fr");
            supportedLanguages.Add("es");
            supportedLanguages.Add("de");
            this.lang = supportedLanguages.Contains(lang) ? lang : "en";
        }

        public string unexpectedTokenMsg(string token)
        {
            switch (lang)
            {
                case "en":
                    return $"Unexpected token '{token}'";
                case "fr":
                    return $"Jeton inattendu '{token}'";
                case "es":
                    return $"Neatendita signo '{token}'";
                case "de":
                    return $"Onverwacht teken '{token}'";
            }
            // won't reach here..
            return "";
        }
        public string divByZeroMsg()
        {
            switch (lang)
            {
                case "en":
                    return "Division By Zero is not allowed";
                case "fr":
                    return "La division par zéro n'est pas autorisée";
                case "es":
                    return "No se permite la división por cero";
                case "de":
                    return "Division By Zero ist nicht erlaubt";
            }
            // won't reach here..
            return "";
        }
        public string formatMsg()
        {
            switch (lang)
            {
                case "en":
                    return "Invalid input format ";
                case "fr":
                    return "Format d'entrée non valide";
                case "es":
                    return "No se permite la división por cero";
                case "de":
                    return "Formato de entrada no válido";
            }
            // won't reach here..
            return "";
        }

        public string NaNMsg(string nan)
        {
            switch (lang)
            {
                case "en":
                    return "(" + nan + ") must be numeric.";
                case "fr":
                    return "(" + nan + ") doit être numérique.";
                case "es":
                    return "(" + nan + ") debe ser numérico.";
                case "de":
                    return "(" + nan + ") muss numerisch sein.";
            }
            // won't reach here..
            return "";
        }
        public string noCommandsMsg()
        {
            switch (lang)
            {
                case "en":
                    return "No commands to Undo.";
                case "fr":
                    return "Aucune commande à annuler.";
                case "es":
                    return "No hay comandos para deshacer.";
                case "de":
                    return "Keine Befehle zum Rückgängigmachen.";
            }
            // won't reach here..
            return "";
        }
        public void StateMsg(double state)
        {
            switch (lang)
            {
                case "en":
                    Console.WriteLine("Running Total: " + state);
                    break;
                case "fr":
                    Console.WriteLine("Total courant: " + state);
                    break;
                case "es":
                    Console.WriteLine("Total corriente:" + state);
                    break;
                case "de":
                    Console.WriteLine("Laufende Summe: " + state);
                    break;
            }
        }

        public void ResultMsg(int op, double result)
        {
            Console.WriteLine(OperationName(op) + ": " + result + ";");
        }

        private string OperationName(int op)
        {
            switch (lang)
            {
                case "en":
                    return op == 3 ? "Sum" :
                           op == 4 ? "Difference" :
                           op == 5 ? "Product" :
                           "Division";
                case "fr":
                    return op == 3 ? "Somme" :
                           op == 4 ? "différence" :
                           op == 5 ? "Produit" :
                           "Division";
                case "es":
                    return op == 3 ? "Suma" :
                           op == 4 ? "Diferencia" :
                           op == 5 ? "Producto" :
                           "División";
                case "de":
                    return op == 3 ? "Summe" :
                           op == 4 ? "Unterschied" :
                           op == 5 ? "Produkt" :
                           "die Teilung";
            }
            // won't reach here....
            return "";
        }





    }
}
