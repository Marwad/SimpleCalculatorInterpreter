namespace SimpleCalculatorInterpreter
{
    public class Memento<E>
    {
        private E m_data;

        public Memento()
        {
            m_data = default;
        }

        public Memento(E value)
        {
            m_data = value;
        }

        public E Data
        {
            get
            {
                return m_data;
            }
            set
            {
                m_data = value;
            }
        }
    }
}
