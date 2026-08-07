// Decompiled with JetBrains decompiler
// Type: buClass.camDistances
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camDistances : buSerilization
{
  public double Safe = 100.0;
  public double SafeSmall = 80.0;
  public double FirstApproach = 20.0;
  public double StepUp = 20.0;
  public double LeftSafe = 100.0;
  public double LeftSafeSmall = 80.0;
  public double LeftFirstApproach = 20.0;
  public double LeftStepUp = 20.0;
  public double RightSafe = 100.0;
  public double RightSafeSmall = 80.0;
  public double RightFirstApproach = 20.0;
  public double RightStepUp = 20.0;
  public double Air = 500.0;
  public double Rapid = 100.0;
  public bool IncrementalSafe = false;
  public static List<string> Captions = new List<string>();

  public camDistances()
  {
  }

  public camDistances(double safe, double stepup, double air, bool increemntalsafe)
  {
    this.Safe = safe;
    this.StepUp = stepup;
    this.Air = air;
    this.IncrementalSafe = increemntalsafe;
  }

  public camDistances(camDistances distance)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) distance, ref CopiedClass);
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

  public override string ToString()
  {
    return $"Safe: {this.Safe.ToString()} , StepUp: {this.StepUp.ToString()} , Air: {this.Air.ToString()} , IncrementalSafe: {this.IncrementalSafe.ToString()}";
  }
}
