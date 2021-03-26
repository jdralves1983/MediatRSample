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
    public class AlteraCachorroCommandHandler : IRequestHandler<AlteraCachorroCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Cachorro> _repository;
        public AlteraCachorroCommandHandler(IMediator mediator, IRepository<Cachorro> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AlteraCachorroCommand request, CancellationToken cancellationToken)
        {
            var cachorro = new Cachorro { Id = request.Id, Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo, Raca = request.Raca };

            try {
                await _repository.Edit(cachorro);

                await _mediator.Publish(new CachorroAlteradoNotification { Id = cachorro.Id, Nome = cachorro.Nome, Idade = cachorro.Idade, Sexo = cachorro.Sexo, IsEfetivado = true});

                return await Task.FromResult("Pessoa alterada com sucesso");
            } catch(Exception ex) {
                await _mediator.Publish(new CachorroAlteradoNotification { Id = cachorro.Id, Nome = cachorro.Nome, Idade = cachorro.Idade, Sexo = cachorro.Sexo, IsEfetivado = false});
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }

        }
    }
}