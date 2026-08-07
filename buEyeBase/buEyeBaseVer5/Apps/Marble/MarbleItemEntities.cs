// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleItemEntities
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemEntities : buSerilization5
{
  public Color GhostClamperColor;
  public int GhostClamperTransparency;
  public int NotchToolNo;
  public double NotchMinSpeed;
  public double NotchMaxSpeed;
  public double MillingToolMaxSpeed;
  public double ProfileMaxLength;
  public double ProfileMaxWidth;
  public double ProfileMaxHeight;
  public double PlaneMoveSafeDistance;
  public bool ProfileAddWidthHeightReadOnly;
  public bool ChangeAAxisWhileMoveBetweenPlanes;
  public double TopOperationClamperMoveZValue;
  public bool AutoPeckingAddDefault;
  public double AutoPeckingUpDefaultDistance;
  public bool RightProfileMakeAsMirror;
  public bool AllGCodeAsG1;
  public bool UseUndoBuffer;
  public bool OperationFrontBackMirrorYDirToAnotherPlane;
  public bool ShowProfileAngleDrawing;
  public bool RemoveProfileAngle;

  public override string ToString()
  {
    string str = $"XPos: {((PanelCutMoveCommand) this).XPosition.ToString("f3")} , MinX: {((buMarbleCalc) this).GeometrixMinX.ToString()} , MaxX: {((buMarbleCalc) this).GeometrixMaxX.ToString()} , Used: {((buMarbleCalc) this).Used.ToString()}";
    if (((buMarbleCalc) this).isCollision)
      str += " Collision";
    return str;
  }

  public static void Copy(List<ProfileClamper> RefClamper, ref List<ProfileClamper> CopiedClamper)
  {
    CopiedClamper.Clear();
    CopiedClamper = new List<ProfileClamper>();
    for (int index = 0; index <= RefClamper.Count - 1; ++index)
    {
      ProfileClamper CopiedClamper1 = (ProfileClamper) new MarbleVacuumCut();
      MarbleItemEntities.Copy(RefClamper[index], ref CopiedClamper1);
      CopiedClamper.Add(CopiedClamper1);
    }
  }

  public static void Copy(ProfileClamper RefClamper, ref ProfileClamper CopiedClamper)
  {
    CopiedClamper = (ProfileClamper) new MarbleItemSettings(RefClamper);
  }

  public static bool isClamperPositionsEqual(
    List<ProfileClamper> ClamperA,
    List<ProfileClamper> ClamperB)
  {
    try
    {
      if (ClamperA.Count != ClamperB.Count)
        return false;
      for (int index = 0; index <= ClamperA.Count - 1; ++index)
      {
        if (!buConversion5.EQ(((PanelCutMoveCommand) ClamperA[index]).XPosition, ((PanelCutMoveCommand) ClamperB[index]).XPosition, 0.01))
          return false;
      }
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }
}
