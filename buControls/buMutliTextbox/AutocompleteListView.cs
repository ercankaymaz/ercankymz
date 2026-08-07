// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.AutocompleteListView
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

[ToolboxItem(false)]
public class AutocompleteListView : UserControl, IDisposable
{
  internal List<AutocompleteItem> list_0;
  internal IEnumerable<AutocompleteItem> ienumerable_0 = (IEnumerable<AutocompleteItem>) new List<AutocompleteItem>();
  private int int_0 = 0;
  private int int_1 = -1;
  internal int int_2 = 0;
  internal buMultiTextBox buMultiTextBox_0;
  internal ToolTip toolTip_0 = new ToolTip();
  internal Timer timer_0 = new Timer();

  public event EventHandler FocussedItemIndexChanged;

  [CompilerGenerated]
  [SpecialName]
  internal bool method_0() => this.bool_0;

  [CompilerGenerated]
  [SpecialName]
  internal void method_1(bool bool_1) => this.bool_0 = bool_1;

  public ImageList ImageList { get; set; }

  [CompilerGenerated]
  [SpecialName]
  internal int method_2() => this.int_3;

  [CompilerGenerated]
  [SpecialName]
  internal void method_3(int int_4) => this.int_3 = int_4;

  [CompilerGenerated]
  [SpecialName]
  internal Size method_4() => this.size_0;

  [CompilerGenerated]
  [SpecialName]
  internal void method_5(Size size_1) => this.size_0 = size_1;

  public Color SelectedColor { get; set; }

  public Color HoveredColor { get; set; }

  public int FocussedItemIndex
  {
    get => this.int_0;
    set
    {
      if (this.int_0 == value)
        return;
      this.int_0 = value;
      if (this.eventHandler_0 == null)
        return;
      this.eventHandler_0((object) this, EventArgs.Empty);
    }
  }

  public AutocompleteItem FocussedItem
  {
    get
    {
      return (this.FocussedItemIndex < 0 ? 0 : (this.int_0 < this.list_0.Count ? 1 : 0)) == 0 ? (AutocompleteItem) null : this.list_0[this.int_0];
    }
    set => this.FocussedItemIndex = this.list_0.IndexOf(value);
  }

  internal AutocompleteListView(buMultiTextBox buMultiTextBox_1)
  {
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    this.Font = new Font(FontFamily.GenericSansSerif, 9f);
    this.list_0 = new List<AutocompleteItem>();
    this.VerticalScroll.SmallChange = Class39.smethod_86(this);
    this.MaximumSize = new Size(this.Size.Width, 180);
    this.toolTip_0.ShowAlways = false;
    Class39.smethod_11(500, this);
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.SelectedColor = Color.Orange;
    this.HoveredColor = Color.Red;
    this.method_3(3000);
    this.toolTip_0.Popup += new PopupEventHandler(this.toolTip_0_Popup);
    this.buMultiTextBox_0 = buMultiTextBox_1;
    buMultiTextBox_1.KeyDown += new KeyEventHandler(this.method_8);
    buMultiTextBox_1.SelectionChanged += new EventHandler(this.method_7);
    buMultiTextBox_1.KeyPressed += new KeyPressEventHandler(this.method_6);
    Form form = buMultiTextBox_1.FindForm();
    if (form != null)
    {
      form.LocationChanged += (EventHandler) ((sender, e) => Class39.smethod_170(this));
      form.ResizeBegin += (EventHandler) ((sender, e) => Class39.smethod_170(this));
      form.FormClosing += (FormClosingEventHandler) ((sender, e) => Class39.smethod_170(this));
      form.LostFocus += (EventHandler) ((sender, e) => Class39.smethod_170(this));
    }
    buMultiTextBox_1.LostFocus += (EventHandler) ((sender, e) =>
    {
      if ((Class39.smethod_169(this) == null ? 0 : (!Class39.smethod_169(this).IsDisposed ? 1 : 0)) == 0 || Class39.smethod_169(this).Focused)
        return;
      Class39.smethod_170(this);
    });
    buMultiTextBox_1.Scroll += (ScrollEventHandler) ((sender, e) => Class39.smethod_170(this));
    this.VisibleChanged += (EventHandler) ((sender, e) =>
    {
      if (!this.Visible)
        return;
      Class39.smethod_114(this);
    });
  }

