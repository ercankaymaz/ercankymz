using System;
using System.Text;
using System.Xml;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export;

internal static class TextExporterHelper
{
	public static Func<string, string> GetXmlInvalidCharHandler(InvalidCharStrategy invalidCharacterStrategy)
	{
		return invalidCharacterStrategy switch
		{
			InvalidCharStrategy.DoNotCheck => (string s) => s, 
			InvalidCharStrategy.Remove => delegate(string s)
			{
				if (string.IsNullOrEmpty(s))
				{
					return s;
				}
				int length = s.Length;
				StringBuilder stringBuilder = new StringBuilder(length);
				for (int i = 0; i < length; i++)
				{
					if (XmlConvert.IsXmlChar(s[i]))
					{
						stringBuilder.Append(s[i]);
					}
				}
				return stringBuilder.ToString();
			}, 
			InvalidCharStrategy.ConvertToHexadecimal => delegate(string s)
			{
				if (string.IsNullOrEmpty(s))
				{
					return s;
				}
				int length = s.Length;
				StringBuilder stringBuilder = new StringBuilder(length);
				for (int i = 0; i < length; i++)
				{
					if (XmlConvert.IsXmlChar(s[i]))
					{
						stringBuilder.Append(s[i]);
					}
					else
					{
						string value = BitConverter.ToString(Encoding.UTF8.GetBytes(s[i].ToString()));
						stringBuilder.Append("0x").Append(value);
					}
				}
				return stringBuilder.ToString();
			}, 
			_ => throw new NotImplementedException("TODO"), 
		};
	}
}
