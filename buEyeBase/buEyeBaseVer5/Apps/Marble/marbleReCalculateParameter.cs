// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleReCalculateParameter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleReCalculateParameter : buSerilization5
{
  public bool selectedPhotoEdit;
  public bool selectedSheetEdit;
  public bool HorReverseCut;
  public bool VerReverseCut;
  public bool SliceHorStartCut;
  public bool SliceHorEndCut;
  public bool SliceVerStartCut;
  public bool SliceVerEndCut;

  public marbleReCalculateParameter(PanelEntityData data)
  {
    ((MarbleRuntimeSettings) this).Depth = 0;
    ((MarbleRuntimeSettings) this).XIndex = -1;
    ((MarbleRuntimeSettings) this).YIndex = -1;
    ((MarbleRuntimeSettings) this).Note = "";
    ((MarbleRuntimeSettings) this).NodeID = -1;
    ((MarbleRuntimeSettings) this).NodeType = nestPanelNodeType.Assembly;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public abstract void m001EEA();
}
