// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingRuntimeSettings : buSerilization5
{
  public List<string> Codes;
  public List<camTp> Cams;
  public List<string> ErrorCodes;
  public MaterialBase5 Material;
  public int TotalCount;
  public int Used;
  public bool isSorted;
  public Entity panelEntity;
  public static byte f003CBC;
  public bool ShowOperationButton;
  public double MaterialHeight;
  public double MaterialWidth;
  public double MaterialDepth;
  public Color colorPanel;
  public Color colorOperation;
  public Color colorOperationDisable;
  public bool FromFileKeepRatio;

  public abstract void m001AFA();

  public SewingRuntimeSettings()
  {
    ((FoamCalcVars) this).activeJob = (PipeBendJob) null;
    ((FoamCalcVars) this).\u0001 = new Timer();
    ((FoamCalcVars) this).\u0002 = new Timer();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (!buVector5.\u0001("buPipeBendCalc"))
      throw new RegisterException("buPipeBendCalc");
  }
}
