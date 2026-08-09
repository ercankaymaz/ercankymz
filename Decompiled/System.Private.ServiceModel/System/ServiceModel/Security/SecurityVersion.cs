using System.IdentityModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace System.ServiceModel.Security;

public abstract class SecurityVersion
{
	internal class SecurityVersion10 : SecurityVersion
	{
		public static SecurityVersion10 Instance { get; } = new SecurityVersion10();

		internal override XmlDictionaryString FailedAuthenticationFaultCode => XD.SecurityJan2004Dictionary.FailedAuthenticationFaultCode;

		internal override XmlDictionaryString InvalidSecurityTokenFaultCode => XD.SecurityJan2004Dictionary.InvalidSecurityTokenFaultCode;

		internal override XmlDictionaryString InvalidSecurityFaultCode => XD.SecurityJan2004Dictionary.InvalidSecurityFaultCode;

		protected SecurityVersion10()
			: base(XD.SecurityJan2004Dictionary.Security, XD.SecurityJan2004Dictionary.Namespace, XD.SecurityJan2004Dictionary.Prefix)
		{
		}

		internal override SendSecurityHeader CreateSendSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction)
		{
			return new WSSecurityOneDotZeroSendSecurityHeader(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, direction);
		}

		internal override ReceiveSecurityHeader CreateReceiveSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction, int headerIndex)
		{
			return new WSSecurityOneDotZeroReceiveSecurityHeader(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, headerIndex, direction);
		}

		public override string ToString()
		{
			return "WSSecurity10";
		}
	}

	internal sealed class SecurityVersion11 : SecurityVersion10
	{
		public new static SecurityVersion11 Instance { get; } = new SecurityVersion11();

		internal override bool SupportsSignatureConfirmation => true;

		private SecurityVersion11()
		{
		}

		internal override ReceiveSecurityHeader CreateReceiveSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction, int headerIndex)
		{
			return new WSSecurityOneDotOneReceiveSecurityHeader(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, headerIndex, direction);
		}

		internal override SendSecurityHeader CreateSendSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction)
		{
			return new WSSecurityOneDotOneSendSecurityHeader(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, direction);
		}

		internal override bool IsReaderAtSignatureConfirmation(XmlDictionaryReader reader)
		{
			return reader.IsStartElement(XD.SecurityXXX2005Dictionary.SignatureConfirmation, XD.SecurityXXX2005Dictionary.Namespace);
		}

		internal override ISignatureValueSecurityElement ReadSignatureConfirmation(XmlDictionaryReader reader)
		{
			reader.MoveToStartElement(XD.SecurityXXX2005Dictionary.SignatureConfirmation, XD.SecurityXXX2005Dictionary.Namespace);
			bool isEmptyElement = reader.IsEmptyElement;
			string requiredNonEmptyAttribute = XmlHelper.GetRequiredNonEmptyAttribute(reader, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			byte[] requiredBase64Attribute = XmlHelper.GetRequiredBase64Attribute(reader, XD.SecurityXXX2005Dictionary.ValueAttribute, null);
			reader.ReadStartElement();
			if (!isEmptyElement)
			{
				reader.ReadEndElement();
			}
			return new SignatureConfirmationElement(requiredNonEmptyAttribute, requiredBase64Attribute, this);
		}

		internal override void WriteSignatureConfirmation(XmlDictionaryWriter writer, string id, byte[] signature)
		{
			if (id == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("id");
			}
			if (signature == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("signature");
			}
			writer.WriteStartElement(XD.SecurityXXX2005Dictionary.Prefix.Value, XD.SecurityXXX2005Dictionary.SignatureConfirmation, XD.SecurityXXX2005Dictionary.Namespace);
			writer.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, id);
			writer.WriteStartAttribute(XD.SecurityXXX2005Dictionary.ValueAttribute, null);
			writer.WriteBase64(signature, 0, signature.Length);
			writer.WriteEndAttribute();
			writer.WriteEndElement();
		}

		public override string ToString()
		{
			return "WSSecurity11";
		}
	}

	private readonly XmlDictionaryString _headerPrefix;

	internal XmlDictionaryString HeaderName { get; }

	internal XmlDictionaryString HeaderNamespace { get; }

	internal XmlDictionaryString HeaderPrefix => _headerPrefix;

	internal abstract XmlDictionaryString FailedAuthenticationFaultCode { get; }

	internal abstract XmlDictionaryString InvalidSecurityTokenFaultCode { get; }

	internal abstract XmlDictionaryString InvalidSecurityFaultCode { get; }

	internal virtual bool SupportsSignatureConfirmation => false;

	public static SecurityVersion WSSecurity10 => SecurityVersion10.Instance;

	public static SecurityVersion WSSecurity11 => SecurityVersion11.Instance;

	internal static SecurityVersion Default => WSSecurity11;

	internal SecurityVersion(XmlDictionaryString headerName, XmlDictionaryString headerNamespace, XmlDictionaryString headerPrefix)
	{
		HeaderName = headerName;
		HeaderNamespace = headerNamespace;
		_headerPrefix = headerPrefix;
	}

	internal abstract ReceiveSecurityHeader CreateReceiveSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction, int headerIndex);

	internal abstract SendSecurityHeader CreateSendSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction);

	internal bool DoesMessageContainSecurityHeader(Message message)
	{
		return message.Headers.FindHeader(HeaderName.Value, HeaderNamespace.Value) >= 0;
	}

	internal int FindIndexOfSecurityHeader(Message message, string[] actors)
	{
		return message.Headers.FindHeader(HeaderName.Value, HeaderNamespace.Value, actors);
	}

	internal virtual bool IsReaderAtSignatureConfirmation(XmlDictionaryReader reader)
	{
		return false;
	}

	internal virtual ISignatureValueSecurityElement ReadSignatureConfirmation(XmlDictionaryReader reader)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SignatureConfirmationNotSupported));
	}

	internal ReceiveSecurityHeader TryCreateReceiveSecurityHeader(Message message, string actor, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction)
	{
		int num = message.Headers.FindHeader(HeaderName.Value, HeaderNamespace.Value, actor);
		if (num < 0 && string.IsNullOrEmpty(actor))
		{
			num = message.Headers.FindHeader(HeaderName.Value, HeaderNamespace.Value, message.Version.Envelope.UltimateDestinationActorValues);
		}
		if (num < 0)
		{
			return null;
		}
		MessageHeaderInfo messageHeaderInfo = message.Headers[num];
		return CreateReceiveSecurityHeader(message, messageHeaderInfo.Actor, messageHeaderInfo.MustUnderstand, messageHeaderInfo.Relay, standardsManager, algorithmSuite, direction, num);
	}

	internal virtual void WriteSignatureConfirmation(XmlDictionaryWriter writer, string id, byte[] signatureConfirmation)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SignatureConfirmationNotSupported));
	}

	internal void WriteStartHeader(XmlDictionaryWriter writer)
	{
		writer.WriteStartElement(HeaderPrefix.Value, HeaderName, HeaderNamespace);
	}
}
