using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{

    ShowLookupService.ServiceClient showLook = new ShowLookupService.ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ShowLookupService.ShowInfo[] shows = showLook.GetShowsByVenue(showSearch.Text);
        GridView1.DataSource = shows;
        GridView1.DataBind();
    }
}