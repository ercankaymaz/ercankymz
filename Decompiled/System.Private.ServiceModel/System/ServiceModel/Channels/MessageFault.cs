using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class MessageFault
{
	private static MessageFault s_defaultMessageFault;

	internal static MessageFault Default
	{
		get
		{
			if (s_defaultMessageFault == null)
			{
				s_defaultMessageFault = CreateFault(new FaultCode("Default"), new FaultReason("", CultureInfo.CurrentCulture));
			}
			return s_defaultMessageFault;
		}
	}

	public virtual string Actor => "";

	public abstract FaultCode Code { get; }

	public bool IsMustUnderstandFault
	{
		get
		{
			FaultCode code = Code;
			if (string.Compare(code.Name, "MustUnderstand", StringComparison.Ordinal) != 0)
			{
				return false;
			}
			if (string.Compare(code.Namespace, EnvelopeVersion.Soap11.Namespace, StringComparison.Ordinal) != 0 && string.Compare(code.Namespace, EnvelopeVersion.Soap12.Namespace, StringComparison.Ordinal) != 0)
			{
				return false;
			}
			return true;
		}
	}

	public virtual string Node => "";

	public abstract bool HasDetail { get; }

	public abstract FaultReason Reason { get; }

	public static MessageFault CreateFault(FaultCode code, string reason)
	{
		return CreateFault(code, new FaultReason(reason));
	}

	public static MessageFault CreateFault(FaultCode code, FaultReason reason)
	{
		return CreateFault(code, reason, null, null, "", "");
	}

	public static MessageFault CreateFault(FaultCode code, FaultReason reason, object detail)
	{
		return CreateFault(code, reason, detail, DataContractSerializerDefaults.CreateSerializer((detail == null) ? typeof(object) : detail.GetType(), int.MaxValue), "", "");
	}

	public static MessageFault CreateFault(FaultCode code, FaultReason reason, object detail, XmlObjectSerializer serializer)
	{
		return CreateFault(code, reason, detail, serializer, "", "");
	}

	public static MessageFault CreateFault(FaultCode code, FaultReason reason, object detail, XmlObjectSerializer serializer, string actor)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		return CreateFault(code, reason, detail, serializer, actor, actor);
	}

	public static MessageFault CreateFault(FaultCode code, FaultReason reason, object detail, XmlObjectSerializer serializer, string actor, string node)
	{
		if (code == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("code"));
		}
		if (reason == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("reason"));
		}
		if (actor == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("actor"));
		}
		if (node == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("node"));
		}
		return new XmlObjectSerializerFault(code, reason, detail, serializer, actor, node);
	}

	public static MessageFault CreateFault(Message message, int maxBufferSize)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("message"));
		}
		XmlDictionaryReader readerAtBodyContents = message.GetReaderAtBodyContents();
		using (readerAtBodyContents)
		{
			try
			{
				EnvelopeVersion envelope = message.Version.Envelope;
				MessageFault result;
				if (envelope == EnvelopeVersion.Soap12)
				{
					result = ReceivedFault.CreateFault12(readerAtBodyContents, maxBufferSize);
				}
				else if (envelope == EnvelopeVersion.Soap11)
				{
					result = ReceivedFault.CreateFault11(readerAtBodyContents, maxBufferSize);
				}
				else
				{
					if (envelope != EnvelopeVersion.None)
					{
						throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EnvelopeVersionUnknown, envelope.ToString())), message);
					}
					result = ReceivedFault.CreateFaultNone(readerAtBodyContents, maxBufferSize);
				}
				message.ReadFromBodyContentsToEnd(readerAtBodyContents);
				return result;
			}
			catch (InvalidOperationException innerException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxErrorDeserializingFault, innerException));
			}
			catch (FormatException innerException2)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxErrorDeserializingFault, innerException2));
			}
			catch (XmlException innerException3)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(System.SR.SFxErrorDeserializingFault, innerException3));
			}
		}
	}

	public T GetDetail<T>()
	{
		return GetDetail<T>(DataContractSerializerDefaults.CreateSerializer(typeof(T), int.MaxValue));
	}

	public T GetDetail<T>(XmlObjectSerializer serializer)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		XmlDictionaryReader readerAtDetailContents = GetReaderAtDetailContents();
		T result = (T)serializer.ReadObject(readerAtDetailContents);
		if (!readerAtDetailContents.EOF)
		{
			readerAtDetailContents.MoveToContent();
			if (readerAtDetailContents.NodeType != XmlNodeType.EndElement && !readerAtDetailContents.EOF)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(System.SR.ExtraContentIsPresentInFaultDetail));
			}
		}
		return result;
	}

	public XmlDictionaryReader GetReaderAtDetailContents()
	{
		if (!HasDetail)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FaultDoesNotHaveAnyDetail));
		}
		return OnGetReaderAtDetailContents();
	}

	protected virtual void OnWriteDetail(XmlDictionaryWriter writer, EnvelopeVersion version)
	{
		OnWriteStartDetail(writer, version);
		OnWriteDetailContents(writer);
		writer.WriteEndElement();
	}

	protected virtual void OnWriteStartDetail(XmlDictionaryWriter writer, EnvelopeVersion version)
	{
		if (version == EnvelopeVersion.Soap12)
		{
			writer.WriteStartElement(XD.Message12Dictionary.FaultDetail, XD.Message12Dictionary.Namespace);
		}
		else if (version == EnvelopeVersion.Soap11)
		{
			writer.WriteStartElement(XD.Message11Dictionary.FaultDetail, XD.Message11Dictionary.FaultNamespace);
		}
		else
		{
			writer.WriteStartElement(XD.Message12Dictionary.FaultDetail, XD.MessageDictionary.Namespace);
		}
	}

	protected abstract void OnWriteDetailContents(XmlDictionaryWriter writer);

	protected virtual XmlDictionaryReader OnGetReaderAtDetailContents()
	{
		XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter writer = xmlBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		OnWriteDetail(writer, EnvelopeVersion.Soap12);
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		XmlDictionaryReader reader = xmlBuffer.GetReader(0);
		reader.Read();
		return reader;
	}

	public static bool WasHeaderNotUnderstood(MessageHeaders headers, string name, string ns)
	{
		if (headers == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("headers");
		}
		for (int i = 0; i < headers.Count; i++)
		{
			MessageHeaderInfo messageHeaderInfo = headers[i];
			if (string.Compare(messageHeaderInfo.Name, "NotUnderstood", StringComparison.Ordinal) != 0 || string.Compare(messageHeaderInfo.Namespace, "http://www.w3.org/2003/05/soap-envelope", StringComparison.Ordinal) != 0)
			{
				continue;
			}
			using XmlDictionaryReader xmlDictionaryReader = headers.GetReaderAtHeader(i);
			xmlDictionaryReader.MoveToAttribute("qname", "http://www.w3.org/2003/05/soap-envelope");
			xmlDictionaryReader.ReadContentAsQualifiedName(out string localName, out string namespaceUri);
			if (localName != null && namespaceUri != null && string.Compare(name, localName, StringComparison.Ordinal) == 0 && string.Compare(ns, namespaceUri, StringComparison.Ordinal) == 0)
			{
				return true;
			}
		}
		return false;
	}

	public void WriteTo(XmlWriter writer, EnvelopeVersion version)
	{
		WriteTo(XmlDictionaryWriter.CreateDictionaryWriter(writer), version);
	}

	public void WriteTo(XmlDictionaryWriter writer, EnvelopeVersion version)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		if (version == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("version");
		}
		if (version == EnvelopeVersion.Soap12)
		{
			WriteTo12(writer);
			return;
		}
		if (version == EnvelopeVersion.Soap11)
		{
			WriteTo11(writer);
			return;
		}
		if (version == EnvelopeVersion.None)
		{
			WriteToNone(writer);
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EnvelopeVersionUnknown, version.ToString())));
	}

	private void WriteToNone(XmlDictionaryWriter writer)
	{
		WriteTo12Driver(writer, EnvelopeVersion.None);
	}

	private void WriteTo12Driver(XmlDictionaryWriter writer, EnvelopeVersion version)
	{
		writer.WriteStartElement(XD.MessageDictionary.Fault, version.DictionaryNamespace);
		writer.WriteStartElement(XD.Message12Dictionary.FaultCode, version.DictionaryNamespace);
		WriteFaultCode12Driver(writer, Code, version);
		writer.WriteEndElement();
		writer.WriteStartElement(XD.Message12Dictionary.FaultReason, version.DictionaryNamespace);
		FaultReason reason = Reason;
		for (int i = 0; i < reason.Translations.Count; i++)
		{
			FaultReasonText faultReasonText = reason.Translations[i];
			writer.WriteStartElement(XD.Message12Dictionary.FaultText, version.DictionaryNamespace);
			writer.WriteAttributeString("xml", "lang", "http://www.w3.org/XML/1998/namespace", faultReasonText.XmlLang);
			writer.WriteString(faultReasonText.Text);
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
		if (Node.Length > 0)
		{
			writer.WriteElementString(XD.Message12Dictionary.FaultNode, version.DictionaryNamespace, Node);
		}
		if (Actor.Length > 0)
		{
			writer.WriteElementString(XD.Message12Dictionary.FaultRole, version.DictionaryNamespace, Actor);
		}
		if (HasDetail)
		{
			OnWriteDetail(writer, version);
		}
		writer.WriteEndElement();
	}

	private void WriteFaultCode12Driver(XmlDictionaryWriter writer, FaultCode faultCode, EnvelopeVersion version)
	{
		writer.WriteStartElement(XD.Message12Dictionary.FaultValue, version.DictionaryNamespace);
		string localName = (faultCode.IsSenderFault ? version.SenderFaultName : ((!faultCode.IsReceiverFault) ? faultCode.Name : version.ReceiverFaultName));
		string text = ((!faultCode.IsPredefinedFault) ? faultCode.Namespace : version.Namespace);
		string text2 = writer.LookupPrefix(text);
		if (text2 == null)
		{
			writer.WriteAttributeString("xmlns", "a", "http://www.w3.org/2000/xmlns/", text);
		}
		writer.WriteQualifiedName(localName, text);
		writer.WriteEndElement();
		if (faultCode.SubCode != null)
		{
			writer.WriteStartElement(XD.Message12Dictionary.FaultSubcode, version.DictionaryNamespace);
			WriteFaultCode12Driver(writer, faultCode.SubCode, version);
			writer.WriteEndElement();
		}
	}

	private void WriteTo12(XmlDictionaryWriter writer)
	{
		WriteTo12Driver(writer, EnvelopeVersion.Soap12);
	}

	private void WriteTo11(XmlDictionaryWriter writer)
	{
		writer.WriteStartElement(XD.MessageDictionary.Fault, XD.Message11Dictionary.Namespace);
		writer.WriteStartElement(XD.Message11Dictionary.FaultCode, XD.Message11Dictionary.FaultNamespace);
		FaultCode faultCode = Code;
		if (faultCode.SubCode != null)
		{
			faultCode = faultCode.SubCode;
		}
		string localName = (faultCode.IsSenderFault ? "Client" : ((!faultCode.IsReceiverFault) ? faultCode.Name : "Server"));
		string text = ((!faultCode.IsPredefinedFault) ? faultCode.Namespace : "http://schemas.xmlsoap.org/soap/envelope/");
		string text2 = writer.LookupPrefix(text);
		if (text2 == null)
		{
			writer.WriteAttributeString("xmlns", "a", "http://www.w3.org/2000/xmlns/", text);
		}
		writer.WriteQualifiedName(localName, text);
		writer.WriteEndElement();
		FaultReasonText faultReasonText = Reason.Translations[0];
		writer.WriteStartElement(XD.Message11Dictionary.FaultString, XD.Message11Dictionary.FaultNamespace);
		if (faultReasonText.XmlLang.Length > 0)
		{
			writer.WriteAttributeString("xml", "lang", "http://www.w3.org/XML/1998/namespace", faultReasonText.XmlLang);
		}
		writer.WriteString(faultReasonText.Text);
		writer.WriteEndElement();
		if (Actor.Length > 0)
		{
			writer.WriteElementString(XD.Message11Dictionary.FaultActor, XD.Message11Dictionary.FaultNamespace, Actor);
		}
		if (HasDetail)
		{
			OnWriteDetail(writer, EnvelopeVersion.Soap11);
		}
		writer.WriteEndElement();
	}
}
