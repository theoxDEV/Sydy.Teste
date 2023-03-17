using SydyTeste.Data.Models;
using SydyTeste.Data.Models.Requests;

namespace SydyTeste.Data.Services.Interfaces
{
    public interface ITeamsService
    {
        Task<List<Team>> GetAllTeams();
        Task<PaginatedTeams> GetPaginatedTeams(int page, int pageLength);
        Task<Team?> GetSingleTeam(int id);
        Task<List<Team>> AddTeam(string name);
        Task<Team?> UpdateTeam(int id, TeamRequest request);
        Task<List<Team>?> DeleteTeam(int id);
    }
}
