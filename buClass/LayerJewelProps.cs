// Decompiled with JetBrains decompiler
// Type: buClass.LayerJewelProps
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using buClass.Apps;
using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LayerJewelProps : buSerilization
{
  public double Depth = 0.0;
  public string ModeName = "";
  public JewelVar JewelMode = new JewelVar();
  public int ModeIndex = 0;

  public LayerJewelProps()
  {
  }

  public LayerJewelProps(LayerJewelProps data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    this.JewelMode = new JewelVar(data.JewelMode);
  }

  public override string ToString()
  {
    return $"Mode Name : {this.JewelMode.ModeName} -  Depth : {this.Depth.ToString()}";
  }
}
