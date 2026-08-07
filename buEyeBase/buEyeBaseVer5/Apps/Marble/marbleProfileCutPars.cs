// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleProfileCutPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleProfileCutPars : buSerilization5
{
  public bool CheckMachineLimits;
  public bool CheckPartLimits;
  public bool ShowSpindleTrack;
  public bool ShowSawTrack;
  public bool DrawWoodBase;
  public bool TextFromFileAsWireframe;
  public bool CloseMenuPageAfterCommand;
  public bool ShowPartZero;
  public bool ShowStartOption;
  public bool ShowWarningList;
  public bool ShowWarningPopup;
  public bool ShowAlarmPoppup;
  public bool ShowOpenSaveButtonAtToolPage;
  public bool ShowGoToolZeroAtToolPage;
  public bool AskSpeedSawManuelStart;
  public bool AskSpeedSpindleManuelStart;
  public bool AutoUpdateToolListFromActiveTools;
  public MarbleExternalGCode GCodeConversion;
  public ImageRotateFlipType ImageRotateType;
  public MarbleCameraType CameraType;
  public MarbleToolListMode ToolListMode;
  public string CameraFileName;
  public string CompareProgramName;
  public static List<string> Captions;
  public static byte f004AB4;
  public int SC1Left;
  public int SC1Top;
  public int SC1Width;
  public int SC1Height;
  public bool SC1AutoSave;
  public bool SC1Enable;
  public int SC2Left;
  public int SC2Top;
  public int SC2Width;
  public int SC2Height;
  public bool SC2AutoSave;
  public bool SC2Enable;
  public int SC3Left;
  public int SC3Top;
  public int SC3Width;
  public int SC3Height;
  public bool SC3AutoSave;
  public bool SC3Enable;
  public int SC4Left;
  public int SC4Top;
  public int SC4Width;
  public int SC4Height;
  public bool SC4AutoSave;
  public bool SC4Enable;
  public int SC5Left;
  public int SC5Top;
  public int SC5Width;
  public int SC5Height;
  public bool SC5AutoSave;
  public bool SC5Enable;
  public static byte f004AD3;
  public MarbleMachineLatheSettings LatheSettings;
  public MarbleMachineSimultionSettings SimulationSettings;
  public MarbleMachineOptionsSettings OptionSettings;
  public double BaseWoodWidth;
  public double BaseWoodHeight;
  public double BaseWoodThickness;
  public double BaseWoodXOffset;
  public double BaseWoodYOffset;
  public double BaseWoodZOffset;
  public double MotorBlockBottomHeight;
  public static List<string> Captions;
  public static byte f004ADF;
  public MarbleMachineType MachineType;
  public bool AAxisEnable;
  public bool ServoAxisA;
  public bool ServoAxisY2;
  public bool GantryY2Parallel;
  public bool AllAbsoluteEncoder;
  public int DigitalInputCount;
  public int DigitalOutputCount;
  public bool CameraEnable;
  public bool CameraCover;
  public bool SlabThicknessEnable;
  public bool ToolMeasureEnable;
  public bool MillingEnable;
  public bool MillingHeadEnable;
  public bool AutoToolChanger;
  public bool VacuumEnable;
  public bool TableEnable;
  public bool LubricationEnable;
  public bool RTCPEnable;
  public bool CrouseControlEnable;
  public bool PensEnable;

  public abstract void m001EF0();

  public marbleProfileCutPars()
  {
    ((MarbleRuntimeSettings) this).Panels = new List<NestingPanel>();
    ((MarbleRuntimeSettings) this).usedParts = new List<buNestingPart>();
    ((MarbleRuntimeSettings) this).Parts = new List<Rectangle2D>();
    ((MarbleRuntimeSettings) this).Sheets = new List<Rectangle2D>();
    ((MarbleRuntimeSettings) this).SimulationMoves = new List<PanelCutMove>();
    ((MarbleRuntimeSettings) this).SimulationCodes = new List<string>();
    ((MarbleRuntimeSettings) this).MovingEntities = new List<buEntity>();
    ((MarbleRuntimeSettings) this).WaitingAssembly = new List<PanelWaitAssembly>();
    ((MarbleRuntimeSettings) this).DoneParts = new List<PanelDonePart>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleProfileCutPars(NestingPanelJob data)
  {
    ((MarbleRuntimeSettings) this).Panels = new List<NestingPanel>();
    ((MarbleRuntimeSettings) this).usedParts = new List<buNestingPart>();
    ((MarbleRuntimeSettings) this).Parts = new List<Rectangle2D>();
    ((MarbleRuntimeSettings) this).Sheets = new List<Rectangle2D>();
    ((MarbleRuntimeSettings) this).SimulationMoves = new List<PanelCutMove>();
    ((MarbleRuntimeSettings) this).SimulationCodes = new List<string>();
    ((MarbleRuntimeSettings) this).MovingEntities = new List<buEntity>();
    ((MarbleRuntimeSettings) this).WaitingAssembly = new List<PanelWaitAssembly>();
    ((MarbleRuntimeSettings) this).DoneParts = new List<PanelDonePart>();
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

  public marbleProfileCutPars()
  {
    ((MarbleRuntimeSettings) this).Nodes = new List<NestingPanelNode>();
    ((MarbleRuntimeSettings) this).CalculatedRectangles = new List<Rectangle2D>();
    ((MarbleRuntimeSettings) this).PanelCodes = new List<string>();
    ((MarbleRuntimeSettings) this).Count = 0;
    ((MarbleRuntimeSettings) this).PartCount = 0;
    ((MarbleRuntimeSettings) this).PanelArea = 0.0;
    ((MarbleRuntimeSettings) this).PartsArea = 0.0;
    ((MarbleRuntimeSettings) this).TotalCutLength = 0.0;
    ((MarbleRuntimeSettings) this).Waste = 0.0;
    ((MarbleRuntimeSettings) this).Width = 0.0;
    ((MarbleRuntimeSettings) this).Height = 0.0;
    ((MarbleRuntimeSettings) this).Depth = 18.0;
    ((MarbleRuntimeSettings) this).Explanation = "";
    ((MarbleRuntimeSettings) this).Material = "Default";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleProfileCutPars(NestingPanel data)
  {
    ((MarbleRuntimeSettings) this).Nodes = new List<NestingPanelNode>();
    ((MarbleRuntimeSettings) this).CalculatedRectangles = new List<Rectangle2D>();
    ((MarbleRuntimeSettings) this).PanelCodes = new List<string>();
    ((MarbleRuntimeSettings) this).Count = 0;
    ((MarbleRuntimeSettings) this).PartCount = 0;
    ((MarbleRuntimeSettings) this).PanelArea = 0.0;
    ((MarbleRuntimeSettings) this).PartsArea = 0.0;
    ((MarbleRuntimeSettings) this).TotalCutLength = 0.0;
    ((MarbleRuntimeSettings) this).Waste = 0.0;
    ((MarbleRuntimeSettings) this).Width = 0.0;
    ((MarbleRuntimeSettings) this).Height = 0.0;
    ((MarbleRuntimeSettings) this).Depth = 18.0;
    ((MarbleRuntimeSettings) this).Explanation = "";
    ((MarbleRuntimeSettings) this).Material = "Default";
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
}
