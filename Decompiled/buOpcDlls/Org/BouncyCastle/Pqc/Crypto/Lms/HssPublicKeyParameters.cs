using System;
using System.IO;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class HssPublicKeyParameters : LmsKeyParameters, ILmsContextBasedVerifier
{
	private readonly int m_l;

	private readonly LmsPublicKeyParameters m_lmsPublicKey;

	public int L => m_l;

	public LmsPublicKeyParameters LmsPublicKey => m_lmsPublicKey;

	public HssPublicKeyParameters(int l, LmsPublicKeyParameters lmsPublicKey)
		: base(isPrivateKey: false)
	{
		m_l = l;
		m_lmsPublicKey = lmsPublicKey;
	}

	public static HssPublicKeyParameters GetInstance(object src)
	{
		if (src is HssPublicKeyParameters result)
		{
			return result;
		}
		if (src is BinaryReader binaryReader)
		{
			int l = BinaryReaders.ReadInt32BigEndian(binaryReader);
			LmsPublicKeyParameters instance = LmsPublicKeyParameters.GetInstance(src);
			return new HssPublicKeyParameters(l, instance);
		}
		if (src is byte[] buffer)
		{
			BinaryReader binaryReader2 = null;
			try
			{
				binaryReader2 = new BinaryReader(new MemoryStream(buffer));
				return GetInstance(binaryReader2);
			}
			finally
			{
				binaryReader2?.Close();
			}
		}
		if (src is MemoryStream inStr)
		{
			return GetInstance(Streams.ReadAll(inStr));
		}
		throw new ArgumentException($"cannot parse {src}");
	}

	public override bool Equals(object o)
	{
		if (this == o)
		{
			return true;
		}
		if (o == null || GetType() != o.GetType())
		{
			return false;
		}
		HssPublicKeyParameters hssPublicKeyParameters = (HssPublicKeyParameters)o;
		if (m_l == hssPublicKeyParameters.m_l)
		{
			return m_lmsPublicKey.Equals(hssPublicKeyParameters.m_lmsPublicKey);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int l = m_l;
		return 31 * l + m_lmsPublicKey.GetHashCode();
	}

	public override byte[] GetEncoded()
	{
		return Composer.Compose().U32Str(m_l).Bytes(m_lmsPublicKey.GetEncoded())
			.Build();
	}

	public LmsContext GenerateLmsContext(byte[] sigEnc)
	{
		HssSignature instance;
		try
		{
			instance = HssSignature.GetInstance(sigEnc, L);
		}
		catch (IOException ex)
		{
			throw new Exception("cannot parse signature: " + ex.Message);
		}
		LmsSignedPubKey[] signedPubKeys = instance.GetSignedPubKeys();
		return signedPubKeys[signedPubKeys.Length - 1].GetPublicKey().GenerateOtsContext(instance.Signature).WithSignedPublicKeys(signedPubKeys);
	}

	public bool Verify(LmsContext context)
	{
		LmsSignedPubKey[] signedPubKeys = context.SignedPubKeys;
		if (signedPubKeys.Length != L - 1)
		{
			return false;
		}
		LmsPublicKeyParameters lmsPublicKeyParameters = LmsPublicKey;
		bool flag = false;
		for (int i = 0; i < signedPubKeys.Length; i++)
		{
			LmsSignature signature = signedPubKeys[i].GetSignature();
			byte[] message = signedPubKeys[i].GetPublicKey().ToByteArray();
			if (!Lms.VerifySignature(lmsPublicKeyParameters, signature, message))
			{
				flag = true;
			}
			lmsPublicKeyParameters = signedPubKeys[i].GetPublicKey();
		}
		return !flag & lmsPublicKeyParameters.Verify(context);
	}
}
