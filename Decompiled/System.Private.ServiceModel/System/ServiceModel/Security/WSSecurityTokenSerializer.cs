using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.ServiceModel.Security.Tokens;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Security;

public class WSSecurityTokenSerializer : SecurityTokenSerializer
{
	internal new abstract class TokenEntry
	{
		private Type[] _tokenTypes;

		protected abstract XmlDictionaryString LocalName { get; }

		protected abstract XmlDictionaryString NamespaceUri { get; }

		public Type TokenType => GetTokenTypes()[0];

		public abstract string TokenTypeUri { get; }

		protected abstract string ValueTypeUri { get; }

		protected abstract Type[] GetTokenTypesCore();

		public Type[] GetTokenTypes()
		{
			if (_tokenTypes == null)
			{
				_tokenTypes = GetTokenTypesCore();
			}
			return _tokenTypes;
		}

		public bool SupportsCore(Type tokenType)
		{
			Type[] tokenTypes = GetTokenTypes();
			for (int i = 0; i < tokenTypes.Length; i++)
			{
				if (tokenTypes[i].IsAssignableFrom(tokenType))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool SupportsTokenTypeUri(string tokenTypeUri)
		{
			return TokenTypeUri == tokenTypeUri;
		}

		protected static SecurityKeyIdentifierClause CreateDirectReference(XmlElement issuedTokenXml, string idAttributeLocalName, string idAttributeNamespace, Type tokenType)
		{
			string attribute = issuedTokenXml.GetAttribute(idAttributeLocalName, idAttributeNamespace);
			if (attribute == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.RequiredAttributeMissing, idAttributeLocalName, issuedTokenXml.LocalName)));
			}
			return new LocalIdKeyIdentifierClause(attribute, tokenType);
		}

		public virtual bool CanReadTokenCore(XmlElement element)
		{
			string text = null;
			if (element.HasAttribute("ValueType", null))
			{
				text = element.GetAttribute("ValueType", null);
			}
			if (element.LocalName == LocalName.Value && element.NamespaceURI == NamespaceUri.Value)
			{
				return text == ValueTypeUri;
			}
			return false;
		}

		public virtual bool CanReadTokenCore(XmlDictionaryReader reader)
		{
			if (reader.IsStartElement(LocalName, NamespaceUri))
			{
				return reader.GetAttribute(XD.SecurityJan2004Dictionary.ValueType, null) == ValueTypeUri;
			}
			return false;
		}

		public virtual Task<SecurityToken> ReadTokenCoreAsync(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver)
		{
			return Task.FromResult(ReadTokenCore(reader, tokenResolver));
		}

		public abstract SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXmlCore(XmlElement issuedTokenXml, SecurityTokenReferenceStyle tokenReferenceStyle);

		public abstract SecurityToken ReadTokenCore(XmlDictionaryReader reader, SecurityTokenResolver tokenResolver);

