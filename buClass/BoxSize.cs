// Decompiled with JetBrains decompiler
// Type: buClass.BoxSize
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class BoxSize : buSerilization
{
  public Pnt3D MinPoint = new Pnt3D();
  public Pnt3D MaxPoint = new Pnt3D();
  public Vec3D Delta = new Vec3D();

  public BoxSize()
  {
  }

  public BoxSize(BoxSize box)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) box, ref CopiedClass);
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

  public BoxSize(Pnt3D PMin, Pnt3D PMax)
  {
    this.MinPoint = new Pnt3D(PMin);
    this.MaxPoint = new Pnt3D(PMax);
  }

  public override string ToString()
  {
    return $"dX: {this.Delta.X.ToString("f2")} , dY: {this.Delta.Y.ToString("f2")} , dZ: {this.Delta.Z.ToString("f2")}";
  }
}
