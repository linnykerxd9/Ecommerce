using System.Collections.Generic;
using ECommerce.Domain.Notification;

namespace Ecommerce.Service.Interface
{
    public interface INotificationService
    {
        void AddError(string erro);
        bool HAsError();
        IEnumerable<Notification> AllError();
    }
}