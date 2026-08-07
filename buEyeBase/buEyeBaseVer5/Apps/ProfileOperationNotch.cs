// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationNotch
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationNotch : ProfileOperation
{
  public bool DeleteSelectedEntities;
  public bool DeleteSelectedAuxEntities;
  public bool DeleteSelectedTextEntities;
  public bool DeleteCamAfterAdding;
  public bool AddCam;
  public bool AddAuxEntities;
  public new int Priority;

  public ProfileOperationNotch(buNestingPartSettings data)
  {
    // ISSUE: unable to decompile the method.
  }

  static ProfileOperationNotch() => ProfileOperationHole.Captions = new List<string>();

  public ProfileOperationNotch()
  {
    ((ProfileOperationHole) this).SelectionColor = Color.Blue;
    ((ProfileOperationHole) this).UseLayerForSelection = false;
    this.DeleteSelectedEntities = true;
    this.DeleteSelectedAuxEntities = true;
    this.DeleteSelectedTextEntities = false;
    this.DeleteCamAfterAdding = false;
    this.AddCam = false;
    this.AddAuxEntities = true;
    this.Priority = 10;
    ((ProfileOperationNotchOld) this).Thickness = 10.0;
    ((ProfileOperationNotchOld) this).Width = 10.0;
    ((ProfileOperationNotchOld) this).Height = 10.0;
    ((ProfileOperationNotchOld) this).Quantity = 1;
    ((ProfileOperationNotchOld) this).Name = "Part";
    ((ProfileOperationNotchOld) this).MirrorQuantity = 0;
    ((ProfileOperationNotchOld) this).PartDistance = 0.0;
    ((ProfileOperationFreeDraw) this).AdditionalRotation = 0.0;
    ((ProfileOperationFreeDraw) this).MirrorAxis = DirectionXandY.XDirection;
    ((ProfileOperationFreeDraw) this).Rotation = nestPartRotateType.Increment90;
    ((ProfileOperationText) this).MirrorEnable = false;
    ((ProfileOperationText) this).OutterContourLayerName = "";
    ((ProfileOperationText) this).LastPartWidth = 500.0;
    ((ProfileOperationText) this).LastPartHeight = 250.0;
    ((ProfileOperationText) this).LastPartQuantity = 10;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
