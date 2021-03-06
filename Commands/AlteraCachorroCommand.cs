using MediatR;

namespace MediatRSample.Commands
{
    public class AlteraCachorroCommand : IRequest<string>
    {
       public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; } 
        public string Raca { get; set; }
    }
}