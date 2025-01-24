namespace BetterOutcome
{
    /// <summary>
    /// Represents an optional value of T.
    /// </summary>
    /// <remarks>
    /// Wraps a nullable value of T to safely access it and avoid a NullReferenceException being thrown.
    /// </remarks>
    public abstract record Option<T>
    {
        /// <summary>
        /// Creates an instance of Option&lt;T&gt; based on a nullable value.
        /// </summary>
        /// <param name="value">The nullable value to wrap.</param>
        /// <returns>An Option value of T.</returns>
        public static Option<T> CreateFromValue(object? value)
        {
            if (value is T some)
                return Some<T>.Create(some);

            return None<T>.Create();
        }

        /// <summary>
        /// Creates an instance of Option&lt;T&gt; based on a nullable value.
        /// </summary>
        /// <param name="value">The nullable value to wrap.</param>
        /// <returns>An Option value of T.</returns>
        public static Option<T> CreateFromValue<TInput>(TInput? value) where TInput : struct
        {
            if (value is T some)
                return Some<T>.Create(some);

            return None<T>.Create();
        }
    }

    /// <summary>
    /// Represents an existent value of T.
    /// </summary>
    /// <remarks>
    /// Used to represent a T value when it is not null.
    /// </remarks>
    public record Some<T> : Option<T>
    {
        /// <summary>
        /// The not-null value of T.
        /// </summary>
        public T Value { get; init; }

        /// <summary>
        /// Creates an instance of Some&lt;T&gt; based on a not-null value.
        /// </summary>
        /// <param name="value">The not-null value to wrap.</param>
        /// <returns>A Some value of T.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        public Some(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Creates an instance of Some&lt;T&gt; based on a not-null value.
        /// </summary>
        /// <param name="value">The not-null value to wrap.</param>
        /// <returns>A Some value of T.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        public static Some<T> Create(T value)
        {
            return new Some<T>(value ?? throw new ArgumentNullException(nameof(value)));
        }
    }

    /// <summary>
    /// Represents a null value of T.
    /// </summary>
    /// <remarks>
    /// Used to represent a null value of T.
    /// </remarks>
    public record None<T> : Option<T>
    {
        /// <summary>
        /// Creates a value of None&lt;T&gt;.
        /// </summary>
        /// <returns>A None value of T.</returns>
        public None() { }

        /// <summary>
        /// Creates a value of None&lt;T&gt;.
        /// </summary>
        /// <returns>A None value of T.</returns>
        public static None<T> Create()
        {
            return new None<T>();
        }
    }
}