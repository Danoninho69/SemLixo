using LixoMelhor.Dto.Caminhao;
using LixoMelhor.Models;

namespace LixoMelhor.Services.Caminhao
{
    public interface ICaminhaoInterface
    {
        Task<ResponseModel<List<CaminhaoModel>>> ListarCaminhoes();
        Task<ResponseModel<CaminhaoModel>> BuscarCaminhaoPorId(int idCaminhao);
        Task<ResponseModel<List<CaminhaoModel>>> CriarCaminhao(CaminhaoCriacaoDto caminhaoCriacaoDto);

        Task<ResponseModel<List<CaminhaoModel>>> EditarCaminhao(CaminhaoEdicaoDto caminhaoEdicaoDto);
        Task<ResponseModel<List<CaminhaoModel>>> ExcluirCaminhao(int idCaminhao);
        List<CaminhaoModel> ListarCaminhoesList();
    }
}
