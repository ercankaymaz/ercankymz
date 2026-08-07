// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillShapeData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillShapeData : buSerilization5
{
  public double WaveFormVShapeBaseHeight;
  public double WaveFormUShapeHeight;
  public double WaveFormUShapeWidth;
  public double WaveFormUShapeBaseHeight;
  public double WaveFormSShapeHeight;
  public double WaveFormSShapeWidth;
  public double WaveFormSShapeBaseHeight;
  public double WaveFormCShapeHeight;

  public void CreateSolidOperation(
    ref FoamPattern Pattern,
    SizeObject Size,
    FoamPlaneType refPlane,
    Color color,
    bool MultiColor,
    int transparant = 255 /*0xFF*/)
  {
    try
    {
      ((DrillItem) Pattern).SolidEntities = new List<Entity>();
      if (refPlane == FoamPlaneType.XZ)
      {
        for (int index = 0; index <= ((DrillItem) Pattern).foamEntities.Count - 1; ++index)
        {
          Color baseColor = color;
          if (MultiColor)
            baseColor = buFile5.GetColorFrom50ListByIndex(index);
          List<ICurve> contours = new List<ICurve>();
          List<Point3D> Points = new List<Point3D>();
          buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((DrillItem) ((DrillItem) Pattern).foamEntities[index]).GroupEntity.Outside).Entities, ref Points);
          ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points);
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) Points);
          if (linearPath.IsClosed)
          {
            contours.Add((ICurve) linearPath);
            Mesh mesh = new devDept.Eyeshot.Entities.Region((IList<ICurve>) contours, Plane.XZ, true).ExtrudeAsMesh(-Size.Height, 0.2, Mesh.natureType.RichSmooth);
            CustomData customData = (CustomData) new ClipperOffset();
            ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Operation);
            mesh.EntityData = (object) customData;
            mesh.Color = Color.FromArgb(transparant, baseColor);
            mesh.ColorMethod = colorMethodType.byEntity;
            mesh.Selectable = false;
            ((DrillItem) Pattern).SolidEntities.Add((Entity) mesh);
          }
        }
      }
      if (refPlane != FoamPlaneType.YZ)
        return;
      for (int index1 = 0; index1 <= ((DrillItem) Pattern).foamEntities.Count - 1; ++index1)
      {
        Color baseColor = color;
        if (MultiColor)
          baseColor = buFile5.GetColorFrom50ListByIndex(index1);
        for (int index2 = 0; index2 <= ((\u0084.\u0001) ((DrillItem) ((DrillItem) Pattern).foamEntities[index1]).GroupEntity.Outside).Entities.Count - 1; ++index2)
        {
          List<ICurve> contours = new List<ICurve>();
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) ((CustomDataSurrogate) ((\u0084.\u0001) ((DrillItem) ((DrillItem) Pattern).foamEntities[index1]).GroupEntity.Outside).Entities[index2]).Vertices);
          if (linearPath.IsClosed)
          {
            contours.Add((ICurve) linearPath);
            Mesh mesh = new devDept.Eyeshot.Entities.Region((IList<ICurve>) contours, Plane.YZ, true).ExtrudeAsMesh(Size.Width, 0.2, Mesh.natureType.RichSmooth);
            CustomData customData = (CustomData) new ClipperOffset();
            ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Operation);
            mesh.EntityData = (object) customData;
            mesh.Color = Color.FromArgb(transparant, baseColor);
            mesh.ColorMethod = colorMethodType.byEntity;
            mesh.Selectable = false;
            ((DrillItem) Pattern).SolidEntities.Add((Entity) mesh);
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void CreateMarkCircleEntity(
    Point3D pntCenter,
    Plane refPlane,
    double Diameter,
    entityTypeDefination T,
    Color color,
    ref Entity refEntity)
  {
    Circle outer = new Circle(refPlane, Diameter / 2.0);
    if (refPlane == Plane.XZ)
    {
      outer.Translate(pntCenter.X, pntCenter.Y - 0.2, pntCenter.Z);
      devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) outer);
      refEntity = (Entity) region.ExtrudeAsMesh(-0.4, 0.1, Mesh.natureType.RichSmooth);
      refEntity.ColorMethod = colorMethodType.byEntity;
      refEntity.Color = color;
      refEntity.Selectable = false;
      CustomData customData = (CustomData) new ClipperOffset();
      ((CutterRuntimeSettings) customData).set_typeDefination(T);
      refEntity.EntityData = (object) customData;
    }
    if (!(refPlane == Plane.YZ))
      return;
    outer.Translate(pntCenter.X + 0.2, pntCenter.Y, pntCenter.Z);
    devDept.Eyeshot.Entities.Region region1 = new devDept.Eyeshot.Entities.Region((ICurve) outer);
    refEntity = (Entity) region1.ExtrudeAsMesh(-0.4, 0.1, Mesh.natureType.RichSmooth);
    refEntity.ColorMethod = colorMethodType.byEntity;
    refEntity.Color = color;
    refEntity.Selectable = false;
    CustomData customData1 = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData1).set_typeDefination(T);
    refEntity.EntityData = (object) customData1;
  }

  public void CreateMarkHexagonEntity(
    Point3D pntCenter,
    Plane refPlane,
    double Diameter,
    entityTypeDefination T,
    Color color,
    ref Entity refEntity)
  {
    if (refPlane == Plane.XZ)
    {
      devDept.Eyeshot.Entities.Region hexagon = devDept.Eyeshot.Entities.Region.CreateHexagon(refPlane, Diameter);
      hexagon.Translate(pntCenter.X, pntCenter.Y - 1.0, pntCenter.Z);
      refEntity = (Entity) hexagon.ExtrudeAsMesh(-2.0, 0.1, Mesh.natureType.RichSmooth);
      refEntity.ColorMethod = colorMethodType.byEntity;
      refEntity.Color = color;
      refEntity.Selectable = false;
      CustomData customData = (CustomData) new ClipperOffset();
      ((CutterRuntimeSettings) customData).set_typeDefination(T);
      refEntity.EntityData = (object) customData;
    }
    if (!(refPlane == Plane.YZ))
      return;
    devDept.Eyeshot.Entities.Region hexagon1 = devDept.Eyeshot.Entities.Region.CreateHexagon(refPlane, Diameter);
    hexagon1.Translate(pntCenter.X + 1.0, pntCenter.Y, pntCenter.Z);
    refEntity = (Entity) hexagon1.ExtrudeAsMesh(-2.0, 0.1, Mesh.natureType.RichSmooth);
    refEntity.ColorMethod = colorMethodType.byEntity;
    refEntity.Color = color;
    refEntity.Selectable = false;
    CustomData customData1 = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData1).set_typeDefination(T);
    refEntity.EntityData = (object) customData1;
  }

  public void CreateSortEntitiesAndArrow(
    buEntity sortEntity,
    Plane refPlane,
    ref List<Entity> createdEntities,
    double ArrowFilterDistance = 30.0)
  {
    createdEntities = new List<Entity>();
    CustomData customData1 = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData1).set_typeDefination(entityTypeDefination.Sorted);
    Entity copiedEntity = (Entity) null;
    buAngularDim.Copy(sortEntity, ref copiedEntity);
    copiedEntity.ColorMethod = colorMethodType.byEntity;
    copiedEntity.LineWeightMethod = colorMethodType.byEntity;
    if (((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.CamLeadin)
    {
      copiedEntity.Color = ((DrillMove) DrillCalcItem.varFoamSettings).LeadInColor;
      copiedEntity.LineWeight = 5f;
    }
    else if (((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.CamLeadOut)
    {
      copiedEntity.Color = ((DrillMove) DrillCalcItem.varFoamSettings).LeadOutColor;
      copiedEntity.LineWeight = 5f;
    }
    else if (((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.Connection)
    {
      copiedEntity.Color = ((DrillFound) DrillCalcItem.varFoamSettings).ConenctionColor;
      copiedEntity.LineWeight = 5f;
    }
    else if (((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.Upper | ((DirectionArrowSetting) ((CustomData) sortEntity).Info).isUpperEntity)
    {
      copiedEntity.Color = ((DrillMove) DrillCalcItem.varFoamSettings).SortUpperColor;
      copiedEntity.LineWeight = 5f;
    }
    else
    {
      copiedEntity.Color = ((DrillMove) DrillCalcItem.varFoamSettings).SortCutColor;
      copiedEntity.LineWeight = 3f;
    }
    copiedEntity.EntityData = (object) customData1;
    createdEntities.Add(copiedEntity);
    List<Entity> arrowEntities = new List<Entity>();
    buCall.\u0001.DirectionWireArrowHeadFromEntities(sortEntity, refPlane, ((DrillItem) DrillCalcItem.varFoamSettings).DirectionArrowHeadLength, ((DrillItem) DrillCalcItem.varFoamSettings).DirectionArrowHeadAngle, ref arrowEntities);
    double num1 = 0.0;
    for (int index = 0; index <= arrowEntities.Count - 1; ++index)
    {
      bool flag = true;
      if (index > 0 && arrowEntities[index].Vertices.Length >= 2 & arrowEntities[index - 1].Vertices.Length >= 2)
      {
        double num2 = Point3D.Distance(arrowEntities[index].Vertices[1], arrowEntities[index - 1].Vertices[1]);
        num1 += num2;
        if (num1 < ArrowFilterDistance)
          flag = false;
        else
          num1 = 0.0;
      }
      if (flag)
      {
        if (refPlane == Plane.XZ)
          arrowEntities[index].Translate(0.0, -0.5);
        else
          arrowEntities[index].Translate(-0.5, 0.0);
        arrowEntities[index].ColorMethod = colorMethodType.byEntity;
        arrowEntities[index].LineWeightMethod = colorMethodType.byEntity;
        CustomData customData2 = (CustomData) new ClipperOffset();
        ((CutterRuntimeSettings) customData2).set_typeDefination(entityTypeDefination.Sorted);
        arrowEntities[index].EntityData = (object) customData2;
        if (((DirectionArrowSetting) ((CustomData) sortEntity).Info).isUpperEntity | ((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.Upper | ((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.CamLeadin | ((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.CamLeadOut | ((CustomDataSurrogate) sortEntity).typeDefination == entityTypeDefination.Connection)
        {
          arrowEntities[index].Color = ((DrillMove) DrillCalcItem.varFoamSettings).SortUpperColor;
          arrowEntities[index].LineWeight = 5f;
        }
        else
        {
          arrowEntities[index].Color = ((DrillMove) DrillCalcItem.varFoamSettings).SortCutColor;
          arrowEntities[index].LineWeight = 3f;
        }
        createdEntities.Add(arrowEntities[index]);
      }
    }
  }
}
