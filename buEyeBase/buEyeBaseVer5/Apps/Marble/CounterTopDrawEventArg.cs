// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.CounterTopDrawEventArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class CounterTopDrawEventArg
{
  public double RotationAngle;
  public double FinishPlungeFeed;

  public static void Copy(MarbleItemSettings refCam, ref MarbleItemSettings copiedCam)
  {
    if (refCam == null)
      return;
    copiedCam = (MarbleItemSettings) new buLogMarbleVer5(refCam);
  }

  public override string ToString()
  {
    string str1 = "";
    if (((MarbleMachineSimultionSettings) this).WireEntities != null)
      str1 = $"Wire: {((MarbleMachineSimultionSettings) this).WireEntities.Count.ToString()} ";
    int count;
    if (((MarbleMachineSimultionSettings) this).BorderEntities != null)
    {
      string str2 = str1;
      count = ((MarbleMachineSimultionSettings) this).BorderEntities.Count;
      string str3 = count.ToString();
      str1 = $"{str2}Border: {str3} ";
    }
    if (((MarbleMachineSimultionSettings) this).ConcaveEntities != null)
    {
      string str4 = str1;
      count = ((MarbleMachineSimultionSettings) this).ConcaveEntities.Count;
      string str5 = count.ToString();
      str1 = $"{str4}Concave: {str5} ";
    }
    if (((MarbleMachineSimultionSettings) this).EngravingEntities != null)
    {
      string str6 = str1;
      count = ((MarbleMachineSimultionSettings) this).EngravingEntities.Count;
      string str7 = count.ToString();
      str1 = $"{str6}Engrave: {str7} ";
    }
    if (((MarbleMachineSimultionSettings) this).DrillEntities != null)
    {
      string str8 = str1;
      count = ((MarbleMachineSimultionSettings) this).DrillEntities.Count;
      string str9 = count.ToString();
      str1 = $"{str8}Drill: {str9} ";
    }
    return str1;
  }
}
