using System;

namespace Org.BouncyCastle.Asn1.Ocsp;

public class CrlID : Asn1Encodable
{
	private readonly DerIA5String crlUrl;

	private readonly DerInteger crlNum;

	private readonly Asn1GeneralizedTime crlTime;

	public DerIA5String CrlUrl => crlUrl;

	public DerInteger CrlNum => crlNum;

	public Asn1GeneralizedTime CrlTime => crlTime;

	public static CrlID GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
	{
		return GetInstance(Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
	}

	public static CrlID GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is CrlID result)
		{
			return result;
		}
		return new CrlID(Asn1Sequence.GetInstance(obj));
	}

	[Obsolete("Use 'GetInstance' instead")]
	public CrlID(Asn1Sequence seq)
	{
		foreach (Asn1TaggedObject item in seq)
		{
			switch (item.TagNo)
			{
			case 0:
				crlUrl = DerIA5String.GetInstance(item, declaredExplicit: true);
				break;
			case 1:
				crlNum = DerInteger.GetInstance(item, declaredExplicit: true);
				break;
			case 2:
				crlTime = Asn1GeneralizedTime.GetInstance(item, declaredExplicit: true);
				break;
			default:
				throw new ArgumentException("unknown tag number: " + item.TagNo);
			}
		}
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(3);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 0, crlUrl);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 1, crlNum);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 2, crlTime);
		return new DerSequence(asn1EncodableVector);
	}
}
