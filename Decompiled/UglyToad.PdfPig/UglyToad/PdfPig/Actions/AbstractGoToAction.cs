using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Actions;

public abstract class AbstractGoToAction : PdfAction
{
	public ExplicitDestination Destination { get; }

	protected AbstractGoToAction(ActionType type, ExplicitDestination destination)
		: base(type)
	{
		Destination = destination;
	}
}
