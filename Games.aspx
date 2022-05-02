<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Games.aspx.cs" Inherits="Games" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-wf-page="62700d68fc9a4eae0cc03ec9" data-wf-site="62700d68fc9a4e45d3c03ec8">
<head runat="server">
    <meta charset="utf-8" />
    <title>NBA_API</title>
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Webflow" name="generator" />
    <link href="styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="styles/webflow.css" rel="stylesheet" type="text/css" />
    <link href="styles/nba-api.webflow.css" rel="stylesheet" type="text/css" />
    <!-- [if lt IE 9]><script src="https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7.3/html5shiv.min.js" type="text/javascript"></script><![endif] -->
    <script type="text/javascript">!function (o, c) { var n = c.documentElement, t = " w-mod-"; n.className += t + "js", ("ontouchstart" in o || o.DocumentTouch && c instanceof DocumentTouch) && (n.className += t + "touch") }(window, document);</script>
    <link href="images/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="images/webclip.png" rel="apple-touch-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="wf-section">
            <div class="container w-container">
                <img src="images/nba-logo.png" loading="lazy" width="141" alt="" class="image" />
                <h1 class="heading">Results from <%# DateTime.Now.AddDays(-1).ToString("D") %></h1>
            </div>            
        </header>
        <div id="main" class="w-container">
            <asp:Panel ID="pnlNoGames" runat="server" Visible="false">
                <h2 class="main_heading">No games to display.</h2>
            </asp:Panel>            
            <asp:GridView ID="gridGames" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                <Columns>
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="home_team" HeaderText="Home Team" />
                    <asp:BoundField DataField="home_team_score" HeaderText="Score" />
                    <asp:BoundField DataField="visitor_team" HeaderText="Visitor Team" />
                    <asp:BoundField DataField="visitor_team_score" HeaderText="Score" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <footer class="section wf-section">
            <div class="w-container">
                <div class="text-block">Copyright © 2022 Wilmes Computers LLC. All rights reserved.</div>
            </div>
        </footer>
        <script src="https://d3e54v103j8qbb.cloudfront.net/js/jquery-3.5.1.min.dc5e7f18c8.js?site=62700d68fc9a4e45d3c03ec8" type="text/javascript" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
        <script src="js/webflow.js" type="text/javascript"></script>
        <!-- [if lte IE 9]><script src="https://cdnjs.cloudflare.com/ajax/libs/placeholders/3.0.2/placeholders.min.js"></script><![endif] -->
    </form>
</body>
</html>
