// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Ruler
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

public class Ruler : UserControl
{
  public EventHandler TargetChanged;
  private buMultiTextBox buMultiTextBox_0;
  internal IContainer icontainer_0 = (IContainer) null;

  [DefaultValue(typeof (Color), "ControlLight")]
  public Color BackColor2 { get; set; }

  [DefaultValue(typeof (Color), "DarkGray")]
  public Color TickColor { get; set; }

  [DefaultValue(typeof (Color), "Black")]
  public Color CaretTickColor { get; set; }

  [Description("Target FastColoredTextBox")]
  public buMultiTextBox Target
  {
    get => this.buMultiTextBox_0;
    set
    {
      if (this.buMultiTextBox_0 != null)
        this.UnSubscribe(this.buMultiTextBox_0);
      this.buMultiTextBox_0 = value;
      this.Subscribe(this.buMultiTextBox_0);
      this.OnTargetChanged();
    }
  }

  public Ruler()
  {
    Class39.smethod_167(this);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    this.MinimumSize = new Size(0, 24);
    this.MaximumSize = new Size(1073741823 /*0x3FFFFFFF*/, 24);
    this.BackColor2 = SystemColors.ControlLight;
    this.TickColor = Color.DarkGray;
    this.CaretTickColor = Color.Black;
  }

  protected virtual void OnTargetChanged()
  {
    if (this.TargetChanged == null)
      return;
    this.TargetChanged((object) this, EventArgs.Empty);
  }

  protected virtual void UnSubscribe(buMultiTextBox target)
  {
    target.Scroll -= new ScrollEventHandler(this.target_Scroll);
    target.SelectionChanged -= new EventHandler(this.method_1);
    target.VisibleRangeChanged -= new EventHandler(this.method_0);
  }

  protected virtual void Subscribe(buMultiTextBox target)
  {
    target.Scroll += new ScrollEventHandler(this.target_Scroll);
    target.SelectionChanged += new EventHandler(this.method_1);
    target.VisibleRangeChanged += new EventHandler(this.method_0);
  }

  private void method_0(object sender, EventArgs e) => this.Invalidate();

  private void method_1(object sender, EventArgs e) => this.Invalidate();

  protected virtual void target_Scroll(object sender, ScrollEventArgs e) => this.Invalidate();

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);
    this.Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    if (this.buMultiTextBox_0 == null)
      return;
    Point client = this.PointToClient(this.buMultiTextBox_0.PointToScreen(this.buMultiTextBox_0.PlaceToPoint(this.buMultiTextBox_0.Selection.Start)));
    Size size = TextRenderer.MeasureText("W", this.Font);
    int num = 0;
    e.Graphics.FillRectangle((Brush) new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), this.BackColor, this.BackColor2, 270f), new Rectangle(0, 0, this.Width, this.Height));
    float charWidth = (float) this.buMultiTextBox_0.CharWidth;
    StringFormat format = new StringFormat();
    format.Alignment = StringAlignment.Center;
    format.LineAlignment = StringAlignment.Near;
    using (Pen pen = new Pen(this.TickColor))
    {
      using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
      {
        float x = (float) this.PointToClient(this.buMultiTextBox_0.PointToScreen(this.buMultiTextBox_0.PositionToPoint(0))).X;
        while ((double) x < (double) this.Right)
        {
          if (num % 10 == 0)
            e.Graphics.DrawString(num.ToString(), this.Font, (Brush) solidBrush, x, 0.0f, format);
          e.Graphics.DrawLine(pen, (int) x, size.Height + (num % 5 == 0 ? 1 : 3), (int) x, this.Height - 4);
          x += charWidth;
          ++num;
        }
      }
    }
    using (Pen pen = new Pen(this.TickColor))
      e.Graphics.DrawLine(pen, new Point(client.X - 3, this.Height - 3), new Point(client.X + 3, this.Height - 3));
    using (Pen pen = new Pen(this.CaretTickColor))
    {
      e.Graphics.DrawLine(pen, new Point(client.X - 2, size.Height + 3), new Point(client.X - 2, this.Height - 4));
      e.Graphics.DrawLine(pen, new Point(client.X, size.Height + 1), new Point(client.X, this.Height - 4));
      e.Graphics.DrawLine(pen, new Point(client.X + 2, size.Height + 3), new Point(client.X + 2, this.Height - 4));
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
