// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEyeBaseForms
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Flexo;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

public class buEyeBaseForms
{
  internal static List<LayerBase5> \u0001;

  public buEyeBaseForms()
  {
    buCall.\u0001 = new buVector();
    buCall.\u0001 = new buKinematic();
    buCall.\u0001 = new buVector5();
    buCall.\u0001 = (buKinematic5) new buConversion5();
    // ISSUE: object of a compiler-generated type is created
    buCall.\u0001 = (buNestingCalc) new buProfileCalc.\u003C\u003Ec();
    buCall.\u0001 = (buCutterCalc) new WoodRuntimeSettings();
    buCall.\u0001 = (buDrillCalc) new buNestedResult();
    buCall.\u0001 = (buFlexoCalc) new PipeBendRuntimeSettings();
    buCall.\u0001 = (buProfileCalc) new ProfileOperationDataEllipse();
    buCall.\u0001 = (buMarbleCalc) new marbleTapPars();
    buCall.\u0001 = new buCam5();
    buCall.\u0001 = (buSewingCalc) new buNestingCalc();
    buCall.\u0001 = (buFoamCalc) new DrillFindTool();
    buCall.\u0001 = (buPanelCutCalc) new marbleEventPar();
    buCall.\u0001 = (buPrinter3D) new DrillItem();
    buCall.\u0001 = (buDiamakerCalc) new buWood();
    buCall.\u0001 = (buDoor) new SewingEntityCustomData();
    buCall.\u0001 = (buPipeBendCalc) new SewingRuntimeSettings();
    buCall.\u0001 = (buRouter3AX) new FoamEntities();
    buCall.\u0001 = (buToolGrindingCalc) new buFoamCalc();
    buCall.\u0001 = (buRoboticCalc) new \u0007.\u0001();
  }
}
