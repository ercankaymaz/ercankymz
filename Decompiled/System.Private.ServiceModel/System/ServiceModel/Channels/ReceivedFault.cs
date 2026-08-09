using System.Collections.Generic;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class ReceivedFault : MessageFault
{
	private FaultCode _code;

	private FaultReason _reason;

	private string _actor;

	private string _node;

	private XmlBuffer _detail;

	private bool _hasDetail;

	private EnvelopeVersion _receivedVersion;

	public override string Actor => _actor;

	public override FaultCode Code => _code;

	public override bool HasDetail => _hasDetail;

	public override string Node => _node;

	public override FaultReason Reason => _reason;

	private ReceivedFault(FaultCode code, FaultReason reason, string actor, string node, XmlBuffer detail, EnvelopeVersion version)
	{
		_code = code;
		_reason = reason;
		_actor = actor;
		_node = node;
		_receivedVersion = version;
		_hasDetail = InferHasDetail(detail);
		_detail = (_hasDetail ? detail : null);
	}

	private bool InferHasDetail(XmlBuffer detail)
	{
		bool result = false;
		if (detail != null)
		{
			XmlDictionaryReader reader = detail.GetReader(0);
			if (!reader.IsEmptyElement && reader.Read())
			{
				result = reader.MoveToContent() != XmlNodeType.EndElement;
			}
			reader.Dispose();
		}
		return result;
	}

	protected override void OnWriteDetail(XmlDictionaryWriter writer, EnvelopeVersion version)
	{
		using XmlReader xmlReader = _detail.GetReader(0);
		base.OnWriteStartDetail(writer, version);
		while (xmlReader.MoveToNextAttribute())
		{
			if (ShouldWriteDetailAttribute(version, xmlReader.Prefix, xmlReader.LocalName, xmlReader.Value))
			{
				writer.WriteAttributeString(xmlReader.Prefix, xmlReader.LocalName, xmlReader.NamespaceURI, xmlReader.Value);
			}
		}
		xmlReader.MoveToElement();
		xmlReader.Read();
		while (xmlReader.NodeType != XmlNodeType.EndElement)
		{
			writer.WriteNode(xmlReader, defattr: false);
		}
		writer.WriteEndElement();
	}

	protected override void OnWriteStartDetail(XmlDictionaryWriter writer, EnvelopeVersion version)
	{
		using XmlReader xmlReader = _detail.GetReader(0);
		base.OnWriteStartDetail(writer, version);
		while (xmlReader.MoveToNextAttribute())
		{
			if (ShouldWriteDetailAttribute(version, xmlReader.Prefix, xmlReader.LocalName, xmlReader.Value))
			{
				writer.WriteAttributeString(xmlReader.Prefix, xmlReader.LocalName, xmlReader.NamespaceURI, xmlReader.Value);
			}
		}
	}

	protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
	{
		using XmlReader xmlReader = _detail.GetReader(0);
		xmlReader.Read();
		while (xmlReader.NodeType != XmlNodeType.EndElement)
		{
			writer.WriteNode(xmlReader, defattr: false);
		}
	}

	protected override XmlDictionaryReader OnGetReaderAtDetailContents()
	{
		XmlDictionaryReader reader = _detail.GetReader(0);
		reader.Read();
		return reader;
	}

	private bool ShouldWriteDetailAttribute(EnvelopeVersion targetVersion, string prefix, string localName, string attributeValue)
	{
		bool flag = _receivedVersion == EnvelopeVersion.Soap12 && targetVersion == EnvelopeVersion.Soap11 && string.IsNullOrEmpty(prefix) && localName == "xmlns" && attributeValue == XD.Message12Dictionary.Namespace.Value;
		return !flag;
	}

	public static ReceivedFault CreateFaultNone(XmlDictionaryReader reader, int maxBufferSize)
	{
		return CreateFault12Driver(reader, maxBufferSize, EnvelopeVersion.None);
	}

	private static ReceivedFault CreateFault12Driver(XmlDictionaryReader reader, int maxBufferSize, EnvelopeVersion version)
	{
		reader.ReadStartElement(XD.MessageDictionary.Fault, version.DictionaryNamespace);
		reader.ReadStartElement(XD.Message12Dictionary.FaultCode, version.DictionaryNamespace);
		FaultCode code = ReadFaultCode12Driver(reader, version);
		reader.ReadEndElement();
		List<FaultReasonText> list = new List<FaultReasonText>();
		if (reader.IsEmptyElement)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(System.SR.AtLeastOneFaultReasonMustBeSpecified));
		}
		reader.ReadStartElement(XD.Message12Dictionary.FaultReason, version.DictionaryNamespace);
		while (reader.IsStartElement(XD.Message12Dictionary.FaultText, version.DictionaryNamespace))
		{
			list.Add(ReadTranslation12(reader));
		}
		reader.ReadEndElement();
		string actor = "";
		string node = "";
		if (reader.IsStartElement(XD.Message12Dictionary.FaultNode, version.DictionaryNamespace))
		{
			node = reader.ReadElementContentAsString();
		}
		if (reader.IsStartElement(XD.Message12Dictionary.FaultRole, version.DictionaryNamespace))
		{
			actor = reader.ReadElementContentAsString();
		}
		XmlBuffer xmlBuffer = null;
		if (reader.IsStartElement(XD.Message12Dictionary.FaultDetail, version.DictionaryNamespace))
		{
			xmlBuffer = new XmlBuffer(maxBufferSize);
			XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(reader.Quotas);
			xmlDictionaryWriter.WriteNode(reader, defattr: false);
			xmlBuffer.CloseSection();
			xmlBuffer.Close();
		}
		reader.ReadEndElement();
		FaultReason reason = new FaultReason(list);
		return new ReceivedFault(code, reason, actor, node, xmlBuffer, version);
	}

	private static FaultCode ReadFaultCode12Driver(XmlDictionaryReader reader, EnvelopeVersion version)
	{
		FaultCode faultCode = null;
		reader.ReadStartElement(XD.Message12Dictionary.FaultValue, version.DictionaryNamespace);
		XmlUtil.ReadContentAsQName(reader, out var localName, out var ns);
		reader.ReadEndElement();
		if (reader.IsStartElement(XD.Message12Dictionary.FaultSubcode, version.DictionaryNamespace))
		{
			reader.ReadStartElement();
			faultCode = ReadFaultCode12Driver(reader, version);
			reader.ReadEndElement();
			return new FaultCode(localName, ns, faultCode);
		}
		return new FaultCode(localName, ns);
	}

	public static ReceivedFault CreateFault12(XmlDictionaryReader reader, int maxBufferSize)
	{
		return CreateFault12Driver(reader, maxBufferSize, EnvelopeVersion.Soap12);
	}

	private static FaultReasonText ReadTranslation12(XmlDictionaryReader reader)
	{
		string xmlLangAttribute = XmlUtil.GetXmlLangAttribute(reader);
		string text = reader.ReadElementContentAsString();
		return new FaultReasonText(text, xmlLangAttribute);
	}

	public static ReceivedFault CreateFault11(XmlDictionaryReader reader, int maxBufferSize)
	{
		reader.ReadStartElement(XD.MessageDictionary.Fault, XD.Message11Dictionary.Namespace);
		reader.ReadStartElement(XD.Message11Dictionary.FaultCode, XD.Message11Dictionary.FaultNamespace);
		XmlUtil.ReadContentAsQName(reader, out var localName, out var ns);
		FaultCode code = new FaultCode(localName, ns);
		reader.ReadEndElement();
		string xmlLang = reader.XmlLang;
		reader.MoveToContent();
		string text = reader.ReadElementContentAsString(XD.Message11Dictionary.FaultString.Value, XD.Message11Dictionary.FaultNamespace.Value);
		FaultReasonText translation = new FaultReasonText(text, xmlLang);
		string text2 = "";
		if (reader.IsStartElement(XD.Message11Dictionary.FaultActor, XD.Message11Dictionary.FaultNamespace))
		{
			text2 = reader.ReadElementContentAsString();
		}
		XmlBuffer xmlBuffer = null;
		if (reader.IsStartElement(XD.Message11Dictionary.FaultDetail, XD.Message11Dictionary.FaultNamespace))
		{
			xmlBuffer = new XmlBuffer(maxBufferSize);
			XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(reader.Quotas);
			xmlDictionaryWriter.WriteNode(reader, defattr: false);
			xmlBuffer.CloseSection();
			xmlBuffer.Close();
		}
		reader.ReadEndElement();
		FaultReason reason = new FaultReason(translation);
		return new ReceivedFault(code, reason, text2, text2, xmlBuffer, EnvelopeVersion.Soap11);
	}
}
