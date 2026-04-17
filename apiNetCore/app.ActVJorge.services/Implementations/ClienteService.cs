using app.ActVJorge.common.DTOs;
using app.ActVJorgedataAccess.repositories;
using app.ActVJorge.entities.models;
using app.ActVJorge.services.EventMQ;
using app.ActVJorge.services.Interfaces;

namespace app.ActVJorge.services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IRabbitMQService _rabbitMQService;

        public ClienteService(IClienteRepository repository, IRabbitMQService rabbitMQService)
        {
            _repository = repository;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<BaseResponse<ClienteDTO>> Insertar(ClienteDTO clienteDTO)
        {
            var response = new BaseResponse<ClienteDTO>();

            try
            {
                Cliente cliente = new()
                {
                    Nombre = clienteDTO.Nombre,
                    Apellido = clienteDTO.Apellido,
                    Email = clienteDTO.Email,
                    CedulaIdentidad = clienteDTO.CedulaIdentidad,
                    FechaNacimiento = clienteDTO.FechaNacimiento,
                    Telefono = clienteDTO.Telefono,
                    Estado = true,
                    Fecha = DateTime.Now
                };

                cliente = await _repository.Insertar(cliente);

                clienteDTO.Id = cliente.Id;
                response.Result = clienteDTO;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<ClienteDTO>> SeleccionarUno(int id)
        {
            var response = new BaseResponse<ClienteDTO>();

            try
            {
                var cliente = await _repository.SeleccionarUno(id);

                if (cliente == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Cliente no encontrado";
                    return response;
                }

                response.Result = new ClienteDTO
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    CedulaIdentidad = cliente.CedulaIdentidad,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Telefono = cliente.Telefono,
                    Estado = cliente.Estado
                };

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<List<ClienteDTO>>> SeleccionarTodos()
        {
            var response = new BaseResponse<List<ClienteDTO>>();

            try
            {
                var clientes = await _repository.SeleccionarTodos();

                response.Result = clientes.Select(c => new ClienteDTO
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    CedulaIdentidad = c.CedulaIdentidad,
                    FechaNacimiento = c.FechaNacimiento,
                    Telefono = c.Telefono,
                    Estado = c.Estado
                }).ToList();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<ClienteDTO>> Actualizar(int id, ClienteDTO clienteDTO)
        {
            var response = new BaseResponse<ClienteDTO>();

            try
            {
                Cliente cliente = new()
                {
                    Id = id,
                    Nombre = clienteDTO.Nombre,
                    Apellido = clienteDTO.Apellido,
                    Email = clienteDTO.Email,
                    CedulaIdentidad = clienteDTO.CedulaIdentidad,
                    FechaNacimiento = clienteDTO.FechaNacimiento,
                    Telefono = clienteDTO.Telefono,
                    Estado = clienteDTO.Estado,
                    Fecha = DateTime.Now
                };

                await _repository.Actualizar(cliente);

                clienteDTO.Id = id;
                response.Result = clienteDTO;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<string>> Eliminar(int id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.Eliminar(id);

                response.Result = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}