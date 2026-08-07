// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.Gcm.BasicGcmMultiplier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes.Gcm;

[Obsolete("Will be removed")]
public class BasicGcmMultiplier : IGcmMultiplier
{
  private GcmUtilities.FieldElement H;

  internal static bool IsHardwareAccelerated => false;

  public void Init(byte[] H) => GcmUtilities.AsFieldElement(H, out this.H);

  public void MultiplyH(byte[] x)
  {
    GcmUtilities.FieldElement z;
    GcmUtilities.AsFieldElement(x, out z);
    GcmUtilities.Multiply(ref z, ref this.H);
    GcmUtilities.AsBytes(ref z, x);
  }
}
