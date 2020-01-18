using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Calculator
{
    interface ICalculator<T>
    {
        //Сложение
        void Addition(T value1, T value2);

        //Вычитание
        void Subtraction(T value1, T value2);

        //Умножение
        void Multiplication(T value1, T value2);

        //Деление
        void Division(T value1, T value2);
    }
}
