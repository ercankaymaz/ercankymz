// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleWarnings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Material;
using buEyeBaseVer5.Forms.MortiseTenon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleWarnings : Form
{
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleBottomPanelV1) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleBottomPanelV1) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleBottomPanelV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleBottomPanelV1) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleCoordinatesV2) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_SlotNoDepth) this);
        ((F_MarbleBottomPanelV1) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleBottomPanelV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleBottomPanelV1) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleCoordinatesV2) this).btn_cancel.Name | control2.Name == ((F_MarbleCoordinatesV2) this).\u0001.Name))
        return;
      ((F_MarbleBottomPanelV1) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleBottomPanelV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleBottomPanelV1) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCoordinatesV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCoordinatesV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleWarnings() => F_MarbleBottomPanelV1.Captions = new List<string>();

  public F_MarbleWarnings()
  {
    ((F_MarbleCoordinatesV2) this).PropertiesForm = new FormProperties();
    ((F_MarbleCoordinatesV2) this).MaterialFiles = new List<string>();
    ((F_MarbleCoordinatesV2) this).selectedMaterialName = "";
    ((F_MarbleCoordinatesV2) this).pathString = Application.StartupPath;
    ((F_MarbleCoordinatesV2) this).\u0001 = new Timer();
    ((F_MarbleCoordinatesV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MaterialsList) this);
    ((F_MarbleCoordinatesV2) this).\u0001.Tick += new EventHandler(this.\u0002);
  }

  public void Init()
  {
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = false;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCoordinatesV2) this).PropertiesForm.Height;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCoordinatesV2) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCoordinatesV2) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCoordinatesV2) this).PropertiesForm.FormPosition;
    List<string> Files1 = new List<string>();
    buFile5.bunesting.GetFilesInDirectory(((F_MarbleCoordinatesV2) this).pathString, ".png", ref Files1);
    ((F_MarbleCoordinatesV2) this).MaterialFiles.AddRange((IEnumerable<string>) Files1);
    List<string> Files2 = new List<string>();
    buFile5.bunesting.GetFilesInDirectory(((F_MarbleCoordinatesV2) this).pathString, ".jpg", ref Files2);
    ((F_MarbleCoordinatesV2) this).MaterialFiles.AddRange((IEnumerable<string>) Files2);
    ((F_MarbleCoordinatesV2) this).\u0001.Interval = 100;
    ((F_MarbleCoordinatesV2) this).\u0001.Enabled = true;
    \u0007.\u0001.\u0001((F_MaterialsList) this);
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = false;
    ((F_MarbleCoordinatesV2) this).\u0001.Enabled = false;
    ((F_MarbleCoordinatesV2) this).\u0001.Items.Clear();
    int num = -1;
    for (int index = 0; index <= ((F_MarbleCoordinatesV2) this).MaterialFiles.Count - 1; ++index)
    {
      string withoutExtension = buFile5.bunesting.getFileNameWithoutExtension(((F_MarbleCoordinatesV2) this).MaterialFiles[index]);
      if (withoutExtension.Length > 0)
        ((F_MarbleCoordinatesV2) this).\u0001.Items.Add((object) withoutExtension);
      if (((F_MarbleCoordinatesV2) this).MaterialFiles[index] == ((F_MarbleCoordinatesV2) this).selectedMaterialName)
        num = index;
    }
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = true;
    if (num < 0)
      return;
    ((F_MarbleCoordinatesV2) this).\u0001.SelectedIndex = num;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = false;
    ((F_MarbleCoordinatesV2) this).selectedMaterialName = ((F_MarbleCoordinatesV2) this).MaterialFiles[((F_MarbleCoordinatesV2) this).\u0001.SelectedIndex];
    ((F_MarbleCoordinatesV2) this).\u0001.Image = (Image) new Bitmap(((F_MarbleCoordinatesV2) this).selectedMaterialName);
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = true;
  }
}
