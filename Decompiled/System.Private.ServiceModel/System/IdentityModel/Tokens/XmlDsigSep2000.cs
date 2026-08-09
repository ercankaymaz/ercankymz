using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel.Tokens;

internal class XmlDsigSep2000 : SecurityTokenSerializer.SerializerEntries
{
	internal class KeyInfoEntry : SecurityTokenSerializer.KeyIdentifierEntry
	{
		private KeyInfoSerializer _securityTokenSerializer;

		protected override XmlDictionaryString LocalName => XD.XmlSignatureDictionary.KeyInfo;

		protected override XmlDictionaryString NamespaceUri => XD.XmlSignatureDictionary.Namespace;

		public KeyInfoEntry(KeyInfoSerializer securityTokenSerializer)
		{
			_securityTokenSerializer = securityTokenSerializer;
		}

		public override SecurityKeyIdentifier ReadKeyIdentifierCore(XmlDictionaryReader reader)
		{
			reader.ReadStartElement(LocalName, NamespaceUri);
			SecurityKeyIdentifier securityKeyIdentifier = new SecurityKeyIdentifier();
			while (reader.IsStartElement())
			{
				SecurityKeyIdentifierClause securityKeyIdentifierClause = _securityTokenSerializer.ReadKeyIdentifierClause(reader);
				if (securityKeyIdentifierClause == null)
				{
					reader.Skip();
				}
				else
				{
					securityKeyIdentifier.Add(securityKeyIdentifierClause);
				}
			}
			if (securityKeyIdentifier.Count == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.ErrorDeserializingKeyIdentifierClause));
			}
			reader.ReadEndElement();
			return securityKeyIdentifier;
		}

		public override bool SupportsCore(SecurityKeyIdentifier keyIdentifier)
		{
			return true;
		}

		public override void WriteKeyIdentifierCore(XmlDictionaryWriter writer, SecurityKeyIdentifier keyIdentifier)
		{
			writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, LocalName, NamespaceUri);
			bool flag = false;
			foreach (SecurityKeyIdentifierClause item in keyIdentifier)
			{
				_securityTokenSerializer.InnerSecurityTokenSerializer.WriteKeyIdentifierClause(writer, item);
				flag = true;
			}
			writer.WriteEndElement();
			if (!flag)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityMessageSerializationException(System.SR.NoKeyInfoClausesToWrite));
			}
		}
	}

	internal class X509CertificateClauseEntry : SecurityTokenSerializer.KeyIdentifierClauseEntry
	{
		protected override XmlDictionaryString LocalName => XD.XmlSignatureDictionary.X509Data;

		protected override XmlDictionaryString NamespaceUri => XD.XmlSignatureDictionary.Namespace;

		public override SecurityKeyIdentifierClause ReadKeyIdentifierClauseCore(XmlDictionaryReader reader)
		{
			SecurityKeyIdentifierClause securityKeyIdentifierClause = null;
			reader.ReadStartElement(XD.XmlSignatureDictionary.X509Data, NamespaceUri);
			while (reader.IsStartElement())
			{
				if (securityKeyIdentifierClause == null && reader.IsStartElement(XD.XmlSignatureDictionary.X509Certificate, NamespaceUri))
				{
					X509Certificate2 certificate = null;
					if (!SecurityUtils.TryCreateX509CertificateFromRawData(reader.ReadElementContentAsBase64(), out certificate))
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityMessageSerializationException(System.SR.InvalidX509RawData));
					}
					securityKeyIdentifierClause = new X509RawDataKeyIdentifierClause(certificate);
				}
				else if (securityKeyIdentifierClause == null && reader.IsStartElement("X509SKI", NamespaceUri.ToString()))
				{
					securityKeyIdentifierClause = new X509SubjectKeyIdentifierClause(reader.ReadElementContentAsBase64());
				}
				else if (securityKeyIdentifierClause == null && reader.IsStartElement(XD.XmlSignatureDictionary.X509IssuerSerial, XD.XmlSignatureDictionary.Namespace))
				{
					reader.ReadStartElement(XD.XmlSignatureDictionary.X509IssuerSerial, XD.XmlSignatureDictionary.Namespace);
					reader.ReadStartElement(XD.XmlSignatureDictionary.X509IssuerName, XD.XmlSignatureDictionary.Namespace);
					string issuerName = reader.ReadContentAsString();
					reader.ReadEndElement();
					reader.ReadStartElement(XD.XmlSignatureDictionary.X509SerialNumber, XD.XmlSignatureDictionary.Namespace);
					string issuerSerialNumber = reader.ReadContentAsString();
					reader.ReadEndElement();
					reader.ReadEndElement();
					securityKeyIdentifierClause = new X509IssuerSerialKeyIdentifierClause(issuerName, issuerSerialNumber);
				}
				else
				{
					reader.Skip();
				}
			}
			reader.ReadEndElement();
			return securityKeyIdentifierClause;
		}

		public override bool SupportsCore(SecurityKeyIdentifierClause keyIdentifierClause)
		{
			return keyIdentifierClause is X509RawDataKeyIdentifierClause;
		}

		public override void WriteKeyIdentifierClauseCore(XmlDictionaryWriter writer, SecurityKeyIdentifierClause keyIdentifierClause)
		{
			if (keyIdentifierClause is X509RawDataKeyIdentifierClause x509RawDataKeyIdentifierClause)
			{
				writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509Data, NamespaceUri);
				writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509Certificate, NamespaceUri);
				byte[] x509RawData = x509RawDataKeyIdentifierClause.GetX509RawData();
				writer.WriteBase64(x509RawData, 0, x509RawData.Length);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			if (keyIdentifierClause is X509IssuerSerialKeyIdentifierClause x509IssuerSerialKeyIdentifierClause)
			{
				writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509Data, XD.XmlSignatureDictionary.Namespace);
				writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509IssuerSerial, XD.XmlSignatureDictionary.Namespace);
				writer.WriteElementString(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509IssuerName, XD.XmlSignatureDictionary.Namespace, x509IssuerSerialKeyIdentifierClause.IssuerName);
				writer.WriteElementString(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509SerialNumber, XD.XmlSignatureDictionary.Namespace, x509IssuerSerialKeyIdentifierClause.IssuerSerialNumber);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			else if (keyIdentifierClause is X509SubjectKeyIdentifierClause x509SubjectKeyIdentifierClause)
			{
				writer.WriteStartElement("ds", "X509Data", "http://www.w3.org/2000/09/xmldsig#");
				writer.WriteStartElement("ds", "X509SKI", "http://www.w3.org/2000/09/xmldsig#");
				byte[] x509SubjectKeyIdentifier = x509SubjectKeyIdentifierClause.GetX509SubjectKeyIdentifier();
				writer.WriteBase64(x509SubjectKeyIdentifier, 0, x509SubjectKeyIdentifier.Length);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
	}

	private KeyInfoSerializer _securityTokenSerializer;

	public XmlDsigSep2000(KeyInfoSerializer securityTokenSerializer)
	{
		_securityTokenSerializer = securityTokenSerializer;
	}

	public override void PopulateKeyIdentifierEntries(IList<SecurityTokenSerializer.KeyIdentifierEntry> keyIdentifierEntries)
	{
		keyIdentifierEntries.Add(new KeyInfoEntry(_securityTokenSerializer));
	}

	public override void PopulateKeyIdentifierClauseEntries(IList<SecurityTokenSerializer.KeyIdentifierClauseEntry> keyIdentifierClauseEntries)
	{
		keyIdentifierClauseEntries.Add(new X509CertificateClauseEntry());
	}
}
