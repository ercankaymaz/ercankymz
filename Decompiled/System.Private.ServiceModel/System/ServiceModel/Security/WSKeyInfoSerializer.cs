using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal class WSKeyInfoSerializer : KeyInfoSerializer
{
	private abstract class WSSecureConversation : SerializerEntries
	{
		protected abstract class SctStrEntry : StrEntry
		{
			protected WSSecureConversation Parent { get; }

			public SctStrEntry(WSSecureConversation parent)
			{
				Parent = parent;
			}

			public override Type GetTokenType(SecurityKeyIdentifierClause clause)
			{
				return null;
			}

			public override string GetTokenTypeUri()
			{
				return null;
			}

			public override bool CanReadClause(XmlDictionaryReader reader, string tokenType)
			{
				if (tokenType != null && tokenType != Parent.SerializerDictionary.SecurityContextTokenType.Value)
				{
					return false;
				}
				if (reader.IsStartElement(Parent.SecurityTokenSerializer.DictionaryManager.SecurityJan2004Dictionary.Reference, Parent.SecurityTokenSerializer.DictionaryManager.SecurityJan2004Dictionary.Namespace))
				{
					string attribute = reader.GetAttribute(Parent.SecurityTokenSerializer.DictionaryManager.SecurityJan2004Dictionary.ValueType, null);
					if (attribute != null && attribute != Parent.SerializerDictionary.SecurityContextTokenReferenceValueType.Value)
					{
						return false;
					}
					string attribute2 = reader.GetAttribute(Parent.SecurityTokenSerializer.DictionaryManager.SecurityJan2004Dictionary.URI, null);
					if (attribute2 != null && attribute2.Length > 0 && attribute2[0] != '#')
					{
						return true;
					}
				}
				return false;
			}

			public override SecurityKeyIdentifierClause ReadClause(XmlDictionaryReader reader, byte[] derivationNonce, int derivationLength, string tokenType)
			{
				UniqueId attributeAsUniqueId = XmlHelper.GetAttributeAsUniqueId(reader, XD.SecurityJan2004Dictionary.URI, null);
				UniqueId generation = ReadGeneration(reader);
				if (reader.IsEmptyElement)
				{
					reader.Read();
				}
				else
				{
					reader.ReadStartElement();
					while (reader.IsStartElement())
					{
						reader.Skip();
					}
					reader.ReadEndElement();
				}
				return new SecurityContextKeyIdentifierClause(attributeAsUniqueId, generation, derivationNonce, derivationLength);
			}

			protected abstract UniqueId ReadGeneration(XmlDictionaryReader reader);

			public override bool SupportsCore(SecurityKeyIdentifierClause clause)
			{
				return clause is SecurityContextKeyIdentifierClause;
			}

			public override void WriteContent(XmlDictionaryWriter writer, SecurityKeyIdentifierClause clause)
			{
				SecurityContextKeyIdentifierClause securityContextKeyIdentifierClause = clause as SecurityContextKeyIdentifierClause;
				writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.Reference, XD.SecurityJan2004Dictionary.Namespace);
				XmlHelper.WriteAttributeStringAsUniqueId(writer, null, XD.SecurityJan2004Dictionary.URI, null, securityContextKeyIdentifierClause.ContextId);
				WriteGeneration(writer, securityContextKeyIdentifierClause);
				writer.WriteAttributeString(XD.SecurityJan2004Dictionary.ValueType, null, Parent.SerializerDictionary.SecurityContextTokenReferenceValueType.Value);
				writer.WriteEndElement();
			}

			protected abstract void WriteGeneration(XmlDictionaryWriter writer, SecurityContextKeyIdentifierClause clause);
		}

		protected class SecurityContextTokenEntry : TokenEntry
		{
			private Type[] _tokenTypes;

			protected WSSecureConversation Parent { get; }

			protected override XmlDictionaryString LocalName => Parent.SerializerDictionary.SecurityContextToken;

			protected override XmlDictionaryString NamespaceUri => Parent.SerializerDictionary.Namespace;

			public override string TokenTypeUri => Parent.SerializerDictionary.SecurityContextTokenType.Value;

			protected override string ValueTypeUri => null;

			public SecurityContextTokenEntry(WSSecureConversation parent)
			{
				Parent = parent;
			}

			protected override Type[] GetTokenTypesCore()
			{
				if (_tokenTypes == null)
				{
					_tokenTypes = new Type[1] { typeof(SecurityContextSecurityToken) };
				}
				return _tokenTypes;
			}
		}

		protected class DerivedKeyTokenEntry : TokenEntry
		{
			public const string DefaultLabel = "WS-SecureConversation";

			private WSSecureConversation _parent;

			private Type[] _tokenTypes;

			protected override XmlDictionaryString LocalName => _parent.SerializerDictionary.DerivedKeyToken;

			protected override XmlDictionaryString NamespaceUri => _parent.SerializerDictionary.Namespace;

			public override string TokenTypeUri => _parent.SerializerDictionary.DerivedKeyTokenType.Value;

			protected override string ValueTypeUri => null;

			public DerivedKeyTokenEntry(WSSecureConversation parent)
			{
				_parent = parent ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
			}

			protected override Type[] GetTokenTypesCore()
			{
				if (_tokenTypes == null)
				{
					_tokenTypes = new Type[1] { typeof(DerivedKeySecurityToken) };
				}
				return _tokenTypes;
			}
		}

		public KeyInfoSerializer SecurityTokenSerializer { get; }

		public abstract System.IdentityModel.SecureConversationDictionary SerializerDictionary { get; }

		public virtual string DerivationAlgorithm => "http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1";

		protected WSSecureConversation(KeyInfoSerializer securityTokenSerializer)
		{
			SecurityTokenSerializer = securityTokenSerializer;
		}

		public override void PopulateTokenEntries(IList<TokenEntry> tokenEntryList)
		{
			if (tokenEntryList == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenEntryList");
			}
			tokenEntryList.Add(new DerivedKeyTokenEntry(this));
			tokenEntryList.Add(new SecurityContextTokenEntry(this));
		}
	}

	private class WSSecureConversationFeb2005 : WSSecureConversation
	{
		private class SctStrEntryFeb2005 : SctStrEntry
		{
			public SctStrEntryFeb2005(WSSecureConversationFeb2005 parent)
				: base(parent)
			{
			}

			protected override UniqueId ReadGeneration(XmlDictionaryReader reader)
			{
				return XmlHelper.GetAttributeAsUniqueId(reader, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary.Instance, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationFeb2005Dictionary.Namespace);
			}

			protected override void WriteGeneration(XmlDictionaryWriter writer, SecurityContextKeyIdentifierClause clause)
			{
				if (clause.Generation != null)
				{
					XmlHelper.WriteAttributeStringAsUniqueId(writer, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationFeb2005Dictionary.Prefix.Value, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary.Instance, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationFeb2005Dictionary.Namespace, clause.Generation);
				}
			}
		}

		public override System.IdentityModel.SecureConversationDictionary SerializerDictionary => base.SecurityTokenSerializer.DictionaryManager.SecureConversationFeb2005Dictionary;

		public WSSecureConversationFeb2005(KeyInfoSerializer securityTokenSerializer)
			: base(securityTokenSerializer)
		{
		}

		public override void PopulateStrEntries(IList<StrEntry> strEntries)
		{
			strEntries.Add(new SctStrEntryFeb2005(this));
		}
	}

	private class WSSecureConversationDec2005 : WSSecureConversation
	{
		private class SctStrEntryDec2005 : SctStrEntry
		{
			public SctStrEntryDec2005(WSSecureConversationDec2005 parent)
				: base(parent)
			{
			}

			protected override UniqueId ReadGeneration(XmlDictionaryReader reader)
			{
				return XmlHelper.GetAttributeAsUniqueId(reader, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary.Instance, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary.Namespace);
			}

			protected override void WriteGeneration(XmlDictionaryWriter writer, SecurityContextKeyIdentifierClause clause)
			{
				if (clause.Generation != null)
				{
					XmlHelper.WriteAttributeStringAsUniqueId(writer, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary.Prefix.Value, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary.Instance, base.Parent.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary.Namespace, clause.Generation);
				}
			}
		}

		public override System.IdentityModel.SecureConversationDictionary SerializerDictionary => base.SecurityTokenSerializer.DictionaryManager.SecureConversationDec2005Dictionary;

		public override string DerivationAlgorithm => "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1";

		public WSSecureConversationDec2005(KeyInfoSerializer securityTokenSerializer)
			: base(securityTokenSerializer)
		{
		}

		public override void PopulateStrEntries(IList<StrEntry> strEntries)
		{
			strEntries.Add(new SctStrEntryDec2005(this));
		}
	}

	private static Func<KeyInfoSerializer, IEnumerable<SerializerEntries>> CreateAdditionalEntries(SecurityVersion securityVersion, SecureConversationVersion secureConversationVersion)
	{
		return delegate(KeyInfoSerializer keyInfoSerializer)
		{
			List<SerializerEntries> list = new List<SerializerEntries>();
			if (securityVersion == SecurityVersion.WSSecurity10)
			{
				list.Add(new System.IdentityModel.Tokens.WSSecurityJan2004(keyInfoSerializer));
			}
			else
			{
				if (securityVersion != SecurityVersion.WSSecurity11)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("securityVersion", System.SR.MessageSecurityVersionOutOfRange));
				}
				list.Add(new System.IdentityModel.Tokens.WSSecurityXXX2005(keyInfoSerializer));
			}
			if (secureConversationVersion == SecureConversationVersion.WSSecureConversationFeb2005)
			{
				list.Add(new WSSecureConversationFeb2005(keyInfoSerializer));
			}
			else
			{
				if (secureConversationVersion != SecureConversationVersion.WSSecureConversation13)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
				}
				list.Add(new WSSecureConversationDec2005(keyInfoSerializer));
			}
			return list;
		};
	}

	public WSKeyInfoSerializer(bool emitBspRequiredAttributes, DictionaryManager dictionaryManager, System.IdentityModel.TrustDictionary trustDictionary, SecurityTokenSerializer innerSecurityTokenSerializer, SecurityVersion securityVersion, SecureConversationVersion secureConversationVersion)
		: base(emitBspRequiredAttributes, dictionaryManager, trustDictionary, innerSecurityTokenSerializer, CreateAdditionalEntries(securityVersion, secureConversationVersion))
	{
	}
}
