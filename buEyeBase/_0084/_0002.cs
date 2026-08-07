// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0084;

internal class \u0002
{
  static void \u0001([In] long obj0, [In] buClipper obj1)
  {
    if (((PipeBendingProgramSettings) obj1).\u0001 == null)
      return;
    \u0084.\u0001 obj2 = ((PipeBendingProgramSettings) obj1).\u0001;
    ((PipeBendTempVars) obj1).\u0001 = obj2;
    for (; obj2 != null; obj2 = ((BendingLRAMaterialData) obj2).\u0004)
    {
      ((BendingLRAMaterialData) obj2).\u0007 = ((BendingLRAMaterialData) obj2).\u0005;
      ((BendingLRAMaterialData) obj2).\u0006 = ((BendingLRAMaterialData) obj2).\u0004;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      (^(DoorRuntimeSettings&) ref ((PipeBendJob) obj2).\u0002).X = \u0007.\u0001.\u0001(obj2, obj0);
    }
    bool flag = true;
    while ((!flag ? 0 : (((PipeBendTempVars) obj1).\u0001 != null ? 1 : 0)) != 0)
    {
      flag = false;
      \u0084.\u0001 obj3 = ((PipeBendTempVars) obj1).\u0001;
      while (((BendingLRAMaterialData) obj3).\u0006 != null)
      {
        \u0084.\u0001 obj4 = ((BendingLRAMaterialData) obj3).\u0006;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if ((^(DoorRuntimeSettings&) ref ((PipeBendJob) obj3).\u0002).X > (^(DoorRuntimeSettings&) ref ((PipeBendJob) obj4).\u0002).X)
        {
          IntPoint intPoint;
          \u0007.\u0001.\u0001(obj4, obj1, obj3, ref intPoint);
          if (intPoint.Y < obj0)
          {
            // ISSUE: explicit constructor call
            ((buDoor) ref intPoint).\u002Ector(\u0007.\u0001.\u0001(obj3, obj0), obj0);
          }
          IntersectNode intersectNode = (IntersectNode) new DoorTempVars();
          ((PipeBendSimulationMove) intersectNode).\u0001 = obj3;
          ((PipeBendSimulationMove) intersectNode).\u0002 = obj4;
          ((PipeBendSimulationMove) intersectNode).\u0001 = intPoint;
          ((PipeBendTempVars) obj1).\u0001.Add(intersectNode);
          \u0007.\u0001.\u0001(obj1, obj3, obj4);
          flag = true;
        }
        else
          obj3 = obj4;
      }
      if (((BendingLRAMaterialData) obj3).\u0007 != null)
        ((BendingLRAMaterialData) ((BendingLRAMaterialData) obj3).\u0007).\u0006 = (\u0084.\u0001) null;
      else
        break;
    }
    ((PipeBendTempVars) obj1).\u0001 = (\u0084.\u0001) null;
  }
}
