using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;

namespace Org.BouncyCastle.Asn1.Cmp;

public class OobCertHash : Asn1Encodable
{
	private readonly AlgorithmIdentifier m_hashAlg;

	private readonly CertId m_certId;

	private readonly DerBitString m_hashVal;

	public virtual CertId CertID => m_certId;

	public virtual AlgorithmIdentifier HashAlg => m_hashAlg;

	public virtual DerBitString HashVal => m_hashVal;

	public static OobCertHash GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is OobCertHash result)
		{
			return result;
		}
		return new OobCertHash(Asn1Sequence.GetInstance(obj));
	}

	public static OobCertHash GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
	{
		return GetInstance(Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
	}

	private OobCertHash(Asn1Sequence seq)
	{
		int num = seq.Count - 1;
		m_hashVal = DerBitString.GetInstance(seq[num--]);
		for (int num2 = num; num2 >= 0; num2--)
		{
			Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject)seq[num2];
			if (asn1TaggedObject.TagNo == 0)
			{
				m_hashAlg = AlgorithmIdentifier.GetInstance(asn1TaggedObject, explicitly: true);
			}
			else
			{
				m_certId = CertId.GetInstance(asn1TaggedObject, isExplicit: true);
			}
		}
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(3);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 0, m_hashAlg);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 1, m_certId);
		asn1EncodableVector.Add(m_hashVal);
		return new DerSequence(asn1EncodableVector);
	}
}
