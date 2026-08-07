// Decompiled with JetBrains decompiler
// Type: buClass.FindInternalEntitiesFromContourSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

public class FindInternalEntitiesFromContourSettings : buSerilization
{
  public bool CurveCheckBoxsizeCover = true;
  public bool CurveCheckIntersections = true;
  public bool GetTextStrings = true;
  public bool TextCheckBoxsizeCover = false;
  public bool TextForInsertionPoint = true;
  public bool AddPoint = false;
  public bool UseEntityInfoData = false;
  public string refEntityInfoData = "";
  public List<string> InnerEntitiesLayerName = new List<string>();

  public FindInternalEntitiesFromContourSettings()
  {
  }

  public FindInternalEntitiesFromContourSettings(FindInternalEntitiesFromContourSettings data)
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
