using System;
using System.Diagnostics;
using System.Text;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Value})")]
public class CString : CObject
{
	private string _value;

	private CStringType _cStringType;

	public string Value
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

	public CStringType CStringType
	{
		get
		{
			return _cStringType;
		}
		set
		{
			_cStringType = value;
		}
	}

	public new CString Clone()
	{
		return (CString)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		switch (CStringType)
		{
		case CStringType.String:
		{
			stringBuilder.Append("(");
			int length = _value.Length;
			for (int i = 0; i < length; i++)
			{
				char c = _value[i];
				switch (c)
				{
				case '\n':
					stringBuilder.Append("\\n");
					break;
				case '\r':
					stringBuilder.Append("\\r");
					break;
				case '\t':
					stringBuilder.Append("\\t");
					break;
				case '\b':
					stringBuilder.Append("\\b");
					break;
				case '\f':
					stringBuilder.Append("\\f");
					break;
				case '(':
					stringBuilder.Append("\\(");
					break;
				case ')':
					stringBuilder.Append("\\)");
					break;
				case '\\':
					stringBuilder.Append("\\\\");
					break;
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			stringBuilder.Append(')');
			break;
		}
		case CStringType.HexString:
			throw new NotImplementedException();
		case CStringType.UnicodeString:
			throw new NotImplementedException();
		case CStringType.UnicodeHexString:
			throw new NotImplementedException();
		case CStringType.Dictionary:
			stringBuilder.Append(_value);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return stringBuilder.ToString();
	}

	internal override void WriteObject(ContentWriter writer)
	{
		writer.WriteRaw(ToString());
	}
}
