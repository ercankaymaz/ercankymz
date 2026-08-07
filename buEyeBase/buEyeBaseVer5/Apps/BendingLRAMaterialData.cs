// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.BendingLRAMaterialData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class BendingLRAMaterialData : buSerilization
{
  internal \u0084.\u0001 \u0003;
  internal \u0084.\u0001 \u0004;
  internal \u0084.\u0001 \u0005;
  internal \u0084.\u0001 \u0006;
  internal \u0084.\u0001 \u0007;

  internal void \u0002([In] \u0080.\u0001 obj0, [In] \u0080.\u0001 obj1)
  {
    \u0080.\u0001 obj2 = ((PipeBendSimulationMove) obj1).\u0001;
    foreach (\u0080.\u0001 obj3 in ((PipeBendingProgramSettings) this).\u0001)
    {
      if ((((PipeBendSimulationMove) obj3).\u0001 == null || obj3 == obj1 ? 1 : (obj3 == obj0 ? 1 : 0)) == 0)
      {
        \u0080.\u0001 obj4 = \u0007.\u0001.\u0001(((PipeBendSimulationMove) obj3).\u0001);
        if ((obj4 == obj2 || obj4 == obj0 ? 0 : (obj4 != obj1 ? 1 : 0)) == 0)
        {
          if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((PipeBendSimulationMove) obj3).\u0001, ((PipeBendSimulationMove) obj0).\u0001))
            ((PipeBendSimulationMove) obj3).\u0001 = obj0;
          else if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((PipeBendSimulationMove) obj3).\u0001, ((PipeBendSimulationMove) obj1).\u0001))
            ((PipeBendSimulationMove) obj3).\u0001 = obj1;
          else if ((((PipeBendSimulationMove) obj3).\u0001 == obj0 ? 1 : (((PipeBendSimulationMove) obj3).\u0001 == obj1 ? 1 : 0)) != 0)
            ((PipeBendSimulationMove) obj3).\u0001 = obj2;
        }
      }
    }
  }

  internal void \u0003([In] \u0080.\u0001 obj0, [In] \u0080.\u0001 obj1)
  {
    foreach (\u0080.\u0001 obj2 in ((PipeBendingProgramSettings) this).\u0001)
    {
      \u0080.\u0001 obj3 = \u0007.\u0001.\u0001(((PipeBendSimulationMove) obj2).\u0001);
      if ((((PipeBendSimulationMove) obj2).\u0001 == null ? 0 : (obj3 == obj0 ? 1 : 0)) != 0)
        ((PipeBendSimulationMove) obj2).\u0001 = obj1;
    }
  }

  public static double Area(List<IntPoint> poly)
  {
    int count = poly.Count;
    double num1;
    if (count < 3)
    {
      num1 = 0.0;
    }
    else
    {
      double num2 = 0.0;
      int index1 = 0;
      int index2 = count - 1;
      for (; index1 < count; ++index1)
      {
        num2 += ((double) poly[index2].X + (double) poly[index1].X) * ((double) poly[index2].Y - (double) poly[index1].Y);
        index2 = index1;
      }
      num1 = -num2 * 0.5;
    }
    return num1;
  }

  public static List<List<IntPoint>> SimplifyPolygon(List<IntPoint> poly, PolyFillType fillType = ); // Unable to render the method

  public static List<List<IntPoint>> SimplifyPolygons(
    List<List<IntPoint>> polys,
    PolyFillType fillType = ); // Unable to render the method
}
