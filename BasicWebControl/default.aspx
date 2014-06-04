<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BasicWebControl._default" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <div class="container">
    <div class="row">
      <div class="page-header" id="banner">
        <div class="jumbotron">
          <div class="h2">Thermostat</div>
          <div class="form-group has-success">
            <div class="col-lg-2">
              <asp:TextBox ID="port" runat="server" type="number" size="2" min="1" max="8" CssClass="form-control" placeholder="Port Number" ValidationGroup="connection" />
            </div>
            <asp:Button ID="ArduinoConnectionButton2" runat="server" CssClass="btn btn-default" OnClick="ConnectToArduino" UseSubmitBehavior="false" Text="Connect to Arduino" CausesValidation="true" ValidationGroup="connection" />
          </div>
        </div>
      </div>
      <div class="col-lg-6">
        <div class="row">
          <div class="col-lg-4 lead">
            <div class="panel panel-info">
              <div class="panel-heading">
                <h3 class="panel-title">Current Temperature</h3>
              </div>
              <div class="panel-body">
                <a runat="server" id="currentTemperature"></a>°F
              </div>
            </div>
          </div>
          <div class="col-lg-4 lead">
            <div class="panel panel-info">
              <div class="panel-heading">
                <h3 class="panel-title">Target temperature</h3>
              </div>
              <div class="panel-body">
                <a runat="server" id="goalTemperature"></a>°F
              </div>
            </div>
          </div>
          <div class="col-md-4">
            <div class="btn-group">
              <asp:Button runat="server" Enabled="false" ID="tempIncreaser" OnClick="IncreaseTemp" UseSubmitBehavior="false" CssClass="btn btn-default" Text="Up" /><%--<i class="fa fa-angle-up"></i>--%>
              <asp:Button runat="server" Enabled="false" ID="tempDecreaser" OnClick="DecreaseTemp" UseSubmitBehavior="false" CssClass="btn btn-default" Text="Down" /><%--<i class="fa fa-angle-down"></i>--%>
            </div>
          </div>
        </div>
      </div>
      <div class="col-lg-4"></div>
    </div>
  </div>
</asp:Content>
