using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfBooleanObject : PdfObject
{
	private readonly bool _value;

	public bool Value => _value;

	public PdfBooleanObject()
	{
	}

	public PdfBooleanObject(bool value)
	{
		_value = value;
	}

	public PdfBooleanObject(PdfDocument document, bool value)
		: base(document)
	{
		_value = value;
	}

	public override string ToString()
	{
		return _value ? bool.TrueString : bool.FalseString;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.WriteBeginObject(this);
		writer.Write(_value);
		writer.WriteEndObject();
	}
}