  private void toolTip_0_Popup(object sender, PopupEventArgs e)
  {
    if ((this.method_4().Height <= 0 ? 0 : (this.method_4().Width > 0 ? 1 : 0)) == 0)
      return;
    e.ToolTipSize = this.method_4();
  }

  protected override void Dispose(bool disposing)
  {
    if (this.toolTip_0 != null)
    {
      this.toolTip_0.Popup -= new PopupEventHandler(this.toolTip_0_Popup);
      this.toolTip_0.Dispose();
    }
    if (this.buMultiTextBox_0 != null)
    {
      this.buMultiTextBox_0.KeyDown -= new KeyEventHandler(this.method_8);
      this.buMultiTextBox_0.KeyPress -= new KeyPressEventHandler(this.method_6);
      this.buMultiTextBox_0.SelectionChanged -= new EventHandler(this.method_7);
    }
    if (this.timer_0 != null)
    {
      this.timer_0.Stop();
      this.timer_0.Tick -= new EventHandler(this.timer_0_Tick);
      this.timer_0.Dispose();
    }
    base.Dispose(disposing);
  }

  private void method_6(object sender, KeyPressEventArgs e)
  {
    bool flag = e.KeyChar == '\b' || e.KeyChar == 'ÿ';
    if ((!Class39.smethod_169(this).Visible ? 0 : (!flag ? 1 : 0)) != 0)
      Class39.smethod_645(this, false);
    else
      Class39.smethod_315(this, this.timer_0);
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.timer_0.Stop();
    Class39.smethod_645(this, false);
  }

  private void method_7(object sender, EventArgs e)
  {
    if (!Class39.smethod_169(this).Visible)
      return;
    bool flag = false;
    if (!this.buMultiTextBox_0.Selection.IsEmpty)
      flag = true;
    else if (!Class39.smethod_169(this).Fragment.Contains(this.buMultiTextBox_0.Selection.Start))
    {
      if ((this.buMultiTextBox_0.Selection.Start.iLine != Class39.smethod_169(this).Fragment.End.iLine ? 0 : (this.buMultiTextBox_0.Selection.Start.iChar == Class39.smethod_169(this).Fragment.End.iChar + 1 ? 1 : 0)) != 0)
      {
        if (!Regex.IsMatch(this.buMultiTextBox_0.Selection.CharBeforeStart.ToString(), Class39.smethod_169(this).SearchPattern))
          flag = true;
      }
      else
        flag = true;
    }
    if (!flag)
      return;
    Class39.smethod_169(this).Close();
  }

