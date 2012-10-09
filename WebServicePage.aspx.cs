using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebServicePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ConvertButton_Click(object sender, EventArgs e)
    {
        Convert wsConvert = new Convert();
        double temperature =
            System.Convert.ToDouble(TemperatureTextBox.Text);
        FahrenheitLabel.Text = "Fahrenheit To Celsius = " +
            wsConvert.FahrenheitToCelsius(temperature).ToString();
        CelsiusLabel.Text = "Celsius To Fahrenheit = " +
            wsConvert.CelsiusToFahrenheit(temperature).ToString();
    }
}