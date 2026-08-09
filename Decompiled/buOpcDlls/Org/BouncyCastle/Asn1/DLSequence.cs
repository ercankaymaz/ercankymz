namespace Org.BouncyCastle.Asn1;

internal class DLSequence : DerSequence
{
	internal new static readonly DLSequence Empty = new DLSequence();

	internal new static DLSequence FromVector(Asn1EncodableVector elementVector)
	{
		if (elementVector.Count >= 1)
		{
			return new DLSequence(elementVector);
		}
		return Empty;
	}

	internal DLSequence()
	{
	}

	internal DLSequence(Asn1Encodable element)
		: base(element)
	{
	}

	public DLSequence(Asn1Encodable element1, Asn1Encodable element2)
		: base(element1, element2)
	{
	}

	internal DLSequence(params Asn1Encodable[] elements)
		: base(elements)
	{
	}

	internal DLSequence(Asn1EncodableVector elementVector)
		: base(elementVector)
	{
	}

	internal DLSequence(Asn1Encodable[] elements, bool clone)
		: base(elements, clone)
	{
	}

	internal override IAsn1Encoding GetEncoding(int encoding)
	{
		if (2 == encoding)
		{
			return base.GetEncoding(encoding);
		}
		return new ConstructedDLEncoding(0, 16, Asn1OutputStream.GetContentsEncodings(encoding, elements));
	}

	internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
	{
		if (2 == encoding)
		{
			return base.GetEncodingImplicit(encoding, tagClass, tagNo);
		}
		return new ConstructedDLEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, elements));
	}

	internal override DerBitString ToAsn1BitString()
	{
		return new DLBitString(BerBitString.FlattenBitStrings(GetConstructedBitStrings()), check: false);
	}

	internal override DerExternal ToAsn1External()
	{
		return new DLExternal(this);
	}

	internal override Asn1Set ToAsn1Set()
	{
		return new DLSet(isSorted: false, elements);
	}
}
