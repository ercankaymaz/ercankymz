using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class ReadableMessageHeader : MessageHeader
{
	public abstract XmlDictionaryReader GetHeaderReader();

	protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		if (!IsMessageVersionSupported(messageVersion))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MessageHeaderVersionNotSupported, GetType().FullName, messageVersion.ToString()), "version"));
		}
		XmlDictionaryReader headerReader = GetHeaderReader();
		writer.WriteStartElement(headerReader.Prefix, headerReader.LocalName, headerReader.NamespaceURI);
		writer.WriteAttributes(headerReader, defattr: false);
		headerReader.Dispose();
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		XmlDictionaryReader headerReader = GetHeaderReader();
		headerReader.ReadStartElement();
		while (headerReader.NodeType != XmlNodeType.EndElement)
		{
			writer.WriteNode(headerReader, defattr: false);
		}
		headerReader.ReadEndElement();
		headerReader.Dispose();
	}
}
