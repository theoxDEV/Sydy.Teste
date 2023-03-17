using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SydyTeste.Data.Models;
using SydyTeste.Data.Models.Requests;
using SydyTeste.Data.Services.Interfaces;

namespace SydyTeste.Controllers
{
    /// <summary>
    /// Endpoints para visualizacao dos times
    /// </summary>
    [Route("api/Time")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        public TeamController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        [HttpGet("{pagina}/{tamanhoPagina}")]
        public async Task<ActionResult<PaginatedTeams>> GetPaginatedTeams(int pagina, int tamanhoPagina)
        {
            return await _teamsService.GetPaginatedTeams(pagina, tamanhoPagina);
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {
            return await _teamsService.GetAllTeams();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Team>>> GetSingleTeam(int id)
        {
            var response = await _teamsService.GetSingleTeam(id);

            if(response == null)
            {
                return BadRequest($"Time com id: {id} não encontrado");
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam([FromBody] TeamRequest team)
        {
            try
            {
                if (team.Name.Length <= 3)
                {
                    return BadRequest("Nome da equipe deve ser maior do que 3 caracteres");
                }

                var response = await _teamsService.AddTeam(team.Name);

                return Ok(response);
            }

            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Team>>> UpdateTeam(int id, [FromBody] TeamRequest team)
        {
            try
            {
                var response = await _teamsService.UpdateTeam(id, team);

                if (response == null)
                {
                    return BadRequest($"Time com id: {id} não encontrado");
                }

                return Ok(response);
            }


            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            } 

            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<List<Team>>> DeleteTeam(int id)
        {
            try
            {
                var response = await _teamsService.DeleteTeam(id);

                if (response == null)
                {
                    return BadRequest($"Time com id: {id} não encontrado");
                }

                return Ok(response);
            }


            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
