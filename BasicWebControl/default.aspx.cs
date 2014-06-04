using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SerialCommands;

namespace BasicWebControl
{
    public partial class _default : System.Web.UI.Page
    {
        public readonly byte[] TEMPERATURE_INCREASE = { 0 };
        public readonly byte[] TEMPERATURE_DECREASE = { 1 };
        public readonly byte[] TEMPERATURE_GOAL     = { 2 };
        public readonly byte[] TEMPERATURE_CURRENT  = { 3 };
        public MySerial serial;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentTemperature.InnerText = "71.92";
            goalTemperature.InnerText = "70";
        }

        protected void IncreaseTemp(object sender, EventArgs e)
        {
            //serial.send(TEMPERATURE_INCREASE);
            goalTemperature.InnerText = (int.Parse(goalTemperature.InnerText) + 1).ToString();
            RefreshData();
        }

        protected void DecreaseTemp(object sender, EventArgs e)
        {
            serial.send(TEMPERATURE_DECREASE);
            RefreshData();
        }

        protected void RefreshData()
        {

        }

        protected void ConnectToArduino(object sender, EventArgs e)
        {
            serial = new MySerial(3);

            if (serial == null)
            {
                serial = null;
                ArduinoConnectionButton.CssClass = "btn btn-danger";
                ArduinoConnectionButton.Text = "<i class=\"fa fa-times\"></i> Failed";
            }
            else
            {
                ArduinoConnectionButton.CssClass = "btn btn-success";
                ArduinoConnectionButton.Text = "<i class=\"fa fa-check\"></i> Connected";
                tempIncreaser.Enabled = true;
                tempDecreaser.Enabled = true;
                tempIncreaser.CssClass = "btn btn-danger";
                tempDecreaser.CssClass = "btn btn-info";
            }
        }
    }
}