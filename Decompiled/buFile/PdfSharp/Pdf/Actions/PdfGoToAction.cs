namespace PdfSharp.Pdf.Actions;

public sealed class PdfGoToAction : PdfAction
{
	internal new class Keys : PdfAction.Keys
	{
		[KeyInfo(KeyType.Rectangle | KeyType.Array | KeyType.Required)]
		public const string D = "/D";
	}

	public PdfGoToAction()
	{
		Inititalize();
	}

	public PdfGoToAction(PdfDocument document)
		: base(document)
	{
		Inititalize();
	}

	private void Inititalize()
	{
		base.Elements.SetName("/Type", "/Action");
		base.Elements.SetName("/S", "/Goto");
	}
}
