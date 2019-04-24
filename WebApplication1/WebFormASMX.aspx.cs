using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebApplication1
{
    public partial class WebFormASMX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_FilterCheckListItemsRequested(object sender, Telerik.Web.UI.GridFilterCheckListItemsRequestedEventArgs e)
        {
            MyASMXService service = new MyASMXService();
            var y = service.GetCustomers();
            if (e.Column is IGridDataColumn)
            {
                string dataField = (e.Column as IGridDataColumn).GetActiveDataField();
                List<GridDataItem> list = new List<GridDataItem>();
                switch (dataField)
                {
                    case "CustomerID":
                        e.ListBox.DataSource = y.Data.Select(x => new { text = x.CustomerID == "\0" ? "(blank)" : x.CustomerID, value = x.CustomerID }).Distinct().OrderBy(x => x.text);
                        break;
                    case "CompanyName":
                        e.ListBox.DataSource = y.Data.Select(x => new { text = x.CompanyName == "\0" ? "(blank)" : x.CompanyName, value = x.CompanyName }).Distinct().OrderBy(x => x.text);
                        break;
                    case "GrowMeth":
                        e.ListBox.DataSource = y.Data.Select(x => new { text = x.ContactName == "\0" ? "(blank)" : x.ContactName, value = x.ContactName }).Distinct().OrderBy(x => x.text);
                        break;
                    case "TypeCode":
                        e.ListBox.DataSource = y.Data.Select(x => new { text = x.ContactTitle == "\0" ? "(blank)" : x.ContactTitle, value = x.ContactTitle }).Distinct().OrderBy(x => x.text);
                        break;
                }
                e.ListBox.DataTextField = "text";
                e.ListBox.DataValueField = "value";
                e.ListBox.DataBind();
            }
        }
    }
}