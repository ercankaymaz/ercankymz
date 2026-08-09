using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Value})")]
public class CInteger : CNumber
{
	private int _value;

	public int Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
		}
	}

	public new CInteger Clone()
	{
		return (CInteger)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}

	public override string ToString()
	{
		return _value.ToString(CultureInfo.InvariantCulture);
	}

	internal override void WriteObject(ContentWriter writer)
	{
		writer.WriteRaw(ToString() + " ");
	}
}
