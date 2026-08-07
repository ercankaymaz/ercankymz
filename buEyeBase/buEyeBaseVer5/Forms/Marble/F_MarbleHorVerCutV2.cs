// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleHorVerCutV2
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorVerCutV2 : Form
{
  internal buLabel \u0004;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleSawMillingPars varSawMilling;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_bottomoffset;
  public buSpin spn_topoffset;
  public buSpin spn_xyoffset;
  public buSpin spn_XYapproachStep;
  public buSpin spn_cuttngforwardfeed;
  public buSpin spn_plungefeed;
  public buSpin spn_zdownstep;
  public buSpin spn_safedistanceZ;
  public buCheckBox chk_zigzag;
  public buSpin spn_xysafedis;
  public buSpin spn_cuttngbackwardfeed;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal buLabel \u0001;
  public buSpin spn_curvedegree;
  internal RadioButton \u0004;
  public buButton btn_advanced;
  internal buPanel \u0001;
  internal buLabel \u0002;
  public buCheckBox chk_uselastcurvature;
  public buSpin spn_resolution;
  public buCheckBox chk_splinenebale;
  public buSpin spn_singlelayerdepth;
  public buCheckBox chk_singlelayer;
  public buButton btn_color;
  public buButton btn_closeadvanced;
  public buCheckBox chk_trimtoborder;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleSawMillingPars varSawMilling;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_safedis;
  public buCheckBox chk_zigzag;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  internal ImageList \u0002;
  public buSpin spn_stepdistance;
  public buSpin spn_cuttingfeed;
  public buSpin spn_plunfefeed;
  public buSpin spn_rapiddis;
  public buSpin spn_xyoffset;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleSurfaceCleanPars varSurfaceClean;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_safedis;
  public buCheckBox chk_zigzag;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  internal ImageList \u0002;
  public buSpin spn_stepdistance;
  public buSpin spn_cuttingfeed;
  public buSpin spn_plunfefeed;
  public buSpin spn_rapiddis;
  public buSpin spn_zoffset;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private string \u0001;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buLabel lbl_moves;
  public buButton btn_gofwd;
  public buButton btn_gobwd;
  public buButton btn_goleft;
  public buButton btn_goright;
  public buSpin spn_distance;
  public buButton btn_goleftbwd;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleProfileCam) this).\u0003.Name && ((F_MarbleProfileCam) this).\u0001.SelectedIndex >= 0)
    {
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.Init(buLangTranslate.preDef.BackUp, $"{buLangTranslate.preSentences.DoYouWantToDelete} [ {((F_MarbleProfileCam) this).\u0001.Items[((F_MarbleProfileCam) this).\u0001.SelectedIndex].ToString()} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result == DialogResult.Yes)
      {
        DirectoryInfo directoryInfo = new DirectoryInfo($"{AppPath.Backup}\\{((F_MarbleProfileCam) this).\u0001.Items[((F_MarbleProfileCam) this).\u0001.SelectedIndex].ToString()}");
        if (directoryInfo.Exists)
          directoryInfo.Delete(true);
        ((F_MarbleHorVerCutV3) this).FillList();
      }
    }
    if (control.Name == ((F_MarbleProfileCam) this).\u0002.Name)
      Process.Start(AppPath.Backup);
    if (control.Name == ((F_MarbleProfileCam) this).\u0004.Name && ((F_MarbleProfileCam) this).\u0001.SelectedIndex >= 0)
    {
      buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
      dialogMessageBoxYesNo.Init(buLangTranslate.preDef.BackUp, $"{buLangTranslate.preSentences.DoYouWantToRestoreFromBackup} [ {((F_MarbleProfileCam) this).\u0001.Items[((F_MarbleProfileCam) this).\u0001.SelectedIndex].ToString()} ]");
      int num = (int) dialogMessageBoxYesNo.ShowDialog();
      if (dialogMessageBoxYesNo.Result == DialogResult.Yes)
      {
        DirectoryInfo directoryInfo = new DirectoryInfo($"{AppPath.Backup}\\{((F_MarbleProfileCam) this).\u0001.Items[((F_MarbleProfileCam) this).\u0001.SelectedIndex].ToString()}");
        if (directoryInfo.Exists)
        {
          ((F_MarbleProfileCam) this).BackupFolder = directoryInfo.FullName;
          ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.OK;
          if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
            this.Dispose();
          if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
            this.Visible = false;
        }
      }
    }
    if (!(control.Name == ((F_MarbleProfileCam) this).\u0005.Name))
      return;
    string str1 = AppPath.MachineSettings + "\\Machine.prm";
    string str2 = $"{AppPath.Backup}\\{((F_MarbleProfileCam) this).\u0001.Items[((F_MarbleProfileCam) this).\u0001.SelectedIndex].ToString()}\\Machine.prm";
    string[] strArray = new string[2]{ str1, str2 };
    string arguments = $"{str1} {str2}";
    Process.Start(((marbleProfileCutPars) MarbleRuntimeSettings.varMarbleSettings).CompareProgramName, arguments);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleHorVerCutV2() => F_MarbleProfileCam.Captions = new List<string>();

  public F_MarbleHorVerCutV2()
  {
    ((F_MarbleProfileCam) this).\u0001 = "F_MarblePointerCmd";
    ((F_MarbleProfileCam) this).PropertiesForm = new FormProperties();
    ((F_MarbleProfileCam) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarblePointerCmd) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleProfileCam) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
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
    this.LoadLanguage();
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileCam) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileCam) this).ground_base.Text = $"{buLangTranslate.preDef.Pointer} {buLangTranslate.preDef.Command}";
      ((F_MarbleProfileCam) this).btn_pointerundo.Text = $"{buLangTranslate.preDef.Undo} {buLangTranslate.preDef.Add}";
      ((F_MarbleProfileCam) this).btn_pointerclosedraw.Text = $"{buLangTranslate.preDef.Drawing} {buLangTranslate.preDef.Close}";
      ((F_MarbleProfileCam) this).btn_pointeraddcircle.Text = $"{buLangTranslate.preDef.Cirlce} {buLangTranslate.preDef.Add}";
      ((F_MarbleProfileCam) this).btn_pointergostart.Text = $"{buLangTranslate.preDef.Go} {buLangTranslate.preDef.Start}";
      ((F_MarbleProfileCam) this).chk_pointerarcmode.Text = $"{buLangTranslate.preDef.Arc} {buLangTranslate.preDef.Mode}";
      ((F_MarbleProfileCam) this).chk_pointerinsidearea.Text = $"{buLangTranslate.preDef.Inside} {buLangTranslate.preDef.Area}";
      ((F_MarbleProfileCam) this).spn_pointerdiameter.Caption.Caption = buLangTranslate.preDef.Diameter;
    }
    catch (Exception ex)
    {
    }
  }
}
