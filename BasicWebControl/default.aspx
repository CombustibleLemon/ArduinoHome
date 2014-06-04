<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BasicWebControl._default" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <div class="container">
    <div class="row">
      <div class="page-header" id="banner">
        <div class="jumbotron">
          <div class="h2">Thermostat</div>
          <asp:LinkButton ID="ArduinoConnectionButton" runat="server" CssClass="btn btn-default" OnClick="ConnectToArduino">Connect to Arduino</asp:LinkButton>
        </div>
      </div>
      <div class="col-lg-4">
        <div class="row">
          <div class="col-md-4 lead"><a runat="server" id="currentTemperature"></a>°F</div>
          <div class="col-md-4 lead"><a runat="server" id="goalTemperature"></a>°F</div>
          <div class="col-md-4">
            <div class="btn-group">
              <asp:LinkButton runat="server" Enabled="false" ID="tempIncreaser" OnClick="IncreaseTemp" CssClass="btn btn-default"><i class="fa fa-angle-up"></i></asp:LinkButton>
              <asp:LinkButton runat="server" Enabled="false" ID="tempDecreaser" OnClick="DecreaseTemp" CssClass="btn btn-default"><i class="fa fa-angle-down"></i></asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
      <div class="col-lg-4"></div>
    </div>
  </div>
</asp:Content>
