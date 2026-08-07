// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.DropDown
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DropDown : Form
{
  internal Point point_0 = new Point(0, 0);
  internal Panel panel_0;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  internal Control parentControl = (Control) null;
  internal Control innerControl = (Control) null;
  private DropDownFlags dropDownFlags_0 = DropDownFlags.CloseOnEscape | DropDownFlags.CloseOnEnter;
  private bool bool_0 = false;

  public DropDown() => Class39.smethod_770(this);

  public DropDown(Control innerControl, Control parentControl, Form owner)
    : this()
  {
    this.Owner = owner;
    this.innerControl = innerControl;
    this.parentControl = parentControl;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  public Control ParentControl
  {
    get => this.parentControl;
    set => this.parentControl = value;
  }

  public Control InnerControl
  {
    get => this.innerControl;
    set => this.innerControl = value;
  }

  internal void method_0(object sender, LayoutEventArgs e)
  {
    this.SuspendLayout();
    Class39.smethod_346(this);
    this.ResumeLayout(false);
  }

  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    if ((this.dropDownFlags_0 & DropDownFlags.CloseOnEscape) == DropDownFlags.CloseOnEscape && keyData == Keys.Escape)
    {
      this.DialogResult = DialogResult.Cancel;
      this.CloseDropDown();
    }
    if ((this.dropDownFlags_0 & DropDownFlags.CloseOnEnter) == DropDownFlags.CloseOnEnter && keyData == Keys.Return)
    {
      this.DialogResult = DialogResult.OK;
      this.CloseDropDown();
    }
    return base.ProcessCmdKey(ref msg, keyData);
  }

  public DropDownFlags DropDownFlags
  {
    get => this.dropDownFlags_0;
    set => this.dropDownFlags_0 = value;
  }

  internal void method_1(object sender, EventArgs e) => this.CloseDropDown();

  public void ShowDropDown()
  {
    if (this.bool_0)
      return;
    this.bool_0 = true;
    if (this.InnerControl == null)
      throw new ApplicationException("InnerControl is null");
    if (this.ParentControl == null)
      throw new ApplicationException("ParentControl is null");
    if (this.Owner == null)
      throw new ApplicationException("Owner is null");
    this.OnDropDownOpen(EventArgs.Empty);
  }

  public void CloseDropDown()
  {
    if (!this.bool_0)
      return;
    this.OnDropDownClosed(EventArgs.Empty);
    this.bool_0 = false;
  }

  protected virtual void OnDropDownOpen(EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }
    this.panel_0.Controls.Add(this.innerControl);
    try
    {
      Class39.smethod_346(this);
      this.Show();
      while (this.bool_0)
      {
        Application.DoEvents();
        Thread.Sleep(1);
      }
    }
    finally
    {
      this.panel_0.Controls.Remove(this.innerControl);
    }
  }

  protected virtual void OnDropDownClosed(EventArgs e)
  {
    this.Owner.Activate();
    this.Hide();
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) this, e);
  }

  public event EventHandler DropDownOpen;

  public event EventHandler DropDownClosed;
}
