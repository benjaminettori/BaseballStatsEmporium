using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballStatsEmporium.Models
{
    public class PlayerInformation
    {
        public int PlayerId { get; set; }
        public string LahmanId { get; set; }
        public string ManagerId { get; set; }
        public string HofID { get; set; }
        public int? BirthYear { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public string BirthCountry { get; set; }
        public string BirthState { get; set; }
        public string BirthCity { get; set; }
        public int? DeathYear { get; set; }
        public int? DeathMonth { get; set; }
        public int? DeathDay { get; set; }
        public string DeathCountry { get; set; }
        public string DeathState { get; set; }
        public string DeathCity { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string NameNote { get; set; }
        public string NameGiven { get; set; }
        public string Nickname { get; set; }
        public int? Weight { get; set; }
        public double? Height { get; set; }
        public string Bats { get; set; }
        public string Throws { get; set; }
        public string Debut { get; set; }
        public string FinalGame { get; set; }
        public string College { get; set; }
    }
}