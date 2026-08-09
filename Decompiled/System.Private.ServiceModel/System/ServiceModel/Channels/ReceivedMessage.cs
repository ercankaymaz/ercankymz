using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class ReceivedMessage : Message
{
	private bool _isFault;

	private bool _isEmpty;

	public override bool IsEmpty => _isEmpty;

	public override bool IsFault => _isFault;

	protected static bool HasHeaderElement(XmlDictionaryReader reader, EnvelopeVersion envelopeVersion)
	{
		return reader.IsStartElement(XD.MessageDictionary.Header, envelopeVersion.DictionaryNamespace);
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		if (_isEmpty)
		{
			return;
		}
		using XmlDictionaryReader xmlDictionaryReader = OnGetReaderAtBodyContents();
		if (xmlDictionaryReader.ReadState == ReadState.Error || xmlDictionaryReader.ReadState == ReadState.Closed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.MessageBodyReaderInvalidReadState, xmlDictionaryReader.ReadState.ToString())));
		}
		while (xmlDictionaryReader.NodeType != XmlNodeType.EndElement && !xmlDictionaryReader.EOF)
		{
			writer.WriteNode(xmlDictionaryReader, defattr: false);
		}
		ReadFromBodyContentsToEnd(xmlDictionaryReader);
	}

	protected bool ReadStartBody(XmlDictionaryReader reader)
	{
		return Message.ReadStartBody(reader, Version.Envelope, out _isFault, out _isEmpty);
	}

	protected static EnvelopeVersion ReadStartEnvelope(XmlDictionaryReader reader)
	{
		EnvelopeVersion result;
		if (reader.IsStartElement(XD.MessageDictionary.Envelope, XD.Message12Dictionary.Namespace))
		{
			result = EnvelopeVersion.Soap12;
		}
		else
		{
			if (!reader.IsStartElement(XD.MessageDictionary.Envelope, XD.Message11Dictionary.Namespace))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.MessageVersionUnknown));
			}
			result = EnvelopeVersion.Soap11;
		}
		if (reader.IsEmptyElement)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.MessageBodyMissing));
		}
		reader.Read();
		return result;
	}

	protected static void VerifyStartBody(XmlDictionaryReader reader, EnvelopeVersion version)
	{
		if (!reader.IsStartElement(XD.MessageDictionary.Body, version.DictionaryNamespace))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.MessageBodyMissing));
		}
	}
}
