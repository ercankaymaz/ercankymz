// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCam3D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Material;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.MortiseTenon;
using buEyeBaseVer5.Forms.Password;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCam3D : Form
{
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal DataGridView \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal TextBox \u0001;
  internal Label \u0002;
  internal TextBox \u0002;
  internal ImageList \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal ToolStripMenuItem \u0002;
  internal ToolStripSeparator \u0001;
  internal ToolStripMenuItem \u0003;
  internal ContextMenuStrip \u0002;
  internal ToolStripMenuItem \u0004;
  internal ToolStripMenuItem \u0005;
  internal ToolStripSeparator \u0002;
  internal ToolStripMenuItem \u0006;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal Button \u0008;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal ToolStripMenuItem \u0007;
  public CheckBox chk_preview;
  internal ToolStripSeparator \u0003;
  internal ToolStripMenuItem \u0008;
  internal Label \u0003;
  internal Panel \u0003;
  internal ToolStripSeparator \u0004;
  internal TextBox \u0003;
  internal Label \u0004;
  internal TextBox \u0004;
  internal Label \u0005;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_SlotNoDepth) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SlotNoDepth) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SlotNoDepth) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SlotNoDepth) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCam3D() => F_SlotNoDepth.Captions = new List<string>();

  public F_MarbleCam3D()
  {
    ((F_MaterialsList) this).PropertiesForm = new FormProperties();
    ((F_MaterialsList) this).Caption = "";
    ((F_MaterialsList) this).CheckNumeric = true;
    ((F_MaterialsList) this).ShowInitValue = true;
    ((F_MaterialsList) this).PasswordChar = '*';
    ((F_MaterialsList) this).MaxValue = 0.0;
    ((F_MaterialsList) this).MinValue = 0.0;
    ((F_MaterialsList) this).\u0001 = false;
    ((F_MaterialRect3D) this).\u0001 = "";
    ((F_MaterialRect3D) this).\u0002 = "";
    ((F_MaterialRect3D) this).\u0001 = new Timer();
    ((F_MaterialRect3D) this).\u0002 = new Timer();
    ((F_MaterialRect3D) this).\u0003 = new Timer();
    ((F_MaterialRect3D) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_PasswordV1) this);
    ((F_MaterialRect3D) this).\u0001 = new Timer();
    ((F_MaterialRect3D) this).\u0001.Tick += new EventHandler(this.\u0003);
    ((F_MaterialRect3D) this).\u0002 = new Timer();
    ((F_MaterialRect3D) this).\u0002.Tick += new EventHandler(this.\u0004);
    ((F_MaterialRect3D) this).\u0003 = new Timer();
    ((F_MaterialRect3D) this).\u0003.Tick += new EventHandler(this.\u0002);
  }

  public void ShowDialog(string Value)
  {
    ((F_MaterialsList) this).\u0001 = false;
    ((F_MaterialRect3D) this).\u0001 = Value;
    ((F_MaterialRect3D) this).textCtrl1.Text = Value;
    ((F_MaterialRect3D) this).textCtrl1.Invalidate();
    ((F_MaterialRect3D) this).textCtrl1.Display.SelectionColor = ((F_MaterialRect3D) this).textCtrl1.Display.BackColor;
    ((F_MaterialRect3D) this).textCtrl1.PasswordChar = ((F_MaterialsList) this).PasswordChar;
    ((F_MaterialRect3D) this).\u0001.Interval = 1000;
    ((F_MaterialRect3D) this).\u0002.Interval = 1500;
    ((F_MaterialRect3D) this).\u0003.Interval = 100;
    ((F_MaterialRect3D) this).\u0003.Enabled = true;
    if (((F_MaterialsList) this).Caption.Length > 0)
      ((F_MaterialRect3D) this).\u0001.Text = ((F_MaterialsList) this).Caption;
    int num = (int) this.ShowDialog();
  }

  public void ShowDialog(string Value, IWin32Window owner)
  {
    ((F_MaterialsList) this).\u0001 = false;
    ((F_MaterialRect3D) this).\u0001 = Value;
    ((F_MaterialRect3D) this).textCtrl1.Text = Value;
    ((F_MaterialRect3D) this).textCtrl1.Display.SelectionColor = ((F_MaterialRect3D) this).textCtrl1.BackColor;
    ((F_MaterialRect3D) this).textCtrl1.PasswordChar = ((F_MaterialsList) this).PasswordChar;
    ((F_MaterialRect3D) this).\u0001.Interval = 1000;
    ((F_MaterialRect3D) this).\u0002.Interval = 1500;
    ((F_MaterialRect3D) this).\u0003.Interval = 100;
    ((F_MaterialRect3D) this).\u0003.Enabled = true;
    if (((F_MaterialsList) this).Caption.Length > 0)
      ((F_MaterialRect3D) this).\u0001.Text = ((F_MaterialsList) this).Caption;
    int num = (int) this.ShowDialog(owner);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MaterialsList) this).Value = ((F_MaterialRect3D) this).textCtrl1.Text;
    if (((F_MaterialsList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Close();
    if (((F_MaterialsList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MaterialRect3D) this).textCtrl1.SelectAll();
    ((F_MaterialsList) this).\u0001 = true;
    ((F_MaterialRect3D) this).\u0003.Enabled = false;
  }

  private void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MaterialRect3D) this).textCtrl1.Text = ((F_MaterialRect3D) this).\u0002;
    ((F_MaterialRect3D) this).\u0001.Enabled = false;
  }

  private void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MaterialRect3D) this).textCtrl1.Text = "";
    ((F_MaterialRect3D) this).\u0002.Enabled = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
