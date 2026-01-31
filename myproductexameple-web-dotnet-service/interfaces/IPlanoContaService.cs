using myproductexameple_web_dotnet_domain;

namespace myproductexameple_web_dotnet_service.interfaces
{
    public interface IPlanoContaService
    {
        void Cadastrar(PlanoConta Entidade);
        void Excluir(long id);
        List<PlanoConta> ListarRegistro();
        PlanoConta RetornarRegistro(long id);
    }
}