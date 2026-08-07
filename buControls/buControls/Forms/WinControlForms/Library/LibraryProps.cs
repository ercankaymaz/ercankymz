// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Library.LibraryProps
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buControls.Forms.WinControlForms.Library;

[Serializable]
public class LibraryProps : buSerilization
{
  public string Char = "";
  public string Explanation = "";
  public double Angle = 0.0;

  public LibraryProps()
  {
  }

  public LibraryProps(string chars, string explanation, double angle)
  {
    this.Angle = angle;
    this.Char = chars;
    this.Explanation = explanation;
  }

  public LibraryProps(LibraryProps Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }
}
