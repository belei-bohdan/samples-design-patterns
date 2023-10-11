namespace DesignPatterns.Composite
{
    internal class PurchaseTodoItem : TodoItem
    {
        internal PurchaseTodoItem(string title, decimal cost) 
            : base(title, 0, cost)
        {
        }
    }
}
