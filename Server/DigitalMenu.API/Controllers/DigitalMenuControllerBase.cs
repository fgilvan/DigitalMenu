using DigitalMenu.Application.Exceptions;
using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model;
using DigitalMenu.Application.Model.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigitalMenu.API.Controllers
{
    public abstract class DigitalMenuControllerBase<TModel> : ControllerBase
        where TModel : ModelBase
    {
        protected abstract string Route { get; }

        protected static Type TypeModel => typeof(TModel);


        protected readonly IServiceBase<TModel> _service;


        public DigitalMenuControllerBase(IServiceBase<TModel> service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém a lista de registros.
        /// </summary>
        /// <returns>A lista de registros.</returns>
        /// <response code="200">Registros encontrado.</response>
        /// <response code="500">Erro na aplicação.</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var models = await _service.GetAll();

                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obtém registro por id.
        /// </summary>
        /// <param name="id">O identificador do registro.</param>
        /// <returns>O registro no banco de dados.</returns>
        /// <response code="200">Registro encontrado.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Erro na aplicação.</response>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var model = await _service.Get(id);

                return Ok(model);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Realiza o cadastro do registro no banco de dados.
        /// </summary>
        /// <param name="model">O registro a ser cadastrado.</param>
        /// <returns>O registro cadastrado no banco de dados.</returns>
        /// <response code="201">Registro cadastrado.</response>
        /// <response code="400">Registro inválido.</response>
        /// <response code="500">Erro na aplicação.</response>
        [HttpPost]
        public async Task<IActionResult> Post(TModel model)
        {
            try
            {
                await _service.Add(model);

                return Created(Route + model.Id, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Realiza a atualização do registro no banco de dados.
        /// </summary>
        /// <param name="id">O identificador do registro a ser atualizado.</param>
        /// <param name="model">O registro a ser atualizado.</param>
        /// <returns>O registro atualizado no banco de dados.</returns>
        /// <response code="201">Registro cadastrado.</response>
        /// <response code="400">Registro inválido.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Erro na aplicação.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return BadRequest();
                }

                await _service.Update(id, model);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Realiza a exclusão do registro no banco de dados.
        /// </summary>
        /// <param name="id">O id do registro a ser excluído.</param>
        /// <returns>O status da exclusão no banco de dados.</returns>
        /// <response code="200">Registro excluído.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Erro na aplicação.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);

                return Ok(Route);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
