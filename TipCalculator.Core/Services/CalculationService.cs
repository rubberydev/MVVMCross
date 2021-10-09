using System;

namespace TipCalculator.Core.Services
{
    public class CalculationService : ICalculationService
    {
        public decimal Division(int firstValue, int secondValue)
        {
            try
            {
                return firstValue / secondValue;
            }
            catch (Exception)
            {
                return 0;

            }
        }

        public int Multiplication(int firstValue, int secondValue) => firstValue * secondValue;
        public double Sqrt(int number) => Math.Sqrt(number);

        public int Substraction(int firstValue, int secondValue) => firstValue - secondValue;

        public int Sum(int firstValue, int secondValue) => firstValue + secondValue;

        public decimal TipAmount(decimal subTotal, double generosity)
        {
            return subTotal * (decimal)(generosity / 100);
        }

        //double Pow(int num) => Math.Pow(num,2);


        int ICalculationService.Pow(int num)
        {
            int res = num;

            if (num == 0)
                return 1;
            else
                for (int i = 1; i <= num; i++)
                {
                    res = num * num;
                }
            return res;
        }
    }
}
