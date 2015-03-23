using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webServices.currencyService;

namespace webServices
{
    public partial class currencyConverter1 : System.Web.UI.Page
    {
        currencyConverter currency = new currencyConverter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> allCountries = new List<string>(currency.allCountries());
                foreach (var items in allCountries)
                {
                    var allItems = items.Split(',');
                    var rate = allItems[1];
                    var country = allItems[0];
                    ddFrom.Items.Add(country);
                    ddTo.Items.Add(country);
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            convert();
        }

        protected void ddTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            convert();
        }

        public void convert()
        {
            string rate1 = "1";
            string rate2 = "1";
            try
            {
                List<string> allCountries = new List<string>(currency.allCountries());
                foreach (var items in allCountries)
                {
                    var allItems = items.Split(',');
                    var rate = allItems[1];
                    var country = allItems[0];
                  
                    if (country == ddTo.SelectedValue)
                    {
                        rate1 = allItems[1];

                        
                    }                    
                }
                foreach (var item in allCountries)
                {
                    var allItems = item.Split(',');
                    var rate = allItems[1];
                    var country = allItems[0];

                    if (country == ddFrom.SelectedValue)
                    {
                        rate2 = allItems[1];

                    }

                }

                var getRate = currency.convert2(Convert.ToDouble(rate1), 1, Convert.ToDouble(rate2));
                lblResult.Text = "1 " + ddFrom.SelectedValue + " equals " + Math.Round(getRate, 2).ToString() + " " + ddTo.SelectedValue;


                var result = currency.convert2(Convert.ToDouble(rate1), Convert.ToDouble(TextBox1.Text), Convert.ToDouble(rate2));

                TextBox2.Text = Math.Round(result, 2).ToString();
            }
            catch
            {
            }

        }



    }
}