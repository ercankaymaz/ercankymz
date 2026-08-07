// Decompiled with JetBrains decompiler
// Type: buClass.SpinPipePattern
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SpinPipePattern : buSerilization
{
  public double StepDepth = 5.0;
  public double PipeLeftOffset = 5.0;
  public double TubeTopOffset = 2.0;
  public double CenterLineOffset = 2.0;
  public double TubeRigthOffset = 5.0;
  public double SetTubeLeftOffsetEachStep = 1.0;
  public double SetTubeRightOffsetEachStep = 1.0;
  public double FirstCurveLength = 5.0;
  public double LeadinCurveLength = 5.0;
  public double ArcRadius = 60.0;
  public double IncrementalSafeDistance = 50.0;
  public double LeaveHeight = 50.0;
  public double LeaveOffsetX = 0.0;
  public double LeaveArcCornerRadius = 2.0;
  public double MinY = 0.0;
  public double CamFeed = 100.0;
  public double CamLeaveFeed = 200.0;
  public double SafeDistance = 10.0;
  public bool isArcCorner = false;
  public static List<string> Captions = new List<string>();

  public SpinPipePattern()
  {
  }

  public SpinPipePattern(SpinPipePattern data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }
}
