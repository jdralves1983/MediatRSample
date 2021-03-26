using MediatR;

namespace MediatRSample.Commands
{
    public class CadastraCachorroCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string Raca { get; set; }
    }
}