// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleVacuumCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleVacuumCut : buSerilization5
{
  public bool ManuelClamperSet;
  public bool NoClampedOutput;
  public double ParkPositionX;
  public double ParkPositionY;
  public double ParkPositionZ;
  public double ToolHolderLength;
  public double ToolPensDiameter;
  public double FirstPositionOffset;
  public bool GoFirstPosition;
  public bool AutoOpenLastLoadedProfile;
  public bool AutoOpenLastLoadedProfileAndOperations;
  public bool SaveCurrentProfilesWhileProgramClosing;

  public MarbleVacuumCut()
  {
    ((PanelCutMoveCommand) this).SizePoint = (BoxSize5) new SortbuOptions();
    ((PanelCutMoveCommand) this).Used = false;
    ((PanelCutMoveCommand) this).ID = "";
    ((PanelCutMoveCommand) this).Plane = planeNames.Top;
    ((PanelCutMoveCommand) this).ToolNo = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleVacuumCut(Point3D MinPoint, Point3D MaxPoint)
  {
    ((PanelCutMoveCommand) this).SizePoint = (BoxSize5) new SortbuOptions();
    ((PanelCutMoveCommand) this).Used = false;
    ((PanelCutMoveCommand) this).ID = "";
    ((PanelCutMoveCommand) this).Plane = planeNames.Top;
    ((PanelCutMoveCommand) this).ToolNo = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((PanelCutMoveCommand) this).SizePoint = (BoxSize5) new SortbuCamData(MinPoint, MaxPoint);
  }

  public MarbleVacuumCut(Point3D MinPoint, Point3D MaxPoint, string ID)
  {
    ((PanelCutMoveCommand) this).SizePoint = (BoxSize5) new SortbuOptions();
    ((PanelCutMoveCommand) this).Used = false;
    ((PanelCutMoveCommand) this).ID = "";
    ((PanelCutMoveCommand) this).Plane = planeNames.Top;
    ((PanelCutMoveCommand) this).ToolNo = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((PanelCutMoveCommand) this).SizePoint = (BoxSize5) new SortbuCamData(MinPoint, MaxPoint);
    ((PanelCutMoveCommand) this).ID = ID;
  }

  public MarbleVacuumCut(ProfileOperationSortItem data)
  {
    ((PanelCutMoveCommand) this).SizePoint = (BoxSize5) new SortbuOptions();
    ((PanelCutMoveCommand) this).Used = false;
    ((PanelCutMoveCommand) this).ID = "";
    ((PanelCutMoveCommand) this).Plane = planeNames.Top;
    ((PanelCutMoveCommand) this).ToolNo = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((PanelCutMoveCommand) this).SizePoint = (BoxSize5) new SortbuOptions(((PanelCutMoveCommand) data).SizePoint);
  }

  public override string ToString()
  {
    return $"{((PanelCutMoveCommand) this).SizePoint.ToString()} - Used: {((PanelCutMoveCommand) this).Used.ToString()}";
  }

  public abstract void m001E7C();

  public MarbleVacuumCut()
  {
    ((PanelCutMoveCommand) this).XPosition = 0.0;
    ((buMarbleCalc) this).GeometrixMaxX = 0.0;
    ((buMarbleCalc) this).GeometrixMinX = 0.0;
    ((buMarbleCalc) this).XOffset = 0.0;
    ((buMarbleCalc) this).Width = 100.0;
    ((buMarbleCalc) this).Text = "";
    ((buMarbleCalc) this).MaxPositionRange = 10000.0;
    ((buMarbleCalc) this).MinPositionRange = 0.0;
    ((buMarbleCalc) this).Used = false;
    ((buMarbleCalc) this).Enable = true;
    ((buMarbleCalc) this).isCollision = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
