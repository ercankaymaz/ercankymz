// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolSawMilling
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSawMilling : Form
{
  internal buLabel \u0013;
  internal buLabel \u0014;
  internal buLabel \u0015;
  internal buLabel \u0016;
  internal buLabel \u0017;
  internal buLabel \u0018;
  public buSpin spn_matsawstraightcuttingsBwdspeed;
  internal buLabel \u0019;
  public buSpin spn_matsawcircularcutBwdspeed;
  internal buLabel \u001A;
  public buSpin spn_matsawplungefirstspeed;
  internal buLabel \u001B;
  internal buLabel \u001C;
  internal buLabel \u001D;
  public buSpin spn_matmillingplungefirstspeed;
  public buSpin spn_matmillingheadplungefirstspeed;
  internal buLabel \u001E;
  internal buLabel \u001F;
  internal buLabel \u007F;
  public buButton btn_sequence;
  internal Panel \u0003;
  internal RadioButton \u0013;
  internal buLabel \u0080;
  internal RadioButton \u0014;
  internal buLabel \u0081;
  public buSpin spn_millingsafedistance;
  public buSpin spn_millingrapiddistance;
  internal buLabel \u0082;
  public buSpin spn_millingheadsafedistance;
  public buSpin spn_millingheadrapiddistance;
  internal TabPage \u0004;
  internal Panel \u0004;
  public buCheckBox chk_millingcuttings;
  public buCheckBox chk_cornercuttingbyhole;
  public buCheckBox chk_cornercuttigbymilling;
  public buCheckBox chk_sawcuttings;

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_MarbleCamSettings) this).SelectedRow = obj1.RowIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCamSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolSawMilling() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleToolSawMilling()
  {
    ((F_MarbleCamSettings) this).Sequences = new List<MarbleOperationSequence>();
    ((F_MarbleCamSettings) this).PropertiesForm = new FormProperties();
    ((F_MarbleCamSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCuttingSequence) this);
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCamSettings) this).\u0001.Text = buLangTranslate.preDef.Sequence;
      ((F_MarbleCamSettings) this).\u0001.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleCamSettings) this).\u0002.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
    }
  }

  public string AddItem(MarbleOperationSequence OP)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCamSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCamSettings) this).Sequences.Clear();
    for (int index = 0; index <= ((F_MarbleCamSettings) this).\u0002.Items.Count - 1; ++index)
    {
      string[] strArray = ((F_MarbleCamSettings) this).\u0002.Items[index].ToString().Split('-');
      if ((strArray == null ? 0 : (strArray.Length >= 2 ? 1 : 0)) != 0)
      {
        int num = int.Parse(strArray[1]);
        if (num >= 0)
          ((F_MarbleCamSettings) this).Sequences.Add((MarbleOperationSequence) num);
      }
    }
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleCamSettings) this).\u0003.Name && ((F_MarbleCamSettings) this).\u0001.SelectedIndex >= 0)
      ((F_MarbleCamSettings) this).\u0001.Items.RemoveAt(((F_MarbleCamSettings) this).\u0001.SelectedIndex);
    if (control.Name == ((F_MarbleCamSettings) this).\u0004.Name && ((F_MarbleCamSettings) this).\u0001.SelectedIndex >= 0)
      ((F_MarbleCamSettings) this).\u0002.Items.Add(((F_MarbleCamSettings) this).\u0001.Items[((F_MarbleCamSettings) this).\u0001.SelectedIndex]);
    if (control.Name == ((F_MarbleCamSettings) this).\u0006.Name && ((F_MarbleCamSettings) this).\u0002.SelectedIndex >= 1)
    {
      int selectedIndex = ((F_MarbleCamSettings) this).\u0002.SelectedIndex;
      string str = ((F_MarbleCamSettings) this).\u0002.Items[((F_MarbleCamSettings) this).\u0002.SelectedIndex].ToString();
      ((F_MarbleCamSettings) this).\u0002.Items.RemoveAt(((F_MarbleCamSettings) this).\u0002.SelectedIndex);
      ((F_MarbleCamSettings) this).\u0002.Items.Insert(selectedIndex - 1, (object) str);
    }
    if (!(control.Name == ((F_MarbleCamSettings) this).\u0005.Name) || ((F_MarbleCamSettings) this).\u0002.SelectedIndex >= ((F_MarbleCamSettings) this).\u0002.Items.Count - 1)
      return;
    int selectedIndex1 = ((F_MarbleCamSettings) this).\u0002.SelectedIndex;
    string str1 = ((F_MarbleCamSettings) this).\u0002.Items[((F_MarbleCamSettings) this).\u0002.SelectedIndex].ToString();
    ((F_MarbleCamSettings) this).\u0002.Items.RemoveAt(((F_MarbleCamSettings) this).\u0002.SelectedIndex);
    ((F_MarbleCamSettings) this).\u0002.Items.Insert(selectedIndex1 + 1, (object) str1);
  }
}
