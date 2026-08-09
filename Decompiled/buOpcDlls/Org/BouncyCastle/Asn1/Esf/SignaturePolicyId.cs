using System;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Esf;

public class SignaturePolicyId : Asn1Encodable
{
	private readonly DerObjectIdentifier m_sigPolicyIdentifier;

	private readonly OtherHashAlgAndValue m_sigPolicyHash;

	private readonly Asn1Sequence m_sigPolicyQualifiers;

	public DerObjectIdentifier SigPolicyIdentifier => m_sigPolicyIdentifier;

	public OtherHashAlgAndValue SigPolicyHash => m_sigPolicyHash;

	public static SignaturePolicyId GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is SignaturePolicyId result)
		{
			return result;
		}
		if (obj is Asn1Sequence seq)
		{
			return new SignaturePolicyId(seq);
		}
		throw new ArgumentException("Unknown object in 'SignaturePolicyId' factory: " + Platform.GetTypeName(obj), "obj");
	}

	private SignaturePolicyId(Asn1Sequence seq)
	{
		if (seq == null)
		{
			throw new ArgumentNullException("seq");
		}
		if (seq.Count < 2 || seq.Count > 3)
		{
			throw new ArgumentException("Bad sequence size: " + seq.Count, "seq");
		}
		m_sigPolicyIdentifier = (DerObjectIdentifier)seq[0].ToAsn1Object();
		m_sigPolicyHash = OtherHashAlgAndValue.GetInstance(seq[1].ToAsn1Object());
		if (seq.Count > 2)
		{
			m_sigPolicyQualifiers = (Asn1Sequence)seq[2].ToAsn1Object();
		}
	}

	public SignaturePolicyId(DerObjectIdentifier sigPolicyIdentifier, OtherHashAlgAndValue sigPolicyHash)
		: this(sigPolicyIdentifier, sigPolicyHash, (SigPolicyQualifierInfo[])null)
	{
	}

	public SignaturePolicyId(DerObjectIdentifier sigPolicyIdentifier, OtherHashAlgAndValue sigPolicyHash, params SigPolicyQualifierInfo[] sigPolicyQualifiers)
	{
		if (sigPolicyIdentifier == null)
		{
			throw new ArgumentNullException("sigPolicyIdentifier");
		}
		if (sigPolicyHash == null)
		{
			throw new ArgumentNullException("sigPolicyHash");
		}
		m_sigPolicyIdentifier = sigPolicyIdentifier;
		m_sigPolicyHash = sigPolicyHash;
		if (sigPolicyQualifiers != null)
		{
			m_sigPolicyQualifiers = new DerSequence(sigPolicyQualifiers);
		}
	}

	public SignaturePolicyId(DerObjectIdentifier sigPolicyIdentifier, OtherHashAlgAndValue sigPolicyHash, IEnumerable<SigPolicyQualifierInfo> sigPolicyQualifiers)
	{
		if (sigPolicyIdentifier == null)
		{
			throw new ArgumentNullException("sigPolicyIdentifier");
		}
		if (sigPolicyHash == null)
		{
			throw new ArgumentNullException("sigPolicyHash");
		}
		m_sigPolicyIdentifier = sigPolicyIdentifier;
		m_sigPolicyHash = sigPolicyHash;
		if (sigPolicyQualifiers != null)
		{
			m_sigPolicyQualifiers = new DerSequence(Asn1EncodableVector.FromEnumerable(sigPolicyQualifiers));
		}
	}

	public SigPolicyQualifierInfo[] GetSigPolicyQualifiers()
	{
		return m_sigPolicyQualifiers?.MapElements(SigPolicyQualifierInfo.GetInstance);
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(m_sigPolicyIdentifier, m_sigPolicyHash.ToAsn1Object());
		if (m_sigPolicyQualifiers != null)
		{
			asn1EncodableVector.Add(m_sigPolicyQualifiers.ToAsn1Object());
		}
		return new DerSequence(asn1EncodableVector);
	}
}
