// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.Lms
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public static class Lms
{
  internal static ushort D_LEAF = 33410;
  internal static ushort D_INTR = 33667;

  public static LmsPrivateKeyParameters GenerateKeys(
    LMSigParameters parameterSet,
    LMOtsParameters lmOtsParameters,
    int q,
    byte[] I,
    byte[] rootSeed)
  {
    if (rootSeed == null || rootSeed.Length < parameterSet.M)
      throw new ArgumentException($"root seed is less than {parameterSet.M}");
    int maxQ = 1 << parameterSet.H;
    return new LmsPrivateKeyParameters(parameterSet, lmOtsParameters, q, I, maxQ, rootSeed);
  }

  public static LmsSignature GenerateSign(LmsPrivateKeyParameters privateKey, byte[] message)
  {
    LmsContext lmsContext = privateKey.GenerateLmsContext();
    lmsContext.BlockUpdate(message, 0, message.Length);
    return Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateSign(lmsContext);
  }

  public static LmsSignature GenerateSign(LmsContext context)
  {
    LMOtsSignature signature = LMOts.LMOtsGenerateSignature(context.PrivateKey, context.GetQ(), context.C);
    return new LmsSignature(context.PrivateKey.Q, signature, context.SigParams, context.Path);
  }

  public static bool VerifySignature(
    LmsPublicKeyParameters publicKey,
    LmsSignature S,
    byte[] message)
  {
    LmsContext otsContext = publicKey.GenerateOtsContext(S);
    LmsUtilities.ByteArray(message, (IDigest) otsContext);
    return Org.BouncyCastle.Pqc.Crypto.Lms.Lms.VerifySignature(publicKey, otsContext);
  }

  public static bool VerifySignature(LmsPublicKeyParameters publicKey, byte[] S, byte[] message)
  {
    LmsContext lmsContext = publicKey.GenerateLmsContext(S);
    LmsUtilities.ByteArray(message, (IDigest) lmsContext);
    return Org.BouncyCastle.Pqc.Crypto.Lms.Lms.VerifySignature(publicKey, lmsContext);
  }

  public static bool VerifySignature(LmsPublicKeyParameters publicKey, LmsContext context)
  {
    LmsSignature signature = (LmsSignature) context.Signature;
    LMSigParameters sigParameters = signature.SigParameters;
    int h = sigParameters.H;
    byte[][] y = signature.Y;
    byte[] input = LMOts.LMOtsValidateSignatureCalculate(context);
    int n = (1 << h) + signature.Q;
    byte[] i = publicKey.GetI();
    IDigest digest = DigestUtilities.GetDigest(sigParameters.DigestOid);
    byte[] numArray = new byte[digest.GetDigestSize()];
    digest.BlockUpdate(i, 0, i.Length);
    LmsUtilities.U32Str(n, digest);
    LmsUtilities.U16Str((short) Org.BouncyCastle.Pqc.Crypto.Lms.Lms.D_LEAF, digest);
    digest.BlockUpdate(input, 0, input.Length);
    digest.DoFinal(numArray, 0);
    int index = 0;
    while (n > 1)
    {
      if ((n & 1) == 1)
      {
        digest.BlockUpdate(i, 0, i.Length);
        LmsUtilities.U32Str(n / 2, digest);
        LmsUtilities.U16Str((short) Org.BouncyCastle.Pqc.Crypto.Lms.Lms.D_INTR, digest);
        digest.BlockUpdate(y[index], 0, y[index].Length);
        digest.BlockUpdate(numArray, 0, numArray.Length);
        digest.DoFinal(numArray, 0);
      }
      else
      {
        digest.BlockUpdate(i, 0, i.Length);
        LmsUtilities.U32Str(n / 2, digest);
        LmsUtilities.U16Str((short) Org.BouncyCastle.Pqc.Crypto.Lms.Lms.D_INTR, digest);
        digest.BlockUpdate(numArray, 0, numArray.Length);
        digest.BlockUpdate(y[index], 0, y[index].Length);
        digest.DoFinal(numArray, 0);
      }
      n /= 2;
      ++index;
    }
    byte[] sig = numArray;
    return publicKey.MatchesT1(sig);
  }
}
