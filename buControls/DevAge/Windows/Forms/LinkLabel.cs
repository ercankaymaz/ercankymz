// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.LinkLabel
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
[DefaultEvent("Click")]
public class LinkLabel : UserControl
{
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private System.Drawing.Image image_0;
  private System.Drawing.Image image_1;
  private System.Drawing.Image image_2;
  private DevAge.Drawing.ContentAlignment contentAlignment_0 = DevAge.Drawing.ContentAlignment.MiddleLeft;
  private StringFormat stringFormat_0 = new StringFormat(StringFormat.GenericDefault);
  private bool bool_0 = true;
  private bool bool_1 = false;
  private bool bool_2 = false;
  private int int_0 = 0;
  private double double_0 = 0.0;
  private Color color_0 = Color.Black;
  private Color color_1 = Color.FromKnownColor(KnownColor.Control);
  private bool bool_3 = false;

  public LinkLabel()
  {
    Class39.smethod_290(this);
    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    this.SetStyle(ControlStyles.StandardClick, true);
    this.SetStyle(ControlStyles.StandardDoubleClick, true);
    this.SetStyle(ControlStyles.ResizeRedraw, true);
    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    this.SetStyle(ControlStyles.UserPaint, true);
    base.BackColor = Color.Transparent;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  [DefaultValue(null)]
  public System.Drawing.Image Image
  {
    get => this.image_0;
    set
    {
      this.image_0 = value;
      this.Invalidate(true);
    }
  }

  [DefaultValue(null)]
  public System.Drawing.Image MouseOverImage
  {
    get => this.image_1;
    set => this.image_1 = value;
  }

  [DefaultValue(null)]
  public System.Drawing.Image DisabledImage
  {
    get => this.image_2;
    set => this.image_2 = value;
  }

  [DefaultValue(DevAge.Drawing.ContentAlignment.MiddleLeft)]
  public DevAge.Drawing.ContentAlignment ImageAlignment
  {
    get => this.contentAlignment_0;
    set
    {
      this.contentAlignment_0 = value;
      this.Invalidate(true);
    }
  }

  public DevAge.Drawing.ContentAlignment TextAlignment
  {
    get => DevAge.Drawing.Utilities.StringFormatToContentAlignment(this.stringFormat_0);
    set
    {
      DevAge.Drawing.Utilities.ApplyContentAlignmentToStringFormat(value, this.stringFormat_0);
      this.Invalidate(true);
    }
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public StringFormat StringFormat
  {
    get => this.stringFormat_0;
    set
    {
      this.stringFormat_0 = value;
      this.Invalidate(true);
    }
  }

  [DefaultValue(true)]
  public bool AlignTextToImage
  {
    get => this.bool_0;
    set
    {
      this.bool_0 = value;
      this.Invalidate(true);
    }
  }

  [DefaultValue(false)]
  public bool ImageStretch
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      this.Invalidate(true);
    }
  }

  [DefaultValue(false)]
  public bool EnableMouseEffect
  {
    get => this.bool_2;
    set => this.bool_2 = value;
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public override string Text
  {
    get => base.Text;
    set => base.Text = value;
  }

  [DefaultValue(0)]
  public int BorderWidth
  {
    get => this.int_0;
    set
    {
      this.int_0 = value;
      this.Invalidate(true);
    }
  }

  [DefaultValue(0)]
  public double BorderRound
  {
    get => this.double_0;
    set
    {
      this.double_0 = value;
      this.Invalidate(true);
    }
  }

  public Color BorderColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.Invalidate(true);
    }
  }

  public new Color BackColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      this.Invalidate();
    }
  }

  protected override void OnMouseEnter(EventArgs e)
  {
    base.OnMouseEnter(e);
    this.bool_3 = true;
    this.Invalidate();
  }

  protected override void OnMouseLeave(EventArgs e)
  {
    base.OnMouseLeave(e);
    this.bool_3 = false;
    this.Invalidate();
  }

  protected virtual void DrawBorderAndFill(Graphics graphics)
  {
    int width = this.BorderWidth;
    double borderRound = this.BorderRound;
    Color color1 = this.BorderColor;
    Color color2 = this.BackColor;
    if ((!this.bool_2 || !this.bool_3 ? 0 : (this.Enabled ? 1 : 0)) != 0)
    {
      Color baseColor = Color.FromKnownColor(KnownColor.Highlight);
      color2 = Color.FromArgb(75, baseColor);
      if (width == 0)
        width = 1;
      color1 = baseColor;
    }
    RoundedRectangle roundRect = new RoundedRectangle(this.ClientRectangle, borderRound);
    using (SolidBrush solidBrush = new SolidBrush(color2))
      DevAge.Drawing.Utilities.FillRoundedRectangle(graphics, roundRect, (Brush) solidBrush);
    if (width <= 0)
      return;
    using (Pen pen = new Pen(color1, (float) width))
      DevAge.Drawing.Utilities.DrawRoundedRectangle(graphics, roundRect, pen);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    if (this.BorderRound > 0.0)
      e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
    this.DrawBorderAndFill(e.Graphics);
    bool flag = false;
    System.Drawing.Image image1 = this.image_0;
    if (!this.Enabled)
    {
      if (this.image_2 != null)
        image1 = this.image_2;
      else
        flag = true;
    }
    else if ((!this.bool_3 ? 0 : (this.image_1 != null ? 1 : 0)) != 0)
      image1 = this.image_1;
    Rectangle area = this.ClientRectangle;
    if (this.BorderWidth > 0)
      area = new Rectangle(area.X + this.BorderWidth, area.Y + this.BorderWidth, area.Width - this.BorderWidth * 2, area.Height - this.BorderWidth * 2);
    DevAge.Drawing.VisualElements.Container container = new DevAge.Drawing.VisualElements.Container();
    TextGDI textGdi = new TextGDI(this.Text);
    DevAge.Drawing.VisualElements.Image image2 = new DevAge.Drawing.VisualElements.Image(image1);
    image2.AnchorArea = new AnchorArea(this.contentAlignment_0, this.bool_1);
    image2.Enabled = !flag;
    textGdi.AnchorArea = new AnchorArea(DevAge.Drawing.Utilities.StringFormatToContentAlignment(this.stringFormat_0), false);
    textGdi.StringFormat = this.stringFormat_0;
    textGdi.Font = this.Font;
    textGdi.ForeColor = this.ForeColor;
    textGdi.Enabled = this.Enabled;
    container.Elements.Add((IVisualElement) image2);
    container.Elements.Add((IVisualElement) textGdi);
    using (GraphicsCache graphics = new GraphicsCache(e.Graphics, e.ClipRectangle))
      container.Draw(graphics, (RectangleF) area);
  }

  protected override void OnTextChanged(EventArgs e)
  {
    base.OnTextChanged(e);
    this.Invalidate(true);
  }
}
