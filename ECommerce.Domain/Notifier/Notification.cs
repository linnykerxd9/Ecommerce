namespace ECommerce.Domain.Notification
{
    public class Notification
    {
        public string Error { get;private set; }

        public Notification(string error)
        {
            Error = error;
        }
    }
}