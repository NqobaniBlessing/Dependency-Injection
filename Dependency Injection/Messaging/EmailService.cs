namespace Dependency_Injection.Messaging
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }
}
