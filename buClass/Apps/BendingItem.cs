// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingItem : buSerilization
{
  public double X = 0.0;
  public double Offset = 0.0;
  public double OffsetMachine = 0.0;
  public int ToolNo = 0;
  public int Action = 0;
  public bool LastCut = false;
  public int Mode = 0;
  public int PartIndex = -1;
  public double PtValue = 0.0;
  public int Option = 0;

  public static void Copy(BendingItem RefItem, ref BendingItem CopiedItem)
  {
    if (RefItem.GetType() == typeof (BendingBendPoint))
      CopiedItem = (BendingItem) new BendingBendPoint((BendingBendPoint) RefItem);
    if (RefItem.GetType() == typeof (BendingBroachPoint))
      CopiedItem = (BendingItem) new BendingBroachPoint((BendingBroachPoint) RefItem);
    if (RefItem.GetType() == typeof (BendingNickPoint))
      CopiedItem = (BendingItem) new BendingNickPoint((BendingNickPoint) RefItem);
    if (RefItem.GetType() == typeof (BendingBridgePoint))
      CopiedItem = (BendingItem) new BendingBridgePoint((BendingBridgePoint) RefItem);
    if (RefItem.GetType() == typeof (BendingPunchPoint))
      CopiedItem = (BendingItem) new BendingPunchPoint((BendingPunchPoint) RefItem);
    if (RefItem.GetType() == typeof (BendingScissorsPoint))
      CopiedItem = (BendingItem) new BendingScissorsPoint((BendingScissorsPoint) RefItem);
    if (RefItem.GetType() == typeof (BendingTrimcutPoint))
      CopiedItem = (BendingItem) new BendingTrimcutPoint((BendingTrimcutPoint) RefItem);
    if (RefItem.GetType() == typeof (BendingBendCut))
      CopiedItem = (BendingItem) new BendingBendCut((BendingBendCut) RefItem);
    if (!(RefItem.GetType() == typeof (BendingPerfoCombiPoint)))
      return;
    CopiedItem = (BendingItem) new BendingPerfoCombiPoint((BendingPerfoCombiPoint) RefItem);
  }
}
