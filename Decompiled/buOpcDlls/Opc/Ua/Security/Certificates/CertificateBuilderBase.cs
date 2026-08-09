using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public abstract class CertificateBuilderBase : IX509Certificate, ICertificateBuilder, ICertificateBuilderConfig, ICertificateBuilderPublicKey, ICertificateBuilderRSAPublicKey, ICertificateBuilderECDsaPublicKey, ICertificateBuilderSetIssuer, ICertificateBuilderParameter, ICertificateBuilderRSAParameter, ICertificateBuilderECCParameter, ICertificateBuilderCreateForRSA, ICertificateBuilderIssuer, ICertificateBuilderCreateGenerator, ICertificateBuilderCreateForRSAGenerator, ICertificateBuilderCreateForECDsaGenerator, ICertificateBuilderCreateForRSAAny, ICertificateBuilderCreateForECDsa, ICertificateBuilderCreateForECDsaAny
{
	protected bool m_isCA;

	protected int m_pathLengthConstraint;

	protected int m_serialNumberLength;

	protected bool m_presetSerial;

	protected byte[] m_serialNumber;

	protected X509ExtensionCollection m_extensions;

	protected RSA m_rsaPublicKey;

	protected int m_keySize;

	protected ECDsa m_ecdsaPublicKey;

	protected ECCurve? m_curve;

	private X509Certificate2 m_issuerCAKeyCert;

	private DateTime m_notBefore;

	private DateTime m_notAfter;

	private HashAlgorithmName m_hashAlgorithmName;

	private X500DistinguishedName m_subjectName;

	private X500DistinguishedName m_issuerName;

	public X500DistinguishedName SubjectName => m_subjectName;

	public X500DistinguishedName IssuerName => m_issuerName;

	public DateTime NotBefore => m_notBefore;

	public DateTime NotAfter => m_notAfter;

	public string SerialNumber => m_serialNumber.ToHexString(invertEndian: true);

	public HashAlgorithmName HashAlgorithmName => m_hashAlgorithmName;

	public X509ExtensionCollection Extensions => m_extensions;

	protected X509Certificate2 IssuerCAKeyCert => m_issuerCAKeyCert;

	protected CertificateBuilderBase(X500DistinguishedName subjectName)
	{
		m_issuerName = (m_subjectName = subjectName);
		Initialize();
	}

	protected CertificateBuilderBase(string subjectName)
	{
		m_issuerName = (m_subjectName = new X500DistinguishedName(subjectName));
		Initialize();
	}

	protected virtual void Initialize()
	{
		m_notBefore = DateTime.UtcNow.AddDays(-1.0).Date;
		m_notAfter = NotBefore.AddMonths(X509Defaults.LifeTime);
		m_hashAlgorithmName = X509Defaults.HashAlgorithmName;
		m_serialNumberLength = X509Defaults.SerialNumberLengthMin;
		m_extensions = new X509ExtensionCollection();
	}

	public byte[] GetSerialNumber()
	{
		return m_serialNumber;
	}

	public abstract X509Certificate2 CreateForRSA();

	public abstract X509Certificate2 CreateForRSA(X509SignatureGenerator generator);

	public abstract X509Certificate2 CreateForECDsa();

	public abstract X509Certificate2 CreateForECDsa(X509SignatureGenerator generator);

	public ICertificateBuilder SetSerialNumberLength(int length)
	{
		if (length > X509Defaults.SerialNumberLengthMax || length == 0)
		{
			throw new ArgumentOutOfRangeException("length", "SerialNumber length out of Range");
		}
		m_serialNumberLength = length;
		m_presetSerial = false;
		return this;
	}

	public ICertificateBuilder SetSerialNumber(byte[] serialNumber)
	{
		if (serialNumber.Length > X509Defaults.SerialNumberLengthMax || serialNumber.Length == 0)
		{
			throw new ArgumentOutOfRangeException("serialNumber", "SerialNumber array exceeds supported length.");
		}
		m_serialNumberLength = serialNumber.Length;
		m_serialNumber = new byte[serialNumber.Length];
		Array.Copy(serialNumber, m_serialNumber, serialNumber.Length);
		m_serialNumber[m_serialNumberLength - 1] &= 127;
		m_presetSerial = true;
		return this;
	}

	public ICertificateBuilder CreateSerialNumber()
	{
		NewSerialNumber();
		m_presetSerial = true;
		return this;
	}

	public ICertificateBuilder SetNotBefore(DateTime notBefore)
	{
		m_notBefore = notBefore;
		return this;
	}

	public ICertificateBuilder SetNotAfter(DateTime notAfter)
	{
		m_notAfter = notAfter;
		return this;
	}

	public ICertificateBuilder SetLifeTime(TimeSpan lifeTime)
	{
		m_notAfter = m_notBefore.Add(lifeTime);
		return this;
	}

	public ICertificateBuilder SetLifeTime(ushort months)
	{
		m_notAfter = m_notBefore.AddMonths((months == 0) ? X509Defaults.LifeTime : months);
		return this;
	}

	public ICertificateBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName)
	{
		m_hashAlgorithmName = hashAlgorithmName;
		return this;
	}

	public ICertificateBuilder SetCAConstraint(int pathLengthConstraint = -1)
	{
		m_isCA = true;
		m_pathLengthConstraint = pathLengthConstraint;
		m_serialNumberLength = X509Defaults.SerialNumberLengthMax;
		return this;
	}

	public virtual ICertificateBuilderCreateForRSAAny SetRSAKeySize(ushort keySize)
	{
		if (keySize == 0)
		{
			keySize = X509Defaults.RSAKeySize;
		}
		if (keySize % 1024 != 0 || keySize < X509Defaults.RSAKeySizeMin || keySize > X509Defaults.RSAKeySizeMax)
		{
			throw new ArgumentException("KeySize must be a multiple of 1024 or is not in the allowed range.", "keySize");
		}
		m_keySize = keySize;
		return this;
	}

	public virtual ICertificateBuilder AddExtension(X509Extension extension)
	{
		if (extension == null)
		{
			throw new ArgumentNullException("extension");
		}
		m_extensions.Add(extension);
		return this;
	}

	public virtual ICertificateBuilderCreateForECDsaAny SetECCurve(ECCurve curve)
	{
		m_curve = curve;
		return this;
	}

	public abstract ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(byte[] publicKey);

	public virtual ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(ECDsa publicKey)
	{
		if (publicKey == null)
		{
			throw new ArgumentNullException("publicKey");
		}
		m_ecdsaPublicKey = publicKey;
		return this;
	}

	public abstract ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey);

	public virtual ICertificateBuilderCreateForRSAAny SetRSAPublicKey(RSA publicKey)
	{
		if (publicKey == null)
		{
			throw new ArgumentNullException("publicKey");
		}
		m_rsaPublicKey = publicKey;
		return this;
	}

	public virtual ICertificateBuilderIssuer SetIssuer(X509Certificate2 issuerCertificate)
	{
		if (issuerCertificate == null)
		{
			throw new ArgumentNullException("issuerCertificate");
		}
		m_issuerCAKeyCert = issuerCertificate;
		m_issuerName = issuerCertificate.SubjectName;
		return this;
	}

	protected void ValidateSettings()
	{
		if (m_issuerCAKeyCert != null)
		{
			if (NotAfter.ToUniversalTime() > m_issuerCAKeyCert.NotAfter.ToUniversalTime())
			{
				m_notAfter = m_issuerCAKeyCert.NotAfter.ToUniversalTime();
			}
			if (NotBefore.ToUniversalTime() < m_issuerCAKeyCert.NotBefore.ToUniversalTime())
			{
				m_notBefore = m_issuerCAKeyCert.NotBefore.ToUniversalTime();
			}
		}
	}

	protected virtual void NewSerialNumber()
	{
		using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
		{
			m_serialNumber = new byte[m_serialNumberLength];
			randomNumberGenerator.GetBytes(m_serialNumber);
		}
		m_serialNumber[m_serialNumberLength - 1] &= 127;
	}
}
