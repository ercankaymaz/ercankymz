// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationFreeDraw
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationFreeDraw : ProfileOperation
{
  public new double AdditionalRotation;
  public DirectionXandY MirrorAxis;
  public new nestPartRotateType Rotation;

  public ProfileOperationFreeDraw(buNestingMaterials data)
  {
    ((ProfileOperationPolygon) this).Thickness = 18.0;
    ((ProfileOperationPolygon) this).Cost = 1.0;
    ((ProfileOperationData) this).ID = -1;
    ((ProfileOperationData) this).Material = "Standart";
    ((ProfileOperationData) this).Explanation = "";
    ((ProfileOperationData) this).Enable = true;
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
    return $"{((ProfileOperationData) this).Material} - Thickness: {((ProfileOperationPolygon) this).Thickness.ToString()} , Enable: {((ProfileOperationData) this).Enable.ToString()}";
  }

  public static void Copy(buNestingMaterials Base, ref buNestingMaterials Copied)
  {
    Copied = (buNestingMaterials) new ProfileOperationFreeDraw(Base);
  }
}
