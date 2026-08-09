using System;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Esf;

public class CrlListID : Asn1Encodable
{
	private readonly Asn1Sequence m_crls;

	public static CrlListID GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is CrlListID result)
		{
			return result;
		}
		if (obj is Asn1Sequence seq)
		{
			return new CrlListID(seq);
		}
		throw new ArgumentException("Unknown object in 'CrlListID' factory: " + Platform.GetTypeName(obj), "obj");
	}

	private CrlListID(Asn1Sequence seq)
	{
		if (seq == null)
		{
			throw new ArgumentNullException("seq");
		}
		if (seq.Count != 1)
		{
			throw new ArgumentException("Bad sequence size: " + seq.Count, "seq");
		}
		m_crls = (Asn1Sequence)seq[0].ToAsn1Object();
		m_crls.MapElements((Asn1Encodable element) => CrlValidatedID.GetInstance(element.ToAsn1Object()));
	}

	public CrlListID(params CrlValidatedID[] crls)
	{
		if (crls == null)
		{
			throw new ArgumentNullException("crls");
		}
		m_crls = new DerSequence(crls);
	}

	public CrlListID(IEnumerable<CrlValidatedID> crls)
	{
		if (crls == null)
		{
			throw new ArgumentNullException("crls");
		}
		m_crls = new DerSequence(Asn1EncodableVector.FromEnumerable(crls));
	}

	public CrlValidatedID[] GetCrls()
	{
		return m_crls.MapElements((Asn1Encodable element) => CrlValidatedID.GetInstance(element.ToAsn1Object()));
	}

	public override Asn1Object ToAsn1Object()
	{
		return new DerSequence(m_crls);
	}
}
