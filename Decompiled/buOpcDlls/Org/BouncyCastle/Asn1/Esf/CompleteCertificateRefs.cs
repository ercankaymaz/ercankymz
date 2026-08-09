using System;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Esf;

public class CompleteCertificateRefs : Asn1Encodable
{
	private readonly Asn1Sequence m_otherCertIDs;

	public static CompleteCertificateRefs GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is CompleteCertificateRefs result)
		{
			return result;
		}
		if (obj is Asn1Sequence seq)
		{
			return new CompleteCertificateRefs(seq);
		}
		throw new ArgumentException("Unknown object in 'CompleteCertificateRefs' factory: " + Platform.GetTypeName(obj), "obj");
	}

	private CompleteCertificateRefs(Asn1Sequence seq)
	{
		if (seq == null)
		{
			throw new ArgumentNullException("seq");
		}
		seq.MapElements((Asn1Encodable element) => OtherCertID.GetInstance(element.ToAsn1Object()));
		m_otherCertIDs = seq;
	}

	public CompleteCertificateRefs(params OtherCertID[] otherCertIDs)
	{
		if (otherCertIDs == null)
		{
			throw new ArgumentNullException("otherCertIDs");
		}
		m_otherCertIDs = new DerSequence(otherCertIDs);
	}

	public CompleteCertificateRefs(IEnumerable<OtherCertID> otherCertIDs)
	{
		if (otherCertIDs == null)
		{
			throw new ArgumentNullException("otherCertIDs");
		}
		m_otherCertIDs = new DerSequence(Asn1EncodableVector.FromEnumerable(otherCertIDs));
	}

	public OtherCertID[] GetOtherCertIDs()
	{
		return m_otherCertIDs.MapElements((Asn1Encodable element) => OtherCertID.GetInstance(element.ToAsn1Object()));
	}

	public override Asn1Object ToAsn1Object()
	{
		return m_otherCertIDs;
	}
}
