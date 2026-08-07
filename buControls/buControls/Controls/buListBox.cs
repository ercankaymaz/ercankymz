// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buListBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[DefaultProperty("Items")]
[DefaultEvent("SelectedIndexChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class buListBox : ListBox
{
  private Font font_0 = new Font("Microsoft Sans Serif", 10f);
  private Color color_0 = Color.Black;
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlGeometry buControlGeometry_0 = new buControlGeometry();
  private buControlTheme buControlTheme_0 = new buControlTheme();
  private Image image_0;
  private ThemeType themeType_0 = ThemeType.Standart;
  private string string_0;
  private ControlStyle controlStyle_0 = ControlStyle.None;

  public buListBox()
  {
    Class39.smethod_439();
    this.Display.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.DrawMode = DrawMode.OwnerDrawVariable;
    this.ItemHeight = 25;
    this.BorderStyle = BorderStyle.None;
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string AuxInfo
  {
    get => this.string_0;
    set
    {
      this.string_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Font), "Microsoft Sans Serif")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public override Font Font
  {
    get => this.font_0;
    set
    {
      this.font_0 = base.Font = value;
      this.Display.Fonts.Font = this.font_0;
      this.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Black")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public override Color ForeColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.Display.Fonts.ForeColor = this.color_0;
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlTheme Theme
  {
    get => this.buControlTheme_0;
    set
    {
      this.buControlTheme_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay Display
  {
    get => this.buControlDisplay_0;
    set
    {
      this.buControlDisplay_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlGeometry Geometry
  {
    get => this.buControlGeometry_0;
    set
    {
      this.buControlGeometry_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(null)]
  public Image ItemImage
  {
    get => this.image_0;
    set
    {
      this.image_0 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(ControlStyle.None)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public ControlStyle ControlStyle
  {
    get => this.controlStyle_0;
    set
    {
      this.controlStyle_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public static buListBox CopyVisual(buListBox refList, buListBox copyList)
  {
    copyList.Display = buControlDisplay.Copy(refList.Display, copyList.Display);
    copyList.Geometry.Space = refList.Geometry.Space;
    copyList.Geometry.ArcDiameter = refList.Geometry.ArcDiameter;
    copyList.Geometry.ShapeMode = refList.Geometry.ShapeMode;
    return copyList;
  }

  protected override void OnDrawItem(DrawItemEventArgs e)
  {
    try
    {
      if (this.Items.Count > 0)
      {
        e.DrawBackground();
        if (Convert.ToInt32((object) (e.State & DrawItemState.Selected)) == 1)
        {
          e.Graphics.FillRectangle((Brush) new SolidBrush(this.Display.SelectionColor), e.Bounds);
        }
        else
        {
          e.Graphics.FillRectangle((Brush) new SolidBrush(this.Display.BackColor), e.Bounds);
          if (this.Display.Border.Visible)
          {
            Rectangle bounds1;
            if (e.Index == 0)
            {
              Graphics graphics = e.Graphics;
              Pen pen = new Pen(this.Display.Border.Color, this.Display.Border.Thickness);
              int x = e.Bounds.X;
              Rectangle bounds2 = e.Bounds;
              int y1 = bounds2.Y;
              Point pt1 = new Point(x, y1);
              bounds2 = e.Bounds;
              int width = bounds2.Width;
              bounds1 = e.Bounds;
              int y2 = bounds1.Y;
              Point pt2 = new Point(width, y2);
              graphics.DrawLine(pen, pt1, pt2);
            }
            Graphics graphics1 = e.Graphics;
            Pen pen1 = new Pen(this.Display.Border.Color, this.Display.Border.Thickness);
            bounds1 = e.Bounds;
            int x1 = bounds1.X;
            bounds1 = e.Bounds;
            int y3 = bounds1.Y;
            Point pt1_1 = new Point(x1, y3);
            bounds1 = e.Bounds;
            int x2 = bounds1.X;
            bounds1 = e.Bounds;
            int y4 = bounds1.Y + this.ItemHeight;
            Point pt2_1 = new Point(x2, y4);
            graphics1.DrawLine(pen1, pt1_1, pt2_1);
            Graphics graphics2 = e.Graphics;
            Pen pen2 = new Pen(this.Display.Border.Color, this.Display.Border.Thickness);
            bounds1 = e.Bounds;
            int x3 = bounds1.Width - 1;
            bounds1 = e.Bounds;
            int y5 = bounds1.Y;
            Point pt1_2 = new Point(x3, y5);
            bounds1 = e.Bounds;
            int x4 = bounds1.Width - 1;
            bounds1 = e.Bounds;
            int y6 = bounds1.Y + this.ItemHeight;
            Point pt2_2 = new Point(x4, y6);
            graphics2.DrawLine(pen2, pt1_2, pt2_2);
          }
        }
        using (new SolidBrush(this.Display.Fonts.ForeColor))
        {
          if (this.Items.Count == 0)
            return;
          e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), this.Display.Fonts.Font, (Brush) new SolidBrush(this.Display.Fonts.ForeColor), (RectangleF) e.Bounds);
        }
      }
      base.OnDrawItem(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    try
    {
      string text = this.Text;
      RectangleF rectangleF1;
      ref RectangleF local1 = ref rectangleF1;
      Rectangle clientRectangle1 = this.ClientRectangle;
      double left1 = (double) clientRectangle1.Left;
      clientRectangle1 = this.ClientRectangle;
      double top1 = (double) clientRectangle1.Top;
      clientRectangle1 = this.ClientRectangle;
      double width1 = (double) clientRectangle1.Width;
      clientRectangle1 = this.ClientRectangle;
      double height1 = (double) clientRectangle1.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
      RectangleF rectangleF2;
      ref RectangleF local2 = ref rectangleF2;
      Rectangle clientRectangle2 = this.ClientRectangle;
      double left2 = (double) clientRectangle2.Left;
      clientRectangle2 = this.ClientRectangle;
      double top2 = (double) clientRectangle2.Top;
      clientRectangle2 = this.ClientRectangle;
      double width2 = (double) clientRectangle2.Width;
      clientRectangle2 = this.ClientRectangle;
      double height2 = (double) clientRectangle2.Height;
      local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
      Graphics graphics = e.Graphics;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.Display.Parent = (Control) this;
      }
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      if (this.Width > 0 & this.Height > 0 && this.Items.Count > 0)
      {
        for (int index = 0; index <= this.Items.Count - 1; ++index)
        {
          Rectangle itemRectangle = this.GetItemRectangle(index);
          if (e.ClipRectangle.IntersectsWith(itemRectangle))
          {
            if ((this.SelectionMode == SelectionMode.One && this.SelectedIndex == index || this.SelectionMode == SelectionMode.MultiSimple && this.SelectedIndices.Contains(index) ? 1 : (this.SelectionMode != SelectionMode.MultiExtended ? 0 : (this.SelectedIndices.Contains(index) ? 1 : 0))) != 0)
              this.OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Display.Fonts.Font, itemRectangle, index, DrawItemState.Selected, this.Display.Fonts.ForeColor, this.Display.BackColor));
            else
              this.OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Display.Fonts.Font, itemRectangle, index, DrawItemState.Default, this.Display.Fonts.ForeColor, this.Display.BackColor));
          }
        }
      }
      this.themeType_0 = this.Theme.Type;
      base.OnPaint(e);
    }
    catch (Exception ex)
    {
    }
  }
}
