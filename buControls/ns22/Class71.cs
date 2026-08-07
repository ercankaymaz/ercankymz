// Decompiled with JetBrains decompiler
// Type: ns22.Class71
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace ns22;

[ToolboxItem(false)]
internal sealed class Class71 : ComboBox
{
  protected int int_0;
  protected int int_1;
  private Color color_0;

  public Class71()
  {
    this.DrawMode = DrawMode.OwnerDrawFixed;
    this.DropDownStyle = ComboBoxStyle.DropDownList;
    this.int_0 = 2;
    this.int_1 = 5;
    this.BeginUpdate();
    Class39.smethod_183(this);
    this.EndUpdate();
  }

  virtual void ComboBox.OnDrawItem(DrawItemEventArgs e)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((ComboBox) this).OnDrawItem(e));
    if ((e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit)
      e.DrawBackground();
    Graphics graphics1 = e.Graphics;
    if (this.Items.Count > 141)
    {
      for (int index = this.Items.Count - 1; index >= 141; --index)
        this.Items.RemoveAt(index);
    }
    if (e.Index == -1)
      return;
    this.color_0 = Color.FromName((string) this.Items[e.Index]);
    Graphics graphics2 = graphics1;
    SolidBrush solidBrush1 = new SolidBrush(this.color_0);
    Rectangle bounds = e.Bounds;
    int x1 = bounds.X + this.int_0;
    bounds = e.Bounds;
    int y1 = bounds.Y + this.int_0;
    bounds = e.Bounds;
    int width1 = bounds.Width / this.int_1 - 2 * this.int_0;
    bounds = e.Bounds;
    int height1 = bounds.Height - 2 * this.int_0;
    graphics2.FillRectangle((Brush) solidBrush1, x1, y1, width1, height1);
    Graphics graphics3 = graphics1;
    Pen black = Pens.Black;
    bounds = e.Bounds;
    int x2 = bounds.X + this.int_0;
    bounds = e.Bounds;
    int y2 = bounds.Y + this.int_0;
    bounds = e.Bounds;
    int width2 = bounds.Width / this.int_1 - 2 * this.int_0;
    bounds = e.Bounds;
    int height2 = bounds.Height - 2 * this.int_0;
    graphics3.DrawRectangle(black, x2, y2, width2, height2);
    Graphics graphics4 = graphics1;
    string name = this.color_0.Name;
    Font font = e.Font;
    SolidBrush solidBrush2 = new SolidBrush(this.ForeColor);
    bounds = e.Bounds;
    double x3 = (double) (bounds.Width / this.int_1 + 5 * this.int_0);
    bounds = e.Bounds;
    double y3 = (double) bounds.Y;
    graphics4.DrawString(name, font, (Brush) solidBrush2, (float) x3, (float) y3);
  }
}
