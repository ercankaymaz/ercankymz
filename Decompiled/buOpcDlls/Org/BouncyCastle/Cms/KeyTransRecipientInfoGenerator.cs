using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cms;

public class KeyTransRecipientInfoGenerator : RecipientInfoGenerator
{
	private readonly IKeyWrapper m_keyWrapper;

	private IssuerAndSerialNumber m_issuerAndSerialNumber;

	private Asn1OctetString m_subjectKeyIdentifier;

	protected virtual AlgorithmIdentifier AlgorithmDetails => (AlgorithmIdentifier)m_keyWrapper.AlgorithmDetails;

	public KeyTransRecipientInfoGenerator(X509Certificate recipCert, IKeyWrapper keyWrapper)
		: this(new IssuerAndSerialNumber(recipCert.IssuerDN, new DerInteger(recipCert.SerialNumber)), keyWrapper)
	{
	}

	public KeyTransRecipientInfoGenerator(IssuerAndSerialNumber issuerAndSerial, IKeyWrapper keyWrapper)
	{
		m_issuerAndSerialNumber = issuerAndSerial;
		m_keyWrapper = keyWrapper;
	}

	public KeyTransRecipientInfoGenerator(byte[] subjectKeyID, IKeyWrapper keyWrapper)
	{
		m_subjectKeyIdentifier = new DerOctetString(subjectKeyID);
		m_keyWrapper = keyWrapper;
	}

	public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
	{
		AlgorithmIdentifier algorithmDetails = AlgorithmDetails;
		byte[] contents = GenerateWrappedKey(contentEncryptionKey);
		RecipientIdentifier rid = ((m_issuerAndSerialNumber == null) ? new RecipientIdentifier(m_subjectKeyIdentifier) : new RecipientIdentifier(m_issuerAndSerialNumber));
		return new RecipientInfo(new KeyTransRecipientInfo(rid, algorithmDetails, new DerOctetString(contents)));
	}

	protected virtual byte[] GenerateWrappedKey(KeyParameter contentEncryptionKey)
	{
		return m_keyWrapper.Wrap(contentEncryptionKey.GetKey()).Collect();
	}
}
