using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	ShowTrackerEntities db = new ShowTrackerEntities();

    public List<ShowInfo> GetShowsByVenue(string venueName){

        var shws = from s in db.Shows
                   from d in s.ShowDetails
                   where s.Venue.VenueName.Equals(venueName)
                   select new{
                       d.Artist.ArtistName,
                       s.ShowName,
                       s.ShowTime,
                       s.ShowDate,
                       s.ShowTicketInfo
                   };
        List<ShowInfo> shows = new List<ShowInfo>();

        foreach(var sh in shws){
            ShowInfo sinfo = new ShowInfo();
            sinfo.ArtistName = sh.ArtistName;
            sinfo.ShowName = sh.ShowName;
            sinfo.ShowDate = sh.ShowDate.ToShortDateString();
            sinfo.ShowTime = sh.ShowTime.ToString();
            shows.Add(sinfo);
        }
        return shows;
    }
}
