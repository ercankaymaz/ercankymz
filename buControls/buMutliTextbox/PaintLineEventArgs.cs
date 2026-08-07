// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.PaintLineEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class PaintLineEventArgs : PaintEventArgs
{
  public PaintLineEventArgs(int iLine, Rectangle rect, Graphics gr, Rectangle clipRect)
    : base(gr, clipRect)
  {
    this.LineIndex = iLine;
    this.LineRect = rect;
  }

  public int LineIndex { get; private set; }

  public Rectangle LineRect { get; private set; }
}
