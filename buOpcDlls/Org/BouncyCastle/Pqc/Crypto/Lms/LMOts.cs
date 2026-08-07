// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LMOts
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public static class LMOts
{
  private static ushort D_PBLC = 32896;
  private static int ITER_K = 20;
  private static int ITER_PREV = 23;
  private static int ITER_J = 22;
  internal static int SEED_RANDOMISER_INDEX = -3;
  internal static int SEED_LEN = 32 /*0x20*/;
  internal static int MAX_HASH = 32 /*0x20*/;
  internal static ushort D_MESG = 33153;

  public static int Coef(byte[] S, int i, int w)
  {
    int index = i * w / 8;
    int num1 = 8 / w;
    int num2 = w * (~i & num1 - 1);
    int num3 = (1 << w) - 1;
    return (int) S[index] >> num2 & num3;
  }

  public static int Cksm(byte[] S, int sLen, LMOtsParameters parameters)
  {
    int num1 = 0;
    int num2 = (1 << parameters.W) - 1;
    for (int i = 0; i < sLen * 8 / parameters.W; ++i)
      num1 = num1 + num2 - LMOts.Coef(S, i, parameters.W);
    return num1 << parameters.Ls;
  }

  public static LMOtsPublicKey LmsOtsGeneratePublicKey(LMOtsPrivateKey privateKey)
  {
    byte[] publicKey = LMOts.LmsOtsGeneratePublicKey(privateKey.Parameters, privateKey.I, privateKey.Q, privateKey.MasterSecret);
    return new LMOtsPublicKey(privateKey.Parameters, privateKey.I, privateKey.Q, publicKey);
  }

  internal static byte[] LmsOtsGeneratePublicKey(
    LMOtsParameters parameter,
    byte[] I,
    int q,
    byte[] masterSecret)
  {
    IDigest digest1 = DigestUtilities.GetDigest(parameter.DigestOid);
    byte[] input = Composer.Compose().Bytes(I).U32Str(q).U16Str((int) LMOts.D_PBLC).PadUntil(0, 22).Build();
    digest1.BlockUpdate(input, 0, input.Length);
    IDigest digest2 = DigestUtilities.GetDigest(parameter.DigestOid);
    byte[] numArray = Composer.Compose().Bytes(I).U32Str(q).PadUntil(0, 23 + digest2.GetDigestSize()).Build();
    SeedDerive seedDerive = new SeedDerive(I, masterSecret, DigestUtilities.GetDigest(parameter.DigestOid))
    {
      Q = q,
      J = 0
    };
    int p = parameter.P;
    int n1 = parameter.N;
    int num = (1 << parameter.W) - 1;
    for (ushort n2 = 0; (int) n2 < p; ++n2)
    {
      seedDerive.DeriveSeed((int) n2 < p - 1, numArray, LMOts.ITER_PREV);
      Pack.UInt16_To_BE(n2, numArray, LMOts.ITER_K);
      for (int index = 0; index < num; ++index)
      {
        numArray[LMOts.ITER_J] = (byte) index;
        digest2.BlockUpdate(numArray, 0, numArray.Length);
        digest2.DoFinal(numArray, LMOts.ITER_PREV);
      }
      digest1.BlockUpdate(numArray, LMOts.ITER_PREV, n1);
    }
    byte[] output = new byte[digest1.GetDigestSize()];
    digest1.DoFinal(output, 0);
    return output;
  }

  public static LMOtsSignature lm_ots_generate_signature(
    LMSigParameters sigParams,
    LMOtsPrivateKey privateKey,
    byte[][] path,
    byte[] message,
    bool preHashed)
  {
    byte[] numArray = new byte[LMOts.MAX_HASH + 2];
    byte[] C;
    if (!preHashed)
    {
      LmsContext signatureContext = privateKey.GetSignatureContext(sigParams, path);
      LmsUtilities.ByteArray(message, 0, message.Length, (IDigest) signatureContext);
      C = signatureContext.C;
      numArray = signatureContext.GetQ();
    }
    else
    {
      C = new byte[LMOts.SEED_LEN];
      Array.Copy((Array) message, 0, (Array) numArray, 0, privateKey.Parameters.N);
    }
    return LMOts.LMOtsGenerateSignature(privateKey, numArray, C);
  }

  public static LMOtsSignature LMOtsGenerateSignature(
    LMOtsPrivateKey privateKey,
    byte[] Q,
    byte[] C)
  {
    LMOtsParameters parameters = privateKey.Parameters;
    int n = parameters.N;
    int p = parameters.P;
    int w = parameters.W;
    byte[] numArray1 = new byte[p * n];
    IDigest digest = DigestUtilities.GetDigest(parameters.DigestOid);
    SeedDerive derivationFunction = privateKey.GetDerivationFunction();
    int num1 = LMOts.Cksm(Q, n, parameters);
    Q[n] = (byte) (num1 >> 8 & (int) byte.MaxValue);
    Q[n + 1] = (byte) num1;
    byte[] numArray2 = Composer.Compose().Bytes(privateKey.I).U32Str(privateKey.Q).PadUntil(0, LMOts.ITER_PREV + n).Build();
    derivationFunction.J = 0;
    for (ushort index1 = 0; (int) index1 < p; ++index1)
    {
      Pack.UInt16_To_BE(index1, numArray2, LMOts.ITER_K);
      derivationFunction.DeriveSeed((int) index1 < p - 1, numArray2, LMOts.ITER_PREV);
      int num2 = LMOts.Coef(Q, (int) index1, w);
      for (int index2 = 0; index2 < num2; ++index2)
      {
        numArray2[LMOts.ITER_J] = (byte) index2;
        digest.BlockUpdate(numArray2, 0, LMOts.ITER_PREV + n);
        digest.DoFinal(numArray2, LMOts.ITER_PREV);
      }
      Array.Copy((Array) numArray2, LMOts.ITER_PREV, (Array) numArray1, n * (int) index1, n);
    }
    return new LMOtsSignature(parameters, C, numArray1);
  }

  public static bool LMOtsValidateSignature(
    LMOtsPublicKey publicKey,
    LMOtsSignature signature,
    byte[] message,
    bool prehashed)
  {
    if (!signature.ParamType.Equals((object) publicKey.Parameters))
      throw new LmsException("public key and signature ots types do not match");
    return Arrays.AreEqual(LMOts.LMOtsValidateSignatureCalculate(publicKey, signature, message), publicKey.K);
  }

  public static byte[] LMOtsValidateSignatureCalculate(
    LMOtsPublicKey publicKey,
    LMOtsSignature signature,
    byte[] message)
  {
    LmsContext otsContext = publicKey.CreateOtsContext(signature);
    LmsUtilities.ByteArray(message, (IDigest) otsContext);
    return LMOts.LMOtsValidateSignatureCalculate(otsContext);
  }

  public static byte[] LMOtsValidateSignatureCalculate(LmsContext context)
  {
    LMOtsPublicKey publicKey = context.PublicKey;
    LMOtsParameters parameters = publicKey.Parameters;
    object signature = context.Signature;
    LMOtsSignature lmOtsSignature = !(signature is LmsSignature) ? (LMOtsSignature) signature : ((LmsSignature) signature).OtsSignature;
    int n = parameters.N;
    int w = parameters.W;
    int p = parameters.P;
    byte[] q1 = context.GetQ();
    int num1 = LMOts.Cksm(q1, n, parameters);
    q1[n] = (byte) (num1 >> 8 & (int) byte.MaxValue);
    q1[n + 1] = (byte) num1;
    byte[] i = publicKey.I;
    int q2 = publicKey.Q;
    IDigest digest1 = DigestUtilities.GetDigest(parameters.DigestOid);
    LmsUtilities.ByteArray(i, digest1);
    LmsUtilities.U32Str(q2, digest1);
    LmsUtilities.U16Str((short) LMOts.D_PBLC, digest1);
    byte[] numArray = Composer.Compose().Bytes(i).U32Str(q2).PadUntil(0, LMOts.ITER_PREV + n).Build();
    int num2 = (1 << w) - 1;
    byte[] y = lmOtsSignature.Y;
    IDigest digest2 = DigestUtilities.GetDigest(parameters.DigestOid);
    for (ushort index1 = 0; (int) index1 < p; ++index1)
    {
      Pack.UInt16_To_BE(index1, numArray, LMOts.ITER_K);
      Array.Copy((Array) y, (int) index1 * n, (Array) numArray, LMOts.ITER_PREV, n);
      for (int index2 = LMOts.Coef(q1, (int) index1, w); index2 < num2; ++index2)
      {
        numArray[LMOts.ITER_J] = (byte) index2;
        digest2.BlockUpdate(numArray, 0, LMOts.ITER_PREV + n);
        digest2.DoFinal(numArray, LMOts.ITER_PREV);
      }
      digest1.BlockUpdate(numArray, LMOts.ITER_PREV, n);
    }
    byte[] output = new byte[n];
    digest1.DoFinal(output, 0);
    return output;
  }
}
