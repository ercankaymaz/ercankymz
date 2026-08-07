// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ReadOnlyStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class ReadOnlyStyle : Style
{
  public ReadOnlyStyle() => this.IsExportable = false;

  public override void Draw(Graphics gr, Point position, Range range)
  {
  }
}
