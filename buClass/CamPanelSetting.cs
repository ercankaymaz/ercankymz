// Decompiled with JetBrains decompiler
// Type: buClass.CamPanelSetting
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CamPanelSetting : buSerilization
{
  public bool ShowCamName = true;
  public bool ShowTool = true;
  public bool ShowCamType = true;
  public bool ShowProcessTime = true;
  public bool ShowTotalLength = true;
  public bool ShowCamInfoArea = true;
  public bool ShowCamButtonArea = true;
  public bool ShowCamSimulationArea = true;
  public static List<string> Captions = new List<string>();

  public CamPanelSetting()
  {
  }

  public CamPanelSetting(CamPanelSetting info)
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

  public override string ToString() => "Name: " + this.ShowCamName.ToString();
}
