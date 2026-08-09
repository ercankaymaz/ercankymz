using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Selectors;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Xml;

namespace System.IdentityModel.Tokens;

internal class WSSecurityJan2004 : SecurityTokenSerializer.SerializerEntries
{
	internal abstract class BinaryTokenEntry : SecurityTokenSerializer.TokenEntry
	{
		internal static readonly XmlDictionaryString ElementName = XD.SecurityJan2004Dictionary.BinarySecurityToken;

		internal static readonly XmlDictionaryString EncodingTypeAttribute = XD.SecurityJan2004Dictionary.EncodingType;

		internal const string EncodingTypeAttributeString = "EncodingType";

		internal const string EncodingTypeValueBase64Binary = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";

		internal const string EncodingTypeValueHexBinary = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary";

		internal static readonly XmlDictionaryString ValueTypeAttribute = XD.SecurityJan2004Dictionary.ValueType;

		private string[] _valueTypeUris;

		protected override XmlDictionaryString LocalName => ElementName;

		protected override XmlDictionaryString NamespaceUri => XD.SecurityJan2004Dictionary.Namespace;

		public override string TokenTypeUri => _valueTypeUris[0];

		protected override string ValueTypeUri => _valueTypeUris[0];

		protected BinaryTokenEntry(string valueTypeUri)
		{
			_valueTypeUris = new string[1];
			_valueTypeUris[0] = valueTypeUri;
		}

		protected BinaryTokenEntry(string[] valueTypeUris)
		{
			if (valueTypeUris == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("valueTypeUris");
			}
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
	}

	private class GenericXmlTokenEntry : SecurityTokenSerializer.TokenEntry
	{
		protected override XmlDictionaryString LocalName => null;

		protected override XmlDictionaryString NamespaceUri => null;

		public override string TokenTypeUri => null;

