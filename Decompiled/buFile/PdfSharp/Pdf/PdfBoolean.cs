using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfBoolean : PdfItem
{
	private readonly bool _value;

	public static readonly PdfBoolean True = new PdfBoolean(value: true);

	public static readonly PdfBoolean False = new PdfBoolean(value: false);

	public bool Value => _value;

	public PdfBoolean()
	{
	}

	public PdfBoolean(bool value)
	{
		_value = value;
	}

	public override string ToString()
	{
		return _value ? bool.TrueString : bool.FalseString;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.Write(this);
	}
}
