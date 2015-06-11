using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        //instantiate the service
        FanRegistrationService.FanLoginRegistrationClient rc = new FanRegistrationService.FanLoginRegistrationClient();

        //call the method
        int id = rc.FanLogin(txtUserName.Text, txtPassword.Text);

        //check the results
        if (id != 0)
        {
            Session["id"] = id;
            Response.Redirect("Search.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid Login";
        }

    }
}