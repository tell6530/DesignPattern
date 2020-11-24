using System.Text;

namespace DesignPattern.Observer
{
    public class LazyBoneObserver : Observer
    {
        private string _name;

        private string _action;

        private Subject _subject;

        public LazyBoneObserver(Subject subject, string name, string action)
        {
            this._subject = subject;
            this._name = name;
            this._action = action;
        }

        public override string GetTaskReaction()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this._subject.Name}: {this._name}, I have a task for you!");
            result.Append($"{this._name}: {this._action}");

            return result.ToString();
        }
    }
}
