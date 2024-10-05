namespace OptionType
{
    public readonly struct ValueOption<T> where T : struct
    {
        private readonly T? _value;

        public ValueOption(T? value) => _value = value;

        public static ValueOption<T> Some(T value) => new(value);

        public static ValueOption<T> None() => new(default);

        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) => _value.HasValue ? some(_value.Value) : none();

        public T ValueOr(Func<T> valueProvider) => _value ?? valueProvider();
    }
}
