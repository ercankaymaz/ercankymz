// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleDisplaySettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleDisplaySettings : buSerilization5
{
  public static MarbleCommands Commands;
  public static MarbleCountertopEdgeCommandTypes CountertopEdgeType;
  public static MarbleCountertopCornerTypes CountertopCornerType;
  public static MarbleOperationPageMode OperationageMode;
  public static int ItemID;
  public static int MarbleCamID;
  public static int MarbleEdgeID;
  public static int MarbleStripID;
  public static int LastSelectedTabPage;
  public static int AxesNumber;
  public static bool isDialogItem;
  public static bool DontChangeValuesAtOperations;
  public static bool HorizontalSetStartPositionDone;

  public MarbleDisplaySettings()
  {
    ((MarbleRuntimeSettings) this).LeftDistance = 0.0;
    ((MarbleRuntimeSettings) this).RightDistance = 0.0;
    ((MarbleRuntimeSettings) this).IndexOpertion = 0;
    ((MarbleRuntimeSettings) this).UseTopPlane = false;
    ((MarbleRuntimeSettings) this).ClamperWidth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleDisplaySettings(OperationInsideClampers data)
  {
    ((MarbleRuntimeSettings) this).LeftDistance = 0.0;
    ((MarbleRuntimeSettings) this).RightDistance = 0.0;
    ((MarbleRuntimeSettings) this).IndexOpertion = 0;
    ((MarbleRuntimeSettings) this).UseTopPlane = false;
    ((MarbleRuntimeSettings) this).ClamperWidth = 0.0;
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

  public MarbleDisplaySettings(double leftDis, double rightDis)
  {
    ((MarbleRuntimeSettings) this).LeftDistance = 0.0;
    ((MarbleRuntimeSettings) this).RightDistance = 0.0;
    ((MarbleRuntimeSettings) this).IndexOpertion = 0;
    ((MarbleRuntimeSettings) this).UseTopPlane = false;
    ((MarbleRuntimeSettings) this).ClamperWidth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MarbleRuntimeSettings) this).RightDistance = rightDis;
    ((MarbleRuntimeSettings) this).LeftDistance = leftDis;
  }

  public MarbleDisplaySettings(double leftDis, double rightDis, double clamperwidth)
  {
    ((MarbleRuntimeSettings) this).LeftDistance = 0.0;
    ((MarbleRuntimeSettings) this).RightDistance = 0.0;
    ((MarbleRuntimeSettings) this).IndexOpertion = 0;
    ((MarbleRuntimeSettings) this).UseTopPlane = false;
    ((MarbleRuntimeSettings) this).ClamperWidth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MarbleRuntimeSettings) this).RightDistance = rightDis;
    ((MarbleRuntimeSettings) this).LeftDistance = leftDis;
    ((MarbleRuntimeSettings) this).ClamperWidth = clamperwidth;
  }

  public override string ToString()
  {
    return $"RightDistance: {((MarbleRuntimeSettings) this).RightDistance.ToString()} - LeftDistance: {((MarbleRuntimeSettings) this).LeftDistance.ToString()}";
  }
}
