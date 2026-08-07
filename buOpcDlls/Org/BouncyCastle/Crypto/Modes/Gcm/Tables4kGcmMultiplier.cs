// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.Gcm.Tables4kGcmMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes.Gcm;

[Obsolete("Will be removed")]
public class Tables4kGcmMultiplier : IGcmMultiplier
{
  private byte[] H;
  private GcmUtilities.FieldElement[] T;

  public void Init(byte[] H)
  {
    if (this.T == null)
      this.T = new GcmUtilities.FieldElement[256 /*0x0100*/];
    else if (Arrays.AreEqual(this.H, H))
      return;
    this.H = Arrays.Clone(H);
    GcmUtilities.AsFieldElement(this.H, out this.T[1]);
    GcmUtilities.MultiplyP7(ref this.T[1]);
    for (int index = 1; index < 128 /*0x80*/; ++index)
    {
      GcmUtilities.DivideP(ref this.T[index], out this.T[index << 1]);
      GcmUtilities.Xor(ref this.T[index << 1], ref this.T[1], out this.T[(index << 1) + 1]);
    }
  }

  public void MultiplyH(byte[] x)
  {
    int index1 = (int) x[15];
    ulong x0 = this.T[index1].n0;
    ulong x1 = this.T[index1].n1;
    for (int index2 = 14; index2 >= 0; --index2)
    {
      int index3 = (int) x[index2];
      ulong num = x1 << 56;
      x1 = this.T[index3].n1 ^ (x1 >> 8 | x0 << 56);
      x0 = this.T[index3].n0 ^ x0 >> 8 ^ num ^ num >> 1 ^ num >> 2 ^ num >> 7;
    }
    GcmUtilities.AsBytes(x0, x1, x);
  }
}
