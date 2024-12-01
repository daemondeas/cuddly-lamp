namespace cuddly_lamp.Input;

public interface IInput<T, U>
{
    T FirstFormattedInput(bool real);
    U SecondFormattedInput(bool real);
}

