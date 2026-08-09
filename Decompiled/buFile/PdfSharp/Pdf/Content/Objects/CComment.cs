using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Text})")]
public class CComment : CObject
{
	private string _text;

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
		}
	}

	public new CComment Clone()
	{
		return (CComment)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}

	public override string ToString()
	{
		return "% " + _text;
	}

	internal override void WriteObject(ContentWriter writer)
	{
		writer.WriteLineRaw(ToString());
	}
}
