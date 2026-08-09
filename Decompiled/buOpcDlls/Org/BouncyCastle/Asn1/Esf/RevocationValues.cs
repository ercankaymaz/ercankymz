using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;

namespace Org.BouncyCastle.Asn1.Esf;

public class RevocationValues : Asn1Encodable
{
	private readonly Asn1Sequence m_crlVals;

	private readonly Asn1Sequence m_ocspVals;

	private readonly OtherRevVals m_otherRevVals;

	public OtherRevVals OtherRevVals => m_otherRevVals;

	public static RevocationValues GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is RevocationValues result)
		{
			return result;
		}
		return new RevocationValues(Asn1Sequence.GetInstance(obj));
	}

	private RevocationValues(Asn1Sequence seq)
	{
		if (seq == null)
		{
			throw new ArgumentNullException("seq");
		}
		if (seq.Count > 3)
		{
			throw new ArgumentException("Bad sequence size: " + seq.Count, "seq");
		}
		foreach (Asn1TaggedObject item in seq)
		{
			Asn1Object asn1Object = item.GetObject();
			switch (item.TagNo)
			{
			case 0:
			{
				Asn1Sequence asn1Sequence2 = (Asn1Sequence)asn1Object;
				asn1Sequence2.MapElements((Asn1Encodable element) => CertificateList.GetInstance(element.ToAsn1Object()));
				m_crlVals = asn1Sequence2;
				break;
			}
			case 1:
			{
				Asn1Sequence asn1Sequence = (Asn1Sequence)asn1Object;
				asn1Sequence.MapElements((Asn1Encodable element) => BasicOcspResponse.GetInstance(element.ToAsn1Object()));
				m_ocspVals = asn1Sequence;
				break;
			}
			case 2:
				m_otherRevVals = OtherRevVals.GetInstance(asn1Object);
				break;
			default:
				throw new ArgumentException("Illegal tag in RevocationValues", "seq");
			}
		}
	}

	public RevocationValues(CertificateList[] crlVals, BasicOcspResponse[] ocspVals, OtherRevVals otherRevVals)
	{
		if (crlVals != null)
		{
			Asn1Encodable[] elements = crlVals;
			m_crlVals = new DerSequence(elements);
		}
		if (ocspVals != null)
		{
			Asn1Encodable[] elements = ocspVals;
			m_ocspVals = new DerSequence(elements);
		}
		m_otherRevVals = otherRevVals;
	}

	public RevocationValues(IEnumerable<CertificateList> crlVals, IEnumerable<BasicOcspResponse> ocspVals, OtherRevVals otherRevVals)
	{
		if (crlVals != null)
		{
			m_crlVals = new DerSequence(Asn1EncodableVector.FromEnumerable(crlVals));
		}
		if (ocspVals != null)
		{
			m_ocspVals = new DerSequence(Asn1EncodableVector.FromEnumerable(ocspVals));
		}
		m_otherRevVals = otherRevVals;
	}

	public CertificateList[] GetCrlVals()
	{
		return m_crlVals.MapElements((Asn1Encodable element) => CertificateList.GetInstance(element.ToAsn1Object()));
	}

	public BasicOcspResponse[] GetOcspVals()
	{
		return m_ocspVals.MapElements((Asn1Encodable element) => BasicOcspResponse.GetInstance(element.ToAsn1Object()));
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(3);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 0, m_crlVals);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 1, m_ocspVals);
		if (m_otherRevVals != null)
		{
			asn1EncodableVector.Add(new DerTaggedObject(isExplicit: true, 2, m_otherRevVals.ToAsn1Object()));
		}
		return new DerSequence(asn1EncodableVector);
	}
}
