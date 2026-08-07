// Decompiled with JetBrains decompiler
// Type: buCore.buCompare
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buCore;

public class buCompare
{
  public static bool EQ(double Value1, double Value2)
  {
    return buCompare.EQ(Value1, Value2, buSystem.resolutionCompare);
  }

  public static bool EQ(Pnt2D Value1, Pnt2D Value2)
  {
    return buCompare.EQ(Value1, Value2, buSystem.resolutionCompare);
  }

  public static bool EQ(Pnt3D Value1, Pnt3D Value2)
  {
    return buCompare.EQ(Value1, Value2, buSystem.resolutionCompare);
  }

  public static bool EQ(Pnt4D Value1, Pnt4D Value2)
  {
    return buCompare.EQ(Value1, Value2, buSystem.resolutionCompare);
  }

  public static bool EQ(Pnt6D Value1, Pnt6D Value2)
  {
    return buCompare.EQ(Value1, Value2, buSystem.resolutionCompare);
  }

  public static bool EQ(Pnt9D Value1, Pnt9D Value2)
  {
    return buCompare.EQ(Value1, Value2, buSystem.resolutionCompare);
  }

  public static bool EQ(double Value1, double Value2, double Resolution)
  {
    return Math.Abs(Value1 - Value2) < Resolution;
  }

  public static bool EQ(Pnt2D Value1, Pnt2D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y)) < Resolution;
  }

  public static bool EQ(Pnt3D Value1, Pnt3D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static bool EQ(Pnt4D Value1, Pnt4D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.W - Value2.W) * (Value1.W - Value2.W)) < Resolution;
  }

  public static bool EQ(Pnt3D Value1, Pnt9D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static bool EQ(Pnt9D Value1, Pnt3D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) < Resolution;
  }

  public static bool EQ(Pnt6D Value1, Pnt6D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C)) < Resolution;
  }

  public static bool EQ(Pnt9D Value1, Pnt9D Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C) + (Value1.U - Value2.U) * (Value1.U - Value2.U) + (Value1.V - Value2.V) * (Value1.V - Value2.V) + (Value1.W - Value2.W) * (Value1.W - Value2.W)) < Resolution;
  }

  public static bool EQ(Pnt3D Value1, Pnt9DCam Value2, double Resolution)
  {
    return Math.Sqrt((Value1.X - Value2.P9.X) * (Value1.X - Value2.P9.X) + (Value1.Y - Value2.P9.Y) * (Value1.Y - Value2.P9.Y) + (Value1.Z - Value2.P9.Z) * (Value1.Z - Value2.P9.Z)) < Resolution;
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<List<Pnt3D>> Points)
  {
    try
    {
      List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
      for (int index = 0; index <= Points.Count - 1; ++index)
      {
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        buGeneral.CopyLists(Points[index], ref pnt3DList);
        buCompare.CheckDuplicatedPointsWithPrevious(ref pnt3DList);
        pnt3DListList.Add(pnt3DList);
      }
      Points.Clear();
      for (int index = 0; index <= pnt3DListList.Count - 1; ++index)
        Points.Add(pnt3DListList[index]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<Pnt3D> Points)
  {
    try
    {
      List<Pnt3D> TargetList = new List<Pnt3D>();
      if (Points.Count <= 0)
        return;
      buGeneral.CopyLists(Points, ref TargetList);
      Points.Clear();
      Points.Add(new Pnt3D(TargetList[0]));
      for (int index = 1; index <= TargetList.Count - 1; ++index)
      {
        if (!buCompare.EQ(Points[Points.Count - 1], TargetList[index]))
          Points.Add(new Pnt3D(TargetList[index]));
      }
      if (Points.Count <= 0 || buCompare.EQ(Points[Points.Count - 1], TargetList[TargetList.Count - 1]))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(new Pnt3D(TargetList[TargetList.Count - 1]));
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<Pnt3D> Points, double Resolution)
  {
    try
    {
      List<Pnt3D> TargetList = new List<Pnt3D>();
      if (Points.Count <= 0)
        return;
      buGeneral.CopyLists(Points, ref TargetList);
      Points.Clear();
      Points.Add(new Pnt3D(TargetList[0]));
      for (int index = 1; index <= TargetList.Count - 1; ++index)
      {
        if (!buCompare.EQ(Points[Points.Count - 1], TargetList[index], Resolution))
          Points.Add(new Pnt3D(TargetList[index]));
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
