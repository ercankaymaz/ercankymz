using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public static class CertificateFactory
{
	public static readonly ushort DefaultKeySize = 2048;

	public static readonly ushort DefaultHashSize = 256;

	public static readonly ushort DefaultLifeTime = 12;

	private static readonly Dictionary<string, X509Certificate2> m_certificates = new Dictionary<string, X509Certificate2>();

	private static readonly object m_certificatesLock = new object();

	public static X509Certificate2 Create(byte[] encodedData, bool useCache)
	{
		if (useCache)
		{
			return Load(new X509Certificate2(encodedData), ensurePrivateKeyAccessible: false);
		}
		return new X509Certificate2(encodedData);
	}

	public static X509Certificate2 Load(X509Certificate2 certificate, bool ensurePrivateKeyAccessible)
	{
		if (certificate == null)
		{
			return null;
		}
		lock (m_certificatesLock)
		{
			X509Certificate2 value = null;
			if (m_certificates.TryGetValue(certificate.Thumbprint, out value))
			{
				return value;
			}
			if (!certificate.HasPrivateKey || !ensurePrivateKeyAccessible)
			{
				return certificate;
			}
			if (ensurePrivateKeyAccessible && !X509Utils.VerifyRSAKeyPair(certificate, certificate))
			{
				Utils.LogWarning("Trying to add certificate to cache with invalid private key.");
				return null;
			}
			m_certificates[certificate.Thumbprint] = certificate;
			if (m_certificates.Count > 100)
			{
				Utils.LogWarning("Certificate cache has {0} certificates in it.", m_certificates.Count);
			}
		}
		return certificate;
	}

	public static ICertificateBuilder CreateCertificate(string subjectName)
	{
		return CertificateBuilder.Create(subjectName);
	}

	public static ICertificateBuilder CreateCertificate(string applicationUri, string applicationName, string subjectName, IList<string> domainNames)
	{
		SetSuitableDefaults(ref applicationUri, ref applicationName, ref subjectName, ref domainNames);
		return CertificateBuilder.Create(subjectName).AddExtension(new X509SubjectAltNameExtension(applicationUri, domainNames));
	}

	[Obsolete("Use the new CreateCertificate methods with CertificateBuilder.")]
	public static X509Certificate2 CreateCertificate(string storeType, string storePath, string password, string applicationUri, string applicationName, string subjectName, IList<string> domainNames, ushort keySize, DateTime startTime, ushort lifetimeInMonths, ushort hashSizeInBits, bool isCA = false, X509Certificate2 issuerCAKeyCert = null, byte[] publicKey = null, int pathLengthConstraint = 0)
	{
		return CreateCertificate(applicationUri, applicationName, subjectName, domainNames, keySize, startTime, lifetimeInMonths, hashSizeInBits, isCA, issuerCAKeyCert, publicKey, pathLengthConstraint).AddToStore(storeType, storePath, password);
	}

	public static X509CRL RevokeCertificate(X509Certificate2 issuerCertificate, X509CRLCollection issuerCrls, X509Certificate2Collection revokedCertificates)
	{
		return RevokeCertificate(issuerCertificate, issuerCrls, revokedCertificates, DateTime.UtcNow, DateTime.UtcNow.AddMonths(12));
	}

	public static X509CRL RevokeCertificate(X509Certificate2 issuerCertificate, X509CRLCollection issuerCrls, X509Certificate2Collection revokedCertificates, DateTime thisUpdate, DateTime nextUpdate)
	{
		if (!issuerCertificate.HasPrivateKey)
		{
			throw new ServiceResultException(2148663296u, "Issuer certificate has no private key, cannot revoke certificate.");
		}
		BigInteger bigInteger = 0;
		Dictionary<string, RevokedCertificate> dictionary = new Dictionary<string, RevokedCertificate>();
		if (issuerCrls != null)
		{
			foreach (X509CRL issuerCrl in issuerCrls)
			{
				X509CrlNumberExtension x509CrlNumberExtension = issuerCrl.CrlExtensions.FindExtension<X509CrlNumberExtension>();
				if (x509CrlNumberExtension != null && x509CrlNumberExtension.CrlNumber > bigInteger)
				{
					bigInteger = x509CrlNumberExtension.CrlNumber;
				}
				foreach (RevokedCertificate revokedCertificate in issuerCrl.RevokedCertificates)
				{
					if (!dictionary.ContainsKey(revokedCertificate.SerialNumber))
					{
						dictionary[revokedCertificate.SerialNumber] = revokedCertificate;
					}
				}
			}
		}
		if (revokedCertificates != null)
		{
			X509Certificate2Enumerator enumerator3 = revokedCertificates.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				X509Certificate2 current3 = enumerator3.Current;
				if (!dictionary.ContainsKey(current3.SerialNumber))
				{
					RevokedCertificate value = new RevokedCertificate(current3.SerialNumber, CRLReason.PrivilegeWithdrawn);
					dictionary[current3.SerialNumber] = value;
				}
			}
		}
		return new X509CRL(CrlBuilder.Create(issuerCertificate.SubjectName).AddRevokedCertificates(dictionary.Values.ToList()).SetThisUpdate(thisUpdate)
			.SetNextUpdate(nextUpdate)
			.AddCRLExtension(X509Extensions.BuildAuthorityKeyIdentifier(issuerCertificate))
			.AddCRLExtension(X509Extensions.BuildCRLNumber(bigInteger + 1))
			.CreateForRSA(issuerCertificate));
	}

	public static byte[] CreateSigningRequest(X509Certificate2 certificate, IList<string> domainNames = null)
	{
		if (!certificate.HasPrivateKey)
		{
			throw new NotSupportedException("Need a certificate with a private key.");
		}
		RSA rSAPublicKey = certificate.GetRSAPublicKey();
		CertificateRequest certificateRequest = new CertificateRequest(certificate.SubjectName, rSAPublicKey, Oids.GetHashAlgorithmName(certificate.SignatureAlgorithm.Value), RSASignaturePadding.Pkcs1);
		X509SubjectAltNameExtension x509SubjectAltNameExtension = certificate.FindExtension<X509SubjectAltNameExtension>();
		domainNames = domainNames ?? new List<string>();
		if (x509SubjectAltNameExtension != null)
		{
			foreach (string name in x509SubjectAltNameExtension.DomainNames)
			{
				if (!domainNames.Any((string s) => s.Equals(name, StringComparison.OrdinalIgnoreCase)))
				{
					domainNames.Add(name);
				}
			}
			foreach (string ipAddress in x509SubjectAltNameExtension.IPAddresses)
			{
				if (!domainNames.Any((string s) => s.Equals(ipAddress, StringComparison.OrdinalIgnoreCase)))
				{
					domainNames.Add(ipAddress);
				}
			}
		}
		X509SubjectAltNameExtension encodedExtension = new X509SubjectAltNameExtension(X509Utils.GetApplicationUriFromCertificate(certificate), domainNames);
		certificateRequest.CertificateExtensions.Add(new X509Extension(encodedExtension, critical: false));
		using RSA key = certificate.GetRSAPrivateKey();
		X509SignatureGenerator signatureGenerator = X509SignatureGenerator.CreateForRSA(key, RSASignaturePadding.Pkcs1);
		return certificateRequest.CreateSigningRequest(signatureGenerator);
	}

	public static X509Certificate2 CreateCertificateWithPrivateKey(X509Certificate2 certificate, X509Certificate2 certificateWithPrivateKey)
	{
		if (!certificateWithPrivateKey.HasPrivateKey)
		{
			throw new NotSupportedException("Need a certificate with a private key.");
		}
		if (!X509Utils.VerifyRSAKeyPair(certificate, certificateWithPrivateKey))
		{
			throw new NotSupportedException("The public and the private key pair doesn't match.");
		}
		return certificate.CopyWithPrivateKey(certificateWithPrivateKey.GetRSAPrivateKey());
	}

	public static X509Certificate2 CreateCertificateWithPEMPrivateKey(X509Certificate2 certificate, byte[] pemDataBlob, string password = null)
	{
		RSA privateKey = PEMReader.ImportPrivateKeyFromPEM(pemDataBlob, password);
		return new X509Certificate2(certificate.RawData).CopyWithPrivateKey(privateKey);
	}

	[Obsolete("Use the new CreateCertificate methods with CertificateBuilder.")]
	internal static X509Certificate2 CreateCertificate(string applicationUri, string applicationName, string subjectName, IList<string> domainNames, ushort keySize, DateTime startTime, ushort lifetimeInMonths, ushort hashSizeInBits, bool isCA = false, X509Certificate2 issuerCAKeyCert = null, byte[] publicKey = null, int pathLengthConstraint = 0)
	{
		ICertificateBuilder certificateBuilder = null;
		certificateBuilder = ((!isCA) ? CreateCertificate(applicationUri, applicationName, subjectName, domainNames) : CreateCertificate(subjectName));
		certificateBuilder.SetNotBefore(startTime);
		certificateBuilder.SetNotAfter(startTime.AddMonths(lifetimeInMonths));
		certificateBuilder.SetHashAlgorithm(X509Utils.GetRSAHashAlgorithmName(hashSizeInBits));
		if (isCA)
		{
			certificateBuilder.SetCAConstraint(pathLengthConstraint);
		}
		ICertificateBuilderCreateForRSA certificateBuilderCreateForRSA;
		if (issuerCAKeyCert != null)
		{
			ICertificateBuilderIssuer certificateBuilderIssuer = certificateBuilder.SetIssuer(issuerCAKeyCert);
			certificateBuilderCreateForRSA = ((publicKey == null) ? certificateBuilderIssuer.SetRSAKeySize(keySize) : certificateBuilderIssuer.SetRSAPublicKey(publicKey));
		}
		else
		{
			certificateBuilderCreateForRSA = certificateBuilder.SetRSAKeySize(keySize);
		}
		return certificateBuilderCreateForRSA.CreateForRSA();
	}

	private static void SetSuitableDefaults(ref string applicationUri, ref string applicationName, ref string subjectName, ref IList<string> domainNames)
	{
		List<string> list = null;
		if (!string.IsNullOrEmpty(subjectName))
		{
			list = X509Utils.ParseDistinguishedName(subjectName);
		}
		if (string.IsNullOrEmpty(applicationName))
		{
			if (list == null)
			{
				throw new ArgumentNullException("applicationName", "Must specify a applicationName or a subjectName.");
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].StartsWith("CN=", StringComparison.Ordinal))
				{
					applicationName = list[i].Substring(3).Trim();
					break;
				}
			}
		}
		if (string.IsNullOrEmpty(applicationName))
		{
			throw new ArgumentNullException("applicationName", "Must specify a applicationName or a subjectName.");
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < applicationName.Length; j++)
		{
			char c = applicationName[j];
			if (char.IsControl(c) || c == '/' || c == ',' || c == ';')
			{
				c = '+';
			}
			stringBuilder.Append(c);
		}
		applicationName = stringBuilder.ToString();
		if (domainNames == null || domainNames.Count == 0)
		{
			domainNames = new List<string>();
			domainNames.Add(Utils.GetHostName());
		}
		if (string.IsNullOrEmpty(applicationUri))
		{
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("urn:");
			stringBuilder2.Append(domainNames[0]);
			stringBuilder2.Append(':');
			stringBuilder2.Append(applicationName);
			applicationUri = stringBuilder2.ToString();
		}
		if (Utils.ParseUri(applicationUri) == null)
		{
			throw new ArgumentNullException("applicationUri", "Must specify a valid URL.");
		}
		if (string.IsNullOrEmpty(subjectName))
		{
			subjectName = Utils.Format("CN={0}", applicationName);
		}
		if (!subjectName.Contains("CN="))
		{
			subjectName = Utils.Format("CN={0}", subjectName);
		}
		if (domainNames != null && domainNames.Count > 0)
		{
			if (!subjectName.Contains("DC=") && !subjectName.Contains('='))
			{
				subjectName += Utils.Format(", DC={0}", domainNames[0]);
			}
			else
			{
				subjectName = Utils.ReplaceDCLocalhost(subjectName, domainNames[0]);
			}
		}
	}
}
