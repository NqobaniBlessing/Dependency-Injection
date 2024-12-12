namespace Dependency_Injection.Messaging
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class NotificationService(IMessageService messageService)
    {
        public void Notify(string message)
        {
            messageService.SendMessage($"Notification: {message}");
        }
    }
}
