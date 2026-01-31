// Transacao.cs
using myproductexameple_web_dotnet_domain; // ✅ ADICIONE ESTA LINHA

namespace myproductexameple_web_dotnet_domain;
public class Transacao
{
    public long Id { get; set; }
    public string? Historico { get; set; }
    public DateTime Data { get; set; }
    public decimal? Valor { get; set; }           // COM ? (nullable)
    public long? PlanoContaId { get; set; }       // COM ? (nullable)
    public PlanoConta? PlanoConta { get; set; }
}