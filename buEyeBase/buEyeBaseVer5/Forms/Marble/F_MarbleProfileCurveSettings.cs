// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileCurveSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleProfileCurveSettings : Form
{
  public buButton btn_close;
  public buGround buGround1;
  public buLabel lbl_total;
  public buLabel lbl_totalcounthor;
  public buLabel lbl_totallenhor;
  public buButton btn_save;
  public buButton btn_open;
  public buButton btn_endposHor;
  public buButton btn_startposHor;
  public buButton btn_downHor;
  public buButton btn_upHor;
  public buButton btn_okhor;
  public buButton btn_cancel;
  public buLabel lbl_length;
  public buLabel lbl_5;
  public buLabel lbl_4;
  public buLabel lbl_3;
  public buLabel lbl_2;
  public buLabel lbl_1;
  public buLabel lbl_ea;
  public buLabel lbl_sa;
  public buLabel lbl_count;
  public Panel pnl_hor_viewport;
  public buLabel lbl_7;
  public buSpin spn_itemEA7;
  public buSpin spn_itemSA7;
  public buSpin spn_itemcount7;
  public buSpin spn_itemlen7;
  public buLabel lbl_6;
  public buSpin spn_itemEA6;
  public buSpin spn_itemSA6;
  public buSpin spn_itemcount6;
  public buSpin spn_itemlen6;
  public buCheckBox chk_horizotalvertical;
  public buCheckBox chk_verticalhorizontal;
  public buCheckBox chk_onlyhorizontal;
  public buCheckBox chk_onlyvertical;
  public Panel pnl_base;
  public buSpin spn_cvalHor;
  public buCheckBox chk_FromvalueHor;
  public buButton btn_clearallHor;
  public buSpin spn_x;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ItemCutCamParameters) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ItemCutCamParameters) this).Properties.Result = DialogResult.Cancel;
    if (((F_ItemCutCamParameters) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ItemCutCamParameters) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_ItemCutCamParameters) this).btn_ok.Name)
      {
        if (!((F_MarbleHorizontalCut) this).\u0002.Checked & !((F_MarbleHorizontalCut) this).\u0001.Checked)
        {
          buString.MessageBoxWarning(((F_ItemCutCamParameters) this).strMessageRoughtFinishSelect);
          return;
        }
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleProfileCut) this);
        ((F_ItemCutCamParameters) this).Properties.Result = DialogResult.OK;
        if (((F_ItemCutCamParameters) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ItemCutCamParameters) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_ItemCutCamParameters) this).btn_cancel.Name))
        return;
      ((F_ItemCutCamParameters) this).Properties.Result = DialogResult.Cancel;
      if (((F_ItemCutCamParameters) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ItemCutCamParameters) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_ItemCutCamParameters) this).Properties.Inited)
      ;
  }

  internal void \u0001([In] object obj0, [In] PaintEventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ItemCutCamParameters) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ItemCutCamParameters) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleProfileCurveSettings() => F_ItemCutCamParameters.Captions = new List<string>();

  public F_MarbleProfileCurveSettings()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorizontalCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorizontalCut) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
