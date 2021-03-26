using MediatR;

namespace MediatRSample.Notifications
{
    public class CachorroCriadoNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string Raca { get; set; } 
    }
}