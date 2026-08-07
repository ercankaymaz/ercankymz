// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.HeaderGroupBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class HeaderGroupBox : GroupBox
{
  private Image image_0 = (Image) null;

  protected override void OnPaint(PaintEventArgs e)
  {
    StringFormat stringFormat = new StringFormat();
    stringFormat.Trimming = StringTrimming.Character;
    stringFormat.Alignment = StringAlignment.Near;
    if (this.RightToLeft == RightToLeft.Yes)
      stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
    SizeF sizeF = e.Graphics.MeasureString(this.Text, this.Font, (SizeF) this.ClientRectangle.Size, stringFormat);
    if (this.Enabled)
    {
      using (Brush brush = (Brush) new SolidBrush(this.ForeColor))
        e.Graphics.DrawString(this.Text, this.Font, brush, (RectangleF) this.ClientRectangle, stringFormat);
    }
    else
      ControlPaint.DrawStringDisabled(e.Graphics, this.Text, this.Font, this.BackColor, (RectangleF) this.ClientRectangle, stringFormat);
    Pen pen1 = new Pen(ControlPaint.LightLight(this.BackColor), (float) SystemInformation.BorderSize.Height);
    Pen pen2 = new Pen(ControlPaint.Dark(this.BackColor), (float) SystemInformation.BorderSize.Height);
    Point pt1;
    ref Point local1 = ref pt1;
    Rectangle clientRectangle1 = this.ClientRectangle;
    int left = clientRectangle1.Left;
    clientRectangle1 = this.ClientRectangle;
    int y1 = clientRectangle1.Top + (int) ((double) this.Font.Height / 2.0);
    local1 = new Point(left, y1);
    Point pt2;
    ref Point local2 = ref pt2;
    Rectangle clientRectangle2 = this.ClientRectangle;
    int right = clientRectangle2.Right;
    clientRectangle2 = this.ClientRectangle;
    int y2 = clientRectangle2.Top + (int) ((double) this.Font.Height / 2.0);
    local2 = new Point(right, y2);
    if (this.RightToLeft != RightToLeft.Yes)
    {
      pt1.X += (int) sizeF.Width;
      if (this.image_0 != null)
        pt2.X -= 17;
      if (this.image_0 != null)
        e.Graphics.DrawImage(this.image_0, pt2.X + 1, 0, 16 /*0x10*/, 16 /*0x10*/);
    }
    else
    {
      pt2.X -= (int) sizeF.Width;
      if (this.image_0 != null)
        pt1.X += 17;
      if (this.image_0 != null)
        e.Graphics.DrawImage(this.image_0, 0, 0, 16 /*0x10*/, 16 /*0x10*/);
    }
    if (this.FlatStyle == FlatStyle.Flat)
    {
      e.Graphics.DrawLine(pen2, pt1, pt2);
    }
    else
    {
      e.Graphics.DrawLine(pen2, pt1, pt2);
      pt1.Offset(0, (int) Math.Ceiling((double) SystemInformation.BorderSize.Height / 2.0));
      pt2.Offset(0, (int) Math.Ceiling((double) SystemInformation.BorderSize.Height / 2.0));
      e.Graphics.DrawLine(pen1, pt1, pt2);
    }
    pen1.Dispose();
    pen2.Dispose();
  }

  public Image Image
  {
    get => this.image_0;
    set => this.image_0 = value;
  }
}
