// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationRoundRectangle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationRoundRectangle : ProfileOperation
{
  public string DefaultPartName;
  public bool AddAutoPartQuantityIfAvailable;
  public bool AddAutoPartNameIfAvailable;
  public string AutoPartNameRef;

  public ProfileOperationRoundRectangle(buNestingPartData data)
  {
    this.Width = 200.0;
    this.Height = 100.0;
    this.Thickness = 10.0;
    this.Quantity = 1;
    this.Priority = 10;
    this.Rotation = nestPartRotateType.Increment90;
    this.AdditionalRotation = 0.0;
    this.Mirror = false;
    this.Name = "Part";
    this.ItemNo = "";
    this.SalesNo = "";
    this.Other = "";
    this.Aux = "";
    this.UserData = 0.0;
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

  public override string ToString()
  {
    return $"W: {this.Width.ToString()} , H: {this.Height.ToString()} , Qt: {this.Quantity.ToString()} , Priority: {this.Priority.ToString()} , Rot: {this.Rotation.ToString()}";
  }

  static ProfileOperationRoundRectangle() => ProfileOperation.Captions = new List<string>();
}
