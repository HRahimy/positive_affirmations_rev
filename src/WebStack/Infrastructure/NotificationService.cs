using WebStack.Application.Common.Interfaces;
using WebStack.Application.Notifications.Models;

namespace WebStack.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
