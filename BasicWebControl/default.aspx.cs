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
        public readonly byte[] TEMPERATURE_BLOWER   = { 4 };
        public static MySerial serial;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentTemperature.InnerText = "";
            goalTemperature.InnerText = "";
        }

        protected void IncreaseTemp(object sender, EventArgs e)
        {
            serial.Send(TEMPERATURE_INCREASE);
            //goalTemperature.InnerText = (int.Parse(goalTemperature.InnerText) + 1).ToString();
            RefreshData();
        }

        protected void DecreaseTemp(object sender, EventArgs e)
        {
            serial = new MySerial(3);
            serial.Send(TEMPERATURE_DECREASE);
            RefreshData();
        }

        protected void RefreshData()
        {
            // Refresh current temperature
            serial.Send(TEMPERATURE_CURRENT);
            int i = int.Parse(serial.ProcessData());
            double d = i / 100.0;
            currentTemperature.InnerText = d.ToString();

            // Refresh goal temperature
            serial.Send(TEMPERATURE_GOAL);
            goalTemperature.InnerText = serial.ProcessData();
        }

        protected void ConnectToArduino(object sender, EventArgs e)
        {
            try
            {
                //serial = new MySerial(int.Parse(port.Text));
                serial = new MySerial(int.Parse(port.Text));
            }
            catch
            {
                ArduinoConnectionButton2.Text = "Error!";
                serial = null;
            }


            if (serial == null)
            {
                ArduinoConnectionButton2.CssClass = "btn btn-danger";
                ArduinoConnectionButton2.Text = "Connection to Arduino failed";
            }
            else
            {
                ArduinoConnectionButton2.CssClass = "btn btn-success";
                ArduinoConnectionButton2.Text = " Connected";
                tempIncreaser.Enabled = true;
                tempDecreaser.Enabled = true;
                tempIncreaser.CssClass = "btn btn-danger";
                tempDecreaser.CssClass = "btn btn-info";
                RefreshData();
            }
        }
    }
}