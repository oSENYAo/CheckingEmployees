using CheckingEmployees.Data.ADO.NET.Repository;
using CheckingEmployees.Models;
using CheckingEmployees.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CheckingEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly FormAbsenceGetDataRepository _getDataRepository;
        private readonly FormAbsenceChangeDataRepository _changeDataRepository;
        private readonly CheckEmployeesContext _context;

        public ValuesController(FormAbsenceGetDataRepository getDataRepository
            , FormAbsenceChangeDataRepository changeDataRepository
            , CheckEmployeesContext context)
        {
            _getDataRepository = getDataRepository;
            _changeDataRepository = changeDataRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FormAbsence>>> GetAll()
        {
            var result = await _getDataRepository.GetAllAsync();
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FormAbsence>> GetSingle(int id)
        {
                var result = await _getDataRepository.GetByIdAsync(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<FormAbsence>> Create(FormAbsence model)
        {
            if (model != null)
            {
                var result = await _changeDataRepository.CreateDataAsync(model);
                if (result == 0)
                    return this.StatusCode((int)HttpStatusCode.InternalServerError);
                return Ok(model);
            }
            return BadRequest();
        }

        //[HttpPost]
        //public async Task<ActionResult<FormAbsence>> Create(FormAbsence model)
        //{
        //    if (model != null)
        //    {
        //        var result = await _context.FormAbsences.AddAsync(model);
        //        await _context.SaveChangesAsync();
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}
        [HttpPut]
        public async Task<ActionResult<FormAbsence>> Update(FormAbsence model)
        {
            if (model != null)
            {
                var result = await _changeDataRepository.UpdateDataAsync(model);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormAbsence>> Delete(int id)
        {
                var model = await _getDataRepository.GetByIdAsync(id);
                if (model == null)
                    return NotFound();

                var result = await _changeDataRepository.DeleteDataAsync(model);

                if (result == 0)
                    return this.StatusCode((int)HttpStatusCode.InternalServerError);
                return Ok(model);
        }
    }
}
