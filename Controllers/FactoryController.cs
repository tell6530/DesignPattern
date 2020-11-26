using DesignPattern.BE.Operation;
using DesignPattern.SimpleFactory;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FactoryController : ControllerBase
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
    }
}
