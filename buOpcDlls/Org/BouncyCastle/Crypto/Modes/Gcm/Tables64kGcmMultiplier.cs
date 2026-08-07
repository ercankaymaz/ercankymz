// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.Gcm.Tables64kGcmMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes.Gcm;

[Obsolete("Will be removed")]
public class Tables64kGcmMultiplier : IGcmMultiplier
{
  private byte[] H;
  private GcmUtilities.FieldElement[][] T;

  public void Init(byte[] H)
  {
    if (this.T == null)
      this.T = new GcmUtilities.FieldElement[16 /*0x10*/][];
    else if (Arrays.AreEqual(this.H, H))
      return;
    this.H = Arrays.Clone(H);
    for (int index1 = 0; index1 < 16 /*0x10*/; ++index1)
    {
      GcmUtilities.FieldElement[] fieldElementArray = this.T[index1] = new GcmUtilities.FieldElement[256 /*0x0100*/];
      if (index1 == 0)
      {
        GcmUtilities.AsFieldElement(this.H, out fieldElementArray[1]);
        GcmUtilities.MultiplyP7(ref fieldElementArray[1]);
      }
      else
        GcmUtilities.MultiplyP8(ref this.T[index1 - 1][1], out fieldElementArray[1]);
      for (int index2 = 1; index2 < 128 /*0x80*/; ++index2)
      {
        GcmUtilities.DivideP(ref fieldElementArray[index2], out fieldElementArray[index2 << 1]);
        GcmUtilities.Xor(ref fieldElementArray[index2 << 1], ref fieldElementArray[1], out fieldElementArray[(index2 << 1) + 1]);
      }
    }
  }

  public void MultiplyH(byte[] x)
  {
    GcmUtilities.FieldElement[] fieldElementArray1 = this.T[15];
    int index1 = (int) x[15];
    ulong n0 = fieldElementArray1[index1].n0;
    ulong n1 = fieldElementArray1[index1].n1;
    for (int index2 = 14; index2 >= 0; --index2)
    {
      GcmUtilities.FieldElement[] fieldElementArray2 = this.T[index2];
      int index3 = (int) x[index2];
      n0 ^= fieldElementArray2[index3].n0;
      n1 ^= fieldElementArray2[index3].n1;
    }
    GcmUtilities.AsBytes(n0, n1, x);
  }
}
