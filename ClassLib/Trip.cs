namespace ClassLib;

public class Trip
{
    private int trip_id;
    private string destination;
    private string start_date;
    private string end_date;
    private string[] travelers;
    private string accommodation;
    private string[] activities;

    public int TripId => trip_id;

    public string Destination => destination;

    public string StartDate => start_date;

    public string EndDate => end_date;

    public string[] Travelers => travelers;

    public string Accommodation => accommodation;

    public string[] Activities => activities;

    public Trip()
    {
        
    }
    
    public Trip(int tripId, string destination, string startDate, string endDate, string[] travelers,
        string accommodation, string[] activities)
    {
        trip_id = tripId;
        this.destination = destination;
        start_date = startDate;
        end_date = endDate;
        this.travelers = travelers;
        this.accommodation = accommodation;
        this.activities = activities;
    }

    public object this[string fieldName]
    {
        get
        {
            switch (fieldName)
            {
                case "trip_id":
                    return TripId;
                case "destination":
                    return Destination;
                case "start_date":
                    return StartDate;
                case "end_date":
                    return EndDate;
                case "travelers":
                    return Travelers;
                case "accommodation":
                    return Accommodation;
                case "activities":
                    return Activities;
                default:
                    throw new ArgumentException($"Invalid field name: {fieldName}");
            }
        }
    }

    public override string ToString()
    {
        return $"Trip ID: {TripId}\nDestination: {Destination}\nStart date: {StartDate}\nEnd date: {EndDate}\n" +
               $"Travelers: [\n";
    }
    
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

    public static List<Trip> FilterByField(List<Trip> trips, string fieldValue, string fieldName)
    {
        if (fieldName == "travelers" || fieldName == "activities")
        {
            return trips.Where(element => ((string[]) element[fieldName]).Contains(fieldValue)).ToList();
        }
    
        return trips.Where(element => element[fieldName].Equals(fieldValue)).ToList();
    }
}