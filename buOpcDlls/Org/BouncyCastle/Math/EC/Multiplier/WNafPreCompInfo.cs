// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.WNafPreCompInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public class WNafPreCompInfo : PreCompInfo
{
  internal volatile int m_promotionCountdown = 4;
  protected int m_confWidth = -1;
  protected ECPoint[] m_preComp;
  protected ECPoint[] m_preCompNeg;
  protected ECPoint m_twice;
  protected int m_width = -1;

  internal int DecrementPromotionCountdown()
  {
    int promotionCountdown = this.m_promotionCountdown;
    if (promotionCountdown > 0)
      this.m_promotionCountdown = --promotionCountdown;
    return promotionCountdown;
  }

  internal int PromotionCountdown
  {
    get => this.m_promotionCountdown;
    set => this.m_promotionCountdown = value;
  }

  public virtual bool IsPromoted => this.m_promotionCountdown <= 0;

  public virtual int ConfWidth
  {
    get => this.m_confWidth;
    set => this.m_confWidth = value;
  }

  public virtual ECPoint[] PreComp
  {
    get => this.m_preComp;
    set => this.m_preComp = value;
  }

  public virtual ECPoint[] PreCompNeg
  {
    get => this.m_preCompNeg;
    set => this.m_preCompNeg = value;
  }

  public virtual ECPoint Twice
  {
    get => this.m_twice;
    set => this.m_twice = value;
  }

  public virtual int Width
  {
    get => this.m_width;
    set => this.m_width = value;
  }
}
