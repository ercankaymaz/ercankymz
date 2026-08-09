using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class MessageHeader : MessageHeaderInfo
{
	private const bool DefaultRelayValue = false;

	private const bool DefaultMustUnderstandValue = false;

	private const string DefaultActorValue = "";

	public override string Actor => "";

	public override bool IsReferenceParameter => false;

	public override bool MustUnderstand => false;

	public override bool Relay => false;

	public virtual bool IsMessageVersionSupported(MessageVersion messageVersion)
	{
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		return true;
	}

	public override string ToString()
	{
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Indent = true
		};
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		using XmlWriter writer = XmlWriter.Create(stringWriter, settings);
		using XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		if (IsMessageVersionSupported(MessageVersion.Soap12WSAddressing10))
		{
			WriteHeader(xmlDictionaryWriter, MessageVersion.Soap12WSAddressing10);
		}
		else if (IsMessageVersionSupported(MessageVersion.Soap12WSAddressingAugust2004))
		{
			WriteHeader(xmlDictionaryWriter, MessageVersion.Soap12WSAddressingAugust2004);
		}
		else if (IsMessageVersionSupported(MessageVersion.Soap11WSAddressing10))
		{
			WriteHeader(xmlDictionaryWriter, MessageVersion.Soap11WSAddressing10);
		}
		else if (IsMessageVersionSupported(MessageVersion.Soap11WSAddressingAugust2004))
		{
			WriteHeader(xmlDictionaryWriter, MessageVersion.Soap11WSAddressingAugust2004);
		}
		else if (IsMessageVersionSupported(MessageVersion.Soap12))
		{
			WriteHeader(xmlDictionaryWriter, MessageVersion.Soap12);
		}
		else if (IsMessageVersionSupported(MessageVersion.Soap11))
		{
			WriteHeader(xmlDictionaryWriter, MessageVersion.Soap11);
		}
		else
		{
			WriteHeader(xmlDictionaryWriter, MessageVersion.None);
		}
		xmlDictionaryWriter.Flush();
		return stringWriter.ToString();
	}

	public void WriteHeader(XmlWriter writer, MessageVersion messageVersion)
	{
		WriteHeader(XmlDictionaryWriter.CreateDictionaryWriter(writer), messageVersion);
	}

	public void WriteHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageVersion"));
		}
		OnWriteStartHeader(writer, messageVersion);
		OnWriteHeaderContents(writer, messageVersion);
		writer.WriteEndElement();
	}

	public void WriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageVersion"));
		}
		OnWriteStartHeader(writer, messageVersion);
	}

	protected virtual void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		writer.WriteStartElement(Name, Namespace);
		WriteHeaderAttributes(writer, messageVersion);
	}

	public void WriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageVersion"));
		}
		OnWriteHeaderContents(writer, messageVersion);
	}

	protected abstract void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion);

	protected void WriteHeaderAttributes(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		string actor = Actor;
		if (actor.Length > 0)
		{
			writer.WriteAttributeString(messageVersion.Envelope.DictionaryActor, messageVersion.Envelope.DictionaryNamespace, actor);
		}
		if (MustUnderstand)
		{
			writer.WriteAttributeString(XD.MessageDictionary.MustUnderstand, messageVersion.Envelope.DictionaryNamespace, "1");
		}
		if (Relay && messageVersion.Envelope == EnvelopeVersion.Soap12)
		{
			writer.WriteAttributeString(XD.Message12Dictionary.Relay, XD.Message12Dictionary.Namespace, "1");
		}
	}

	public static MessageHeader CreateHeader(string name, string ns, object value)
	{
		return CreateHeader(name, ns, value, mustUnderstand: false, "", relay: false);
	}

	public static MessageHeader CreateHeader(string name, string ns, object value, bool mustUnderstand)
	{
		return CreateHeader(name, ns, value, mustUnderstand, "", relay: false);
	}

	public static MessageHeader CreateHeader(string name, string ns, object value, bool mustUnderstand, string actor)
	{
		return CreateHeader(name, ns, value, mustUnderstand, actor, relay: false);
	}

	public static MessageHeader CreateHeader(string name, string ns, object value, bool mustUnderstand, string actor, bool relay)
	{
		return new XmlObjectSerializerHeader(name, ns, value, null, mustUnderstand, actor, relay);
	}

	public static MessageHeader CreateHeader(string name, string ns, object value, XmlObjectSerializer serializer)
	{
		return CreateHeader(name, ns, value, serializer, mustUnderstand: false, "", relay: false);
	}

	public static MessageHeader CreateHeader(string name, string ns, object value, XmlObjectSerializer serializer, bool mustUnderstand)
	{
		return CreateHeader(name, ns, value, serializer, mustUnderstand, "", relay: false);
	}

	public static MessageHeader CreateHeader(string name, string ns, object value, XmlObjectSerializer serializer, bool mustUnderstand, string actor)
	{
		return CreateHeader(name, ns, value, serializer, mustUnderstand, actor, relay: false);
	}

	public static MessageHeader CreateHeader(string name, string ns, object value, XmlObjectSerializer serializer, bool mustUnderstand, string actor, bool relay)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		return new XmlObjectSerializerHeader(name, ns, value, serializer, mustUnderstand, actor, relay);
	}

	internal static void GetHeaderAttributes(XmlDictionaryReader reader, MessageVersion version, out string actor, out bool mustUnderstand, out bool relay, out bool isReferenceParameter)
	{
		int attributeCount = reader.AttributeCount;
		if (attributeCount == 0)
		{
			mustUnderstand = false;
			actor = string.Empty;
			relay = false;
			isReferenceParameter = false;
			return;
		}
		string attribute = reader.GetAttribute(XD.MessageDictionary.MustUnderstand, version.Envelope.DictionaryNamespace);
		if (attribute != null && ToBoolean(attribute))
		{
			mustUnderstand = true;
		}
		else
		{
			mustUnderstand = false;
		}
		if (mustUnderstand && attributeCount == 1)
		{
			actor = string.Empty;
			relay = false;
		}
		else
		{
			actor = reader.GetAttribute(version.Envelope.DictionaryActor, version.Envelope.DictionaryNamespace);
			if (actor == null)
			{
				actor = "";
			}
			if (version.Envelope == EnvelopeVersion.Soap12)
			{
				string attribute2 = reader.GetAttribute(XD.Message12Dictionary.Relay, version.Envelope.DictionaryNamespace);
				if (attribute2 != null && ToBoolean(attribute2))
				{
					relay = true;
				}
				else
				{
					relay = false;
				}
			}
			else
			{
				relay = false;
			}
		}
		isReferenceParameter = false;
		if (version.Addressing == AddressingVersion.WSAddressing10)
		{
			string attribute3 = reader.GetAttribute(XD.AddressingDictionary.IsReferenceParameter, version.Addressing.DictionaryNamespace);
			if (attribute3 != null)
			{
				isReferenceParameter = ToBoolean(attribute3);
			}
		}
	}

	private static bool ToBoolean(string value)
	{
		if (value.Length == 1)
		{
			switch (value[0])
			{
			case '1':
				return true;
			case '0':
				return false;
			}
		}
		else
		{
			if (value == "true")
			{
				return true;
			}
			if (value == "false")
			{
				return false;
			}
		}
		try
		{
			return XmlConvert.ToBoolean(value);
		}
		catch (FormatException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(ex.Message, null));
		}
	}
}
