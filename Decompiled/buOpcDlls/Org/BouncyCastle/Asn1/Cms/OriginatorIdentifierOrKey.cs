using System;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1.Cms;

public class OriginatorIdentifierOrKey : Asn1Encodable, IAsn1Choice
{
	private readonly Asn1Encodable id;

	public Asn1Encodable ID => id;

	public IssuerAndSerialNumber IssuerAndSerialNumber
	{
		get
		{
			if (id is IssuerAndSerialNumber)
			{
				return (IssuerAndSerialNumber)id;
			}
			return null;
		}
	}

	public SubjectKeyIdentifier SubjectKeyIdentifier
	{
		get
		{
			if (id is Asn1TaggedObject && ((Asn1TaggedObject)id).TagNo == 0)
			{
				return SubjectKeyIdentifier.GetInstance((Asn1TaggedObject)id, explicitly: false);
			}
			return null;
		}
	}

	public OriginatorPublicKey OriginatorPublicKey
	{
		get
		{
			if (id is Asn1TaggedObject && ((Asn1TaggedObject)id).TagNo == 1)
			{
				return OriginatorPublicKey.GetInstance((Asn1TaggedObject)id, explicitly: false);
			}
			return null;
		}
	}

	public OriginatorIdentifierOrKey(IssuerAndSerialNumber id)
	{
		this.id = id;
	}

	public OriginatorIdentifierOrKey(SubjectKeyIdentifier id)
	{
		this.id = new DerTaggedObject(isExplicit: false, 0, id);
	}

	public OriginatorIdentifierOrKey(OriginatorPublicKey id)
	{
		this.id = new DerTaggedObject(isExplicit: false, 1, id);
	}

	private OriginatorIdentifierOrKey(Asn1TaggedObject id)
	{
		this.id = id;
	}

	public static OriginatorIdentifierOrKey GetInstance(Asn1TaggedObject o, bool explicitly)
	{
		if (!explicitly)
		{
			throw new ArgumentException("Can't implicitly tag OriginatorIdentifierOrKey");
		}
		return GetInstance(o.GetObject());
	}

	public static OriginatorIdentifierOrKey GetInstance(object o)
	{
		if (o == null || o is OriginatorIdentifierOrKey)
		{
			return (OriginatorIdentifierOrKey)o;
		}
		if (o is IssuerAndSerialNumber)
		{
			return new OriginatorIdentifierOrKey((IssuerAndSerialNumber)o);
		}
		if (o is SubjectKeyIdentifier)
		{
			return new OriginatorIdentifierOrKey((SubjectKeyIdentifier)o);
		}
		if (o is OriginatorPublicKey)
		{
			return new OriginatorIdentifierOrKey((OriginatorPublicKey)o);
		}
		if (o is Asn1TaggedObject)
		{
			return new OriginatorIdentifierOrKey((Asn1TaggedObject)o);
		}
		throw new ArgumentException("Invalid OriginatorIdentifierOrKey: " + Platform.GetTypeName(o));
	}

	public override Asn1Object ToAsn1Object()
	{
		return id.ToAsn1Object();
	}
}
