// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataPolygon
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationDataPolygon : buSerilization5
{
  public double ApproxExecutionTimeSec;
  public int ApproxExecution0UpDownCnt;
  public int ApproxExecution1UpDownCnt;
  public int ApproxExecution2UpDownCnt;
  public int ApproxExecution3UpDownCnt;

  public ProfileOperationDataPolygon()
  {
    ((ProfileOperationDataHole) this).MovedDistance = new Vec3D();
    ((ProfileOperationDataHole) this).RotateValue = 0.0;
    ((ProfileOperationDataHole) this).Width = 0.0;
    ((ProfileOperationDataHole) this).Height = 0.0;
    ((ProfileOperationDataHole) this).Thickness = 2.0;
    ((ProfileOperationDataFreeDraw) this).PartArea = 0.0;
    ((ProfileOperationDataFreeDraw) this).TotalOutSideLength = 0.0;
    ((ProfileOperationDataFreeDraw) this).TotalInsideLength = 0.0;
    ((ProfileOperationDataFreeDraw) this).TotalLength = 0.0;
    ((ProfileOperationDataFreeDraw) this).Name = "";
    ((ProfileOperationDataFreeDraw) this).GroupCount = 1;
    ((ProfileOperationDataText) this).ID = -1;
    ((ProfileOperationDataText) this).ItemNo = "";
    ((ProfileOperationDataText) this).SalesNo = "";
    ((ProfileOperationDataText) this).Other = "";
    ((ProfileOperationDataText) this).Aux = "";
    ((ProfileOperationDataText) this).UserData = 0.0;
    ((ProfileOperationDataText) this).SequenceChar = "";
    ((ProfileOperationDataText) this).isMirror = false;
    ((ProfileOperationDataText) this).Color = Color.Linen;
    ((ProfileOperationDataText) this).Rotation = nestPartRotateType.Increment90;
    ((ProfileOperationDataText) this).EntitiesGroup = new buEntitiesGroup();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationDataPolygon(buNestedPart data)
  {
    ((ProfileOperationDataHole) this).MovedDistance = new Vec3D();
    ((ProfileOperationDataHole) this).RotateValue = 0.0;
    ((ProfileOperationDataHole) this).Width = 0.0;
    ((ProfileOperationDataHole) this).Height = 0.0;
    ((ProfileOperationDataHole) this).Thickness = 2.0;
    ((ProfileOperationDataFreeDraw) this).PartArea = 0.0;
    ((ProfileOperationDataFreeDraw) this).TotalOutSideLength = 0.0;
    ((ProfileOperationDataFreeDraw) this).TotalInsideLength = 0.0;
    ((ProfileOperationDataFreeDraw) this).TotalLength = 0.0;
    ((ProfileOperationDataFreeDraw) this).Name = "";
    ((ProfileOperationDataFreeDraw) this).GroupCount = 1;
    ((ProfileOperationDataText) this).ID = -1;
    ((ProfileOperationDataText) this).ItemNo = "";
    ((ProfileOperationDataText) this).SalesNo = "";
    ((ProfileOperationDataText) this).Other = "";
    ((ProfileOperationDataText) this).Aux = "";
    ((ProfileOperationDataText) this).UserData = 0.0;
    ((ProfileOperationDataText) this).SequenceChar = "";
    ((ProfileOperationDataText) this).isMirror = false;
    ((ProfileOperationDataText) this).Color = Color.Linen;
    ((ProfileOperationDataText) this).Rotation = nestPartRotateType.Increment90;
    ((ProfileOperationDataText) this).EntitiesGroup = new buEntitiesGroup();
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
    ((ProfileOperationDataHole) this).MovedDistance = new Vec3D(((ProfileOperationDataHole) data).MovedDistance);
    if (((ProfileOperationDataText) data).EntitiesGroup == null)
      return;
    ((ProfileOperationDataText) this).EntitiesGroup = new buEntitiesGroup(((ProfileOperationDataText) data).EntitiesGroup);
  }

  public static buNestedPart FromNestingPart(buNestingPart data)
  {
    buNestedPart buNestedPart = (buNestedPart) new ProfileOperationDataPolygon();
    ((ProfileOperationDataText) buNestedPart).Aux = ((ProfileOperation) ((ProfileOperation) data).PartData).Aux;
    ((ProfileOperationDataHole) buNestedPart).Width = ((ProfileOperation) ((ProfileOperation) data).PartData).Width;
    ((ProfileOperationDataHole) buNestedPart).Height = ((ProfileOperation) ((ProfileOperation) data).PartData).Height;
    ((ProfileOperationDataText) buNestedPart).SalesNo = ((ProfileOperation) ((ProfileOperation) data).PartData).SalesNo;
    ((ProfileOperationDataText) buNestedPart).ItemNo = ((ProfileOperation) ((ProfileOperation) data).PartData).ItemNo;
    ((ProfileOperationDataText) buNestedPart).Other = ((ProfileOperation) ((ProfileOperation) data).PartData).Other;
    ((ProfileOperationDataText) buNestedPart).UserData = ((ProfileOperation) ((ProfileOperation) data).PartData).UserData;
    ((ProfileOperationDataHole) buNestedPart).Thickness = ((ProfileOperation) ((ProfileOperation) data).PartData).Thickness;
    ((ProfileOperationDataFreeDraw) buNestedPart).Name = ((ProfileOperation) ((ProfileOperation) data).PartData).Name;
    ((ProfileOperationDataText) buNestedPart).Rotation = ((ProfileOperation) ((ProfileOperation) data).PartData).Rotation;
    ((ProfileOperationDataText) buNestedPart).ID = ((ProfileOperation) data).ID;
    ((ProfileOperationDataText) buNestedPart).EntitiesGroup = new buEntitiesGroup(((ProfileOperationRectangle) data).EntitiesGroup);
    return buNestedPart;
  }

  public override string ToString()
  {
    return $"DX: {((ProfileOperationDataHole) this).MovedDistance.X.ToString()} , DY: {((ProfileOperationDataHole) this).MovedDistance.Y.ToString()} , Rotate: {((ProfileOperationDataText) this).Rotation.ToString()}";
  }

  public static ArrayList ToDef(List<buNestedPart> NestedParts, int Space)
  {
    ArrayList def = new ArrayList();
    def.Add((object) (buImage5.SpaceChar(Space) + "<buNestedParts>"));
    for (int index = 0; index <= NestedParts.Count - 1; ++index)
    {
      def.AddRange((ICollection) NestedParts[index].ToDefAll("", 2 + Space, (SerilizationMode5) 1));
      string str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      if (((\u0084.\u0001) ((ProfileOperationDataText) NestedParts[index]).EntitiesGroup.Outside).Entities.Count > 0)
        def.AddRange((ICollection) DimensionGroup.ToDefGroup(((ProfileOperationDataText) NestedParts[index]).EntitiesGroup, Space + 4, "NestedPart"));
      def.Add((object) str);
    }
    def.Add((object) (buImage5.SpaceChar(Space) + "</buNestedParts>"));
    return def;
  }

  public static void Decode(ArrayList AL, ref List<buNestedPart> Parts)
  {
    Parts.Clear();
    Parts = new List<buNestedPart>();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<buNestedPart>", "</buNestedPart>", true, AL, ref CalcList1);
    for (int index = 0; index <= CalcList1.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      List<string> CalcList2 = new List<string>();
      arrayList.AddRange((ICollection) CalcList1[index].ToArray());
      buNestedPart buNestedPart = (buNestedPart) new ProfileOperationDataPolygon();
      buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) buNestedPart);
      buStatics.ListToSpecificList("<buEntitiesGroupDataNestedPart>", "</buEntitiesGroupDataNestedPart>", true, arrayList, ref CalcList2);
      DimensionGroup.Decode(CalcList2, ref ((ProfileOperationDataText) buNestedPart).EntitiesGroup);
      ((GProfileOperationGroup) buCall.\u0001).CreatePointAndSolidFromEntityGroup(ref ((ProfileOperationDataText) buNestedPart).EntitiesGroup);
      Parts.Add(buNestedPart);
      arrayList.Clear();
      CalcList2.Clear();
    }
    CalcList1.Clear();
  }
}
