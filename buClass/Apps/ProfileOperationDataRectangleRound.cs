// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperationDataRectangleRound
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataRectangleRound : buSerilization
{
  public double RoundRectangleWidth = 20.0;
  public double RoundRectangleHeight = 20.0;
  public double RoundRectangleRadius = 2.0;
  public double RoundRectangleAngle = 0.0;
  public Color RoundRectangleColor = Color.Blue;
  public double RoundRectangleThickness = 1.0;

  public ProfileOperationDataRectangleRound()
  {
  }

  public ProfileOperationDataRectangleRound(ProfileOperationDataRectangleRound data)
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
    return $"Width : {this.RoundRectangleWidth.ToString()} - Height : {this.RoundRectangleHeight.ToString()} - Radius : {this.RoundRectangleRadius.ToString()}";
  }
}
