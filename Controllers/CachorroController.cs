using System.Threading.Tasks;
using MediatR;
using MediatRSample.Commands;
using MediatRSample.Models;
using MediatRSample.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CachorroController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Cachorro> _repository;

        public CachorroController(IMediator mediator, IRepository<Cachorro> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastraCachorroCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraCachorroCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ExcluiCachorroCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}