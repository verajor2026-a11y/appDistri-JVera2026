using app.ActVJorge.common.DTOs;
using app.ActVJorgedataAccess.repositories;
using app.ActVJorge.entities.models;
using app.ActVJorge.services.EventMQ;
using app.ActVJorge.services.Interfaces;

namespace app.ActVJorge.services.Implementations
{
    public class DireccionClienteService : IDireccionClienteService
    {
        private readonly IDireccionClienteRepository _repository;
        private readonly IClienteRepository _repositoryCliente;
        private readonly IRabbitMQService _rabbitMQService;

        public DireccionClienteService(
            IDireccionClienteRepository repository,
            IClienteRepository repositoryCliente,
            IRabbitMQService rabbitMQService)
        {
            _repository = repository;
            _repositoryCliente = repositoryCliente;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<BaseResponse<DireccionClienteDTO>> Insertar(DireccionClienteDTO dto)
        {
            var response = new BaseResponse<DireccionClienteDTO>();

            try
            {
                var entity = new DireccionCliente
                {
                    ClienteId = dto.ClienteId,
                    Provincia = dto.Provincia,
                    Ciudad = dto.Ciudad,
                    Direccion = dto.Direccion,
                    CodigoPostal = dto.CodigoPostal,
                    Estado = true,
                    Fecha = DateTime.Now
                };

                entity = await _repository.Insertar(entity);

                dto.Id = entity.Id;
                response.Result = dto;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<List<DireccionClienteDTO>>> SeleccionarTodos()
        {
            var response = new BaseResponse<List<DireccionClienteDTO>>();

            try
            {
                var list = await _repository.SeleccionarTodos();

                response.Result = list.Select(d => new DireccionClienteDTO
                {
                    Id = d.Id,
                    ClienteId = d.ClienteId,
                    Provincia = d.Provincia,
                    Ciudad = d.Ciudad,
                    Direccion = d.Direccion,
                    CodigoPostal = d.CodigoPostal,
                    Estado = d.Estado
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

        public async Task<BaseResponse<DireccionClienteDTO>> SeleccionarUno(int id)
        {
            var response = new BaseResponse<DireccionClienteDTO>();

            try
            {
                var entity = await _repository.SeleccionarUno(id);

                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "No encontrado";
                    return response;
                }

                response.Result = new DireccionClienteDTO
                {
                    Id = entity.Id,
                    ClienteId = entity.ClienteId,
                    Provincia = entity.Provincia,
                    Ciudad = entity.Ciudad,
                    Direccion = entity.Direccion,
                    CodigoPostal = entity.CodigoPostal,
                    Estado = entity.Estado
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

        public async Task<BaseResponse<DireccionClienteDTO>> Actualizar(int id, DireccionClienteDTO dto)
        {
            var response = new BaseResponse<DireccionClienteDTO>();

            try
            {
                var entity = new DireccionCliente
                {
                    Id = id,
                    ClienteId = dto.ClienteId,
                    Provincia = dto.Provincia,
                    Ciudad = dto.Ciudad,
                    Direccion = dto.Direccion,
                    CodigoPostal = dto.CodigoPostal,
                    Estado = true,
                    Fecha = DateTime.Now
                };

                await _repository.Actualizar(entity);

                dto.Id = id;
                response.Result = dto;
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