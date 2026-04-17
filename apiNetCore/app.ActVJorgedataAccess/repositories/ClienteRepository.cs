using app.ActVJorgedataAccess.context;
using app.ActVJorge.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ActVJorgedataAccess.repositories
{
    public class ClienteRepository : CrudGenericService<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Cliente> Insertar(Cliente cliente)
        {
            return await InsertEntity(cliente);
        }

        public async Task Eliminar(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Cliente> SeleccionarUno(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Cliente>> SeleccionarTodos()
        {
            return await SelectEntitiesAll();
        }

        public async Task Actualizar(Cliente cliente)
        {
            await UpdateEntity(cliente);
        }
    }
}
