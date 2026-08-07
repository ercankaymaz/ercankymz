// Decompiled with JetBrains decompiler
// Type: buClass.MaterialBase
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class MaterialBase : buSerilization
{
  public string Name = "Material";
  public List<Pnt3D> Points = new List<Pnt3D>();
  public SolidItemDisplay Display = new SolidItemDisplay(Color.Linen, 100, Color.Brown, 200);
  public Pnt3D StartPoint = new Pnt3D();
  public SizeObject Size = new SizeObject(400.0, 200.0, 25.0);
  public MaterialShapes Shapes = MaterialShapes.Rectangle;
  public bool Enable = true;
  public double Width = 200.0;
  public double Height = 100.0;
  public double Thickness = 10.0;
  public double Angle = 0.0;
  public double Radius = 100.0;
  public double MajorRadius = 100.0;
  public double MinorRadius = 50.0;
  public bool TopIsZeroPosition = false;
  public List<eEntities> Entities = new List<eEntities>();

  public MaterialBase()
  {
  }

  public MaterialBase(MaterialBase mat)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) mat, ref CopiedClass);
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
    this.Display = new SolidItemDisplay(mat.Display);
    this.Size = new SizeObject(mat.Size);
    this.Points.Clear();
    Pnt3D.Copy(mat.Points, ref this.Points);
    this.Entities.Clear();
    this.Entities = new List<eEntities>();
    eEntities.CopyEntities(mat.Entities, ref this.Entities);
  }

  public MaterialBase(SizeObject size) => this.Size = new SizeObject(size);

  public override string ToString()
  {
    return $"{this.Name} , Color: {this.Display.SkinColor.ToString()}, Size: {this.Size.ToString()}";
  }
}
