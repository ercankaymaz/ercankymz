// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerProgramSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerProgramSettings : buSerilization
{
  public int VendorType = 0;
  public bool MotionCommunicationEnable = true;
  public double CompareLevel = 0.05;
  public double SlotDiameter = 1.0;
  public bool FindSameEntities = true;
  public bool FindMirrorEntities = true;
  public bool LayerFromCf2Settings = true;
  public bool DontResetAfterOperations = true;
  public bool DrawAllEntitiesAtCuttingListPage = true;
  public static List<string> Captions = new List<string>();

  public DiemakerProgramSettings()
  {
  }

  public DiemakerProgramSettings(DiemakerProgramSettings data)
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

  public static void Copy(DiemakerProgramSettings Source, ref DiemakerProgramSettings Target)
  {
    Target = new DiemakerProgramSettings(Source);
  }

  public override string ToString() => "VendorType : " + this.VendorType.ToString();
}
