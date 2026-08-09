using System;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Ocsp;

public class ResponseData : Asn1Encodable
{
	private static readonly DerInteger V1 = new DerInteger(0);

	private readonly bool versionPresent;

	private readonly DerInteger version;

	private readonly ResponderID responderID;

	private readonly Asn1GeneralizedTime producedAt;

	private readonly Asn1Sequence responses;

	private readonly X509Extensions responseExtensions;

	public DerInteger Version => version;

	public ResponderID ResponderID => responderID;

	public Asn1GeneralizedTime ProducedAt => producedAt;

	public Asn1Sequence Responses => responses;

	public X509Extensions ResponseExtensions => responseExtensions;

	public static ResponseData GetInstance(Asn1TaggedObject obj, bool explicitly)
	{
		return GetInstance(Asn1Sequence.GetInstance(obj, explicitly));
	}

	public static ResponseData GetInstance(object obj)
	{
		if (obj == null || obj is ResponseData)
		{
			return (ResponseData)obj;
		}
		if (obj is Asn1Sequence)
		{
			return new ResponseData((Asn1Sequence)obj);
		}
		throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), "obj");
	}

	public ResponseData(DerInteger version, ResponderID responderID, Asn1GeneralizedTime producedAt, Asn1Sequence responses, X509Extensions responseExtensions)
	{
		this.version = version;
		this.responderID = responderID;
		this.producedAt = producedAt;
		this.responses = responses;
		this.responseExtensions = responseExtensions;
	}

	public ResponseData(ResponderID responderID, Asn1GeneralizedTime producedAt, Asn1Sequence responses, X509Extensions responseExtensions)
		: this(V1, responderID, producedAt, responses, responseExtensions)
	{
	}

	private ResponseData(Asn1Sequence seq)
	{
		int num = 0;
		if (seq[0] is Asn1TaggedObject asn1TaggedObject)
		{
			if (asn1TaggedObject.TagNo == 0)
			{
				versionPresent = true;
				version = DerInteger.GetInstance(asn1TaggedObject, declaredExplicit: true);
				num++;
			}
			else
			{
				version = V1;
			}
		}
		else
		{
			version = V1;
		}
		responderID = ResponderID.GetInstance(seq[num++]);
		producedAt = (Asn1GeneralizedTime)seq[num++];
		responses = (Asn1Sequence)seq[num++];
		if (seq.Count > num)
		{
			responseExtensions = X509Extensions.GetInstance((Asn1TaggedObject)seq[num], declaredExplicit: true);
		}
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(3);
		if (versionPresent || !version.Equals(V1))
		{
			asn1EncodableVector.Add(new DerTaggedObject(isExplicit: true, 0, version));
		}
		asn1EncodableVector.Add(responderID, producedAt, responses);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 1, responseExtensions);
		return new DerSequence(asn1EncodableVector);
	}
}
