using app.ActVJorge.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ActVJorgedataAccess.repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> SeleccionarUno(int id);

        Task<Cliente> Insertar(Cliente cliente);

        Task<List<Cliente>> SeleccionarTodos();

        Task Actualizar(Cliente cliente);

        Task Eliminar(int id);

    }
}
