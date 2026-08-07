// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleBackupLoad
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleBackupLoad : Form
{
  public buButton btn_cancel;
  internal DataGridView \u0001;
  internal ImageList \u0001;
  public buButton btn_g54save;
  public buButton btn_g54open;
  public buButton btn_add;
  public static byte f001DBB;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<Point3D> pntList;
  private Timer \u0001;
  private DrawingTypes \u0001;

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
    ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).Enable = ((F_MarbleSlice) this).chk_slatenable.Check;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).EndChamfer).DataChamfer).TopEnable = ((F_MarbleSlice) this).chk_topchamferendenable.Check;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).StartChamfer).DataChamfer).TopEnable = ((F_MarbleMaterialList) this).chk_topchamferstartenable.Check;
    ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).StartAngle = ((F_MarbleMaterialList) this).spn_slatstartangle.Value;
    ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).EndAngle = ((F_MarbleSlice) this).spn_slatendangle.Value;
    ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).DataSlat).Width = ((F_MarbleMaterialList) this).spn_slatwidth.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).StartChamfer).DataChamfer).TopHeight = ((F_MarbleMaterialList) this).spn_topchamferstartheight.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).StartChamfer).DataChamfer).TopAngle = ((F_MarbleMaterialList) this).spn_topchamferstartangle.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).EndChamfer).DataChamfer).TopHeight = ((F_MarbleSlice) this).spn_topchamferendheight.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourCutSequence) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Slat).EndChamfer).DataChamfer).TopAngle = ((F_MarbleSlice) this).spn_topchamferendangle.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).BottomAngle = ((F_MarbleSlice) this).spn_chamferbottomangle.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).BottomHeight = ((F_MarbleSlice) this).spn_chamferbottomheiht.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).TopAngle = ((F_MarbleSlice) this).spn_chamfertopangle.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).TopHeight = ((F_MarbleSlice) this).spn_chamfertopheight.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).BottomEnable = ((F_MarbleSlice) this).chk_bottomchamfer.Check;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((MarbleContourMenuType) ((F_MarbleMaterialList) this).Edge).Chamfer).DataChamfer).TopEnable = ((F_MarbleSlice) this).chk_topchamfer.Check;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleMaterialList) this).btn_okVer.Name)
      {
        this.Apply();
        ((F_MarbleMaterialList) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleMaterialList) this).btn_close.Name | control2.Name == ((F_MarbleMaterialList) this).btn_cancel.Name))
        return;
      ((F_MarbleMaterialList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleMaterialList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleMaterialList) this).PropertiesForm.Inited)
      return;
    buSpin buSpin = obj0 as buSpin;
    buSpin.Display.BackColor = clsVisualVars.parVisual.colorDataFocus;
    buSpin.SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
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
    if ((!disposing ? 0 : (((F_MarbleMaterialList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMaterialList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleBackupLoad() => F_MarbleMaterialList.Captions = new List<string>();

  public F_MarbleBackupLoad()
  {
    ((F_MarbleSlice) this).PropertiesForm = new FormProperties();
    ((F_MarbleSlice) this).Slat = (marbleSlatPars) new \u0007.\u0001();
    ((F_MarbleSlice) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCountertopSlat) this);
  }
}
