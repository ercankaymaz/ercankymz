// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.RobotItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

public class RobotItem : buSerilization5
{
  public const MarbleOperationSequence waterJet = ; // Unable to render the field
  public const MarbleOperationSequence RestCutting = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const MarbleCamAreaMode Level = ; // Unable to render the field

  public override string ToString()
  {
    return "colorItem: " + ((marbleSlicesPars) this).colorItem.ToString();
  }
}
