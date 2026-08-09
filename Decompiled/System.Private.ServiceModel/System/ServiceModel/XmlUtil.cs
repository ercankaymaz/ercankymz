using System.Globalization;
using System.Xml;

namespace System.ServiceModel;

internal static class XmlUtil
{
	public const string XmlNs = "http://www.w3.org/XML/1998/namespace";

	public const string XmlNsNs = "http://www.w3.org/2000/xmlns/";

	public const string XmlSerializerSchemaInstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";

	public const string XmlSerializerSchemaNamespace = "http://www.w3.org/2001/XMLSchema";

	public static string GetXmlLangAttribute(XmlReader reader)
	{
		string text = null;
		if (reader.MoveToAttribute("lang", "http://www.w3.org/XML/1998/namespace"))
		{
			text = reader.Value;
			reader.MoveToElement();
		}
		if (text == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.XmlLangAttributeMissing));
		}
		return text;
	}

	public static bool IsTrue(string booleanValue)
	{
		if (string.IsNullOrEmpty(booleanValue))
		{
			return false;
		}
		return XmlConvert.ToBoolean(booleanValue);
	}

	public static void ReadContentAsQName(XmlReader reader, out string localName, out string ns)
	{
		ParseQName(reader, reader.ReadContentAsString(), out localName, out ns);
	}

	public static bool IsWhitespace(char ch)
	{
		if (ch != ' ' && ch != '\t' && ch != '\r')
		{
			return ch == '\n';
		}
		return true;
	}

	public static string TrimEnd(string s)
	{
		int num = s.Length;
		while (num > 0 && IsWhitespace(s[num - 1]))
		{
			num--;
		}
		if (num != s.Length)
		{
			return s.Substring(0, num);
		}
		return s;
	}

	public static string TrimStart(string s)
	{
		int i;
		for (i = 0; i < s.Length && IsWhitespace(s[i]); i++)
		{
		}
		if (i != 0)
		{
			return s.Substring(i);
		}
		return s;
	}

	public static string Trim(string s)
	{
		int i;
		for (i = 0; i < s.Length && IsWhitespace(s[i]); i++)
		{
		}
		if (i >= s.Length)
		{
			return string.Empty;
		}
		int num = s.Length;
		while (num > 0 && IsWhitespace(s[num - 1]))
		{
			num--;
		}
		if (i != 0 || num != s.Length)
		{
			return s.Substring(i, num - i);
		}
		return s;
	}

	public static void ParseQName(XmlReader reader, string qname, out string localName, out string ns)
	{
		int num = qname.IndexOf(':');
		string prefix;
		if (num < 0)
		{
			prefix = "";
			localName = TrimStart(TrimEnd(qname));
		}
		else
		{
			if (num == qname.Length - 1)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.InvalidXmlQualifiedName, qname)));
			}
			prefix = TrimStart(qname.Substring(0, num));
			localName = TrimEnd(qname.Substring(num + 1));
		}
		ns = reader.LookupNamespace(prefix);
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnboundPrefixInQName, qname)));
		}
	}

	public static DateTime ReadElementContentAsDateTime(this XmlDictionaryReader reader)
	{
		DateTime result;
		if (reader.IsStartElement() && reader.IsEmptyElement)
		{
			reader.Read();
			try
			{
				result = DateTime.Parse(string.Empty, NumberFormatInfo.InvariantInfo);
			}
			catch (ArgumentException innerException)
			{
				throw new XmlException(System.SR.Format(System.SR.XmlInvalidConversion, string.Empty, "DateTime"), innerException);
			}
			catch (FormatException innerException2)
			{
				throw new XmlException(System.SR.Format(System.SR.XmlInvalidConversion, string.Empty, "DateTime"), innerException2);
			}
		}
		else
		{
			reader.ReadStartElement();
			result = reader.ReadContentAsDateTimeOffset().DateTime;
			reader.ReadEndElement();
		}
		return result;
	}
}
