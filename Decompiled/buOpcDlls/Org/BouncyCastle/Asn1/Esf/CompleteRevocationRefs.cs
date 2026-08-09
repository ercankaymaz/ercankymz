using System;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Esf;

public class CompleteRevocationRefs : Asn1Encodable
{
	private readonly Asn1Sequence m_crlOcspRefs;

	public static CompleteRevocationRefs GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is CompleteRevocationRefs result)
		{
			return result;
		}
		if (obj is Asn1Sequence seq)
		{
			return new CompleteRevocationRefs(seq);
		}
		throw new ArgumentException("Unknown object in 'CompleteRevocationRefs' factory: " + Platform.GetTypeName(obj), "obj");
	}

	private CompleteRevocationRefs(Asn1Sequence seq)
	{
		if (seq == null)
		{
			throw new ArgumentNullException("seq");
		}
		seq.MapElements((Asn1Encodable element) => CrlOcspRef.GetInstance(element.ToAsn1Object()));
		m_crlOcspRefs = seq;
	}

	public CompleteRevocationRefs(params CrlOcspRef[] crlOcspRefs)
	{
		if (crlOcspRefs == null)
		{
			throw new ArgumentNullException("crlOcspRefs");
		}
		m_crlOcspRefs = new DerSequence(crlOcspRefs);
	}

	public CompleteRevocationRefs(IEnumerable<CrlOcspRef> crlOcspRefs)
	{
		if (crlOcspRefs == null)
		{
			throw new ArgumentNullException("crlOcspRefs");
		}
		m_crlOcspRefs = new DerSequence(Asn1EncodableVector.FromEnumerable(crlOcspRefs));
	}

	public CrlOcspRef[] GetCrlOcspRefs()
	{
		return m_crlOcspRefs.MapElements((Asn1Encodable element) => CrlOcspRef.GetInstance(element.ToAsn1Object()));
	}

	public override Asn1Object ToAsn1Object()
	{
		return m_crlOcspRefs;
	}
}
