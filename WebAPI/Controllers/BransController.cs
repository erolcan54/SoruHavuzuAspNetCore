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
    public class BransController : ControllerBase
    {
        private IBransService _bransService;

        public BransController(IBransService bransService)
        {
            _bransService = bransService;
        }

        [HttpPost("add")]
        public IActionResult Add(Brans brans)
        {
            brans.Durum = true;
            var result = _bransService.Add(brans);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getallaktif")]
        public IActionResult GetAllAktif()
        {
            var result = _bransService.GetAllAktif();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}
