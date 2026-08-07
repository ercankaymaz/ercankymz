// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Multiplier.FixedPointPreCompInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC.Multiplier;

public class FixedPointPreCompInfo : PreCompInfo
{
  protected ECPoint m_offset;
  protected ECLookupTable m_lookupTable;
  protected int m_width = -1;

  public virtual ECLookupTable LookupTable
  {
    get => this.m_lookupTable;
    set => this.m_lookupTable = value;
  }

  public virtual ECPoint Offset
  {
    get => this.m_offset;
    set => this.m_offset = value;
  }

  public virtual int Width
  {
    get => this.m_width;
    set => this.m_width = value;
  }
}
