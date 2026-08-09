using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Cms;

public class CmsAuthenticatedDataGenerator : CmsAuthenticatedGenerator
{
	public CmsAuthenticatedDataGenerator()
	{
	}

	public CmsAuthenticatedDataGenerator(SecureRandom random)
		: base(random)
	{
	}

	private CmsAuthenticatedData Generate(CmsProcessable content, string macOid, CipherKeyGenerator keyGen)
	{
		KeyParameter keyParameter;
		AlgorithmIdentifier algorithmIdentifier;
		Asn1OctetString content2;
		Asn1OctetString mac2;
		try
		{
			byte[] array = keyGen.GenerateKey();
			keyParameter = ParameterUtilities.CreateKeyParameter(macOid, array);
			Asn1Encodable asn1Params = GenerateAsn1Parameters(macOid, array);
			algorithmIdentifier = GetAlgorithmIdentifier(macOid, keyParameter, asn1Params, out var _);
			IMac mac = MacUtilities.GetMac(macOid);
			mac.Init(keyParameter);
			MemoryStream memoryStream = new MemoryStream();
			using (TeeOutputStream outStream = new TeeOutputStream(memoryStream, new MacSink(mac)))
			{
				content.Write(outStream);
			}
			content2 = new BerOctetString(memoryStream.ToArray());
			mac2 = new DerOctetString(MacUtilities.DoFinal(mac));
		}
		catch (SecurityUtilityException innerException)
		{
			throw new CmsException("couldn't create cipher.", innerException);
		}
		catch (InvalidKeyException innerException2)
		{
			throw new CmsException("key invalid in message.", innerException2);
		}
		catch (IOException innerException3)
		{
			throw new CmsException("exception decoding algorithm parameters.", innerException3);
		}
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(recipientInfoGenerators.Count);
		foreach (RecipientInfoGenerator recipientInfoGenerator in recipientInfoGenerators)
		{
			try
			{
				asn1EncodableVector.Add(recipientInfoGenerator.Generate(keyParameter, m_random));
			}
			catch (InvalidKeyException innerException4)
			{
				throw new CmsException("key inappropriate for algorithm.", innerException4);
			}
			catch (GeneralSecurityException innerException5)
			{
				throw new CmsException("error making encrypted content.", innerException5);
			}
		}
		ContentInfo encapsulatedContent = new ContentInfo(CmsObjectIdentifiers.Data, content2);
		return new CmsAuthenticatedData(new ContentInfo(CmsObjectIdentifiers.AuthenticatedData, new AuthenticatedData(null, new DerSet(asn1EncodableVector), algorithmIdentifier, null, encapsulatedContent, null, mac2, null)));
	}

	public CmsAuthenticatedData Generate(CmsProcessable content, string encryptionOid)
	{
		try
		{
			CipherKeyGenerator keyGenerator = GeneratorUtilities.GetKeyGenerator(encryptionOid);
			keyGenerator.Init(new KeyGenerationParameters(m_random, keyGenerator.DefaultStrength));
			return Generate(content, encryptionOid, keyGenerator);
		}
		catch (SecurityUtilityException innerException)
		{
			throw new CmsException("can't find key generation algorithm.", innerException);
		}
	}
}
