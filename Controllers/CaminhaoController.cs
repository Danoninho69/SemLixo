using Microsoft.AspNetCore.Mvc;
using LixoMelhor.Dto.Caminhao;
using LixoMelhor.Models;
using LixoMelhor.Services.Caminhao;

namespace LixoMelhor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        private readonly ICaminhaoInterface _caminhaoInterface;
        public CaminhaoController(ICaminhaoInterface caminhaoInterface)
        {
            _caminhaoInterface = caminhaoInterface;
        }


        [HttpGet("ListarCaminhoes")]
        public async Task<ActionResult<ResponseModel<List<CaminhaoModel>>>> ListarCaminhoes()
        {
            var caminhoes = await _caminhaoInterface.ListarCaminhoes();
            return Ok(caminhoes);
        }

        [HttpGet("BuscarCaminhaoPorId/{idCaminhao}")]
        public async Task<ActionResult<ResponseModel<CaminhaoModel>>> BuscarCaminhaoPorId(int idCaminhao)
        {
            var caminhao = await _caminhaoInterface.BuscarCaminhaoPorId(idCaminhao);
            return Ok(caminhao);
        }

        [HttpPost("CriarCaminhao")]
        public async Task<ActionResult<ResponseModel<List<CaminhaoModel>>>> CriarCaminhao(CaminhaoCriacaoDto livroCriacaoDto)
        {
            var caminhoes = await _caminhaoInterface.CriarCaminhao(livroCriacaoDto);
            return Ok(caminhoes);
        }


        [HttpPut("EditarCaminhao")]
        public async Task<ActionResult<ResponseModel<List<CaminhaoModel>>>> EditarCaminhao(CaminhaoEdicaoDto livroEdicaoDto)
        {
            var caminhoes = await _caminhaoInterface.EditarCaminhao(livroEdicaoDto);
            return Ok(caminhoes);
        }

        [HttpDelete("ExcluirCaminhao")]
        public async Task<ActionResult<ResponseModel<List<LixeiraModel>>>> ExcluirCaminhao(int idCaminhao)
        {
            var caminhoes = await _caminhaoInterface.ExcluirCaminhao(idCaminhao);
            return Ok(caminhoes);
        }
    }
}
