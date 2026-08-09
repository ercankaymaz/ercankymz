using System;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math;
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

public static class PqcPrivateKeyFactory
{
	public static AsymmetricKeyParameter CreateKey(byte[] privateKeyInfoData)
	{
		return CreateKey(PrivateKeyInfo.GetInstance(Asn1Object.FromByteArray(privateKeyInfoData)));
	}

	public static AsymmetricKeyParameter CreateKey(Stream inStr)
	{
		return CreateKey(PrivateKeyInfo.GetInstance(new Asn1InputStream(inStr).ReadObject()));
	}

	public static AsymmetricKeyParameter CreateKey(PrivateKeyInfo keyInfo)
	{
		DerObjectIdentifier algorithm = keyInfo.PrivateKeyAlgorithm.Algorithm;
		if (algorithm.Equals(PkcsObjectIdentifiers.IdAlgHssLmsHashsig))
		{
			byte[] octets = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
			DerBitString publicKeyData = keyInfo.PublicKeyData;
			if (Pack.BE_To_UInt32(octets, 0) == 1)
			{
				if (publicKeyData != null)
				{
					byte[] octets2 = publicKeyData.GetOctets();
					return LmsPrivateKeyParameters.GetInstance(Arrays.CopyOfRange(octets, 4, octets.Length), Arrays.CopyOfRange(octets2, 4, octets2.Length));
				}
				return LmsPrivateKeyParameters.GetInstance(Arrays.CopyOfRange(octets, 4, octets.Length));
			}
		}
		if (algorithm.On(BCObjectIdentifiers.pqc_kem_mceliece))
		{
			CmcePrivateKey instance = CmcePrivateKey.GetInstance(keyInfo.ParsePrivateKey());
			return new CmcePrivateKeyParameters(PqcUtilities.McElieceParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), instance.Delta, instance.C, instance.G, instance.Alpha, instance.S);
		}
		if (algorithm.On(BCObjectIdentifiers.sphincsPlus))
		{
			byte[] octets3 = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
			return new SphincsPlusPrivateKeyParameters(SphincsPlusParameters.GetParams(BigInteger.ValueOf(Pack.BE_To_UInt32(octets3, 0)).IntValue), Arrays.CopyOfRange(octets3, 4, octets3.Length));
		}
		if (algorithm.On(BCObjectIdentifiers.pqc_kem_saber))
		{
			byte[] octets4 = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
			return new SaberPrivateKeyParameters(PqcUtilities.SaberParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets4);
		}
		if (algorithm.On(BCObjectIdentifiers.picnic))
		{
			byte[] octets5 = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
			return new PicnicPrivateKeyParameters(PqcUtilities.PicnicParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets5);
		}
		if (algorithm.On(BCObjectIdentifiers.pqc_kem_sike))
		{
			byte[] octets6 = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
			return new SikePrivateKeyParameters(PqcUtilities.SikeParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets6);
		}
		if (algorithm.On(BCObjectIdentifiers.pqc_kem_bike))
		{
			byte[] octets7 = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
			BikeParameters bikeParameters = PqcUtilities.BikeParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
			byte[] h = Arrays.CopyOfRange(octets7, 0, bikeParameters.RByte);
			byte[] h2 = Arrays.CopyOfRange(octets7, bikeParameters.RByte, 2 * bikeParameters.RByte);
			byte[] sigma = Arrays.CopyOfRange(octets7, 2 * bikeParameters.RByte, octets7.Length);
			return new BikePrivateKeyParameters(bikeParameters, h, h2, sigma);
		}
		if (algorithm.On(BCObjectIdentifiers.pqc_kem_hqc))
		{
			byte[] octets8 = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
			return new HqcPrivateKeyParameters(PqcUtilities.HqcParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets8);
		}
		if (algorithm.Equals(BCObjectIdentifiers.kyber512) || algorithm.Equals(BCObjectIdentifiers.kyber512_aes) || algorithm.Equals(BCObjectIdentifiers.kyber768) || algorithm.Equals(BCObjectIdentifiers.kyber768_aes) || algorithm.Equals(BCObjectIdentifiers.kyber1024) || algorithm.Equals(BCObjectIdentifiers.kyber1024_aes))
		{
			Asn1Sequence instance2 = Asn1Sequence.GetInstance(keyInfo.ParsePrivateKey());
			KyberParameters parameters = PqcUtilities.KyberParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
			int intValue = DerInteger.GetInstance(instance2[0]).Value.IntValue;
			if (intValue != 0)
			{
				throw new IOException("unknown private key version: " + intValue);
			}
			if (keyInfo.PublicKeyData != null)
			{
				Asn1Sequence instance3 = Asn1Sequence.GetInstance(keyInfo.PublicKeyData.GetOctets());
				return new KyberPrivateKeyParameters(parameters, Asn1OctetString.GetInstance(instance2[1]).GetDerEncoded(), Asn1OctetString.GetInstance(instance2[2]).GetOctets(), Asn1OctetString.GetInstance(instance2[3]).GetOctets(), Asn1OctetString.GetInstance(instance3[0]).GetOctets(), Asn1OctetString.GetInstance(instance3[1]).GetOctets());
			}
			return new KyberPrivateKeyParameters(parameters, Asn1OctetString.GetInstance(instance2[1]).GetOctets(), Asn1OctetString.GetInstance(instance2[2]).GetOctets(), Asn1OctetString.GetInstance(instance2[3]).GetOctets(), null, null);
		}
		if (algorithm.Equals(BCObjectIdentifiers.dilithium2) || algorithm.Equals(BCObjectIdentifiers.dilithium3) || algorithm.Equals(BCObjectIdentifiers.dilithium5) || algorithm.Equals(BCObjectIdentifiers.dilithium2_aes) || algorithm.Equals(BCObjectIdentifiers.dilithium3_aes) || algorithm.Equals(BCObjectIdentifiers.dilithium5_aes))
		{
			Asn1Sequence instance4 = Asn1Sequence.GetInstance(keyInfo.ParsePrivateKey());
			DilithiumParameters parameters2 = PqcUtilities.DilithiumParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
			int intValue2 = DerInteger.GetInstance(instance4[0]).Value.IntValue;
			if (intValue2 != 0)
			{
				throw new IOException("unknown private key version: " + intValue2);
			}
			if (keyInfo.PublicKeyData != null)
			{
				Asn1Sequence instance5 = Asn1Sequence.GetInstance(keyInfo.PublicKeyData.GetOctets());
				return new DilithiumPrivateKeyParameters(parameters2, DerBitString.GetInstance(instance4[1]).GetOctets(), DerBitString.GetInstance(instance4[2]).GetOctets(), DerBitString.GetInstance(instance4[3]).GetOctets(), DerBitString.GetInstance(instance4[4]).GetOctets(), DerBitString.GetInstance(instance4[5]).GetOctets(), DerBitString.GetInstance(instance4[6]).GetOctets(), Asn1OctetString.GetInstance(instance5[1]).GetOctets());
			}
			return new DilithiumPrivateKeyParameters(parameters2, DerBitString.GetInstance(instance4[1]).GetOctets(), DerBitString.GetInstance(instance4[2]).GetOctets(), DerBitString.GetInstance(instance4[3]).GetOctets(), DerBitString.GetInstance(instance4[4]).GetOctets(), DerBitString.GetInstance(instance4[5]).GetOctets(), DerBitString.GetInstance(instance4[6]).GetOctets(), null);
		}
		if (algorithm.Equals(BCObjectIdentifiers.falcon_512) || algorithm.Equals(BCObjectIdentifiers.falcon_1024))
		{
			Asn1Sequence instance6 = Asn1Sequence.GetInstance(keyInfo.ParsePrivateKey());
			FalconParameters parameters3 = PqcUtilities.FalconParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
			DerBitString publicKeyData2 = keyInfo.PublicKeyData;
			int intValue3 = DerInteger.GetInstance(instance6[0]).Value.IntValue;
			if (intValue3 != 1)
			{
				throw new IOException("unknown private key version: " + intValue3);
			}
			if (keyInfo.PublicKeyData != null)
			{
				return new FalconPrivateKeyParameters(parameters3, Asn1OctetString.GetInstance(instance6[1]).GetOctets(), Asn1OctetString.GetInstance(instance6[2]).GetOctets(), Asn1OctetString.GetInstance(instance6[3]).GetOctets(), publicKeyData2.GetOctets());
			}
			return new FalconPrivateKeyParameters(parameters3, Asn1OctetString.GetInstance(instance6[1]).GetOctets(), Asn1OctetString.GetInstance(instance6[2]).GetOctets(), Asn1OctetString.GetInstance(instance6[3]).GetOctets(), null);
		}
		throw new Exception("algorithm identifier in private key not recognised");
	}
}
