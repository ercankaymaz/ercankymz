// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.BendingLRAMaterial
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
public class BendingLRAMaterial : buSerilization
{
  internal \u0084.\u0001 \u0001;
  internal \u0084.\u0001 \u0002;

  private bool \u0001()
  {
    try
    {
      ((buPipeBendCalc) this).\u0001();
      ((PipeBendTempVars) this).\u0001 = (\u0084.\u0001) null;
      ((PipeBendTempVars) this).\u0001 = (\u0012.\u0001) null;
      long num1;
      if (!\u0007.\u0001.\u0001((buClipperBase) this, ref num1))
        return false;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((buClipper) this, num1);
      long num2;
      while ((\u0007.\u0001.\u0001((buClipperBase) this, ref num2) ? 1 : (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((buClipperBase) this) ? 1 : 0)) != 0)
      {
        \u0007.\u0001.\u0001((buClipper) this);
        ((PipeBendTempVars) this).\u0002.Clear();
        if (!\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((buClipper) this, num2))
          return false;
        \u0007.\u0001.\u0001((buClipper) this, num2);
        num1 = num2;
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((buClipper) this, num1);
      }
      foreach (\u0080.\u0001 obj in ((PipeBendingProgramSettings) this).\u0001)
      {
        if ((((PipeBendSimulationMove) obj).\u0001 == null ? 1 : (((PipeBendSimulationMove) obj).\u0002 ? 1 : 0)) == 0 && (((PipeBendSimulationMove) obj).\u0001 ^ ((PipeBendJob) this).get_ReverseSolution()) == \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((buClipper) this, obj) > 0.0)
          \u0007.\u0001.\u0001(((PipeBendSimulationMove) obj).\u0001, (buClipper) this);
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((buClipper) this);
      foreach (\u0080.\u0001 obj in ((PipeBendingProgramSettings) this).\u0001)
      {
        if (((PipeBendSimulationMove) obj).\u0001 != null)
        {
          if (((PipeBendSimulationMove) obj).\u0002)
            \u0007.\u0001.\u0001(obj, (buClipper) this);
          else
            \u0007.\u0001.\u0001((buClipper) this, obj);
        }
      }
      if (((PipeBendMove) this).get_StrictlySimple())
        \u0007.\u0001.\u0001((buClipper) this);
      return true;
    }
    finally
    {
      ((PipeBendTempVars) this).\u0001.Clear();
      ((PipeBendTempVars) this).\u0002.Clear();
    }
  }

  public static void ReversePaths(List<List<IntPoint>> polys)
  {
    foreach (List<IntPoint> poly in polys)
      poly.Reverse();
  }

  public static bool Orientation(List<IntPoint> poly) => BendingLRAMaterialData.Area(poly) >= 0.0;

  public static int PointInPolygon(IntPoint pt, List<IntPoint> path)
  {
    int num1 = 0;
    int count = path.Count;
    int num2;
    if (count < 3)
    {
      num2 = 0;
    }
    else
    {
      IntPoint intPoint1 = path[0];
      for (int index = 1; index <= count; ++index)
      {
        IntPoint intPoint2 = index == count ? path[0] : path[index];
        if (intPoint2.Y != pt.Y || (intPoint2.X == pt.X ? 1 : (intPoint1.Y != pt.Y ? 0 : (intPoint2.X > pt.X == intPoint1.X < pt.X ? 1 : 0))) == 0)
        {
          if (intPoint1.Y < pt.Y != intPoint2.Y < pt.Y)
          {
            if (intPoint1.X >= pt.X)
            {
              if (intPoint2.X > pt.X)
              {
                num1 = 1 - num1;
              }
              else
              {
                double num3 = (double) (intPoint1.X - pt.X) * (double) (intPoint2.Y - pt.Y) - (double) (intPoint2.X - pt.X) * (double) (intPoint1.Y - pt.Y);
                if (num3 != 0.0)
                {
                  if (num3 > 0.0 == intPoint2.Y > intPoint1.Y)
                    num1 = 1 - num1;
                }
                else
                {
                  num2 = -1;
                  goto label_21;
                }
              }
            }
            else if (intPoint2.X > pt.X)
            {
              double num4 = (double) (intPoint1.X - pt.X) * (double) (intPoint2.Y - pt.Y) - (double) (intPoint2.X - pt.X) * (double) (intPoint1.Y - pt.Y);
              if (num4 != 0.0)
              {
                if (num4 > 0.0 == intPoint2.Y > intPoint1.Y)
                  num1 = 1 - num1;
              }
              else
              {
                num2 = -1;
                goto label_21;
              }
            }
          }
          intPoint1 = intPoint2;
        }
        else
        {
          num2 = -1;
          goto label_21;
        }
      }
      num2 = num1;
    }
label_21:
    return num2;
  }

  internal void \u0001([In] \u0080.\u0001 obj0, [In] \u0080.\u0001 obj1)
  {
    foreach (\u0080.\u0001 obj2 in ((PipeBendingProgramSettings) this).\u0001)
    {
      \u0080.\u0001 obj3 = \u0007.\u0001.\u0001(((PipeBendSimulationMove) obj2).\u0001);
      if ((((PipeBendSimulationMove) obj2).\u0001 == null ? 0 : (obj3 == obj0 ? 1 : 0)) != 0 && \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((PipeBendSimulationMove) obj2).\u0001, ((PipeBendSimulationMove) obj1).\u0001))
        ((PipeBendSimulationMove) obj2).\u0001 = obj1;
    }
  }
}
