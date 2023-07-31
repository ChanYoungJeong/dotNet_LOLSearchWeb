<%@ Page Title="Search Page" Language="C#" MasterPageFile="~/Web/Site.Master" AutoEventWireup="true" CodeBehind="Lol.aspx.cs" Inherits="ValorantWeb.Web.Lol" %>

<asp:Content ID="SearchBar" ContentPlaceHolderID="MainContent" runat="server">
<div class="my-3 p-3 bg-white rounded box-shadow">
        <h6 class="border-bottom border-gray pb-2 mb-0">Calculations</h6>
        <div class="media text-muted pt-3">
          <p class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
            <strong class="d-block text-gray-dark">Win Rate</strong>
            Win rate has the highest priority to check if player might have bad behaviour
          </p>
        </div>
        <div class="media text-muted pt-3">
          <p class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
            <strong class="d-block text-gray-dark">Kills/Deaths/Assists</strong>
              It will check KDAs of recent 20 rank-matches to analyze each games behaviour.
          </p>
        </div>
        <div class="media text-muted pt-3">
          <p class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray">
            <strong class="d-block text-gray-dark">Equation</strong>
            This website is using exponentioal equation to find percentage of having bad behaviour.
            <br /><image src ="../Assets/Equation.jpg"></image>
          </p>
            
        </div>
      </div>

</asp:Content>



