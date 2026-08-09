using System;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfDate : PdfItem
{
	private DateTime _value;

	public DateTime Value => _value;

	public PdfDate()
	{
	}

	public PdfDate(string value)
	{
		_value = Parser.ParseDateTime(value, DateTime.MinValue);
	}

	public PdfDate(DateTime value)
	{
		_value = value;
	}

	public override string ToString()
	{
		string arg = _value.ToString("zzz").Replace(':', '\'');
		return $"D:{_value:yyyyMMddHHmmss}{arg}'";
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.WriteDocString(ToString());
	}
}
