using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("(count={Count})")]
public class CArray : CSequence
{
	public new CArray Clone()
	{
		return (CArray)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}

	public override string ToString()
	{
		return "[" + base.ToString() + "]";
	}

	internal override void WriteObject(ContentWriter writer)
	{
		writer.WriteRaw(ToString());
	}
}
