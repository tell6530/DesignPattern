namespace DesignPattern.SimpleFactory
{
    public class AddFactoryOperation : BaseFactoryOperation
    {
        public override double GetResult(int num1, int num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;

            return this.Num1 + this.Num2;
        }
    }
}