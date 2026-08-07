// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendingProgramSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using dummy_ptr;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendingProgramSettings : buSerilization5
{
  internal List<List<\u0084.\u0001>> \u0001;
  internal \u0018.\u0001 \u0001;
  internal List<\u0080.\u0001> \u0001;
  internal \u0084.\u0001 \u0001;

  public void Clear()
  {
    ((Router3AXRuntimeSettings) ((PipeBendTempVars) this).\u0001).get_Childs().Clear();
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    (^(DoorRuntimeSettings&) ref ((PipeBendTempVars) this).\u0001).X = -1L;
  }

  public void AddPath(List<IntPoint> path, JoinType joinType, EndType endType)
  {
    // ISSUE: unable to decompile the method.
  }

  public void AddPaths(List<List<IntPoint>> paths, JoinType joinType, EndType endType)
  {
    // ISSUE: unable to decompile the method.
  }

  public void Execute(ref List<List<IntPoint>> solution, double delta)
  {
    solution.Clear();
    \u0007.\u0001.\u0001((ClipperOffset) this);
    \u0007.\u0001.\u0001((ClipperOffset) this, delta);
    buClipper buClipper = (buClipper) new PipeBendJob();
    ((buPipeBendCalc) buClipper).AddPaths(((PipeBendTempVars) this).\u0001, (PolyType) 0, true);
    if (delta > 0.0)
    {
      ((PipeBendMove) buClipper).Execute((ClipType) 1, solution, (PolyFillType) 2, (PolyFillType) 2);
    }
    else
    {
      IntRect bounds = buPipeBendCalc.GetBounds(((PipeBendTempVars) this).\u0001);
      ((buPipeBendCalc) buClipper).AddPath(new List<IntPoint>(4)
      {
        (IntPoint) new buDoor(bounds.left - 10L, bounds.bottom + 10L),
        (IntPoint) new buDoor(bounds.right + 10L, bounds.bottom + 10L),
        (IntPoint) new buDoor(bounds.right + 10L, bounds.top - 10L),
        (IntPoint) new buDoor(bounds.left - 10L, bounds.top - 10L)
      }, (PolyType) 0, true);
      ((PipeBendJob) buClipper).set_ReverseSolution(true);
      ((PipeBendMove) buClipper).Execute((ClipType) 1, solution, (PolyFillType) 3, (PolyFillType) 3);
      if (solution.Count <= 0)
        return;
      solution.RemoveAt(0);
    }
  }

  public void Execute(ref PolyTree solution, double delta)
  {
    ((Router3AXCamPlane) solution).Clear();
    \u0007.\u0001.\u0001((ClipperOffset) this);
    \u0007.\u0001.\u0001((ClipperOffset) this, delta);
    buClipper buClipper = (buClipper) new PipeBendJob();
    ((buPipeBendCalc) buClipper).AddPaths(((PipeBendTempVars) this).\u0001, (PolyType) 0, true);
    if (delta > 0.0)
    {
      ((PipeBendMove) buClipper).Execute((ClipType) 1, solution, (PolyFillType) 2, (PolyFillType) 2);
    }
    else
    {
      IntRect bounds = buPipeBendCalc.GetBounds(((PipeBendTempVars) this).\u0001);
      ((buPipeBendCalc) buClipper).AddPath(new List<IntPoint>(4)
      {
        (IntPoint) new buDoor(bounds.left - 10L, bounds.bottom + 10L),
        (IntPoint) new buDoor(bounds.right + 10L, bounds.bottom + 10L),
        (IntPoint) new buDoor(bounds.right + 10L, bounds.top - 10L),
        (IntPoint) new buDoor(bounds.left - 10L, bounds.top - 10L)
      }, (PolyType) 0, true);
      ((PipeBendJob) buClipper).set_ReverseSolution(true);
      ((PipeBendMove) buClipper).Execute((ClipType) 1, solution, (PolyFillType) 3, (PolyFillType) 3);
      if ((((Router3AXDisplaySettings) solution).get_ChildCount() != 1 ? 0 : (((Router3AXDisplaySettings) ((Router3AXRuntimeSettings) solution).get_Childs()[0]).get_ChildCount() > 0 ? 1 : 0)) != 0)
      {
        PolyNode polyNode = ((Router3AXRuntimeSettings) solution).get_Childs()[0];
        ((Router3AXRuntimeSettings) solution).get_Childs().Capacity = ((Router3AXDisplaySettings) polyNode).get_ChildCount();
        ((Router3AXRuntimeSettings) solution).get_Childs()[0] = ((Router3AXRuntimeSettings) polyNode).get_Childs()[0];
        ((DoorRuntimeSettings) ((Router3AXRuntimeSettings) solution).get_Childs()[0]).\u0001 = (PolyNode) solution;
        for (int index = 1; index < ((Router3AXDisplaySettings) polyNode).get_ChildCount(); ++index)
          \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((PolyNode) solution, ((Router3AXRuntimeSettings) polyNode).get_Childs()[index]);
      }
      else
        ((Router3AXCamPlane) solution).Clear();
    }
  }
}
