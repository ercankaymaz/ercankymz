// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buContainerControl
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public abstract class buContainerControl : ContainerControl
{
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlGeometry buControlGeometry_0 = new buControlGeometry();
  private buControlTheme buControlTheme_0 = new buControlTheme();
  private Font font_0 = new Font("Microsoft Sans Serif", 10f);
  private Color color_0 = Color.Black;
  internal ContentAlignment contentAlignment_0 = ContentAlignment.MiddleCenter;
  private Image image_0;
  private int int_0 = -1;
  private int int_1 = 5;
  private string string_0 = string.Empty;
  private ImageList imageList_0;
  private ControlStyle controlStyle_0 = ControlStyle.None;
  internal ContentAlignment contentAlignment_1 = ContentAlignment.MiddleCenter;

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

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlTheme Theme
  {
    get => this.buControlTheme_0;
    set
    {
      this.buControlTheme_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(ContentAlignment.MiddleCenter)]
  [Localizable(true)]
  public virtual ContentAlignment TextAlign
  {
    get => this.contentAlignment_0;
    set
    {
      if (!Enum.IsDefined(typeof (ContentAlignment), (object) value))
        throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for ContentAlignment");
      if (this.contentAlignment_0 == value)
        return;
      this.contentAlignment_0 = value;
      this.Display.Fonts.Alignment = this.contentAlignment_0;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
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
      if (this.Parent != null)
        this.Parent.Invalidate();
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
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [Localizable(true)]
  public Image Image
  {
    get
    {
      return this.image_0 == null ? (this.int_0 < 0 || this.imageList_0 == null ? (string.IsNullOrEmpty(this.string_0) || this.imageList_0 == null ? (Image) null : this.imageList_0.Images[this.string_0]) : this.imageList_0.Images[this.int_0]) : this.image_0;
    }
    set
    {
      if (this.image_0 == value)
        return;
      this.image_0 = value;
      this.int_0 = -1;
      this.string_0 = string.Empty;
      this.imageList_0 = (ImageList) null;
      if ((!this.AutoSize ? 0 : (this.Parent != null ? 1 : 0)) != 0)
        this.Parent.PerformLayout((Control) this, nameof (Image));
      this.Invalidate();
    }
  }

  [DefaultValue(ContentAlignment.MiddleCenter)]
  [Localizable(true)]
  public ContentAlignment ImageAlign
  {
    get => this.contentAlignment_1;
    set
    {
      if (!Enum.IsDefined(typeof (ContentAlignment), (object) value))
        throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for ContentAlignment");
      if (this.contentAlignment_1 == value)
        return;
      this.contentAlignment_1 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DefaultValue(-1)]
  [Localizable(true)]
  [TypeConverter(typeof (ImageIndexConverter))]
  [RefreshProperties(RefreshProperties.Repaint)]
  public int ImageIndex
  {
    get
    {
      int imageIndex;
      if (this.ImageList == null)
        imageIndex = -1;
      else if (this.int_0 >= this.imageList_0.Images.Count)
      {
        imageIndex = this.imageList_0.Images.Count - 1;
      }
      else
      {
        if (this.Parent != null)
          this.Parent.Invalidate();
        imageIndex = this.int_0;
      }
      return imageIndex;
    }
    set
    {
      if (value < -1)
        throw new ArgumentException();
      if (this.int_0 == value)
        return;
      this.int_0 = value;
      this.image_0 = (Image) null;
      this.string_0 = string.Empty;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DefaultValue(5)]
  [Localizable(true)]
  public int ImageBorderOffset
  {
    get => this.int_1;
    set
    {
      if (this.int_1 == value)
        return;
      this.int_1 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [Localizable(true)]
  [DefaultValue("")]
  [RefreshProperties(RefreshProperties.Repaint)]
  [TypeConverter(typeof (ImageKeyConverter))]
  public string ImageKey
  {
    get => this.string_0;
    set
    {
      if (!(this.string_0 != value))
        return;
      this.image_0 = (Image) null;
      this.int_0 = -1;
      this.string_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DefaultValue(null)]
  [RefreshProperties(RefreshProperties.Repaint)]
  public ImageList ImageList
  {
    get => this.imageList_0;
    set
    {
      if (this.imageList_0 == value)
        return;
      this.imageList_0 = value;
      if ((this.imageList_0 == null ? 0 : (this.int_0 != -1 ? 1 : 0)) != 0)
        this.Image = (Image) null;
      if (this.Parent != null)
        this.Parent.Invalidate();
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

  protected Rectangle CalcImageRenderBounds(Image image, Rectangle r, ContentAlignment align)
  {
    Rectangle rectangle = r;
    rectangle.Inflate(-2, -2);
    int x = r.X;
    int y = r.Y;
    if ((align == ContentAlignment.TopCenter || align == ContentAlignment.MiddleCenter ? 1 : (align == ContentAlignment.BottomCenter ? 1 : 0)) != 0)
      x += (r.Width - image.Width) / 2;
    else if ((align == ContentAlignment.TopRight || align == ContentAlignment.MiddleRight ? 1 : (align == ContentAlignment.BottomRight ? 1 : 0)) != 0)
      x += r.Width - image.Width;
    if ((align == ContentAlignment.BottomCenter || align == ContentAlignment.BottomLeft ? 1 : (align == ContentAlignment.BottomRight ? 1 : 0)) != 0)
      y += r.Height - image.Height;
    else if ((align == ContentAlignment.MiddleCenter || align == ContentAlignment.MiddleLeft ? 1 : (align == ContentAlignment.MiddleRight ? 1 : 0)) != 0)
      y += (r.Height - image.Height) / 2;
    rectangle.X = x;
    rectangle.Y = y;
    rectangle.Width = image.Width;
    rectangle.Height = image.Height;
    return rectangle;
  }

  protected internal void DrawImage(Graphics g, Image image, Rectangle r, ContentAlignment align)
  {
    if ((image == null ? 1 : (g == null ? 1 : 0)) != 0)
      return;
    Rectangle rectangle = this.CalcImageRenderBounds(image, r, align);
    if (this.Enabled)
      g.DrawImage(image, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
    else
      ControlPaint.DrawImageDisabled(g, image, rectangle.X, rectangle.Y, this.BackColor);
  }
}
