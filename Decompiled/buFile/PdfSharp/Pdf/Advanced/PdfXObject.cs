namespace PdfSharp.Pdf.Advanced;

public abstract class PdfXObject : PdfDictionary
{
	public class Keys : PdfStream.Keys
	{
	}

	protected PdfXObject(PdfDocument document)
		: base(document)
	{
	}
}
