// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarblePartZero
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buCadCamResVer5;
using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarblePartZero : Form
{
  public buSpin spn_c270CDis;
  public buSpin spn_c180CDis;
  public buSpin spn_c90CDis;
  public buSpin spn_c0CDis;
  internal buLabel \u0015;
  public buButton btn_stop;
  public buButton btn_closecross;
  public buButton btn_mdi;
  public buButton btn_jog;
  public static byte f000365;
  public static List<string> Captions;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleKinematic) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleKinematic) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleKinematic) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleKinematic) this).SpinFocusColor;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleKinematic) this).SpinBaseColor;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleKinematic) this).btn_A0ZPosGet.Name && clsAppMarbleVars.cMachine != null)
      ((F_MarbleKinematic) this).spn_A0ZPos.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition;
    if (control.Name == ((F_MarbleKinematic) this).btn_A45ZPosGet.Name && clsAppMarbleVars.cMachine != null)
      ((F_MarbleKinematic) this).spn_A45ZPos.Value = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition;
    if (control.Name == this.btn_stop.Name && clsAppMarbleVars.cmdMarble != null)
      clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 2);
    if (control.Name == this.btn_jog.Name && clsAppMarbleItems.frmJogPageV1 != null)
    {
      clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      clsAppMarbleItems.frmJogPageV1.Init();
      int num = (int) clsAppMarbleItems.frmJogPageV1.ShowDialog();
    }
    if (control.Name == this.btn_mdi.Name)
    {
      if (clsAppMarbleItems.frmMDIPageV1 != null)
      {
        clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmMDIPageV1.Init();
        int num = (int) clsAppMarbleItems.frmMDIPageV1.ShowDialog();
      }
      else if (clsAppMarbleItems.frmMDIPageV2 != null)
      {
        clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsAppMarbleItems.frmMDIPageV2.Init();
        int num = (int) clsAppMarbleItems.frmMDIPageV2.ShowDialog();
      }
    }
    if (control.Name == ((F_MarbleKinematic) this).btn_adistancecalc.Name)
    {
      for (double num1 = -5.0; num1 <= 5.0; ++num1)
      {
        double num2 = 0.0;
        if (buMarbleCalc.activeToolSaw.Geometry.SocketThickness > 0.0 & buMarbleCalc.activeToolSaw.Geometry.SocketThickness > buMarbleCalc.activeToolSaw.Geometry.Thickness)
          num2 = (buMarbleCalc.activeToolSaw.Geometry.SocketThickness - buMarbleCalc.activeToolSaw.Geometry.Thickness) / 2.0;
        KinematicBase5 kinematicBase5 = new KinematicBase5(((F_MarbleKinematic) this).Kinematic);
        kinematicBase5.RotateCenterOffsetOfA.Y += num1;
        kinematicBase5.RotateCenterOffsetOfA.Y += num2;
        kinematicBase5.RotateCenterOffsetOfC.Y += num2;
        double num3 = buMarbleCalc.activeToolSaw.Geometry.Diameter / 2.0;
        Point3D point3D1 = new Point3D();
        Pnt6D pnt6D1 = new Pnt6D();
        Point3D point3D2 = new Point3D(0.0, 497.0, 0.0);
        Pnt6D pnt6D2 = new Pnt6D();
        clsInit.cKinematic5.ReverseKinematix5Ax(num3, kinematicBase5, new OrientationAngle(45.0, 0.0, 0.0), point3D1, ref pnt6D1);
        clsInit.cKinematic5.ReverseKinematix5Ax(num3, kinematicBase5, new OrientationAngle(45.0, 0.0, 180.0), point3D2, ref pnt6D2);
      }
      double num = 0.0;
      clsInit.cMarble.ARotationCenterCalc(((F_MarbleKinematic) this).spn_A0ZPos.Value - ((F_MarbleKinematic) this).spn_A45ZPos.Value, ((F_MarbleKinematic) this).spn_measuredYDistanceA0A45.Value, 45.0, buMarbleCalc.activeToolSaw.Geometry.Diameter, buMarbleCalc.activeToolSaw.Geometry.SocketThickness, ref num);
      ((F_MarbleKinematic) this).spn_ACalculated.Value = num;
    }
    if (control.Name == ((F_MarbleKinematic) this).btn_closeadvanced.Name)
      ((F_MarbleKinematic) this).\u0001.Visible = false;
    if (control.Name == ((F_MarbleKinematic) this).btn_closeAcalc.Name)
      ((F_MarbleKinematic) this).\u0002.Visible = false;
    if (control.Name == ((F_MarbleKinematic) this).btn_acentercalcshow.Name)
    {
      if (((F_MarbleKinematic) this).\u0002.Visible)
        ((F_MarbleKinematic) this).\u0002.Visible = false;
      else
        ((F_MarbleKinematic) this).\u0002.Visible = true;
    }
    if (!(control.Name == ((F_MarbleKinematic) this).btn_options.Name))
      return;
    if (((F_MarbleKinematic) this).\u0001.Visible)
      ((F_MarbleKinematic) this).\u0001.Visible = false;
    else
      ((F_MarbleKinematic) this).\u0001.Visible = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleKinematic) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleKinematic) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarblePartZero() => F_MarbleKinematic.Captions = new List<string>();

  public F_MarblePartZero()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void MenuButtonColors(MarblePartZeroType partZero)
  {
    // ISSUE: unable to decompile the method.
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (buEyeVars.parVisual == null)
        return;
      if (!((F_MarbleMDIV2) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce && new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
      {
        Control.ControlCollection controlCollection = (Control.ControlCollection) null;
        controlCollection = hmiUICommands.SetVisualItem(((F_MarbleMDIV2) this).buGround1.Controls);
        ((F_MarbleMDIV2) this).PropertiesForm.VisualUpdated = true;
      }
      \u0005.\u0003.\u0001(this);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleMDIV2) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
