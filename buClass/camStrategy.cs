// Decompiled with JetBrains decompiler
// Type: buClass.camStrategy
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camStrategy : buSerilization
{
  public bool UseTangentLimit = true;
  public bool UseLimitAngleForOtherPlane = false;
  public double AngleLimitXY = 30.0;
  public double AngleLimitXZ = 30.0;
  public double AngleLimitYZ = 30.0;
  public double AngleLimit = 30.0;
  public double MinTangentValue = -360.0;
  public double MaxTangentValue = 360.0;
  public double TangentOffset = 0.0;
  public double ContantTangent = 0.0;
  public double OverrideC = 0.0;
  public bool UseContantTangent = false;
  public bool OverrideCEnable = false;
  public bool ArcToPoints = false;
  public bool StartFromAnyPoint = false;
  public bool OpenContourTwoDirectionCut = true;
  public static List<string> Captions = new List<string>();

  public camStrategy()
  {
  }

  public camStrategy(double anglelimit) => this.AngleLimit = anglelimit;

  public camStrategy(camStrategy Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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

  public override string ToString() => "AngleLimit: " + this.AngleLimit.ToString();
}
