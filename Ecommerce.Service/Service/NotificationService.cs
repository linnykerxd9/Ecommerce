using System.Collections.Generic;
using System.Linq;
using Ecommerce.Service.Interface;
using ECommerce.Domain.Notification;

namespace Ecommerce.Service.Service
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _errors = new List<Notification>();
        public void AddError(string erro)
        {
            _errors.Add(new Notification(erro));
        }

        public IEnumerable<Notification> AllError()
        {
            return _errors;
        }

        public bool HAsError()
        {
            return _errors.Any();
        }
    }
}