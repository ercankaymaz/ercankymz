using System.Globalization;
using System.ServiceModel;

namespace System.Xml;

internal static class XmlExceptionHelper
{
	private static void ThrowXmlException(XmlDictionaryReader reader, string res, string arg1)
	{
		ThrowXmlException(reader, res, arg1, null);
	}

	private static void ThrowXmlException(XmlDictionaryReader reader, string res, string arg1, string arg2)
	{
		ThrowXmlException(reader, res, arg1, arg2, null);
	}

	private static void ThrowXmlException(XmlDictionaryReader reader, string res, string arg1, string arg2, string arg3)
	{
		string text = System.SR.Format(res, arg1, arg2, arg3);
		if (reader is IXmlLineInfo xmlLineInfo && xmlLineInfo.HasLineInfo())
		{
			text = text + " " + System.SR.Format(System.SR.XmlLineInfo, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(text));
	}

	public static void ThrowMaxStringContentLengthExceeded(XmlDictionaryReader reader, int maxStringContentLength)
	{
		ThrowXmlException(reader, System.SR.XmlMaxStringContentLengthExceeded, maxStringContentLength.ToString(NumberFormatInfo.CurrentInfo));
	}
}
