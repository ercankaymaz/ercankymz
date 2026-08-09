using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Value})")]
public class CReal : CNumber
{
	private double _value;

	public double Value
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

	public new CReal Clone()
	{
		return (CReal)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}

	public override string ToString()
	{
		return _value.ToString("0.0#########", CultureInfo.InvariantCulture);
	}

	internal override void WriteObject(ContentWriter writer)
	{
		writer.WriteRaw(ToString() + " ");
	}
}
