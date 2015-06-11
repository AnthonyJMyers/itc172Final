using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueLoginRegistrationService" in code, svc and config file together.
public class FanLoginRegistration : IFanLoginRegistration
{
    ShowTrackerEntities db = new ShowTrackerEntities();
    public bool RegisterFan(Fan f, FanLogin fl)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            KeyCode kc = new KeyCode();
            int code = kc.GetKeyCode();
            byte[] hashed = ph.HashIt(fl.FanLoginPasswordPlain, code.ToString());

            Fan fan = new Fan();
            fan.FanName = f.FanName;
            fan.FanEmail = f.FanEmail;
            fan.FanDateEntered = DateTime.Now;
            //fan.FanLogins = f.FanLogins;
            //fan.FanKey = f.FanKey;



            FanLogin fanl = new FanLogin();
            fanl.Fan = fan;
            fanl.FanLoginDateAdded = DateTime.Now;
            fanl.FanLoginHashed = hashed;
            fanl.FanLoginPasswordPlain = fl.FanLoginPasswordPlain;
            fanl.FanLoginUserName = fl.FanLoginUserName;
            fanl.FanLoginRandom = code;
            fanl.FanKey = fl.FanKey;

            db.Fans.Add(fan);
            db.FanLogins.Add(fanl);
            db.SaveChanges();


        }
        catch
        {
            result = false;
        }
        return result;
    }

    public int FanLogin(string userName, string Password)
    {
        int id = 0;

        LoginClass lc = new LoginClass(Password, userName);
        id = lc.ValidateLogin();

        return id;
    }
}

