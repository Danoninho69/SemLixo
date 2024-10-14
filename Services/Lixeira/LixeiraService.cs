using Microsoft.EntityFrameworkCore;
using LixoMelhor.Data;
using LixoMelhor.Dto.Lixeira;
using LixoMelhor.Models;
using LixoMelhor.Services.Lixeira;

namespace LixoMelhor.Services.Lixeira
{
    public class LixeiraService : ILixeiraInterface
    {
        private readonly AppDbContext _context;
        public LixeiraService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LixeiraModel>> BuscarLixeiraPorId(int idLixeira)
        {
            ResponseModel<LixeiraModel> resposta = new ResponseModel<LixeiraModel>();
            try
            {

                var lixeira = await _context.Lixeiras.FirstOrDefaultAsync(lixeiraBanco => lixeiraBanco.Id == idLixeira);

                if(lixeira == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = lixeira;
                resposta.Mensagem = "Lixeira Localizada!";

                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LixeiraModel>>> CriarLixeira(LixeiraCriacaoDto lixeiraCriacaoDto)
        {
            ResponseModel<List<LixeiraModel>> resposta = new ResponseModel<List<LixeiraModel>>();

            try
            {

                var lixeira = new LixeiraModel()
                {
                    Nome = lixeiraCriacaoDto.Nome,
                    Ativa = lixeiraCriacaoDto.Ativa
                };

                _context.Add(lixeira);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Lixeiras.ToListAsync();
                resposta.Mensagem = "Lixeira criado com sucesso!";

                return resposta;


            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<List<LixeiraModel>>> EditarLixeira(LixeiraEdicaoDto lixeiraEdicaoDto)
        {
            ResponseModel<List<LixeiraModel>> resposta = new ResponseModel<List<LixeiraModel>>();
            try
            {

                var lixeira = await _context.Lixeiras
                    .FirstOrDefaultAsync(lixeiraBanco => lixeiraBanco.Id == lixeiraEdicaoDto.Id);

                if (lixeira == null)
                {
                    resposta.Mensagem = "Nenhuma lixeira localizada!";
                    return resposta;
                }

                lixeira.Nome = lixeiraEdicaoDto.Nome;
                lixeira.Ativa = lixeiraEdicaoDto.Ativa;

                _context.Update(lixeira);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Lixeiras.ToListAsync();
                resposta.Mensagem = "Lixeira Editada com Sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LixeiraModel>>> ExcluirLixeira(int idLixeira)
        {
            ResponseModel<List<LixeiraModel>> resposta = new ResponseModel<List<LixeiraModel>>();

            try
            {

                var lixeira = await _context.Lixeiras
                    .FirstOrDefaultAsync(lixeiraBanco => lixeiraBanco.Id == idLixeira);

                if(lixeira == null)
                {
                    resposta.Mensagem = "Nenhuma lixeira localizada!";
                    return resposta;
                }

                _context.Remove(lixeira);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Lixeiras.ToListAsync();
                resposta.Mensagem = "Lixeira Removida com sucesso!";

                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<List<LixeiraModel>>> ListarLixeiras()
        {
            ResponseModel<List<LixeiraModel>> resposta = new ResponseModel<List<LixeiraModel>>();
            try
            {

                var lixeiras = await _context.Lixeiras.ToListAsync();

                resposta.Dados = lixeiras;
                resposta.Mensagem = "Todas as lixeiras foram coletadas!";

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
