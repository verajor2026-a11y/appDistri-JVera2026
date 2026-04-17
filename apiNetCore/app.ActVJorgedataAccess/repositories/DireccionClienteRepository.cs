using app.ActVJorge.entities.models;
using app.ActVJorgedataAccess.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ActVJorgedataAccess.repositories
{
    public class DireccionClienteRepository : CrudGenericService<DireccionCliente>, IDireccionClienteRepository
    {
        public DireccionClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<DireccionCliente> Insertar(DireccionCliente direccionCliente)
        {
            return await InsertEntity(direccionCliente);
        }

        public async Task Eliminar(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<DireccionCliente> SeleccionarUno(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<DireccionCliente>> SeleccionarTodos()
        {
            return await SelectEntitiesAll();
        }

        public async Task Actualizar(DireccionCliente cliente)
        {
            await UpdateEntity(cliente);
        }
    }
}
