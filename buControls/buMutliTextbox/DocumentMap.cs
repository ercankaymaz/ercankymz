// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.DocumentMap
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
namespace buMutliTextbox;

public class DocumentMap : Control
{
  public EventHandler TargetChanged;
  internal buMultiTextBox buMultiTextBox_0;
  private float float_0 = 0.3f;
  private bool bool_0 = true;
  internal Place place_0 = Place.Empty;
  private bool bool_1 = true;

  [Description("Target FastColoredTextBox")]
  public buMultiTextBox Target
  {
    get => this.buMultiTextBox_0;
    set
    {
      if (this.buMultiTextBox_0 != null)
        this.UnSubscribe(this.buMultiTextBox_0);
      this.buMultiTextBox_0 = value;
      if (value != null)
        this.Subscribe(this.buMultiTextBox_0);
      this.OnTargetChanged();
    }
  }

  [Description("Scale")]
  [DefaultValue(0.3f)]
  public float Scale
  {
    get => this.float_0;
    set
    {
      this.float_0 = value;
      this.NeedRepaint();
    }
  }

  [Description("Scrollbar visibility")]
  [DefaultValue(true)]
  public bool ScrollbarVisible
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      this.NeedRepaint();
    }
  }

  public DocumentMap()
  {
    this.ForeColor = Color.Maroon;
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    Application.Idle += new EventHandler(this.method_0);
  }

  private void method_0(object sender, EventArgs e)
  {
    if (!this.bool_0)
      return;
    this.Invalidate();
  }

  protected virtual void OnTargetChanged()
  {
    this.NeedRepaint();
    if (this.TargetChanged == null)
      return;
    this.TargetChanged((object) this, EventArgs.Empty);
  }

  protected virtual void UnSubscribe(buMultiTextBox target)
  {
    target.Scroll -= new ScrollEventHandler(this.Target_Scroll);
    target.SelectionChangedDelayed -= new EventHandler(this.Target_SelectionChanged);
    target.VisibleRangeChanged -= new EventHandler(this.Target_VisibleRangeChanged);
  }

  protected virtual void Subscribe(buMultiTextBox target)
  {
    target.Scroll += new ScrollEventHandler(this.Target_Scroll);
    target.SelectionChangedDelayed += new EventHandler(this.Target_SelectionChanged);
    target.VisibleRangeChanged += new EventHandler(this.Target_VisibleRangeChanged);
  }

  protected virtual void Target_VisibleRangeChanged(object sender, EventArgs e)
  {
    this.NeedRepaint();
  }

  protected virtual void Target_SelectionChanged(object sender, EventArgs e) => this.NeedRepaint();

  protected virtual void Target_Scroll(object sender, ScrollEventArgs e) => this.NeedRepaint();

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);
    this.NeedRepaint();
  }

  public void NeedRepaint() => this.bool_0 = true;

  protected override void OnPaint(PaintEventArgs e)
  {
    if (this.buMultiTextBox_0 == null)
      return;
    float num1 = this.Scale * 100f / (float) this.buMultiTextBox_0.Zoom;
    if ((double) num1 <= 1.4012984643248171E-45)
      return;
    Range visibleRange = this.buMultiTextBox_0.VisibleRange;
    if (this.place_0.iLine > visibleRange.Start.iLine)
    {
      this.place_0.iLine = visibleRange.Start.iLine;
    }
    else
    {
      Point point = this.buMultiTextBox_0.PlaceToPoint(visibleRange.End);
      point.Offset(0, -(int) ((double) this.ClientSize.Height / (double) num1) + this.buMultiTextBox_0.CharHeight);
      Place place = this.buMultiTextBox_0.PointToPlace(point);
      if (place.iLine > this.place_0.iLine)
        this.place_0.iLine = place.iLine;
    }
    this.place_0.iChar = 0;
    int count = this.buMultiTextBox_0.Lines.Count;
    float num2 = (float) visibleRange.Start.iLine / (float) count;
    float num3 = (float) visibleRange.End.iLine / (float) count;
    e.Graphics.ScaleTransform(num1, num1);
    SizeF sizeF = new SizeF((float) this.ClientSize.Width / num1, (float) this.ClientSize.Height / num1);
    this.buMultiTextBox_0.DrawText(e.Graphics, this.place_0, sizeF.ToSize());
    Point point1 = this.buMultiTextBox_0.PlaceToPoint(this.place_0);
    Point point2 = this.buMultiTextBox_0.PlaceToPoint(visibleRange.Start);
    Point point3 = this.buMultiTextBox_0.PlaceToPoint(visibleRange.End);
    int y1 = point2.Y - point1.Y;
    int num4 = point3.Y + this.buMultiTextBox_0.CharHeight - point1.Y;
    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
    using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, this.ForeColor)))
    {
      using (Pen pen = new Pen((Brush) solidBrush, 1f / num1))
      {
        Rectangle rect = new Rectangle(0, y1, (int) ((double) (this.ClientSize.Width - 1) / (double) num1), num4 - y1);
        e.Graphics.FillRectangle((Brush) solidBrush, rect);
        e.Graphics.DrawRectangle(pen, rect);
      }
    }
    if (this.bool_1)
    {
      e.Graphics.ResetTransform();
      e.Graphics.SmoothingMode = SmoothingMode.None;
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(200, this.ForeColor)))
      {
        RectangleF rect;
        ref RectangleF local = ref rect;
        Size clientSize = this.ClientSize;
        double x = (double) (clientSize.Width - 3);
        clientSize = this.ClientSize;
        double y2 = (double) clientSize.Height * (double) num2;
        clientSize = this.ClientSize;
        double height = (double) clientSize.Height * ((double) num3 - (double) num2);
        local = new RectangleF((float) x, (float) y2, 2f, (float) height);
        e.Graphics.FillRectangle((Brush) solidBrush, rect);
      }
    }
    this.bool_0 = false;
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
      Class39.smethod_593(e.Location, this);
    base.OnMouseDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
      Class39.smethod_593(e.Location, this);
    base.OnMouseMove(e);
  }

  internal void method_1()
  {
    this.Refresh();
    this.buMultiTextBox_0.Refresh();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
    {
      Application.Idle -= new EventHandler(this.method_0);
      if (this.buMultiTextBox_0 != null)
        this.UnSubscribe(this.buMultiTextBox_0);
    }
    base.Dispose(disposing);
  }
}
