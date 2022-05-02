namespace NbaApiJson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Summary description
    /// </summary>

    //public class Rootobject
    //{
    //    public Datum[] data { get; set; }
    //    public Meta meta { get; set; }
    //}

    //public class Meta
    //{
    //    public int total_pages { get; set; }
    //    public int current_page { get; set; }
    //    public object next_page { get; set; }
    //    public int per_page { get; set; }
    //    public int total_count { get; set; }
    //}

    //public class Datum
    //{
    //    public int id { get; set; }
    //    public DateTime date { get; set; }
    //    public Home_Team home_team { get; set; }
    //    public int home_team_score { get; set; }
    //    public int period { get; set; }
    //    public bool postseason { get; set; }
    //    public int season { get; set; }
    //    public string status { get; set; }
    //    public string time { get; set; }
    //    public Visitor_Team visitor_team { get; set; }
    //    public int visitor_team_score { get; set; }
    //}

    //public class Home_Team
    //{
    //    public int id { get; set; }
    //    public string abbreviation { get; set; }
    //    public string city { get; set; }
    //    public string conference { get; set; }
    //    public string division { get; set; }
    //    public string full_name { get; set; }
    //    public string name { get; set; }
    //}

    //public class Visitor_Team
    //{
    //    public int id { get; set; }
    //    public string abbreviation { get; set; }
    //    public string city { get; set; }
    //    public string conference { get; set; }
    //    public string division { get; set; }
    //    public string full_name { get; set; }
    //    public string name { get; set; }
    //}

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



