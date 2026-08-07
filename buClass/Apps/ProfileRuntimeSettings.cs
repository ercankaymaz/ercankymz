// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileRuntimeSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileRuntimeSettings : buSerilization
{
  public double NewProfileWidth = 100.0;
  public double NewProfileHeight = 100.0;
  public double NewProfileThickness = 2.0;
  public double SimStep = 2.0;
  public double ClamperMoveStep = 10.0;
  public int DrawingeLayerIndex = 0;
  public int OperationWireframeLayerIndex = 1;
  public int AuxLayerIndex = 2;
  public int SupportBlockLayerIndex = 3;
  public int OperationPlaneLayerIndex = 4;
  public int CamLayerIndex = 5;
  public int OperationSolidLayerIndex = 7;
  public int ProfileLayerIndex = 8;
  public double PatternCopyDistance = 100.0;
  public double PatternCopyCutSpace = 4.0;
  public int PatternCopyCount = 1;
  public bool PatternShowSeperators = true;
  public double ProfileLength = 1000.0;
  public int ProfileMaxClamper = 4;
  public ProfileMacroOpenSave MacroSaveOpen = new ProfileMacroOpenSave();

  public ProfileRuntimeSettings()
  {
  }

  public ProfileRuntimeSettings(ProfileRuntimeSettings data)
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
    this.MacroSaveOpen = new ProfileMacroOpenSave(data.MacroSaveOpen);
  }
}
