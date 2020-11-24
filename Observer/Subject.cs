using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Observer
{
    public abstract class Subject
    {
        private IList<Observer> _observers = new List<Observer>();

        public string Name { get; set; }

        public Subject(string name)
        {
            this.Name = name;
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public string NotifyTask()
        {
            var result = new StringBuilder();

            foreach(var observer in _observers)
            {

                result.AppendLine(observer.GetTaskReaction());
            }

            return result.ToString();
        }
    }
}
