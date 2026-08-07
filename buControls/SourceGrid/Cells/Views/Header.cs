// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.Header
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using System;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class Header : Cell
{
  public new static RectangleBorder DefaultBorder = RectangleBorder.NoBorder;
  public static readonly Header Default = new Header();

  public Header()
  {
    this.Background = (IHeader) new HeaderThemed();
    this.Border = (IBorder) Header.DefaultBorder;
  }

  public Header(Header p_Source)
    : base((Cell) p_Source)
  {
    this.Background = (IHeader) p_Source.Background.Clone();
  }

  public override object Clone() => (object) new Header(this);

  public IHeader Background
  {
    get => (IHeader) base.Background;
    set => this.Background = (IVisualElement) value;
  }

  protected override void PrepareView(CellContext context)
  {
    base.PrepareView(context);
    if (context.CellRange.Contains(context.Grid.MouseDownPosition))
      this.Background.Style = ControlDrawStyle.Pressed;
    else if (context.CellRange.Contains(context.Grid.MouseCellPosition))
      this.Background.Style = ControlDrawStyle.Hot;
    else
      this.Background.Style = ControlDrawStyle.Normal;
  }
}
