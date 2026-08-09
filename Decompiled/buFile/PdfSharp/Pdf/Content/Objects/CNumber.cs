namespace PdfSharp.Pdf.Content.Objects;

public abstract class CNumber : CObject
{
	public new CNumber Clone()
	{
		return (CNumber)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}
}
