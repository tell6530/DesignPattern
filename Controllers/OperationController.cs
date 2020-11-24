using DesignPattern.BE.Operation;
using DesignPattern.SimpleFactory;
using DesignPattern.Strategy;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OperationController : ControllerBase
    {
        [HttpPost]
        public double Normal(OperationRequestEntity requestEntity)
        {
            double result = 0;

            switch (requestEntity.OperationType)
            {
                case OperationTypeEnum.Add:
                    result = requestEntity.num1 + requestEntity.num2;
                    break;
                case OperationTypeEnum.Minus:
                    result = requestEntity.num1 - requestEntity.num2;
                    break;
                case OperationTypeEnum.Multiply:
                    result = requestEntity.num1 * requestEntity.num2;
                    break;
                case OperationTypeEnum.Divide:
                    result = requestEntity.num1 / requestEntity.num2;
                    break;
                default:
                    break;

            }

            return result;
        }

        [HttpPost]
        public double SimpleFactory(OperationRequestEntity requestEntity)
        {
            var operationFactory = new OperationFactory();
            var operation = operationFactory.CreateOperation(requestEntity.OperationType);

            return operation.GetResult(requestEntity.num1, requestEntity.num2);
        }

        [HttpPost]
        public double Strategy(OperationRequestEntity requestEntity)
        {
            OperationContext contextBaseOperation = null;

            switch (requestEntity.OperationType)
            {
                case OperationTypeEnum.Add:
                    contextBaseOperation = new OperationContext(new AddContextOperation());
                    break;
                case OperationTypeEnum.Minus:
                    contextBaseOperation = new OperationContext(new MinusContextOperation());
                    break;
                case OperationTypeEnum.Multiply:
                    contextBaseOperation = new OperationContext(new MulContextOperation());
                    break;
                case OperationTypeEnum.Divide:
                    contextBaseOperation = new OperationContext(new DivContextOperation());
                    break;
            }

            return contextBaseOperation.GetResult(requestEntity.num1, requestEntity.num2);
        }

        [HttpPost]
        public double SimpleFactoryWithStrategy(OperationRequestEntity requestEntity)
        {
            var contextBaseOperation = new OperationContext(requestEntity.OperationType);

            return contextBaseOperation.GetResult(requestEntity.num1, requestEntity.num2);
        }
    }
}
