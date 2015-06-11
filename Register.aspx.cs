using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //instantiate service
        FanRegistrationService.FanLoginRegistrationClient rc = new FanRegistrationService.FanLoginRegistrationClient();


        //create an instance of the venue class from our data Contract
        FanRegistrationService.Fan fan = new FanRegistrationService.Fan();
        FanRegistrationService.FanLogin fanlog = new FanRegistrationService.FanLogin();

        //assign text box content to the venue properties
        fan.FanName = txtFanName.Text;
        fan.FanEmail = txtFanEmail.Text;
        fan.FanDateEntered = DateTime.Now;
        

        fanlog.FanLoginUserName = txtUserName.Text;
        fanlog.FanLoginPasswordPlain = txtConfirm.Text;

        //call the register method in the service
        bool result = rc.RegisterFan(fan, fanlog);
        //check the results
        if (result)
        {
            lblResult.Text = "You have successfully registered";
        }
        else
        {
            lblResult.Text = "Registration failed";
        }


    }
}