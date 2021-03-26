using MediatR;

namespace MediatRSample.Notifications
{
    public class CachorroAlteradoNotification: INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string Raca { get; set; }
        public bool IsEfetivado { get; set; }
    }
}