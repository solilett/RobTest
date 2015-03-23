using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace webServices
{
    /// <summary>
    /// Summary description for currencyConverter
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class currencyConverter : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<string> allCountries()
        {
            List<string> list = new List<string>();
            list.Add("British Pound Sterling, 1");
            list.Add("US Dolars, 1.67");
            list.Add("Euro, 1.38");
            list.Add("Yen, 179.51");
            return list;

        }


        [WebMethod]
        public double convert(double rate, double value)
        {
            double result = value * (rate);
            return result;
        }

        [WebMethod]
        public double convert2(double rate, double value, double rate2)
        {
            double result;

            result = value / rate2;
            result = result * rate;
            return result;
        }

        public class Country
        {
            public string name { get; set; }
            public string currency { get; set; }
            public string rate { get; set; }
        }

        [WebMethod]
        public List<Country> countryList()
        {
            var countryList = new List<Country>(); 

            countryList.Add(new Country
            {
                name = "America",
                currency = "US Dollars",
                rate = "1.67",
            });

            countryList.Add(new Country
            {
                name = "United Kingdom",
                currency = "British Pound Sterling",
                rate = "1.38",
            });

            countryList.Add(new Country
            {
                name = "France",
                currency = "Euro",
                rate = "1.67",
            });



            return countryList;
        }

    }
}
