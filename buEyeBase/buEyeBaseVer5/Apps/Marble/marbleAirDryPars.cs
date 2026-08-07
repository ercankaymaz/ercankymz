// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleAirDryPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleAirDryPars : buSerilization5
{
  public bool WarmMotors;
  public bool WagonEnable;
  public bool AirDryEnable;
  public bool LaserPointerEnable;
  public bool AbsoluteXAxis;
  public bool AbsoluteYAxis;

  public abstract void m001EF5();

  public marbleAirDryPars()
  {
    ((MarbleRuntimeSettings) this).LowerLeft = new Point3D();
    ((MarbleRuntimeSettings) this).Direction = DirectionXandY.XDirection;
    ((MarbleRuntimeSettings) this).NodeType = nestPanelNodeType.Assembly;
    ((MarbleRuntimeSettings) this).NodeID = -1;
    ((MarbleRuntimeSettings) this).XQuantity = -1;
    ((MarbleRuntimeSettings) this).YQuantity = -1;
    ((MarbleRuntimeSettings) this).Depth = -1;
    ((MarbleRuntimeSettings) this).DimensionX = 0.0;
    ((MarbleRuntimeSettings) this).DimensionY = 0.0;
    ((MarbleRuntimeSettings) this).SubNodeLowerLeft = new Point3D();
    ((MarbleRuntimeSettings) this).BaseRectangle = (Rectangle2D) null;
    ((MarbleRuntimeSettings) this).Rectangle = (Rectangle2D) null;
    ((MarbleRuntimeSettings) this).CutLine = (Line2D) null;
    ((MarbleRuntimeSettings) this).CutOffset = 0.0;
    ((MarbleRuntimeSettings) this).CutFeedDistance = 0.0;
    ((MarbleRuntimeSettings) this).CutSawDistance = 0.0;
    ((MarbleRuntimeSettings) this).PartID = -1;
    ((MarbleRuntimeSettings) this).ID = -1;
    ((MarbleRuntimeSettings) this).Node = new List<NestingPanelNode>();
    ((MarbleRuntimeSettings) this).SimMoves = new List<PanelCutMove>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleAirDryPars(NestingPanelNode data)
  {
    ((MarbleRuntimeSettings) this).LowerLeft = new Point3D();
    ((MarbleRuntimeSettings) this).Direction = DirectionXandY.XDirection;
    ((MarbleRuntimeSettings) this).NodeType = nestPanelNodeType.Assembly;
    ((MarbleRuntimeSettings) this).NodeID = -1;
    ((MarbleRuntimeSettings) this).XQuantity = -1;
    ((MarbleRuntimeSettings) this).YQuantity = -1;
    ((MarbleRuntimeSettings) this).Depth = -1;
    ((MarbleRuntimeSettings) this).DimensionX = 0.0;
    ((MarbleRuntimeSettings) this).DimensionY = 0.0;
    ((MarbleRuntimeSettings) this).SubNodeLowerLeft = new Point3D();
    ((MarbleRuntimeSettings) this).BaseRectangle = (Rectangle2D) null;
    ((MarbleRuntimeSettings) this).Rectangle = (Rectangle2D) null;
    ((MarbleRuntimeSettings) this).CutLine = (Line2D) null;
    ((MarbleRuntimeSettings) this).CutOffset = 0.0;
    ((MarbleRuntimeSettings) this).CutFeedDistance = 0.0;
    ((MarbleRuntimeSettings) this).CutSawDistance = 0.0;
    ((MarbleRuntimeSettings) this).PartID = -1;
    ((MarbleRuntimeSettings) this).ID = -1;
    ((MarbleRuntimeSettings) this).Node = new List<NestingPanelNode>();
    ((MarbleRuntimeSettings) this).SimMoves = new List<PanelCutMove>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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
    ((MarbleRuntimeSettings) this).SubNodeLowerLeft = F_NotchEdit.ToPoint3D(((MarbleRuntimeSettings) data).SubNodeLowerLeft);
    if (((MarbleRuntimeSettings) data).Rectangle != null)
      ((MarbleRuntimeSettings) this).Rectangle = (Rectangle2D) new AnalyseEntitiesResultError(((MarbleRuntimeSettings) data).Rectangle);
    if (((MarbleRuntimeSettings) data).CutLine == null)
      return;
    ((MarbleRuntimeSettings) this).CutLine = (Line2D) new EntitiesCopySettings(((MarbleRuntimeSettings) data).CutLine);
  }

  public override string ToString()
  {
    return $"NodeType: {((MarbleRuntimeSettings) this).NodeType.ToString()} , Dir: {((MarbleRuntimeSettings) this).Direction.ToString()} , NodeID: {((MarbleRuntimeSettings) this).NodeID.ToString()} , DimX: {((MarbleRuntimeSettings) this).DimensionX.ToString()} , DimY: {((MarbleRuntimeSettings) this).DimensionY.ToString()} , PartID: {((MarbleRuntimeSettings) this).PartID.ToString()}";
  }

  public abstract void m001EF9();
}
