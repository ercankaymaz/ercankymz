// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.ReasonsMask
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Pkix;

internal class ReasonsMask
{
  private int _reasons;
  internal static readonly ReasonsMask AllReasons = new ReasonsMask(33023);

  internal ReasonsMask(int reasons) => this._reasons = reasons;

  internal ReasonsMask()
    : this(0)
  {
  }

  internal void AddReasons(ReasonsMask mask) => this._reasons |= mask.Reasons.IntValue;

  internal bool IsAllReasons => this._reasons == ReasonsMask.AllReasons._reasons;

  internal ReasonsMask Intersect(ReasonsMask mask)
  {
    ReasonsMask reasonsMask = new ReasonsMask();
    reasonsMask.AddReasons(new ReasonsMask(this._reasons & mask.Reasons.IntValue));
    return reasonsMask;
  }

  internal bool HasNewReasons(ReasonsMask mask)
  {
    return (this._reasons | mask.Reasons.IntValue ^ this._reasons) != 0;
  }

  public ReasonFlags Reasons => new ReasonFlags(this._reasons);
}
