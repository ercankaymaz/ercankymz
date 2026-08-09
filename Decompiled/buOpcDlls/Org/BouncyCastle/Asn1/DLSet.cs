namespace Org.BouncyCastle.Asn1;

internal class DLSet : DerSet
{
	internal new static readonly DLSet Empty = new DLSet();

	internal new static DLSet FromVector(Asn1EncodableVector elementVector)
	{
		if (elementVector.Count >= 1)
		{
			return new DLSet(elementVector);
		}
		return Empty;
	}

	internal DLSet()
	{
	}

	internal DLSet(Asn1Encodable element)
		: base(element)
	{
	}

	internal DLSet(params Asn1Encodable[] elements)
		: base(elements, doSort: false)
	{
	}

	internal DLSet(Asn1EncodableVector elementVector)
		: base(elementVector, doSort: false)
	{
	}

	internal DLSet(bool isSorted, Asn1Encodable[] elements)
		: base(isSorted, elements)
	{
	}

	internal override IAsn1Encoding GetEncoding(int encoding)
	{
		if (2 == encoding)
		{
			return base.GetEncoding(encoding);
		}
		return new ConstructedDLEncoding(0, 17, Asn1OutputStream.GetContentsEncodings(encoding, m_elements));
	}

	internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
	{
		if (2 == encoding)
		{
			return base.GetEncodingImplicit(encoding, tagClass, tagNo);
		}
		return new ConstructedDLEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, m_elements));
	}
}
