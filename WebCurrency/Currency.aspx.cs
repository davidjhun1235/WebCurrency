using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text;

namespace WebCurrency
{
    public partial class Currency : System.Web.UI.Page
    {
        Rate M;
        Rate Y;

        protected void Page_Init(object sender, EventArgs e)
        {
            ddl();
            ddlCurrency.SelectedIndexChanged += DdlCurrency_SelectedIndexChanged;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ddl();
            getRate();
            
            
        }

        private void DdlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxlMonthMinDate.Text = string.Empty;
            tbxlMonthMinRate.Text = string.Empty;
            tbxTodayDate.Text = string.Empty;
            tbxTodayRate.Text = string.Empty;
            tbxHalfYearMinDate.Text = string.Empty;
            tbxHalfYearMinRate.Text = string.Empty;
            getRate();

        }

        void ddl()
        {
            string [] currency  = new string[3];
            currency[0] = "USD";
            currency[1] = "JPY";
            currency[2] = "EUR";


            DataTable DT = new DataTable();
            DataRow DR;
            DT.Columns.Add("PK", typeof(int));
            DT.Columns.Add("Currency", typeof(string));


            for (int i = 0; i < currency.Length; i++)
            {
                DR = DT.NewRow();
                DR["PK"] = i;
                DR["Currency"] = currency[i];
                DT.Rows.Add(DR);
            }

            ddlCurrency.DataSource = DT;
            ddlCurrency.DataTextField = "Currency";
            ddlCurrency.DataValueField ="PK";
            ddlCurrency.DataBind();


        }

        void getRate()
        {
            M = new Rate("thisMonth", ddlCurrency.SelectedItem.Text);
            M.getRate();
            tbxTodayRate.Text = M.TodayRate.ToString();
            tbxTodayDate.Text = M.TodayDate;
            tbxlMonthMinRate.Text = M.RateMin.ToString();
            tbxlMonthMinDate.Text = M.DateMin;
            
            Y = new Rate("HalfYear", ddlCurrency.SelectedItem.Text);
            Y.getRate();
            tbxHalfYearMinRate.Text = Y.RateMin.ToString(); ;
            tbxHalfYearMinDate.Text = Y.DateMin;



            
        }
    }

    public class Rate
    {
        string webUrl;
        string rType;
        string Currency;
        public double RateMin;
        public string DateMin;

        MemoryStream ms;
        WebClient url = new WebClient();
        string date = DateTime.Now.Year.ToString() + "-" + ("0" + DateTime.Now.Month.ToString()).Substring(0, 2);

        string h1;
        string h2;
        //string cDate;

        string[] rDate;
        double[] rRate;

        public string TodayDate;
        public double TodayRate;

        HtmlDocument doc;
        HtmlDocument hdc;
        HtmlNodeCollection htnode;

        double rate;





        public Rate(string type, string currency)
        {
            rType = type;
            Currency = currency;
        }



        public void getRate()
        {

            if (rType == "thisMonth")
            {
                webUrl = @"http://rate.bot.com.tw/xrt/quote/" + date + "/" + Currency;

            }
            else if (rType == "HalfYear")
            {
                webUrl = @"http://rate.bot.com.tw/xrt/quote/l6m/" + Currency;
            }

            ms = new MemoryStream(url.DownloadData(webUrl));
            doc = new HtmlDocument();
            doc.Load(ms, Encoding.UTF8);

            hdc = new HtmlDocument();
            hdc.LoadHtml(doc.DocumentNode.SelectSingleNode(" /html[1]/body[1]/div[1]/main[1]/div[4]/table[1]/tbody[1]").InnerHtml);
            htnode = hdc.DocumentNode.SelectNodes("./tr");

            rDate = new string[htnode.Count];
            rRate = new double[htnode.Count];

            for (int a = 0; a < htnode.Count; a++)
            {
                if (Currency != "KRW")
                {
                    h1 = string.Format("./tr[{0}]/td[1]", a + 1);
                    h2 = string.Format("./tr[{0}]/td[4]", a + 1);
                }
                else //韓元沒即期匯率，所以抓現金匯率
                {
                    h1 = string.Format("./tr[{0}]/td[1]", a + 1);
                    h2 = string.Format("./tr[{0}]/td[6]", a + 1);
                }
                rDate[a] = (hdc.DocumentNode.SelectSingleNode(h1).InnerText);
                rRate[a] = Convert.ToDouble(hdc.DocumentNode.SelectSingleNode(h2).InnerText);
            }

            rate = rRate.Min();

            RateMin = rate;
            int index = Array.IndexOf(rRate, rate);

            TodayDate = rDate[0];
            TodayRate = rRate[0];

            DateMin = rDate[index];




        }




    }
}