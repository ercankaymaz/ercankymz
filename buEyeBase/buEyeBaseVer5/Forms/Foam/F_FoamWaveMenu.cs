// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamWaveMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Holes;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamWaveMenu : Form
{
  public Button btn_oldhor;
  public Button btn_newhor;
  public Button btn_newplane;
  public RadioButton radio_vertical;
  public RadioButton radio_horizontal;
  public RadioButton radio_plane;
  public CheckBox chk_copynew;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  public static byte f002FB6;
  public FormProperties PropertiesForm;

  private void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((F_HolesTemp) this).textCtrl1.Text = "";
    ((F_HolesTemp) this).\u0002.Enabled = false;
  }

  internal void \u0001([In] object obj0, [In] MouseEventArgs obj1)
  {
    ((F_HolesTemp) this).\u0002.Enabled = true;
  }

  internal void \u0002([In] object obj0, [In] MouseEventArgs obj1)
  {
    ((F_HolesTemp) this).\u0002.Enabled = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((F_HolesTemp) this).\u0002.Enabled = false;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    if (obj1.KeyCode == Keys.Escape)
      ((F_FoamSlicesList) this).\u0001((object) ((F_HolesTemp) this).\u0011, (EventArgs) null);
    if (obj1.KeyCode != Keys.Return)
      return;
    ((F_FoamSlicesList) this).\u0001((object) ((F_HolesTemp) this).\u0012, (EventArgs) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_HolesTemp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_HolesTemp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m0014C2();

  public F_FoamWaveMenu()
  {
    ((F_HolesTemp) this).PropertiesForm = new FormProperties();
    ((F_HolesTemp) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_CabinetCycle) this);
  }

  public void Init()
  {
    ((F_HolesTemp) this).PropertiesForm.Inited = false;
    if (((F_HolesTemp) this).PropertiesForm.Height > 10)
      this.Height = ((F_HolesTemp) this).PropertiesForm.Height;
    if (((F_HolesTemp) this).PropertiesForm.Width > 10)
      this.Width = ((F_HolesTemp) this).PropertiesForm.Width;
    this.TopMost = ((F_HolesTemp) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_HolesTemp) this).PropertiesForm.FormPosition;
    ((F_FoamSlices) this).ControlUpdate();
    ((F_FoamSlices) this).LoadLanguage();
    ((F_HolesTemp) this).PropertiesForm.Result = DialogResult.None;
    ((F_HolesTemp) this).PropertiesForm.Inited = true;
  }
}
