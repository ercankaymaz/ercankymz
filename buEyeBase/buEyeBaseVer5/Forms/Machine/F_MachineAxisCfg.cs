// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Machine.F_MachineAxisCfg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using buEyeBaseVer5.Forms.Marble;
using dummy_ptr;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Machine;

public class F_MachineAxisCfg : Form
{
  public buSpin spn_chamfercuttingvel;
  internal buLabel \u0007;
  public buSpin spn_engravesafedis;
  public buSpin spn_engraverapiddis;
  public buSpin spn_engraveplungevel;
  public buSpin spn_engravecuttingvel;
  internal buLabel \u0008;
  public buSpin spn_textengravesafedis;
  public buSpin spn_textengraverapiddis;
  public buSpin spn_textengraveplungevel;
  public buSpin spn_textengravecuttingvel;
  internal buLabel \u000E;
  public buSpin spn_trochoidalsafedis;
  public buSpin spn_trochoidalrapiddis;
  public buSpin spn_trochoidalplungevel;
  public buSpin spn_trochoidalcuttingvel;
  public buSpin spn_contoursteplen;
  public buSpin spn_centersteplen;
  public buCheckBox chk_contouroffsetcenter;
  public buCheckBox chk_contouroffsetoutside;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSawMillingContourSetting) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSawMillingContourSetting) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MachineAxisCfg() => F_MarbleSawMillingContourSetting.Captions = new List<string>();

  public F_MachineAxisCfg()
  {
    ((F_MarbleMillingCamSetting) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleVerticalCut) this);
  }

  public void Init() => this.LoadLanguage();

  public void LoadLanguage()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMillingCamSetting) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMillingCamSetting) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MachineAxisCfg() => F_MarbleMillingCamSetting.Captions = new List<string>();
}
