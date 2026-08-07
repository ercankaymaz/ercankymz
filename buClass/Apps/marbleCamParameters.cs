// Decompiled with JetBrains decompiler
// Type: buClass.Apps.marbleCamParameters
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class marbleCamParameters : buSerilization
{
  public double SafeDistance = 50.0;
  public double StepUpDistance = 20.0;
  public bool AirDistanceEnable = true;
  public double AirDistance = 50.0;
  public double PlungeVelocity = 50.0;
  public double LeaveVelocity = 50.0;
  public double FirstEnterDistance = 0.0;
  public double LastOutDistance = 0.0;
  public double ForwardStepDownDistance = 5.0;
  public double BackwardStepDownDistance = 2.0;
  public double ForwardCuttingVelocity = 10.0;
  public double BackwardCuttingVelocity = 5.0;
  public bool UseCZero = false;
  public CamCuttingDirectionType CuttingDirection = CamCuttingDirectionType.Forward;
  public CamCuttingSideDirectionType CuttingSide = CamCuttingSideDirectionType.LeftToRight;
  public CamCuttingOrderDirectionType CuttingOrderDirection = CamCuttingOrderDirectionType.Region;
  public static List<string> Captions = new List<string>();

  public marbleCamParameters()
  {
  }

  public marbleCamParameters(marbleCamParameters data)
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

  public static void Copy(marbleCamParameters Source, ref marbleCamParameters Target)
  {
    Target = new marbleCamParameters(Source);
  }

  public override string ToString()
  {
    return $"SafeDistance : {this.SafeDistance.ToString()} , PlungeVelocity : {this.PlungeVelocity.ToString()}";
  }
}
