// Decompiled with JetBrains decompiler
// Type: ns0.Class1
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buMutliTextbox;
using System.Runtime.CompilerServices;

#nullable disable
namespace ns0;

internal sealed class Class1
{
  [CompilerGenerated]
  [SpecialName]
  public Place method_0() => this.place_0;

  [CompilerGenerated]
  [SpecialName]
  public void method_1(Place place_2) => this.place_0 = place_2;

  [CompilerGenerated]
  [SpecialName]
  public Place method_2() => this.place_1;

  [CompilerGenerated]
  [SpecialName]
  public void method_3(Place place_2) => this.place_1 = place_2;

  public Class1(Range range_0)
  {
    this.method_1(range_0.Start);
    this.method_3(range_0.End);
  }
}
