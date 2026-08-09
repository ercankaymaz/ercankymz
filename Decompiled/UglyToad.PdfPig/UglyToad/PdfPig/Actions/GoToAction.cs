using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Actions;

public class GoToAction : AbstractGoToAction
{
	public GoToAction(ExplicitDestination destination)
		: base(ActionType.GoTo, destination)
	{
	}
}
