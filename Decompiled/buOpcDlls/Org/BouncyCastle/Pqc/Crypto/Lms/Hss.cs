using System;
using System.Collections.Generic;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public static class Hss
{
	public static HssPrivateKeyParameters GenerateHssKeyPair(HssKeyGenerationParameters parameters)
	{
		LmsPrivateKeyParameters[] array = new LmsPrivateKeyParameters[parameters.Depth];
		LmsSignature[] collection = new LmsSignature[parameters.Depth - 1];
		byte[] array2 = new byte[32];
		parameters.Random.NextBytes(array2);
		byte[] array3 = new byte[16];
		parameters.Random.NextBytes(array3);
		byte[] array4 = new byte[0];
		long num = 1L;
		for (int i = 0; i < array.Length; i++)
		{
			LmsParameters lmsParameters = parameters.GetLmsParameters(i);
			if (i == 0)
			{
				array[i] = new LmsPrivateKeyParameters(lmsParameters.LMSigParameters, lmsParameters.LMOtsParameters, 0, array3, 1 << lmsParameters.LMSigParameters.H, array2, isPlaceholder: false);
			}
			else
			{
				array[i] = new LmsPrivateKeyParameters(lmsParameters.LMSigParameters, lmsParameters.LMOtsParameters, -1, array4, 1 << lmsParameters.LMSigParameters.H, array4, isPlaceholder: true);
			}
			num <<= lmsParameters.LMSigParameters.H;
		}
		if (num == 0L)
		{
			num = long.MaxValue;
		}
		return new HssPrivateKeyParameters(parameters.Depth, new List<LmsPrivateKeyParameters>(array), new List<LmsSignature>(collection), 0L, num);
	}

	public static void IncrementIndex(HssPrivateKeyParameters keyPair)
	{
		lock (keyPair)
		{
			RangeTestKeys(keyPair);
			keyPair.IncIndex();
			keyPair.GetKeys()[keyPair.L - 1].IncIndex();
		}
	}

	public static void RangeTestKeys(HssPrivateKeyParameters keyPair)
	{
		lock (keyPair)
		{
			if (keyPair.GetIndex() >= keyPair.IndexLimit)
			{
				throw new Exception("hss private key" + (keyPair.IsShard() ? " shard" : "") + " is exhausted");
			}
			int l = keyPair.L;
			int num = l;
			IList<LmsPrivateKeyParameters> keys = keyPair.GetKeys();
			while (keys[num - 1].GetIndex() == 1 << keys[num - 1].GetSigParameters().H)
			{
				if (--num == 0)
				{
					throw new Exception("hss private key" + (keyPair.IsShard() ? " shard" : "") + " is exhausted the maximum limit for this HSS private key");
				}
			}
			while (num < l)
			{
				keyPair.ReplaceConsumedKey(num++);
			}
		}
	}

	public static HssSignature GenerateSignature(HssPrivateKeyParameters keyPair, byte[] message)
	{
		int l = keyPair.L;
		LmsPrivateKeyParameters lmsPrivateKeyParameters;
		LmsSignedPubKey[] array;
		lock (keyPair)
		{
			RangeTestKeys(keyPair);
			IList<LmsPrivateKeyParameters> keys = keyPair.GetKeys();
			IList<LmsSignature> sig = keyPair.GetSig();
			lmsPrivateKeyParameters = keyPair.GetKeys()[l - 1];
			int i = 0;
			array = new LmsSignedPubKey[l - 1];
			for (; i < l - 1; i++)
			{
				array[i] = new LmsSignedPubKey(sig[i], keys[i + 1].GetPublicKey());
			}
			keyPair.IncIndex();
		}
		LmsContext lmsContext = lmsPrivateKeyParameters.GenerateLmsContext().WithSignedPublicKeys(array);
		lmsContext.BlockUpdate(message, 0, message.Length);
		return GenerateSignature(l, lmsContext);
	}

	public static HssSignature GenerateSignature(int L, LmsContext context)
	{
		return new HssSignature(L - 1, context.SignedPubKeys, Lms.GenerateSign(context));
	}

	public static bool VerifySignature(HssPublicKeyParameters publicKey, HssSignature signature, byte[] message)
	{
		int lMinus = signature.GetLMinus1();
		if (lMinus + 1 != publicKey.L)
		{
			return false;
		}
		LmsSignature[] array = new LmsSignature[lMinus + 1];
		LmsPublicKeyParameters[] array2 = new LmsPublicKeyParameters[lMinus];
		for (int i = 0; i < lMinus; i++)
		{
			array[i] = signature.GetSignedPubKeys()[i].GetSignature();
			array2[i] = signature.GetSignedPubKeys()[i].GetPublicKey();
		}
		array[lMinus] = signature.Signature;
		LmsPublicKeyParameters publicKey2 = publicKey.LmsPublicKey;
		for (int j = 0; j < lMinus; j++)
		{
			LmsSignature s = array[j];
			byte[] message2 = array2[j].ToByteArray();
			if (!Lms.VerifySignature(publicKey2, s, message2))
			{
				return false;
			}
			try
			{
				publicKey2 = array2[j];
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}
		return Lms.VerifySignature(publicKey2, array[lMinus], message);
	}
}
