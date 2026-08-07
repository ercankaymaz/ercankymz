// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.Gcm.Tables1kGcmExponentiator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes.Gcm;

[Obsolete("Will be removed")]
public class Tables1kGcmExponentiator : IGcmExponentiator
{
  private IList<GcmUtilities.FieldElement> lookupPowX2;

  public void Init(byte[] x)
  {
    GcmUtilities.FieldElement z;
    GcmUtilities.AsFieldElement(x, out z);
    if (this.lookupPowX2 != null && z.Equals((object) this.lookupPowX2[0]))
      return;
    this.lookupPowX2 = (IList<GcmUtilities.FieldElement>) new List<GcmUtilities.FieldElement>(8);
    this.lookupPowX2.Add(z);
  }

  public void ExponentiateX(long pow, byte[] output)
  {
    GcmUtilities.FieldElement x;
    GcmUtilities.One(out x);
    int num = 0;
    for (; pow > 0L; pow >>= 1)
    {
      if ((pow & 1L) != 0L)
      {
        this.EnsureAvailable(num);
        GcmUtilities.FieldElement y = this.lookupPowX2[num];
        GcmUtilities.Multiply(ref x, ref y);
      }
      ++num;
    }
    GcmUtilities.AsBytes(ref x, output);
  }

  private void EnsureAvailable(int bit)
  {
    int count = this.lookupPowX2.Count;
    if (count > bit)
      return;
    GcmUtilities.FieldElement x = this.lookupPowX2[count - 1];
    do
    {
      GcmUtilities.Square(ref x);
      this.lookupPowX2.Add(x);
    }
    while (++count <= bit);
  }
}
