// Decompiled with JetBrains decompiler
// Type: buClass.ToolPanelSetting
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolPanelSetting : buSerilization
{
  public bool ShowToolName = true;
  public bool ShowToolType = true;
  public bool ShowSpindleSpeed = true;
  public bool ShowFeed = true;
  public bool ShowSafeDistance = true;
  public bool ShowPurpose = true;
  public bool ShowLength = true;
  public bool ShowDiameter = true;
  public bool ShowToolInfoArea = true;
  public bool ShowToolButtonArea = true;
  public bool ShowToolPreviewArea = true;
  public static List<string> Captions = new List<string>();

  public ToolPanelSetting()
  {
  }

  public ToolPanelSetting(ToolPanelSetting info)
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

  public override string ToString() => "Name: " + this.ShowToolName.ToString();
}
