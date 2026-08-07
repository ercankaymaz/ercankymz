// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.RobotPose
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RobotPose : buSerilization5
{
  public const MarbleSawCornerCleanMode FullCurvature = ; // Unable to render the field
  public const MarbleSawCornerCleanMode FitArc = ; // Unable to render the field
  public const MarbleSawCornerCleanMode FitLine = ; // Unable to render the field
  public const MarbleSawCornerCleanMode FitCircular = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const MarbleOperationSelectionCommand None = ; // Unable to render the field
  public const MarbleOperationSelectionCommand Item = ; // Unable to render the field
  public const MarbleOperationSelectionCommand Operation = ; // Unable to render the field
  public const MarbleOperationSelectionCommand Wire = ; // Unable to render the field

  public static void Copy(MarbleControlColorSettings Source, ref MarbleControlColorSettings Target)
  {
    Target = (MarbleControlColorSettings) new RobotToolPath(Source);
  }

  public override string ToString()
  {
    return "colorDataFocus: " + ((marbleMatrialCleanPars) this).colorDataFocus.ToString();
  }

  static RobotPose() => marbleMatrialCleanPars.Captions = new List<string>();

  public RobotPose()
  {
    ((marbleMatrialCleanPars) this).SolidOnlineDrawDeviation = 5.0;
    ((marbleMatrialCleanPars) this).WireframeOnlineDrawZOffset = 2.0;
    ((marbleMatrialCleanPars) this).DirectionArrowZOffset = 2.0;
    ((marbleMatrialCleanPars) this).DirectionArrowWidth = 40.0;
    ((marbleMatrialCleanPars) this).DirectionArrowHeight = 16.0;
    ((marbleMatrialCleanPars) this).CamLeavePlungeAsArrowDraw = true;
    ((marbleMatrialCleanPars) this).CamArrowConeLength = 5.0;
    ((marbleMatrialCleanPars) this).CamArrowBodyDiameter = 2.0;
    ((marbleSurfaceCleanPars) this).CamArrowConeDiameter = 3.0;
    ((marbleSurfaceCleanPars) this).DrawMaterialDimension = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public RobotPose(MarbleDrawingSetting data)
  {
    ((marbleMatrialCleanPars) this).SolidOnlineDrawDeviation = 5.0;
    ((marbleMatrialCleanPars) this).WireframeOnlineDrawZOffset = 2.0;
    ((marbleMatrialCleanPars) this).DirectionArrowZOffset = 2.0;
    ((marbleMatrialCleanPars) this).DirectionArrowWidth = 40.0;
    ((marbleMatrialCleanPars) this).DirectionArrowHeight = 16.0;
    ((marbleMatrialCleanPars) this).CamLeavePlungeAsArrowDraw = true;
    ((marbleMatrialCleanPars) this).CamArrowConeLength = 5.0;
    ((marbleMatrialCleanPars) this).CamArrowBodyDiameter = 2.0;
    ((marbleSurfaceCleanPars) this).CamArrowConeDiameter = 3.0;
    ((marbleSurfaceCleanPars) this).DrawMaterialDimension = false;
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
