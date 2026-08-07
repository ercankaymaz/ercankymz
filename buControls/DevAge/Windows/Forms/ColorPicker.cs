// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.ColorPicker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class ColorPicker : EditableControlBase
{
  internal Button button_0;
  internal Panel panel_0;
  internal Label label_0;
  private System.ComponentModel.Container container_2 = (System.ComponentModel.Container) null;

  public ColorPicker()
  {
    Class39.smethod_780(this);
    this.SelectedColor = Color.Black;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_2 != null)
      this.container_2.Dispose();
    base.Dispose(disposing);
  }

  public virtual Color SelectedColor
  {
    get => this.panel_0.BackColor;
    set => this.panel_0.BackColor = value;
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.label_0.Text = this.panel_0.BackColor.Name;
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, e);
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      using (ColorDialog colorDialog = new ColorDialog())
      {
        colorDialog.Color = this.SelectedColor;
        if (colorDialog.ShowDialog((IWin32Window) this) != DialogResult.OK)
          return;
        this.SelectedColor = colorDialog.Color;
      }
    }
    catch (Exception ex)
    {
    }
  }

  public new Color ForeColor
  {
    get => this.label_0.ForeColor;
    set => this.label_0.ForeColor = value;
  }

  public event EventHandler SelectedColorChanged;
}
