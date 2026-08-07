// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ArcDevideByRadius
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ArcDevideByRadius : buSerilization
{
  public double Radius;
  public double DevideLength;

  public ArcDevideByRadius()
  {
  }

  public ArcDevideByRadius(double Radius_, double DevideLength_)
  {
    this.Radius = Radius_;
    this.DevideLength = DevideLength_;
  }

  public ArcDevideByRadius(ArcDevideByRadius data)
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
    return $"Radius: {this.Radius.ToString("f2")} -  DevideLength: {this.DevideLength.ToString("f4")}";
  }
}
