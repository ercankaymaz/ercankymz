using System;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Esf;

public class OcspListID : Asn1Encodable
{
	private readonly Asn1Sequence m_ocspResponses;

	public static OcspListID GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is OcspListID result)
		{
			return result;
		}
		if (obj is Asn1Sequence seq)
		{
			return new OcspListID(seq);
		}
		throw new ArgumentException("Unknown object in 'OcspListID' factory: " + Platform.GetTypeName(obj), "obj");
	}

	private OcspListID(Asn1Sequence seq)
	{
		if (seq == null)
		{
			throw new ArgumentNullException("seq");
		}
		if (seq.Count != 1)
		{
			throw new ArgumentException("Bad sequence size: " + seq.Count, "seq");
		}
		m_ocspResponses = (Asn1Sequence)seq[0].ToAsn1Object();
		m_ocspResponses.MapElements((Asn1Encodable element) => OcspResponsesID.GetInstance(element.ToAsn1Object()));
	}

	public OcspListID(params OcspResponsesID[] ocspResponses)
	{
		if (ocspResponses == null)
		{
			throw new ArgumentNullException("ocspResponses");
		}
		m_ocspResponses = new DerSequence(ocspResponses);
	}

	public OcspListID(IEnumerable<OcspResponsesID> ocspResponses)
	{
		if (ocspResponses == null)
		{
			throw new ArgumentNullException("ocspResponses");
		}
		m_ocspResponses = new DerSequence(Asn1EncodableVector.FromEnumerable(ocspResponses));
	}

	public OcspResponsesID[] GetOcspResponses()
	{
		return m_ocspResponses.MapElements((Asn1Encodable element) => OcspResponsesID.GetInstance(element.ToAsn1Object()));
	}

	public override Asn1Object ToAsn1Object()
	{
		return new DerSequence(m_ocspResponses);
	}
}
