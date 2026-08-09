using System;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;
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

public static class PqcPublicKeyFactory
{
	private abstract class SubjectPublicKeyInfoConverter
	{
		internal abstract AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams);
	}

	private class LmsConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] array = Asn1OctetString.GetInstance(keyInfo.ParsePublicKey()).GetOctets();
			if (Pack.BE_To_UInt32(array, 0) == 1)
			{
				return LmsPublicKeyParameters.GetInstance(Arrays.CopyOfRange(array, 4, array.Length));
			}
			if (array.Length == 64)
			{
				array = Arrays.CopyOfRange(array, 4, array.Length);
			}
			return HssPublicKeyParameters.GetInstance(array);
		}
	}

	private class SphincsPlusConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] octets = Asn1OctetString.GetInstance(keyInfo.ParsePublicKey()).GetOctets();
			return new SphincsPlusPublicKeyParameters(SphincsPlusParameters.GetParams((int)Pack.BE_To_UInt32(octets, 0)), Arrays.CopyOfRange(octets, 4, octets.Length));
		}
	}

	private class CmceConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] t = CmcePublicKey.GetInstance(keyInfo.ParsePublicKey()).T;
			return new CmcePublicKeyParameters(PqcUtilities.McElieceParamsLookup(keyInfo.AlgorithmID.Algorithm), t);
		}
	}

	private class SaberConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] octets = Asn1OctetString.GetInstance(Asn1Sequence.GetInstance(keyInfo.ParsePublicKey())[0]).GetOctets();
			return new SaberPublicKeyParameters(PqcUtilities.SaberParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
		}
	}

	private class PicnicConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] octets = Asn1OctetString.GetInstance(keyInfo.ParsePublicKey()).GetOctets();
			return new PicnicPublicKeyParameters(PqcUtilities.PicnicParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
		}
	}

	[Obsolete("Will be removed")]
	private class SikeConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] octets = Asn1OctetString.GetInstance(keyInfo.ParsePublicKey()).GetOctets();
			return new SikePublicKeyParameters(PqcUtilities.SikeParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
		}
	}

	private class DilithiumConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			DilithiumParameters parameters = PqcUtilities.DilithiumParamsLookup(keyInfo.AlgorithmID.Algorithm);
			try
			{
				Asn1Object asn1Object = keyInfo.ParsePublicKey();
				if (asn1Object is Asn1Sequence)
				{
					Asn1Sequence instance = Asn1Sequence.GetInstance(asn1Object);
					return new DilithiumPublicKeyParameters(parameters, Asn1OctetString.GetInstance(instance[0]).GetOctets(), Asn1OctetString.GetInstance(instance[1]).GetOctets());
				}
				byte[] octets = Asn1OctetString.GetInstance(asn1Object).GetOctets();
				return new DilithiumPublicKeyParameters(parameters, octets);
			}
			catch (Exception)
			{
				return new DilithiumPublicKeyParameters(parameters, keyInfo.PublicKeyData.GetOctets());
			}
		}
	}

	private class KyberConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			KyberParameters parameters = PqcUtilities.KyberParamsLookup(keyInfo.AlgorithmID.Algorithm);
			Asn1Object asn1Object = keyInfo.ParsePublicKey();
			if (asn1Object is Asn1Sequence)
			{
				Asn1Sequence instance = Asn1Sequence.GetInstance(asn1Object);
				return new KyberPublicKeyParameters(parameters, Asn1OctetString.GetInstance(instance[0]).GetOctets(), Asn1OctetString.GetInstance(instance[1]).GetOctets());
			}
			byte[] octets = Asn1OctetString.GetInstance(asn1Object).GetOctets();
			return new KyberPublicKeyParameters(parameters, octets);
		}
	}

	private class FalconConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			FalconParameters falconParameters = PqcUtilities.FalconParamsLookup(keyInfo.AlgorithmID.Algorithm);
			try
			{
				Asn1Object asn1Object = keyInfo.ParsePublicKey();
				if (asn1Object is Asn1Sequence)
				{
					byte[] octets = Asn1OctetString.GetInstance(Asn1Sequence.GetInstance(asn1Object)[0]).GetOctets();
					return new FalconPublicKeyParameters(falconParameters, octets);
				}
				byte[] octets2 = Asn1OctetString.GetInstance(asn1Object).GetOctets();
				if (octets2[0] != (byte)falconParameters.LogN)
				{
					throw new ArgumentException("byte[] enc of Falcon h value not tagged correctly");
				}
				return new FalconPublicKeyParameters(falconParameters, Arrays.CopyOfRange(octets2, 1, octets2.Length));
			}
			catch (Exception)
			{
				byte[] octets3 = keyInfo.PublicKeyData.GetOctets();
				if (octets3[0] != (byte)falconParameters.LogN)
				{
					throw new ArgumentException("byte[] enc of Falcon h value not tagged correctly");
				}
				return new FalconPublicKeyParameters(falconParameters, Arrays.CopyOfRange(octets3, 1, octets3.Length));
			}
		}
	}

	private class BikeConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] octets = Asn1OctetString.GetInstance(keyInfo.ParsePublicKey()).GetOctets();
			return new BikePublicKeyParameters(PqcUtilities.BikeParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
		}
	}

	private class HqcConverter : SubjectPublicKeyInfoConverter
	{
		internal override AsymmetricKeyParameter GetPublicKeyParameters(SubjectPublicKeyInfo keyInfo, object defaultParams)
		{
			byte[] octets = Asn1OctetString.GetInstance(keyInfo.ParsePublicKey()).GetOctets();
			return new HqcPublicKeyParameters(PqcUtilities.HqcParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
		}
	}

	private static Dictionary<DerObjectIdentifier, SubjectPublicKeyInfoConverter> Converters;

	static PqcPublicKeyFactory()
	{
		Converters = new Dictionary<DerObjectIdentifier, SubjectPublicKeyInfoConverter>();
		Converters[PkcsObjectIdentifiers.IdAlgHssLmsHashsig] = new LmsConverter();
		Converters[BCObjectIdentifiers.sphincsPlus] = new SphincsPlusConverter();
		Converters[BCObjectIdentifiers.sphincsPlus_shake_256] = new SphincsPlusConverter();
		Converters[BCObjectIdentifiers.sphincsPlus_sha_256] = new SphincsPlusConverter();
		Converters[BCObjectIdentifiers.sphincsPlus_sha_512] = new SphincsPlusConverter();
		Converters[BCObjectIdentifiers.mceliece348864_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece348864f_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece460896_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece460896f_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece6688128_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece6688128f_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece6960119_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece6960119f_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece8192128_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.mceliece8192128f_r3] = new CmceConverter();
		Converters[BCObjectIdentifiers.lightsaberkem128r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.saberkem128r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.firesaberkem128r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.lightsaberkem192r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.saberkem192r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.firesaberkem192r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.lightsaberkem256r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.saberkem256r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.firesaberkem256r3] = new SaberConverter();
		Converters[BCObjectIdentifiers.ulightsaberkemr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.usaberkemr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.ufiresaberkemr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.lightsaberkem90sr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.saberkem90sr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.firesaberkem90sr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.ulightsaberkem90sr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.usaberkem90sr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.ufiresaberkem90sr3] = new SaberConverter();
		Converters[BCObjectIdentifiers.picnic] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl1fs] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl1ur] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl3fs] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl3ur] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl5fs] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl5ur] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnic3l1] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnic3l3] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnic3l5] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl1full] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl3full] = new PicnicConverter();
		Converters[BCObjectIdentifiers.picnicl5full] = new PicnicConverter();
		Converters[BCObjectIdentifiers.sikep434] = new SikeConverter();
		Converters[BCObjectIdentifiers.sikep503] = new SikeConverter();
		Converters[BCObjectIdentifiers.sikep610] = new SikeConverter();
		Converters[BCObjectIdentifiers.sikep751] = new SikeConverter();
		Converters[BCObjectIdentifiers.sikep434_compressed] = new SikeConverter();
		Converters[BCObjectIdentifiers.sikep503_compressed] = new SikeConverter();
		Converters[BCObjectIdentifiers.sikep610_compressed] = new SikeConverter();
		Converters[BCObjectIdentifiers.sikep751_compressed] = new SikeConverter();
		Converters[BCObjectIdentifiers.dilithium2] = new DilithiumConverter();
		Converters[BCObjectIdentifiers.dilithium3] = new DilithiumConverter();
		Converters[BCObjectIdentifiers.dilithium5] = new DilithiumConverter();
		Converters[BCObjectIdentifiers.dilithium2_aes] = new DilithiumConverter();
		Converters[BCObjectIdentifiers.dilithium3_aes] = new DilithiumConverter();
		Converters[BCObjectIdentifiers.dilithium5_aes] = new DilithiumConverter();
		Converters[BCObjectIdentifiers.falcon_512] = new FalconConverter();
		Converters[BCObjectIdentifiers.falcon_1024] = new FalconConverter();
		Converters[BCObjectIdentifiers.kyber512] = new KyberConverter();
		Converters[BCObjectIdentifiers.kyber512_aes] = new KyberConverter();
		Converters[BCObjectIdentifiers.kyber768] = new KyberConverter();
		Converters[BCObjectIdentifiers.kyber768_aes] = new KyberConverter();
		Converters[BCObjectIdentifiers.kyber1024] = new KyberConverter();
		Converters[BCObjectIdentifiers.kyber1024_aes] = new KyberConverter();
		Converters[BCObjectIdentifiers.bike128] = new BikeConverter();
		Converters[BCObjectIdentifiers.bike192] = new BikeConverter();
		Converters[BCObjectIdentifiers.bike256] = new BikeConverter();
		Converters[BCObjectIdentifiers.hqc128] = new HqcConverter();
		Converters[BCObjectIdentifiers.hqc192] = new HqcConverter();
		Converters[BCObjectIdentifiers.hqc256] = new HqcConverter();
	}

	public static AsymmetricKeyParameter CreateKey(byte[] keyInfoData)
	{
		return CreateKey(SubjectPublicKeyInfo.GetInstance(Asn1Object.FromByteArray(keyInfoData)));
	}

	public static AsymmetricKeyParameter CreateKey(Stream inStr)
	{
		return CreateKey(SubjectPublicKeyInfo.GetInstance(new Asn1InputStream(inStr).ReadObject()));
	}

	public static AsymmetricKeyParameter CreateKey(SubjectPublicKeyInfo keyInfo)
	{
		return CreateKey(keyInfo, null);
	}

	public static AsymmetricKeyParameter CreateKey(SubjectPublicKeyInfo keyInfo, object defaultParams)
	{
		AlgorithmIdentifier algorithmID = keyInfo.AlgorithmID;
		SubjectPublicKeyInfoConverter subjectPublicKeyInfoConverter = Converters[algorithmID.Algorithm];
		if (subjectPublicKeyInfoConverter != null)
		{
			return subjectPublicKeyInfoConverter.GetPublicKeyParameters(keyInfo, defaultParams);
		}
		throw new IOException("algorithm identifier in public key not recognised: " + algorithmID.Algorithm);
	}
}
