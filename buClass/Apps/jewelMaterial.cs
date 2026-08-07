// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelMaterial
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class jewelMaterial : buSerilization
{
  public double Diameter = 30.0;
  public double MajorDiameter = 20.0;
  public double MinorDiameter = 10.0;
  public double EllipseCircumference = 100.0;
  public double Width = 20.0;
  public double StartSpaceX = 0.0;
  public double EndSpaceX = 0.0;
  public double SpaceY = 0.0;
  public bool MoveEnable = false;
  public bool ReadSurfaceEnable = false;
  public jewelCurveType CurveType = jewelCurveType.Flat;
  public jewelMaterialShapeType ShapeType = jewelMaterialShapeType.Circle;
  public double CurveRadius = 0.0;

  public jewelMaterial()
  {
  }

  public jewelMaterial(jewelMaterial data)
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
    return $"Dia: {this.Diameter.ToString()}  -  Width: {this.Width.ToString()}  -  Curve Rad: {this.CurveRadius.ToString()}";
  }
}
