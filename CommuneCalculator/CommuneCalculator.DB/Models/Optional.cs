namespace CommuneCalculator.DB.Models
{
    public class Optional<TValue>
    {

        private TValue _value;

        public Optional(TValue value)
        {
            Value = value;
            HasValue = value != null && !value.Equals(default(TValue));
        }

        public TValue Value
        {
            get { return _value; }
            set
            {
                _value = value;
                HasValue = value != null && !value.Equals(default(TValue));
            }
        }

        public bool HasValue { get; private set; }
    }
}