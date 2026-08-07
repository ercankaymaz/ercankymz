// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxMoves
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxMoves : buSerilization
{
  public double moveVelocity = 20.0;
  public double moveAcc = 1000.0;
  public double moveDec = 1000.0;
  public double moveJerk = 2500.0;
  public bool moveOverrideEnable = true;
  public bool moveDynamicVelocityFromFeed = false;
  public static List<string> Captions = new List<string>();

  public CodesysAxMoves()
  {
  }

  public CodesysAxMoves(CodesysAxMoves data)
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
    return $"Vel : {this.moveVelocity.ToString()} , Acc: {this.moveAcc.ToString()} , Dec: {this.moveDec.ToString()} , Jerk: {this.moveJerk.ToString()}";
  }

  public string ToFileString(int Version)
  {
    return $"{$"{$"{this.moveVelocity.ToString()};{this.moveAcc.ToString()};{this.moveDec.ToString()}"};{this.moveJerk.ToString()}"};{buSerilization.BoolToString(this.moveOverrideEnable)};{buSerilization.BoolToString(this.moveDynamicVelocityFromFeed)}";
  }
}
