using System.Collections.Generic;
using System.IdentityModel.Security;
using System.IdentityModel.Selectors;
using System.Runtime;
using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel.Tokens;

internal class KeyInfoSerializer : SecurityTokenSerializer
{
	private readonly List<KeyIdentifierEntry> _keyIdentifierEntries;

	private readonly List<KeyIdentifierClauseEntry> _keyIdentifierClauseEntries;

	private readonly List<SerializerEntries> _serializerEntries;

	private readonly List<TokenEntry> _tokenEntries;

	private SecurityTokenSerializer _innerSecurityTokenSerializer;

	public DictionaryManager DictionaryManager { get; }

	public bool EmitBspRequiredAttributes { get; }

	public SecurityTokenSerializer InnerSecurityTokenSerializer
	{
		get
		{
			if (_innerSecurityTokenSerializer != null)
			{
				return _innerSecurityTokenSerializer;
			}
			return this;
		}
		set
		{
			_innerSecurityTokenSerializer = value;
		}
	}

	public KeyInfoSerializer(bool emitBspRequiredAttributes)
		: this(emitBspRequiredAttributes, new DictionaryManager(), XD.TrustDec2005Dictionary, null)
	{
	}

	public KeyInfoSerializer(bool emitBspRequiredAttributes, DictionaryManager dictionaryManager, TrustDictionary trustDictionary, SecurityTokenSerializer innerSecurityTokenSerializer)
		: this(emitBspRequiredAttributes, dictionaryManager, trustDictionary, innerSecurityTokenSerializer, null)
	{
	}

	public KeyInfoSerializer(bool emitBspRequiredAttributes, DictionaryManager dictionaryManager, TrustDictionary trustDictionary, SecurityTokenSerializer innerSecurityTokenSerializer, Func<KeyInfoSerializer, IEnumerable<SerializerEntries>> additionalEntries)
	{
		DictionaryManager = dictionaryManager;
		EmitBspRequiredAttributes = emitBspRequiredAttributes;
		_innerSecurityTokenSerializer = innerSecurityTokenSerializer;
		_serializerEntries = new List<SerializerEntries>();
		_serializerEntries.Add(new XmlDsigSep2000(this));
		_serializerEntries.Add(new WSTrust(this, trustDictionary));
		if (additionalEntries != null)
		{
			foreach (SerializerEntries item in additionalEntries(this))
			{
				_serializerEntries.Add(item);
			}
		}
		bool flag = false;
		foreach (SerializerEntries serializerEntry in _serializerEntries)
		{
			if (serializerEntry is WSSecurityXXX2005 || serializerEntry is WSSecurityJan2004)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			_serializerEntries.Add(new WSSecurityXXX2005(this));
		}
		_tokenEntries = new List<TokenEntry>();
		_keyIdentifierEntries = new List<KeyIdentifierEntry>();
		_keyIdentifierClauseEntries = new List<KeyIdentifierClauseEntry>();
		for (int i = 0; i < _serializerEntries.Count; i++)
		{
			SerializerEntries serializerEntries = _serializerEntries[i];
			serializerEntries.PopulateTokenEntries(_tokenEntries);
			serializerEntries.PopulateKeyIdentifierEntries(_keyIdentifierEntries);
			serializerEntries.PopulateKeyIdentifierClauseEntries(_keyIdentifierClauseEntries);
		}
	}

	protected override bool CanReadTokenCore(XmlReader reader)
	{
		return false;
	}

