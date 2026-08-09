using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf;

public sealed class PdfLiteral : PdfItem
{
	private readonly string _value = string.Empty;

	public string Value => _value;

	public PdfLiteral()
	{
	}

	public PdfLiteral(string value)
	{
		_value = value;
	}

	public PdfLiteral(string format, params object[] args)
	{
		_value = PdfEncoders.Format(format, args);
	}

	public static PdfLiteral FromMatrix(XMatrix matrix)
	{
		return new PdfLiteral("[" + PdfEncoders.ToString(matrix) + "]");
	}

	public override string ToString()
	{
		return _value;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.Write(this);
	}
}
