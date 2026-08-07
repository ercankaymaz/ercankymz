// Decompiled with JetBrains decompiler
// Type: buClass.Apps.LaserRouterRuntimeSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class LaserRouterRuntimeSettings : buSerilization
{
  public int SelectedMaterial = -1;
  public bool VerticalSelection = false;
  public bool HorizontalSelection = false;
  public bool AngleSelection = false;
  public string PathMaterialSave = Application.StartupPath;
  public string LastSelectedWoodChamferTopToolName = "";
  public string LastSelectedWoodChamferBottomToolName = "";
  public string LastSelectedPertinaxInCutToolName = "";
  public string LastSelectedPertinaxOutCutToolName = "";
  public string LastSelectedPertinaxHoleToolName = "";
  public string LastSelectedPertinaxHoleCutToolName = "";
  public string LastSelectedPertinaxTextToolName = "";
  public string LastSelectedSteelContourToolName = "";
  public string LastSelectedSteelPocketToolName = "";
  public string LastSelectedSteelTextToolName = "";

  public LaserRouterRuntimeSettings()
  {
  }

  public LaserRouterRuntimeSettings(LaserRouterRuntimeSettings data)
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

  public static void Copy(LaserRouterRuntimeSettings Source, ref LaserRouterRuntimeSettings Target)
  {
    Target = new LaserRouterRuntimeSettings(Source);
  }

  public override string ToString() => "Sel Mat : " + this.SelectedMaterial.ToString();
}
