using WebStack.Application.Notifications.Models;

namespace WebStack.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
