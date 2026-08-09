using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal class WSSecurityJan2004 : WSSecurityTokenSerializer.SerializerEntries
{
	internal abstract class BinaryTokenEntry : WSSecurityTokenSerializer.TokenEntry
	{
		internal static readonly XmlDictionaryString ElementName = XD.SecurityJan2004Dictionary.BinarySecurityToken;

		internal static readonly XmlDictionaryString EncodingTypeAttribute = XD.SecurityJan2004Dictionary.EncodingType;

		internal const string EncodingTypeAttributeString = "EncodingType";

		internal const string EncodingTypeValueBase64Binary = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";

		internal const string EncodingTypeValueHexBinary = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary";

		internal static readonly XmlDictionaryString ValueTypeAttribute = XD.SecurityJan2004Dictionary.ValueType;

		private WSSecurityTokenSerializer _tokenSerializer;

		private string[] _valueTypeUris;

		protected override XmlDictionaryString LocalName => ElementName;

		protected override XmlDictionaryString NamespaceUri => XD.SecurityJan2004Dictionary.Namespace;

		public override string TokenTypeUri => _valueTypeUris[0];

		protected override string ValueTypeUri => _valueTypeUris[0];

		protected BinaryTokenEntry(WSSecurityTokenSerializer tokenSerializer, string valueTypeUri)
		{
			_tokenSerializer = tokenSerializer;
			_valueTypeUris = new string[1];
			_valueTypeUris[0] = valueTypeUri;
		}

		protected BinaryTokenEntry(WSSecurityTokenSerializer tokenSerializer, string[] valueTypeUris)
		{
			if (valueTypeUris == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("valueTypeUris");
			}
			_tokenSerializer = tokenSerializer;
			_valueTypeUris = new string[valueTypeUris.GetLength(0)];
			for (int i = 0; i < _valueTypeUris.GetLength(0); i++)
			{
				_valueTypeUris[i] = valueTypeUris[i];
			}
		}

		public override bool SupportsTokenTypeUri(string tokenTypeUri)
		{
			for (int i = 0; i < _valueTypeUris.GetLength(0); i++)
			{
				if (_valueTypeUris[i] == tokenTypeUri)
				{
					return true;
				}
			}
			return false;
		}

		public abstract SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromBinaryCore(byte[] rawData);

		public override SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXmlCore(XmlElement issuedTokenXml, SecurityTokenReferenceStyle tokenReferenceStyle)
		{
			TokenReferenceStyleHelper.Validate(tokenReferenceStyle);
			switch (tokenReferenceStyle)
			{
			case SecurityTokenReferenceStyle.Internal:
				return WSSecurityTokenSerializer.TokenEntry.CreateDirectReference(issuedTokenXml, "Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", base.TokenType);
			case SecurityTokenReferenceStyle.External:
			{
				string attribute = issuedTokenXml.GetAttribute("EncodingType", null);
				string innerText = issuedTokenXml.InnerText;
				byte[] rawData;
				switch (attribute)
				{
				case null:
				case "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary":
					rawData = Convert.FromBase64String(innerText);
					break;
				case "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary":
					rawData = SoapHexBinary.Parse(innerText).Value;
					break;
				default:
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.UnknownEncodingInBinarySecurityToken));
				}
				return CreateKeyIdentifierClauseFromBinaryCore(rawData);
			}
			default:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("tokenReferenceStyle"));
			}
		}

		public abstract SecurityToken ReadBinaryCore(string id, string valueTypeUri, byte[] rawData);

		public override SecurityToken ReadTokenCore(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver)
		{
			string attribute = reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			string attribute2 = reader.GetAttribute(ValueTypeAttribute, null);
			byte[] rawData;
			switch (reader.GetAttribute(EncodingTypeAttribute, null))
			{
			case null:
			case "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary":
				rawData = reader.ReadElementContentAsBase64();
				break;
			case "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary":
				rawData = SoapHexBinary.Parse(reader.ReadElementContentAsString()).Value;
				break;
			default:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.UnknownEncodingInBinarySecurityToken));
			}
			return ReadBinaryCore(attribute, attribute2, rawData);
		}

		public abstract void WriteBinaryCore(SecurityToken token, out string id, out byte[] rawData);

		public override void WriteTokenCore(XmlDictionaryWriter writer, SecurityToken token)
		{
			WriteBinaryCore(token, out var id, out var rawData);
			if (rawData == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rawData");
			}
			writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, ElementName, XD.SecurityJan2004Dictionary.Namespace);
			if (id != null)
			{
				writer.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, id);
			}
			if (_valueTypeUris != null)
			{
				writer.WriteAttributeString(ValueTypeAttribute, null, _valueTypeUris[0]);
			}
			if (_tokenSerializer.EmitBspRequiredAttributes)
			{
				writer.WriteAttributeString(EncodingTypeAttribute, null, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary");
			}
			writer.WriteBase64(rawData, 0, rawData.Length);
			writer.WriteEndElement();
		}
	}

	private class GenericXmlTokenEntry : WSSecurityTokenSerializer.TokenEntry
	{
		protected override XmlDictionaryString LocalName => null;

		protected override XmlDictionaryString NamespaceUri => null;

		public override string TokenTypeUri => null;

		protected override string ValueTypeUri => null;

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(GenericXmlSecurityToken) };
		}

		public override bool CanReadTokenCore(XmlElement element)
		{
			return false;
		}

		public override bool CanReadTokenCore(XmlDictionaryReader reader)
		{
			return false;
		}

		public override SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXmlCore(XmlElement issuedTokenXml, SecurityTokenReferenceStyle tokenReferenceStyle)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
		}

		public override SecurityToken ReadTokenCore(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
		}

		public override void WriteTokenCore(XmlDictionaryWriter writer, SecurityToken token)
		{
			if (token is BufferedGenericXmlSecurityToken { TokenXmlBuffer: not null } bufferedGenericXmlSecurityToken)
			{
				using XmlDictionaryReader reader = bufferedGenericXmlSecurityToken.TokenXmlBuffer.GetReader(0);
				writer.WriteNode(reader, defattr: false);
				return;
			}
			GenericXmlSecurityToken genericXmlSecurityToken = (GenericXmlSecurityToken)token;
			genericXmlSecurityToken.TokenXml.WriteTo(writer);
		}
	}

	private class UserNamePasswordTokenEntry : WSSecurityTokenSerializer.TokenEntry
	{
		private WSSecurityTokenSerializer _tokenSerializer;

		protected override XmlDictionaryString LocalName => XD.SecurityJan2004Dictionary.UserNameTokenElement;

		protected override XmlDictionaryString NamespaceUri => XD.SecurityJan2004Dictionary.Namespace;

		public override string TokenTypeUri => "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#UsernameToken";

		protected override string ValueTypeUri => null;

		public UserNamePasswordTokenEntry(WSSecurityTokenSerializer tokenSerializer)
		{
			_tokenSerializer = tokenSerializer;
		}

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(UserNameSecurityToken) };
		}

		public override SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXmlCore(XmlElement issuedTokenXml, SecurityTokenReferenceStyle tokenReferenceStyle)
		{
			TokenReferenceStyleHelper.Validate(tokenReferenceStyle);
			return tokenReferenceStyle switch
			{
				SecurityTokenReferenceStyle.Internal => WSSecurityTokenSerializer.TokenEntry.CreateDirectReference(issuedTokenXml, "Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", typeof(UserNameSecurityToken)), 
				SecurityTokenReferenceStyle.External => null, 
				_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("tokenReferenceStyle")), 
			};
		}

		public override SecurityToken ReadTokenCore(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver)
		{
			ParseToken(reader, out var id, out var userName, out var password);
			if (id == null)
			{
				id = SecurityUniqueId.Create().Value;
			}
			return new UserNameSecurityToken(userName, password, id);
		}

		public override void WriteTokenCore(XmlDictionaryWriter writer, SecurityToken token)
		{
			UserNameSecurityToken userNameSecurityToken = (UserNameSecurityToken)token;
			WriteUserNamePassword(writer, userNameSecurityToken.Id, userNameSecurityToken.UserName, userNameSecurityToken.Password);
		}

		private void WriteUserNamePassword(XmlDictionaryWriter writer, string id, string userName, string password)
		{
			writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.UserNameTokenElement, XD.SecurityJan2004Dictionary.Namespace);
			writer.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, id);
			writer.WriteElementString(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.UserNameElement, XD.SecurityJan2004Dictionary.Namespace, userName);
			if (password != null)
			{
				writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.PasswordElement, XD.SecurityJan2004Dictionary.Namespace);
				if (_tokenSerializer.EmitBspRequiredAttributes)
				{
					writer.WriteAttributeString(XD.SecurityJan2004Dictionary.TypeAttribute, null, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText");
				}
				writer.WriteString(password);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}

		private static string ParsePassword(XmlDictionaryReader reader)
		{
			string attribute = reader.GetAttribute(XD.SecurityJan2004Dictionary.TypeAttribute, null);
			if (attribute != null && attribute.Length > 0 && attribute != "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText")
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedPasswordType, attribute)));
			}
			return reader.ReadElementString();
		}

		private static void ParseToken(XmlDictionaryReader reader, out string id, out string userName, out string password)
		{
			id = null;
			userName = null;
			password = null;
			reader.MoveToContent();
			id = reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			reader.ReadStartElement(XD.SecurityJan2004Dictionary.UserNameTokenElement, XD.SecurityJan2004Dictionary.Namespace);
			while (reader.IsStartElement())
			{
				if (reader.IsStartElement(XD.SecurityJan2004Dictionary.UserNameElement, XD.SecurityJan2004Dictionary.Namespace))
				{
					userName = reader.ReadElementString();
				}
				else if (reader.IsStartElement(XD.SecurityJan2004Dictionary.PasswordElement, XD.SecurityJan2004Dictionary.Namespace))
				{
					password = ParsePassword(reader);
				}
				else if (reader.IsStartElement(XD.SecurityJan2004Dictionary.NonceElement, XD.SecurityJan2004Dictionary.Namespace))
				{
					reader.Skip();
				}
				else if (reader.IsStartElement(XD.UtilityDictionary.CreatedElement, XD.UtilityDictionary.Namespace))
				{
					reader.Skip();
				}
				else
				{
					XmlHelper.OnUnexpectedChildNodeError("UsernameToken", reader);
				}
			}
			reader.ReadEndElement();
			if (userName == null)
			{
				XmlHelper.OnRequiredElementMissing("Username", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
			}
		}
	}

	protected class X509TokenEntry : BinaryTokenEntry
	{
		internal const string ValueTypeAbsoluteUri = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";

		public X509TokenEntry(WSSecurityTokenSerializer tokenSerializer)
			: base(tokenSerializer, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3")
		{
		}

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(X509SecurityToken) };
		}

		public override SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromBinaryCore(byte[] rawData)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CantInferReferenceForToken, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3")));
		}

		public override SecurityToken ReadBinaryCore(string id, string valueTypeUri, byte[] rawData)
		{
			if (!SecurityUtils.TryCreateX509CertificateFromRawData(rawData, out var certificate))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.InvalidX509RawData));
			}
			return new X509SecurityToken(certificate, id, clone: false);
		}

		public override void WriteBinaryCore(SecurityToken token, out string id, out byte[] rawData)
		{
			id = token.Id;
			if (token is X509SecurityToken x509SecurityToken)
			{
				rawData = x509SecurityToken.Certificate.GetRawCertData();
				return;
			}
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	public class IdManager : SignatureTargetIdManager
	{
		public override string DefaultIdNamespacePrefix => "u";

		public override string DefaultIdNamespaceUri => "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";

		internal static IdManager Instance { get; } = new IdManager();

		private IdManager()
		{
		}

		public override string ExtractId(XmlDictionaryReader reader)
		{
			if (reader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
			}
			return reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
		}

		public override void WriteIdAttribute(XmlDictionaryWriter writer, string id)
		{
			if (writer == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
			}
			writer.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, id);
		}
	}

	private SamlSerializer _samlSerializer;

	public WSSecurityTokenSerializer WSSecurityTokenSerializer { get; }

	public SamlSerializer SamlSerializer => _samlSerializer;

	public WSSecurityJan2004(WSSecurityTokenSerializer tokenSerializer, SamlSerializer samlSerializer)
	{
		WSSecurityTokenSerializer = tokenSerializer;
		_samlSerializer = samlSerializer;
	}

	protected void PopulateJan2004TokenEntries(IList<WSSecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		tokenEntryList.Add(new GenericXmlTokenEntry());
		tokenEntryList.Add(new UserNamePasswordTokenEntry(WSSecurityTokenSerializer));
		tokenEntryList.Add(new X509TokenEntry(WSSecurityTokenSerializer));
	}

	public override void PopulateTokenEntries(IList<WSSecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		PopulateJan2004TokenEntries(tokenEntryList);
	}
}
