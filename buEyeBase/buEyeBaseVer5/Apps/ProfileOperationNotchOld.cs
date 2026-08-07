// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationNotchOld
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationNotchOld : ProfileOperation
{
  public new double Thickness;
  public new double Width;
  public new double Height;
  public new int Quantity;
  public new string Name;
  public int MirrorQuantity;
  public new double PartDistance;

  public ProfileOperationNotchOld(buNestingPartAddData data)
  {
    ((ProfileOperationHole) this).SelectionColor = Color.Blue;
    ((ProfileOperationHole) this).UseLayerForSelection = false;
    ((ProfileOperationNotch) this).DeleteSelectedEntities = true;
    ((ProfileOperationNotch) this).DeleteSelectedAuxEntities = true;
    ((ProfileOperationNotch) this).DeleteSelectedTextEntities = false;
    ((ProfileOperationNotch) this).DeleteCamAfterAdding = false;
    ((ProfileOperationNotch) this).AddCam = false;
    ((ProfileOperationNotch) this).AddAuxEntities = true;
    ((ProfileOperationNotch) this).Priority = 10;
    this.Thickness = 10.0;
    this.Width = 10.0;
    this.Height = 10.0;
    this.Quantity = 1;
    this.Name = "Part";
    this.MirrorQuantity = 0;
    this.PartDistance = 0.0;
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
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  static ProfileOperationNotchOld() => ProfileOperationText.Captions = new List<string>();

  public ProfileOperationNotchOld()
  {
    ((ProfileOperationPolygon) this).Thickness = 18.0;
    ((ProfileOperationPolygon) this).Cost = 1.0;
    ((ProfileOperationData) this).ID = -1;
    ((ProfileOperationData) this).Material = "Standart";
    ((ProfileOperationData) this).Explanation = "";
    ((ProfileOperationData) this).Enable = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
