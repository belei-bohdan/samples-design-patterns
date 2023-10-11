using System.Text;

namespace DesignPatterns.Composite
{
    internal class CompositeTodoItem : TodoItem
    {
        private readonly List<TodoItem> _todoItems = new();

        internal CompositeTodoItem(string title) 
            : base(title, 0, 0)
        {
        }

        public override decimal Cost => _todoItems.Sum(x => x.Cost);
        public override double Hours => _todoItems.Sum(_x => _x.Hours);

        public void Add(TodoItem item) => _todoItems.Add(item);

        public override string ToString(int indent = 0)
        {
            ++indent;

            StringBuilder sb = new();
        
            sb.AppendLine(base.ToString());

            _todoItems.ForEach(i => sb
                .Append(new string('*', indent))
                .Append(' ')
                .AppendLine(i.ToString(indent)));

            return sb.ToString();
        }
    }
}
