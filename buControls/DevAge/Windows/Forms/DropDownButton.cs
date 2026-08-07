// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.DropDownButton
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
[DefaultEvent("Click")]
public class DropDownButton : Control
{
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private DropDownButtonThemed dropDownButtonThemed_0 = new DropDownButtonThemed();
  private bool bool_0 = false;
  private bool bool_1 = false;

  public DropDownButton()
  {
    Class39.smethod_135(this);
    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    this.SetStyle(ControlStyles.UserMouse, true);
    this.SetStyle(ControlStyles.UserPaint, true);
    this.SetStyle(ControlStyles.DoubleBuffer, true);
    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    this.SetStyle(ControlStyles.ResizeRedraw, true);
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.StandardClick, true);
    this.SetStyle(ControlStyles.StandardDoubleClick, true);
    base.BackColor = Color.Transparent;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    if (this.Enabled)
    {
      if (this.bool_1)
        this.dropDownButtonThemed_0.Style = ButtonStyle.Pressed;
      else if (this.bool_0)
        this.dropDownButtonThemed_0.Style = ButtonStyle.Hot;
      else
        this.dropDownButtonThemed_0.Style = ButtonStyle.Normal;
    }
    else
      this.dropDownButtonThemed_0.Style = ButtonStyle.Disabled;
    using (GraphicsCache graphics = new GraphicsCache(e.Graphics, e.ClipRectangle))
      this.dropDownButtonThemed_0.Draw(graphics, (RectangleF) Rectangle.Round((RectangleF) this.ClientRectangle));
  }

  protected override void OnMouseEnter(EventArgs e)
  {
    base.OnMouseEnter(e);
    this.bool_0 = true;
    this.Invalidate();
  }

  protected override void OnMouseLeave(EventArgs e)
  {
    base.OnMouseLeave(e);
    this.bool_0 = false;
    this.Invalidate();
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    this.bool_1 = true;
    this.Invalidate();
    base.OnMouseDown(e);
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    base.OnMouseUp(e);
    this.bool_1 = false;
    this.Invalidate();
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (e.KeyCode == Keys.Space)
    {
      this.bool_1 = true;
      this.OnClick(EventArgs.Empty);
      e.Handled = true;
    }
    base.OnKeyDown(e);
  }

  protected override void OnKeyUp(KeyEventArgs e)
  {
    this.bool_1 = false;
    this.Invalidate();
    base.OnKeyUp(e);
  }

  protected override void OnClick(EventArgs e)
  {
    base.OnClick(e);
    this.Invalidate();
  }

  [Browsable(false)]
  public new Color BackColor
  {
    get => base.BackColor;
    set => base.BackColor = value;
  }
}
