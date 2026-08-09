using System;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Pkcs;

public class Pkcs10CertificationRequestDelaySigned : Pkcs10CertificationRequest
{
	protected Pkcs10CertificationRequestDelaySigned()
	{
	}

	public Pkcs10CertificationRequestDelaySigned(byte[] encoded)
		: base(encoded)
	{
	}

	public Pkcs10CertificationRequestDelaySigned(Asn1Sequence seq)
		: base(seq)
	{
	}

	public Pkcs10CertificationRequestDelaySigned(Stream input)
		: base(input)
	{
	}

	public Pkcs10CertificationRequestDelaySigned(string signatureAlgorithm, X509Name subject, AsymmetricKeyParameter publicKey, Asn1Set attributes, AsymmetricKeyParameter signingKey)
		: base(signatureAlgorithm, subject, publicKey, attributes, signingKey)
	{
	}

	public Pkcs10CertificationRequestDelaySigned(string signatureAlgorithm, X509Name subject, AsymmetricKeyParameter publicKey, Asn1Set attributes)
	{
		if (signatureAlgorithm == null)
		{
			throw new ArgumentNullException("signatureAlgorithm");
		}
		if (subject == null)
		{
			throw new ArgumentNullException("subject");
		}
		if (publicKey == null)
		{
			throw new ArgumentNullException("publicKey");
		}
		if (publicKey.IsPrivate)
		{
			throw new ArgumentException("expected public key", "publicKey");
		}
		DerObjectIdentifier derObjectIdentifier = CollectionUtilities.GetValueOrNull(Pkcs10CertificationRequest.m_algorithms, signatureAlgorithm);
		if (derObjectIdentifier == null)
		{
			try
			{
				derObjectIdentifier = new DerObjectIdentifier(signatureAlgorithm);
			}
			catch (Exception innerException)
			{
				throw new ArgumentException("Unknown signature type requested", innerException);
			}
		}
		Asn1Encodable value;
		if (Pkcs10CertificationRequest.m_noParams.Contains(derObjectIdentifier))
		{
			sigAlgId = new AlgorithmIdentifier(derObjectIdentifier);
		}
		else if (Pkcs10CertificationRequest.m_exParams.TryGetValue(signatureAlgorithm, out value))
		{
			sigAlgId = new AlgorithmIdentifier(derObjectIdentifier, value);
		}
		else
		{
			sigAlgId = new AlgorithmIdentifier(derObjectIdentifier, DerNull.Instance);
		}
		SubjectPublicKeyInfo pkInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
		reqInfo = new CertificationRequestInfo(subject, pkInfo, attributes);
	}

	public byte[] GetDataToSign()
	{
		return reqInfo.GetDerEncoded();
	}

	public void SignRequest(byte[] signedData)
	{
		sigBits = new DerBitString(signedData);
	}

	public void SignRequest(DerBitString signedData)
	{
		sigBits = signedData;
	}
}