  private void method_8(object sender, KeyEventArgs e)
  {
    buMultiTextBox buMultiTextBox = sender as buMultiTextBox;
    if (Class39.smethod_169(this).Visible)
    {
      Keys keyCode = e.KeyCode;
      if (Class39.smethod_705(e.Modifiers, keyCode, this))
        e.Handled = true;
    }
    if (Class39.smethod_169(this).Visible)
      return;
    if ((!buMultiTextBox.HotkeysMapping.ContainsKey(e.KeyData) ? 0 : (buMultiTextBox.HotkeysMapping[e.KeyData] == FCTBAction.AutocompleteMenu ? 1 : 0)) != 0)
    {
      Class39.smethod_690(this);
      e.Handled = true;
    }
    else
    {
      if ((e.KeyCode != Keys.Escape ? 0 : (this.timer_0.Enabled ? 1 : 0)) == 0)
        return;
      this.timer_0.Stop();
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Class39.smethod_148(this);
    int num1 = Class39.smethod_86(this);
    int val1_1 = this.VerticalScroll.Value / num1 - 1;
    int val1_2 = (this.VerticalScroll.Value + this.ClientSize.Height) / num1 + 1;
    int num2 = Math.Max(val1_1, 0);
    int num3 = Math.Min(val1_2, this.list_0.Count);
    int x = 18;
    for (int index = num2; index < num3; ++index)
    {
      int y = index * num1 - this.VerticalScroll.Value;
      AutocompleteItem autocompleteItem = this.list_0[index];
      if (autocompleteItem.BackColor != Color.Transparent)
      {
        using (SolidBrush solidBrush = new SolidBrush(autocompleteItem.BackColor))
          e.Graphics.FillRectangle((Brush) solidBrush, 1, y, this.ClientSize.Width - 1 - 1, num1 - 1);
      }
      if ((this.ImageList == null ? 0 : (this.list_0[index].ImageIndex >= 0 ? 1 : 0)) != 0)
        e.Graphics.DrawImage(this.ImageList.Images[autocompleteItem.ImageIndex], 1, y);
      if (index == this.FocussedItemIndex)
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, y - 3), new Point(0, y + num1), Color.Transparent, this.SelectedColor))
        {
          using (Pen pen = new Pen(this.SelectedColor))
          {
            e.Graphics.FillRectangle((Brush) linearGradientBrush, x, y, this.ClientSize.Width - 1 - x, num1 - 1);
            e.Graphics.DrawRectangle(pen, x, y, this.ClientSize.Width - 1 - x, num1 - 1);
          }
        }
      }
      if (index == this.int_1)
      {
        using (Pen pen = new Pen(this.HoveredColor))
          e.Graphics.DrawRectangle(pen, x, y, this.ClientSize.Width - 1 - x, num1 - 1);
      }
      using (SolidBrush solidBrush = new SolidBrush(autocompleteItem.ForeColor != Color.Transparent ? autocompleteItem.ForeColor : this.ForeColor))
        e.Graphics.DrawString(autocompleteItem.ToString(), this.Font, (Brush) solidBrush, (float) x, (float) y);
    }
  }

  protected override void OnScroll(ScrollEventArgs se)
  {
    base.OnScroll(se);
    this.Invalidate();
  }

  protected override void OnMouseClick(MouseEventArgs e)
  {
    base.OnMouseClick(e);
    if (e.Button != MouseButtons.Left)
      return;
    this.FocussedItemIndex = Class39.smethod_505(this, e.Location);
    Class39.smethod_114(this);
    this.Invalidate();
  }

  protected override void OnMouseDoubleClick(MouseEventArgs e)
  {
    base.OnMouseDoubleClick(e);
    this.FocussedItemIndex = Class39.smethod_505(this, e.Location);
    this.Invalidate();
    this.vmethod_0();
  }

  internal virtual void vmethod_0()
  {
    if ((this.FocussedItemIndex < 0 ? 1 : (this.FocussedItemIndex >= this.list_0.Count ? 1 : 0)) != 0)
      return;
    this.buMultiTextBox_0.TextSource.Manager.BeginAutoUndoCommands();
    try
    {
      AutocompleteItem focussedItem = this.FocussedItem;
      SelectingEventArgs selectingEventArgs_0 = new SelectingEventArgs()
      {
        Item = focussedItem,
        SelectedIndex = this.FocussedItemIndex
      };
      Class39.smethod_146(Class39.smethod_169(this), selectingEventArgs_0);
      if (selectingEventArgs_0.Cancel)
      {
        this.FocussedItemIndex = selectingEventArgs_0.SelectedIndex;
        this.Invalidate();
      }
      else
      {
        if (!selectingEventArgs_0.Handled)
          Class39.smethod_519(Class39.smethod_169(this).Fragment, focussedItem, this);
        Class39.smethod_169(this).Close();
        SelectedEventArgs selectedEventArgs = new SelectedEventArgs()
        {
          Item = focussedItem,
          Tb = Class39.smethod_169(this).Fragment.tb
        };
        focussedItem.OnSelected(Class39.smethod_169(this), selectedEventArgs);
        Class39.smethod_169(this).OnSelected(selectedEventArgs);
      }
    }
    finally
    {
      this.buMultiTextBox_0.TextSource.Manager.EndAutoUndoCommands();
    }
  }

  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    Class39.smethod_705(Keys.None, keyData, this);
    return base.ProcessCmdKey(ref msg, keyData);
  }

  public void SelectNext(int shift)
  {
    this.FocussedItemIndex = Math.Max(0, Math.Min(this.FocussedItemIndex + shift, this.list_0.Count - 1));
    Class39.smethod_114(this);
    this.Invalidate();
  }

  public int Count => this.list_0.Count;

  public void SetAutocompleteItems(ICollection<string> items)
  {
    List<AutocompleteItem> items1 = new List<AutocompleteItem>(items.Count);
    foreach (string text in (IEnumerable<string>) items)
      items1.Add(new AutocompleteItem(text));
    this.SetAutocompleteItems((IEnumerable<AutocompleteItem>) items1);
  }

  public void SetAutocompleteItems(IEnumerable<AutocompleteItem> items)
  {
    this.ienumerable_0 = items;
  }
}
