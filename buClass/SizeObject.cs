// Decompiled with JetBrains decompiler
// Type: buClass.SizeObject
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SizeObject : buSerilization
{
  public double Width;
  public double Height;
  public double Depth;

  public SizeObject()
  {
  }

  public SizeObject(double width, double height, double depth)
  {
    this.Width = width;
    this.Height = height;
    this.Depth = depth;
  }

  public SizeObject(SizeObject size)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) size, ref CopiedClass);
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
    return $"W: {this.Width.ToString()} - H: {this.Height.ToString()} - D: {this.Depth.ToString()}";
  }
}
