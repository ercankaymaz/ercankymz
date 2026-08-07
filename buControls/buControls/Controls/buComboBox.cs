// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buComboBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[DefaultProperty("Items")]
[DefaultEvent("SelectedIndexChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class buComboBox : ComboBox
{
  private Font font_0 = new Font("Microsoft Sans Serif", 10f);
  private Color color_0 = Color.Black;
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlGeometry buControlGeometry_0 = new buControlGeometry();
  private buControlLanguage buControlLanguage_0 = new buControlLanguage();
  private buControlCaption buControlCaption_0 = new buControlCaption();
  private buControlSecurity buControlSecurity_0 = new buControlSecurity();
  private buControlCombo buControlCombo_0 = new buControlCombo();
  private buControlTheme buControlTheme_0 = new buControlTheme();
  private Image image_0;
  private string string_0;
  private ControlStyle controlStyle_0 = ControlStyle.None;
  private rectDraw rectDraw_0 = new rectDraw();
  private RectangleF rectangleF_0 = new RectangleF();
  private ThemeType themeType_0 = ThemeType.Standart;
  private HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;

  public buComboBox()
  {
    Class39.smethod_317();
    this.Display.Parent = (Control) this;
    this.Caption.Parent = (Control) this;
    this.Caption.Display.Parent = (Control) this;
    this.Combo.Parent = (Control) this;
    this.Theme.Parent = (Control) this;
    this.DrawMode = DrawMode.OwnerDrawFixed;
    this.DropDownStyle = ComboBoxStyle.DropDownList;
    this.ItemHeight = 25;
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlCombo Combo
  {
    get => this.buControlCombo_0;
    set
    {
      this.buControlCombo_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
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
  public buControlCaption Caption
  {
    get => this.buControlCaption_0;
    set
    {
      this.buControlCaption_0 = value;
      this.Invalidate();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlLanguage Language
  {
    get => this.buControlLanguage_0;
    set
    {
      this.buControlLanguage_0 = value;
      this.Invalidate();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlSecurity Security
  {
    get => this.buControlSecurity_0;
    set
    {
      this.buControlSecurity_0 = value;
      this.Invalidate();
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

  protected override void OnLostFocus(EventArgs e)
  {
    base.OnLostFocus(e);
    this.SuspendLayout();
    this.Update();
    this.ResumeLayout();
  }

  protected override void OnPaintBackground(PaintEventArgs e) => base.OnPaintBackground(e);

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
          e.Graphics.FillRectangle((Brush) new SolidBrush(this.Combo.DropBoxColor), e.Bounds);
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
      string caption = this.Caption.Caption;
      RectangleF rectangleF;
      ref RectangleF local1 = ref rectangleF;
      Rectangle clientRectangle1 = this.ClientRectangle;
      double left1 = (double) clientRectangle1.Left;
      clientRectangle1 = this.ClientRectangle;
      double top1 = (double) clientRectangle1.Top;
      clientRectangle1 = this.ClientRectangle;
      double width1 = (double) clientRectangle1.Width;
      clientRectangle1 = this.ClientRectangle;
      double height1 = (double) clientRectangle1.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
      RectangleF rect;
      ref RectangleF local2 = ref rect;
      Rectangle clientRectangle2 = this.ClientRectangle;
      double left2 = (double) clientRectangle2.Left;
      clientRectangle2 = this.ClientRectangle;
      double top2 = (double) clientRectangle2.Top;
      clientRectangle2 = this.ClientRectangle;
      double width2 = (double) clientRectangle2.Width;
      clientRectangle2 = this.ClientRectangle;
      double height2 = (double) clientRectangle2.Height;
      local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
      RectangleF Rectangle;
      ref RectangleF local3 = ref Rectangle;
      Rectangle clientRectangle3 = this.ClientRectangle;
      double left3 = (double) clientRectangle3.Left;
      clientRectangle3 = this.ClientRectangle;
      double top3 = (double) clientRectangle3.Top;
      clientRectangle3 = this.ClientRectangle;
      double width3 = (double) (clientRectangle3.Width - 1);
      clientRectangle3 = this.ClientRectangle;
      double height3 = (double) (clientRectangle3.Height - 1);
      local3 = new RectangleF((float) left3, (float) top3, (float) width3, (float) height3);
      double width4 = (double) this.Caption.Width;
      double height4 = (double) this.Height;
      Graphics graphics = e.Graphics;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.Caption.Display = new buControlDisplay(Vars.Caption.Display);
        this.Combo = new buControlCombo(Vars.Combo);
        this.Display.Parent = (Control) this;
        this.Combo.Parent = (Control) this;
        this.Caption.Parent = (Control) this;
        this.Caption.Display.Parent = (Control) this;
      }
      string Text = ControlGeometry.LanguageSelect(this.Language, caption);
      ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, ref this.rectDraw_0, ref this.rectangleF_0);
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      GraphicsPath path = this.Geometry.ShapeMode != ShapeType.Arc ? ControlGeometry.Rectangle(Rectangle) : ControlGeometry.RoundRect(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height, this.Geometry.ArcDiameter);
      graphics.SetClip(path);
      graphics.FillPath((Brush) new SolidBrush(this.Combo.ValueColor), path);
      graphics.ResetClip();
      graphics.DrawPath(new Pen(this.Display.Border.Color, this.Display.Border.Thickness), path);
      if (this.Caption.OnTop)
      {
        --this.rectDraw_0.rect.X;
        --this.rectDraw_0.rect.Y;
        ++this.rectDraw_0.rect.Width;
        ++this.rectDraw_0.rect.Height;
        ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.Geometry, this.Caption.Display, this.rectDraw_0.RoundType, ref graphics);
        ControlGeometry.drawString(this.rectDraw_0.rectText, Text, this.Caption.Display, this.hotkeyPrefix_0, ref graphics);
      }
      else
      {
        --this.rectDraw_0.rect.X;
        --this.rectDraw_0.rect.Y;
        this.rectDraw_0.rect.Width += 2f;
        this.rectDraw_0.rect.Height += 2f;
        ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.Geometry, this.Caption.Display, this.rectDraw_0.RoundType, ref graphics);
        ControlGeometry.drawString(this.rectDraw_0.rectText, Text, this.Caption.Display, this.hotkeyPrefix_0, ref graphics);
      }
      if (this.Caption.Visible)
      {
        if (!this.Caption.OnTop)
        {
          rect.X = (float) ((double) this.rectDraw_0.rect.X + (double) this.rectDraw_0.rect.Width + 1.0);
          rect.Width = (float) ((double) Rectangle.Width - 1.0 - ((double) this.rectDraw_0.rect.X + (double) this.rectDraw_0.rect.Width + (double) this.Combo.ArrowButtonWidth + 1.0));
        }
        else
        {
          rect.X = Rectangle.X + 1f;
          rect.Width = Rectangle.Width - 2f;
        }
      }
      ControlGeometry.drawString(rect, this.Text, this.Display, this.hotkeyPrefix_0, ref graphics);
      int x = this.Width - Convert.ToInt32((float) this.Combo.ArrowButtonWidth / 2f);
      graphics.DrawLine(new Pen(this.Combo.ArrowColor, 2f), new PointF((float) (x - 4), 10f), new PointF((float) x, 14f));
      graphics.DrawLine(new Pen(this.Combo.ArrowColor, 2f), new PointF((float) x, 14f), new PointF((float) (x + 4), 10f));
      graphics.DrawLine(new Pen(this.Combo.ArrowLineColor), new PointF((float) (this.Width - this.Combo.ArrowButtonWidth), 0.0f), new PointF((float) (this.Width - this.Combo.ArrowButtonWidth), (float) (this.Height - 1)));
      this.themeType_0 = this.Theme.Type;
      base.OnPaint(e);
    }
    catch (Exception ex)
    {
    }
  }

  public static buComboBox CopyVisual(buComboBox refCombo, buComboBox copyCombo)
  {
    copyCombo.Display = buControlDisplay.Copy(refCombo.Display, copyCombo.Display);
    copyCombo.Caption.Display = buControlDisplay.Copy(refCombo.Caption.Display, copyCombo.Caption.Display);
    copyCombo.Combo.DropBoxColor = refCombo.Combo.DropBoxColor;
    copyCombo.Combo.ArrowColor = refCombo.Combo.ArrowColor;
    copyCombo.Combo.ArrowLineColor = refCombo.Combo.ArrowLineColor;
    copyCombo.Combo.ValueColor = refCombo.Combo.ValueColor;
    copyCombo.Combo.ArrowButtonWidth = refCombo.Combo.ArrowButtonWidth;
    copyCombo.Geometry.Space = refCombo.Geometry.Space;
    copyCombo.Geometry.ArcDiameter = refCombo.Geometry.ArcDiameter;
    copyCombo.Geometry.ShapeMode = refCombo.Geometry.ShapeMode;
    return copyCombo;
  }
}
