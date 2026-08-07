// Decompiled with JetBrains decompiler
// Type: SourceGrid.Decorators.DecoratorBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Decorators;

public abstract class DecoratorBase
{
  public abstract bool IntersectWith(Range range);

  public abstract void Draw(RangePaintEventArgs e);
}
