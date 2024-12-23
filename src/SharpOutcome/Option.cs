namespace SharpOutcome
{
    public abstract record Option<T>
    {
        public static Some<T> CreateSome(T value)
        {
            return new Some<T>(value ?? throw new ArgumentNullException(nameof(value)));
        }

        public static None<T> CreateNone()
        {
            return new None<T>();
        }
    }

    public record Some<T> : Option<T>
    {
        public T Value { get; init; }

        public Some(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    public record None<T> : Option<T>
    {
        public None() { }
    }
}