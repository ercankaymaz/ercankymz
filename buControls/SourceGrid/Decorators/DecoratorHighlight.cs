// Decompiled with JetBrains decompiler
// Type: SourceGrid.Decorators.DecoratorHighlight
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Decorators;

public class DecoratorHighlight : DecoratorBase
{
  private Range range_0 = Range.Empty;

  public Range Range
  {
    get => this.range_0;
    set => this.range_0 = value;
  }

  public override bool IntersectWith(Range range) => this.Range.IntersectsWith(range);

  public override void Draw(RangePaintEventArgs e)
  {
  }
}
