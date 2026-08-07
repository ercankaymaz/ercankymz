// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public static class LmsUtilities
{
  public static void U32Str(int n, IDigest d)
  {
    d.Update((byte) (n >> 24));
    d.Update((byte) (n >> 16 /*0x10*/));
    d.Update((byte) (n >> 8));
    d.Update((byte) n);
  }

  public static void U16Str(short n, IDigest d)
  {
    d.Update((byte) ((uint) n >> 8));
    d.Update((byte) n);
  }

  public static void ByteArray(byte[] array, IDigest digest)
  {
    digest.BlockUpdate(array, 0, array.Length);
  }

  public static void ByteArray(byte[] array, int start, int len, IDigest digest)
  {
    digest.BlockUpdate(array, start, len);
  }

  public static int CalculateStrength(LmsParameters lmsParameters)
  {
    LMSigParameters lmSigParameters = lmsParameters != null ? lmsParameters.LMSigParameters : throw new ArgumentNullException(nameof (lmsParameters));
    return lmSigParameters.M << lmSigParameters.H;
  }
}
