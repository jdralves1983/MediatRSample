using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatRSample.Models;

namespace MediatRSample.Repository
{
    public class CachorroRepository : IRepository<Cachorro>
    {
        private static Dictionary<int, Cachorro> cachorros = new Dictionary<int, Cachorro>();

        public async Task<IEnumerable<Cachorro>> GetAll(){
            return await Task.Run(() => cachorros.Values.ToList());
        }

        public async Task<Cachorro> Get(int id){
            return await Task.Run(() => cachorros.GetValueOrDefault(id));
        }

        public async Task Add(Cachorro cachorro){
            cachorro.Id = 0;
            if (cachorros.Count() > 0) cachorro.Id = cachorros.Values.OrderByDescending( x => x.Id).First().Id + 1;
            await Task.Run(() => cachorros.Add(cachorro.Id, cachorro));
        }

        public async Task Edit(Cachorro cachorro){
            await Task.Run(() =>
            {
                cachorros.Remove(cachorro.Id);
                cachorros.Add(cachorro.Id, cachorro);
            });
        }

        public async Task Delete(int id){
            await Task.Run(() => cachorros.Remove(id));
        }
    }
}