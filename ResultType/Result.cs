namespace ResultType;

public class Result<TValue>
{
    private readonly TValue? _value;
    private readonly Error _error;

    private readonly bool _isSucces;

    private Result(TValue value) => (_value, _isSucces) = (value, true);

    private Result(Error error) => (_error, _isSucces) = (error, false);

    public static Result<TValue> Success(TValue value) => new(value);

    public static Result<TValue> Failure(Error error) => new(error);
}
