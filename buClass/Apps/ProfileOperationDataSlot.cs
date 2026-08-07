// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperationDataSlot
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataSlot : buSerilization
{
  public double SlotWidth = 50.0;
  public double SlotDiameter = 10.0;
  public double SlotAngle = 0.0;
  public Color SlotColor = Color.Blue;
  public double SlotThickness = 1.0;

  public ProfileOperationDataSlot()
  {
  }

  public ProfileOperationDataSlot(ProfileOperationDataSlot data)
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
    return $"Width : {this.SlotWidth.ToString()} - Dia : {this.SlotDiameter.ToString()}";
  }
}
