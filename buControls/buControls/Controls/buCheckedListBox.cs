// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buCheckedListBox
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
public class buCheckedListBox : CheckedListBox
{
  private Font font_0 = new Font("Microsoft Sans Serif", 10f);
  private Color color_0 = Color.Black;
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlGeometry buControlGeometry_0 = new buControlGeometry();
  private Image image_0;
  private buControlTheme buControlTheme_0 = new buControlTheme();
  private PictureBox pictureBox_0 = new PictureBox();
  private PictureBox pictureBox_1 = new PictureBox();
  private PictureBox pictureBox_2 = new PictureBox();
  private PictureBox pictureBox_3 = new PictureBox();
  private ThemeType themeType_0 = ThemeType.Standart;

  public buCheckedListBox()
  {
    this.Controls.Add((Control) this.pictureBox_0);
    this.Controls.Add((Control) this.pictureBox_1);
    this.Controls.Add((Control) this.pictureBox_2);
    this.Controls.Add((Control) this.pictureBox_3);
    Class39.smethod_162();
    this.Display.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.BorderStyle = BorderStyle.None;
    this.DrawMode = DrawMode.OwnerDrawVariable;
    this.ItemHeight = 25;
    this.DoubleBuffered = true;
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
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
          e = new DrawItemEventArgs(e.Graphics, this.Display.Fonts.Font, e.Bounds, e.Index, DrawItemState.NoFocusRect, this.Display.Fonts.ForeColor, this.Display.SelectionColor);
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
          e = new DrawItemEventArgs(e.Graphics, this.Display.Fonts.Font, e.Bounds, e.Index, DrawItemState.NoFocusRect, this.Display.Fonts.ForeColor, this.Display.BackColor);
        }
        e.DrawFocusRectangle();
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
      this.pictureBox_0.Visible = this.Display.Border.Visible;
      this.pictureBox_1.Visible = this.Display.Border.Visible;
      this.pictureBox_2.Visible = this.Display.Border.Visible;
      this.pictureBox_3.Visible = this.Display.Border.Visible;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.Display.Parent = (Control) this;
      }
      if (this.Display.Border.Visible)
      {
        this.pictureBox_0.Left = 0;
        this.pictureBox_0.Top = 0;
        this.pictureBox_0.Width = this.Width;
        this.pictureBox_0.Height = (int) this.Display.Border.Thickness;
        this.pictureBox_0.BackColor = this.Display.Border.Color;
        this.pictureBox_1.Left = 0;
        this.pictureBox_1.Top = this.Height - (int) this.Display.Border.Thickness;
        this.pictureBox_1.Width = this.Width;
        this.pictureBox_1.Height = (int) this.Display.Border.Thickness;
        this.pictureBox_1.BackColor = this.Display.Border.Color;
        this.pictureBox_2.Left = 0;
        this.pictureBox_2.Top = 0;
        this.pictureBox_2.Width = (int) this.Display.Border.Thickness;
        this.pictureBox_2.Height = this.Height;
        this.pictureBox_2.BackColor = this.Display.Border.Color;
        this.pictureBox_3.Left = this.Width - (int) this.Display.Border.Thickness;
        this.pictureBox_3.Top = 0;
        this.pictureBox_3.Width = (int) this.Display.Border.Thickness;
        this.pictureBox_3.Height = this.Height;
        this.pictureBox_3.BackColor = this.Display.Border.Color;
      }
      string text = this.Text;
      RectangleF rectangleF1;
      ref RectangleF local1 = ref rectangleF1;
      Rectangle rectangle = this.ClientRectangle;
      double left1 = (double) rectangle.Left;
      rectangle = this.ClientRectangle;
      double top1 = (double) rectangle.Top;
      rectangle = this.ClientRectangle;
      double width1 = (double) rectangle.Width;
      rectangle = this.ClientRectangle;
      double height1 = (double) rectangle.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
      RectangleF rectangleF2;
      ref RectangleF local2 = ref rectangleF2;
      rectangle = this.ClientRectangle;
      double left2 = (double) rectangle.Left;
      rectangle = this.ClientRectangle;
      double top2 = (double) rectangle.Top;
      rectangle = this.ClientRectangle;
      double width2 = (double) rectangle.Width;
      rectangle = this.ClientRectangle;
      double height2 = (double) rectangle.Height;
      local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
      Graphics graphics = e.Graphics;
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      if (this.Items.Count > 0)
      {
        for (int index = 0; index <= this.Items.Count - 1; ++index)
        {
          Rectangle itemRectangle = this.GetItemRectangle(index);
          rectangle = e.ClipRectangle;
          if (rectangle.IntersectsWith(itemRectangle))
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
