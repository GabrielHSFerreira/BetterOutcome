namespace BetterOutcome
{
    public abstract record Option<T>
    {
        public static Option<T> CreateFromValue(object? value)
        {
            if (value is T some)
                return Some<T>.Create(some);

            return None<T>.Create();
        }

        public static Option<T> CreateFromValue<TInput>(TInput? value) where TInput : struct
        {
            if (value is T some)
                return Some<T>.Create(some);

            return None<T>.Create();
        }
    }

    public record Some<T> : Option<T>
    {
        public T Value { get; init; }

        public Some(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static Some<T> Create(T value)
        {
            return new Some<T>(value ?? throw new ArgumentNullException(nameof(value)));
        }
    }

    public record None<T> : Option<T>
    {
        public None() { }

        public static None<T> Create()
        {
            return new None<T>();
        }
    }
}