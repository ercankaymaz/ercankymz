using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public sealed class CrlBuilder : IX509CRL
{
	private List<RevokedCertificate> m_revokedCertificates;

	private X509ExtensionCollection m_crlExtensions;

	public X500DistinguishedName IssuerName { get; }

	public string Issuer => IssuerName.Name;

	public DateTime ThisUpdate { get; private set; }

	public DateTime NextUpdate { get; private set; }

	public HashAlgorithmName HashAlgorithmName { get; private set; }

	public IList<RevokedCertificate> RevokedCertificates => m_revokedCertificates;

	public X509ExtensionCollection CrlExtensions => m_crlExtensions;

	public byte[] RawData { get; private set; }

	public static CrlBuilder Create(IX509CRL crl)
	{
		return new CrlBuilder(crl);
	}

	public static CrlBuilder Create(X500DistinguishedName issuerSubjectName)
	{
		return new CrlBuilder(issuerSubjectName);
	}

	public static CrlBuilder Create(X500DistinguishedName issuerSubjectName, HashAlgorithmName hashAlgorithmName)
	{
		return new CrlBuilder(issuerSubjectName, hashAlgorithmName);
	}

	private CrlBuilder(IX509CRL crl)
	{
		IssuerName = crl.IssuerName;
		HashAlgorithmName = crl.HashAlgorithmName;
		ThisUpdate = crl.ThisUpdate;
		NextUpdate = crl.NextUpdate;
		RawData = crl.RawData;
		m_revokedCertificates = new List<RevokedCertificate>(crl.RevokedCertificates);
		m_crlExtensions = new X509ExtensionCollection();
		X509ExtensionEnumerator enumerator = crl.CrlExtensions.GetEnumerator();
		while (enumerator.MoveNext())
		{
			X509Extension current = enumerator.Current;
			m_crlExtensions.Add(current);
		}
	}

	private CrlBuilder(X500DistinguishedName issuerSubjectName)
		: this(issuerSubjectName, X509Defaults.HashAlgorithmName)
	{
	}

	private CrlBuilder(X500DistinguishedName issuerSubjectName, HashAlgorithmName hashAlgorithmName)
		: this()
	{
		IssuerName = issuerSubjectName;
		HashAlgorithmName = hashAlgorithmName;
	}

	private CrlBuilder()
	{
		ThisUpdate = DateTime.UtcNow;
		NextUpdate = DateTime.MinValue;
		m_revokedCertificates = new List<RevokedCertificate>();
		m_crlExtensions = new X509ExtensionCollection();
	}

	public CrlBuilder SetThisUpdate(DateTime thisUpdate)
	{
		ThisUpdate = thisUpdate;
		return this;
	}

	public CrlBuilder SetNextUpdate(DateTime nextUpdate)
	{
		NextUpdate = nextUpdate;
		return this;
	}

	public CrlBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName)
	{
		HashAlgorithmName = hashAlgorithmName;
		return this;
	}

	public CrlBuilder AddRevokedSerialNumbers(string[] serialNumbers, CRLReason crlReason = CRLReason.Unspecified)
	{
		if (serialNumbers == null)
		{
			throw new ArgumentNullException("serialNumbers");
		}
		m_revokedCertificates.AddRange(serialNumbers.Select((string s) => new RevokedCertificate(s, crlReason)).ToList());
		return this;
	}

	public CrlBuilder AddRevokedCertificate(X509Certificate2 certificate, CRLReason crlReason = CRLReason.Unspecified)
	{
		if (certificate == null)
		{
			throw new ArgumentNullException("certificate");
		}
		m_revokedCertificates.Add(new RevokedCertificate(certificate.SerialNumber, crlReason));
		return this;
	}

	public CrlBuilder AddRevokedCertificate(RevokedCertificate revokedCertificate)
	{
		if (revokedCertificate == null)
		{
			throw new ArgumentNullException("revokedCertificate");
		}
		m_revokedCertificates.Add(revokedCertificate);
		return this;
	}

	public CrlBuilder AddRevokedCertificates(IList<RevokedCertificate> revokedCertificates)
	{
		if (revokedCertificates == null)
		{
			throw new ArgumentNullException("revokedCertificates");
		}
		m_revokedCertificates.AddRange(revokedCertificates);
		return this;
	}

	public CrlBuilder AddCRLExtension(X509Extension extension)
	{
		m_crlExtensions.Add(extension);
		return this;
	}

	public IX509CRL CreateSignature(X509SignatureGenerator generator)
	{
		byte[] array = Encode();
		byte[] signatureAlgorithmIdentifier = generator.GetSignatureAlgorithmIdentifier(HashAlgorithmName);
		byte[] signature = generator.SignData(array, HashAlgorithmName);
		X509Signature x509Signature = new X509Signature(array, signature, signatureAlgorithmIdentifier);
		RawData = x509Signature.Encode();
		return this;
	}

	public IX509CRL CreateForRSA(X509Certificate2 issuerCertificate)
	{
		using RSA key = issuerCertificate.GetRSAPrivateKey();
		X509SignatureGenerator generator = X509SignatureGenerator.CreateForRSA(key, RSASignaturePadding.Pkcs1);
		return CreateSignature(generator);
	}

	public IX509CRL CreateForECDsa(X509Certificate2 issuerCertificate)
	{
		using ECDsa key = issuerCertificate.GetECDsaPrivateKey();
		X509SignatureGenerator generator = X509SignatureGenerator.CreateForECDsa(key);
		return CreateSignature(generator);
	}

	internal byte[] Encode()
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.PushSequence();
		asnWriter.WriteInteger(1L);
		asnWriter.PushSequence();
		string rSAOid = Oids.GetRSAOid(HashAlgorithmName);
		asnWriter.WriteObjectIdentifier(rSAOid);
		asnWriter.WriteNull();
		asnWriter.PopSequence();
		asnWriter.WriteEncodedValue(IssuerName.RawData);
		WriteTime(asnWriter, ThisUpdate);
		if (NextUpdate != DateTime.MinValue && NextUpdate > ThisUpdate)
		{
			WriteTime(asnWriter, NextUpdate);
		}
		asnWriter.PushSequence();
		foreach (RevokedCertificate revokedCertificate in RevokedCertificates)
		{
			asnWriter.PushSequence();
			BigInteger value = new BigInteger(revokedCertificate.UserCertificate);
			asnWriter.WriteInteger(value);
			WriteTime(asnWriter, revokedCertificate.RevocationDate);
			if (revokedCertificate.CrlEntryExtensions.Count > 0)
			{
				asnWriter.PushSequence();
				X509ExtensionEnumerator enumerator2 = revokedCertificate.CrlEntryExtensions.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					X509Extension current2 = enumerator2.Current;
					asnWriter.WriteExtension(current2);
				}
				asnWriter.PopSequence();
			}
			asnWriter.PopSequence();
		}
		asnWriter.PopSequence();
		if (CrlExtensions.Count > 0)
		{
			Asn1Tag value2 = new Asn1Tag(TagClass.ContextSpecific, 0);
			asnWriter.PushSequence(value2);
			asnWriter.PushSequence();
			X509ExtensionEnumerator enumerator2 = CrlExtensions.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				X509Extension current3 = enumerator2.Current;
				asnWriter.WriteExtension(current3);
			}
			asnWriter.PopSequence();
			asnWriter.PopSequence(value2);
		}
		asnWriter.PopSequence();
		return asnWriter.Encode();
	}

	private static void WriteTime(AsnWriter writer, DateTime dateTime)
	{
		DateTime dateTime2 = dateTime.ToUniversalTime();
		if (dateTime2.Year < 2050)
		{
			writer.WriteUtcTime(dateTime2);
		}
		else
		{
			writer.WriteGeneralizedTime(dateTime2, omitFractionalSeconds: true);
		}
	}
}
