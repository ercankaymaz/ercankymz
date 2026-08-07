// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Hint
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class Hint
{
  public string Text
  {
    get => this.HostPanel.Text;
    set => this.HostPanel.Text = value;
  }

  public Range Range { get; set; }

  public Color BackColor
  {
    get => this.HostPanel.BackColor;
    set => this.HostPanel.BackColor = value;
  }

  public Color BackColor2
  {
    get => this.HostPanel.BackColor2;
    set => this.HostPanel.BackColor2 = value;
  }

  public Color BorderColor
  {
    get => this.HostPanel.BorderColor;
    set => this.HostPanel.BorderColor = value;
  }

  public Color ForeColor
  {
    get => this.HostPanel.ForeColor;
    set => this.HostPanel.ForeColor = value;
  }

  public StringAlignment TextAlignment
  {
    get => this.HostPanel.TextAlignment;
    set => this.HostPanel.TextAlignment = value;
  }

  public Font Font
  {
    get => this.HostPanel.Font;
    set => this.HostPanel.Font = value;
  }

  public event EventHandler Click
  {
    add => this.HostPanel.Click += value;
    remove => this.HostPanel.Click -= value;
  }

  public Control InnerControl { get; set; }

  public DockStyle Dock { get; set; }

  public int Width
  {
    get => this.HostPanel.Width;
    set => this.HostPanel.Width = value;
  }

  public int Height
  {
    get => this.HostPanel.Height;
    set => this.HostPanel.Height = value;
  }

  public UnfocusablePanel HostPanel { get; private set; }

  [CompilerGenerated]
  [SpecialName]
  internal int method_0() => this.int_0;

  [CompilerGenerated]
  [SpecialName]
  internal void method_1(int int_1) => this.int_0 = int_1;

  public object Tag { get; set; }

  public Cursor Cursor
  {
    get => this.HostPanel.Cursor;
    set => this.HostPanel.Cursor = value;
  }

  public bool Inline { get; set; }

  public virtual void DoVisible()
  {
    this.Range.tb.DoRangeVisible(this.Range, true);
    Class39.smethod_542(this.Range.tb, this.HostPanel.Bounds);
    this.Range.tb.Invalidate();
  }

  private Hint(Range range_1, Control control_1, string string_0, bool bool_1, bool bool_2)
  {
    this.Range = range_1;
    this.Inline = bool_1;
    this.InnerControl = control_1;
    this.Init();
    this.Dock = bool_2 ? DockStyle.Fill : DockStyle.None;
    this.Text = string_0;
  }

  public Hint(Range range, string text, bool inline, bool dock)
    : this(range, (Control) null, text, inline, dock)
  {
  }

  public Hint(Range range, string text)
    : this(range, (Control) null, text, true, true)
  {
  }

  public Hint(Range range, Control innerControl, bool inline, bool dock)
    : this(range, innerControl, (string) null, inline, dock)
  {
  }

  public Hint(Range range, Control innerControl)
    : this(range, innerControl, (string) null, true, true)
  {
  }

  protected virtual void Init()
  {
    this.HostPanel = new UnfocusablePanel();
    this.HostPanel.Click += new EventHandler(this.OnClick);
    this.Cursor = Cursors.Default;
    this.BorderColor = Color.Silver;
    this.BackColor2 = Color.White;
    this.BackColor = this.InnerControl == null ? Color.Silver : SystemColors.Control;
    this.ForeColor = Color.Black;
    this.TextAlignment = StringAlignment.Near;
    this.Font = this.Range.tb.Parent == null ? this.Range.tb.Font : this.Range.tb.Parent.Font;
    if (this.InnerControl != null)
    {
      this.HostPanel.Controls.Add(this.InnerControl);
      Size preferredSize = this.InnerControl.GetPreferredSize(this.InnerControl.Size);
      this.HostPanel.Width = preferredSize.Width + 2;
      this.HostPanel.Height = preferredSize.Height + 2;
      this.InnerControl.Dock = DockStyle.Fill;
      this.InnerControl.Visible = true;
      this.BackColor = SystemColors.Control;
    }
    else
      this.HostPanel.Height = this.Range.tb.CharHeight + 5;
  }

  protected virtual void OnClick(object sender, EventArgs e) => this.Range.tb.OnHintClick(this);
}
