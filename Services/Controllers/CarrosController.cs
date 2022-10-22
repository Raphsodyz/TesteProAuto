using Application.DTOs;
using Application;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroWebApi.Controllers
{
    [Route("api/carros")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroApplication _carroApplication;
        public CarrosController(ICarroApplication carroApplication)
        {
            _carroApplication = carroApplication;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var carros = await _carroApplication.GetAll();
                return Ok(carros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var carro = await _carroApplication.Get(id);
                return Ok(carro);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(CarroDTO carroDTO)
        {
            try
            {
                await _carroApplication.Edit(carroDTO);
                await _carroApplication.Save();
                return Ok("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarroDTO carroDTO)
        {
            try
            {
                await _carroApplication.Add(carroDTO);
                await _carroApplication.Save();
                return Created("Carro adicionado!", new { Carro = carroDTO.Modelo });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _carroApplication.Delete(id);
                await _carroApplication.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
