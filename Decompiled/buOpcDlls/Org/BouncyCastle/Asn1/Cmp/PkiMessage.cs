namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiMessage : Asn1Encodable
{
	private readonly PkiHeader header;

	private readonly PkiBody body;

	private readonly DerBitString protection;

	private readonly Asn1Sequence extraCerts;

	public virtual PkiHeader Header => header;

	public virtual PkiBody Body => body;

	public virtual DerBitString Protection => protection;

	public static PkiMessage GetInstance(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is PkiMessage result)
		{
			return result;
		}
		return new PkiMessage(Asn1Sequence.GetInstance(obj));
	}

	public static PkiMessage GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
	{
		return GetInstance(Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
	}

	private PkiMessage(Asn1Sequence seq)
	{
		header = PkiHeader.GetInstance(seq[0]);
		body = PkiBody.GetInstance(seq[1]);
		for (int i = 2; i < seq.Count; i++)
		{
			Asn1TaggedObject instance = Asn1TaggedObject.GetInstance(seq[i]);
			if (instance.HasContextTag(0))
			{
				protection = DerBitString.GetInstance(instance, isExplicit: true);
			}
			else if (instance.HasContextTag(1))
			{
				extraCerts = Asn1Sequence.GetInstance(instance, declaredExplicit: true);
			}
		}
	}

	public PkiMessage(PkiHeader header, PkiBody body, DerBitString protection, CmpCertificate[] extraCerts)
	{
		this.header = header;
		this.body = body;
		this.protection = protection;
		if (extraCerts != null)
		{
			this.extraCerts = new DerSequence(extraCerts);
		}
	}

	public PkiMessage(PkiHeader header, PkiBody body, DerBitString protection)
		: this(header, body, protection, null)
	{
	}

	public PkiMessage(PkiHeader header, PkiBody body)
		: this(header, body, null, null)
	{
	}

	public virtual CmpCertificate[] GetExtraCerts()
	{
		return extraCerts?.MapElements(CmpCertificate.GetInstance);
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(header, body);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 0, protection);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 1, extraCerts);
		return new DerSequence(asn1EncodableVector);
	}
}
