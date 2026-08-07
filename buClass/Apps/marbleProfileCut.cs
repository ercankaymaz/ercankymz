// Decompiled with JetBrains decompiler
// Type: buClass.Apps.marbleProfileCut
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class marbleProfileCut : buSerilization
{
  public double Length = 500.0;
  public double StartPosition = 0.0;
  public double BaseHeight = 50.0;
  public double Angle = 100.0;
  public double FinishStep = 10.0;
  public double RoughtOffset = 0.0;
  public double FinishOffset = 0.0;
  public double RoughtDevideLen = 2.0;
  public double FinishDevideLen = 1.0;
  public double DownDevideLen = 5.0;
  public bool RoughEnable = true;
  public bool FinishEnable = true;
  public bool MaxToMinDirection = false;
  public bool SmoothZigzagMode = false;
  public bool RoughZigzagMode = false;
  public bool MoveSafeDistanceForFinishZigzagMode = false;
  public double RotationAngle = 0.0;
  public VectorXYType Direction = VectorXYType.XVector;
  public CamAxisCountType CamTypeRough = CamAxisCountType.Axis5;
  public CamAxisCountType CamTypeFinish = CamAxisCountType.Axis5;
  public static List<string> Captions = new List<string>();

  public marbleProfileCut()
  {
  }

  public marbleProfileCut(marbleProfileCut data)
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

  public static void Copy(marbleProfileCut Source, ref marbleProfileCut Target)
  {
    Target = new marbleProfileCut(Source);
  }

  public override string ToString()
  {
    return $"Length : {this.Length.ToString()} , BaseHeight : {this.BaseHeight.ToString()}";
  }
}
