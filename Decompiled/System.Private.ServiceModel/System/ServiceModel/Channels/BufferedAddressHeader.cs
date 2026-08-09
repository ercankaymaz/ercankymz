using System.Xml;

namespace System.ServiceModel.Channels;

internal class BufferedAddressHeader : AddressHeader
{
	private string _name;

	private string _ns;

	private XmlBuffer _buffer;

	public bool IsReferencePropertyHeader { get; }

	public override string Name => _name;

	public override string Namespace => _ns;

	public BufferedAddressHeader(XmlDictionaryReader reader)
	{
		_buffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter xmlDictionaryWriter = _buffer.OpenSection(reader.Quotas);
		_name = reader.LocalName;
		_ns = reader.NamespaceURI;
		xmlDictionaryWriter.WriteNode(reader, defattr: false);
		_buffer.CloseSection();
		_buffer.Close();
		IsReferencePropertyHeader = false;
	}

	public BufferedAddressHeader(XmlDictionaryReader reader, bool isReferenceProperty)
		: this(reader)
	{
		IsReferencePropertyHeader = isReferenceProperty;
	}

	public override XmlDictionaryReader GetAddressHeaderReader()
	{
		return _buffer.GetReader(0);
	}

	protected override void OnWriteStartAddressHeader(XmlDictionaryWriter writer)
	{
		XmlDictionaryReader addressHeaderReader = GetAddressHeaderReader();
		writer.WriteStartElement(addressHeaderReader.Prefix, addressHeaderReader.LocalName, addressHeaderReader.NamespaceURI);
		writer.WriteAttributes(addressHeaderReader, defattr: false);
		addressHeaderReader.Dispose();
	}

	protected override void OnWriteAddressHeaderContents(XmlDictionaryWriter writer)
	{
		XmlDictionaryReader addressHeaderReader = GetAddressHeaderReader();
		addressHeaderReader.ReadStartElement();
		while (addressHeaderReader.NodeType != XmlNodeType.EndElement)
		{
			writer.WriteNode(addressHeaderReader, defattr: false);
		}
		addressHeaderReader.ReadEndElement();
		addressHeaderReader.Dispose();
	}
}
