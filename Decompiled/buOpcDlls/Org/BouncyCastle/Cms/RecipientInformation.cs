using System;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Cms;

public abstract class RecipientInformation
{
	internal RecipientID rid = new RecipientID();

	internal AlgorithmIdentifier keyEncAlg;

	internal CmsSecureReadable secureReadable;

	private byte[] resultMac;

	public RecipientID RecipientID => rid;

	public AlgorithmIdentifier KeyEncryptionAlgorithmID => keyEncAlg;

	public string KeyEncryptionAlgOid => keyEncAlg.Algorithm.Id;

	public Asn1Object KeyEncryptionAlgParams => keyEncAlg.Parameters?.ToAsn1Object();

	internal RecipientInformation(AlgorithmIdentifier keyEncAlg, CmsSecureReadable secureReadable)
	{
		this.keyEncAlg = keyEncAlg;
		this.secureReadable = secureReadable;
	}

	internal string GetContentAlgorithmName()
	{
		return secureReadable.Algorithm.Algorithm.Id;
	}

	internal CmsTypedStream GetContentFromSessionKey(KeyParameter sKey)
	{
		CmsReadable readable = secureReadable.GetReadable(sKey);
		try
		{
			return new CmsTypedStream(readable.GetInputStream());
		}
		catch (IOException innerException)
		{
			throw new CmsException("error getting .", innerException);
		}
	}

	public byte[] GetContent(ICipherParameters key)
	{
		try
		{
			return CmsUtilities.StreamToByteArray(GetContentStream(key).ContentStream);
		}
		catch (IOException ex)
		{
			throw new Exception("unable to parse internal stream: " + ex);
		}
	}

	public byte[] GetMac()
	{
		if (resultMac == null && secureReadable.CryptoObject is IMac mac)
		{
			resultMac = MacUtilities.DoFinal(mac);
		}
		return Arrays.Clone(resultMac);
	}

	public abstract CmsTypedStream GetContentStream(ICipherParameters key);
}
