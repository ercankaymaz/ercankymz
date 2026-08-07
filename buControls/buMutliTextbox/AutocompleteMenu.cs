// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.AutocompleteMenu
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

[Browsable(false)]
public class AutocompleteMenu : ToolStripDropDown, IDisposable
{
  internal AutocompleteListView autocompleteListView_0;
  public ToolStripControlHost host;

  public Range Fragment { get; internal set; }

  public string SearchPattern { get; set; }

  public int MinFragmentLength { get; set; }

  public event EventHandler<SelectingEventArgs> Selecting;

  public event EventHandler<SelectedEventArgs> Selected;

  public event EventHandler<CancelEventArgs> Opening;

  public bool AllowTabKey
  {
    get => this.autocompleteListView_0.method_0();
    set => this.autocompleteListView_0.method_1(value);
  }

  public int AppearInterval
  {
    get => Class39.smethod_465(this.autocompleteListView_0);
    set => Class39.smethod_11(value, this.autocompleteListView_0);
  }

  public Size MaxTooltipSize
  {
    get => this.autocompleteListView_0.method_4();
    set => this.autocompleteListView_0.method_5(value);
  }

  public bool AlwaysShowTooltip
  {
    get => Class39.smethod_572(this.autocompleteListView_0);
    set => Class39.smethod_794(this.autocompleteListView_0, value);
  }

  [DefaultValue(typeof (Color), "Orange")]
  public Color SelectedColor
  {
    get => this.autocompleteListView_0.SelectedColor;
    set => this.autocompleteListView_0.SelectedColor = value;
  }

  [DefaultValue(typeof (Color), "Red")]
  public Color HoveredColor
  {
    get => this.autocompleteListView_0.HoveredColor;
    set => this.autocompleteListView_0.HoveredColor = value;
  }

  public AutocompleteMenu(buMultiTextBox tb)
  {
    this.AutoClose = false;
    this.AutoSize = false;
    this.Margin = Padding.Empty;
    this.Padding = Padding.Empty;
    this.BackColor = Color.White;
    this.autocompleteListView_0 = new AutocompleteListView(tb);
    this.host = new ToolStripControlHost((Control) this.autocompleteListView_0);
    this.host.Margin = new Padding(2, 2, 2, 2);
    this.host.Padding = Padding.Empty;
    this.host.AutoSize = false;
    this.host.AutoToolTip = false;
    Class39.smethod_294(this);
    base.Items.Add((ToolStripItem) this.host);
    this.autocompleteListView_0.Parent = (Control) this;
    this.SearchPattern = "[\\w\\.]";
    this.MinFragmentLength = 2;
  }

  public new Font Font
  {
    get => this.autocompleteListView_0.Font;
    set => this.autocompleteListView_0.Font = value;
  }

  public new void Close()
  {
    this.autocompleteListView_0.toolTip_0.Hide((IWin32Window) this.autocompleteListView_0);
    base.Close();
  }

  public virtual void OnSelecting() => this.autocompleteListView_0.vmethod_0();

  public void SelectNext(int shift) => this.autocompleteListView_0.SelectNext(shift);

  public void OnSelected(SelectedEventArgs args)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) this, args);
  }

  public AutocompleteListView Items => this.autocompleteListView_0;

  public void Show(bool forced) => Class39.smethod_645(this.Items, forced);

  public new Size MinimumSize
  {
    get => this.Items.MinimumSize;
    set => this.Items.MinimumSize = value;
  }

  public new ImageList ImageList
  {
    get => this.Items.ImageList;
    set => this.Items.ImageList = value;
  }

  public int ToolTipDuration
  {
    get => this.Items.method_2();
    set => this.Items.method_3(value);
  }

  public new ToolTip ToolTip
  {
    get => this.Items.toolTip_0;
    set => this.Items.toolTip_0 = value;
  }

  protected override void Dispose(bool disposing)
  {
    base.Dispose(disposing);
    if ((this.autocompleteListView_0 == null ? 0 : (!this.autocompleteListView_0.IsDisposed ? 1 : 0)) == 0)
      return;
    this.autocompleteListView_0.Dispose();
  }
}
