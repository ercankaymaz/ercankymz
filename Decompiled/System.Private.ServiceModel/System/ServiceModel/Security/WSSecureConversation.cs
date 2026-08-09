using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class WSSecureConversation : WSSecurityTokenSerializer.SerializerEntries
{
	protected class DerivedKeyTokenEntry : WSSecurityTokenSerializer.TokenEntry
	{
		public const string DefaultLabel = "WS-SecureConversation";

		private WSSecureConversation _parent;

		private int _maxKeyDerivationOffset;

		private int _maxKeyDerivationLabelLength;

		private int _maxKeyDerivationNonceLength;

		protected override XmlDictionaryString LocalName => _parent.SerializerDictionary.DerivedKeyToken;

		protected override XmlDictionaryString NamespaceUri => _parent.SerializerDictionary.Namespace;

		public override string TokenTypeUri => _parent.SerializerDictionary.DerivedKeyTokenType.Value;

		protected override string ValueTypeUri => null;

		public DerivedKeyTokenEntry(WSSecureConversation parent, int maxKeyDerivationOffset, int maxKeyDerivationLabelLength, int maxKeyDerivationNonceLength)
		{
			_parent = parent ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
			_maxKeyDerivationOffset = maxKeyDerivationOffset;
			_maxKeyDerivationLabelLength = maxKeyDerivationLabelLength;
			_maxKeyDerivationNonceLength = maxKeyDerivationNonceLength;
		}

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(DerivedKeySecurityToken) };
		}

		public override SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXmlCore(XmlElement issuedTokenXml, SecurityTokenReferenceStyle tokenReferenceStyle)
		{
			TokenReferenceStyleHelper.Validate(tokenReferenceStyle);
			return tokenReferenceStyle switch
			{
				SecurityTokenReferenceStyle.Internal => WSSecurityTokenSerializer.TokenEntry.CreateDirectReference(issuedTokenXml, "Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", typeof(DerivedKeySecurityToken)), 
				SecurityTokenReferenceStyle.External => null, 
				_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("tokenReferenceStyle")), 
			};
		}

		public virtual void ReadDerivedKeyTokenParameters(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver, out string id, out string derivationAlgorithm, out string label, out int length, out byte[] nonce, out int offset, out int generation, out SecurityKeyIdentifierClause tokenToDeriveIdentifier, out SecurityToken tokenToDerive)
		{
			if (tokenResolver == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenResolver");
			}
			id = reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			derivationAlgorithm = reader.GetAttribute(XD.XmlSignatureDictionary.Algorithm, null);
			if (derivationAlgorithm == null)
			{
				derivationAlgorithm = _parent.DerivationAlgorithm;
			}
			reader.ReadStartElement();
			tokenToDeriveIdentifier = null;
			tokenToDerive = null;
			if (reader.IsStartElement(XD.SecurityJan2004Dictionary.SecurityTokenReference, XD.SecurityJan2004Dictionary.Namespace))
			{
				tokenToDeriveIdentifier = _parent.WSSecurityTokenSerializer.ReadKeyIdentifierClause(reader);
				tokenResolver.TryResolveToken(tokenToDeriveIdentifier, out tokenToDerive);
				generation = -1;
				if (reader.IsStartElement(_parent.SerializerDictionary.Generation, _parent.SerializerDictionary.Namespace))
				{
					reader.ReadStartElement();
					generation = reader.ReadContentAsInt();
					reader.ReadEndElement();
					if (generation < 0)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.DerivedKeyInvalidGenerationSpecified, generation)));
					}
				}
				offset = -1;
				if (reader.IsStartElement(_parent.SerializerDictionary.Offset, _parent.SerializerDictionary.Namespace))
				{
					reader.ReadStartElement();
					offset = reader.ReadContentAsInt();
					reader.ReadEndElement();
					if (offset < 0)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.DerivedKeyInvalidOffsetSpecified, offset)));
					}
				}
				length = 32;
				if (reader.IsStartElement(_parent.SerializerDictionary.Length, _parent.SerializerDictionary.Namespace))
				{
					reader.ReadStartElement();
					length = reader.ReadContentAsInt();
					reader.ReadEndElement();
				}
				if (offset == -1 && generation == -1)
				{
					offset = 0;
				}
				DerivedKeySecurityToken.EnsureAcceptableOffset(offset, generation, length, _maxKeyDerivationOffset);
				label = null;
				if (reader.IsStartElement(_parent.SerializerDictionary.Label, _parent.SerializerDictionary.Namespace))
				{
					reader.ReadStartElement();
					label = reader.ReadString();
					reader.ReadEndElement();
				}
				if (label != null && label.Length > _maxKeyDerivationLabelLength)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.DerivedKeyTokenLabelTooLong, label.Length, _maxKeyDerivationLabelLength)));
				}
				nonce = null;
				reader.ReadStartElement(_parent.SerializerDictionary.Nonce, _parent.SerializerDictionary.Namespace);
				nonce = reader.ReadContentAsBase64();
				reader.ReadEndElement();
				if (nonce != null && nonce.Length > _maxKeyDerivationNonceLength)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.DerivedKeyTokenNonceTooLong, nonce.Length, _maxKeyDerivationNonceLength)));
				}
				reader.ReadEndElement();
				return;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.DerivedKeyTokenRequiresTokenReference));
		}

		public virtual SecurityToken CreateDerivedKeyToken(string id, string derivationAlgorithm, string label, int length, byte[] nonce, int offset, int generation, SecurityKeyIdentifierClause tokenToDeriveIdentifier, SecurityToken tokenToDerive)
		{
			if (tokenToDerive == null)
			{
				return new DerivedKeySecurityTokenStub(generation, offset, length, label, nonce, tokenToDeriveIdentifier, derivationAlgorithm, id);
			}
			return new DerivedKeySecurityToken(generation, offset, length, label, nonce, tokenToDerive, tokenToDeriveIdentifier, derivationAlgorithm, id);
		}

		public override SecurityToken ReadTokenCore(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver)
		{
			ReadDerivedKeyTokenParameters(reader, tokenResolver, out var id, out var derivationAlgorithm, out var label, out var length, out var nonce, out var offset, out var generation, out var tokenToDeriveIdentifier, out var tokenToDerive);
			return CreateDerivedKeyToken(id, derivationAlgorithm, label, length, nonce, offset, generation, tokenToDeriveIdentifier, tokenToDerive);
		}

		public override void WriteTokenCore(XmlDictionaryWriter writer, SecurityToken token)
		{
			DerivedKeySecurityToken derivedKeySecurityToken = token as DerivedKeySecurityToken;
			string value = _parent.SerializerDictionary.Prefix.Value;
			writer.WriteStartElement(value, _parent.SerializerDictionary.DerivedKeyToken, _parent.SerializerDictionary.Namespace);
			if (derivedKeySecurityToken.Id != null)
			{
				writer.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, derivedKeySecurityToken.Id);
			}
			if (derivedKeySecurityToken.KeyDerivationAlgorithm != _parent.DerivationAlgorithm)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.UnsupportedKeyDerivationAlgorithm, derivedKeySecurityToken.KeyDerivationAlgorithm)));
			}
			_parent.WSSecurityTokenSerializer.WriteKeyIdentifierClause(writer, derivedKeySecurityToken.TokenToDeriveIdentifier);
			if (derivedKeySecurityToken.Generation > 0 || derivedKeySecurityToken.Offset > 0 || derivedKeySecurityToken.Length != 32)
			{
				if (derivedKeySecurityToken.Generation >= 0 && derivedKeySecurityToken.Offset >= 0)
				{
					writer.WriteStartElement(value, _parent.SerializerDictionary.Generation, _parent.SerializerDictionary.Namespace);
					writer.WriteValue(derivedKeySecurityToken.Generation);
					writer.WriteEndElement();
				}
				else if (derivedKeySecurityToken.Generation != -1)
				{
					writer.WriteStartElement(value, _parent.SerializerDictionary.Generation, _parent.SerializerDictionary.Namespace);
					writer.WriteValue(derivedKeySecurityToken.Generation);
					writer.WriteEndElement();
				}
				else if (derivedKeySecurityToken.Offset != -1)
				{
					writer.WriteStartElement(value, _parent.SerializerDictionary.Offset, _parent.SerializerDictionary.Namespace);
					writer.WriteValue(derivedKeySecurityToken.Offset);
					writer.WriteEndElement();
				}
				if (derivedKeySecurityToken.Length != 32)
				{
					writer.WriteStartElement(value, _parent.SerializerDictionary.Length, _parent.SerializerDictionary.Namespace);
					writer.WriteValue(derivedKeySecurityToken.Length);
					writer.WriteEndElement();
				}
			}
			if (derivedKeySecurityToken.Label != null)
			{
				writer.WriteStartElement(value, _parent.SerializerDictionary.Generation, _parent.SerializerDictionary.Namespace);
				writer.WriteString(derivedKeySecurityToken.Label);
				writer.WriteEndElement();
			}
			writer.WriteStartElement(value, _parent.SerializerDictionary.Nonce, _parent.SerializerDictionary.Namespace);
			writer.WriteBase64(derivedKeySecurityToken.Nonce, 0, derivedKeySecurityToken.Nonce.Length);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	protected abstract class SecurityContextTokenEntry : WSSecurityTokenSerializer.TokenEntry
	{
		protected WSSecureConversation Parent { get; }

		protected override XmlDictionaryString LocalName => Parent.SerializerDictionary.SecurityContextToken;

		protected override XmlDictionaryString NamespaceUri => Parent.SerializerDictionary.Namespace;

		public override string TokenTypeUri => Parent.SerializerDictionary.SecurityContextTokenType.Value;

		protected override string ValueTypeUri => null;

		public SecurityContextTokenEntry(WSSecureConversation parent, SecurityStateEncoder securityStateEncoder, IList<Type> knownClaimTypes)
		{
			Parent = parent;
		}

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(SecurityContextSecurityToken) };
		}

		public override SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXmlCore(XmlElement issuedTokenXml, SecurityTokenReferenceStyle tokenReferenceStyle)
		{
			TokenReferenceStyleHelper.Validate(tokenReferenceStyle);
			switch (tokenReferenceStyle)
			{
			case SecurityTokenReferenceStyle.Internal:
				return WSSecurityTokenSerializer.TokenEntry.CreateDirectReference(issuedTokenXml, "Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", typeof(SecurityContextSecurityToken));
			case SecurityTokenReferenceStyle.External:
			{
				UniqueId contextId = null;
				UniqueId generation = null;
				foreach (XmlNode childNode in issuedTokenXml.ChildNodes)
				{
					if (childNode is XmlElement xmlElement)
					{
						if (xmlElement.LocalName == Parent.SerializerDictionary.Identifier.Value && xmlElement.NamespaceURI == Parent.SerializerDictionary.Namespace.Value)
						{
							contextId = XmlHelper.ReadTextElementAsUniqueId(xmlElement);
						}
						else if (CanReadGeneration(xmlElement))
						{
							generation = ReadGeneration(xmlElement);
						}
					}
				}
				return new SecurityContextKeyIdentifierClause(contextId, generation);
			}
			default:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("tokenReferenceStyle"));
			}
		}

		protected abstract bool CanReadGeneration(XmlDictionaryReader reader);

		protected abstract bool CanReadGeneration(XmlElement element);

		protected abstract UniqueId ReadGeneration(XmlDictionaryReader reader);

		protected abstract UniqueId ReadGeneration(XmlElement element);

		private SecurityContextSecurityToken TryResolveSecurityContextToken(UniqueId contextId, UniqueId generation, string id, SecurityTokenResolver tokenResolver, out ISecurityContextSecurityTokenCache sctCache)
		{
			SecurityContextSecurityToken securityContextSecurityToken = null;
			sctCache = null;
			if (tokenResolver is ISecurityContextSecurityTokenCache)
			{
				sctCache = (ISecurityContextSecurityTokenCache)tokenResolver;
				securityContextSecurityToken = sctCache.GetContext(contextId, generation);
			}
			else if (tokenResolver is AggregateSecurityHeaderTokenResolver)
			{
				AggregateSecurityHeaderTokenResolver aggregateSecurityHeaderTokenResolver = tokenResolver as AggregateSecurityHeaderTokenResolver;
				for (int i = 0; i < aggregateSecurityHeaderTokenResolver.TokenResolvers.Count; i++)
				{
					if (aggregateSecurityHeaderTokenResolver.TokenResolvers[i] is ISecurityContextSecurityTokenCache securityContextSecurityTokenCache)
					{
						if (sctCache == null)
						{
							sctCache = securityContextSecurityTokenCache;
						}
						securityContextSecurityToken = securityContextSecurityTokenCache.GetContext(contextId, generation);
						if (securityContextSecurityToken != null)
						{
							break;
						}
					}
				}
			}
			if (securityContextSecurityToken == null)
			{
				return null;
			}
			if (securityContextSecurityToken.Id == id)
			{
				return securityContextSecurityToken;
			}
			return new SecurityContextSecurityToken(securityContextSecurityToken, id);
		}

		public override SecurityToken ReadTokenCore(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver)
		{
			UniqueId uniqueId = null;
			byte[] array = null;
			UniqueId uniqueId2 = null;
			bool flag = false;
			string attribute = reader.GetAttribute(XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace);
			SecurityContextSecurityToken securityContextSecurityToken = null;
			reader.ReadFullStartElement();
			reader.MoveToStartElement(Parent.SerializerDictionary.Identifier, Parent.SerializerDictionary.Namespace);
			uniqueId = reader.ReadElementContentAsUniqueId();
			if (CanReadGeneration(reader))
			{
				uniqueId2 = ReadGeneration(reader);
			}
			if (reader.IsStartElement(Parent.SerializerDictionary.Cookie, XD.DotNetSecurityDictionary.Namespace))
			{
				flag = true;
				securityContextSecurityToken = TryResolveSecurityContextToken(uniqueId, uniqueId2, attribute, tokenResolver, out var _);
				if (securityContextSecurityToken == null)
				{
					array = reader.ReadElementContentAsBase64();
					if (array != null)
					{
						throw new PlatformNotSupportedException();
					}
				}
				else
				{
					reader.Skip();
				}
			}
			reader.ReadEndElement();
			if (uniqueId == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.NoSecurityContextIdentifier));
			}
			if (securityContextSecurityToken == null && !flag)
			{
				securityContextSecurityToken = TryResolveSecurityContextToken(uniqueId, uniqueId2, attribute, tokenResolver, out var _);
			}
			if (securityContextSecurityToken == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new SecurityContextTokenValidationException(System.SR.Format(System.SR.SecurityContextNotRegistered, uniqueId, uniqueId2)));
			}
			return securityContextSecurityToken;
		}

		protected virtual void WriteGeneration(XmlDictionaryWriter writer, SecurityContextSecurityToken sct)
		{
		}

		public override void WriteTokenCore(XmlDictionaryWriter writer, SecurityToken token)
		{
			SecurityContextSecurityToken securityContextSecurityToken = token as SecurityContextSecurityToken;
			writer.WriteStartElement(Parent.SerializerDictionary.Prefix.Value, Parent.SerializerDictionary.SecurityContextToken, Parent.SerializerDictionary.Namespace);
			if (securityContextSecurityToken.Id != null)
			{
				writer.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, securityContextSecurityToken.Id);
			}
			writer.WriteStartElement(Parent.SerializerDictionary.Prefix.Value, Parent.SerializerDictionary.Identifier, Parent.SerializerDictionary.Namespace);
			XmlHelper.WriteStringAsUniqueId(writer, securityContextSecurityToken.ContextId);
			writer.WriteEndElement();
			WriteGeneration(writer, securityContextSecurityToken);
			if (securityContextSecurityToken.IsCookieMode)
			{
				if (securityContextSecurityToken.CookieBlob == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.NoCookieInSct));
				}
				writer.WriteStartElement(XD.DotNetSecurityDictionary.Prefix.Value, Parent.SerializerDictionary.Cookie, XD.DotNetSecurityDictionary.Namespace);
				writer.WriteBase64(securityContextSecurityToken.CookieBlob, 0, securityContextSecurityToken.CookieBlob.Length);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
	}

	public abstract class Driver : SecureConversationDriver
	{
		protected abstract SecureConversationDictionary DriverDictionary { get; }

		public override XmlDictionaryString IssueAction => DriverDictionary.RequestSecurityContextIssuance;

		public override XmlDictionaryString IssueResponseAction => DriverDictionary.RequestSecurityContextIssuanceResponse;

		public override XmlDictionaryString RenewNeededFaultCode => DriverDictionary.RenewNeededFaultCode;

		public override XmlDictionaryString BadContextTokenFaultCode => DriverDictionary.BadContextTokenFaultCode;

		public Driver()
		{
		}

		public override UniqueId GetSecurityContextTokenId(XmlDictionaryReader reader)
		{
			if (reader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
			}
			reader.ReadStartElement(DriverDictionary.SecurityContextToken, DriverDictionary.Namespace);
			UniqueId result = XmlHelper.ReadElementStringAsUniqueId(reader, DriverDictionary.Identifier, DriverDictionary.Namespace);
			while (reader.IsStartElement())
			{
				reader.Skip();
			}
			reader.ReadEndElement();
			return result;
		}

		public override bool IsAtSecurityContextToken(XmlDictionaryReader reader)
		{
			if (reader == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
			}
			return reader.IsStartElement(DriverDictionary.SecurityContextToken, DriverDictionary.Namespace);
		}
	}

	private DerivedKeyTokenEntry _derivedKeyEntry;

	public abstract SecureConversationDictionary SerializerDictionary { get; }

	public WSSecurityTokenSerializer WSSecurityTokenSerializer { get; }

	public virtual string DerivationAlgorithm => "http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1";

	protected WSSecureConversation(WSSecurityTokenSerializer tokenSerializer, int maxKeyDerivationOffset, int maxKeyDerivationLabelLength, int maxKeyDerivationNonceLength)
	{
		WSSecurityTokenSerializer = tokenSerializer ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenSerializer");
		_derivedKeyEntry = new DerivedKeyTokenEntry(this, maxKeyDerivationOffset, maxKeyDerivationLabelLength, maxKeyDerivationNonceLength);
	}

	public override void PopulateTokenEntries(IList<WSSecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		if (tokenEntryList == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenEntryList");
		}
		tokenEntryList.Add(_derivedKeyEntry);
	}

	public virtual bool IsAtDerivedKeyToken(XmlDictionaryReader reader)
	{
		return _derivedKeyEntry.CanReadTokenCore(reader);
	}

	public virtual void ReadDerivedKeyTokenParameters(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver, out string id, out string derivationAlgorithm, out string label, out int length, out byte[] nonce, out int offset, out int generation, out SecurityKeyIdentifierClause tokenToDeriveIdentifier, out SecurityToken tokenToDerive)
	{
		_derivedKeyEntry.ReadDerivedKeyTokenParameters(reader, tokenResolver, out id, out derivationAlgorithm, out label, out length, out nonce, out offset, out generation, out tokenToDeriveIdentifier, out tokenToDerive);
	}

	public virtual SecurityToken CreateDerivedKeyToken(string id, string derivationAlgorithm, string label, int length, byte[] nonce, int offset, int generation, SecurityKeyIdentifierClause tokenToDeriveIdentifier, SecurityToken tokenToDerive)
	{
		return _derivedKeyEntry.CreateDerivedKeyToken(id, derivationAlgorithm, label, length, nonce, offset, generation, tokenToDeriveIdentifier, tokenToDerive);
	}
}