		protected override string ValueTypeUri => null;

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(GenericXmlSecurityToken) };
		}
	}

	private class UserNamePasswordTokenEntry : SecurityTokenSerializer.TokenEntry
	{
		protected override XmlDictionaryString LocalName => XD.SecurityJan2004Dictionary.UserNameTokenElement;

		protected override XmlDictionaryString NamespaceUri => XD.SecurityJan2004Dictionary.Namespace;

		public override string TokenTypeUri => "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#UsernameToken";

		protected override string ValueTypeUri => null;

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(UserNameSecurityToken) };
		}
	}

	protected class X509TokenEntry : BinaryTokenEntry
	{
		internal const string ValueTypeAbsoluteUri = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";

		public X509TokenEntry()
			: base("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3")
		{
		}

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(X509SecurityToken) };
		}
	}

	protected class SecurityTokenReferenceJan2004ClauseEntry : SecurityTokenSerializer.KeyIdentifierClauseEntry
	{
		private const int DefaultDerivedKeyLength = 32;

		protected bool EmitBspRequiredAttributes { get; }

		protected IList<SecurityTokenSerializer.StrEntry> StrEntries { get; }

		protected override XmlDictionaryString LocalName => XD.SecurityJan2004Dictionary.SecurityTokenReference;

		protected override XmlDictionaryString NamespaceUri => XD.SecurityJan2004Dictionary.Namespace;

		public SecurityTokenReferenceJan2004ClauseEntry(bool emitBspRequiredAttributes, IList<SecurityTokenSerializer.StrEntry> strEntries)
		{
			EmitBspRequiredAttributes = emitBspRequiredAttributes;
			StrEntries = strEntries;
		}

		protected virtual string ReadTokenType(XmlDictionaryReader reader)
		{
			return null;
		}

		public override SecurityKeyIdentifierClause ReadKeyIdentifierClauseCore(XmlDictionaryReader reader)
		{
			byte[] derivationNonce = null;
			int derivationLength = 0;
			if (reader.IsStartElement(XD.SecurityJan2004Dictionary.SecurityTokenReference, NamespaceUri))
			{
				string attribute = reader.GetAttribute(XD.SecureConversationFeb2005Dictionary.Nonce, XD.SecureConversationFeb2005Dictionary.Namespace);
				if (attribute != null)
				{
					derivationNonce = Convert.FromBase64String(attribute);
				}
				string attribute2 = reader.GetAttribute(XD.SecureConversationFeb2005Dictionary.Length, XD.SecureConversationFeb2005Dictionary.Namespace);
				derivationLength = ((attribute2 == null) ? 32 : Convert.ToInt32(attribute2, CultureInfo.InvariantCulture));
			}
			string tokenType = ReadTokenType(reader);
			string attribute3 = reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			reader.ReadStartElement(XD.SecurityJan2004Dictionary.SecurityTokenReference, NamespaceUri);
			SecurityKeyIdentifierClause securityKeyIdentifierClause = null;
			for (int i = 0; i < StrEntries.Count; i++)
			{
				if (StrEntries[i].CanReadClause(reader, tokenType))
				{
					securityKeyIdentifierClause = StrEntries[i].ReadClause(reader, derivationNonce, derivationLength, tokenType);
					break;
				}
			}
			if (securityKeyIdentifierClause == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CannotReadKeyIdentifierClause, reader.LocalName, reader.NamespaceURI)));
			}
			if (!string.IsNullOrEmpty(attribute3))
			{
				securityKeyIdentifierClause.Id = attribute3;
			}
			reader.ReadEndElement();
			return securityKeyIdentifierClause;
		}

		public override bool SupportsCore(SecurityKeyIdentifierClause keyIdentifierClause)
		{
			for (int i = 0; i < StrEntries.Count; i++)
			{
				if (StrEntries[i].SupportsCore(keyIdentifierClause))
				{
					return true;
				}
			}
			return false;
		}

		public override void WriteKeyIdentifierClauseCore(XmlDictionaryWriter writer, SecurityKeyIdentifierClause keyIdentifierClause)
		{
			for (int i = 0; i < StrEntries.Count; i++)
			{
				if (StrEntries[i].SupportsCore(keyIdentifierClause))
				{
					writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.SecurityTokenReference, XD.SecurityJan2004Dictionary.Namespace);
					StrEntries[i].WriteContent(writer, keyIdentifierClause);
					writer.WriteEndElement();
					return;
				}
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.StandardsManagerCannotWriteObject, keyIdentifierClause.GetType())));
		}
	}

	protected abstract class KeyIdentifierStrEntry : SecurityTokenSerializer.StrEntry
	{
		protected const string EncodingTypeValueBase64Binary = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";

		protected const string EncodingTypeValueHexBinary = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary";

		protected const string EncodingTypeValueText = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Text";

		protected abstract Type ClauseType { get; }

		protected virtual string DefaultEncodingType => "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";

		public abstract Type TokenType { get; }

		protected abstract string ValueTypeUri { get; }

		protected bool EmitBspRequiredAttributes { get; }

		protected KeyIdentifierStrEntry(bool emitBspRequiredAttributes)
		{
			EmitBspRequiredAttributes = emitBspRequiredAttributes;
		}

		public override bool CanReadClause(XmlDictionaryReader reader, string tokenType)
		{
			if (reader.IsStartElement(XD.SecurityJan2004Dictionary.KeyIdentifier, XD.SecurityJan2004Dictionary.Namespace))
			{
				string attribute = reader.GetAttribute(XD.SecurityJan2004Dictionary.ValueType, null);
				return ValueTypeUri == attribute;
			}
			return false;
		}

		protected abstract SecurityKeyIdentifierClause CreateClause(byte[] bytes, byte[] derivationNonce, int derivationLength);

		public override Type GetTokenType(SecurityKeyIdentifierClause clause)
		{
			return TokenType;
		}

		public override SecurityKeyIdentifierClause ReadClause(XmlDictionaryReader reader, byte[] derivationNonce, int derivationLength, string tokenType)
		{
			string text = reader.GetAttribute(XD.SecurityJan2004Dictionary.EncodingType, null);
			if (text == null)
			{
				text = DefaultEncodingType;
			}
			reader.ReadStartElement();
			byte[] bytes = text switch
			{
				"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary" => reader.ReadContentAsBase64(), 
				"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary" => SoapHexBinary.Parse(reader.ReadContentAsString()).Value, 
				"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Text" => new UTF8Encoding().GetBytes(reader.ReadContentAsString()), 
				_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityMessageSerializationException(System.SR.UnknownEncodingInKeyIdentifier)), 
			};
			reader.ReadEndElement();
			return CreateClause(bytes, derivationNonce, derivationLength);
		}

		public override bool SupportsCore(SecurityKeyIdentifierClause clause)
		{
			return ClauseType.IsAssignableFrom(clause.GetType());
		}

		public override void WriteContent(XmlDictionaryWriter writer, SecurityKeyIdentifierClause clause)
		{
			writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.KeyIdentifier, XD.SecurityJan2004Dictionary.Namespace);
			writer.WriteAttributeString(XD.SecurityJan2004Dictionary.ValueType, null, ValueTypeUri);
			if (EmitBspRequiredAttributes)
			{
				writer.WriteAttributeString(XD.SecurityJan2004Dictionary.EncodingType, null, DefaultEncodingType);
			}
			string defaultEncodingType = DefaultEncodingType;
			BinaryKeyIdentifierClause binaryKeyIdentifierClause = clause as BinaryKeyIdentifierClause;
			byte[] buffer = binaryKeyIdentifierClause.GetBuffer();
			switch (defaultEncodingType)
			{
			case "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary":
				writer.WriteBase64(buffer, 0, buffer.Length);
				break;
			case "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary":
				writer.WriteBinHex(buffer, 0, buffer.Length);
				break;
			case "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Text":
				writer.WriteString(new UTF8Encoding().GetString(buffer, 0, buffer.Length));
				break;
			}
			writer.WriteEndElement();
		}
	}

	protected class X509SkiStrEntry : KeyIdentifierStrEntry
	{
		protected override Type ClauseType => typeof(X509SubjectKeyIdentifierClause);

		public override Type TokenType => typeof(X509SecurityToken);

		protected override string ValueTypeUri => "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509SubjectKeyIdentifier";

		public X509SkiStrEntry(bool emitBspRequiredAttributes)
			: base(emitBspRequiredAttributes)
		{
		}

		protected override SecurityKeyIdentifierClause CreateClause(byte[] bytes, byte[] derivationNonce, int derivationLength)
		{
			return new X509SubjectKeyIdentifierClause(bytes);
		}

		public override string GetTokenTypeUri()
		{
			return "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";
		}
	}

	protected class LocalReferenceStrEntry : SecurityTokenSerializer.StrEntry
	{
		private bool _emitBspRequiredAttributes;

		private KeyInfoSerializer _tokenSerializer;

		public LocalReferenceStrEntry(bool emitBspRequiredAttributes, KeyInfoSerializer tokenSerializer)
		{
			_emitBspRequiredAttributes = emitBspRequiredAttributes;
			_tokenSerializer = tokenSerializer;
		}

		public override Type GetTokenType(SecurityKeyIdentifierClause clause)
		{
			LocalIdKeyIdentifierClause localIdKeyIdentifierClause = clause as LocalIdKeyIdentifierClause;
			return localIdKeyIdentifierClause.OwnerType;
		}

		public string GetLocalTokenTypeUri(SecurityKeyIdentifierClause clause)
		{
			Type tokenType = GetTokenType(clause);
			return _tokenSerializer.GetTokenTypeUri(tokenType);
		}

		public override string GetTokenTypeUri()
		{
			return null;
		}

		public override bool CanReadClause(XmlDictionaryReader reader, string tokenType)
		{
			if (reader.IsStartElement(XD.SecurityJan2004Dictionary.Reference, XD.SecurityJan2004Dictionary.Namespace))
			{
				string attribute = reader.GetAttribute(XD.SecurityJan2004Dictionary.URI, null);
				if (attribute != null && attribute.Length > 0 && attribute[0] == '#')
				{
					return true;
				}
			}
			return false;
		}

		public override SecurityKeyIdentifierClause ReadClause(XmlDictionaryReader reader, byte[] derivationNonce, int derivationLength, string tokenType)
		{
			string attribute = reader.GetAttribute(XD.SecurityJan2004Dictionary.URI, null);
			string attribute2 = reader.GetAttribute(XD.SecurityJan2004Dictionary.ValueType, null);
			Type[] ownerTypes = null;
			if (attribute2 != null)
			{
				ownerTypes = _tokenSerializer.GetTokenTypes(attribute2);
			}
			SecurityKeyIdentifierClause result = new LocalIdKeyIdentifierClause(attribute.Substring(1), derivationNonce, derivationLength, ownerTypes);
			if (reader.IsEmptyElement)
			{
				reader.Read();
			}
			else
			{
				reader.ReadStartElement();
				reader.ReadEndElement();
			}
			return result;
		}

		public override bool SupportsCore(SecurityKeyIdentifierClause clause)
		{
			return clause is LocalIdKeyIdentifierClause;
		}

		public override void WriteContent(XmlDictionaryWriter writer, SecurityKeyIdentifierClause clause)
		{
			LocalIdKeyIdentifierClause localIdKeyIdentifierClause = clause as LocalIdKeyIdentifierClause;
			writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.Reference, XD.SecurityJan2004Dictionary.Namespace);
			if (_emitBspRequiredAttributes)
			{
				string localTokenTypeUri = GetLocalTokenTypeUri(localIdKeyIdentifierClause);
				if (localTokenTypeUri != null)
				{
					writer.WriteAttributeString(XD.SecurityJan2004Dictionary.ValueType, null, localTokenTypeUri);
				}
			}
			writer.WriteAttributeString(XD.SecurityJan2004Dictionary.URI, null, "#" + localIdKeyIdentifierClause.LocalId);
			writer.WriteEndElement();
		}
	}

	protected class X509IssuerSerialStrEntry : SecurityTokenSerializer.StrEntry
	{
		public override Type GetTokenType(SecurityKeyIdentifierClause clause)
		{
			return typeof(X509SecurityToken);
		}

		public override bool CanReadClause(XmlDictionaryReader reader, string tokenType)
		{
			return reader.IsStartElement(XD.XmlSignatureDictionary.X509Data, XD.XmlSignatureDictionary.Namespace);
		}

		public override string GetTokenTypeUri()
		{
			return "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";
		}

		public override SecurityKeyIdentifierClause ReadClause(XmlDictionaryReader reader, byte[] derivationNonce, int derivationLength, string tokenType)
		{
			reader.ReadStartElement(XD.XmlSignatureDictionary.X509Data, XD.XmlSignatureDictionary.Namespace);
			reader.ReadStartElement(XD.XmlSignatureDictionary.X509IssuerSerial, XD.XmlSignatureDictionary.Namespace);
			reader.ReadStartElement(XD.XmlSignatureDictionary.X509IssuerName, XD.XmlSignatureDictionary.Namespace);
			string issuerName = reader.ReadContentAsString();
			reader.ReadEndElement();
			reader.ReadStartElement(XD.XmlSignatureDictionary.X509SerialNumber, XD.XmlSignatureDictionary.Namespace);
			string issuerSerialNumber = reader.ReadContentAsString();
			reader.ReadEndElement();
			reader.ReadEndElement();
			reader.ReadEndElement();
			return new X509IssuerSerialKeyIdentifierClause(issuerName, issuerSerialNumber);
		}

		public override bool SupportsCore(SecurityKeyIdentifierClause clause)
		{
			return clause is X509IssuerSerialKeyIdentifierClause;
		}

		public override void WriteContent(XmlDictionaryWriter writer, SecurityKeyIdentifierClause clause)
		{
			X509IssuerSerialKeyIdentifierClause x509IssuerSerialKeyIdentifierClause = clause as X509IssuerSerialKeyIdentifierClause;
			writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509Data, XD.XmlSignatureDictionary.Namespace);
			writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509IssuerSerial, XD.XmlSignatureDictionary.Namespace);
			writer.WriteElementString(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509IssuerName, XD.XmlSignatureDictionary.Namespace, x509IssuerSerialKeyIdentifierClause.IssuerName);
			writer.WriteElementString(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509SerialNumber, XD.XmlSignatureDictionary.Namespace, x509IssuerSerialKeyIdentifierClause.IssuerSerialNumber);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	public class IdManager : SignatureTargetIdManager
	{
		internal static readonly XmlDictionaryString ElementName = XD.XmlEncryptionDictionary.EncryptedData;

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
			if (reader.IsStartElement(ElementName, XD.XmlEncryptionDictionary.Namespace))
			{
				return reader.GetAttribute(XD.XmlEncryptionDictionary.Id, null);
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

	public KeyInfoSerializer SecurityTokenSerializer { get; }

	public WSSecurityJan2004(KeyInfoSerializer securityTokenSerializer)
	{
		SecurityTokenSerializer = securityTokenSerializer;
	}

	public override void PopulateKeyIdentifierClauseEntries(IList<SecurityTokenSerializer.KeyIdentifierClauseEntry> clauseEntries)
	{
		List<SecurityTokenSerializer.StrEntry> strEntries = new List<SecurityTokenSerializer.StrEntry>();
		SecurityTokenSerializer.PopulateStrEntries(strEntries);
		SecurityTokenReferenceJan2004ClauseEntry item = new SecurityTokenReferenceJan2004ClauseEntry(SecurityTokenSerializer.EmitBspRequiredAttributes, strEntries);
		clauseEntries.Add(item);
	}

	protected void PopulateJan2004StrEntries(IList<SecurityTokenSerializer.StrEntry> strEntries)
	{
		strEntries.Add(new LocalReferenceStrEntry(SecurityTokenSerializer.EmitBspRequiredAttributes, SecurityTokenSerializer));
		strEntries.Add(new X509SkiStrEntry(SecurityTokenSerializer.EmitBspRequiredAttributes));
		strEntries.Add(new X509IssuerSerialStrEntry());
	}

	public override void PopulateStrEntries(IList<SecurityTokenSerializer.StrEntry> strEntries)
	{
		PopulateJan2004StrEntries(strEntries);
	}

	protected void PopulateJan2004TokenEntries(IList<SecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		tokenEntryList.Add(new GenericXmlTokenEntry());
		tokenEntryList.Add(new UserNamePasswordTokenEntry());
		tokenEntryList.Add(new X509TokenEntry());
	}

	public override void PopulateTokenEntries(IList<SecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		PopulateJan2004TokenEntries(tokenEntryList);
	}
}
