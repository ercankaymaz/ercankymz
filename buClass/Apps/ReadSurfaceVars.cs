// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ReadSurfaceVars
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ReadSurfaceVars : buSerilization
{
  public double CValue = 0.0;
  public double ReadValue = 0.0;
  public double XValue = 0.0;
  public double YValue = 0.0;

  public ReadSurfaceVars()
  {
  }

  public ReadSurfaceVars(ReadSurfaceVars data)
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
    return $"X: {this.XValue.ToString("f5")} , Y: {this.YValue.ToString("f5")} , C: {this.CValue.ToString("f5")} , Read: {this.ReadValue.ToString("f5")}";
  }
}
