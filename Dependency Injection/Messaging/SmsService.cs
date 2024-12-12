namespace Dependency_Injection.Messaging
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class SmsService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}
