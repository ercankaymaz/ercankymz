// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendPart
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendPart : buSerilization
{
  public int Count = 0;
  public int CountDone = 0;
  public int Closed = 0;
  public int Index = 0;
  public bool Done = false;
  public string FileName = "";
  public string RefFileName = "";
  public string FullPath = "";
  public string Path = "";
  public int PartID = 0;
  public bool TransferRamp = false;
  public int BlueBenderCutMode = 0;
  public double Heigth = 0.0;
  public double BridgeHeight = 0.0;
  public double Thickness = 0.0;
  public double Width = 0.0;
  public double Length = 0.0;
  public bool TrimcutPress = false;
  public int PartMaterialType = 0;
  public double ShapedModeOverride = 100.0;
  public bool BendCut = false;
  public double Offset = 0.0;
  public List<BendingItem> BendingItems = new List<BendingItem>();
  public List<eEntities> Entities = new List<eEntities>();

  public BendPart()
  {
  }

  public BendPart(BendPart data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.Entities.Clear();
    eEntities.CopyEntities(data.Entities, ref this.Entities);
    this.BendingItems = new List<BendingItem>();
    for (int index = 0; index <= data.BendingItems.Count - 1; ++index)
    {
      if (data.BendingItems[index].GetType() == typeof (BendingBendPoint))
        this.BendingItems.Add((BendingItem) new BendingBendPoint((BendingBendPoint) data.BendingItems[index]));
      if (data.BendingItems[index].GetType() == typeof (BendingBridgePoint))
        this.BendingItems.Add((BendingItem) new BendingBridgePoint((BendingBridgePoint) data.BendingItems[index]));
      if (data.BendingItems[index].GetType() == typeof (BendingBroachPoint))
        this.BendingItems.Add((BendingItem) new BendingBroachPoint((BendingBroachPoint) data.BendingItems[index]));
      if (data.BendingItems[index].GetType() == typeof (BendingNickPoint))
        this.BendingItems.Add((BendingItem) new BendingNickPoint((BendingNickPoint) data.BendingItems[index]));
      if (data.BendingItems[index].GetType() == typeof (BendingTrimcutPoint))
        this.BendingItems.Add((BendingItem) new BendingTrimcutPoint((BendingTrimcutPoint) data.BendingItems[index]));
      if (data.BendingItems[index].GetType() == typeof (BendingPunchPoint))
        this.BendingItems.Add((BendingItem) new BendingPunchPoint((BendingPunchPoint) data.BendingItems[index]));
      if (data.BendingItems[index].GetType() == typeof (BendingScissorsPoint))
        this.BendingItems.Add((BendingItem) new BendingScissorsPoint((BendingScissorsPoint) data.BendingItems[index]));
      if (data.BendingItems[index].GetType() == typeof (BendingBendCut))
        this.BendingItems.Add((BendingItem) new BendingBendCut((BendingBendCut) data.BendingItems[index]));
    }
  }

  public override string ToString()
  {
    return $"Count: {this.Count.ToString()} ; Length: {this.Length.ToString()}  ; Thickness: {this.Thickness.ToString()}  - File: {this.FileName.ToString()}";
  }
}
