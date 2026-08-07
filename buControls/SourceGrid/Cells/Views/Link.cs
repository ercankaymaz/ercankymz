// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.Link
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class Link : Cell
{
  public static readonly Link Default = new Link();

  public Link()
  {
    this.Font = new Font(Control.DefaultFont, FontStyle.Underline);
    this.ForeColor = Color.Blue;
  }

  public Link(Link p_Source)
    : base((Cell) p_Source)
  {
  }

  public override object Clone() => (object) new Link(this);
}
