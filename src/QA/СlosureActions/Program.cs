List<Action> actions = new List<Action>();

for (var count = 0; count < 10; count++)
{
    actions.Add(() => Console.WriteLine(count));
}

foreach (var action in actions)
{
    action();
}