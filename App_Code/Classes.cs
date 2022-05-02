namespace NbaApiJson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    <summary>
        Classes for JSON data
    </summary>

    public partial class RootObject
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("home_team_score")]
        public long HomeTeamScore { get; set; }

        [JsonProperty("period")]
        public long Period { get; set; }

        [JsonProperty("postseason")]
        public bool Postseason { get; set; }

        [JsonProperty("season")]
        public long Season { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("visitor_team")]
        public Team VisitorTeam { get; set; }

        [JsonProperty("visitor_team_score")]
        public long VisitorTeamScore { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("conference")]
        public string Conference { get; set; }

        [JsonProperty("division")]
        public string Division { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("next_page")]
        public object NextPage { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }
    }
}



