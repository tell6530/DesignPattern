namespace DesignPattern.Strategy
{
    public abstract class BaseContextOperation
    {
        public int Num1 { get; set; }

        public int Num2 { get; set; }

        public abstract double GetResult(int num1, int num2);
    }
}
