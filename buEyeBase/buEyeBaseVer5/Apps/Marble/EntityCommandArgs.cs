// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.EntityCommandArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class EntityCommandArgs
{
  public bool FinishExecuteVerticalWalls;
  public bool Finish5Axis;
  public bool FinishReverseCAngle;
  public bool FinishMoveUpSafe;
  public double RoughPlungeFeed;
  public double RoughCutForwardFeed;
  public double RoughCutBackwardFeed;
  public double RoughSafeDis;
  public double RoughRapid;

  public static void Copy(List<MarbleItemExtend> Items, ref List<MarbleItemExtend> CopyItems)
  {
    CopyItems = new List<MarbleItemExtend>();
    for (int index = 0; index <= Items.Count - 1; ++index)
      CopyItems.Add((MarbleItemExtend) new CounterTopFormImageIndex(Items[index]));
  }
}
