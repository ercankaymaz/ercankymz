// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelCamMCode
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class jewelCamMCode : buSerilization
{
  public ArrayList SpinldeStartMCode = new ArrayList();
  public ArrayList SpinldeEndMCode = new ArrayList();
  public ArrayList KalemStartMCode = new ArrayList();
  public ArrayList KalemEndMCode = new ArrayList();
  public ArrayList GroupStartMCode = new ArrayList();
  public ArrayList GroupEndMCode = new ArrayList();
  public ArrayList FileStartMCode = new ArrayList();
  public ArrayList FileEndMCode = new ArrayList();

  public jewelCamMCode()
  {
  }

  public jewelCamMCode(jewelCamMCode data)
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
    this.SpinldeStartMCode.Clear();
    this.SpinldeStartMCode.AddRange((ICollection) data.SpinldeStartMCode);
    this.SpinldeEndMCode.Clear();
    this.SpinldeEndMCode.AddRange((ICollection) data.SpinldeEndMCode);
    this.KalemStartMCode.Clear();
    this.KalemStartMCode.AddRange((ICollection) data.KalemStartMCode);
    this.KalemEndMCode.Clear();
    this.KalemEndMCode.AddRange((ICollection) data.KalemEndMCode);
    this.GroupStartMCode.Clear();
    this.GroupStartMCode.AddRange((ICollection) data.GroupStartMCode);
    this.GroupEndMCode.Clear();
    this.GroupEndMCode.AddRange((ICollection) data.GroupEndMCode);
    this.FileStartMCode.Clear();
    this.FileStartMCode.AddRange((ICollection) data.FileStartMCode);
    this.FileEndMCode.Clear();
    this.FileEndMCode.AddRange((ICollection) data.FileEndMCode);
  }
}
