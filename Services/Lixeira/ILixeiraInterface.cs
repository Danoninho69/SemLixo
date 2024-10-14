using LixoMelhor.Dto.Lixeira;
using LixoMelhor.Models;


namespace LixoMelhor.Services.Lixeira
{
    public interface ILixeiraInterface
    {
        Task<ResponseModel<List<LixeiraModel>>> ListarLixeiras();
        Task<ResponseModel<LixeiraModel>> BuscarLixeiraPorId(int idLixeira);
        Task<ResponseModel<List<LixeiraModel>>> CriarLixeira(LixeiraCriacaoDto lixeiraCriacaoDto);

        Task<ResponseModel<List<LixeiraModel>>> EditarLixeira(LixeiraEdicaoDto lixeiraEdicaoDto);
        Task<ResponseModel<List<LixeiraModel>>> ExcluirLixeira(int idLixeira);

    }
}
