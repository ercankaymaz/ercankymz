// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.RichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Windows.Forms;
using ns7;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Models;

public class RichTextBox : IModel, IRichTextBox
{
  public void InsertString(CellContext cellContext, string s)
  {
    Class39.smethod_739(this, cellContext).SelectedText = s;
  }

  public void SetSelectionEffect(CellContext cellContext, EffectType effect)
  {
    ValueChangeEventArgs e = new ValueChangeEventArgs((object) null, (object) effect);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }

  public void SetSelectionFont(CellContext cellContext, Font font)
  {
    ValueChangeEventArgs e = new ValueChangeEventArgs((object) null, (object) font);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }

  public Font GetSelectionFont(CellContext cellContext)
  {
    return Class39.smethod_739(this, cellContext).SelectionFont;
  }

  public void SetSelectionColor(CellContext cellContext, Color color)
  {
    ValueChangeEventArgs e = new ValueChangeEventArgs((object) null, (object) color);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }

  public Color GetSelectionColor(CellContext cellContext)
  {
    return Class39.smethod_739(this, cellContext).SelectionColor;
  }

  public int GetSelectionCharOffset(CellContext cellContext)
  {
    return Class39.smethod_739(this, cellContext).SelectionCharOffset;
  }

  public void SetSelectionCharOffset(CellContext cellContext, int charoffset)
  {
    ValueChangeEventArgs e = new ValueChangeEventArgs((object) null, (object) charoffset);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }

  public void SetSelectionAlignment(CellContext cellContext, HorizontalAlignment horAlignment)
  {
    ValueChangeEventArgs e = new ValueChangeEventArgs((object) null, (object) horAlignment);
    if (cellContext.Grid != null)
      cellContext.Grid.Controller.OnValueChanging(cellContext, e);
    if (cellContext.Grid == null)
      return;
    cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
  }

  public HorizontalAlignment GetSelectionAlignment(CellContext cellContext)
  {
    return Class39.smethod_739(this, cellContext).SelectionAlignment;
  }
}
