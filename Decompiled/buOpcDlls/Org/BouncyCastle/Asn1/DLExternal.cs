namespace Org.BouncyCastle.Asn1;

internal class DLExternal : DerExternal
{
	internal DLExternal(Asn1EncodableVector vector)
		: base(vector)
	{
	}

	internal DLExternal(Asn1Sequence sequence)
		: base(sequence)
	{
	}

	internal DLExternal(DerObjectIdentifier directReference, DerInteger indirectReference, Asn1ObjectDescriptor dataValueDescriptor, Asn1TaggedObject externalData)
		: base(directReference, indirectReference, dataValueDescriptor, externalData)
	{
	}

	internal DLExternal(DerObjectIdentifier directReference, DerInteger indirectReference, Asn1ObjectDescriptor dataValueDescriptor, int encoding, Asn1Object externalData)
		: base(directReference, indirectReference, dataValueDescriptor, encoding, externalData)
	{
	}

	internal override Asn1Sequence BuildSequence()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(4);
		asn1EncodableVector.AddOptional(directReference, indirectReference, dataValueDescriptor);
		asn1EncodableVector.Add(new DLTaggedObject(encoding == 0, encoding, externalContent));
		return new DLSequence(asn1EncodableVector);
	}

	internal override IAsn1Encoding GetEncoding(int encoding)
	{
		if (2 == encoding)
		{
			return base.GetEncoding(encoding);
		}
		return BuildSequence().GetEncodingImplicit(encoding, 0, 8);
	}

	internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
	{
		if (2 == encoding)
		{
			return base.GetEncodingImplicit(encoding, tagClass, tagNo);
		}
		return BuildSequence().GetEncodingImplicit(encoding, tagClass, tagNo);
	}
}
