// Decompiled with JetBrains decompiler
// Type: buClass.KinematicItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class KinematicItem : buSerilization
{
  public string PartName = "Part";
  public List<eEntities> Entities = new List<eEntities>();
  public AxesEnable Axis = new AxesEnable(true, true, true);
  public Color Color = Color.Gray;

  public KinematicItem()
  {
  }

  public KinematicItem(KinematicItem item)
  {
    this.PartName = item.PartName;
    this.Color = item.Color;
    this.Axis = new AxesEnable(item.Axis);
    this.Entities = new List<eEntities>();
    eEntities.CopyEntities(item.Entities, ref this.Entities);
  }

  public override string ToString() => this.PartName;
}
