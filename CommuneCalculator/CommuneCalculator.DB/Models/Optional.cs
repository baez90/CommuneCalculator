namespace CommuneCalculator.DB.Models
{
    public struct Optional<T>
    {
        private Optional(T value)
        {
            Value = value;
            HasValue = value != null && !value.Equals(default(T));
        }

        public T Value { get; }

        public bool HasValue { get; }

        public static Optional<TO> Of<TO>(TO value)
        {
            return new Optional<TO>(value);
        }

        public static Optional<TO> Empty<TO>()
        {
            return new Optional<TO>(default(TO));
        }

        public static implicit operator Optional<T>(T value)
        {
            return Of(value);
        }
    }
}