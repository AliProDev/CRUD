using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CrudProject.GeneralParameter;

namespace CrudProject
{
    [Binding]
    [Scope(Tag = "CrudProject")]
    public sealed class CrudProjectStep
    {
        IWebDriver webDriver;
        CrudProjectPage Crud;

        #region Launch_Application

        [Given(@"launch application")]
        public void Launch_Application()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demos.telerik.com/kendo-ui/grid/editing-popup");
            Crud = new CrudProjectPage(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(2000);
        }
        #endregion

        #region Add_New_Record

        public class Add
        {
            public string ProductName { get; set; }
            public string UnitPrice { get; set; }
            public string UnitsInStock { get; set; }
            public string Discontinued { get; set; }
            public string Save { get; set; }
        }

        [Given(@"click add new record button and create new information")]
        public void Add_New_Record(Table table)
        {
            System.Threading.Thread.Sleep(2000);
            var info = table.CreateSet<Add>();
            foreach (Add item in info)
            {
                Add_Parameter items = new Add_Parameter()
                {
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    Discontinued = item.Discontinued,
                    Save = item.Save
                };

                Crud.Add_New_Record(items);
            }
        }

        #endregion

        #region Edit_New_Record

        public class Edit
        {
            public string ProductName { get; set; }
            public string UnitPrice { get; set; }
            public string UnitsInStock { get; set; }
            public string NewProductName { get; set; }
            public string NewUnitPrice { get; set; }
            public string NewUnitsInStock { get; set; }
            public string NewDiscontinued { get; set; }
            public string Update { get; set; }
        }

        [When(@"find new record as grid and click edit button and edit information")]
        public void Edit_New_Record(Table table)
        {
            System.Threading.Thread.Sleep(2000);
            var info = table.CreateSet<Edit>();
            foreach (Edit item in info)
            {
                Edit_Information items = new Edit_Information()
                {
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    NewProductName = item.NewProductName,
                    NewUnitPrice = item.NewUnitPrice,
                    NewUnitsInStock = item.NewUnitsInStock,
                    NewDiscontinued = item.NewDiscontinued,
                    Update = item.Update
                };

                Crud.Edit_New_Record(items);
            }
        }

        #endregion

        #region Delete_New_Record

        public class delete
        {
            public string ProductName { get; set; }
            public string UnitPrice { get; set; }
            public string UnitsInStock { get; set; }
            public string Delete { get; set; }
        }

        [Then(@"find edit record as grid and delete it")]
        public void Delete_New_Record(Table table)
        {
            System.Threading.Thread.Sleep(2000);
            var info = table.CreateSet<delete>();
            foreach (delete item in info)
            {
                Delete_Information items = new Delete_Information()
                {
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    Delete = item.Delete
                };

                Crud.Delete_New_Record(items);
            }
        }

        #endregion

    }
}
