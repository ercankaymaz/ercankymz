using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal class EndpointAddressProcessor
{
	internal class Attr : IComparable<Attr>
	{
		internal string local;

		internal string ns;

		internal string val;

		private string _key;

		internal Attr(string l, string ns, string v)
		{
			local = l;
			this.ns = ns;
			val = v;
			_key = ns + ":" + l;
		}

		public int CompareTo(Attr a)
		{
			return string.Compare(_key, a._key, StringComparison.Ordinal);
		}
	}

	internal static readonly string XsiNs = "http://www.w3.org/2001/XMLSchema-instance";

	internal const string SerNs = "http://schemas.microsoft.com/2003/10/Serialization/";

	internal const string TypeLN = "type";

	internal const string ItemTypeLN = "ItemType";

	internal const string FactoryTypeLN = "FactoryType";

	internal static string GetComparableForm(StringBuilder builder, XmlReader reader)
	{
		List<Attr> list = new List<Attr>();
		int num = -1;
		while (!reader.EOF)
		{
			switch (reader.MoveToContent())
			{
			case XmlNodeType.Element:
				CompleteValue(builder, num);
				num = -1;
				builder.Append("<");
				AppendString(builder, reader.LocalName);
				builder.Append(":");
				AppendString(builder, reader.NamespaceURI);
				builder.Append(" ");
				list.Clear();
				if (reader.MoveToFirstAttribute())
				{
					do
					{
						if (!(reader.Prefix == "xmlns") && !(reader.Name == "xmlns") && (!(reader.LocalName == "IsReferenceParameter") || !(reader.NamespaceURI == "http://www.w3.org/2005/08/addressing")))
						{
							string text = reader.Value;
							if ((reader.LocalName == "type" && reader.NamespaceURI == XsiNs) || (reader.NamespaceURI == "http://schemas.microsoft.com/2003/10/Serialization/" && (reader.LocalName == "ItemType" || reader.LocalName == "FactoryType")))
							{
								XmlUtil.ParseQName(reader, text, out var localName, out var ns);
								text = localName + "^" + localName.Length.ToString(CultureInfo.InvariantCulture) + ":" + ns + "^" + ns.Length.ToString(CultureInfo.InvariantCulture);
							}
							else if (reader.LocalName == XD.UtilityDictionary.IdAttribute.Value && reader.NamespaceURI == XD.UtilityDictionary.Namespace.Value)
							{
								continue;
							}
							list.Add(new Attr(reader.LocalName, reader.NamespaceURI, text));
						}
					}
					while (reader.MoveToNextAttribute());
				}
				reader.MoveToElement();
				if (list.Count > 0)
				{
					list.Sort();
					for (int i = 0; i < list.Count; i++)
					{
						Attr attr = list[i];
						AppendString(builder, attr.local);
						builder.Append(":");
						AppendString(builder, attr.ns);
						builder.Append("=\"");
						AppendString(builder, attr.val);
						builder.Append("\" ");
					}
				}
				if (reader.IsEmptyElement)
				{
					builder.Append("></>");
				}
				else
				{
					builder.Append(">");
				}
				break;
			case XmlNodeType.EndElement:
				CompleteValue(builder, num);
				num = -1;
				builder.Append("</>");
				break;
			case XmlNodeType.CDATA:
				CompleteValue(builder, num);
				num = -1;
				builder.Append("<![CDATA[");
				AppendString(builder, reader.Value);
				builder.Append("]]>");
				break;
			case XmlNodeType.Text:
			case XmlNodeType.SignificantWhitespace:
				if (num < 0)
				{
					num = builder.Length;
				}
				builder.Append(reader.Value);
				break;
			}
			reader.Read();
		}
		return builder.ToString();
	}

	private static void AppendString(StringBuilder builder, string s)
	{
		builder.Append(s);
		builder.Append("^");
		builder.Append(s.Length.ToString(CultureInfo.InvariantCulture));
	}

	private static void CompleteValue(StringBuilder builder, int startLength)
	{
		if (startLength >= 0)
		{
			int num = builder.Length - startLength;
			builder.Append("^");
			builder.Append(num.ToString(CultureInfo.InvariantCulture));
		}
	}
}
