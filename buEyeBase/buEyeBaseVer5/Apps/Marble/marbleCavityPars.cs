// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCavityPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCavityPars : buSerilization5
{
  public bool AbsoluteZAxis;
  public bool AbsoluteAAxis;
  public bool AbsoluteCAxis;
  public bool WaterJet;
  public string AxisXChar;
  public string AxisYChar;
  public string AxisZChar;
  public string AxisAChar;

  public marbleCavityPars()
  {
    ((MarbleRuntimeSettings) this).simulationInterval = 10;
    ((MarbleRuntimeSettings) this).SawThickness = 0.0;
    ((MarbleRuntimeSettings) this).NestingExecuteTimeSec = 3;
    ((MarbleRuntimeSettings) this).ShowOperationButton = true;
    ((MarbleRuntimeSettings) this).CutSimDevideLen = 100.0;
    ((MarbleRuntimeSettings) this).CutSawZMoveCount = 2;
    ((MarbleRuntimeSettings) this).MaxOptimisationDepth = 0;
    ((MarbleRuntimeSettings) this).PanelThickness = 19.0;
    ((MarbleRuntimeSettings) this).PanelMaxThickness = 90.0;
    ((MarbleRuntimeSettings) this).GeneralTrimWidth = 0.0;
    ((MarbleRuntimeSettings) this).GeneralTrimHeight = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleCavityPars(PanelCutSettings data)
  {
    ((MarbleRuntimeSettings) this).simulationInterval = 10;
    ((MarbleRuntimeSettings) this).SawThickness = 0.0;
    ((MarbleRuntimeSettings) this).NestingExecuteTimeSec = 3;
    ((MarbleRuntimeSettings) this).ShowOperationButton = true;
    ((MarbleRuntimeSettings) this).CutSimDevideLen = 100.0;
    ((MarbleRuntimeSettings) this).CutSawZMoveCount = 2;
    ((MarbleRuntimeSettings) this).MaxOptimisationDepth = 0;
    ((MarbleRuntimeSettings) this).PanelThickness = 19.0;
    ((MarbleRuntimeSettings) this).PanelMaxThickness = 90.0;
    ((MarbleRuntimeSettings) this).GeneralTrimWidth = 0.0;
    ((MarbleRuntimeSettings) this).GeneralTrimHeight = 0.0;
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

  public marbleCavityPars()
  {
    ((MarbleRuntimeSettings) this).CollisionCheck = false;
    ((MarbleRuntimeSettings) this).StepRun = true;
    ((MarbleRuntimeSettings) this).SimStep = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleCavityPars(PanelCutRuntimeSettings data)
  {
    ((MarbleRuntimeSettings) this).CollisionCheck = false;
    ((MarbleRuntimeSettings) this).StepRun = true;
    ((MarbleRuntimeSettings) this).SimStep = 1;
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
