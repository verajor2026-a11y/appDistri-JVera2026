using app.ActVJorge.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ActVJorge.services.Interfaces
{
    public interface IDireccionClienteService
    {
        Task<BaseResponse<DireccionClienteDTO>> Insertar(DireccionClienteDTO dto);

        Task<BaseResponse<DireccionClienteDTO>> SeleccionarUno(int id);

        Task<BaseResponse<List<DireccionClienteDTO>>> SeleccionarTodos();

        Task<BaseResponse<DireccionClienteDTO>> Actualizar(int id, DireccionClienteDTO dto);

        Task<BaseResponse<string>> Eliminar(int id);
    }
}
