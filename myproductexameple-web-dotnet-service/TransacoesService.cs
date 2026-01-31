using myproductexameple_web_dotnet_domain;
using myproductexameple_web_dotnet_infra;
using myproductexameple_web_dotnet_service.interfaces;

namespace myproductexameple_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyProductExampleDbContext _dbContext;

        // Construtor para injeção de dependência
        public TransacaoService(MyProductExampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Cadastrar ou atualizar
        public void Cadastrar(Transacao entidade)
        {
            if (entidade == null) return;

            var dbSet = _dbContext.Set<Transacao>();

            // Se Id == 0, cria novo
            if (entidade.Id == 0)
            {
                dbSet.Add(entidade);
            }
            else
            {
                // Atualiza existente
                _dbContext.Update(entidade);
            }

            _dbContext.SaveChanges();
        }

        // Excluir por id
        public void Excluir(long id)
        {
            var dbSet = _dbContext.Set<Transacao>();

            var entidade = new Transacao { Id = id };
            dbSet.Attach(entidade);
            dbSet.Remove(entidade);

            _dbContext.SaveChanges();
        }

        // Listar todas as transações
        public List<Transacao> ListarRegistro()
        {
            var dbSet = _dbContext.Set<Transacao>();
            return dbSet.ToList();
        }

        // Buscar transação por id
        public Transacao? RetornarRegistro(long id)
        {
            var dbSet = _dbContext.Set<Transacao>();
            return dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}
