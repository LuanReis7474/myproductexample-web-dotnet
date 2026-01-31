using myproductexameple_web_dotnet_domain;

namespace myproductexameple_web_dotnet_service.interfaces
{
    public interface ITransacaoService
    {
        void Cadastrar(Transacao entidade);

        void Excluir(long id);

        List<Transacao> ListarRegistro();

        Transacao? RetornarRegistro(long id);
    }
}
