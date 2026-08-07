// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_Marble3DAddMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_Marble3DAddMenu : Form
{
  internal IContainer \u0001;
  internal System.Windows.Forms.ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_basex;
  public buSpin spn_bssey;
  public buSpin spn_firstx;
  public buSpin spn_firstthinckness;
  public buSpin spn_firsty;
  public buSpin spn_secondthickness;
  public buSpin spn_secondy;
  public buSpin spn_secondx;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<MarbleImageThicknessData> ImageList;
  public int indexG54;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;

  public void Init()
  {
    ((F_MarbleMaterialList) this).PropertiesForm.Inited = false;
    if (!((F_MarbleMaterialList) this).PropertiesForm.Updated)
      ((F_MarbleMaterialList) this).PropertiesForm.Updated = true;
    if (((F_MarbleMaterialList) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleMaterialList) this).PropertiesForm.Height;
    if (((F_MarbleMaterialList) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleMaterialList) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleMaterialList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleMaterialList) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleMaterialList) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleMaterialList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleMaterialList) this).ground_base.Text = buLangTranslate.preDef.Move;
      ((F_MarbleMaterialList) this).spn_eventmovevalue.Caption.Caption = buLangTranslate.preDef.Move;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleMaterialList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMaterialList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleMaterialList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleMaterialList) this).spn_eventmovevalue.Value = (obj0 as buButton).Aux.ValDouble;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString(), (IWin32Window) this);
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMaterialList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMaterialList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Marble3DAddMenu() => F_MarbleMaterialList.Captions = new List<string>();

  public F_Marble3DAddMenu()
  {
    ((F_MarbleMaterialList) this).PropertiesForm = new FormProperties();
    ((F_MarbleMaterialList) this).Edge = (marbleEdgeItem) new \u0007.\u0001();
    ((F_MarbleMaterialList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleCountertopEdge) this);
  }

  public void Init()
  {
    ((F_MarbleMaterialList) this).PropertiesForm.Inited = false;
    if (((F_MarbleMaterialList) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleMaterialList) this).PropertiesForm.Height;
    if (((F_MarbleMaterialList) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleMaterialList) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleMaterialList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleMaterialList) this).PropertiesForm.FormPosition;
    ((F_MarbleSlice) this).chk_slatenable.Check = ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).Enable;
    ((F_MarbleSlice) this).chk_topchamferendenable.Check = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).EndChamfer).DataChamfer).TopEnable;
    ((F_MarbleMaterialList) this).chk_topchamferstartenable.Check = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).StartChamfer).DataChamfer).TopEnable;
    ((F_MarbleMaterialList) this).spn_slatstartangle.Value = ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).StartAngle;
    ((F_MarbleSlice) this).spn_slatendangle.Value = ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).EndAngle;
    ((F_MarbleMaterialList) this).spn_slatwidth.Value = ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).Width;
    ((F_MarbleMaterialList) this).spn_topchamferstartheight.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).StartChamfer).DataChamfer).TopHeight;
    ((F_MarbleMaterialList) this).spn_topchamferstartangle.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).StartChamfer).DataChamfer).TopAngle;
    ((F_MarbleSlice) this).spn_topchamferendheight.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).EndChamfer).DataChamfer).TopHeight;
    ((F_MarbleSlice) this).spn_topchamferendangle.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).EndChamfer).DataChamfer).TopAngle;
    ((F_MarbleSlice) this).spn_chamferbottomangle.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).BottomAngle;
    ((F_MarbleSlice) this).spn_chamferbottomheiht.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).BottomHeight;
    ((F_MarbleSlice) this).spn_chamfertopangle.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).TopAngle;
    ((F_MarbleSlice) this).spn_chamfertopheight.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).TopHeight;
    ((F_MarbleSlice) this).chk_bottomchamfer.Check = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).BottomEnable;
    ((F_MarbleSlice) this).chk_topchamfer.Check = ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).TopEnable;
    ((F_MarbleMaterialList) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleMaterialList) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleCountertopEdge) this);
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
