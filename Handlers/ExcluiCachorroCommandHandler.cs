using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Commands;
using MediatRSample.Models;
using MediatRSample.Notifications;
using MediatRSample.Repository;

namespace MediatRSample.Handlers
{
    public class ExcluiCachorroCommandHandler : IRequestHandler<ExcluiCachorroCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Cachorro> _repository;
        public ExcluiCachorroCommandHandler(IMediator mediator, IRepository<Cachorro> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(ExcluiCachorroCommand request, CancellationToken cancellationToken)
        {
            try {
                await _repository.Delete(request.Id);

                await _mediator.Publish(new CachorroExcluidoNotification { Id = request.Id, IsEfetivado = true});

                return await Task.FromResult("Pessoa excluída com sucesso");
            } catch(Exception ex) {
                await _mediator.Publish(new CachorroExcluidoNotification { Id = request.Id, IsEfetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }

        }
    }
}