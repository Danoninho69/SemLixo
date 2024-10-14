using Microsoft.AspNetCore.Mvc;
using LixoMelhor.Dto.Lixeira;
using LixoMelhor.Models;
using LixoMelhor.Services.Lixeira;

namespace LixoMelhor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LixeiraController : ControllerBase
    {

        private readonly ILixeiraInterface _lixeiraInterface;
        public LixeiraController(ILixeiraInterface lixeiraInterface)
        {
            _lixeiraInterface = lixeiraInterface;
        }


        [HttpGet("ListarLixeiras")]
        public async Task<ActionResult<ResponseModel<List<LixeiraModel>>>> ListarLixeiras()
        {
            var lixeiras = await _lixeiraInterface.ListarLixeiras();
            return Ok(lixeiras);
        }

        [HttpGet("BuscarLixeiraPorId/{idLixeira}")]
        public async Task<ActionResult<ResponseModel<LixeiraModel>>> BuscarLixeiraPorId(int idLixeira)
        {
            var lixeira = await _lixeiraInterface.BuscarLixeiraPorId(idLixeira);
            return Ok(lixeira);
        }

        [HttpPost("CriarLixeira")]
        public async Task<ActionResult<ResponseModel<List<LixeiraModel>>>> CriarLixeira(LixeiraCriacaoDto lixeiraCriacaoDto)
        {
            var lixeiras = await _lixeiraInterface.CriarLixeira(lixeiraCriacaoDto);
            return Ok(lixeiras);
        }


        [HttpPut("EditarLixeira")]
        public async Task<ActionResult<ResponseModel<List<LixeiraModel>>>> EditarLixeira(LixeiraEdicaoDto lixeiraEdicaoDto)
        {
            var lixeiras = await _lixeiraInterface.EditarLixeira(lixeiraEdicaoDto);
            return Ok(lixeiras);
        }

        [HttpDelete("ExcluirLixeira")]
        public async Task<ActionResult<ResponseModel<List<LixeiraModel>>>> ExcluirLixeira(int idLixeira)
        {
            var lixeiras = await _lixeiraInterface.ExcluirLixeira(idLixeira);
            return Ok(lixeiras);
        }

    }
}
