using SydyTeste.Data.DB;
using SydyTeste.Data.Models;
using SydyTeste.Data.Services.Interfaces;

namespace SydyTeste.Data.Services
{
    public class CupService : ICupService
    {
        private readonly SydyDataContext _context;

        public CupService(SydyDataContext context)
        {
            _context = context;
        }

        public Cup GetCup()
        {
            var cup = new Cup(_context.Teams.ToList());

            return cup;
        }
    }
}
