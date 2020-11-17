using DesignPattern.BE.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.SimpleFactory
{
    public class OperationFactory
    {
        public BaseFactoryOperation CreateOperation(OperationTypeEnum operationType)
        {
            BaseFactoryOperation operation = null;

            switch (operationType)
            {
                case OperationTypeEnum.Add:
                    operation = new AddFactoryOperation();
                    break;
                case OperationTypeEnum.Minus:
                    operation = new MinusFactoryOperation();
                    break;
                case OperationTypeEnum.Multiply:
                    operation = new MulFactoryOperation();
                    break;
                case OperationTypeEnum.Divide:
                    operation = new DivFactoryOperation();
                    break;
                default:
                    operation = new BaseFactoryOperation();
                    break;
            }

            return operation;
        }
    }
}
