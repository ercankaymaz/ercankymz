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

public static class PqcSubjectPublicKeyInfoFactory
{
	public static SubjectPublicKeyInfo CreateSubjectPublicKeyInfo(AsymmetricKeyParameter publicKey)
	{
		if (publicKey == null)
		{
			throw new ArgumentNullException("publicKey");
		}
		if (publicKey.IsPrivate)
		{
			throw new ArgumentException("Private key passed - public key expected.", "publicKey");
		}
		if (publicKey is LmsPublicKeyParameters encodable)
		{
			byte[] contents = Composer.Compose().U32Str(1).Bytes(encodable)
				.Build();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), new DerOctetString(contents));
		}
		if (publicKey is HssPublicKeyParameters { L: var l } hssPublicKeyParameters)
		{
			byte[] contents2 = Composer.Compose().U32Str(l).Bytes(hssPublicKeyParameters.LmsPublicKey)
				.Build();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), new DerOctetString(contents2));
		}
		if (publicKey is SphincsPlusPublicKeyParameters sphincsPlusPublicKeyParameters)
		{
			byte[] encoded = sphincsPlusPublicKeyParameters.GetEncoded();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.SphincsPlusOidLookup(sphincsPlusPublicKeyParameters.Parameters)), new DerOctetString(encoded));
		}
		if (publicKey is CmcePublicKeyParameters cmcePublicKeyParameters)
		{
			byte[] encoded2 = cmcePublicKeyParameters.GetEncoded();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.McElieceOidLookup(cmcePublicKeyParameters.Parameters)), new CmcePublicKey(encoded2));
		}
		if (publicKey is SaberPublicKeyParameters saberPublicKeyParameters)
		{
			byte[] encoded3 = saberPublicKeyParameters.GetEncoded();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.SaberOidLookup(saberPublicKeyParameters.Parameters)), new DerSequence(new DerOctetString(encoded3)));
		}
		if (publicKey is PicnicPublicKeyParameters picnicPublicKeyParameters)
		{
			byte[] encoded4 = picnicPublicKeyParameters.GetEncoded();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.PicnicOidLookup(picnicPublicKeyParameters.Parameters)), new DerOctetString(encoded4));
		}
		if (publicKey is SikePublicKeyParameters sikePublicKeyParameters)
		{
			byte[] encoded5 = sikePublicKeyParameters.GetEncoded();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.SikeOidLookup(sikePublicKeyParameters.Parameters)), new DerOctetString(encoded5));
		}
		if (publicKey is FalconPublicKeyParameters falconPublicKeyParameters)
		{
			byte[] encoded6 = falconPublicKeyParameters.GetEncoded();
			byte[] array = new byte[encoded6.Length + 1];
			array[0] = (byte)falconPublicKeyParameters.Parameters.LogN;
			Array.Copy(encoded6, 0, array, 1, encoded6.Length);
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.FalconOidLookup(falconPublicKeyParameters.Parameters)), array);
		}
		if (publicKey is KyberPublicKeyParameters kyberPublicKeyParameters)
		{
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.KyberOidLookup(kyberPublicKeyParameters.Parameters)), new DerSequence(new Asn1EncodableVector(2)
			{
				new DerOctetString(kyberPublicKeyParameters.T),
				new DerOctetString(kyberPublicKeyParameters.Rho)
			}));
		}
		if (publicKey is DilithiumPublicKeyParameters dilithiumPublicKeyParameters)
		{
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.DilithiumOidLookup(dilithiumPublicKeyParameters.Parameters)), Arrays.Concatenate(dilithiumPublicKeyParameters.Rho, dilithiumPublicKeyParameters.T1));
		}
		if (publicKey is BikePublicKeyParameters bikePublicKeyParameters)
		{
			byte[] encoded7 = bikePublicKeyParameters.GetEncoded();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.BikeOidLookup(bikePublicKeyParameters.Parameters)), new DerOctetString(encoded7));
		}
		if (publicKey is HqcPublicKeyParameters hqcPublicKeyParameters)
		{
			byte[] encoded8 = hqcPublicKeyParameters.GetEncoded();
			return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.HqcOidLookup(hqcPublicKeyParameters.Parameters)), new DerOctetString(encoded8));
		}
		throw new ArgumentException("Class provided no convertible: " + Platform.GetTypeName(publicKey));
	}
}
