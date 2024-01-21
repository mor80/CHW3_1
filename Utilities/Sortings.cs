using ClassLib;


namespace Utilities;

public class Sortings
{
    public static List<Trip> Sorting(List<Trip> trips, string fieldName, bool rev = false)
    {
        if (fieldName == "travelers" || fieldName == "activities")
        {
            return rev
                ? trips.OrderByDescending(element => ((string[]) element[fieldName]).Length).ToList()
                : trips.OrderBy(element => ((string[]) element[fieldName]).Length).ToList();
        }
        
        return rev
            ? trips.OrderByDescending(element => element[fieldName]).ToList()
            : trips.OrderBy(element => element[fieldName]).ToList();
    }
    
    public static List<Trip> FilterByField(List<Trip> trips, string field, string fieldName)
    {
        if (fieldName == "travelers" || fieldName == "activities")
        {
            return trips.Where(element => element[fieldName].Equals(field)).ToList();
        }
        
        return trips.Where(element => element[fieldName].Equals(field)).ToList();
    }
}