namespace DesignPattern.SimpleFactory
{
    public class BaseFactoryOperation
    {
        public int Num1 {get; set;}

        public int Num2 {get; set;}

        public virtual double GetResult(int num1, int num2)
        {
            double result = 0;
            return result;
        }
    }
}