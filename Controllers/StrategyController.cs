using DesignPattern.BE.Operation;
using DesignPattern.Strategy;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StrategyController : ControllerBase
    {
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
        public double StrategySimpleFactory(OperationRequestEntity requestEntity)
        {
            var contextBaseOperation = new OperationContext(requestEntity.OperationType);

            return contextBaseOperation.GetResult(requestEntity.num1, requestEntity.num2);
        }
    }
}
