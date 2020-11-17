using DesignPattern.BE.Operation;

namespace DesignPattern.Strategy
{
    public class OperationContext
    {
        private BaseContextOperation _contextBaseOperation = null;

        public int Num1 { get; set; }

        public int Num2 { get; set; }

        public OperationContext(BaseContextOperation contextBaseOperation)
        {
            this._contextBaseOperation = contextBaseOperation;
        }

        public OperationContext(OperationTypeEnum operationType)
        {
            switch (operationType)
            {
                case OperationTypeEnum.Add:
                    this._contextBaseOperation = new AddContextOperation();
                    break;
                case OperationTypeEnum.Minus:
                    this._contextBaseOperation = new MinusContextOperation();
                    break;
                case OperationTypeEnum.Multiply:
                    this._contextBaseOperation = new MulContextOperation();
                    break;
                case OperationTypeEnum.Divide:
                    this._contextBaseOperation = new DivContextOperation();
                    break;
            }
        }

        public double GetResult(int num1, int num2)
        {
            return this._contextBaseOperation.GetResult(num1, num2);
        }
    }
}
