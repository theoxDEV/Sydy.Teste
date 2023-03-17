using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SydyTeste.Data.Models
{
    public class Match
    {
        [Newtonsoft.Json.JsonIgnore]
        public readonly CupTeam? Team01;
        public readonly CupTeam? Team02;


        [JsonPropertyName("times")]
        public string? Teams
        {
            get => $"{Team01!.Name} x {Team02!.Name}";
        }

        [JsonPropertyName("resultados")]
        public string Results
        {
            get => $"{Team01!.Score} x {Team02!.Score}";
        }

        public Match(Team team01, Team team02)
        {

            Team01 = JsonConvert.DeserializeObject<CupTeam>(JsonConvert.SerializeObject(team01));
            Team02 = JsonConvert.DeserializeObject<CupTeam>(JsonConvert.SerializeObject(team02));

            Team01!.Score = TeamRandomScore();
            Team02!.Score = TeamRandomScore();
        }

        public static int TeamRandomScore()
        {
            Random rnd = new();
            var randomScore = rnd.Next(0, 7);

            return randomScore;
        }
    }

}
