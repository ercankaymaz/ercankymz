// Decompiled with JetBrains decompiler
// Type: buClass.SolidItemDisplay
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SolidItemDisplay : buSerilization
{
  public Color BorderColor = Color.Brown;
  public int BorderTransperancy = 200;
  public Color SkinColor = Color.Linen;
  public int SkinTransperancy = 100;

  public SolidItemDisplay()
  {
  }

  public SolidItemDisplay(
    Color skinColor,
    int skinTransperancy,
    Color borderColor,
    int borderTransperancy)
  {
    this.BorderColor = borderColor;
    this.BorderTransperancy = borderTransperancy;
    this.SkinColor = skinColor;
    this.SkinTransperancy = skinTransperancy;
  }

  public SolidItemDisplay(SolidItemDisplay disp)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) disp, ref CopiedClass);
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
    return $"Skin Color : {this.SkinColor.ToString()} - Tranparancy: {this.SkinTransperancy.ToString()}";
  }
}
