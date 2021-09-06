using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurumTuruController : ControllerBase
    {
        private IKurumTuruService _kurumTuruService;

        public KurumTuruController(IKurumTuruService kurumTuruService)
        {
            _kurumTuruService = kurumTuruService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _kurumTuruService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(KurumTuru kurumTuru)
        {
            kurumTuru.Durum = true;
            var result = _kurumTuruService.Add(kurumTuru);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(KurumTuru kurumTuru)
        {
            var result = _kurumTuruService.Delete(kurumTuru);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallaktif")]
        public IActionResult GetAllAktif()
        {
            var result = _kurumTuruService.GetAllAktif();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int kurumTurId)
        {
            var result = _kurumTuruService.GetById(kurumTurId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(KurumTuru kurumTuru)
        {
            var result = _kurumTuruService.Update(kurumTuru);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
