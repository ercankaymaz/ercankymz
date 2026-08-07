// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEyeItems
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Forms.WinControlForms.Progress;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Flexo;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buEyeItems
{
  public static F_ProgressCalculation FrmProgress;
  public static Form frmMain;
  public static Design viewportCNC;
  public static Design viewportCadCam;
  public static Design viewportDialogs;
  public static Plane planeViewportDialogs;

  static buEyeItems()
  {
    buCall.\u0001 = (buKinematic) null;
    buCall.\u0001 = (buKinematic5) null;
    buCall.\u0001 = (buVector) null;
    buCall.\u0001 = (buVector5) null;
    buCall.\u0001 = (buCam5) null;
    buCall.\u0001 = (buNestingCalc) null;
    buCall.\u0001 = (buCutterCalc) null;
    buCall.\u0001 = (buDrillCalc) null;
    buCall.\u0001 = (buFlexoCalc) null;
    buCall.\u0001 = (buProfileCalc) null;
    buCall.\u0001 = (buSewingCalc) null;
    buCall.\u0001 = (buFoamCalc) null;
    buCall.\u0001 = (buPipeBendCalc) null;
    buCall.\u0001 = (buPrinter3D) null;
    buCall.\u0001 = (buPanelCutCalc) null;
    buCall.\u0001 = (buDiamakerCalc) null;
    buCall.\u0001 = (buDoor) null;
    buCall.\u0001 = (buRouter3AX) null;
    buCall.\u0001 = (buToolGrindingCalc) null;
    buCall.\u0001 = (buMarbleCalc) null;
    buCall.\u0001 = (buRoboticCalc) null;
    buEyeBaseForms.\u0001 = new List<LayerBase5>();
  }

  public static void mouseMoveViewportDialogs(object sender, MouseEventArgs e)
  {
    if (buEyeItems.viewportDialogs == null)
      return;
    buEyeItems.viewportDialogs.ScreenToPlane(e.Location, buEyeItems.planeViewportDialogs, out buEyeVars.pntMouseMove);
  }
}
