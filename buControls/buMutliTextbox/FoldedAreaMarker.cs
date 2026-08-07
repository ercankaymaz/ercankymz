// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.FoldedAreaMarker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class FoldedAreaMarker : VisualMarker
{
  public readonly int iLine;

  public FoldedAreaMarker(int iLine, Rectangle rectangle)
    : base(rectangle)
  {
    this.iLine = iLine;
  }

  public override void Draw(Graphics gr, Pen pen) => gr.DrawRectangle(pen, this.rectangle);
}
