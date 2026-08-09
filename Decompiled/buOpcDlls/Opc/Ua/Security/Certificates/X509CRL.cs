using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class X509CRL : IX509CRL
{
	private bool m_decoded;

	private X509Signature m_signature;

	private X500DistinguishedName m_issuerName;

	private DateTime m_thisUpdate;

	private DateTime m_nextUpdate;

	private HashAlgorithmName m_hashAlgorithmName;

	private List<RevokedCertificate> m_revokedCertificates;

	private X509ExtensionCollection m_crlExtensions;

	public X500DistinguishedName IssuerName
	{
		get
		{
			EnsureDecoded();
			return m_issuerName;
		}
	}

	public string Issuer => IssuerName.Name;

	public DateTime ThisUpdate
	{
		get
		{
			EnsureDecoded();
			return m_thisUpdate;
		}
	}

	public DateTime NextUpdate
	{
		get
		{
			EnsureDecoded();
			return m_nextUpdate;
		}
	}

	public HashAlgorithmName HashAlgorithmName
	{
		get
		{
			EnsureDecoded();
			return m_hashAlgorithmName;
		}
	}

	public IList<RevokedCertificate> RevokedCertificates
	{
		get
		{
			EnsureDecoded();
			return m_revokedCertificates.AsReadOnly();
		}
	}

	public X509ExtensionCollection CrlExtensions
	{
		get
		{
			EnsureDecoded();
			return m_crlExtensions;
		}
	}

	public byte[] RawData { get; private set; }

	public X509CRL(string filePath)
		: this()
	{
		RawData = File.ReadAllBytes(filePath);
	}

	public X509CRL(byte[] crl)
		: this()
	{
		RawData = crl;
	}

	public X509CRL(IX509CRL crl)
	{
		m_decoded = true;
		m_issuerName = crl.IssuerName;
		m_hashAlgorithmName = crl.HashAlgorithmName;
		m_thisUpdate = crl.ThisUpdate;
		m_nextUpdate = crl.NextUpdate;
		m_revokedCertificates = new List<RevokedCertificate>(crl.RevokedCertificates);
		m_crlExtensions = new X509ExtensionCollection();
		X509ExtensionEnumerator enumerator = crl.CrlExtensions.GetEnumerator();
		while (enumerator.MoveNext())
		{
			X509Extension current = enumerator.Current;
			m_crlExtensions.Add(current);
		}
		RawData = crl.RawData;
	}

	internal X509CRL()
	{
		m_decoded = false;
		m_thisUpdate = DateTime.MinValue;
		m_nextUpdate = DateTime.MinValue;
		m_revokedCertificates = new List<RevokedCertificate>();
		m_crlExtensions = new X509ExtensionCollection();
	}

	public bool VerifySignature(X509Certificate2 issuer, bool throwOnError)
	{
		bool flag;
		try
		{
			flag = new X509Signature(RawData).Verify(issuer);
		}
		catch (Exception)
		{
			flag = false;
		}
		if (!flag && throwOnError)
		{
			throw new CryptographicException("Could not verify signature on CRL.");
		}
		return flag;
	}

	public bool IsRevoked(X509Certificate2 certificate)
	{
		if (certificate.IssuerName.Equals(IssuerName))
		{
			throw new CryptographicException("Certificate was not created by the CRL Issuer.");
		}
		EnsureDecoded();
		byte[] serialNumber = certificate.GetSerialNumber();
		foreach (RevokedCertificate revokedCertificate in RevokedCertificates)
		{
			if (Enumerable.SequenceEqual(serialNumber, revokedCertificate.UserCertificate))
			{
				return true;
			}
		}
		return false;
	}

	internal void Decode(byte[] crl)
	{
		m_signature = new X509Signature(crl);
		DecodeCrl(m_signature.Tbs);
	}

	internal void DecodeCrl(byte[] tbs)
	{
		try
		{
			AsnReader asnReader = new AsnReader(tbs, AsnEncodingRules.DER);
			Asn1Tag sequence = Asn1Tag.Sequence;
			AsnReader asnReader2 = asnReader.ReadSequence(sequence);
			asnReader.ThrowIfNotEmpty();
			if (asnReader2 != null)
			{
				uint value = 0u;
				Asn1Tag asn1Tag = new Asn1Tag(UniversalTagNumber.Integer);
				if (asnReader2.PeekTag() == asn1Tag && asnReader2.TryReadUInt32(out value) && value != 1)
				{
					throw new AsnContentException($"The CRL contains an incorrect version {value}");
				}
				AsnReader asnReader3 = asnReader2.ReadSequence();
				string oid = asnReader3.ReadObjectIdentifier();
				m_hashAlgorithmName = Oids.GetHashAlgorithmName(oid);
				if (asnReader3.HasData)
				{
					asnReader3.ReadNull();
				}
				asnReader3.ThrowIfNotEmpty();
				m_issuerName = new X500DistinguishedName(asnReader2.ReadEncodedValue().ToArray());
				m_thisUpdate = ReadTime(asnReader2, optional: false);
				m_nextUpdate = ReadTime(asnReader2, optional: true);
				Asn1Tag asn1Tag2 = new Asn1Tag(UniversalTagNumber.Sequence, isConstructed: true);
				if (asnReader2.PeekTag() == asn1Tag2)
				{
					AsnReader asnReader4 = asnReader2.ReadSequence(sequence);
					List<RevokedCertificate> list = new List<RevokedCertificate>();
					while (asnReader4.HasData)
					{
						AsnReader asnReader5 = asnReader4.ReadSequence();
						RevokedCertificate revokedCertificate = new RevokedCertificate(asnReader5.ReadInteger().ToByteArray());
						revokedCertificate.RevocationDate = ReadTime(asnReader5, optional: false);
						if (value == 1 && asnReader5.HasData)
						{
							AsnReader asnReader6 = asnReader5.ReadSequence();
							while (asnReader6.HasData)
							{
								X509Extension extension = asnReader6.ReadExtension();
								revokedCertificate.CrlEntryExtensions.Add(extension);
							}
							asnReader6.ThrowIfNotEmpty();
						}
						asnReader5.ThrowIfNotEmpty();
						list.Add(revokedCertificate);
					}
					asnReader4.ThrowIfNotEmpty();
					m_revokedCertificates = list;
				}
				if (value == 1 && asnReader2.HasData)
				{
					Asn1Tag value2 = new Asn1Tag(TagClass.ContextSpecific, 0);
					AsnReader asnReader7 = asnReader2.ReadSequence(value2);
					X509ExtensionCollection x509ExtensionCollection = new X509ExtensionCollection();
					AsnReader asnReader8 = asnReader7.ReadSequence();
					while (asnReader8.HasData)
					{
						X509Extension extension2 = asnReader8.ReadExtension();
						x509ExtensionCollection.Add(extension2);
					}
					m_crlExtensions = x509ExtensionCollection;
				}
				asnReader2.ThrowIfNotEmpty();
				m_decoded = true;
				return;
			}
			throw new CryptographicException("The CRL contains ivalid data.");
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Failed to decode the CRL.", inner);
		}
	}

	private static DateTime ReadTime(AsnReader asnReader, bool optional)
	{
		Asn1Tag asn1Tag = asnReader.PeekTag();
		if (asn1Tag.TagValue == Asn1Tag.UtcTime.TagValue)
		{
			return asnReader.ReadUtcTime().UtcDateTime;
		}
		if (asn1Tag.TagValue == Asn1Tag.GeneralizedTime.TagValue)
		{
			return asnReader.ReadGeneralizedTime().UtcDateTime;
		}
		if (optional)
		{
			return DateTime.MinValue;
		}
		throw new AsnContentException("The CRL contains an invalid time tag.");
	}

	private void EnsureDecoded()
	{
		if (!m_decoded)
		{
			Decode(RawData);
		}
	}
}
