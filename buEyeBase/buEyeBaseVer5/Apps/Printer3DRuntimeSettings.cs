// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Printer3DRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DRuntimeSettings : buSerilization5
{
  public CamClosedContourType OffsetType;

  public Printer3DRuntimeSettings(CutterRuntimeSettings data)
  {
    ((buPrinter3D) this).SimStep = 1;
    ((Printer3DJob) this).ManuelSheetWidth = 1000.0;
    ((Printer3DJob) this).ManuelSheetHeight = 500.0;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static void Copy(CutterRuntimeSettings Source, ref CutterRuntimeSettings Target)
  {
    Target = (CutterRuntimeSettings) new Printer3DRuntimeSettings(Source);
  }
}
