// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ClassViewer.F_ClassViewerColorDialog5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.ClassViewer;

public class F_ClassViewerColorDialog5 : Form
{
  internal buGroup \u0081;
  public buCheckBox chk_levelgeodesic;
  public buCheckBox chk_regiongeodesic;
  internal buGroup \u0082;
  public buCheckBox chk_zigzaggeodesic;
  public buCheckBox chk_onewaygeodesic;
  public buCheckBox chk_spiralgeodesic;
  public buSpin spn_cuttolerancegeodesic;
  internal buLabel \u0002;
  public buSpin spn_cuttingspeedgeodesic;
  public buSpin spn_plungespeedgeodesic;
  public buSpin spn_safedistancegeodesic;
  public buSpin spn_rapiddistancegeodesic;

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_CamSettings1.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_CamSettings1) this).\u0001.Name)
      ((F_CamSettings1) this).FrontBackAll = CamFrontBackAll.Front;
    if (control2.Name == ((F_CamSettings1) this).\u0002.Name)
      ((F_CamSettings1) this).FrontBackAll = CamFrontBackAll.Back;
    if (control2.Name == ((F_CamSettings1) this).\u0003.Name)
      ((F_CamSettings1) this).FrontBackAll = CamFrontBackAll.All;
    ((F_CamSettings1) this).Properties.Result = DialogResult.OK;
    if (((F_CamSettings1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamSettings1) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamSettings1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamSettings1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ClassViewerColorDialog5() => F_CamSettings1.Captions = new List<string>();

  public F_ClassViewerColorDialog5()
  {
    ((F_CamSettings1) this).Properties = new FormProperties();
    ((F_CamSettings1) this).FrontBack = CamFrontBackAll.Front;
    ((F_CamSettings1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CamFrontBack) this);
  }
}
