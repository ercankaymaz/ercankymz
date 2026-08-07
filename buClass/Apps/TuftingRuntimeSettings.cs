// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TuftingRuntimeSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TuftingRuntimeSettings : buSerilization
{
  public int SelectedLayerIndex = 0;
  public string SelectedLayerName = "";
  public string ArrowDirLayerName = "";
  public bool BreakTuftCurve = false;
  public bool DirectionArrowAllLayer = true;
  public bool DirectionArrowSelectedLayer = true;
  public bool ShowSortedAllLayer = false;
  public bool ShowSortedSelectedLayer = false;
  public bool LineAsBorderLine = true;
  public string pathGCode = Application.StartupPath;
  public bool ThisIsTuftingOperation = false;

  public TuftingRuntimeSettings()
  {
  }

  public TuftingRuntimeSettings(TuftingRuntimeSettings data)
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

  public override string ToString() => "Layer Index: " + this.SelectedLayerIndex.ToString();
}
