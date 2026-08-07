// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxSets
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxSets : buSerilization
{
  public double setUnit = 5.0;
  public double setPulse = 50001.0;
  public double setGearRatio = 1.0;
  public bool setReverseDirection = false;
  public double setEmergencyDec = 50000.0;
  public double setMaxVelocity = 100.0;
  public double setMaxAcc = 10000.0;
  public double setMaxDec = 10000.0;
  public double setMaxJerk = 20000.0;
  public CodesysRampType setRampType = CodesysRampType.QuadraticRamp;
  public bool setSoftLimitEnable = false;
  public bool setSoftLimitControlFromPLC = false;
  public double setSoftLimitPositive = 0.0;
  public double setSoftLimitNegative = 0.0;
  public bool setSoftLimitErrorDecEnable = false;
  public double setSoftLimitErrorDec = 10000.0;
  public double setSoftLimitErrorMaxDistance = 1.0;
  public bool setHardLimitEnable = false;
  public double setDataLimitPositive = 0.0;
  public double setDataLimitNegative = 0.0;
  public double setParkPosition = 0.0;
  public bool setGantryEnable = false;
  public int setGantryNumerator = 1;
  public int setGantryDenumerator = 1;
  public double setPositionDoneLimit = 0.002;
  public CodesysMovementType setAxesType = CodesysMovementType.Linear;
  public static List<string> Captions = new List<string>();

  public CodesysAxSets()
  {
  }

  public CodesysAxSets(CodesysAxSets data)
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

  public override string ToString()
  {
    return $"Unit: {this.setUnit.ToString()} ; setPulse: {this.setPulse.ToString()}";
  }

  public string ToFileString(int Version)
  {
    return $"{$"{$"{$"{$"{$"{$"{$"{this.setUnit.ToString()};{this.setPulse.ToString()};{this.setGearRatio.ToString()}"};{buSerilization.BoolToString(this.setReverseDirection)};{this.setEmergencyDec.ToString()};{this.setMaxVelocity.ToString()}"};{this.setMaxAcc.ToString()};{this.setMaxDec.ToString()};{this.setMaxJerk.ToString()}"};{Convert.ToInt32((object) this.setRampType).ToString()};{buSerilization.BoolToString(this.setSoftLimitEnable)};{buSerilization.BoolToString(this.setSoftLimitControlFromPLC)}"};{this.setSoftLimitPositive.ToString()};{this.setSoftLimitNegative.ToString()};{buSerilization.BoolToString(this.setSoftLimitErrorDecEnable)}"};{this.setSoftLimitErrorDec.ToString()};{this.setSoftLimitErrorMaxDistance.ToString()};{buSerilization.BoolToString(this.setHardLimitEnable)}"};{this.setDataLimitPositive.ToString()};{this.setDataLimitNegative.ToString()};{this.setParkPosition.ToString()}"};{buSerilization.BoolToString(this.setGantryEnable)};{this.setGantryNumerator.ToString()};{this.setGantryDenumerator.ToString()};{this.setPositionDoneLimit.ToString()}";
  }
}
