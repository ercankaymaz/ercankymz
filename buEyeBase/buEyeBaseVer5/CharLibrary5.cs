// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CharLibrary5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CharLibrary5 : buSerilization5
{
  public Point3D CatchPoint;
  public Point3D BasePoint;
  public Point3D CatchPointOfEntity;

  public CharLibrary5()
  {
    ((EntityInfo) this).Chars = "";
    ((EntityInfo) this).Explanation = "";
    ((CutterInfo) this).TextOverride = "";
    ((Rectangle2D) this).ReletedEntityName = "";
    ((Rectangle2D) this).Distance = 0.0;
    ((Rectangle2D) this).Angle = 0.0;
    ((Line2D) this).IsVertical = false;
    ((Line2D) this).Type = DimensionType.None;
    this.CatchPoint = new Point3D();
    this.BasePoint = new Point3D();
    this.CatchPointOfEntity = new Point3D();
    ((AnalyseEntitiesSetting) this).BasePointOfEntity = new Point3D();
    ((AnalyseEntitiesSetting) this).ReSizedEntityIndex = -1;
    ((AnalyseEntitiesSetting) this).ReSizedEntitySubIndex = -1;
    ((AnalyseEntitiesSetting) this).SelectedEntities = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CharLibrary5(
    string chars,
    string explanation,
    double distance,
    double angle,
    bool isvertical,
    DimensionType type)
  {
    ((EntityInfo) this).Chars = "";
    ((EntityInfo) this).Explanation = "";
    ((CutterInfo) this).TextOverride = "";
    ((Rectangle2D) this).ReletedEntityName = "";
    ((Rectangle2D) this).Distance = 0.0;
    ((Rectangle2D) this).Angle = 0.0;
    ((Line2D) this).IsVertical = false;
    ((Line2D) this).Type = DimensionType.None;
    this.CatchPoint = new Point3D();
    this.BasePoint = new Point3D();
    this.CatchPointOfEntity = new Point3D();
    ((AnalyseEntitiesSetting) this).BasePointOfEntity = new Point3D();
    ((AnalyseEntitiesSetting) this).ReSizedEntityIndex = -1;
    ((AnalyseEntitiesSetting) this).ReSizedEntitySubIndex = -1;
    ((AnalyseEntitiesSetting) this).SelectedEntities = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityInfo) this).Chars = chars;
    ((EntityInfo) this).Explanation = explanation;
    ((Rectangle2D) this).Distance = distance;
    ((Rectangle2D) this).Angle = angle;
    ((Line2D) this).IsVertical = isvertical;
    ((Line2D) this).Type = type;
  }

  public CharLibrary5(DimensionInfo data)
  {
    ((EntityInfo) this).Chars = "";
    ((EntityInfo) this).Explanation = "";
    ((CutterInfo) this).TextOverride = "";
    ((Rectangle2D) this).ReletedEntityName = "";
    ((Rectangle2D) this).Distance = 0.0;
    ((Rectangle2D) this).Angle = 0.0;
    ((Line2D) this).IsVertical = false;
    ((Line2D) this).Type = DimensionType.None;
    this.CatchPoint = new Point3D();
    this.BasePoint = new Point3D();
    this.CatchPointOfEntity = new Point3D();
    ((AnalyseEntitiesSetting) this).BasePointOfEntity = new Point3D();
    ((AnalyseEntitiesSetting) this).ReSizedEntityIndex = -1;
    ((AnalyseEntitiesSetting) this).ReSizedEntitySubIndex = -1;
    ((AnalyseEntitiesSetting) this).SelectedEntities = "";
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
    this.BasePoint = F_NotchEdit.ToPoint3D(((CharLibrary5) data).BasePoint);
    this.CatchPoint = F_NotchEdit.ToPoint3D(((CharLibrary5) data).CatchPoint);
    this.CatchPointOfEntity = F_NotchEdit.ToPoint3D(((CharLibrary5) data).CatchPointOfEntity);
    ((AnalyseEntitiesSetting) this).BasePointOfEntity = F_NotchEdit.ToPoint3D(((AnalyseEntitiesSetting) data).BasePointOfEntity);
  }

  public ArrayList ToDef(int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + buSerilization5.ClassToString((object) this))
    };
  }

  public static void Decode(List<string> SL, ref DimensionInfo Sewing)
  {
    try
    {
      if (SL.Count < 1)
        return;
      Sewing = (DimensionInfo) new CharLibrary5();
      object ObjPar = (object) Sewing;
      buSerilization5.StringToClass(ref ObjPar, SL[0]);
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    return $"{((EntityInfo) this).Chars} - Exp: {((EntityInfo) this).Explanation} - Dis: {((Rectangle2D) this).Distance.ToString("f2")} - Type: {((Line2D) this).Type.ToString()} - Ent Index: {((AnalyseEntitiesSetting) this).ReSizedEntityIndex.ToString()}";
  }

  public abstract void m0001FE();

  public CharLibrary5()
  {
    ((AnalyseEntitiesSetting) this).Sequence = -1;
    ((AnalyseEntitiesSetting) this).OriginalEntityIndex = -1;
    ((AnalyseEntitiesSetting) this).InsideIndex = -1;
    ((AnalyseEntitiesSetting) this).EntityIndex = -1;
    ((AnalyseEntitiesSetting) this).EntitySubIndex = -1;
    ((AnalyseEntitiesSetting) this).RefIndex = -1;
    ((AnalyseEntitiesResult) this).CamIndex = -1;
    ((AnalyseEntitiesResult) this).CamSelected = false;
    ((AnalyseEntitiesResultError) this).CamSelectedCount = 0;
    ((AnalyseEntitiesResultError) this).CamSelectable = true;
    ((AnalyseEntitiesResultError) this).CamPlungeAxis = (string) null;
    ((AnalyseEntitiesResultError) this).CamLeaveAxis = (string) null;
    ((AnalyseEntitiesResultError) this).CamSpeed = 0.0;
    ((AnalyseEntitiesResultError) this).PlungeSpeed = 0.0;
    ((AnalyseEntitiesResultError) this).SpindleSpeed = 0.0;
    ((DirectionArrowSetting) this).Enable = true;
    ((DirectionArrowSetting) this).Calculated = false;
    ((DirectionArrowSetting) this).Selectable = true;
    ((DirectionArrowSetting) this).DontUseForCalculation = false;
    ((DirectionArrowSetting) this).isUpperEntity = false;
    ((EntityDataSet) this).CamID = -1;
    ((EntityDataSet) this).ItemID = -1;
    ((EntityDataSet) this).EdgeID = -1;
    ((EntityDataSet) this).CamToolNo = 1;
    ((EntityDataSet) this).EntityName = (string) null;
    ((EntityDataSet) this).CamCode = (string) null;
    ((EntityDataSet) this).ID = (string) null;
    ((EntityDataSet) this).Tags = (string) null;
    ((EntityDataSet) this).Data = (string) null;
    ((EntityDataSet) this).AuxVal = 0.0;
    ((EntityDataSet) this).Length = 0.0;
    ((EntityDataSet) this).Radius = 0.0;
    ((EntityDataSet) this).Offset = (Point3D) null;
    ((EntityDataSet) this).OffsetABC = (PointABC) null;
    ((EntityDataSet) this).OffsetAngle = (OrientationAngle) null;
    ((EntityDataSet) this).Commands = (List<string>) null;
    ((EntityDataSet) this).Options = (List<string>) null;
    ((EntityDataSet) this).OrjType = entityOriginalType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
