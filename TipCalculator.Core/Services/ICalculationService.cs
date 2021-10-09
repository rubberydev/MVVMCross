namespace TipCalculator.Core.Services
{
	public interface ICalculationService
	{    /// <summary>
		/// Calculate a tip
		/// </summary>
		/// <param name="subTotal"></param>
		/// <param name="generosity"></param>
		/// <returns></returns>
		decimal TipAmount(decimal subTotal, double generosity);

		/// <summary>
		/// Calculate a sum of two numbers
		/// </summary>
		/// <param name="firstValue"></param>
		/// <param name="secondValue"></param>
		/// <returns></returns>
		int Sum(int firstValue, int secondValue);

		/// <summary>
		/// make a substraction between two numbers
		/// </summary>
		/// <param name="firstValue"></param>
		/// <param name="secondValue"></param>
		/// <returns></returns>
		int Substraction(int firstValue, int secondValue);

		/// <summary>
		/// make a Division between two numbers
		/// </summary>
		/// <param name="firstValue"></param>
		/// <param name="secondValue"></param>
		/// <returns></returns>
		decimal Division(int firstValue, int secondValue);
		/// <summary>
		/// make a multiplication between two numbers
		/// </summary>
		/// <param name="firstValue"></param>
		/// <param name="secondValue"></param>
		/// <returns></returns>
		int Multiplication(int firstValue, int secondValue);

		/// <summary>
		/// make a pow of a number
		/// </summary>
		/// <param name="firstValue"></param>
		/// <returns></returns>
		int Pow(int firstValue);
		/// <summary>
		/// calculate a sqrt of a number
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		double Sqrt(int number);
	}
}