		public abstract void WriteTokenCore(XmlDictionaryWriter writer, SecurityToken token);
	}

	internal new abstract class SerializerEntries
	{
		public virtual void PopulateTokenEntries(IList<TokenEntry> tokenEntries)
		{
		}
	}

	internal class CollectionDictionary : IXmlDictionary
	{
		private List<XmlDictionaryString> _dictionaryStrings;

		public CollectionDictionary(List<XmlDictionaryString> dictionaryStrings)
		{
			_dictionaryStrings = dictionaryStrings ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("dictionaryStrings"));
		}

		public bool TryLookup(string value, out XmlDictionaryString result)
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			for (int i = 0; i < _dictionaryStrings.Count; i++)
			{
				if (_dictionaryStrings[i].Value.Equals(value))
				{
					result = _dictionaryStrings[i];
					return true;
				}
			}
			result = null;
			return false;
		}

		public bool TryLookup(int key, out XmlDictionaryString result)
		{
			for (int i = 0; i < _dictionaryStrings.Count; i++)
			{
				if (_dictionaryStrings[i].Key == key)
				{
					result = _dictionaryStrings[i];
					return true;
				}
			}
			result = null;
			return false;
		}

		public bool TryLookup(XmlDictionaryString value, out XmlDictionaryString result)
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("value"));
			}
			for (int i = 0; i < _dictionaryStrings.Count; i++)
			{
				if (_dictionaryStrings[i].Key == value.Key && _dictionaryStrings[i].Value.Equals(value.Value))
				{
					result = _dictionaryStrings[i];
					return true;
				}
			}
			result = null;
			return false;
		}
	}

	private const int DefaultMaximumKeyDerivationOffset = 64;

	private const int DefaultMaximumKeyDerivationLabelLength = 128;

	private const int DefaultMaximumKeyDerivationNonceLength = 128;

	private static WSSecurityTokenSerializer s_instance;

	private readonly List<SerializerEntries> _serializerEntries;

	private WSSecureConversation _secureConversation;

	private readonly List<TokenEntry> _tokenEntries = new List<TokenEntry>();

	private int _maximumKeyDerivationNonceLength;

	private KeyInfoSerializer _keyInfoSerializer;

	public static WSSecurityTokenSerializer DefaultInstance
	{
		get
		{
			if (s_instance == null)
			{
				s_instance = new WSSecurityTokenSerializer();
			}
			return s_instance;
		}
	}

	public bool EmitBspRequiredAttributes { get; }

	public SecurityVersion SecurityVersion { get; }

	public int MaximumKeyDerivationOffset { get; }

	public int MaximumKeyDerivationLabelLength { get; }

	public int MaximumKeyDerivationNonceLength => _maximumKeyDerivationNonceLength;

	public WSSecurityTokenSerializer()
		: this(SecurityVersion.WSSecurity11)
	{
	}

	public WSSecurityTokenSerializer(bool emitBspRequiredAttributes)
		: this(SecurityVersion.WSSecurity11, emitBspRequiredAttributes)
	{
	}

	public WSSecurityTokenSerializer(SecurityVersion securityVersion)
		: this(securityVersion, emitBspRequiredAttributes: false)
	{
	}

	public WSSecurityTokenSerializer(SecurityVersion securityVersion, bool emitBspRequiredAttributes)
		: this(securityVersion, emitBspRequiredAttributes, null)
	{
	}

	public WSSecurityTokenSerializer(SecurityVersion securityVersion, bool emitBspRequiredAttributes, SamlSerializer samlSerializer)
		: this(securityVersion, emitBspRequiredAttributes, samlSerializer, null, null)
	{
	}

	public WSSecurityTokenSerializer(SecurityVersion securityVersion, bool emitBspRequiredAttributes, SamlSerializer samlSerializer, SecurityStateEncoder securityStateEncoder, IEnumerable<Type> knownTypes)
		: this(securityVersion, emitBspRequiredAttributes, samlSerializer, securityStateEncoder, knownTypes, 64, 128, 128)
	{
	}

	public WSSecurityTokenSerializer(SecurityVersion securityVersion, TrustVersion trustVersion, SecureConversationVersion secureConversationVersion, bool emitBspRequiredAttributes, SamlSerializer samlSerializer, SecurityStateEncoder securityStateEncoder, IEnumerable<Type> knownTypes)
		: this(securityVersion, trustVersion, secureConversationVersion, emitBspRequiredAttributes, samlSerializer, securityStateEncoder, knownTypes, 64, 128, 128)
	{
	}

	public WSSecurityTokenSerializer(SecurityVersion securityVersion, bool emitBspRequiredAttributes, SamlSerializer samlSerializer, SecurityStateEncoder securityStateEncoder, IEnumerable<Type> knownTypes, int maximumKeyDerivationOffset, int maximumKeyDerivationLabelLength, int maximumKeyDerivationNonceLength)
		: this(securityVersion, TrustVersion.Default, SecureConversationVersion.Default, emitBspRequiredAttributes, samlSerializer, securityStateEncoder, knownTypes, maximumKeyDerivationOffset, maximumKeyDerivationLabelLength, maximumKeyDerivationNonceLength)
	{
	}

	public WSSecurityTokenSerializer(SecurityVersion securityVersion, TrustVersion trustVersion, SecureConversationVersion secureConversationVersion, bool emitBspRequiredAttributes, SamlSerializer samlSerializer, SecurityStateEncoder securityStateEncoder, IEnumerable<Type> knownTypes, int maximumKeyDerivationOffset, int maximumKeyDerivationLabelLength, int maximumKeyDerivationNonceLength)
	{
		if (maximumKeyDerivationOffset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maximumKeyDerivationOffset", System.SR.ValueMustBeNonNegative));
		}
		if (maximumKeyDerivationLabelLength < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maximumKeyDerivationLabelLength", System.SR.ValueMustBeNonNegative));
		}
		if (maximumKeyDerivationNonceLength <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maximumKeyDerivationNonceLength", System.SR.ValueMustBeGreaterThanZero));
		}
		SecurityVersion = securityVersion ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("securityVersion"));
		EmitBspRequiredAttributes = emitBspRequiredAttributes;
		MaximumKeyDerivationOffset = maximumKeyDerivationOffset;
		_maximumKeyDerivationNonceLength = maximumKeyDerivationNonceLength;
		MaximumKeyDerivationLabelLength = maximumKeyDerivationLabelLength;
		_serializerEntries = new List<SerializerEntries>();
		if (secureConversationVersion == SecureConversationVersion.WSSecureConversationFeb2005)
		{
			_secureConversation = new WSSecureConversationFeb2005(this, securityStateEncoder, knownTypes, maximumKeyDerivationOffset, maximumKeyDerivationLabelLength, maximumKeyDerivationNonceLength);
		}
		else
		{
			if (secureConversationVersion != SecureConversationVersion.WSSecureConversation13)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
			}
			_secureConversation = new WSSecureConversationDec2005(this, securityStateEncoder, knownTypes, maximumKeyDerivationOffset, maximumKeyDerivationLabelLength, maximumKeyDerivationNonceLength);
		}
		if (securityVersion == SecurityVersion.WSSecurity10)
		{
			_serializerEntries.Add(new WSSecurityJan2004(this, samlSerializer));
		}
		else
		{
			if (securityVersion != SecurityVersion.WSSecurity11)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("securityVersion", System.SR.MessageSecurityVersionOutOfRange));
			}
			_serializerEntries.Add(new WSSecurityXXX2005(this, samlSerializer));
		}
		_serializerEntries.Add(_secureConversation);
		System.IdentityModel.TrustDictionary trustDictionary;
		if (trustVersion == TrustVersion.WSTrustFeb2005)
		{
			_serializerEntries.Add(new WSTrustFeb2005(this));
			trustDictionary = new System.IdentityModel.TrustFeb2005Dictionary(new CollectionDictionary(DXD.TrustDec2005Dictionary.Feb2005DictionaryStrings));
		}
		else
		{
			if (trustVersion != TrustVersion.WSTrust13)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
			}
			_serializerEntries.Add(new WSTrustDec2005(this));
			trustDictionary = new System.IdentityModel.TrustDec2005Dictionary(new CollectionDictionary(DXD.TrustDec2005Dictionary.Dec2005DictionaryString));
		}
		_tokenEntries = new List<TokenEntry>();
		for (int i = 0; i < _serializerEntries.Count; i++)
		{
			SerializerEntries serializerEntries = _serializerEntries[i];
			serializerEntries.PopulateTokenEntries(_tokenEntries);
		}
		DictionaryManager dictionaryManager = new DictionaryManager(ServiceModelDictionary.CurrentVersion)
		{
			SecureConversationDec2005Dictionary = new System.IdentityModel.SecureConversationDec2005Dictionary(new CollectionDictionary(DXD.SecureConversationDec2005Dictionary.SecureConversationDictionaryStrings)),
			SecurityAlgorithmDec2005Dictionary = new System.IdentityModel.SecurityAlgorithmDec2005Dictionary(new CollectionDictionary(DXD.SecurityAlgorithmDec2005Dictionary.SecurityAlgorithmDictionaryStrings))
		};
		_keyInfoSerializer = new WSKeyInfoSerializer(EmitBspRequiredAttributes, dictionaryManager, trustDictionary, this, securityVersion, secureConversationVersion);
	}

	private bool ShouldWrapException(Exception e)
	{
		if (Fx.IsFatal(e))
		{
			return false;
		}
		if (!(e is ArgumentException) && !(e is FormatException))
		{
			return e is InvalidOperationException;
		}
		return true;
	}

	protected override bool CanReadTokenCore(XmlReader reader)
	{
		XmlDictionaryReader reader2 = XmlDictionaryReader.CreateDictionaryReader(reader);
		for (int i = 0; i < _tokenEntries.Count; i++)
		{
			TokenEntry tokenEntry = _tokenEntries[i];
			if (tokenEntry.CanReadTokenCore(reader2))
			{
				return true;
			}
		}
		return false;
	}

	protected override SecurityToken ReadTokenCore(XmlReader reader, SecurityTokenResolver tokenResolver)
	{
		XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader);
		for (int i = 0; i < _tokenEntries.Count; i++)
		{
			TokenEntry tokenEntry = _tokenEntries[i];
			if (!tokenEntry.CanReadTokenCore(xmlDictionaryReader))
			{
				continue;
			}
			try
			{
				return tokenEntry.ReadTokenCore(xmlDictionaryReader, tokenResolver);
			}
			catch (Exception ex)
			{
				if (!ShouldWrapException(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.ErrorDeserializingTokenXml, ex));
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CannotReadToken, reader.LocalName, reader.NamespaceURI, xmlDictionaryReader.GetAttribute(XD.SecurityJan2004Dictionary.ValueType, null))));
	}

	protected override bool CanWriteTokenCore(SecurityToken token)
	{
		for (int i = 0; i < _tokenEntries.Count; i++)
		{
			TokenEntry tokenEntry = _tokenEntries[i];
			if (tokenEntry.SupportsCore(token.GetType()))
			{
				return true;
			}
		}
		return false;
	}

	protected override void WriteTokenCore(XmlWriter writer, SecurityToken token)
	{
		bool flag = false;
		XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		for (int i = 0; i < _tokenEntries.Count; i++)
		{
			TokenEntry tokenEntry = _tokenEntries[i];
			if (!tokenEntry.SupportsCore(token.GetType()))
			{
				continue;
			}
			try
			{
				tokenEntry.WriteTokenCore(xmlDictionaryWriter, token);
			}
			catch (Exception ex)
			{
				if (!ShouldWrapException(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ErrorSerializingSecurityToken), ex));
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.StandardsManagerCannotWriteObject, token.GetType())));
		}
		xmlDictionaryWriter.Flush();
	}

	protected override bool CanReadKeyIdentifierCore(XmlReader reader)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override SecurityKeyIdentifier ReadKeyIdentifierCore(XmlReader reader)
	{
		try
		{
			return _keyInfoSerializer.ReadKeyIdentifier(reader);
		}
		catch (SecurityMessageSerializationException ex)
		{
			throw FxTrace.Exception.AsError(new MessageSecurityException(ex.Message));
		}
	}

	protected override bool CanWriteKeyIdentifierCore(SecurityKeyIdentifier keyIdentifier)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override void WriteKeyIdentifierCore(XmlWriter writer, SecurityKeyIdentifier keyIdentifier)
	{
		try
		{
			_keyInfoSerializer.WriteKeyIdentifier(writer, keyIdentifier);
		}
		catch (SecurityMessageSerializationException ex)
		{
			throw FxTrace.Exception.AsError(new MessageSecurityException(ex.Message));
		}
	}

	protected override bool CanReadKeyIdentifierClauseCore(XmlReader reader)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override SecurityKeyIdentifierClause ReadKeyIdentifierClauseCore(XmlReader reader)
	{
		try
		{
			return _keyInfoSerializer.ReadKeyIdentifierClause(reader);
		}
		catch (SecurityMessageSerializationException ex)
		{
			throw FxTrace.Exception.AsError(new MessageSecurityException(ex.Message));
		}
	}

	protected override bool CanWriteKeyIdentifierClauseCore(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected override void WriteKeyIdentifierClauseCore(XmlWriter writer, SecurityKeyIdentifierClause keyIdentifierClause)
	{
		try
		{
			_keyInfoSerializer.WriteKeyIdentifierClause(writer, keyIdentifierClause);
		}
		catch (SecurityMessageSerializationException ex)
		{
			throw FxTrace.Exception.AsError(new MessageSecurityException(ex.Message));
		}
	}

	internal Type[] GetTokenTypes(string tokenTypeUri)
	{
		if (tokenTypeUri != null)
		{
			for (int i = 0; i < _tokenEntries.Count; i++)
			{
				TokenEntry tokenEntry = _tokenEntries[i];
				if (tokenEntry.SupportsTokenTypeUri(tokenTypeUri))
				{
					return tokenEntry.GetTokenTypes();
				}
			}
		}
		return null;
	}

	protected internal virtual string GetTokenTypeUri(Type tokenType)
	{
		if (tokenType != null)
		{
			for (int i = 0; i < _tokenEntries.Count; i++)
			{
				TokenEntry tokenEntry = _tokenEntries[i];
				if (tokenEntry.SupportsCore(tokenType))
				{
					return tokenEntry.TokenTypeUri;
				}
			}
		}
		return null;
	}

	public virtual bool TryCreateKeyIdentifierClauseFromTokenXml(XmlElement element, SecurityTokenReferenceStyle tokenReferenceStyle, out SecurityKeyIdentifierClause securityKeyIdentifierClause)
	{
		if (element == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
		}
		securityKeyIdentifierClause = null;
		try
		{
			securityKeyIdentifierClause = CreateKeyIdentifierClauseFromTokenXml(element, tokenReferenceStyle);
		}
		catch (XmlException)
		{
			return false;
		}
		return true;
	}

	public virtual SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXml(XmlElement element, SecurityTokenReferenceStyle tokenReferenceStyle)
	{
		if (element == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
		}
		for (int i = 0; i < _tokenEntries.Count; i++)
		{
			TokenEntry tokenEntry = _tokenEntries[i];
			if (!tokenEntry.CanReadTokenCore(element))
			{
				continue;
			}
			try
			{
				return tokenEntry.CreateKeyIdentifierClauseFromTokenXmlCore(element, tokenReferenceStyle);
			}
			catch (Exception ex)
			{
				if (!ShouldWrapException(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.ErrorDeserializingKeyIdentifierClauseFromTokenXml, ex));
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CannotReadToken, element.LocalName, element.NamespaceURI, element.GetAttribute("ValueType", null))));
	}
}
