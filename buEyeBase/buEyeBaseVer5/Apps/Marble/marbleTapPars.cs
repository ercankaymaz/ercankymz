// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleTapPars
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
public class marbleTapPars : buSerilization5
{
  public string AxisCChar;
  public string AxisY2Char;
  public bool TechnicianReportEnable;
  public bool OperationReportEnable;
  public static byte f004B07;
  public bool DrawHead;
  public bool DrawMachine;
  public bool DrawLathe;
  public bool DrawSawTool;
  public bool DrawMillingTool;
  public bool DrawMilling5AxisTool;
  public bool DrawMillingHeadTool;
  public bool DrawAirDry;

  public marbleTapPars()
  {
    ((MarbleRuntimeSettings) this).simRelease = false;
    ((MarbleRuntimeSettings) this).acliveLine = -1;
    ((MarbleRuntimeSettings) this).OffcutCount = 0;
    ((MarbleRuntimeSettings) this).layerPanel = "Panel";
    ((MarbleRuntimeSettings) this).layerOperation = "Operation";
    ((MarbleRuntimeSettings) this).layerGeneral = "General";
    ((MarbleRuntimeSettings) this).layerSelected = "Selected";
    ((MarbleRuntimeSettings) this).layerCam = "Cam";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public marbleTapPars(PanelCutTempVars data)
  {
    ((MarbleRuntimeSettings) this).simRelease = false;
    ((MarbleRuntimeSettings) this).acliveLine = -1;
    ((MarbleRuntimeSettings) this).OffcutCount = 0;
    ((MarbleRuntimeSettings) this).layerPanel = "Panel";
    ((MarbleRuntimeSettings) this).layerOperation = "Operation";
    ((MarbleRuntimeSettings) this).layerGeneral = "General";
    ((MarbleRuntimeSettings) this).layerSelected = "Selected";
    ((MarbleRuntimeSettings) this).layerCam = "Cam";
    // ISSUE: explicit constructor call
    base.\u002Ector();
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

  public abstract void m001F00();

  public marbleTapPars()
  {
    ((MarbleRuntimeSettings) this).\u0001 = "buMarbleCalc";
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (!buVector5.\u0001("buMarbleCalc"))
      throw new RegisterException("buMarbleCalc");
  }
}
