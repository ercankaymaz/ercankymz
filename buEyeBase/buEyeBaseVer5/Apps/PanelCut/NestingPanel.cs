// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.NestingPanel
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class NestingPanel : buSerilization5
{
  public UpDownLocationType NotchUpDown;
  public FrontBackType NotchFrontBack;
  public ProfileNotchOperationType NotchOPType;
  public double NotchStart;
  public ProfileNotchLocationType NotchLocation;
  public Color NotchColor;
  public double NotchThickness;
  public bool UseMilling;
  public static byte f00454F;
  public double HoleDepth;
  public double HoleDiameter;
  public Color HoleColor;
  public double HoleThickness;
  public bool Tapping;

  public abstract void m001DB5();

  public NestingPanel()
  {
    ((ProfileSettings) this).Name = "Job";
    ((ProfileSettings) this).isSimulationDone = false;
    ((ProfileSettings) this).FirstItem = (ProfileItem) null;
    ((ProfileSettings) this).SecondItem = (ProfileItem) null;
    ((ProfileSettings) this).ThirdItem = (ProfileItem) null;
    ((ProfileSettings) this).FourthItem = (ProfileItem) null;
    ((ProfileSettings) this).GCodes = (ArrayList) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
