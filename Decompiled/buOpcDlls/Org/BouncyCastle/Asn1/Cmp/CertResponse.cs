using System;

namespace Org.BouncyCastle.Asn1.Cmp;

public class CertResponse : Asn1Encodable
{
	private readonly DerInteger m_certReqId;

	private readonly PkiStatusInfo m_status;

	private readonly CertifiedKeyPair m_certifiedKeyPair;

	private readonly Asn1OctetString m_rspInfo;

	public virtual DerInteger CertReqID => m_certReqId;

	public virtual PkiStatusInfo Status => m_status;

	public virtual CertifiedKeyPair CertifiedKeyPair => m_certifiedKeyPair;

	public static CertResponse GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is CertResponse result)
		{
			return result;
		}
		return new CertResponse(Asn1Sequence.GetInstance(obj));
	}

	public static CertResponse GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
	{
		return GetInstance(Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
	}

	private CertResponse(Asn1Sequence seq)
	{
		m_certReqId = DerInteger.GetInstance(seq[0]);
		m_status = PkiStatusInfo.GetInstance(seq[1]);
		if (seq.Count < 3)
		{
			return;
		}
		if (seq.Count == 3)
		{
			Asn1Encodable asn1Encodable = seq[2];
			if (asn1Encodable is Asn1OctetString)
			{
				m_rspInfo = Asn1OctetString.GetInstance(asn1Encodable);
			}
			else
			{
				m_certifiedKeyPair = CertifiedKeyPair.GetInstance(asn1Encodable);
			}
		}
		else
		{
			m_certifiedKeyPair = CertifiedKeyPair.GetInstance(seq[2]);
			m_rspInfo = Asn1OctetString.GetInstance(seq[3]);
		}
	}

	public CertResponse(DerInteger certReqId, PkiStatusInfo status)
		: this(certReqId, status, null, null)
	{
	}

	public CertResponse(DerInteger certReqId, PkiStatusInfo status, CertifiedKeyPair certifiedKeyPair, Asn1OctetString rspInfo)
	{
		if (certReqId == null)
		{
			throw new ArgumentNullException("certReqId");
		}
		if (status == null)
		{
			throw new ArgumentNullException("status");
		}
		m_certReqId = certReqId;
		m_status = status;
		m_certifiedKeyPair = certifiedKeyPair;
		m_rspInfo = rspInfo;
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(m_certReqId, m_status);
		asn1EncodableVector.AddOptional(m_certifiedKeyPair, m_rspInfo);
		return new DerSequence(asn1EncodableVector);
	}
}
