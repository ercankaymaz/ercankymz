// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestedResultEventArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buNestedResultEventArg
{
  public static byte f0041A2;
  public double minXClamper;
  public double maxXClamper;
  public double minXClamperLessSafe;
  public double maxXClamperLessSafe;
  public double XMovePlus;
  public double XMoveMinus;
  public double XMovePlusLessSafe;
  public double XMoveMinusLessSafe;
  public bool DrillInClamper;
  public bool DrillInClamperLassSafe;
  public static byte f0041AD;
  [SpecialName]
  public int value__;
  public const DrillMoveCommand AxisMove = ; // Unable to render the field
  public const DrillMoveCommand SetPiston = ; // Unable to render the field
  public const DrillMoveCommand ResetPiston = ; // Unable to render the field
  public const DrillMoveCommand Finished = ; // Unable to render the field
  public const DrillMoveCommand XAxesGantyOn = ; // Unable to render the field

  public override string ToString()
  {
    return $"Top: {((DrillMachineSettings) this).lstTop.Count.ToString()} , Bottom: {((DrillMachineSettings) this).lstBottom.Count.ToString()} , Left-Right: {((DrillMachineSettings) this).lstLeftRight.Count.ToString()} , Front: {((DrillMachineSettings) this).lstFront.Count.ToString()} , Back: {((DrillMachineSettings) this).lstBack.Count.ToString()}";
  }

  public abstract void m001C28();
}
