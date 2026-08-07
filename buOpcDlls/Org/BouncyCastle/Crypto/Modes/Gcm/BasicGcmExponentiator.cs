// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.Gcm.BasicGcmExponentiator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes.Gcm;

[Obsolete("Will be removed")]
public class BasicGcmExponentiator : IGcmExponentiator
{
  private GcmUtilities.FieldElement x;

  public void Init(byte[] x) => GcmUtilities.AsFieldElement(x, out this.x);

  public void ExponentiateX(long pow, byte[] output)
  {
    GcmUtilities.FieldElement x1;
    GcmUtilities.One(out x1);
    if (pow > 0L)
    {
      GcmUtilities.FieldElement x2 = this.x;
      do
      {
        if ((pow & 1L) != 0L)
          goto label_3;
label_2:
        GcmUtilities.Square(ref x2);
        pow >>= 1;
        continue;
label_3:
        GcmUtilities.Multiply(ref x1, ref x2);
        goto label_2;
      }
      while (pow > 0L);
    }
    GcmUtilities.AsBytes(ref x1, output);
  }
}
