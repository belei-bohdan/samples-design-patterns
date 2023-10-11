using DesignPatterns.Composite;

var items = new CompositeTodoItem("PRIMARY PROJECT");

var backendItems = new CompositeTodoItem("Finish backend development");
var frontendItems = new CompositeTodoItem("Finish frontend development");
items.Add(backendItems);
items.Add(frontendItems);

backendItems.Add(new DevelopmentTodoItem(title: "Finish backend project", hours: 80, costRate: 50));
backendItems.Add(new CallTodoItem(title: "Call the project lead", hours: 0.5));
backendItems.Add(new PurchaseTodoItem(title: "Purchase a new service plan for the deployment environment", cost: 2000));

var kendoItems = new CompositeTodoItem("Acquire and activate a Kendo Angular license");
kendoItems.Add(new PurchaseTodoItem("Purchase license", cost: 1500));
kendoItems.Add(new DevelopmentTodoItem("Activate and test", hours: 10, costRate: 50));

frontendItems.Add(kendoItems);

Display(items);

static void Display(TodoItem items)
{
    Console.WriteLine(items.ToString());
    //Console.WriteLine(new string('-', 50));
    //Console.WriteLine($"Total cost: {items.Cost.ToString("C0", new CultureInfo("en-US"))}");
    //Console.WriteLine($"Total duration: {items.Hours} hours");
}