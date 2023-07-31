using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ValorantWeb.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search(object sender, EventArgs e)
        {
            string url;
            DropDownList dropDown = RegionDropDown;

            url = "HomePage.aspx?region=" +
                RegionDropDown.SelectedItem.Text +
                "&inputField=" + inputField.Value;
            Response.Redirect(url);
        }
    }
}