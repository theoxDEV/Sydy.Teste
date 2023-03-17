namespace SydyTeste.Data.Models
{
    public class PaginatedTeams
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdPagina { get; set; }
        public List<Team> Itens { get; set; }
    }
}
