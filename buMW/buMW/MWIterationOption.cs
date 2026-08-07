// Decompiled with JetBrains decompiler
// Type: buMW.MWIterationOption
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using ModuleWorks;

#nullable disable
namespace buMW;

public class MWIterationOption
{
  public camParameters5 buCamParamters;
  public bool getContour;
  public Pnt6D StartPoint;

  public MWIterationOption()
  {
    ((MWCalculationResult) this).geoLib = (GeoLib) null;
    ((MWCalculationResult) this).Tool = (ToolBase5) null;
    ((MWCalculationResult) this).ToolPathCalc = (ToolPath) null;
    this.buCamParamters = (camParameters5) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public MWIterationOption()
  {
    ((MWCalculationResultEventArg) this).EndPoint = new Pnt6D();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
