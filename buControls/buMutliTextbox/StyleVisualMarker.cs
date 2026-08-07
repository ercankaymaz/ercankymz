// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.StyleVisualMarker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class StyleVisualMarker : VisualMarker
{
  public Style Style { get; private set; }

  public StyleVisualMarker(Rectangle rectangle, Style style)
    : base(rectangle)
  {
    this.Style = style;
  }
}
