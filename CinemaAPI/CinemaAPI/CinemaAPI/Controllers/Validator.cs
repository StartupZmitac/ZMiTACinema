using System.Globalization;
using System.Net;

namespace CinemaAPI.Controllers;

public class Validator
{

    
    public static DateTime getCurrentTime()
    {
        try{
            using (var response = 
                   WebRequest.Create("http://www.google.com").GetResponse())
                return DateTime.ParseExact(response.Headers["date"],
                    "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                    CultureInfo.InvariantCulture.DateTimeFormat,
                    DateTimeStyles.AssumeUniversal);
        }
        catch (WebException)
        {
            return DateTime.Now; //In case something goes wrong. 
        }
    }


    public bool checkTime(DateTime fromFront)
    {
        if (DateTime.Compare(getCurrentTime(), fromFront) <= 0)
            return true;
        return false;
    }



}