// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleHorVerCutV3
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

public class F_MarbleHorVerCutV3 : Form
{
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_finishsafedis;
  public buCheckBox chk_finishzigzag;
  public buSpin spn_finishrapiddis;
  internal buTab \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  public buSpin spn_roughsafedis;
  public buSpin spn_roughrapiddis;
  public buSpin spn_roughsurfoffset;
  public buCheckBox chk_rougjzigzag;
  public buSpin spn_roughstepang;
  public buSpin spn_roughminZ;
  public buSpin spn_finishcoffset;
  public buSpin spn_roughcoffset;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buCheckBox chk_finishperpendicularA;
  public buSpin spn_finishbwdcuttingfeed;
  public buSpin spn_finishfwdcutfeed;
  public buSpin spn_finishplungefeed;
  public buCheckBox chk_roughperpendicularA;
  public buSpin spn_roughbwdcuttingfeed;
  public buSpin spn_roughfwdcuttingfeed;
  public buSpin spn_roughplungefeed;
  public buSpin spn_roughleadout;
  public buSpin spn_roughleadin;
  public buSpin spn_finishleadout;
  public buSpin spn_finishleadin;
  public buSpin spn_finishverticaldevidedis;
  public buSpin spn_roughverticaldevidelen;
  public buCheckBox chk_finishreverseC;
  public buCheckBox chk_roughreverseC;
  public buSpin spn_roughtopoffet;
  public buSpin spn_roughoutsideoffset;
  public buSpin spn_roughinsideoffset;
  public buSpin spn_roughbottomoffset;
  public buSpin spn_finishoutsideoffset;
  public buSpin spn_finishinsideoffset;
  public buSpin spn_finishbottomoffset;
  public buSpin spn_finishtopoffet;
  public buSpin spn_roughzdownstep;
  public buSpin spn_roughstepoverXY;
  internal buLabel \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal TabPage \u0003;
  internal buLabel \u0004;
  public buSpin spn_offsetedgeoffsey;
  public buCheckBox chk_offsetcutedges;
  public buCheckBox chk_offsetcutoutside;
  public buCheckBox chk_offsetcutinside;
  public buSpin spn_offsetzdownstep;
  public buSpin spn_offsetoutsideoffset;
  public buSpin spn_offsetinsideoffset;
  public buCheckBox chk_offsetreverseC;
  public buSpin spn_offsetleadoutangle;
  public buSpin spn_offsetleadinangle;
  public buSpin spn_offsetbackwardcuttingspeed;
  public buSpin spn_offsetforwardcuttingspeed;
  public buSpin spn_offsetplungefeed;
  public buSpin spn_offsetsafedistance;
  public buSpin spn_offsetstepangle;
  public buSpin spn_offsetminZHeight;
  public buCheckBox chk_offsetzigzag;
  public buSpin spn_offsetAAngle;
  public buCheckBox chk_finishmoveupsafe;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleProfileCutPars varProfileCut;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_finishsurfoffset;
  public buSpin spn_finishminZ;
  public buSpin spn_finishstepdistance;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_finishsafedis;
  public buCheckBox chk_finishzigzag;
  public buSpin spn_finishrapiddis;
  internal buTab \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  public buSpin spn_roughsafedis;
  public buSpin spn_roughrapiddis;
  public buSpin spn_roughsurfoffset;
  public buCheckBox chk_rougjzigzag;
  public buSpin spn_roughminZ;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buCheckBox chk_finishperpendicularA;
  public buSpin spn_finishbwdcuttingfeed;
  public buSpin spn_finishfwdcutfeed;
  public buSpin spn_finishplungefeed;
  public buCheckBox chk_roughperpendicularA;
  public buSpin spn_roughbwdcuttingfeed;
  public buSpin spn_roughfwdcuttingfeed;
  public buSpin spn_roughplungefeed;
  public buSpin spn_finishverticaldevide;
  public buSpin spn_finishleadout;
  public buSpin spn_finishleadin;
  public buSpin spn_roughverticaldevidelen;
  public buSpin spn_roughleadout;
  public buSpin spn_roughleadin;
  public buSpin spn_roughstepoverXY;
  public buSpin spn_roughzdownstep;
  internal buLabel \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  public buSpin spn_roughoutsideoffset;
  public buSpin spn_roughinsideoffset;
  public buSpin spn_roughbottomoffset;
  public buSpin spn_roughtopoffet;
  public buCheckBox chk_roughreverseC;
  public buCheckBox chk_finishmoveupsafe;
  public buSpin spn_finishoutsideoffset;
  public buSpin spn_finishinsideoffset;
  public buSpin spn_finishbottomoffset;
  public buSpin spn_finishtopoffet;
  public buCheckBox chk_finishreverseC;
  public buCheckBox chk_roughmoveupsafedis;
  internal TabPage \u0003;
  public buSpin spn_offsetAAngle;
  public buCheckBox chk_offsetzigzag;
  public buSpin spn_offsetedgeoffsey;
  public buCheckBox chk_offsetcutedges;
  public buCheckBox chk_offsetcutoutside;
  public buCheckBox chk_offsetcutinside;
  public buSpin spn_offsetzdownstep;
  public buSpin spn_offsetoutsideoffset;
  public buSpin spn_offsetinsideoffset;
  public buCheckBox chk_offsetreverseC;
  public buSpin spn_offsetleadoutangle;
  public buSpin spn_offsetleadinangle;
  public buSpin spn_offsetbackwardcuttingspeed;
  public buSpin spn_offsetforwardcuttingspeed;
  public buSpin spn_offsetplungefeed;
  public buSpin spn_offsetsafedistance;
  public buSpin spn_offsetstepangle;
  public buSpin spn_offsetminZHeight;

  static F_MarbleHorVerCutV3() => F_MarbleProfileCurveCam.Captions = new List<string>();

  public F_MarbleHorVerCutV3()
  {
    ((F_MarbleProfileCam) this).PropertiesForm = new FormProperties();
    ((F_MarbleProfileCam) this).BackupFolder = "";
    ((F_MarbleProfileCam) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleBackupLoad) this);
  }

  public void Init()
  {
    ((F_MarbleProfileCam) this).PropertiesForm.Inited = false;
    if (((F_MarbleProfileCam) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleProfileCam) this).PropertiesForm.Height;
    if (((F_MarbleProfileCam) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleProfileCam) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleProfileCam) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleProfileCam) this).PropertiesForm.FormPosition;
    this.FillList();
    this.LoadLanguage();
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileCam) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileCam) this).\u0001.Text = buLangTranslate.preDef.BackUp;
      ((F_MarbleProfileCam) this).\u0001.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
    }
  }

  public void FillList()
  {
    ((F_MarbleProfileCam) this).\u0001.Items.Clear();
    List<string> Paths = new List<string>();
    buFile5.bunesting.getPathsInPath(AppPath.Backup, ref Paths);
    for (int index = 0; index <= Paths.Count - 1; ++index)
      ((F_MarbleProfileCam) this).\u0001.Items.Add((object) Paths[index]);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
