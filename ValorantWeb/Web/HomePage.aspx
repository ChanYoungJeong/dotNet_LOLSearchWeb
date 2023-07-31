<%@ Page Title="HomePage" Language="C#" MasterPageFile="~/Web/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ValorantWeb.Web.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <p></p>
        <div class="col-md-8">
              <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                <div class="col-auto d-none d-lg-block">
                  <image class="bd-placeholder-img" width="200" height="250" src="" id ="icon" runat="server">
                  </image>
                </div>
                <div class="col p-4 d-flex flex-column position-static">
                  <h5 class="mb-0" id="userName" runat="server">Featured post</h5>
                  <div>
                  <img id="emblem" runat="server" src ="../Assets/emblems/Emblem_Bronze.png" width="50" height ="50" alt="" />
                  <strong id="rank" class="d-inline-block mb-2 text-primary-emphasis" runat ="server" style="font-size:36px; margin-top:10px;">World</strong>
                  </div>
                  <div id="level" runat="server" class ="mb-1 text-body-secondary">Level </div>
                  <p id ="winLose" runat="server" class="card-text mb-auto">Win : 00 / Lose : 00</p>
                </div>
              </div>
            </div>
         <div class="col-md-8">
              <div class ="g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                  <div>
                    <p style="display:inline">This Player has a </p>
                    <h3 style="display:inline" id="trollProb" runat="server">50%</h3>
                    <p style="display:inline"> chance of having a bad behavior</p>
                  </div>
                  <div >
                      <p id ="matchHistory" runat="server">

                      </p>
                  </div>
              </div>
          </div>
</asp:Content>
