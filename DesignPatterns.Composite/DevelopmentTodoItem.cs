namespace DesignPatterns.Composite
{
    internal class DevelopmentTodoItem : TodoItem
    {
        internal DevelopmentTodoItem(string title, double hours, decimal costRate) 
            : base(title, hours, (decimal)hours * costRate)
        {
        }
    }
}
