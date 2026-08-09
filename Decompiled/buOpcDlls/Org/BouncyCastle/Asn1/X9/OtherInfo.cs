using System.Collections.Generic;

namespace Org.BouncyCastle.Asn1.X9;

public class OtherInfo : Asn1Encodable
{
	private KeySpecificInfo keyInfo;

	private Asn1OctetString partyAInfo;

	private Asn1OctetString suppPubInfo;

	public KeySpecificInfo KeyInfo => keyInfo;

	public Asn1OctetString PartyAInfo => partyAInfo;

	public Asn1OctetString SuppPubInfo => suppPubInfo;

	public OtherInfo(KeySpecificInfo keyInfo, Asn1OctetString partyAInfo, Asn1OctetString suppPubInfo)
	{
		this.keyInfo = keyInfo;
		this.partyAInfo = partyAInfo;
		this.suppPubInfo = suppPubInfo;
	}

	public OtherInfo(Asn1Sequence seq)
	{
		IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
		enumerator.MoveNext();
		keyInfo = new KeySpecificInfo((Asn1Sequence)enumerator.Current);
		while (enumerator.MoveNext())
		{
			Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject)enumerator.Current;
			if (asn1TaggedObject.TagNo == 0)
			{
				partyAInfo = (Asn1OctetString)asn1TaggedObject.GetObject();
			}
			else if (asn1TaggedObject.TagNo == 2)
			{
				suppPubInfo = (Asn1OctetString)asn1TaggedObject.GetObject();
			}
		}
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(keyInfo);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 0, partyAInfo);
		asn1EncodableVector.Add(new DerTaggedObject(2, suppPubInfo));
		return new DerSequence(asn1EncodableVector);
	}
}
