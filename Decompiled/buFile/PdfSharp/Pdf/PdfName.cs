using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfName : PdfItem
{
	public class PdfXNameComparer : IComparer<PdfName>
	{
		public int Compare(PdfName l, PdfName r)
		{
			if (l != null)
			{
				if (r != null)
				{
					return string.Compare(l._value, r._value, StringComparison.Ordinal);
				}
				return -1;
			}
			if (r != null)
			{
				return 1;
			}
			return 0;
		}
	}

	private readonly string _value;

	public static readonly PdfName Empty = new PdfName("/");

	public string Value => _value;

	public static PdfXNameComparer Comparer => new PdfXNameComparer();

	public PdfName()
	{
		_value = "/";
	}

	public PdfName(string value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (value.Length == 0 || value[0] != '/')
		{
			throw new ArgumentException(PSSR.NameMustStartWithSlash);
		}
		_value = value;
	}

	public override bool Equals(object obj)
	{
		return _value.Equals(obj);
	}

	public override int GetHashCode()
	{
		return _value.GetHashCode();
	}

	public override string ToString()
	{
		return _value;
	}

	public static bool operator ==(PdfName name, string str)
	{
		if ((object)name == null)
		{
			return str == null;
		}
		return name._value == str;
	}

	public static bool operator !=(PdfName name, string str)
	{
		if ((object)name == null)
		{
			return str != null;
		}
		return name._value != str;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.Write(this);
	}
}
