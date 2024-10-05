namespace OptionType
{
    public sealed class Option<T> where T : class
    {
        private readonly T? _value;

        public bool HasValue => _value is not null;
        public Option(T? value) => _value = value;

        public static Option<T> Some(T value) => new(value);

        public static Option<T> None() => new(default);

        public Option<TOut> Map<TOut>(Func<T, TOut> map) where TOut : class =>
            _value is null ? Option<TOut>.None() : Option<TOut>.Some(map(_value));

        public Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind) where TOut : class =>
            _value is null ? Option<TOut>.None() : bind(_value);

        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) => _value is null ? none() : some(_value);

    }
}
