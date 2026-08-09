using System.Diagnostics;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfReal : PdfNumber
{
	private readonly double _value;

	public double Value => _value;

	public PdfReal()
	{
	}

	public PdfReal(double value)
	{
		_value = value;
	}

	public override string ToString()
	{
		return _value.ToString("0.###", CultureInfo.InvariantCulture);
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.Write(this);
	}
}
