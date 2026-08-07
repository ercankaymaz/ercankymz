// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.Hss
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public static class Hss
{
  public static HssPrivateKeyParameters GenerateHssKeyPair(HssKeyGenerationParameters parameters)
  {
    LmsPrivateKeyParameters[] collection1 = new LmsPrivateKeyParameters[parameters.Depth];
    LmsSignature[] collection2 = new LmsSignature[parameters.Depth - 1];
    byte[] numArray1 = new byte[32 /*0x20*/];
    parameters.Random.NextBytes(numArray1);
    byte[] numArray2 = new byte[16 /*0x10*/];
    parameters.Random.NextBytes(numArray2);
    byte[] numArray3 = new byte[0];
    long indexLimit = 1;
    for (int index = 0; index < collection1.Length; ++index)
    {
      LmsParameters lmsParameters = parameters.GetLmsParameters(index);
      collection1[index] = index != 0 ? new LmsPrivateKeyParameters(lmsParameters.LMSigParameters, lmsParameters.LMOtsParameters, -1, numArray3, 1 << lmsParameters.LMSigParameters.H, numArray3, true) : new LmsPrivateKeyParameters(lmsParameters.LMSigParameters, lmsParameters.LMOtsParameters, 0, numArray2, 1 << lmsParameters.LMSigParameters.H, numArray1, false);
      indexLimit <<= lmsParameters.LMSigParameters.H;
    }
    if (indexLimit == 0L)
      indexLimit = long.MaxValue;
    return new HssPrivateKeyParameters(parameters.Depth, (IList<LmsPrivateKeyParameters>) new List<LmsPrivateKeyParameters>((IEnumerable<LmsPrivateKeyParameters>) collection1), (IList<LmsSignature>) new List<LmsSignature>((IEnumerable<LmsSignature>) collection2), 0L, indexLimit);
  }

  public static void IncrementIndex(HssPrivateKeyParameters keyPair)
  {
    lock (keyPair)
    {
      Hss.RangeTestKeys(keyPair);
      keyPair.IncIndex();
      keyPair.GetKeys()[keyPair.L - 1].IncIndex();
    }
  }

  public static void RangeTestKeys(HssPrivateKeyParameters keyPair)
  {
    lock (keyPair)
    {
      int num1 = keyPair.GetIndex() < keyPair.IndexLimit ? keyPair.L : throw new Exception($"hss private key{(keyPair.IsShard() ? " shard" : "")} is exhausted");
      int num2 = num1;
      IList<LmsPrivateKeyParameters> keys = keyPair.GetKeys();
      while (keys[num2 - 1].GetIndex() == 1 << keys[num2 - 1].GetSigParameters().H)
      {
        if (--num2 == 0)
          throw new Exception($"hss private key{(keyPair.IsShard() ? " shard" : "")} is exhausted the maximum limit for this HSS private key");
      }
      while (num2 < num1)
        keyPair.ReplaceConsumedKey(num2++);
    }
  }

  public static HssSignature GenerateSignature(HssPrivateKeyParameters keyPair, byte[] message)
  {
    int l = keyPair.L;
    LmsPrivateKeyParameters key;
    LmsSignedPubKey[] signedPubKeys;
    lock (keyPair)
    {
      Hss.RangeTestKeys(keyPair);
      IList<LmsPrivateKeyParameters> keys = keyPair.GetKeys();
      IList<LmsSignature> sig = keyPair.GetSig();
      key = keyPair.GetKeys()[l - 1];
      int index = 0;
      signedPubKeys = new LmsSignedPubKey[l - 1];
      for (; index < l - 1; ++index)
        signedPubKeys[index] = new LmsSignedPubKey(sig[index], keys[index + 1].GetPublicKey());
      keyPair.IncIndex();
    }
    LmsContext context = key.GenerateLmsContext().WithSignedPublicKeys(signedPubKeys);
    context.BlockUpdate(message, 0, message.Length);
    return Hss.GenerateSignature(l, context);
  }

  public static HssSignature GenerateSignature(int L, LmsContext context)
  {
    return new HssSignature(L - 1, context.SignedPubKeys, Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateSign(context));
  }

  public static bool VerifySignature(
    HssPublicKeyParameters publicKey,
    HssSignature signature,
    byte[] message)
  {
    int lminus1 = signature.GetLMinus1();
    if (lminus1 + 1 != publicKey.L)
      return false;
    LmsSignature[] lmsSignatureArray = new LmsSignature[lminus1 + 1];
    LmsPublicKeyParameters[] publicKeyParametersArray = new LmsPublicKeyParameters[lminus1];
    for (int index = 0; index < lminus1; ++index)
    {
      lmsSignatureArray[index] = signature.GetSignedPubKeys()[index].GetSignature();
      publicKeyParametersArray[index] = signature.GetSignedPubKeys()[index].GetPublicKey();
    }
    lmsSignatureArray[lminus1] = signature.Signature;
    LmsPublicKeyParameters lmsPublicKey = publicKey.LmsPublicKey;
    for (int index = 0; index < lminus1; ++index)
    {
      LmsSignature S = lmsSignatureArray[index];
      byte[] byteArray = publicKeyParametersArray[index].ToByteArray();
      if (!Org.BouncyCastle.Pqc.Crypto.Lms.Lms.VerifySignature(lmsPublicKey, S, byteArray))
        return false;
      try
      {
        lmsPublicKey = publicKeyParametersArray[index];
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message, ex);
      }
    }
    return Org.BouncyCastle.Pqc.Crypto.Lms.Lms.VerifySignature(lmsPublicKey, lmsSignatureArray[lminus1], message);
  }
}
