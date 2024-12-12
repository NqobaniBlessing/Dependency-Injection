using Dependency_Injection.Container;
using Dependency_Injection.Messaging;

var container = new DiContainer();

// container.Register<IMessageService, EmailService>(ServiceLifetime.Singleton);
container.Register<IMessageService, SmsService>();
container.Register<NotificationService, NotificationService>();

// var emailService = container.Resolve<IMessageService>();
var smsService = container.Resolve<IMessageService>();
var notificationService = container.Resolve<NotificationService>();

// emailService.SendMessage("Hi!");
smsService.SendMessage("Hello");
notificationService.Notify("Hello DI with constructor!");