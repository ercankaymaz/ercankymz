namespace UglyToad.PdfPig.Actions;

public class PdfAction
{
	public ActionType Type { get; }

	protected PdfAction(ActionType type)
	{
		Type = type;
	}
}
