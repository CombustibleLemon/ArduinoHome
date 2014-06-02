<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="BasicWebControl.about" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <div class="jumbotron">
    <h1>Arduino Thermostat</h1>
    <p>A powerful thermostat controlled by a modern website.</p>
    <p><a href="https://github.com/CombustibleLemon/ArduinoThermostat"><i class="fa fa-github"></i></a></p>
  </div>
  <div class="row">
    <div class="col col-lg-4">
      <div class="panel panel-info">
        <div class="panel-heading">
          <h3 class="panel-title">About Arduino</h3>
        </div>
        <div class="panel-body">
          <blockquote>
            <p>Arduino is an open-source electronics prototyping platform based on flexible, easy-to-use hardware and software. It's intended for artists, designers, hobbyists and anyone interested in creating interactive objects or environments.</p>
            <small>From the <a href="http://www.arduino.cc/">Arduino website</a></small>
          </blockquote>
        </div>
      </div>
    </div>
    <div class="col col-lg-4">
      <div class="panel panel-info">
        <div class="panel-heading">
          <h3 class="panel-title">How it works</h3>
        </div>
        <div class="panel-body">
          <p>The <abbr title="heating, ventilation, and air conditioning">HVAC</abbr> system works by completing a <abbr title="Twenty-four volt">24V</abbr><abbr title="Alternating Current">AC</abbr> circuit on four different wires; however, the Arduino works with <abbr title="Five volt">5V</abbr><abbr title="Direct Current">DC</abbr>. <a href="http://www.digikey.com/product-search/en?lang=en&site=US&KeyWords=lc241r&x=0&y=0">The relays used</a> handle <abbr title="Twenty-four volt">24V</abbr><abbr title="Alternating Current">AC</abbr> on the HVAC side, and it can be toggled directly by the output of the <abbr title="Five volt">5V</abbr><abbr title="Direct Current">DC</abbr> of the Arduino.</p>
          <p>The Arduino is controlled by sending serial messages over <abbr title="Universal Serial Bus">USB</abbr> from a webserver. The webserver runs an <a href="http://asp.net/"><abbr title="Active Server Pages">ASP</abbr>.NET</a> web form.</p>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
