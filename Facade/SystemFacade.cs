using System.Text;

namespace DesignPattern.Facade
{
    public class SystemFacade
    {
        SystemOne _systemOne;

        SystemTwo _systemTwo;

        public SystemFacade()
        {
            this._systemOne = new SystemOne();
            this._systemTwo = new SystemTwo();
        }

        public string GetSystemMessage()
        {
            var result = new StringBuilder();

            result.AppendLine(this._systemOne.GetSystemOneMessage());
            result.AppendLine(this._systemTwo.GetSystemTwoMessage());

            return result.ToString();
        }
    }
}
