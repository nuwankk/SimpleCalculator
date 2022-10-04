namespace bf.api.Helpers
{
# pragma warning disable 
    public class CalculatorHelper
    {
        public static Result Addition(CalcIn calcIn)
        {
            return new Result() { IsSuccess=true, Value = decimal.Round((calcIn.Number1 + calcIn.Number2), 5, MidpointRounding.AwayFromZero)};
        }

        public static Result Substraction(CalcIn calcIn)
        {
            return new Result() { IsSuccess = true, Value = decimal.Round((calcIn.Number1 - calcIn.Number2), 5, MidpointRounding.AwayFromZero) };
        }

        public static Result Multiply(CalcIn calcIn)
        {
            return new Result() { IsSuccess = true, Value = decimal.Round((calcIn.Number1 * calcIn.Number2), 5, MidpointRounding.AwayFromZero) };
        }

        public static Result Devision(CalcIn calcIn)
        {
            return new Result() { IsSuccess = true, Value = decimal.Round((calcIn.Number1 / calcIn.Number2), 5, MidpointRounding.AwayFromZero) };
        }
    }
}
