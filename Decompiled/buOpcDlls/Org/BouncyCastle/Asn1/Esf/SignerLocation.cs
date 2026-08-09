using System;
using Org.BouncyCastle.Asn1.X500;

namespace Org.BouncyCastle.Asn1.Esf;

public class SignerLocation : Asn1Encodable
{
	private readonly DirectoryString countryName;

	private readonly DirectoryString localityName;

	private readonly Asn1Sequence postalAddress;

	public DirectoryString Country => countryName;

	public DirectoryString Locality => localityName;

	public Asn1Sequence PostalAddress => postalAddress;

	public SignerLocation(Asn1Sequence seq)
	{
		foreach (Asn1TaggedObject item in seq)
		{
			switch (item.TagNo)
			{
			case 0:
				countryName = DirectoryString.GetInstance(item, isExplicit: true);
				break;
			case 1:
				localityName = DirectoryString.GetInstance(item, isExplicit: true);
				break;
			case 2:
			{
				bool declaredExplicit = item.IsExplicit();
				postalAddress = Asn1Sequence.GetInstance(item, declaredExplicit);
				if (postalAddress != null && postalAddress.Count > 6)
				{
					throw new ArgumentException("postal address must contain less than 6 strings");
				}
				break;
			}
			default:
				throw new ArgumentException("illegal tag");
			}
		}
	}

	private SignerLocation(DirectoryString countryName, DirectoryString localityName, Asn1Sequence postalAddress)
	{
		if (postalAddress != null && postalAddress.Count > 6)
		{
			throw new ArgumentException("postal address must contain less than 6 strings");
		}
		this.countryName = countryName;
		this.localityName = localityName;
		this.postalAddress = postalAddress;
	}

	public SignerLocation(DirectoryString countryName, DirectoryString localityName, DirectoryString[] postalAddress)
		: this(countryName, localityName, new DerSequence(postalAddress))
	{
	}

	public SignerLocation(DerUtf8String countryName, DerUtf8String localityName, Asn1Sequence postalAddress)
		: this(DirectoryString.GetInstance(countryName), DirectoryString.GetInstance(localityName), postalAddress)
	{
	}

	public static SignerLocation GetInstance(object obj)
	{
		if (obj == null || obj is SignerLocation)
		{
			return (SignerLocation)obj;
		}
		return new SignerLocation(Asn1Sequence.GetInstance(obj));
	}

	public DirectoryString[] GetPostal()
	{
		if (postalAddress == null)
		{
			return null;
		}
		return postalAddress.MapElements((Asn1Encodable element) => DirectoryString.GetInstance(element.ToAsn1Object()));
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(3);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 0, countryName);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 1, localityName);
		asn1EncodableVector.AddOptionalTagged(isExplicit: true, 2, postalAddress);
		return new DerSequence(asn1EncodableVector);
	}
}
