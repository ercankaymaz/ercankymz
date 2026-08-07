// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillFindTool
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillFindTool : buSerilization5
{
  public Color RotationMoreThen180;
  public LengthUnit UnitLength;
  public SpeedUnit UnitSpeed;
  public ProfileOperationWindowType OperationWindow;
  public ProfileOperationWindowCloseType OperationWindowClose;
  public static byte f003DC8;
  public double WaveFormPyramidShapeHeight;
  public double WaveFormPyramidShapeWidth;
  public double WaveFormPyramidShapeBaseHeight;
  public double WaveFormPyramidShapeCount;
  public double WaveFormVShapeHeight;
  public double WaveFormVShapeWidth;

  public abstract void m001B68();

  public DrillFindTool()
  {
    if (!buVector5.\u0001("buFoamCuttingCalc"))
      throw new RegisterException("buFoamCuttingCalc");
  }
}
