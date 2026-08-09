using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Actions;

public class GoToEAction : AbstractGoToAction
{
	public string FileSpecification { get; }

	public GoToEAction(ExplicitDestination destination, string fileSpecification)
		: base(ActionType.GoToE, destination)
	{
		FileSpecification = fileSpecification;
	}
}
