// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleTools
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleTools : Form
{
  public buSpin spn_itemSA5;
  public buSpin spn_itemcount5;
  public buSpin spn_itemlen5;
  public buSpin spn_itemEA4;
  public buSpin spn_itemSA4;
  public buSpin spn_itemcount4;
  public buSpin spn_itemlen4;
  public buSpin spn_itemEA3;
  public buSpin spn_itemSA3;
  public buSpin spn_itemcount3;
  public buSpin spn_itemlen3;
  public buSpin spn_itemEA2;
  public buSpin spn_itemSA2;
  public buSpin spn_itemcount2;
  public buSpin spn_itemlen2;
  public buSpin spn_itemEA1;
  public buSpin spn_itemSA1;
  public buSpin spn_itemcount1;
  public buSpin spn_itemlen1;
  public buButton buButton1;
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_open;
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
  public Panel pnl_base;
  public buButton btn_clearallHor;
  internal Panel \u0001;
  public buSpin buSpin1;
  public buButton btn_save;
  public buSpin buSpin2;
  public buSpin buSpin3;
  internal buLabel \u0001;
  public TextBox txt_info;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleItemSettings varSettings;
  public string strMessageRoughtFinish;
  public string strMessageRoughtFinishSelect;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public buSpin spn_safedistance;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buCheckBox chk_maxtomin;
  public buSpin spn_plungespeed;
  public buSpin spn_cutspeed;
  internal buGround \u0001;
  internal buButton \u0001;
  public buCheckBox chk_midtoright;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleProfileCut) this).Properties.Inited)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleTools() => F_MarbleProfileCut.Captions = new List<string>();

  public F_MarbleTools()
  {
    ((F_MarbleProfileCut) this).PropertiesForm = new FormProperties();
    ((F_MarbleProfileCut) this).Mat = (MaterialBase5) new ShapeLeadInOut();
    ((F_MarbleProfileCut) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleMaterialSize) this);
  }

  public void Init()
  {
    ((F_MarbleProfileCut) this).PropertiesForm.Inited = false;
    if (((F_MarbleProfileCut) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleProfileCut) this).PropertiesForm.Height;
    if (((F_MarbleProfileCut) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleProfileCut) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleProfileCut) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleProfileCut) this).PropertiesForm.FormPosition;
    ((F_MarbleProfileCut) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileCut) this).PropertiesForm.Inited = true;
    ((F_MarbleProfileCut) this).spn_matheight.Value = ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialHeight;
    ((F_MarbleProfileCut) this).spn_matWdith.Value = ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialWidth;
    ((F_MarbleProfileCut) this).spn_matdepth.Value = ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness;
    \u0007.\u0001.\u0001((F_MarbleMaterialSize) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCut) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleProfileCut) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMaterialSize) this);
        ((F_MarbleProfileCut) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleProfileCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleProfileCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleContourMenu) this).btn_importimage.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathFromPhoto;
        openFileDialog.Filter = "All Image Files Files (*.Png,*.Jpg,*.Jpeg,*.Bmp)|*.png;*.jpg;*.jpeg;*.bmp|PNG Files (*.png)|*.png|JpegFiles (*.jpeg,*.jpg)|*.jpg;*.jpeg|BMP Files (*.bmp)|*.bmp";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_MarbleContourMenu) this).\u0001.Text = buFile5.bunesting.getFileName(openFileDialog.FileName);
          ((F_MarbleContourMenu) this).\u0001.Image = buFile5.PLYToSchematic.OpenImageAsStream(openFileDialog.FileName);
          ((SortFoundItems) ((F_MarbleProfileCut) this).Mat).FileNameImage = openFileDialog.FileName;
          ((SortResult) ((F_MarbleProfileCut) this).Mat).matImage = buFile5.PLYToSchematic.OpenImageAsStream(openFileDialog.FileName);
          ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathFromPhoto = buFile5.bunesting.GetPath(openFileDialog.FileName);
        }
      }
      if (!(control2.Name == ((F_MarbleProfileCut) this).btn_cancel.Name))
        return;
      ((F_MarbleProfileCut) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleProfileCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleProfileCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleTools() => F_MarbleProfileCut.Captions = new List<string>();

  public F_MarbleTools()
  {
    ((F_MarbleContourMenu) this).Properties = new FormProperties();
    ((F_MarbleContourMenu) this).varSweep = (marbleSweepPars) new \u0007.\u0001();
    ((F_MarbleContourMenu) this).SweepZFormEntities = new List<buEntity>();
    ((F_MarbleContourMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleSweepCut) this);
  }
}
