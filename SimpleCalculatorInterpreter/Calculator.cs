using System;                     // to use : Consle
using System.Collections.Generic; // to use : Stack

namespace SimpleCalculatorInterpreter
{
    public class Calculator
    {

        private double _state;

        private Stack<Memento<double>> caretaker;

        private LanguageManager languageManager;
        public double State
        {
            get { return _state; }
        }
        public Calculator(LanguageManager languageManager)
        {
            this.languageManager = languageManager;
            _state = 0;
            caretaker = new Stack<Memento<double>>();
            caretaker.Push(CreateMemento());
        }

        public void Undo()
        {
            if (caretaker.Count > 1)
            {
                caretaker.Pop();
                SetMemento(caretaker.Peek());
                languageManager.StateMsg(_state);
            }
            else
            {
                Console.WriteLine(languageManager.noCommandsMsg());
            }
        }

        public void Clear()
        {
            _state = 0;
            SetMemento(CreateMemento());
            caretaker.Clear();
            caretaker.Push(CreateMemento());
            languageManager.StateMsg(_state);
        }

        public void Sum(double a, double b)
        {
            languageManager.ResultMsg(3, a + b);
            UpdateState(a + b);
        }

        public void Difference(double a, double b)
        {
            languageManager.ResultMsg(4, a - b);
            UpdateState(a - b);
        }
        public void Product(double a, double b)
        {
            languageManager.ResultMsg(5, a * b);
            UpdateState(a * b);
        }
        public void Divide(double a, double b)
        {
            languageManager.ResultMsg(6, a / b);
            UpdateState(a / b);
        }

        private void UpdateState(double val)
        {
            _state += val;
            caretaker.Push(CreateMemento());
            languageManager.StateMsg(_state);
        }
        private Memento<double> CreateMemento()
        {
            return (new Memento<double>(_state));
        }

        private void SetMemento(Memento<double> memento)
        {
            _state = memento.Data;
        }
    }
}
