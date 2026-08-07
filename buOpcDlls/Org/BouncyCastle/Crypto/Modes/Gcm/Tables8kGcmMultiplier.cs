// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.Gcm.Tables8kGcmMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes.Gcm;

[Obsolete("Will be removed")]
public class Tables8kGcmMultiplier : IGcmMultiplier
{
  private byte[] H;
  private GcmUtilities.FieldElement[][] T;

  public void Init(byte[] H)
  {
    if (this.T == null)
      this.T = new GcmUtilities.FieldElement[2][];
    else if (Arrays.AreEqual(this.H, H))
      return;
    this.H = Arrays.Clone(H);
    for (int index1 = 0; index1 < 2; ++index1)
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
    GcmUtilities.FieldElement[] fieldElementArray1 = this.T[0];
    GcmUtilities.FieldElement[] fieldElementArray2 = this.T[1];
    int index1 = (int) x[15];
    int index2 = (int) x[14];
    ulong x1 = fieldElementArray1[index2].n1 ^ fieldElementArray2[index1].n1;
    ulong x0 = fieldElementArray1[index2].n0 ^ fieldElementArray2[index1].n0;
    for (int index3 = 12; index3 >= 0; index3 -= 2)
    {
      int index4 = (int) x[index3 + 1];
      int index5 = (int) x[index3];
      ulong num = x1 << 48 /*0x30*/;
      x1 = (ulong) ((long) fieldElementArray1[index5].n1 ^ (long) fieldElementArray2[index4].n1 ^ ((long) (x1 >> 16 /*0x10*/) | (long) x0 << 48 /*0x30*/));
      x0 = fieldElementArray1[index5].n0 ^ fieldElementArray2[index4].n0 ^ x0 >> 16 /*0x10*/ ^ num ^ num >> 1 ^ num >> 2 ^ num >> 7;
    }
    GcmUtilities.AsBytes(x0, x1, x);
  }
}
