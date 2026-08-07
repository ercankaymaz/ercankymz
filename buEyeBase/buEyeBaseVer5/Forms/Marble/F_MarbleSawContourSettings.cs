// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawContourSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawContourSettings : Form
{
  public buButton btn_toolacitve2;
  public buButton btn_toolacitve1;
  public TabPage tabPage_magazine;
  public buLabel lbl_tool1;
  public buLabel lbl_tool6;
  public buLabel lbl_tool5;
  public buLabel lbl_tool4;
  public buLabel lbl_tool3;
  public buLabel lbl_tool2;
  public buLabel lbl_toolspeed;
  public buLabel lbl_tooldia;
  public buLabel lbl_toollen;
  public static byte f002B7B;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public MarbleItemSettings Settings;
  public FormProperties PropertiesForm;
  private IContainer \u0001;

  static F_MarbleSawContourSettings() => F_MarbleVerticalCut.Captions = new List<string>();

  public F_MarbleSawContourSettings()
  {
    ((F_MarbleVerticalCut) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleHorizontalCutV2) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleVerticalCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleVerticalCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSawContourSettings() => F_MarbleVerticalCut.Captions = new List<string>();

  public F_MarbleSawContourSettings()
  {
    ((F_MarbleTools) this).Properties = new FormProperties();
    ((F_MarbleTools) this).varSettings = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_MarbleTools) this).strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";
    ((F_MarbleTools) this).strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";
    ((F_MarbleTools) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleLathe) this);
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleTools) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleTools) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleTools) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleTools) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
