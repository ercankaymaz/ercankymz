using System;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1;

internal abstract class Asn1UniversalType : Asn1Type
{
	internal readonly Asn1Tag m_tag;

	internal Asn1Tag Tag => m_tag;

	internal Asn1UniversalType(Type platformType, int tagNo)
		: base(platformType)
	{
		m_tag = Asn1Tag.Create(0, tagNo);
	}

	internal Asn1Object CheckedCast(Asn1Object asn1Object)
	{
		if (base.PlatformType.IsInstanceOfType(asn1Object))
		{
			return asn1Object;
		}
		throw new InvalidOperationException("unexpected object: " + Platform.GetTypeName(asn1Object));
	}

	internal virtual Asn1Object FromImplicitPrimitive(DerOctetString octetString)
	{
		throw new InvalidOperationException("unexpected implicit primitive encoding");
	}

	internal virtual Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
	{
		throw new InvalidOperationException("unexpected implicit constructed encoding");
	}

	internal Asn1Object FromByteArray(byte[] bytes)
	{
		return CheckedCast(Asn1Object.FromByteArray(bytes));
	}

	internal Asn1Object GetContextInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
	{
		if (128 != taggedObject.TagClass)
		{
			throw new InvalidOperationException("this method only valid for CONTEXT_SPECIFIC tags");
		}
		return CheckedCast(taggedObject.GetBaseUniversal(declaredExplicit, this));
	}
}
