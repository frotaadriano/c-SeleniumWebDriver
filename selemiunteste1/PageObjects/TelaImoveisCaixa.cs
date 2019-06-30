using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace selemiunteste1.PageObjects
{
    public class TelaImoveisCaixa
    {
        private IWebDriver driver { get; set; }

        public string URL { get; set; }

        public TelaImoveisCaixa()
        {
            driver = new ChromeDriver(@"C:\SeleliunWebDriverChrome v75");
        }


        //public IWebDriver CarregaDriver()
        //{
        //    IWebDriver driver = new ChromeDriver(@"C:\SeleliunWebDriverChrome v75");
        //    return driver;
        //}

        public void SelecionaComboEstado()
        {
            this.URL = "https://www1.caixa.gov.br/Simov/busca-imovel.asp?sltTipoBusca=imoveis";

            LoadURL(driver, URL);


            driver.FindElement(By.Id("cmb_estado")).Click();
            var el = driver.FindElement(By.Id("cmb_estado"));
            el.SendKeys("RJ");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            // driver.Quit();
        }


        public void SelecionaComboCidade(string cidade = "SAO GONCALO")
        {
            driver.FindElement(By.Id("cmb_cidade")).Click();
            //var el = driver.FindElement(By.Id("cmb_cidade"));
            //el.SendKeys(cidade);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var el = wait.Until(drv => drv.FindElement(By.Id("cmb_cidade")));

            var elemento = new SelectElement(el);
            elemento.SelectByText(cidade);

            //el.SendKeys(cidade);
        }

        public void SelecionarBairros(List<string> bairros = null)
        {
            var selectElements = driver.FindElements(By.Id("cmb_bairro"));
            selectElements[0].Click();
            selectElements[1].Click();
            selectElements[2].Click();

            var b = selectElements.ToList();

            //Debug.Print(b);

            foreach (var item in selectElements)
            {
                //Debug.Print(item.Text.ToString());
                item.Click(); 
            }

            //proximo
            driver.FindElement(By.Id("btn_next0")).Click();

        }



        private static void LoadURL(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }


    }
}
