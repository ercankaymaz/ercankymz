using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cmp;

public class CertificateStatus
{
	private static readonly DefaultSignatureAlgorithmIdentifierFinder sigAlgFinder = new DefaultSignatureAlgorithmIdentifierFinder();

	private readonly DefaultDigestAlgorithmIdentifierFinder digestAlgFinder;

	private readonly CertStatus certStatus;

	public virtual PkiStatusInfo StatusInfo => certStatus.StatusInfo;

	public virtual BigInteger CertRequestID => certStatus.CertReqID.Value;

	public CertificateStatus(DefaultDigestAlgorithmIdentifierFinder digestAlgFinder, CertStatus certStatus)
	{
		this.digestAlgFinder = digestAlgFinder;
		this.certStatus = certStatus;
	}

	public virtual bool IsVerified(X509Certificate cert)
	{
		AlgorithmIdentifier algorithmIdentifier = digestAlgFinder.Find(sigAlgFinder.Find(cert.SigAlgName));
		if (algorithmIdentifier == null)
		{
			throw new CmpException("cannot find algorithm for digest from signature " + cert.SigAlgName);
		}
		byte[] b = DigestUtilities.CalculateDigest(algorithmIdentifier.Algorithm, cert.GetEncoded());
		return Arrays.FixedTimeEquals(certStatus.CertHash.GetOctets(), b);
	}
}
