using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webServices.weatherService;
using webServices.tempConvert;

namespace webServices
{
    public partial class weather : System.Web.UI.Page
    {
        weatherService.Forecast newFor = new weatherService.Forecast();
        tempConvert.WebService1 tempConvert = new tempConvert.WebService1();
        weatherService.Weather weath = new weatherService.Weather();
        weatherService.ForecastReturn returnWeath = new weatherService.ForecastReturn();
        weatherService.WeatherDescription weathInfo = new weatherService.WeatherDescription();

        weatherService.POP pop = new weatherService.POP();

        
        protected void btnGet_Click(object sender, EventArgs e)
        {
            getTemp();
        }

        public void getTemp ()
        {
            returnWeath = weath.GetCityForecastByZIP(txtZip.Text);
            lblResult.Text = "State: " + returnWeath.State;
            lblResult.Text += "<br/> City: " + returnWeath.City;
            lblResult.Text += "<br/> Weather Station: " + returnWeath.WeatherStationCity;

            for (int i = 1; i < 6; i++)
            {
                lblResult.Text += "<div class='forcastBlock'>";
                var getDate = DateTime.Now;
                getDate = getDate.AddDays(i);
                newFor = returnWeath.ForecastResult[i];
                lblResult.Text += getDate.Date.DayOfWeek.ToString() + " " + getDate.Date.ToString("MMMM dd, yyyy") + ".";

                weathInfo = weath.GetWeatherInformation()[newFor.WeatherID-1];
                lblResult.Text += "<br/> <img runat='server' ID='weathIcon' src=" + weathInfo.PictureURL + "  height='25px' width='25px' />   " + newFor.Desciption;
                lblResult.Text += "<h4>Probability Of Percipitation</h4>";
                lblResult.Text += "Daytime: " + newFor.ProbabilityOfPrecipiation.Daytime + "%";
                lblResult.Text += "<br/> Nighttime: " + newFor.ProbabilityOfPrecipiation.Nighttime + "%";

                lblResult.Text += "<h4>Temperature</h4>";

                if (rbGetType.SelectedValue == "f")
                {
                    lblResult.Text += "Morning Low: " + newFor.Temperatures.MorningLow.ToString() + "°F";
                    lblResult.Text += "<br/> Daytime High: " + newFor.Temperatures.DaytimeHigh.ToString() + "°F";
                }
                else
                {
                    lblResult.Text += "<br/> Morning Low: " + tempConvert.getCelcius(Convert.ToInt32(newFor.Temperatures.MorningLow)).ToString() + "°C";
                    lblResult.Text += "<br/> Daytime High: " + tempConvert.getCelcius(Convert.ToInt32(newFor.Temperatures.DaytimeHigh)).ToString() + "°C";
                }

                var getDescription = newFor.Desciption;

                if (getDescription == "Mostly Cloudy")
                {
                    getDescription = "Cloudy";
                }
                lblResult.Text += newFor.WeatherID.ToString();

                lblResult.Text += "</div>";
            }
              
        
        }

        protected void rbGetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTemp();
        }


    }
}