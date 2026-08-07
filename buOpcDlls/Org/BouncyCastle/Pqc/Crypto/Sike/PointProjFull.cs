// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.PointProjFull
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal sealed class PointProjFull
{
  internal ulong[][] X;
  internal ulong[][] Y;
  internal ulong[][] Z;

  internal PointProjFull(uint nwords_field)
  {
    this.X = SikeUtilities.InitArray(2U, nwords_field);
    this.Y = SikeUtilities.InitArray(2U, nwords_field);
    this.Z = SikeUtilities.InitArray(2U, nwords_field);
  }
}
