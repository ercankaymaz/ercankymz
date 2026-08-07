// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.GCode.F_FoamGCodeConverter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Kinematic;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.GCode;

public class F_FoamGCodeConverter : Form
{
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Label \u0001;
  internal TextBox \u0001;
  internal TextBox \u0002;
  internal Label \u0002;
  internal TextBox \u0003;
  internal Label \u0003;
  internal Button \u0001;
  internal Button \u0002;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal CheckBox \u0003;
  internal Label \u0007;
  internal CheckBox \u0004;
  internal Button \u0003;
  internal TextBox \u0004;
  internal Label \u0008;
  internal TextBox \u0005;
  internal Label \u000E;
  internal Label \u000F;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0010;
  internal Label \u0011;
  internal CheckBox \u0005;
  internal Label \u0012;
  internal ComboBox \u0001;
  public static byte f002F86;
  public FormProperties PropertiesForm;
  public static List<string> Captions;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_HolesTemp) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_KinematicBasic) this);
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = ((F_HolesTemp) this).PathKinematic;
    saveFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buGCodeCreate.SaveKinematicFile(saveFileDialog.FileName, ((F_HolesTemp) this).KinematicSettings);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_KinematicBasic) this);
    ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_HolesTemp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = ((F_HolesTemp) this).PathKinematic;
    openFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
    openFileDialog.Multiselect = false;
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    ((F_HolesTemp) this).PathKinematic = buFile.GetPath(openFileDialog.FileName);
    buGCodeCreate.OpenKinemticFile(openFileDialog.FileName, ref ((F_HolesTemp) this).KinematicSettings);
    ((F_HolesTemp) this).LoadedKinematicFileName = buFile.getFileName(openFileDialog.FileName);
    ((F_HolesTemp) this).LoadedKinematicFullFileName = openFileDialog.FileName;
    ((F_HolesTemp) this).Init();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_HolesTemp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_HolesTemp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamGCodeConverter() => F_HolesTemp.Captions = new List<string>();

  public F_FoamGCodeConverter()
  {
    ((F_HolesTemp) this).\u0001 = 0.0;
    ((F_HolesTemp) this).\u0001 = "";
    ((F_HolesTemp) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((Form1) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1) => \u0007.\u0001.\u0001((Form1) this);
}
