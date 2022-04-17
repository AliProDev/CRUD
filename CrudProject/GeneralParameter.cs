using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProject
{
    class GeneralParameter
    {

        #region Add_Parameter

        public class Add_Parameter
        {
            public string ProductName;
            public string UnitPrice;
            public string UnitsInStock;
            public string Discontinued;
            public string Save;
        }

        #endregion

        #region Edit_Parameter
        public class Edit_Information
        {
            public string ProductName;
            public string UnitPrice;
            public string UnitsInStock;
            public string NewProductName;
            public string NewUnitPrice;
            public string NewUnitsInStock;
            public string NewDiscontinued;
            public string Update;
        }

        #endregion

        #region Delete_Parameter
        public class Delete_Information
        {
            public string ProductName;
            public string UnitPrice;
            public string UnitsInStock;
            public string Delete;
        }

        #endregion
    }
}
