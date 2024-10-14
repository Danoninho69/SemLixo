using LixoMelhor.Data;
using LixoMelhor.Dto.Caminhao;
using LixoMelhor.Models;
using Microsoft.EntityFrameworkCore;

namespace LixoMelhor.Services.Caminhao
{
    public class CaminhaoService : ICaminhaoInterface
    {
        private readonly AppDbContext _context;

        public CaminhaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<CaminhaoModel>> BuscarCaminhaoPorId(int idCaminhao)
        {
            ResponseModel<CaminhaoModel> resposta = new ResponseModel<CaminhaoModel>();
            try
            {

                var caminhao = await _context.Caminhoes
                    .FirstOrDefaultAsync(caminhaoBanco => caminhaoBanco.Id == idCaminhao);

                if (caminhao == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = caminhao;
                resposta.Mensagem = "Caminhão Localizado com Sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CaminhaoModel>>> CriarCaminhao(CaminhaoCriacaoDto caminhaoCriacaoDto)
        {
            ResponseModel<List<CaminhaoModel>> resposta = new ResponseModel<List<CaminhaoModel>>();

            try
            {

                var caminhao = new CaminhaoModel()
                {
                    Placa = caminhaoCriacaoDto.Placa,
                    Ativo = caminhaoCriacaoDto.Ativo
                };

                _context.Add(caminhao);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Caminhoes.ToListAsync();
                resposta.Mensagem = "Caminhão criado com sucesso!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CaminhaoModel>>> EditarCaminhao(CaminhaoEdicaoDto caminhaoEdicaoDto)
        {
            ResponseModel<List<CaminhaoModel>> resposta = new ResponseModel<List<CaminhaoModel>>();
            try
            {

                var caminhao = await _context.Caminhoes
                     .FirstOrDefaultAsync(caminhaoBanco => caminhaoBanco.Id == caminhaoEdicaoDto.Id);

                if (caminhao == null)
                {
                    resposta.Mensagem = "Nenhum registro de caminhão localizado!";
                    return resposta;
                }

                caminhao.Placa = caminhaoEdicaoDto.Placa;
                caminhao.Ativo = caminhaoEdicaoDto.Ativo;

                _context.Update(caminhao);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Caminhoes.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CaminhaoModel>>> ExcluirCaminhao(int idCaminhao)
        {
            ResponseModel<List<CaminhaoModel>> resposta = new ResponseModel<List<CaminhaoModel>>();

            try
            {

                var caminhao = await _context.Caminhoes
                    .FirstOrDefaultAsync(caminhaoBanco => caminhaoBanco.Id == idCaminhao);

                if (caminhao == null)
                {
                    resposta.Mensagem = "Nenhum caminhão localizado!";
                    return resposta;
                }

                _context.Remove(caminhao);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Caminhoes.ToListAsync();
                resposta.Mensagem = "Caminhão Removido com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CaminhaoModel>>> ListarCaminhoes()
        {
            ResponseModel<List<CaminhaoModel>> resposta = new ResponseModel<List<CaminhaoModel>>();
            try
            {

                var caminhoes = await _context.Caminhoes.ToListAsync();

                resposta.Dados = caminhoes;
                resposta.Mensagem = "Todos os caminhões foram listados!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
