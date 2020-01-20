namespace TestProject.Calculator
{
    interface ICalculator<T>
    {
        //Сложение
        T Addition(T value1, T value2);

        //Вычитание
        T Subtraction(T value1, T value2);

        //Умножение
        T Multiplication(T value1, T value2);

        //Деление
        T Division(T value1, T value2);
    }
}
