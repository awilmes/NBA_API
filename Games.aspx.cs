using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using NbaApiJson;
using System.IO;

public partial class Games : System.Web.UI.Page
{
    private static HttpClient _client = new HttpClient();
    private string _json;    

    protected async void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _json = await GetPrevDayGames();
            InitializeData();
            DataBind();            
        }        
    }

    protected void InitializeData()
    {
        // Creates a list of games based on the JSON returned from the API, and adds the games to a GridView
        
        try
        {
            List<Datum> games = new List<Datum>();

            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(_json);

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("date");
            dt1.Columns.Add("home_team");
            dt1.Columns.Add("home_team_score");
            dt1.Columns.Add("visitor_team");
            dt1.Columns.Add("visitor_team_score");

            for (int i = 0; i < rootObject.Data.Length; i++)
            {
                games.Add(rootObject.Data[i]);
            }

            foreach (Datum game in games)
            {
                dt1.Rows.Add(game.Id, game.Date.Date.ToString("D"), game.HomeTeam.Name, game.HomeTeamScore, game.VisitorTeam.Name, game.VisitorTeamScore);
            }

            gridGames.DataSource = dt1;
            gridGames.DataBind();
        }
        catch (Newtonsoft.Json.JsonReaderException e)
        {
            lblError.Text = e.Message;
        }
        catch (System.IndexOutOfRangeException e)
        {
            pnlNoGames.Visible = true;
        }
        catch (Exception err)
        {
            lblError.Text = err.Message;
        }        
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell homeScoreCell = e.Row.Cells[2];
            TableCell visitorScoreCell = e.Row.Cells[4];

            int homeScore = int.Parse(homeScoreCell.Text);
            int visitorScore = int.Parse(visitorScoreCell.Text);

            if (homeScore > visitorScore)
            {
                homeScoreCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#82E0AA"); // Sets cell background to green
                visitorScoreCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1948A"); // Sets cell background to red
            }
            else if (homeScore < visitorScore)
            {
                homeScoreCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1948A"); // Sets cell background to red
                visitorScoreCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#82E0AA"); // Sets cell background to green
            }
        }
    }

    public static string GetPrevDay()
    {       
        // Returns a formatted string of the previous day: 'YYYY-MM-DD'
        
        string prevDate = DateTime.Now.AddDays(-1).ToShortDateString();
        string[] splitDate = prevDate.Split('/');

        string outDate = splitDate[2] + "-" + splitDate[0] + "-" + splitDate[1];

        return outDate;
    }

    public static async Task<string> GetPrevDayGames()
    {
        // Gets the JSON of games from the previous day using API

        // Define base URL
        string prevDay = GetPrevDay();
        string baseURL = "https://balldontlie.io/api/v1/games?start_date=" + prevDay + "&end_date=" + prevDay;
        string output;

        try
        {
            // Define HttpClient with your first using statement which use a IDisposable.
            using (_client)
            {
                // Initiate the GET request, use the await keyword so it will execute the using statement in order.
                // The HttpResponseMessage which contains the status code, and data from response.
                using (HttpResponseMessage res = await _client.GetAsync(baseURL))
                {
                    // Get the data from the response and convert it to a C# object.
                    using (HttpContent content = res.Content)
                    {
                        // Assign content to data variable by converting to a string using the await keyword.
                        var data = await content.ReadAsStringAsync();
                        // If not null, return log convert the data using newtonsoft JObject Parse class method on the data.
                        if (data != null)
                        {
                            output = data;
                            return output;
                        }
                        else
                        {
                            output = "Data was null";
                            return output;
                        }
                    }
                }
            }
        }
        catch (Exception err)
        {
            return err.Message;
        }
    }
}