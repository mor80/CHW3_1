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

    public Trip(int tripId, string destination, string startDate, string endDate, string[] travelers, string accommodation, string[] activities)
    {
        trip_id = tripId;
        this.destination = destination;
        start_date = startDate;
        end_date = endDate;
        this.travelers = travelers;
        this.accommodation = accommodation;
        this.activities = activities;
    }
}