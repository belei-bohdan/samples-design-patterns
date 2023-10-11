namespace DesignPatterns.Composite
{
    internal class CallTodoItem : TodoItem
    {
        internal CallTodoItem(string title, double hours) 
            : base(title, hours, 0)
        {
        }
    }
}
