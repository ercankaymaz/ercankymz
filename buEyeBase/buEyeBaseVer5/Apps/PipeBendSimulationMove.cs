// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendSimulationMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendSimulationMove : buSerilization5
{
  internal \u0084.\u0001 \u0001;
  internal \u0084.\u0001 \u0002;
  internal IntPoint \u0001;
  internal long \u0001;
  internal \u0084.\u0001 \u0001;
  internal \u0084.\u0001 \u0002;
  internal \u0008.\u0001 \u0001;
  internal long \u0001;
  internal \u0018.\u0001 \u0001;
  internal long \u0001;
  internal \u0012.\u0001 \u0001;
  internal \u0012.\u0001 \u0002;
  internal int \u0001;
  internal bool \u0001;
  internal bool \u0002;
  internal \u0080.\u0001 \u0001;
  internal \u0012.\u0002 \u0001;

  public static List<IntPoint> CleanPolygon(List<IntPoint> path, double distance = 1.415)
  {
    int capacity = path.Count;
    List<IntPoint> intPointList1;
    if (capacity == 0)
    {
      intPointList1 = new List<IntPoint>();
    }
    else
    {
      \u0012.\u0002[] objArray = new \u0012.\u0002[capacity];
      for (int index = 0; index < capacity; ++index)
        objArray[index] = (\u0012.\u0002) new buPipeBendCalc();
      for (int index = 0; index < capacity; ++index)
      {
        ((PipeBendDiskBlocks) objArray[index]).\u0001 = path[index];
        ((PipeBendDiskBlocks) objArray[index]).\u0001 = objArray[(index + 1) % capacity];
        ((PipeBendDiskBlocks) ((PipeBendDiskBlocks) objArray[index]).\u0001).\u0002 = objArray[index];
        ((PipeBendDiskBlocks) objArray[index]).\u0001 = 0;
      }
      double num = distance * distance;
      \u0012.\u0002 obj = objArray[0];
      while ((((PipeBendDiskBlocks) obj).\u0001 != 0 ? 0 : (((PipeBendDiskBlocks) obj).\u0001 != ((PipeBendDiskBlocks) obj).\u0002 ? 1 : 0)) != 0)
      {
        if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((PipeBendDiskBlocks) obj).\u0001, ((PipeBendDiskBlocks) ((PipeBendDiskBlocks) obj).\u0002).\u0001, num))
        {
          obj = \u0007.\u0001.\u0001(obj);
          --capacity;
        }
        else if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((PipeBendDiskBlocks) ((PipeBendDiskBlocks) obj).\u0002).\u0001, ((PipeBendDiskBlocks) ((PipeBendDiskBlocks) obj).\u0001).\u0001, num))
        {
          \u0007.\u0001.\u0001(((PipeBendDiskBlocks) obj).\u0001);
          obj = \u0007.\u0001.\u0001(obj);
          capacity -= 2;
        }
        else if (\u0007.\u0001.\u0001(((PipeBendDiskBlocks) ((PipeBendDiskBlocks) obj).\u0002).\u0001, ((PipeBendDiskBlocks) obj).\u0001, ((PipeBendDiskBlocks) ((PipeBendDiskBlocks) obj).\u0001).\u0001, num))
        {
          obj = \u0007.\u0001.\u0001(obj);
          --capacity;
        }
        else
        {
          ((PipeBendDiskBlocks) obj).\u0001 = 1;
          obj = ((PipeBendDiskBlocks) obj).\u0001;
        }
      }
      if (capacity < 3)
        capacity = 0;
      List<IntPoint> intPointList2 = new List<IntPoint>(capacity);
      for (int index = 0; index < capacity; ++index)
      {
        intPointList2.Add(((PipeBendDiskBlocks) obj).\u0001);
        obj = ((PipeBendDiskBlocks) obj).\u0001;
      }
      intPointList1 = intPointList2;
    }
    return intPointList1;
  }

  public static List<List<IntPoint>> CleanPolygons(List<List<IntPoint>> polys, double distance = 1.415)
  {
    List<List<IntPoint>> intPointListList = new List<List<IntPoint>>(polys.Count);
    for (int index = 0; index < polys.Count; ++index)
      intPointListList.Add(PipeBendSimulationMove.CleanPolygon(polys[index], distance));
    return intPointListList;
  }

  internal static List<List<IntPoint>> \u0001(
    [In] List<IntPoint> obj0,
    [In] List<IntPoint> obj1,
    [In] bool obj2,
    [In] bool obj3)
  {
    int num = obj3 ? 1 : 0;
    int count1 = obj0.Count;
    int count2 = obj1.Count;
    List<List<IntPoint>> intPointListList1 = new List<List<IntPoint>>(count2);
    if (obj2)
    {
      for (int index = 0; index < count2; ++index)
      {
        List<IntPoint> intPointList = new List<IntPoint>(count1);
        foreach (IntPoint intPoint in obj0)
          intPointList.Add((IntPoint) new buDoor(obj1[index].X + intPoint.X, obj1[index].Y + intPoint.Y));
        intPointListList1.Add(intPointList);
      }
    }
    else
    {
      for (int index = 0; index < count2; ++index)
      {
        List<IntPoint> intPointList = new List<IntPoint>(count1);
        foreach (IntPoint intPoint in obj0)
          intPointList.Add((IntPoint) new buDoor(obj1[index].X - intPoint.X, obj1[index].Y - intPoint.Y));
        intPointListList1.Add(intPointList);
      }
    }
    List<List<IntPoint>> intPointListList2 = new List<List<IntPoint>>((count2 + num) * (count1 + 1));
    for (int index1 = 0; index1 < count2 - 1 + num; ++index1)
    {
      for (int index2 = 0; index2 < count1; ++index2)
      {
        List<IntPoint> poly = new List<IntPoint>(4);
        poly.Add(intPointListList1[index1 % count2][index2 % count1]);
        poly.Add(intPointListList1[(index1 + 1) % count2][index2 % count1]);
        poly.Add(intPointListList1[(index1 + 1) % count2][(index2 + 1) % count1]);
        poly.Add(intPointListList1[index1 % count2][(index2 + 1) % count1]);
        if (!BendingLRAMaterial.Orientation(poly))
          poly.Reverse();
        intPointListList2.Add(poly);
      }
    }
    return intPointListList2;
  }

  public static List<List<IntPoint>> MinkowskiSum(
    List<IntPoint> pattern,
    List<IntPoint> path,
    bool pathIsClosed)
  {
    List<List<IntPoint>> intPointListList = PipeBendSimulationMove.\u0001(pattern, path, true, pathIsClosed);
    buClipper buClipper = (buClipper) new PipeBendJob();
    ((buPipeBendCalc) buClipper).AddPaths(intPointListList, (PolyType) 0, true);
    ((PipeBendMove) buClipper).Execute((ClipType) 1, intPointListList, (PolyFillType) 1, (PolyFillType) 1);
    return intPointListList;
  }

  public static List<List<IntPoint>> MinkowskiSum(
    List<IntPoint> pattern,
    List<List<IntPoint>> paths,
    bool pathIsClosed)
  {
    List<List<IntPoint>> solution = new List<List<IntPoint>>();
    buClipper buClipper = (buClipper) new PipeBendJob();
    for (int index = 0; index < paths.Count; ++index)
    {
      List<List<IntPoint>> ppg = PipeBendSimulationMove.\u0001(pattern, paths[index], true, pathIsClosed);
      ((buPipeBendCalc) buClipper).AddPaths(ppg, (PolyType) 0, true);
      if (pathIsClosed)
      {
        List<IntPoint> path = paths[index];
        List<IntPoint> pg = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(pattern[0], path);
        ((buPipeBendCalc) buClipper).AddPath(pg, (PolyType) 1, true);
      }
    }
    ((PipeBendMove) buClipper).Execute((ClipType) 1, solution, (PolyFillType) 1, (PolyFillType) 1);
    return solution;
  }

  public static List<List<IntPoint>> MinkowskiDiff(List<IntPoint> poly1, List<IntPoint> poly2)
  {
    List<List<IntPoint>> intPointListList = PipeBendSimulationMove.\u0001(poly1, poly2, false, true);
    buClipper buClipper = (buClipper) new PipeBendJob();
    ((buPipeBendCalc) buClipper).AddPaths(intPointListList, (PolyType) 0, true);
    ((PipeBendMove) buClipper).Execute((ClipType) 1, intPointListList, (PolyFillType) 1, (PolyFillType) 1);
    return intPointListList;
  }

  public static List<List<IntPoint>> PolyTreeToPaths(PolyTree polytree)
  {
    List<List<IntPoint>> paths = new List<List<IntPoint>>();
    paths.Capacity = ((Router3AXSettings) polytree).get_Total();
    PipeBendSimulationMove.\u0001((PolyNode) polytree, (buClipper.\u0001) 0, paths);
    return paths;
  }

  internal static void \u0001([In] PolyNode obj0, [In] buClipper.\u0001 obj1, [In] List<List<IntPoint>> obj2)
  {
    // ISSUE: unable to decompile the method.
  }

  public static List<List<IntPoint>> OpenPathsFromPolyTree(PolyTree polytree)
  {
    List<List<IntPoint>> intPointListList = new List<List<IntPoint>>();
    intPointListList.Capacity = ((Router3AXDisplaySettings) polytree).get_ChildCount();
    for (int index = 0; index < ((Router3AXDisplaySettings) polytree).get_ChildCount(); ++index)
    {
      if (((DrawOptions) ((Router3AXRuntimeSettings) polytree).get_Childs()[index]).get_IsOpen())
        intPointListList.Add(((DoorRuntimeSettings) ((Router3AXRuntimeSettings) polytree).get_Childs()[index]).\u0001);
    }
    return intPointListList;
  }
}
