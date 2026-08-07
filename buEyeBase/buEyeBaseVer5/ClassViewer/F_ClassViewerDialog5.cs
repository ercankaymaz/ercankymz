// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ClassViewer.F_ClassViewerDialog5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.ClassViewer;

public class F_ClassViewerDialog5 : Form
{
  internal buGroup \u0083;
  public buCheckBox chk_userdefinescurves;
  public buCheckBox chk_boundrycurvesmachiningsurfacegeodesic;
  public buCheckBox chk_cointainmentgeodesic;
  public buCheckBox chk_medialaxisofcontainmentgeodesic;
  public buCheckBox chk_circleatcentercontainmentgeodesic;
  internal buGroup \u0084;
  public buCheckBox chk_paralleltomultiplecurvegeodesic;
  public buCheckBox chk_morphbetweentwocurvegeodesic;
  internal buGroup \u0086;
  public buCheckBox chk_automaticcontainmentgeodesic;
  public buCheckBox chk_userdefinecontainmentgeodesic;
  internal buGroup \u0087;

  public void Init()
  {
    ((F_CamSettings1) this).Properties.Inited = false;
    if (((F_CamSettings1) this).Properties.Height > 10)
      this.Height = ((F_CamSettings1) this).Properties.Height;
    if (((F_CamSettings1) this).Properties.Width > 10)
      this.Width = ((F_CamSettings1) this).Properties.Width;
    this.TopMost = ((F_CamSettings1) this).Properties.TopMost;
    this.StartPosition = ((F_CamSettings1) this).Properties.FormPosition;
    ((F_CamSettings1) this).Properties.Result = DialogResult.None;
    ((F_CamSettings1) this).Properties.Inited = true;
    this.LoadLangueage();
  }

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
      ((F_CamSettings1) this).FrontBack = CamFrontBackAll.Front;
    if (control2.Name == ((F_CamSettings1) this).\u0002.Name)
      ((F_CamSettings1) this).FrontBack = CamFrontBackAll.Back;
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

  static F_ClassViewerDialog5() => F_CamSettings1.Captions = new List<string>();
}
