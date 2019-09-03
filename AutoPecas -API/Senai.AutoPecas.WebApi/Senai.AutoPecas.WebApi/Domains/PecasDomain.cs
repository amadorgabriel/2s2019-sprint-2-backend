namespace Senai.AutoPecas.WebApi.Domains
{
    public class PecasDomain
    {
        public int IdPeca { get; set; }
        public string CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public float Peso { get; set; }
        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }
        public int IdFornecedor { get; set; }
        public FornecedoresDomain Fornecedor { get; set; }

    }
}