// Decompiled with JetBrains decompiler
// Type: buClass.LaserMaterial
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LaserMaterial : buSerilization
{
  public string Name = "Mat";
  public List<LaserMaterialData> Orders = new List<LaserMaterialData>();

  public LaserMaterial()
  {
  }

  public LaserMaterial(LaserMaterial data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    this.Orders = new List<LaserMaterialData>();
    for (int index = 0; index <= data.Orders.Count - 1; ++index)
      this.Orders.Add(new LaserMaterialData(data.Orders[index]));
  }

  public static void Copy(LaserMaterial Base, ref LaserMaterial Copied)
  {
    Copied = new LaserMaterial(Base);
  }

  public static void Copy(List<LaserMaterial> Base, ref List<LaserMaterial> Copied)
  {
    Copied.Clear();
    Copied = new List<LaserMaterial>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      Copied.Add(new LaserMaterial(Base[index]));
  }

  public override string ToString() => "Name: " + this.Name.ToString();
}
