using System.Xml;

namespace System.ServiceModel.Channels;

internal class WsrmSequenceFaultHeader : WsrmMessageHeader
{
	public WsrmFault Fault { get; }

	public override XmlDictionaryString DictionaryName => XD.WsrmFeb2005Dictionary.SequenceFault;

	public string Subcode => Fault.Subcode;

	public WsrmSequenceFaultHeader(ReliableMessagingVersion reliableMessagingVersion, WsrmFault fault)
		: base(reliableMessagingVersion)
	{
		Fault = fault;
	}

	public static XmlDictionaryReader GetReaderAtDetailContents(string detailName, string detailNamespace, XmlDictionaryReader headerReader, ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			return GetReaderAtDetailContentsFeb2005(detailName, detailNamespace, headerReader);
		}
		return GetReaderAtDetailContents11(detailName, detailNamespace, headerReader);
	}

	public static XmlDictionaryReader GetReaderAtDetailContents11(string detailName, string detailNamespace, XmlDictionaryReader headerReader)
	{
		XmlDictionaryString namespaceUri = DXD.Wsrm11Dictionary.Namespace;
		headerReader.ReadFullStartElement(XD.WsrmFeb2005Dictionary.SequenceFault, namespaceUri);
		headerReader.Skip();
		headerReader.ReadFullStartElement(XD.Message12Dictionary.FaultDetail, namespaceUri);
		if (headerReader.NodeType != XmlNodeType.Element || headerReader.NamespaceURI != detailNamespace || headerReader.LocalName != detailName)
		{
			headerReader.Close();
			return null;
		}
		return headerReader;
	}

	public static XmlDictionaryReader GetReaderAtDetailContentsFeb2005(string detailName, string detailNamespace, XmlDictionaryReader headerReader)
	{
		try
		{
			WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
			XmlDictionaryString namespaceUri = wsrmFeb2005Dictionary.Namespace;
			XmlBuffer xmlBuffer = null;
			int sectionIndex = 0;
			int depth = headerReader.Depth;
			headerReader.ReadFullStartElement(wsrmFeb2005Dictionary.SequenceFault, namespaceUri);
			while (headerReader.Depth > depth)
			{
				if (headerReader.NodeType == XmlNodeType.Element && headerReader.NamespaceURI == detailNamespace && headerReader.LocalName == detailName)
				{
					if (xmlBuffer != null)
					{
						return null;
					}
					xmlBuffer = new XmlBuffer(int.MaxValue);
					try
					{
						sectionIndex = xmlBuffer.SectionCount;
						XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(headerReader.Quotas);
						xmlDictionaryWriter.WriteNode(headerReader, defattr: false);
					}
					finally
					{
						xmlBuffer.CloseSection();
					}
				}
				else
				{
					if (headerReader.Depth == depth)
					{
						break;
					}
					headerReader.Read();
				}
			}
			if (xmlBuffer == null)
			{
				return null;
			}
			xmlBuffer.Close();
			return xmlBuffer.GetReader(sectionIndex);
		}
		finally
		{
			headerReader.Close();
		}
	}

	public static string GetSubcode(XmlDictionaryReader headerReader, ReliableMessagingVersion reliableMessagingVersion)
	{
		string localName = null;
		try
		{
			WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
			XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
			headerReader.ReadStartElement(wsrmFeb2005Dictionary.SequenceFault, namespaceUri);
			headerReader.ReadStartElement(wsrmFeb2005Dictionary.FaultCode, namespaceUri);
			XmlUtil.ReadContentAsQName(headerReader, out localName, out var ns);
			if (ns != WsrmIndex.GetNamespaceString(reliableMessagingVersion))
			{
				localName = null;
			}
			headerReader.ReadEndElement();
			while (headerReader.IsStartElement())
			{
				headerReader.Skip();
			}
			headerReader.ReadEndElement();
			return localName;
		}
		finally
		{
			headerReader.Close();
		}
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		writer.WriteStartElement("r", "FaultCode", Namespace);
		writer.WriteXmlnsAttribute(null, Namespace);
		writer.WriteQualifiedName(Subcode, Namespace);
		writer.WriteEndElement();
		bool flag = base.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11;
		if (flag)
		{
			writer.WriteStartElement("r", XD.Message12Dictionary.FaultDetail, DictionaryNamespace);
		}
		Fault.WriteDetail(writer);
		if (flag)
		{
			writer.WriteEndElement();
		}
	}
}
