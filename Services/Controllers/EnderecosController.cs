using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroWebApi.Controllers
{
    [Route("api/enderecos")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoApplication _enderecoApplication;
        public EnderecosController(IEnderecoApplication enderecoApplication)
        {
            _enderecoApplication = enderecoApplication;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var enderecos = await _enderecoApplication.GetAll();
                return Ok(enderecos);
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
                var endereco = await _enderecoApplication.Get(id);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EnderecoDTO enderecoDTO)
        {
            try
            {
                await _enderecoApplication.Edit(enderecoDTO);
                await _enderecoApplication.Save();
                return Ok("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(EnderecoDTO enderecoDTO)
        {
            try
            {
                await _enderecoApplication.Add(enderecoDTO);
                await _enderecoApplication.Save();
                return Created("Endereco adicionado!", enderecoDTO);
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
                await _enderecoApplication.Delete(id);
                await _enderecoApplication.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
