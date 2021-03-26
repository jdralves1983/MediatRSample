using MediatR;

namespace MediatRSample.Notifications
{
    public class CachorroExcluidoNotification: INotification
    {
        public int Id { get; set; }
        public bool IsEfetivado { get; set; }
    }
}