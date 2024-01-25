namespace ClassLib;

public class Trip
{
    /// <summary>
    /// Private fields of Trip class.
    /// </summary>
    private int trip_id;
    private string destination;
    private string start_date;
    private string end_date;
    private string[] travelers;
    private string accommodation;
    private string[] activities;

    // Public read only properties of fields.
    public int TripId => trip_id;

    public string Destination => destination;

    public string StartDate => start_date;

    public string EndDate => end_date;

    public string[] Travelers => travelers;

    public string Accommodation => accommodation;

    public string[] Activities => activities;

    /// <summary>
    /// Empty constructor.
    /// </summary>
    public Trip()
    {
        
    }
    
    /// <summary>
    /// Constructor of the class.
    /// </summary>
    /// <param name="tripId"></param>
    /// <param name="destination"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="travelers"></param>
    /// <param name="accommodation"></param>
    /// <param name="activities"></param>
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

    /// <summary>
    /// Indexator for Trip objects.
    /// </summary>
    /// <param name="fieldName">Index value(name of the field)</param>
    /// <exception cref="ArgumentException"></exception>
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

    /// <summary>
    /// Overrided method ToString().
    /// </summary>
    /// <returns>String</returns>
    public override string ToString()
    {
        return $"Trip ID: {TripId}\nDestination: {Destination}\nStart date: {StartDate}\nEnd date: {EndDate}\n" +
               $"Travelers: [ {string.Join(", ", Travelers)} ]\nAccommodation: {Accommodation}\n" +
               $"Activities: [ {string.Join(", ", Activities)} ]";
    }
    
    /// <summary>
    /// Method filters by field (for diff types of fields).
    /// </summary>
    /// <param name="trips">List for field</param>
    /// <param name="fieldName">Which field is being filtered</param>
    /// <param name="rev">Flag for sorting in Descending way</param>
    /// <returns>Filtered list of Trip class objects</returns>
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

    /// <summary>
    /// Method filters by field (for diff types of fields).
    /// </summary>
    /// <param name="trips">List for field</param>
    /// <param name="fieldValue">Value of field to filter buy</param>
    /// <param name="fieldName">Which field is being filtered</param>
    /// <returns>Filtered list of Trip class objects</returns>
    public static List<Trip> FilterByField(List<Trip> trips, string fieldValue, string fieldName)
    {
        if (fieldName == "travelers" || fieldName == "activities")
        {
            return trips.Where(element => ((string[]) element[fieldName]).Contains(fieldValue)).ToList();
        }

        if (fieldName == "trip_id")
        {
            return trips.Where(element => (int) element[fieldName] == int.Parse(fieldValue)).ToList();
        }
    
        return trips.Where(element => element[fieldName].Equals(fieldValue)).ToList();
    }
}