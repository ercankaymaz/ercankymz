// Decompiled with JetBrains decompiler
// Type: buMW.buMWUpdateHandler
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;
using System.Collections.Generic;

#nullable disable
namespace buMW;

public class buMWUpdateHandler : UpdateHandler
{
  public Point3d<double> pntStart;
  public static bool CancelOperation;

  public buMWUpdateHandler()
  {
    ((buMWCurveEntities) this).CurveList = new List<Curve>();
    this.pntStart = new Point3d<double>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public event MWCalculationUpdateHandler CalculationUpdate;

  public override bool IsCanceled() => buMWUpdateHandler.CancelOperation;

  public override void SetProgress(
    ProgressDescription rProgress,
    OverallProgressDescription rOverAllProgress)
  {
    // ISSUE: reference to a compiler-generated field
    if (((MWCalculationResult) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((MWCalculationResult) this).\u0001(rProgress, rOverAllProgress);
    }
    if (rOverAllProgress.Percentage >= 100)
      ;
  }

  public override void VisualUpdate(CNCMove lastCalculated, uint cutNumber)
  {
  }
}
