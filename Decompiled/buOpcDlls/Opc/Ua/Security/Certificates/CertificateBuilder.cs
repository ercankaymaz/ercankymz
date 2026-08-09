using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Opc.Ua.Security.Certificates.BouncyCastle;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class CertificateBuilder : CertificateBuilderBase
{
	public static ICertificateBuilder Create(X500DistinguishedName subjectName)
	{
		return new CertificateBuilder(subjectName);
	}

	public static ICertificateBuilder Create(string subjectName)
	{
		return new CertificateBuilder(subjectName);
	}

	private CertificateBuilder(X500DistinguishedName subjectName)
		: base(subjectName)
	{
	}

	private CertificateBuilder(string subjectName)
		: base(subjectName)
	{
	}

	public override X509Certificate2 CreateForRSA()
	{
		CreateDefaults();
		if (m_rsaPublicKey != null && (base.IssuerCAKeyCert == null || !base.IssuerCAKeyCert.HasPrivateKey))
		{
			throw new NotSupportedException("Cannot use a public key without a issuer certificate with a private key.");
		}
		RSA rSA = null;
		RSA rSA2 = m_rsaPublicKey;
		if (rSA2 == null)
		{
			rSA = RSA.Create((m_keySize == 0) ? X509Defaults.RSAKeySize : m_keySize);
			rSA2 = rSA;
		}
		RSASignaturePadding pkcs = RSASignaturePadding.Pkcs1;
		CertificateRequest certificateRequest = new CertificateRequest(base.SubjectName, rSA2, base.HashAlgorithmName, pkcs);
		CreateX509Extensions(certificateRequest, forECDsa: false);
		byte[] serialNumber = Enumerable.Reverse(m_serialNumber).ToArray();
		X509Certificate2 x509Certificate;
		if (base.IssuerCAKeyCert != null)
		{
			using RSA key = base.IssuerCAKeyCert.GetRSAPrivateKey();
			x509Certificate = certificateRequest.Create(base.IssuerCAKeyCert.SubjectName, X509SignatureGenerator.CreateForRSA(key, pkcs), base.NotBefore, base.NotAfter, serialNumber);
		}
		else
		{
			x509Certificate = certificateRequest.Create(base.SubjectName, X509SignatureGenerator.CreateForRSA(rSA, pkcs), base.NotBefore, base.NotAfter, serialNumber);
		}
		if (rSA != null)
		{
			return x509Certificate.CopyWithPrivateKey(rSA);
		}
		return x509Certificate;
	}

	public override X509Certificate2 CreateForRSA(X509SignatureGenerator generator)
	{
		CreateDefaults();
		if (m_rsaPublicKey == null && base.IssuerCAKeyCert == null)
		{
			throw new NotSupportedException("Need an issuer certificate or a public key for a signature generator.");
		}
		X500DistinguishedName subjectName = base.SubjectName;
		if (base.IssuerCAKeyCert != null)
		{
			subjectName = base.IssuerCAKeyCert.SubjectName;
		}
		RSA rSA = null;
		RSA rSA2 = m_rsaPublicKey;
		if (rSA2 == null)
		{
			rSA = RSA.Create((m_keySize == 0) ? X509Defaults.RSAKeySize : m_keySize);
			rSA2 = rSA;
		}
		CertificateRequest certificateRequest = new CertificateRequest(base.SubjectName, rSA2, base.HashAlgorithmName, RSASignaturePadding.Pkcs1);
		CreateX509Extensions(certificateRequest, forECDsa: false);
		X509Certificate2 x509Certificate = certificateRequest.Create(subjectName, generator, base.NotBefore, base.NotAfter, Enumerable.Reverse(m_serialNumber).ToArray());
		if (rSA != null)
		{
			return x509Certificate.CopyWithPrivateKey(rSA);
		}
		return x509Certificate;
	}

	public override X509Certificate2 CreateForECDsa()
	{
		if (m_ecdsaPublicKey != null && base.IssuerCAKeyCert == null)
		{
			throw new NotSupportedException("Cannot use a public key without a issuer certificate with a private key.");
		}
		if (m_ecdsaPublicKey == null && !m_curve.HasValue)
		{
			throw new NotSupportedException("Need a public key or a ECCurve to create the certificate.");
		}
		CreateDefaults();
		ECDsa eCDsa = null;
		ECDsa eCDsa2 = m_ecdsaPublicKey;
		if (eCDsa2 == null)
		{
			eCDsa = ECDsa.Create(m_curve.Value);
			eCDsa2 = eCDsa;
		}
		CertificateRequest certificateRequest = new CertificateRequest(base.SubjectName, eCDsa2, base.HashAlgorithmName);
		CreateX509Extensions(certificateRequest, forECDsa: true);
		byte[] serialNumber = Enumerable.Reverse(m_serialNumber).ToArray();
		if (base.IssuerCAKeyCert != null)
		{
			using (ECDsa key = base.IssuerCAKeyCert.GetECDsaPrivateKey())
			{
				return certificateRequest.Create(base.IssuerCAKeyCert.SubjectName, X509SignatureGenerator.CreateForECDsa(key), base.NotBefore, base.NotAfter, serialNumber);
			}
		}
		return certificateRequest.Create(base.SubjectName, X509SignatureGenerator.CreateForECDsa(eCDsa), base.NotBefore, base.NotAfter, serialNumber).CopyWithPrivateKey(eCDsa);
	}

	public override X509Certificate2 CreateForECDsa(X509SignatureGenerator generator)
	{
		if (base.IssuerCAKeyCert == null)
		{
			throw new NotSupportedException("X509 Signature generator requires an issuer certificate.");
		}
		if (m_ecdsaPublicKey == null && !m_curve.HasValue)
		{
			throw new NotSupportedException("Need a public key or a ECCurve to create the certificate.");
		}
		CreateDefaults();
		ECDsa eCDsa = null;
		ECDsa eCDsa2 = m_ecdsaPublicKey;
		if (eCDsa2 == null)
		{
			eCDsa = ECDsa.Create(m_curve.Value);
			eCDsa2 = eCDsa;
		}
		CertificateRequest certificateRequest = new CertificateRequest(base.SubjectName, eCDsa2, base.HashAlgorithmName);
		CreateX509Extensions(certificateRequest, forECDsa: true);
		X509Certificate2 x509Certificate = certificateRequest.Create(base.IssuerCAKeyCert.SubjectName, generator, base.NotBefore, base.NotAfter, Enumerable.Reverse(m_serialNumber).ToArray());
		if (eCDsa != null)
		{
			return x509Certificate.CopyWithPrivateKey(eCDsa);
		}
		return x509Certificate;
	}

	public override ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(byte[] publicKey)
	{
		if (publicKey == null)
		{
			throw new ArgumentNullException("publicKey");
		}
		throw new NotSupportedException("Import a ECDsaPublicKey is not supported on this platform.");
	}

	public override ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey)
	{
		if (publicKey == null)
		{
			throw new ArgumentNullException("publicKey");
		}
		int num = 0;
		try
		{
			m_rsaPublicKey = Opc.Ua.Security.Certificates.BouncyCastle.X509Utils.SetRSAPublicKey(publicKey);
			num = publicKey.Length;
		}
		catch (Exception innerException)
		{
			throw new ArgumentException("Failed to decode the public key.", innerException);
		}
		if (publicKey.Length != num)
		{
			throw new ArgumentException("Decoded the public key but extra bytes were found.");
		}
		return this;
	}

	private void CreateDefaults()
	{
		if (!m_presetSerial)
		{
			NewSerialNumber();
		}
		m_presetSerial = false;
		ValidateSettings();
	}

	private void CreateX509Extensions(CertificateRequest request, bool forECDsa)
	{
		if (m_extensions.FindExtension<X509BasicConstraintsExtension>() == null)
		{
			X509BasicConstraintsExtension basicContraints = GetBasicContraints();
			request.CertificateExtensions.Add(basicContraints);
		}
		X509SubjectKeyIdentifierExtension x509SubjectKeyIdentifierExtension = new X509SubjectKeyIdentifierExtension(request.PublicKey, X509SubjectKeyIdentifierHashAlgorithm.Sha1, critical: false);
		if (m_extensions.FindExtension<X509SubjectKeyIdentifierExtension>() == null)
		{
			request.CertificateExtensions.Add(x509SubjectKeyIdentifierExtension);
		}
		if (m_extensions.FindExtension<X509AuthorityKeyIdentifierExtension>() == null)
		{
			X509Extension item = ((base.IssuerCAKeyCert != null) ? X509Extensions.BuildAuthorityKeyIdentifier(base.IssuerCAKeyCert) : new X509AuthorityKeyIdentifierExtension(x509SubjectKeyIdentifierExtension.SubjectKeyIdentifier.FromHexString(), base.IssuerName, m_serialNumber));
			request.CertificateExtensions.Add(item);
		}
		if (m_extensions.FindExtension<X509KeyUsageExtension>() == null)
		{
			X509KeyUsageFlags x509KeyUsageFlags;
			if (m_isCA)
			{
				x509KeyUsageFlags = X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.DigitalSignature;
			}
			else
			{
				x509KeyUsageFlags = ((!forECDsa) ? (X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature) : (X509KeyUsageFlags.KeyAgreement | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature));
				if (base.IssuerCAKeyCert == null)
				{
					x509KeyUsageFlags |= X509KeyUsageFlags.KeyCertSign;
				}
			}
			request.CertificateExtensions.Add(new X509KeyUsageExtension(x509KeyUsageFlags, critical: true));
		}
		if (!m_isCA && m_extensions.FindExtension<X509EnhancedKeyUsageExtension>() == null)
		{
			request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection
			{
				new Oid("1.3.6.1.5.5.7.3.1"),
				new Oid("1.3.6.1.5.5.7.3.2")
			}, critical: true));
		}
		X509ExtensionEnumerator enumerator = m_extensions.GetEnumerator();
		while (enumerator.MoveNext())
		{
			X509Extension current = enumerator.Current;
			request.CertificateExtensions.Add(current);
		}
	}

	private X509BasicConstraintsExtension GetBasicContraints()
	{
		if (!m_isCA && base.IssuerCAKeyCert == null)
		{
			return new X509BasicConstraintsExtension(certificateAuthority: false, hasPathLengthConstraint: false, 0, critical: true);
		}
		if (m_isCA && m_pathLengthConstraint >= 0)
		{
			return new X509BasicConstraintsExtension(certificateAuthority: true, hasPathLengthConstraint: true, m_pathLengthConstraint, critical: true);
		}
		return new X509BasicConstraintsExtension(m_isCA, hasPathLengthConstraint: false, 0, critical: true);
	}
}
