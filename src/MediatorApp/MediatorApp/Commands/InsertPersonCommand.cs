namespace MediatorApp.Commands
{
    public class InsertPersonCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public InsertPersonCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
