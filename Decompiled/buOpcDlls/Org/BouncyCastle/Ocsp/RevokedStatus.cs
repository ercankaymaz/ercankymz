using System;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;

namespace Org.BouncyCastle.Ocsp;

public class RevokedStatus : CertificateStatus
{
	private readonly RevokedInfo m_revokedInfo;

	public DateTime RevocationTime => m_revokedInfo.RevocationTime.ToDateTime();

	public bool HasRevocationReason => m_revokedInfo.RevocationReason != null;

	public int RevocationReason
	{
		get
		{
			if (m_revokedInfo.RevocationReason == null)
			{
				throw new InvalidOperationException("attempt to get a reason where none is available");
			}
			return m_revokedInfo.RevocationReason.IntValueExact;
		}
	}

	public RevokedStatus(RevokedInfo revokedInfo)
	{
		m_revokedInfo = revokedInfo;
	}

	public RevokedStatus(DateTime revocationDate)
	{
		m_revokedInfo = new RevokedInfo(new Asn1GeneralizedTime(revocationDate));
	}

	public RevokedStatus(DateTime revocationDate, int reason)
	{
		m_revokedInfo = new RevokedInfo(new Asn1GeneralizedTime(revocationDate), new CrlReason(reason));
	}
}
