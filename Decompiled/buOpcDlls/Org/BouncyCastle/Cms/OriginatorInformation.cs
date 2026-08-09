using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cms;

public class OriginatorInformation
{
	private readonly OriginatorInfo originatorInfo;

	public OriginatorInformation(OriginatorInfo originatorInfo)
	{
		this.originatorInfo = originatorInfo;
	}

	public virtual IStore<X509Certificate> GetCertificates()
	{
		return CmsSignedHelper.Instance.GetCertificates(originatorInfo.Certificates);
	}

	public virtual IStore<X509Crl> GetCrls()
	{
		return CmsSignedHelper.Instance.GetCrls(originatorInfo.Crls);
	}

	public virtual OriginatorInfo ToAsn1Structure()
	{
		return originatorInfo;
	}
}
