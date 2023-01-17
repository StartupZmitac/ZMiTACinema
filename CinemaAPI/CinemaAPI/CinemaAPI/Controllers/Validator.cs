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

    public bool checkColumnRowOutOfRange(string toCheck, int column, int row) //WARNING: BECAUSE OF BROKEN IDEXES, METHOD MIGHT NOT WORK PROPERLY
    {
        //string temp = toCheck.Replace("C", ",");
        //temp = temp.Replace("R", ",");
        //temp = temp.Remove(temp.Length - 1); idk how Split works
        Char[] delimiters = {'C', 'R'};
        string[] values = toCheck.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        if (int.Parse(values[0]) > row || int.Parse(values[1]) > column) //TODO: Check if method works with different columns and rows from ticket
            return false;
        return true;
    }
    


}