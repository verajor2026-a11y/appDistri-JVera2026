using app.ActVJorge.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ActVJorgedataAccess.repositories
{
    public interface IDireccionClienteRepository
    {
        Task<DireccionCliente> SeleccionarUno(int id);

        Task<DireccionCliente> Insertar(DireccionCliente direccionCliente);

        Task<List<DireccionCliente>> SeleccionarTodos();

        Task Actualizar(DireccionCliente direccionCliente);

        Task Eliminar(int id);
    }
}
