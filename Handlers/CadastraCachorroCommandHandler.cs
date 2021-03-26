using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Commands;
using MediatRSample.Notifications;
using MediatRSample.Repository;
using MediatRSample.Models;

namespace MediatRSample.Handlers
{
    public class CadastraCachorroCommandHandler : IRequestHandler<CadastraCachorroCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Cachorro> _repository;
        public CadastraCachorroCommandHandler(IMediator mediator, IRepository<Cachorro> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraCachorroCommand request, CancellationToken cancellationToken)
        {
            var cachorro = new Cachorro { Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo, Raca = request.Raca};

            try {
                await _repository.Add(cachorro);

                await _mediator.Publish(new CachorroCriadoNotification { Id = cachorro.Id, Nome = cachorro.Nome, Idade = cachorro.Idade, Sexo = cachorro.Sexo, Raca = cachorro.Raca});

                return await Task.FromResult("Cachorro criado com sucesso");
            } catch(Exception ex) {
                await _mediator.Publish(new CachorroCriadoNotification { Id = cachorro.Id, Nome = cachorro.Nome, Idade = cachorro.Idade, Sexo = cachorro.Sexo, Raca = cachorro.Raca });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}