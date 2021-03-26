using MediatR;

namespace MediatRSample.Commands
{
    public class ExcluiCachorroCommand: IRequest<string>
    {
        public int Id { get; set; }        
    }
}