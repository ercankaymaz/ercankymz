// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.Line
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class Line : UserControl
{
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private DashStyle dashStyle_0 = DashStyle.Solid;
  private Color color_0 = Color.FromKnownColor(KnownColor.ControlDark);
  private Color color_1 = Color.FromKnownColor(KnownColor.ControlLightLight);
  private LineStyle lineStyle_0 = LineStyle.Horizontal;

  public Line()
  {
    Class39.smethod_451(this);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.FixedWidth | ControlStyles.FixedHeight | ControlStyles.AllPaintingInWmPaint, true);
    this.SetStyle(ControlStyles.Selectable, false);
    this.TabStop = false;
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
    int x1_1;
    int y1_1;
    int x2_1;
    int y2_1;
    int x1_2;
    int y1_2;
    int x2_2;
    int y2_2;
    if (this.LineStyle == LineStyle.Horizontal)
    {
      x1_1 = 0;
      y1_1 = 0;
      Rectangle clientRectangle = this.ClientRectangle;
      x2_1 = clientRectangle.Width;
      y2_1 = 0;
      x1_2 = 0;
      y1_2 = 1;
      clientRectangle = this.ClientRectangle;
      x2_2 = clientRectangle.Width;
      y2_2 = 1;
    }
    else
    {
      x1_1 = 0;
      y1_1 = 0;
      x2_1 = 0;
      Rectangle clientRectangle = this.ClientRectangle;
      y2_1 = clientRectangle.Height;
      x1_2 = 1;
      y1_2 = 0;
      x2_2 = 1;
      clientRectangle = this.ClientRectangle;
      y2_2 = clientRectangle.Height;
    }
    using (Pen pen = new Pen(this.color_0, 1f))
    {
      pen.DashStyle = this.dashStyle_0;
      e.Graphics.DrawLine(pen, x1_1, y1_1, x2_1, y2_1);
    }
    using (Pen pen = new Pen(this.color_1, 1f))
    {
      pen.DashStyle = this.dashStyle_0;
      e.Graphics.DrawLine(pen, x1_2, y1_2, x2_2, y2_2);
    }
  }

  public DashStyle DashStyle
  {
    get => this.dashStyle_0;
    set
    {
      this.dashStyle_0 = value;
      this.Invalidate();
    }
  }

  public Color FirstColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.Invalidate();
    }
  }

  public Color SecondColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      this.Invalidate();
    }
  }

  public LineStyle LineStyle
  {
    get => this.lineStyle_0;
    set
    {
      this.lineStyle_0 = value;
      this.Size = new Size(this.Height, this.Width);
      this.Invalidate();
    }
  }

  protected override void OnSizeChanged(EventArgs e)
  {
    base.OnSizeChanged(e);
    Class39.smethod_136(this);
  }
}
