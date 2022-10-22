﻿using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroWebApi.Controllers
{
    [Route("api/associados")]
    [ApiController]
    public class AssociadosController : ControllerBase
    {
        private readonly IAssociadoApplication _associadoApplication;
        public AssociadosController(IAssociadoApplication associadoApplication)
        {
            _associadoApplication = associadoApplication;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var associados = await _associadoApplication.GetAll();
                return Ok(associados);
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
                var associado = await _associadoApplication.Get(id);
                return Ok(associado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(AssociadoDTO associadoDTO)
        {
            try
            {
                await _associadoApplication.Edit(associadoDTO);
                await _associadoApplication.Save();
                return Ok("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AssociadoDTO associadoDTO)
        {
            try
            {
                await _associadoApplication.Add(associadoDTO);
                await _associadoApplication.Save();
                return Created("Associado adicionado!", new { Associado = associadoDTO.Nome });
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
                await _associadoApplication.Delete(id);
                await _associadoApplication.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
