using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CrudProject.GeneralParameter;

namespace CrudProject
{
    class CrudProjectPage
    {
        public IWebDriver WebDriver { get; }
        public CrudProjectPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        #region List Information

        public class Item
        {
            public string ProductName { get; set; }
            public string UnitPrice { get; set; }
            public string UnitsInStock { get; set; }
            public string Discontinued { get; set; }
        }

        #endregion

        #region Get_Element

        //add new record
        public IWebElement btnNewRecord => WebDriver.FindElement(By.XPath("//div[@class='k-toolbar k-grid-toolbar']/child::button"));
        public IWebElement txtProductName => WebDriver.FindElement(By.Id("ProductName"));
        public IWebElement txtUnitPrice => WebDriver.FindElement(By.Id("UnitPrice"));
        public IWebElement txtUnitsInStocke => WebDriver.FindElement(By.Id("UnitsInStock"));
        public IWebElement chkDiscontinued => WebDriver.FindElement(By.Id("Discontinued"));
        public IWebElement btnSave => WebDriver.FindElement(By.XPath("//div[@class='k-edit-buttons k-actions-end']/child::button[1]"));
        public IWebElement btnCancel => WebDriver.FindElement(By.XPath("//div[@class='k-edit-buttons k-actions-end']/child::button[2]"));
        public IList<IWebElement> gridinfo => WebDriver.FindElements(By.XPath("//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr"));

        string xpathgridinformation = "//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[{0}]/child::td[{1}]";



        #endregion

        #region Add_New_Record