	protected override SecurityToken ReadTokenCore(XmlReader reader, SecurityTokenResolver tokenResolver)
	{
		XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader);
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CannotReadToken, reader.LocalName, reader.NamespaceURI, xmlDictionaryReader.GetAttribute(XD.SecurityJan2004Dictionary.ValueType, null))));
	}

	protected override bool CanWriteTokenCore(SecurityToken token)
	{
		return false;
	}

	protected override void WriteTokenCore(XmlWriter writer, SecurityToken token)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.StandardsManagerCannotWriteObject, token.GetType())));
	}

	protected override bool CanReadKeyIdentifierCore(XmlReader reader)
	{
		XmlDictionaryReader reader2 = XmlDictionaryReader.CreateDictionaryReader(reader);
		for (int i = 0; i < _keyIdentifierEntries.Count; i++)
		{
			KeyIdentifierEntry keyIdentifierEntry = _keyIdentifierEntries[i];
			if (keyIdentifierEntry.CanReadKeyIdentifierCore(reader2))
			{
				return true;
			}
		}
		return false;
	}

	protected override SecurityKeyIdentifier ReadKeyIdentifierCore(XmlReader reader)
	{
		XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader);
		xmlDictionaryReader.ReadStartElement(XD.XmlSignatureDictionary.KeyInfo, XD.XmlSignatureDictionary.Namespace);
		SecurityKeyIdentifier securityKeyIdentifier = new SecurityKeyIdentifier();
		while (xmlDictionaryReader.IsStartElement())
		{
			SecurityKeyIdentifierClause securityKeyIdentifierClause = InnerSecurityTokenSerializer.ReadKeyIdentifierClause(xmlDictionaryReader);
			if (securityKeyIdentifierClause == null)
			{
				xmlDictionaryReader.Skip();
			}
			else
			{
				securityKeyIdentifier.Add(securityKeyIdentifierClause);
			}
		}
		if (securityKeyIdentifier.Count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ErrorDeserializingKeyIdentifierClause)));
		}
		xmlDictionaryReader.ReadEndElement();
		return securityKeyIdentifier;
	}

	protected override bool CanWriteKeyIdentifierCore(SecurityKeyIdentifier keyIdentifier)
	{
		for (int i = 0; i < _keyIdentifierEntries.Count; i++)
		{
			KeyIdentifierEntry keyIdentifierEntry = _keyIdentifierEntries[i];
			if (keyIdentifierEntry.SupportsCore(keyIdentifier))
			{
				return true;
			}
		}
		return false;
	}

	protected override void WriteKeyIdentifierCore(XmlWriter writer, SecurityKeyIdentifier keyIdentifier)
	{
		bool flag = false;
		XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		for (int i = 0; i < _keyIdentifierEntries.Count; i++)
		{
			KeyIdentifierEntry keyIdentifierEntry = _keyIdentifierEntries[i];
			if (!keyIdentifierEntry.SupportsCore(keyIdentifier))
			{
				continue;
			}
			try
			{
				keyIdentifierEntry.WriteKeyIdentifierCore(xmlDictionaryWriter, keyIdentifier);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (!ShouldWrapException(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ErrorSerializingKeyIdentifier), ex));
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.StandardsManagerCannotWriteObject, keyIdentifier.GetType())));
		}
		xmlDictionaryWriter.Flush();
	}

	protected override bool CanReadKeyIdentifierClauseCore(XmlReader reader)
	{
		XmlDictionaryReader reader2 = XmlDictionaryReader.CreateDictionaryReader(reader);
		for (int i = 0; i < _keyIdentifierClauseEntries.Count; i++)
		{
			KeyIdentifierClauseEntry keyIdentifierClauseEntry = _keyIdentifierClauseEntries[i];
			if (keyIdentifierClauseEntry.CanReadKeyIdentifierClauseCore(reader2))
			{
				return true;
			}
		}
		return false;
	}

	protected override SecurityKeyIdentifierClause ReadKeyIdentifierClauseCore(XmlReader reader)
	{
		XmlDictionaryReader reader2 = XmlDictionaryReader.CreateDictionaryReader(reader);
		for (int i = 0; i < _keyIdentifierClauseEntries.Count; i++)
		{
			KeyIdentifierClauseEntry keyIdentifierClauseEntry = _keyIdentifierClauseEntries[i];
			if (!keyIdentifierClauseEntry.CanReadKeyIdentifierClauseCore(reader2))
			{
				continue;
			}
			try
			{
				return keyIdentifierClauseEntry.ReadKeyIdentifierClauseCore(reader2);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (!ShouldWrapException(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ErrorDeserializingKeyIdentifierClause), ex));
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.CannotReadKeyIdentifierClause, reader.LocalName, reader.NamespaceURI)));
	}

	protected override bool CanWriteKeyIdentifierClauseCore(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		for (int i = 0; i < _keyIdentifierClauseEntries.Count; i++)
		{
			KeyIdentifierClauseEntry keyIdentifierClauseEntry = _keyIdentifierClauseEntries[i];
			if (keyIdentifierClauseEntry.SupportsCore(keyIdentifierClause))
			{
				return true;
			}
		}
		return false;
	}

	protected override void WriteKeyIdentifierClauseCore(XmlWriter writer, SecurityKeyIdentifierClause keyIdentifierClause)
	{
		bool flag = false;
		XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		for (int i = 0; i < _keyIdentifierClauseEntries.Count; i++)
		{
			KeyIdentifierClauseEntry keyIdentifierClauseEntry = _keyIdentifierClauseEntries[i];
			if (!keyIdentifierClauseEntry.SupportsCore(keyIdentifierClause))
			{
				continue;
			}
			try
			{
				keyIdentifierClauseEntry.WriteKeyIdentifierClauseCore(xmlDictionaryWriter, keyIdentifierClause);
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				if (!ShouldWrapException(ex))
				{
					throw;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.ErrorSerializingKeyIdentifierClause, ex));
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.StandardsManagerCannotWriteObject, keyIdentifierClause.GetType())));
		}
		xmlDictionaryWriter.Flush();
	}

	internal void PopulateStrEntries(IList<StrEntry> strEntries)
	{
		foreach (SerializerEntries serializerEntry in _serializerEntries)
		{
			serializerEntry.PopulateStrEntries(strEntries);
		}
	}

	private bool ShouldWrapException(Exception e)
	{
		if (!(e is ArgumentException) && !(e is FormatException))
		{
			return e is InvalidOperationException;
		}
		return true;
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
}
