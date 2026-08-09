using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Actions;

public class GoToRAction : AbstractGoToAction
{
	public string Filename { get; }

	public GoToRAction(ExplicitDestination destination, string filename)
		: base(ActionType.GoToR, destination)
	{
		Filename = filename;
	}
}
