using System;

namespace Org.BouncyCastle.Asn1;

public class DerGeneralizedTime : Asn1GeneralizedTime
{
	public DerGeneralizedTime(string timeString)
		: base(timeString)
	{
	}

	public DerGeneralizedTime(DateTime dateTime)
		: base(dateTime)
	{
	}

	internal DerGeneralizedTime(byte[] contents)
		: base(contents)
	{
	}

	internal override IAsn1Encoding GetEncoding(int encoding)
	{
		return new PrimitiveEncoding(0, 24, GetContents(2));
	}

	internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
	{
		return new PrimitiveEncoding(tagClass, tagNo, GetContents(2));
	}
}
