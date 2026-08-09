namespace UglyToad.PdfPig.Outline.Destinations;

public class ExplicitDestination
{
	public int PageNumber { get; }

	public ExplicitDestinationType Type { get; }

	public ExplicitDestinationCoordinates Coordinates { get; }

	public ExplicitDestination(int pageNumber, ExplicitDestinationType type, ExplicitDestinationCoordinates coordinates)
	{
		PageNumber = pageNumber;
		Type = type;
		Coordinates = coordinates;
	}
}
