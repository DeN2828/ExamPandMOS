using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace olxParsFin
{
    public class Search
    {



        IWebDriver browser;
        public Search()
        {
        }


        public List<Objavi> start(string request,string priceF, string priceU, int filtrType)
        {




            List<Objavi> objavleniya
                = new List<Objavi>();






            browser = new OpenQA.Selenium.Chrome.ChromeDriver("/Users/tim/Projects/Olxparser/chromedriver");

            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://www.olx.ua/uk/");
            IWebElement searchBar = browser.FindElement(By.Id("headerSearch"));
            searchBar.SendKeys(request);
            //Thread.Sleep(1000);
            IWebElement searchButton = browser.FindElement(By.Id("submit-searchmain"));
            searchButton.Click();
            IWebElement priceFrom = browser.FindElement(By.Name("range-from-input"));
            priceFrom.SendKeys(priceF);
            IWebElement priceTo = browser.FindElement(By.Name("range-to-input"));
            priceTo.SendKeys(priceU);

            Thread.Sleep(200);
            Thread.Sleep(7000);

            IWebElement filtr = browser.FindElement(By.ClassName("css-1xqxmn3"));
            Thread.Sleep(299);
            filtr.Click();
            Thread.Sleep(200);
            Thread.Sleep(8000);

            IList<IWebElement> list = browser.FindElements(By.ClassName("css-dbu7uc"));
            try
            {
                list[filtrType].Click();

            }
            catch
            {
                list[filtrType].Click();

            }
            Thread.Sleep(100);
            Thread.Sleep(1000);

            IWebElement citySearch = browser.FindElement(By.Name("location-Field"));
            citySearch.SendKeys("Днепр");
            citySearch.Click();
            Thread.Sleep(100);
            Thread.Sleep(8000);

            IList<IWebElement> cities = browser.FindElements(By.ClassName("css-ngpp9b"));
            try
            {
                cities[0].Click();

            }
            catch
            {
                cities[0].Click();

            }

            Go(browser, objavleniya);

            return objavleniya;

        }

        public List<Objavi> Go(IWebDriver brow, List<Objavi> listik)
        {

            string page = brow.PageSource.ToString();

            string[] arr = page.Split("data-cy=\"l-card\"");
            brow.Close();
            for (int i = 1; i < arr.Length - 3; i++)
            {
                string[] arr2 = arr[i].Split(new string[] { "class", "<" }, StringSplitOptions.None);

                string sillka = "https://www.olx.ua/" + arr2[3].Split(new string[] { "\"", "\"" }, StringSplitOptions.None)[3];
                Console.WriteLine(sillka);
                string city = "";
                string price = "";




                string name = arr2[36].Split(">")[1];
                Console.WriteLine(name);
                try
                {
                    city = arr2[45].Split(">")[1];
                    Console.WriteLine(city);
                }
                catch (IndexOutOfRangeException)
                {

                }
                try
                {
                    price = arr2[39].Split(">")[1];
                    Console.WriteLine(price);
                }
                catch (IndexOutOfRangeException)
                {

                }
                listik.Add(new Objavi(name, city, price, sillka));
                Console.WriteLine("--------------------------------");
            }
            return listik;
        }


    }

}


