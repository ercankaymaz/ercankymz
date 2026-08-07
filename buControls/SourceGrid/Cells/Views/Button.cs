// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.Button
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using System;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class Button : Cell
{
  public static readonly Button Default = new Button();

  public Button() => this.Background = (IButton) new ButtonThemed();

  public Button(Button p_Source)
    : base((Cell) p_Source)
  {
    this.Background = (IButton) p_Source.Background.Clone();
  }

  public override object Clone() => (object) new Button(this);

  public IButton Background
  {
    get => (IButton) base.Background;
    set => this.Background = (IVisualElement) value;
  }

  protected override void PrepareView(CellContext context)
  {
    base.PrepareView(context);
    if (context.CellRange.Contains(context.Grid.MouseDownPosition))
      this.Background.Style = ButtonStyle.Pressed;
    else if (context.CellRange.Contains(context.Grid.MouseCellPosition))
      this.Background.Style = ButtonStyle.Hot;
    else if (context.CellRange.Contains(context.Grid.Selection.ActivePosition))
      this.Background.Style = ButtonStyle.Focus;
    else
      this.Background.Style = ButtonStyle.Normal;
  }
}
