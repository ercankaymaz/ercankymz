using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Esf;

public class OtherSigningCertificate : Asn1Encodable
{
	private readonly Asn1Sequence m_certs;

	private readonly Asn1Sequence m_policies;

	public static OtherSigningCertificate GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is OtherSigningCertificate result)
		{
			return result;
		}
		if (obj is Asn1Sequence seq)
		{
			return new OtherSigningCertificate(seq);
		}
		throw new ArgumentException("Unknown object in 'OtherSigningCertificate' factory: " + Platform.GetTypeName(obj), "obj");
	}

	private OtherSigningCertificate(Asn1Sequence seq)
	{
		if (seq == null)
		{
			throw new ArgumentNullException("seq");
		}
		if (seq.Count < 1 || seq.Count > 2)
		{
			throw new ArgumentException("Bad sequence size: " + seq.Count, "seq");
		}
		m_certs = Asn1Sequence.GetInstance(seq[0].ToAsn1Object());
		if (seq.Count > 1)
		{
			m_policies = Asn1Sequence.GetInstance(seq[1].ToAsn1Object());
		}
	}

	public OtherSigningCertificate(params OtherCertID[] certs)
		: this(certs, (PolicyInformation[])null)
	{
	}

	public OtherSigningCertificate(OtherCertID[] certs, params PolicyInformation[] policies)
	{
		if (certs == null)
		{
			throw new ArgumentNullException("certs");
		}
		Asn1Encodable[] elements = certs;
		m_certs = new DerSequence(elements);
		if (policies != null)
		{
			elements = policies;
			m_policies = new DerSequence(elements);
		}
	}

	public OtherSigningCertificate(IEnumerable<OtherCertID> certs)
		: this(certs, null)
	{
	}

	public OtherSigningCertificate(IEnumerable<OtherCertID> certs, IEnumerable<PolicyInformation> policies)
	{
		if (certs == null)
		{
			throw new ArgumentNullException("certs");
		}
		m_certs = new DerSequence(Asn1EncodableVector.FromEnumerable(certs));
		if (policies != null)
		{
			m_policies = new DerSequence(Asn1EncodableVector.FromEnumerable(policies));
		}
	}

	public OtherCertID[] GetCerts()
	{
		return m_certs.MapElements((Asn1Encodable element) => OtherCertID.GetInstance(element.ToAsn1Object()));
	}

	public PolicyInformation[] GetPolicies()
	{
		return m_policies?.MapElements((Asn1Encodable element) => PolicyInformation.GetInstance(element.ToAsn1Object()));
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(m_certs);
		asn1EncodableVector.AddOptional(m_policies);
		return new DerSequence(asn1EncodableVector);
	}
}
