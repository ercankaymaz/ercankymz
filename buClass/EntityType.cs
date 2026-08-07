// Decompiled with JetBrains decompiler
// Type: buClass.EntityType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class EntityType : buSerilization
{
  public bool AllWireframes = true;
  public bool Line = true;
  public bool Polyline = true;
  public bool Arc = true;
  public bool Circle = true;
  public bool Ellipse = true;
  public bool Bspline = true;
  public bool Bezeir = true;
  public bool Point = true;
  public bool Picture = true;
  public bool Text = true;
  public bool Surface = true;

  public EntityType()
  {
  }

  public EntityType(bool AllWireframe)
  {
    this.AllWireframes = true;
    this.Line = true;
    this.Polyline = true;
    this.Arc = true;
    this.Circle = true;
    this.Ellipse = true;
    this.Bspline = true;
    this.Bezeir = true;
    this.Point = true;
    this.Picture = false;
    this.Text = false;
    this.Surface = false;
  }

  public EntityType(EntityType data)
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
