using myproductexameple_web_dotnet_domain;
using myproductexameple_web_dotnet_infra;
using myproductexameple_web_dotnet_service.interfaces;

namespace myproductexameple_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyProductExampleDbContext _dbContext;

        // Construtor público para injeção
        public PlanoContaService(MyProductExampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Cadastrar: se Id == 0 adiciona, senão atualiza
        public void Cadastrar(PlanoConta entidade)
        {
            if (entidade == null) return;

            var dbSet = _dbContext.Set<PlanoConta>();

            if (entidade.Id == 0)
            {
                dbSet.Add(entidade);
            }
            else
            {
                // forma simples: atualiza toda a entidade
                _dbContext.Update(entidade);
            }

            _dbContext.SaveChanges();
        }

        // Excluir por id
        public void Excluir(long id)
        {
            var dbSet = _dbContext.Set<PlanoConta>();

            // criar a entidade com a chave e remover (sem consultar antes)
            var entidade = new PlanoConta { Id = id };
            dbSet.Attach(entidade);
            dbSet.Remove(entidade);

            _dbContext.SaveChanges();
        }

        // Listar todos os registros
        public List<PlanoConta> ListarRegistro()
        {
            var dbSet = _dbContext.Set<PlanoConta>();
            return dbSet.ToList();
        }

        // Retornar um registro por id (retorna null se não achar)
        public PlanoConta? RetornarRegistro(long id)
        {
            var dbSet = _dbContext.Set<PlanoConta>();
            return dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}
