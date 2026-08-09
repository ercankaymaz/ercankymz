using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

public sealed class AddressingVersion
{
	private string _toStringFormat;

	private Uri _noneUri;

	private string _defaultFaultAction;

	private const string AddressingNoneToStringFormat = "AddressingNone ({0})";

	private const string Addressing10ToStringFormat = "Addressing10 ({0})";

	private const string Addressing200408ToStringFormat = "Addressing200408 ({0})";

	private static AddressingVersion s_addressing10 = new AddressingVersion("http://www.w3.org/2005/08/addressing", XD.Addressing10Dictionary.Namespace, "Addressing10 ({0})", Addressing10SignedMessageParts, "http://www.w3.org/2005/08/addressing/anonymous", XD.Addressing10Dictionary.Anonymous, "http://www.w3.org/2005/08/addressing/none", "http://www.w3.org/2005/08/addressing/fault", "http://www.w3.org/2005/08/addressing/soap/fault");

	private static MessagePartSpecification s_addressing10SignedMessageParts;

	private static MessagePartSpecification s_addressing200408SignedMessageParts;

	public static AddressingVersion WSAddressingAugust2004 { get; } = new AddressingVersion("http://schemas.xmlsoap.org/ws/2004/08/addressing", XD.Addressing200408Dictionary.Namespace, "Addressing200408 ({0})", Addressing200408SignedMessageParts, "http://schemas.xmlsoap.org/ws/2004/08/addressing/role/anonymous", XD.Addressing200408Dictionary.Anonymous, null, "http://schemas.xmlsoap.org/ws/2004/08/addressing/fault", "http://schemas.xmlsoap.org/ws/2004/08/addressing/fault");

	public static AddressingVersion WSAddressing10 => s_addressing10;

	public static AddressingVersion None { get; } = new AddressingVersion("http://schemas.microsoft.com/ws/2005/05/addressing/none", XD.AddressingNoneDictionary.Namespace, "AddressingNone ({0})", new MessagePartSpecification(), null, null, null, null, null);

	internal string Namespace { get; }

	private static MessagePartSpecification Addressing10SignedMessageParts
	{
		get
		{
			if (s_addressing10SignedMessageParts == null)
			{
				MessagePartSpecification messagePartSpecification = new MessagePartSpecification(new XmlQualifiedName("To", "http://www.w3.org/2005/08/addressing"), new XmlQualifiedName("From", "http://www.w3.org/2005/08/addressing"), new XmlQualifiedName("FaultTo", "http://www.w3.org/2005/08/addressing"), new XmlQualifiedName("ReplyTo", "http://www.w3.org/2005/08/addressing"), new XmlQualifiedName("MessageID", "http://www.w3.org/2005/08/addressing"), new XmlQualifiedName("RelatesTo", "http://www.w3.org/2005/08/addressing"), new XmlQualifiedName("Action", "http://www.w3.org/2005/08/addressing"));
				messagePartSpecification.MakeReadOnly();
				s_addressing10SignedMessageParts = messagePartSpecification;
			}
			return s_addressing10SignedMessageParts;
		}
	}

	private static MessagePartSpecification Addressing200408SignedMessageParts
	{
		get
		{
			if (s_addressing200408SignedMessageParts == null)
			{
				MessagePartSpecification messagePartSpecification = new MessagePartSpecification(new XmlQualifiedName("To", "http://schemas.xmlsoap.org/ws/2004/08/addressing"), new XmlQualifiedName("From", "http://schemas.xmlsoap.org/ws/2004/08/addressing"), new XmlQualifiedName("FaultTo", "http://schemas.xmlsoap.org/ws/2004/08/addressing"), new XmlQualifiedName("ReplyTo", "http://schemas.xmlsoap.org/ws/2004/08/addressing"), new XmlQualifiedName("MessageID", "http://schemas.xmlsoap.org/ws/2004/08/addressing"), new XmlQualifiedName("RelatesTo", "http://schemas.xmlsoap.org/ws/2004/08/addressing"), new XmlQualifiedName("Action", "http://schemas.xmlsoap.org/ws/2004/08/addressing"));
				messagePartSpecification.MakeReadOnly();
				s_addressing200408SignedMessageParts = messagePartSpecification;
			}
			return s_addressing200408SignedMessageParts;
		}
	}

	internal XmlDictionaryString DictionaryNamespace { get; }

	internal string Anonymous { get; }

	internal XmlDictionaryString DictionaryAnonymous { get; }

	internal Uri AnonymousUri { get; }

	internal Uri NoneUri => _noneUri;

	internal string FaultAction { get; }

	internal string DefaultFaultAction => _defaultFaultAction;

	internal MessagePartSpecification SignedMessageParts { get; }

	private AddressingVersion(string ns, XmlDictionaryString dictionaryNs, string toStringFormat, MessagePartSpecification signedMessageParts, string anonymous, XmlDictionaryString dictionaryAnonymous, string none, string faultAction, string defaultFaultAction)
	{
		Namespace = ns;
		DictionaryNamespace = dictionaryNs;
		_toStringFormat = toStringFormat;
		SignedMessageParts = signedMessageParts;
		Anonymous = anonymous;
		DictionaryAnonymous = dictionaryAnonymous;
		if (anonymous != null)
		{
			AnonymousUri = new Uri(anonymous);
		}
		if (none != null)
		{
			_noneUri = new Uri(none);
		}
		FaultAction = faultAction;
		_defaultFaultAction = defaultFaultAction;
	}

	public override string ToString()
	{
		return string.Format(_toStringFormat, Namespace);
	}
}
