using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.Data.Entity
{
    [Table("Pitching")]
    public partial class Pitching
    {
        [Key]
        [Column(Order=1)]
        public string LahmanId { get; set; }
        [Key]
        [Column(Order=2)]
        public int YearId { get; set; }
        [Key]
        [Column(Order=3)]
        public int Stint { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }
        public int GamesStarted { get; set; }
        public int CompleteGames { get; set; }
        public int ShutOuts { get; set; }
        public int Saves { get; set; }
        public int IPouts { get; set; }
        public int Hits { get; set; }
        public int EarnedRuns { get; set; }
        public int HomeRuns { get; set; }
        public int BasesOnBalls { get; set; }
        public int StrikeOuts { get; set; }
        public double BAOpp { get; set; }
        public double EarnedRunAverage { get; set; }
        public int IntentionalWalks { get; set; }
        public int WildPitches { get; set; }
        public int HitByPitch { get; set; }
        public int Balks { get; set; }
        public int BFP { get; set; }
        public int GamesFinished { get; set; }
        public int Runs { get; set; }
        public int SacrificeHit { get; set; }
        public int SacrificeFlies { get; set;}
        public int GroundedIntoDoublePlay { get; set; }
    }
}
