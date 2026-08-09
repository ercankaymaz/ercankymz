using System.Xml;

namespace System.ServiceModel.Channels;

internal class XmlReaderBodyWriter : BodyWriter
{
	private XmlDictionaryReader _reader;

	private bool _isFault;

	internal override bool IsFault => _isFault;

	public XmlReaderBodyWriter(XmlDictionaryReader reader, EnvelopeVersion version)
		: base(isBuffered: false)
	{
		_reader = reader;
		if (reader.MoveToContent() != XmlNodeType.Element)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.InvalidReaderPositionOnCreateMessage, "reader"));
		}
		_isFault = Message.IsFaultStartElement(reader, version);
	}

	protected override BodyWriter OnCreateBufferedCopy(int maxBufferSize)
	{
		return OnCreateBufferedCopy(maxBufferSize, _reader.Quotas);
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		using (_reader)
		{
			XmlNodeType xmlNodeType = _reader.MoveToContent();
			while (!_reader.EOF)
			{
				switch (xmlNodeType)
				{
				default:
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.InvalidReaderPositionOnCreateMessage, "reader"));
				case XmlNodeType.Element:
					break;
				case XmlNodeType.EndElement:
					return;
				}
				writer.WriteNode(_reader, defattr: false);
				xmlNodeType = _reader.MoveToContent();
			}
		}
	}
}
