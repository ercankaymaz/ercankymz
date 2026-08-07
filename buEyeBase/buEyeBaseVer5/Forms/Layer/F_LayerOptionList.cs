// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Layer.F_LayerOptionList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Machine;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Layer;

public class F_LayerOptionList : Form
{
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
  public FormProperties Properties;
  public static List<string> Captions;
  public marbleProfileCurveCutPars varProfileCurveCut;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_finishsurfoffset;
  public buSpin spn_finishminZ;
  public buSpin spn_finishstepang;
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
  private IContainer \u0001;
  public buLabel lbl_c;
  public buLabel lbl_part;
  public buLabel lbl_a;
  public buLabel lbl_machinec;
  public buLabel lbl_z;
  public buLabel lbl_machine;
  public buLabel lbl_y;
  public buLabel lbl_partc;
  public buLabel lbl_x;
  public buLabel lbl_quickspeed;
  public buButton btn_laser;

  static F_LayerOptionList() => F_Preset.Captions = new List<string>();

  public F_LayerOptionList()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init(MarbleCamType camType)
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MachineGCodeCfg) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MachineGCodeCfg) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MachineGCodeCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MachineGCodeCfg) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_CornerLocation) this).chk_zigzag.Name)
      {
        ((F_CornerLocation) this).chk_oneway.Check = false;
        ((F_CornerLocation) this).chk_zigzag.Check = true;
        ((F_CornerLocation) this).chk_spiral.Check = false;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_oneway.Name)
      {
        ((F_CornerLocation) this).chk_oneway.Check = true;
        ((F_CornerLocation) this).chk_zigzag.Check = false;
        ((F_CornerLocation) this).chk_spiral.Check = false;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_spiral.Name)
      {
        ((F_CornerLocation) this).chk_oneway.Check = false;
        ((F_CharList) this).chk_roughadaptive.Check = false;
        ((F_CornerLocation) this).chk_spiral.Check = true;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_region.Name)
      {
        ((F_CornerLocation) this).chk_region.Check = true;
        ((F_CornerLocation) this).chk_level.Check = false;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_level.Name)
      {
        ((F_CornerLocation) this).chk_region.Check = false;
        ((F_CornerLocation) this).chk_level.Check = true;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_silhouettenone.Name)
      {
        ((F_CornerLocation) this).chk_silhouettenone.Check = true;
        ((F_CornerLocation) this).chk_silhouettepart.Check = false;
        ((F_CornerLocation) this).chk_silhouettepartend.Check = false;
        ((F_CornerLocation) this).chk_silhouettetoolcontact.Check = false;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_silhouettepart.Name)
      {
        ((F_CornerLocation) this).chk_silhouettenone.Check = false;
        ((F_CornerLocation) this).chk_silhouettepart.Check = true;
        ((F_CornerLocation) this).chk_silhouettepartend.Check = false;
        ((F_CornerLocation) this).chk_silhouettetoolcontact.Check = false;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_silhouettepartend.Name)
      {
        ((F_CornerLocation) this).chk_silhouettenone.Check = false;
        ((F_CornerLocation) this).chk_silhouettepart.Check = false;
        ((F_CornerLocation) this).chk_silhouettepartend.Check = true;
        ((F_CornerLocation) this).chk_silhouettetoolcontact.Check = false;
      }
      else if (control2.Name == ((F_CornerLocation) this).chk_silhouettetoolcontact.Name)
      {
        ((F_CornerLocation) this).chk_silhouettenone.Check = false;
        ((F_CornerLocation) this).chk_silhouettepart.Check = false;
        ((F_CornerLocation) this).chk_silhouettepartend.Check = false;
        ((F_CornerLocation) this).chk_silhouettetoolcontact.Check = true;
      }
      else if (control2.Name == ((F_CharList) this).chk_roughadaptive.Name)
      {
        ((F_CharList) this).chk_roughoffset.Check = false;
        ((F_CharList) this).chk_roughadaptive.Check = true;
        ((F_CharList) this).chk_roughparalel.Check = false;
      }
      else if (control2.Name == ((F_CharList) this).chk_roughoffset.Name)
      {
        ((F_CharList) this).chk_roughoffset.Check = true;
        ((F_CharList) this).chk_roughadaptive.Check = false;
        ((F_CharList) this).chk_roughparalel.Check = false;
      }
      else if (control2.Name == ((F_CharList) this).chk_roughparalel.Name)
      {
        ((F_CharList) this).chk_roughoffset.Check = false;
        ((F_CharList) this).chk_roughadaptive.Check = false;
        ((F_CharList) this).chk_roughparalel.Check = true;
      }
      else if (control2.Name == ((F_SketchLibrary) this).chk_roughstockbox.Name)
      {
        ((F_SketchLibrary) this).chk_roughstocksurface.Check = false;
        ((F_SketchLibrary) this).chk_roughstockbox.Check = true;
      }
      else if (control2.Name == ((F_SketchLibrary) this).chk_roughstocksurface.Name)
      {
        ((F_SketchLibrary) this).chk_roughstocksurface.Check = true;
        ((F_SketchLibrary) this).chk_roughstockbox.Check = false;
      }
      else
      {
        if (control2.Name == ((F_CharList) this).btn_roughok.Name)
          ((F_CharList) this).\u0001.Visible = false;
        if (control2.Name == ((F_CharList) this).btn_roughsettings.Name)
        {
          if (!((F_CharList) this).\u0001.Visible)
            ((F_CharList) this).\u0001.Visible = true;
          else
            ((F_CharList) this).\u0001.Visible = false;
        }
        if (control2.Name == ((F_ObjectLocation) this).btn_ok.Name)
        {
          \u0007.\u0001.\u0001((F_MarbleEngraveCamSetting) this);
          ((F_MachineGCodeCfg) this).PropertiesForm.Result = DialogResult.OK;
          if (((F_MachineGCodeCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
            this.Dispose();
          if (((F_MachineGCodeCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
            this.Visible = false;
        }
        if (!(control2.Name == ((F_ObjectLocation) this).btn_cancel.Name | control2.Name == ((F_CharList) this).btn_closecross.Name))
          return;
        ((F_MachineGCodeCfg) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MachineGCodeCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MachineGCodeCfg) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MachineGCodeCfg) this).PropertiesForm.Inited)
      ;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }
}
