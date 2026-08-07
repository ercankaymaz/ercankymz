// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationBarrel
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationBarrel : ProfileOperation
{
  public string AutoPartQuantityRef;
  public string AutoPartNameEquality;
  public string AutoPartQuantityEquality;
  public bool PartInPart;

  public ProfileOperationBarrel()
  {
    this.PartData = (buNestingPartData) new ProfileOperationCut();
    this.RotateDegree = 0.0;
    this.Area = 0.0;
    this.PartDistance = 0.0;
    this.Price = 0.0;
    this.PrecutWidth = 0.0;
    this.PrecutHeight = 0.0;
    this.Nested = 0;
    this.Remain = 0;
    this.ID = 0;
    this.Explanation = "";
    this.Aux = "";
    this.Material = "";
    this.Code = "";
    this.FileName = "";
    this.Referance = "";
    this.CanRotate = false;
    this.Enable = true;
    this.UseInnersAsHolePartInPart = true;
    this.EdgeLeft = false;
    this.EdgeRight = false;
    this.EdgeTop = false;
    this.EdgeBottom = false;
    this.Selected = false;
    this.EdgeLeftThickness = 0.0;
    ((ProfileOperationCircle) this).EdgeRightThickness = 0.0;
    ((ProfileOperationRectangle) this).EdgeTopThickness = 0.0;
    ((ProfileOperationRectangle) this).EdgeBottomThickness = 0.0;
    ((ProfileOperationRectangle) this).Type = nestMaterialType.Rectangle;
    ((ProfileOperationRectangle) this).EntitiesGroup = new buEntitiesGroup();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationBarrel(buNestingPart data)
  {
    this.PartData = (buNestingPartData) new ProfileOperationCut();
    this.RotateDegree = 0.0;
    this.Area = 0.0;
    this.PartDistance = 0.0;
    this.Price = 0.0;
    this.PrecutWidth = 0.0;
    this.PrecutHeight = 0.0;
    this.Nested = 0;
    this.Remain = 0;
    this.ID = 0;
    this.Explanation = "";
    this.Aux = "";
    this.Material = "";
    this.Code = "";
    this.FileName = "";
    this.Referance = "";
    this.CanRotate = false;
    this.Enable = true;
    this.UseInnersAsHolePartInPart = true;
    this.EdgeLeft = false;
    this.EdgeRight = false;
    this.EdgeTop = false;
    this.EdgeBottom = false;
    this.Selected = false;
    this.EdgeLeftThickness = 0.0;
    ((ProfileOperationCircle) this).EdgeRightThickness = 0.0;
    ((ProfileOperationRectangle) this).EdgeTopThickness = 0.0;
    ((ProfileOperationRectangle) this).EdgeBottomThickness = 0.0;
    ((ProfileOperationRectangle) this).Type = nestMaterialType.Rectangle;
    ((ProfileOperationRectangle) this).EntitiesGroup = new buEntitiesGroup();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    this.PartData = (buNestingPartData) new ProfileOperationRoundRectangle(((ProfileOperation) data).PartData);
    ((ProfileOperationRectangle) this).EntitiesGroup = new buEntitiesGroup(((ProfileOperationRectangle) data).EntitiesGroup);
  }

  public override string ToString()
  {
    return $"Type: {((ProfileOperationRectangle) this).Type.ToString()} - {this.PartData.ToString()}";
  }
}
