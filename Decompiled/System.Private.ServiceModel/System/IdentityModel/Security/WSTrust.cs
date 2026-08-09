using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.IdentityModel.Security;

internal class WSTrust : SecurityTokenSerializer.SerializerEntries
{
	private class BinarySecretTokenEntry : SecurityTokenSerializer.TokenEntry
	{
		private WSTrust _parent;

		protected override XmlDictionaryString LocalName => _parent.SerializerDictionary.BinarySecret;

		protected override XmlDictionaryString NamespaceUri => _parent.SerializerDictionary.Namespace;

		public override string TokenTypeUri => null;

		protected override string ValueTypeUri => null;

		public BinarySecretTokenEntry(WSTrust parent)
		{
			_parent = parent;
		}

		protected override Type[] GetTokenTypesCore()
		{
			return new Type[1] { typeof(BinarySecretSecurityToken) };
		}
	}

	internal class BinarySecretClauseEntry : SecurityTokenSerializer.KeyIdentifierClauseEntry
	{
		private WSTrust _parent;

		private TrustDictionary _otherDictionary;

		protected override XmlDictionaryString LocalName => _parent.SerializerDictionary.BinarySecret;

		protected override XmlDictionaryString NamespaceUri => _parent.SerializerDictionary.Namespace;

		public BinarySecretClauseEntry(WSTrust parent)
		{
			_parent = parent;
			_otherDictionary = null;
			if (parent.SerializerDictionary is TrustDec2005Dictionary)
			{
				_otherDictionary = parent._securityTokenSerializer.DictionaryManager.TrustFeb2005Dictionary;
			}
			if (parent.SerializerDictionary is TrustFeb2005Dictionary)
			{
				_otherDictionary = parent._securityTokenSerializer.DictionaryManager.TrustDec2005Dictionary;
			}
			if (_otherDictionary == null)
			{
				_otherDictionary = _parent.SerializerDictionary;
			}
		}

		public override SecurityKeyIdentifierClause ReadKeyIdentifierClauseCore(XmlDictionaryReader reader)
		{
			byte[] key = reader.ReadElementContentAsBase64();
			return new BinarySecretKeyIdentifierClause(key, cloneBuffer: false);
		}

		public override bool SupportsCore(SecurityKeyIdentifierClause keyIdentifierClause)
		{
			return keyIdentifierClause is BinarySecretKeyIdentifierClause;
		}

		public override bool CanReadKeyIdentifierClauseCore(XmlDictionaryReader reader)
		{
			if (!reader.IsStartElement(LocalName, NamespaceUri))
			{
				return reader.IsStartElement(LocalName, _otherDictionary.Namespace);
			}
			return true;
		}

		public override void WriteKeyIdentifierClauseCore(XmlDictionaryWriter writer, SecurityKeyIdentifierClause keyIdentifierClause)
		{
			BinarySecretKeyIdentifierClause binarySecretKeyIdentifierClause = keyIdentifierClause as BinarySecretKeyIdentifierClause;
			byte[] keyBytes = binarySecretKeyIdentifierClause.GetKeyBytes();
			writer.WriteStartElement(_parent.SerializerDictionary.Prefix.Value, _parent.SerializerDictionary.BinarySecret, _parent.SerializerDictionary.Namespace);
			writer.WriteBase64(keyBytes, 0, keyBytes.Length);
			writer.WriteEndElement();
		}
	}

	internal class GenericXmlSecurityKeyIdentifierClauseEntry : SecurityTokenSerializer.KeyIdentifierClauseEntry
	{
		private WSTrust _parent;

		protected override XmlDictionaryString LocalName => null;

		protected override XmlDictionaryString NamespaceUri => null;

		public GenericXmlSecurityKeyIdentifierClauseEntry(WSTrust parent)
		{
			_parent = parent;
		}

		public override bool CanReadKeyIdentifierClauseCore(XmlDictionaryReader reader)
		{
			return false;
		}

		public override SecurityKeyIdentifierClause ReadKeyIdentifierClauseCore(XmlDictionaryReader reader)
		{
			return null;
		}

		public override bool SupportsCore(SecurityKeyIdentifierClause keyIdentifierClause)
		{
			return keyIdentifierClause is GenericXmlSecurityKeyIdentifierClause;
		}

		public override void WriteKeyIdentifierClauseCore(XmlDictionaryWriter writer, SecurityKeyIdentifierClause keyIdentifierClause)
		{
			GenericXmlSecurityKeyIdentifierClause genericXmlSecurityKeyIdentifierClause = keyIdentifierClause as GenericXmlSecurityKeyIdentifierClause;
			genericXmlSecurityKeyIdentifierClause.ReferenceXml.WriteTo(writer);
		}
	}

	private KeyInfoSerializer _securityTokenSerializer;

	public TrustDictionary SerializerDictionary { get; }

	public WSTrust(KeyInfoSerializer securityTokenSerializer, TrustDictionary serializerDictionary)
	{
		_securityTokenSerializer = securityTokenSerializer;
		SerializerDictionary = serializerDictionary;
	}

	public override void PopulateTokenEntries(IList<SecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		tokenEntryList.Add(new BinarySecretTokenEntry(this));
	}

	public override void PopulateKeyIdentifierClauseEntries(IList<SecurityTokenSerializer.KeyIdentifierClauseEntry> keyIdentifierClauseEntries)
	{
		keyIdentifierClauseEntries.Add(new BinarySecretClauseEntry(this));
		keyIdentifierClauseEntries.Add(new GenericXmlSecurityKeyIdentifierClauseEntry(this));
	}

	protected static bool CheckElement(XmlElement element, string name, string ns, out string value)
	{
		value = null;
		if (element.LocalName != name || element.NamespaceURI != ns)
		{
			return false;
		}
		if (element.FirstChild is XmlText)
		{
			value = ((XmlText)element.FirstChild).Value;
			return true;
		}
		return false;
	}
}
