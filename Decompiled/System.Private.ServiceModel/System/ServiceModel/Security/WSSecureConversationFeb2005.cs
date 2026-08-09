using System.Collections.Generic;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal class WSSecureConversationFeb2005 : WSSecureConversation
{
	private class SecurityContextTokenEntryFeb2005 : SecurityContextTokenEntry
	{
		public SecurityContextTokenEntryFeb2005(WSSecureConversationFeb2005 parent, SecurityStateEncoder securityStateEncoder, IList<Type> knownClaimTypes)
			: base(parent, securityStateEncoder, knownClaimTypes)
		{
		}

		protected override bool CanReadGeneration(XmlDictionaryReader reader)
		{
			return reader.IsStartElement(DXD.SecureConversationDec2005Dictionary.Instance, XD.SecureConversationFeb2005Dictionary.Namespace);
		}

		protected override bool CanReadGeneration(XmlElement element)
		{
			if (element.LocalName == DXD.SecureConversationDec2005Dictionary.Instance.Value)
			{
				return element.NamespaceURI == XD.SecureConversationFeb2005Dictionary.Namespace.Value;
			}
			return false;
		}

		protected override UniqueId ReadGeneration(XmlDictionaryReader reader)
		{
			return reader.ReadElementContentAsUniqueId();
		}

		protected override UniqueId ReadGeneration(XmlElement element)
		{
			return XmlHelper.ReadTextElementAsUniqueId(element);
		}

		protected override void WriteGeneration(XmlDictionaryWriter writer, SecurityContextSecurityToken sct)
		{
			if (sct.KeyGeneration != null)
			{
				writer.WriteStartElement(XD.SecureConversationFeb2005Dictionary.Prefix.Value, DXD.SecureConversationDec2005Dictionary.Instance, XD.SecureConversationFeb2005Dictionary.Namespace);
				XmlHelper.WriteStringAsUniqueId(writer, sct.KeyGeneration);
				writer.WriteEndElement();
			}
		}
	}

	public class DriverFeb2005 : Driver
	{
		protected override SecureConversationDictionary DriverDictionary => XD.SecureConversationFeb2005Dictionary;

		public override XmlDictionaryString CloseAction => XD.SecureConversationFeb2005Dictionary.RequestSecurityContextClose;

		public override XmlDictionaryString CloseResponseAction => XD.SecureConversationFeb2005Dictionary.RequestSecurityContextCloseResponse;

		public override bool IsSessionSupported => true;

		public override XmlDictionaryString RenewAction => XD.SecureConversationFeb2005Dictionary.RequestSecurityContextRenew;

		public override XmlDictionaryString RenewResponseAction => XD.SecureConversationFeb2005Dictionary.RequestSecurityContextRenewResponse;

		public override XmlDictionaryString Namespace => XD.SecureConversationFeb2005Dictionary.Namespace;

		public override string TokenTypeUri => XD.SecureConversationFeb2005Dictionary.SecurityContextTokenType.Value;
	}

	private SecurityStateEncoder _securityStateEncoder;

	private IList<Type> _knownClaimTypes;

	public override SecureConversationDictionary SerializerDictionary => XD.SecureConversationFeb2005Dictionary;

	public WSSecureConversationFeb2005(WSSecurityTokenSerializer tokenSerializer, SecurityStateEncoder securityStateEncoder, IEnumerable<Type> knownTypes, int maxKeyDerivationOffset, int maxKeyDerivationLabelLength, int maxKeyDerivationNonceLength)
		: base(tokenSerializer, maxKeyDerivationOffset, maxKeyDerivationLabelLength, maxKeyDerivationNonceLength)
	{
		if (securityStateEncoder != null)
		{
			_securityStateEncoder = securityStateEncoder;
		}
		_knownClaimTypes = new List<Type>();
		if (knownTypes == null)
		{
			return;
		}
		foreach (Type knownType in knownTypes)
		{
			_knownClaimTypes.Add(knownType);
		}
	}

	public override void PopulateTokenEntries(IList<WSSecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		base.PopulateTokenEntries(tokenEntryList);
		tokenEntryList.Add(new SecurityContextTokenEntryFeb2005(this, _securityStateEncoder, _knownClaimTypes));
	}
}
