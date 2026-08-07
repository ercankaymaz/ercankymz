// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamCalcVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamCalcVars : buSerilization5
{
  public ViewportRefType ViewportRef;
  public planeBoxNames activePlane;
  public int selectedDoorIndex;
  public int selectedItemIndex;
  public static byte f003C20;
  public static LengthUnit UnitLength;
  public static SpeedUnit UnitsSpeed;
  public static List<string> LangPipeBendStatus;
  public static List<string> LangPipeBendMessage;
  public static List<string> LangPipeBendCaptions;
  public static List<string> LangPipeBendCommands;
  public static int EntityID;
  public static PipeBendingProgramSettings varPipeBendingProgramSettings;
  public static PipeBendTempVars varTemps;
  public static PipeBendSettings varPipeBendingSettings;
  public static PipeBendRuntimeSettings varPipeBendingRunSettings;
  public static List<PipeBendDiskBlocks> DiskBlocks;
  public PipeBendJob activeJob;
  public static F_BendingRotaryDisk frmDiskBlocks;
  private readonly Timer \u0001;
  private readonly Timer \u0002;
  public static string UnlockString;

  public static void Decode(ArrayList AL, ref FoamItem Item)
  {
  }

  public override string ToString() => ((FoamCreatePanelOptions) this).ItemName.ToString();
}
