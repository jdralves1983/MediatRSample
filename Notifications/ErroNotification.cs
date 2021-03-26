using MediatR;

namespace MediatRSample.Notifications
{
    public class ErroNotification : INotification
    {
        public string Excecao { get; set; }
        public string PilhaErro { get; set; }
    }
}