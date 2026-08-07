// Decompiled with JetBrains decompiler
// Type: buClass.MaterialSkin
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class MaterialSkin : buSerilization
{
  public string Name = "";
  public Color MaterialColor = Color.Gray;

  public MaterialSkin()
  {
  }

  public MaterialSkin(string name, Color color)
  {
    this.Name = name;
    this.MaterialColor = color;
  }

  public MaterialSkin(MaterialSkin mat)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) mat, ref CopiedClass);
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
