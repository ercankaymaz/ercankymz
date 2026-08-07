// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.ButtonMultiSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
[DefaultEvent("Click")]
public class ButtonMultiSelection : UserControl, IButtonControl
{
  internal Button button_0;
  internal DropDownButton dropDownButton_0;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private ContextMenu contextMenu_0 = new ContextMenu();
  private SubButtonItemCollection subButtonItemCollection_0 = new SubButtonItemCollection();
  private ButtonMultiSelectionMode buttonMultiSelectionMode_0 = ButtonMultiSelectionMode.InvokeFirstAction;

  public ButtonMultiSelection()
  {
    Class39.smethod_127(this);
    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    base.BackColor = Color.Transparent;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public override string Text
  {
    get => this.button_0.Text;
    set
    {
      this.button_0.Text = value;
      base.Text = value;
    }
  }

  [Browsable(false)]
  public new Color BackColor
  {
    get => base.BackColor;
    set => base.BackColor = value;
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public override Color ForeColor
  {
    get => base.ForeColor;
    set
    {
      this.button_0.ForeColor = value;
      this.dropDownButton_0.ForeColor = value;
      base.ForeColor = value;
    }
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public override Font Font
  {
    get => base.Font;
    set
    {
      this.button_0.Font = value;
      this.dropDownButton_0.Font = value;
      base.Font = value;
    }
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public virtual ContentAlignment TextAlign
  {
    get => this.button_0.TextAlign;
    set => this.button_0.TextAlign = value;
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public virtual Image Image
  {
    get => this.button_0.Image;
    set => this.button_0.Image = value;
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public virtual ContentAlignment ImageAlign
  {
    get => this.button_0.ImageAlign;
    set => this.button_0.ImageAlign = value;
  }

  [Browsable(true)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public virtual DialogResult DialogResult
  {
    get => this.button_0.DialogResult;
    set => this.button_0.DialogResult = value;
  }

  public void PerformClick() => this.button_0.PerformClick();

  public void NotifyDefault(bool value) => this.button_0.NotifyDefault(value);

  public event SubButtonItemEventHandler Click
  {
    add => this.method_0(value);
    remove => this.method_1(value);
  }

  protected virtual void OnClick(SubButtonItemEventArgs e)
  {
    if (e.ButtonItem != null)
      e.ButtonItem.InvokeItemClick(EventArgs.Empty);
    // ISSUE: reference to a compiler-generated field
    if (this.subButtonItemEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.subButtonItemEventHandler_0((object) this, e);
  }

  internal void method_2(SubButtonItemEventArgs subButtonItemEventArgs_0)
  {
    this.OnClick(subButtonItemEventArgs_0);
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (this.buttonMultiSelectionMode_0 == ButtonMultiSelectionMode.InvokeFirstAction)
    {
      if ((this.subButtonItemCollection_0 == null ? 0 : (this.subButtonItemCollection_0.Count > 0 ? 1 : 0)) != 0)
        this.OnClick(new SubButtonItemEventArgs(this.subButtonItemCollection_0[0]));
      else
        this.OnClick(new SubButtonItemEventArgs((SubButtonItem) null));
    }
    else
      this.method_4(sender, e);
  }

  internal void method_4(object sender, EventArgs e)
  {
    if ((this.subButtonItemCollection_0 == null ? 0 : (this.subButtonItemCollection_0.Count > 0 ? 1 : 0)) == 0)
      return;
    this.contextMenu_0.MenuItems.Clear();
    foreach (SubButtonItem subButtonItem in this.subButtonItemCollection_0)
    {
      subButtonItem.Owner = this;
      this.contextMenu_0.MenuItems.Add(subButtonItem.menuItem_0);
    }
    this.contextMenu_0.Show((Control) this.button_0, new Point(0, this.button_0.Height));
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public SubButtonItemCollection ButtonsItems
  {
    get => this.subButtonItemCollection_0;
    set => this.subButtonItemCollection_0 = value;
  }

  [DefaultValue(ButtonMultiSelectionMode.InvokeFirstAction)]
  public ButtonMultiSelectionMode Mode
  {
    get => this.buttonMultiSelectionMode_0;
    set => this.buttonMultiSelectionMode_0 = value;
  }
}