        public void Add_New_Record(Add_Parameter Value)
        {
            var ListInformation = new List<Item>();

            btnNewRecord.Click();
            System.Threading.Thread.Sleep(1000);

            txtProductName.SendKeys(Value.ProductName);
            System.Threading.Thread.Sleep(500);
            txtUnitPrice.SendKeys(Value.UnitPrice);
            System.Threading.Thread.Sleep(500);
            txtUnitsInStocke.SendKeys(Value.UnitsInStock);
            System.Threading.Thread.Sleep(500);

            if (Value.Discontinued == "true")
            {
                chkDiscontinued.Click();
                System.Threading.Thread.Sleep(500);
            }

            var Result = "";

            if (Value.Save == "true")
            {
                btnSave.Click();
                System.Threading.Thread.Sleep(1000);

                for (int i = 0; i < 20; i++)
                {
                    var productname = "";
                    var unitprice = "";
                    var unitsinstock = "";
                    var discontinued = "";

                    productname = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 1))).Text;
                    unitprice = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 2))).Text;
                    unitsinstock = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 3))).Text;
                    discontinued = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 4))).Text;

                    ListInformation.Add(new Item()
                    {
                        ProductName = productname,
                        UnitPrice = unitprice,
                        UnitsInStock = unitsinstock,
                        Discontinued = discontinued
                    });

                    System.Threading.Thread.Sleep(500);
                    i++;

                }

                var j = 0;
                foreach (var item in ListInformation)
                {
                    if (item.ProductName == Value.ProductName && item.UnitPrice == Value.UnitPrice && item.UnitsInStock == Value.UnitsInStock && item.Discontinued == Value.Discontinued)
                    {
                        Console.WriteLine("The information was successfully recorded and displayed in the grid");
                        Result = "ok";
                        break;
                    }
                    j++;
                }

            }
            else
            {
                btnCancel.Click();
                System.Threading.Thread.Sleep(1000);
            }

            if (Result == null)
            {
                Console.WriteLine("Information not successfully registered");
                Assert.Fail("Information not successfully registered");
            }

        }

        #endregion

        #region Edit_New_Record

        public void Edit_New_Record(Edit_Information Value)
        {
            var ListInformation = new List<Item>();
            var result = "";
            for (int i = 0; i < 20; i++)
            {
                var productname = "";
                var unitprice = "";
                var unitsinstock = "";
                var discontinued = "";

                productname = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 1))).Text;
                unitprice = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 2))).Text;
                unitsinstock = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 3))).Text;
                discontinued = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 4))).Text;

                if (productname == Value.ProductName && unitprice == Value.UnitPrice && unitsinstock == Value.UnitsInStock)
                {
                    WebDriver.FindElement(By.XPath("//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr["+i+ "]/child::td[5]/child::button[1]")).Click();
                    System.Threading.Thread.Sleep(1000);

                    if (txtProductName.Text != null)
                    {
                        txtProductName.Clear();
                    }
                    txtProductName.SendKeys(Value.NewProductName);
                    System.Threading.Thread.Sleep(500);

                    if (txtUnitPrice.Text != null)
                    {
                        txtUnitPrice.Clear();
                    }
                    txtUnitPrice.SendKeys(Value.NewUnitPrice);
                    System.Threading.Thread.Sleep(500);

                    if (txtUnitsInStocke.Text != null)
                    {
                        txtUnitsInStocke.Clear();
                    }
                    txtUnitsInStocke.SendKeys(Value.NewUnitsInStock);
                    System.Threading.Thread.Sleep(500);

                    if (chkDiscontinued.Selected == false && Value.NewDiscontinued == "true" || chkDiscontinued.Selected == true && Value.NewDiscontinued == "false")
                    {
                        chkDiscontinued.Click();
                        System.Threading.Thread.Sleep(500);
                    }

                    if (Value.Update == "true")
                    {
                        btnSave.Click();
                        System.Threading.Thread.Sleep(1000);

                        for (int ii = 0; ii < 20; ii++)
                        {
                            var Productname = "";
                            var Unitprice = "";
                            var Unitsinstock = "";
                            var Discontinued = "";

                            Productname = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 1))).Text;
                            Unitprice = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 2))).Text;
                            Unitsinstock = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 3))).Text;
                            Discontinued = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 4))).Text;

                            ListInformation.Add(new Item()
                            {
                                ProductName = Productname,
                                UnitPrice = Unitprice,
                                UnitsInStock = Unitsinstock,
                                Discontinued = Discontinued
                            });

                            System.Threading.Thread.Sleep(500);
                            ii++;

                        }

                        var j = 0;
                        foreach (var item in ListInformation)
                        {
                            if (item.ProductName == Value.NewProductName && item.UnitPrice == Value.NewUnitPrice && item.UnitsInStock == Value.NewUnitsInStock && item.Discontinued == Value.NewDiscontinued)
                            {
                                Console.WriteLine("The information was successfully updated and displayed in the grid");
                                result = "ok";
                                break;
                            }
                            j++;
                        }

                    }
                    else
                    {
                        btnCancel.Click();
                        System.Threading.Thread.Sleep(1000);
                    }

                }

                i++;

            }

            if (result == null)
            {
                Console.WriteLine("Information not successfully updated");
                Assert.Fail("Information not successfully updated");
            }

        }

        #endregion

        #region Delete_New_Record

        public void Delete_New_Record(Delete_Information Value)
        {
            var ListInformation = new List<Item>();
            for (int i = 0; i < 20; i++)
            {
                var productname = "";
                var unitprice = "";
                var unitsinstock = "";
                var discontinued = "";

                productname = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 1))).Text;
                unitprice = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 2))).Text;
                unitsinstock = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 3))).Text;
                discontinued = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 4))).Text;

                if (productname == Value.ProductName && unitprice == Value.UnitPrice && unitsinstock == Value.UnitsInStock)
                {
                    WebDriver.FindElement(By.XPath("//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[" + i + "]/child::td[5]/child::button[2]")).Click();
                    System.Threading.Thread.Sleep(1000);

                    Actions builder = new Actions(WebDriver);

                    if (Value.Delete == "true")
                    {
                        builder.SendKeys(Keys.Enter);
                        System.Threading.Thread.Sleep(1000);

                        for (int ii = 0; ii < 20; ii++)
                        {
                            var Productname = "";
                            var Unitprice = "";
                            var Unitsinstock = "";
                            var Discontinued = "";

                            Productname = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 1))).Text;
                            Unitprice = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 2))).Text;
                            Unitsinstock = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 3))).Text;
                            Discontinued = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, ii, 4))).Text;

                            ListInformation.Add(new Item()
                            {
                                ProductName = Productname,
                                UnitPrice = Unitprice,
                                UnitsInStock = Unitsinstock,
                                Discontinued = Discontinued
                            });

                            System.Threading.Thread.Sleep(500);
                            ii++;

                        }

                        var j = 0;
                        foreach (var item in ListInformation)
                        {
                            if (item.ProductName == Value.ProductName && item.UnitPrice == Value.UnitPrice && item.UnitsInStock == Value.UnitsInStock)
                            {
                                Console.WriteLine("Deletion operation failed");
                                Assert.Fail("Deletion operation failed");
                            }
                            j++;
                        }

                        break;
                    }
                    else
                    {
                        builder.SendKeys(Keys.Escape);
                        System.Threading.Thread.Sleep(1000);
                        break;
                    }

                }

                i++;
            }


        }

        #endregion

    }
}
