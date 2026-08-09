using System;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Asn1;
using Org.BouncyCastle.Pqc.Crypto.Bike;
using Org.BouncyCastle.Pqc.Crypto.Cmce;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using Org.BouncyCastle.Pqc.Crypto.Hqc;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Org.BouncyCastle.Pqc.Crypto.Picnic;
using Org.BouncyCastle.Pqc.Crypto.Saber;
using Org.BouncyCastle.Pqc.Crypto.Sike;
using Org.BouncyCastle.Pqc.Crypto.SphincsPlus;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.Utilities;

public static class PqcPrivateKeyInfoFactory
{
	public static PrivateKeyInfo CreatePrivateKeyInfo(AsymmetricKeyParameter privateKey)
	{
		return CreatePrivateKeyInfo(privateKey, null);
	}

	public static PrivateKeyInfo CreatePrivateKeyInfo(AsymmetricKeyParameter privateKey, Asn1Set attributes)
	{
		if (privateKey is LmsPrivateKeyParameters lmsPrivateKeyParameters)
		{
			byte[] contents = Composer.Compose().U32Str(1).Bytes(lmsPrivateKeyParameters)
				.Build();
			byte[] publicKey = Composer.Compose().U32Str(1).Bytes(lmsPrivateKeyParameters.GetPublicKey())
				.Build();
			return new PrivateKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), new DerOctetString(contents), attributes, publicKey);
		}
		if (privateKey is HssPrivateKeyParameters { L: var l } hssPrivateKeyParameters)
		{
			byte[] contents2 = Composer.Compose().U32Str(l).Bytes(hssPrivateKeyParameters)
				.Build();
			byte[] publicKey2 = Composer.Compose().U32Str(l).Bytes(hssPrivateKeyParameters.GetPublicKey().LmsPublicKey)
				.Build();
			return new PrivateKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), new DerOctetString(contents2), attributes, publicKey2);
		}
		if (privateKey is SphincsPlusPrivateKeyParameters sphincsPlusPrivateKeyParameters)
		{
			byte[] encoded = sphincsPlusPrivateKeyParameters.GetEncoded();
			byte[] encodedPublicKey = sphincsPlusPrivateKeyParameters.GetEncodedPublicKey();
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.SphincsPlusOidLookup(sphincsPlusPrivateKeyParameters.Parameters)), new DerOctetString(encoded), attributes, encodedPublicKey);
		}
		if (privateKey is CmcePrivateKeyParameters cmcePrivateKeyParameters)
		{
			cmcePrivateKeyParameters.GetEncoded();
			AlgorithmIdentifier privateKeyAlgorithm = new AlgorithmIdentifier(PqcUtilities.McElieceOidLookup(cmcePrivateKeyParameters.Parameters));
			CmcePrivateKey privateKey2 = new CmcePrivateKey(pubKey: new CmcePublicKey(cmcePrivateKeyParameters.ReconstructPublicKey()), version: 0, delta: cmcePrivateKeyParameters.Delta, c: cmcePrivateKeyParameters.C, g: cmcePrivateKeyParameters.G, alpha: cmcePrivateKeyParameters.Alpha, s: cmcePrivateKeyParameters.S);
			return new PrivateKeyInfo(privateKeyAlgorithm, privateKey2, attributes);
		}
		if (privateKey is SaberPrivateKeyParameters saberPrivateKeyParameters)
		{
			byte[] encoded2 = saberPrivateKeyParameters.GetEncoded();
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.SaberOidLookup(saberPrivateKeyParameters.Parameters)), new DerOctetString(encoded2), attributes);
		}
		if (privateKey is PicnicPrivateKeyParameters picnicPrivateKeyParameters)
		{
			byte[] encoded3 = picnicPrivateKeyParameters.GetEncoded();
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.PicnicOidLookup(picnicPrivateKeyParameters.Parameters)), new DerOctetString(encoded3), attributes);
		}
		if (privateKey is SikePrivateKeyParameters sikePrivateKeyParameters)
		{
			byte[] encoded4 = sikePrivateKeyParameters.GetEncoded();
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.SikeOidLookup(sikePrivateKeyParameters.Parameters)), new DerOctetString(encoded4), attributes);
		}
		if (privateKey is FalconPrivateKeyParameters falconPrivateKeyParameters)
		{
			Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(4);
			asn1EncodableVector.Add(new DerInteger(1));
			asn1EncodableVector.Add(new DerOctetString(falconPrivateKeyParameters.GetSpolyLittleF()));
			asn1EncodableVector.Add(new DerOctetString(falconPrivateKeyParameters.GetG()));
			asn1EncodableVector.Add(new DerOctetString(falconPrivateKeyParameters.GetSpolyBigF()));
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.FalconOidLookup(falconPrivateKeyParameters.Parameters)), new DerSequence(asn1EncodableVector), attributes, falconPrivateKeyParameters.GetPublicKey());
		}
		if (privateKey is KyberPrivateKeyParameters kyberPrivateKeyParameters)
		{
			Asn1EncodableVector asn1EncodableVector2 = new Asn1EncodableVector(4);
			asn1EncodableVector2.Add(new DerInteger(0));
			asn1EncodableVector2.Add(new DerOctetString(kyberPrivateKeyParameters.S));
			asn1EncodableVector2.Add(new DerOctetString(kyberPrivateKeyParameters.Hpk));
			asn1EncodableVector2.Add(new DerOctetString(kyberPrivateKeyParameters.Nonce));
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.KyberOidLookup(kyberPrivateKeyParameters.Parameters)), publicKey: new DerSequence(new Asn1EncodableVector(2)
			{
				new DerOctetString(kyberPrivateKeyParameters.T),
				new DerOctetString(kyberPrivateKeyParameters.Rho)
			}).GetEncoded(), privateKey: new DerSequence(asn1EncodableVector2), attributes: attributes);
		}
		if (privateKey is DilithiumPrivateKeyParameters dilithiumPrivateKeyParameters)
		{
			Asn1EncodableVector asn1EncodableVector3 = new Asn1EncodableVector(7);
			asn1EncodableVector3.Add(new DerInteger(0));
			asn1EncodableVector3.Add(new DerBitString(dilithiumPrivateKeyParameters.Rho));
			asn1EncodableVector3.Add(new DerBitString(dilithiumPrivateKeyParameters.K));
			asn1EncodableVector3.Add(new DerBitString(dilithiumPrivateKeyParameters.Tr));
			asn1EncodableVector3.Add(new DerBitString(dilithiumPrivateKeyParameters.S1));
			asn1EncodableVector3.Add(new DerBitString(dilithiumPrivateKeyParameters.S2));
			asn1EncodableVector3.Add(new DerBitString(dilithiumPrivateKeyParameters.T0));
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.DilithiumOidLookup(dilithiumPrivateKeyParameters.Parameters)), publicKey: new DerSequence(new Asn1EncodableVector(2)
			{
				new DerOctetString(dilithiumPrivateKeyParameters.Rho),
				new DerOctetString(dilithiumPrivateKeyParameters.T1)
			}).GetEncoded(), privateKey: new DerSequence(asn1EncodableVector3), attributes: attributes);
		}
		if (privateKey is BikePrivateKeyParameters bikePrivateKeyParameters)
		{
			byte[] encoded5 = bikePrivateKeyParameters.GetEncoded();
			return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.BikeOidLookup(bikePrivateKeyParameters.Parameters)), new DerOctetString(encoded5), attributes);
		}
		if (privateKey is HqcPrivateKeyParameters hqcPrivateKeyParameters)
		{
			AlgorithmIdentifier privateKeyAlgorithm2 = new AlgorithmIdentifier(PqcUtilities.HqcOidLookup(hqcPrivateKeyParameters.Parameters));
			byte[] privateKey3 = hqcPrivateKeyParameters.PrivateKey;
			return new PrivateKeyInfo(privateKeyAlgorithm2, new DerOctetString(privateKey3), attributes);
		}
		throw new ArgumentException("Class provided is not convertible: " + Platform.GetTypeName(privateKey));
	}
}
