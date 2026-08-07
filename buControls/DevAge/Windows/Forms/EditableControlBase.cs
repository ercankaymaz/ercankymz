// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.EditableControlBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class EditableControlBase : UserControl
{
  internal System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private DevAge.Drawing.VisualElements.Container container_1 = new DevAge.Drawing.VisualElements.Container();
  private EditablePanelThemed editablePanelThemed_0 = new EditablePanelThemed();
  private BackgroundSolid backgroundSolid_0 = new BackgroundSolid();
  private static Color color_0 = Color.FromKnownColor(KnownColor.Window);

  public EditableControlBase()
  {
    this.container_0 = new System.ComponentModel.Container();
    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    this.SetStyle(ControlStyles.UserMouse, true);
    this.SetStyle(ControlStyles.UserPaint, true);
    this.SetStyle(ControlStyles.DoubleBuffer, false);
    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    this.SetStyle(ControlStyles.ResizeRedraw, true);
    this.BackColor = EditableControlBase.color_0;
    this.container_1.Background = (IVisualElement) this.backgroundSolid_0;
    this.container_1.Border = (IBorder) this.editablePanelThemed_0;
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
    using (GraphicsCache graphics = new GraphicsCache(e.Graphics, e.ClipRectangle))
      this.editablePanelThemed_0.Draw(graphics, (RectangleF) this.ClientRectangle);
  }

  [DefaultValue(typeof (Color), "Window")]
  public new Color BackColor
  {
    get => base.BackColor;
    set
    {
      this.backgroundSolid_0.BackColor = value;
      base.BackColor = value;
    }
  }

  [DefaultValue(DevAge.Drawing.BorderStyle.System)]
  public DevAge.Drawing.BorderStyle BorderStyle
  {
    get => this.editablePanelThemed_0.BorderStyle;
    set
    {
      this.editablePanelThemed_0.BorderStyle = value;
      this.OnBorderStyleChanged(EventArgs.Empty);
    }
  }

  protected virtual void OnBorderStyleChanged(EventArgs e) => this.Invalidate();

  public override Rectangle DisplayRectangle
  {
    get
    {
      using (MeasureHelper measure = new MeasureHelper((Control) this))
        return Rectangle.Round(this.container_1.GetContentRectangle(measure, (RectangleF) base.DisplayRectangle));
    }
  }

  protected void SetContentAndButtonLocation(Control content, Control rightButton)
  {
    Rectangle displayRectangle = this.DisplayRectangle;
    rightButton.Bounds = new Rectangle(displayRectangle.Right - 18, displayRectangle.Y, 18, displayRectangle.Height);
    int width = rightButton.Location.X - this.DisplayRectangle.X;
    content.Bounds = new Rectangle(displayRectangle.Location, new Size(width, displayRectangle.Height));
  }
}
