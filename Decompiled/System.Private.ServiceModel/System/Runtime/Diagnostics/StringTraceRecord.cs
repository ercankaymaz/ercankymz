using System.Xml;

namespace System.Runtime.Diagnostics;

internal class StringTraceRecord : TraceRecord
{
	private string _elementName;

	private string _content;

	internal override string EventId => BuildEventId("String");

	internal StringTraceRecord(string elementName, string content)
	{
		_elementName = elementName;
		_content = content;
	}

	internal override void WriteTo(XmlWriter writer)
	{
		writer.WriteElementString(_elementName, _content);
	}
}
