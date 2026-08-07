// Decompiled with JetBrains decompiler
// Type: buClass.PagePanelSetting
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class PagePanelSetting : buSerilization
{
  public bool ShowPageName = true;
  public bool ShowSceneName = true;
  public bool ShowEntityCount = true;
  public bool ShowPlane = true;
  public bool ShowPageInfoArea = true;
  public bool ShowPageButtonArea = true;
  public static List<string> Captions = new List<string>();

  public PagePanelSetting()
  {
  }

  public PagePanelSetting(PagePanelSetting info)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) info, ref CopiedClass);
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

  public override string ToString() => "Name: " + this.ShowPageName.ToString();
}
