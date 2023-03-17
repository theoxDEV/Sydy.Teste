using Microsoft.EntityFrameworkCore;
using SydyTeste.Data.DB;
using SydyTeste.Data.Models;
using SydyTeste.Data.Models.Requests;
using SydyTeste.Data.Services.Interfaces;

namespace SydyTeste.Data.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly SydyDataContext _context;

        public TeamsService(SydyDataContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<PaginatedTeams> GetPaginatedTeams(int page, int pageLength)
        {
            var count = GetAllTeams().Result.Count();

            var pagesQuantity = Math.Ceiling((decimal)count / (decimal)pageLength);

            var query = await _context.Teams
                .Skip((page - 1) * pageLength)
                .Take(pageLength)
                .ToListAsync();

            var paginatedTeams = new PaginatedTeams()
            {
                Pagina = page,
                QtdPagina = (int)pagesQuantity,
                TamanhoPagina = pageLength,
                Itens = query
            };

            return paginatedTeams;
        }

        public async Task<List<Team>> AddTeam(string teamName)
        {
            var query = await _context.Teams.FirstOrDefaultAsync(x => x.Name == teamName);

            var team = new Team
            {
                Name = teamName
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return await _context.Teams.ToListAsync();
        }

        public async Task<List<Team>?> DeleteTeam(int id)
        {
            var query = await _context.Teams.FindAsync(id);

            if(query == null)
            {
                return null;
            }

            _context.Teams.Remove(query);
            await _context.SaveChangesAsync();

            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetSingleTeam(int id)
        {
            var query = await _context.Teams.FindAsync(id);

            if (query == null)
            {
                return null;
            }

            return query;
        }

        public async Task<Team?> UpdateTeam(int id, TeamRequest teamRequest)
        {
            var query = await _context.Teams.FindAsync(id);

            if(query == null)
            {
                return null;
            }

            query.Name = teamRequest.Name;

            await _context.SaveChangesAsync();

            return query;
        }
    }
}
