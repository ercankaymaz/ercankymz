// Decompiled with JetBrains decompiler
// Type: buClass.Apps.GrindingPin
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class GrindingPin : buSerilization
{
  public double Diameter = 10.0;
  public double Height = 10.0;
  public double Thickness = 10.0;
  public Pnt3D Position = new Pnt3D();
  public int ID = 0;

  public GrindingPin()
  {
  }

  public GrindingPin(double diameter, double height, double thickness, Pnt3D position, int id)
  {
    this.Diameter = diameter;
    this.Height = height;
    this.Thickness = thickness;
    this.ID = id;
    this.Position = new Pnt3D(position);
  }

  public GrindingPin(GrindingPin data)
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
}
