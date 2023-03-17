using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SydyTeste.Data.Models
{
    public class Cup
    {
        private List<CupTeam>? Teams { get; set; }

        [JsonPropertyName("partidas")]
        public List<Match>? Matches { get; set; }

        [JsonPropertyName("campeao")]
        public string? Champion { get; set; }

        [JsonPropertyName("vice")]
        public string? SecondPlace { get; set; }

        [JsonPropertyName("terceiro")]
        public string? ThirdPlace { get; set; }


        public Cup(List<Team> teams)
        {
            Teams = JsonConvert.DeserializeObject<List<CupTeam>>(JsonConvert.SerializeObject(teams));
            Matches = GetMatches();
        }

        public List<Match> GetMatches()
        {
            var matches = new List<Match>();

            for (int i = 0; i < Teams!.Count; i++)
            {
                for(int j = 0; j < Teams.Count; j++)
                {
                    if (Teams[i].Name != Teams[j].Name)
                    {
                        var match = new Match(Teams[i], Teams[j]);

                        matches.Add(match);

                        GetTeamPoints(match);
                    }
                }
            }


            Teams = Teams.OrderByDescending(t => t.Points).ToList();

            Champion = $"{Teams[0].Name} - Pontos: {Teams[0].Points}";
            SecondPlace = $"{Teams[1].Name} - Pontos: {Teams[1].Points}";
            ThirdPlace = $"{Teams[2].Name} - Pontos: {Teams[2].Points}";

            return matches;
        }

        public void GetTeamPoints(Match match)
        {
            var team01 = Teams!.Find(t => t.Name == match.Team01!.Name);
            var team02 = Teams!.Find(t => t.Name == match.Team02!.Name);

            
            if (match.Team01!.Score > match.Team02!.Score)
            {
                team01!.Points += 3;
            } 
            else if (match.Team02.Score > match.Team01.Score)
            {
                team02!.Points += 3;
            }
            else
            {
                team01!.Points += 1;
                team02!.Points += 1;
            }
        }
    }
}
