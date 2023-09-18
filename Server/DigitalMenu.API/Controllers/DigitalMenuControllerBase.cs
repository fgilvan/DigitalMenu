using DigitalMenu.Application.Exceptions;
using DigitalMenu.Application.Interfaces;
using DigitalMenu.Application.Model;
using DigitalMenu.Application.Model.Product;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMenu.API.Controllers
{
    public abstract class DigitalMenuControllerBase<TModel> : ControllerBase 
        where TModel : ModelBase
    {
        protected abstract string Route { get; }

        protected readonly IServiceBase<TModel> _service;

        public DigitalMenuControllerBase(IServiceBase<TModel> service)
        {
            _service = service;
        }

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
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

        [HttpPost]
        public async Task<IActionResult> Post(TModel model)
        {
            try
            {
                await _service.Add(model);

                return Created(Route + model.Id, model);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TModel model)
        {
            try
            {
                await _service.Update(id, model);

                return Created(Route + model.Id, model);
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
