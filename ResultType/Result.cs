namespace ResultType;

public class Result<TValue>
{
    private readonly TValue? _value;
    private readonly Error _error;

    private readonly bool _isSucces;

    private Result(TValue value) => (_value, _isSucces, _error) = (value, true, Error.None);

    private Result(Error error) => (_error, _isSucces) = (error, false);

    public static Result<TValue> Success(TValue value) => new(value);

    public static Result<TValue> Failure(Error error) => new(error);

    public static implicit operator Result<TValue>(TValue value) => new(value);
    
    public static implicit operator Result<TValue>(Error error) => new(error);

    public TResult Match<TResult>(Func<TValue, TResult> success, Func<Error, TResult> failure) => _isSucces ? success(_value!) : failure(_error);
}
