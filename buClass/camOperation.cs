// Decompiled with JetBrains decompiler
// Type: buClass.camOperation
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camOperation : buSerilization
{
  public double Height = 0.0;
  public double Depth = 0.0;
  public bool FinishEnable = false;
  public bool AreaClearanceEnable = false;
  public bool MakeCenterOffset = false;
  public bool isClosed = false;
  public ClockDirectionType Direction = ClockDirectionType.CCW;
  public InToOutType AreaClearanceDirection = InToOutType.OutToIn;
  public CamSafeForPlunge SafePlungeForFirstPoint = CamSafeForPlunge.Safe;
  public CamSafeForLeave SafeLeaveForLastPoint = CamSafeForLeave.Safe;
  public CamSafeForPlunge SafePlungeForContoutToContour = CamSafeForPlunge.Safe;
  public CamSafeForLeave SafeLeaveForContoutToContour = CamSafeForLeave.Safe;
  public CamSafeForPlunge SafePlungeForIfLastAndNextPointSameXY = CamSafeForPlunge.None;
  public CamSafeForLeave SafeLeaveForIfLastAndNextPointSameXY = CamSafeForLeave.None;
  public bool PocketStepToStepSmallSafe = true;
  public Pnt6D Point = new Pnt6D();
  public double Thickness = 0.0;
  public double TargetZ = 0.0;
  public List<double> StepHeights = new List<double>();
  public static List<string> Captions = new List<string>();

  public camOperation()
  {
  }

  public camOperation(double height, ClockDirectionType direction)
  {
    this.Height = height;
    this.Direction = direction;
  }

  public camOperation(camOperation data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    this.StepHeights.Clear();
    for (int index = 0; index <= data.StepHeights.Count - 1; ++index)
      this.StepHeights.Add(data.StepHeights[index]);
  }

  public override string ToString()
  {
    return $"{this.Height.ToString()} , Direction: {this.Direction.ToString()}";
  }
}
