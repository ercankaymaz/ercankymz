// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.RichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class RichTextBox : ControllerBase
{
  public static readonly RichTextBox Default = new RichTextBox();

  public override void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
  {
    base.OnValueChanging(sender, e);
    if (e.NewValue is RichText)
      return;
    DevAgeRichTextBox control = ((SourceGrid.Cells.Editors.RichTextBox) sender.Cell.Editor).Control;
    if (sender.Cell.Editor.EditCell == null)
    {
      control.Value = sender.Value as RichText;
      control.SelectAll();
    }
    if (e.NewValue is Font)
      control.SelectionFont = (Font) e.NewValue;
    else if (e.NewValue is Color)
      control.SelectionColor = (Color) e.NewValue;
    else if (e.NewValue is int)
      control.SelectionCharOffset = (int) e.NewValue;
    else if (e.NewValue is HorizontalAlignment)
      control.SelectionAlignment = (HorizontalAlignment) e.NewValue;
    else if (e.NewValue is EffectType)
      control.SelectionEffect = (EffectType) e.NewValue;
    if (sender.Cell.Editor.EditCell != null)
      return;
    sender.Value = (object) control.Value;
  }
}
