// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buCall
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Flexo;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

public class buCall
{
  public drawPropertiesType CamOtherDraw;
  internal static buKinematic \u0001;
  internal static buKinematic5 \u0001;
  internal static buVector \u0001;
  internal static buVector5 \u0001;
  internal static buCam5 \u0001;
  internal static buNestingCalc \u0001;
  internal static buCutterCalc \u0001;
  internal static buDrillCalc \u0001;
  internal static buFlexoCalc \u0001;
  internal static buProfileCalc \u0001;
  internal static buSewingCalc \u0001;
  internal static buFoamCalc \u0001;
  internal static buPipeBendCalc \u0001;
  internal static buPrinter3D \u0001;
  internal static buPanelCutCalc \u0001;
  internal static buDiamakerCalc \u0001;
  internal static buDoor \u0001;
  internal static buRouter3AX \u0001;
  internal static buToolGrindingCalc \u0001;
  internal static buMarbleCalc \u0001;
  internal static buRoboticCalc \u0001;

  public abstract void m00005D();

  public buCall()
  {
    ((CamDraws) this).CamMarkDraw = new drawPropertiesType(Color.DarkGreen, 2f, new drawingPattern());
    ((CamDraws) this).CamG0Draw = new drawPropertiesType(Color.Brown, 2f, new drawingPattern());
    ((CamDraws) this).CamG1Draw = new drawPropertiesType(Color.Blue, 2f, new drawingPattern());
    ((CamDraws) this).CamPlungeDraw = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());
    ((CamDraws) this).CamLeaveDraw = new drawPropertiesType(Color.Red, 2f, new drawingPattern());
    ((CamDraws) this).CamLeadinDraw = new drawPropertiesType(Color.Cyan, 2f, new drawingPattern());
    ((CamDraws) this).CamLeadOutDraw = new drawPropertiesType(Color.Orange, 2f, new drawingPattern());
    this.CamOtherDraw = new drawPropertiesType(Color.DarkGray, 2f, new drawingPattern());
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
