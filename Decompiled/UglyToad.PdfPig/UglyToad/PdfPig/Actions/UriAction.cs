namespace UglyToad.PdfPig.Actions;

public class UriAction : PdfAction
{
	public string Uri { get; }

	public UriAction(string uri)
		: base(ActionType.URI)
	{
		Uri = uri;
	}
}
