using API.Interfaces.Services.Crud;
using API.Models.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers.Crud
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public abstract class CrudController<T, Dto> : Controller where T : BaseEntity
    {
        public readonly ICrudService<T, Dto> service;

        public CrudController(ICrudService<T, Dto> _service)
        {
            service = _service;
        }

        [HttpGet("SelectAll")]
        public async Task<ActionResult> SelectAll()
        {            
            try
            {
                return Ok(await service.SelectAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("SelectById/{id}")]
        public async Task<ActionResult> SelectById(int id)
        {            
            try
            {
                return Ok(await service.SelectByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromBody] Dto obj)
        {           
            try
            {
                return Ok(await service.SaveAsync(obj));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Dto obj)
        {            
            try
            {
                return Ok(await service.InsertAsync(obj));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] Dto obj)
        {            
            try
            {
                return Ok(await service.UpdateAsync(obj));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {            
            try
            {
                return Ok(await service.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
