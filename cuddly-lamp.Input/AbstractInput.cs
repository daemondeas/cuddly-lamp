namespace cuddly_lamp.Input;

public abstract class AbstractInput<T, U> : IInput<T, U>
{
    public abstract string TestInput { get; }
    public abstract string RealInput { get; }
    public T FirstFormattedInput(bool real)
    {
        return FormatFirst(real ? RealInput : TestInput);
    }

    public U SecondFormattedInput(bool real)
    {
        return FormatSecond(real ? RealInput : TestInput);
    }

    protected abstract T FormatFirst(string input);
    protected abstract U FormatSecond(string input);
}

