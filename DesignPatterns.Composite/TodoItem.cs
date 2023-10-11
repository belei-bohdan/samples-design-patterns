using System.Globalization;

namespace DesignPatterns.Composite
{
    internal abstract class TodoItem
    {
        internal TodoItem(string title, double hours, decimal cost)
        {
            Title = title;
            Hours = hours;
            Cost = cost;
            IsCompleted = false;
        }

        public string Title { get; set; }
        public virtual double Hours { get; set; }
        public virtual decimal Cost { get; set; }
        public bool IsCompleted { get; set; }

        public virtual string ToString(int indent = 0)
            => $"({this.GetType().Name}) {Title} | {Hours} hours | {Cost.ToString("C0", new CultureInfo("en-US"))} | {IsCompleted}";
    }
}