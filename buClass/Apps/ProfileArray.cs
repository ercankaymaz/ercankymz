// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileArray
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileArray : buSerilization
{
  public int CircularCount = 1;
  public int LineerCount = 1;
  public double CircularAngle = 45.0;
  public double LineerDistance = 100.0;
  public bool CircularEnable = false;
  public bool LineerEnable = false;

  public ProfileArray()
  {
  }

  public ProfileArray(ProfileArray data)
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
    return $"Lineer :{this.LineerEnable.ToString()} , Circular : {this.CircularEnable.ToString()}";
  }
}
