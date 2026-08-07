// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleImageSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleImageSettings : buSerilization5
{
  public static List<int> LastSelectedEntitiesList;
  public static List<buEntity> SweepZFormEntities;
  public static MarbleCountertopModes CountertopMode;
  public static MarbleToolType ActiveSimulationToolType;

  public abstract void m001EC2();

  public MarbleImageSettings()
  {
    ((MarbleRuntimeSettings) this).MirrorEnable = false;
    ((MarbleRuntimeSettings) this).MirrorAxis = MirrorAxisXYType.X;
    ((MarbleRuntimeSettings) this).MirrorLocation = MinCenterMaxType.Min;
    ((MarbleRuntimeSettings) this).MirrorDistance = 0.0;
    ((MarbleRuntimeSettings) this).Mode = MirrorModeType.FromCenter;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleImageSettings(ProfileMirror data)
  {
    ((MarbleRuntimeSettings) this).MirrorEnable = false;
    ((MarbleRuntimeSettings) this).MirrorAxis = MirrorAxisXYType.X;
    ((MarbleRuntimeSettings) this).MirrorLocation = MinCenterMaxType.Min;
    ((MarbleRuntimeSettings) this).MirrorDistance = 0.0;
    ((MarbleRuntimeSettings) this).Mode = MirrorModeType.FromCenter;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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

  public override string ToString()
  {
    return $"MirrorEnable :{((MarbleRuntimeSettings) this).MirrorEnable.ToString()} , MirrorAxis : {((MarbleRuntimeSettings) this).MirrorAxis.ToString()}";
  }

  public abstract void m001EC6();
}
