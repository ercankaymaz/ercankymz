// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buLineCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.Flexo;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buLineCam : Line
{
  public Form OwnerForm;
  public TouchPadType TouchPayStyle;
  public List<string> ParCaptions;

  public static void ToDefEntity(buEntityList refEntity, int Space, ref ArrayList AL)
  {
    AL.Clear();
    AL = new ArrayList();
    AL.Add((object) (buImage5.SpaceChar(Space) + "<buEntityListData>"));
    AL.AddRange((ICollection) buText.ToDefEntity(((\u0084.\u0001) refEntity).Entities, Space + 2));
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<buEntityListAdder>"));
    AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListGroupInfo= {((IntersectNode) refEntity).GroupInfo.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListGroupType= {((\u0008.\u0001) refEntity).GroupType.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListToolType= {((\u0008.\u0001) refEntity).ToolType.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListAux= {((\u0012.\u0001) refEntity).Aux.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListDirection= {((\u0008.\u0001) refEntity).Direction.ToString()}");
    if (((IntersectNode) refEntity).pntMassCenter != (Point3D) null)
      AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListpntMassCenter= {buSerilization5.ToDef(((IntersectNode) refEntity).pntMassCenter)}");
    if (((\u0012.\u0001) refEntity).Marble != null)
      AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListMarble= {buSerilization5.ClassToString((object) ((\u0012.\u0001) refEntity).Marble)}");
    if (((\u0018.\u0001) refEntity).Layer != null)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) SketchAnalyseData.ToDef(((\u0018.\u0001) refEntity).Layer));
      if (arrayList.Count > 0)
        AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListLayer1= {arrayList[0].ToString()}");
    }
    if (((\u0018.\u0001) refEntity).Tool != null)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) ToolData5.ToDef(((\u0018.\u0001) refEntity).Tool));
      if (arrayList.Count >= 4)
      {
        AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListTool1= {arrayList[0].ToString()}");
        AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListTool2= {arrayList[1].ToString()}");
        AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListTool3= {arrayList[2].ToString()}");
        AL.Add((object) $"{buImage5.SpaceChar(Space + 4)}ListTool4= {arrayList[3].ToString()}");
      }
    }
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</buEntityListAdder>"));
    AL.Add((object) (buImage5.SpaceChar(Space) + "</buEntityListData>"));
  }

  public static void ToDefEntity(List<buEntityList> refEntities, int Space, ref ArrayList AL)
  {
    AL.Clear();
    AL = new ArrayList();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      AL.AddRange((ICollection) buArcCam.ToDefEntity(refEntities[index], Space));
  }

  public static ArrayList ToDefEntity(List<buEntityList> refEntities, int Space)
  {
    ArrayList defEntity = new ArrayList();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      defEntity.AddRange((ICollection) buArcCam.ToDefEntity(refEntities[index], Space));
    return defEntity;
  }

  public static void Decode(List<string> SL, ref buEntityList refEntity)
  {
    try
    {
      if (SL.Count < 2)
        return;
      refEntity = (buEntityList) new buArcCam();
      List<string> CalcList1 = new List<string>();
      List<List<string>> CalcList2 = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, SL, ref CalcList2);
      buImage5.ListToSpecificList("<buEntityListAdder>", "</buEntityListAdder>", false, SL, ref CalcList1);
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        buEntity buEntity = buText.Decode(CalcList2[index]);
        if (buEntity != null)
          ((\u0084.\u0001) refEntity).Entities.Add(buEntity);
      }
      if (CalcList1.Count >= 1)
      {
        string[] strArray = CalcList1[0].Split('=');
        if (strArray.Length >= 2)
          ((IntersectNode) refEntity).GroupInfo = strArray[1];
      }
      if (CalcList1.Count >= 2)
      {
        string[] strArray = CalcList1[1].Split('=');
        if (strArray.Length >= 2)
          ((\u0008.\u0001) refEntity).GroupType = (entityGroupType) Enum.Parse(typeof (entityGroupType), strArray[1], true);
      }
      if (CalcList1.Count >= 3)
      {
        string[] strArray = CalcList1[2].Split('=');
        if (strArray.Length >= 2)
          ((\u0008.\u0001) refEntity).ToolType = (entityToolType) Enum.Parse(typeof (entityToolType), strArray[1], true);
      }
      if (CalcList1.Count >= 4)
      {
        string[] strArray = CalcList1[3].Split('=');
        if (strArray.Length >= 2)
          ((\u0012.\u0001) refEntity).Aux = strArray[1];
      }
      if (CalcList1.Count >= 5)
      {
        string[] strArray = CalcList1[4].Split('=');
        if (strArray.Length >= 2)
          ((\u0008.\u0001) refEntity).Direction = (ClockDirectionType) Enum.Parse(typeof (ClockDirectionType), strArray[1], true);
      }
      for (int index = 5; index <= CalcList1.Count - 1; ++index)
      {
        if (CalcList1[index].IndexOf("ListpntMassCenter") >= 0)
        {
          string[] strArray = CalcList1[index].Split('=');
          if (strArray.Length >= 2)
            ((IntersectNode) refEntity).pntMassCenter = buSerilization5.DecoderFromPoint3D(strArray[1]);
        }
        if (CalcList1[index].IndexOf("ListMarble") >= 0)
        {
          string[] strArray = CalcList1[index].Split('=');
          if (strArray.Length >= 2)
          {
            object marble = (object) ((\u0012.\u0001) refEntity).Marble;
            buSerilization5.StringToClass(ref marble, strArray[1]);
          }
        }
        if (CalcList1[index].IndexOf("ListLayer1") >= 0)
        {
          string[] strArray = CalcList1[index].Split('=');
          if (strArray.Length >= 2)
          {
            object layer = (object) ((\u0018.\u0001) refEntity).Layer;
            buSerilization5.StringToClass(ref layer, strArray[1]);
          }
        }
        if (CalcList1[index].IndexOf("ListTool1") >= 0)
        {
          ((\u0018.\u0001) refEntity).Tool = (ToolBase5) new ToolGeometry5();
          string[] strArray = CalcList1[index].Split('=');
          if (strArray.Length >= 2)
          {
            EnumConverter enumConverter = new EnumConverter(typeof (ToolPurpose));
            ((ToolGeometry5) ((\u0018.\u0001) refEntity).Tool).Purpose = (ToolPurpose) enumConverter.ConvertFromString(strArray[1]);
          }
        }
        if (CalcList1[index].IndexOf("ListTool2") >= 0)
        {
          string[] strArray = CalcList1[index].Split('=');
          if (strArray.Length >= 2)
          {
            object data = (object) ((ToolGeometry5) ((\u0018.\u0001) refEntity).Tool).Data;
            buSerilization5.StringToClass(ref data, strArray[1]);
          }
        }
        if (CalcList1[index].IndexOf("ListTool3") >= 0)
        {
          string[] strArray = CalcList1[index].Split('=');
          if (strArray.Length >= 2)
          {
            object geometry = (object) ((ToolGeometry5) ((\u0018.\u0001) refEntity).Tool).Geometry;
            buSerilization5.StringToClass(ref geometry, strArray[1]);
          }
        }
        if (CalcList1[index].IndexOf("ListTool4") >= 0)
        {
          string[] strArray = CalcList1[index].Split('=');
          if (strArray.Length >= 2)
          {
            object camData = (object) ((ToolGeometry5) ((\u0018.\u0001) refEntity).Tool).CamData;
            buSerilization5.StringToClass(ref camData, strArray[1]);
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static buEntityList Decode(List<string> SL)
  {
    try
    {
      buEntityList refEntity = (buEntityList) new buArcCam();
      buLineCam.Decode(SL, ref refEntity);
      return refEntity;
    }
    catch (Exception ex)
    {
      return (buEntityList) null;
    }
  }

  public static void Copy(List<buEntityList> refEntities, ref List<buEntityList> copyEntities)
  {
    if (refEntities == null)
      return;
    copyEntities = new List<buEntityList>();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      copyEntities.Add((buEntityList) new buArcCam(refEntities[index]));
  }

  public static void Copy(
    List<List<buEntityList>> refEntities,
    ref List<List<buEntityList>> copyEntities)
  {
    if (refEntities == null)
      return;
    copyEntities = new List<List<buEntityList>>();
    for (int index1 = 0; index1 <= refEntities.Count - 1; ++index1)
    {
      List<buEntityList> buEntityListList = new List<buEntityList>();
      for (int index2 = 0; index2 <= refEntities[index1].Count - 1; ++index2)
        buEntityListList.Add((buEntityList) new buArcCam(refEntities[index1][index2]));
      if (buEntityListList.Count > 0)
        copyEntities.Add(buEntityListList);
    }
  }

  public override string ToString()
  {
    string str = "Entities: " + ((\u0084.\u0001) this).Entities.Count.ToString();
    if (((\u0008.\u0001) this).GroupType != 0)
      str = $"{str} - {((\u0008.\u0001) this).GroupType.ToString()}";
    if (((IntersectNode) this).GroupInfo.Length > 0)
      str = $"{str} - Info: {((IntersectNode) this).GroupInfo}";
    if (((\u0008.\u0001) this).ToolType != 0)
      str = $"{str} - {((\u0008.\u0001) this).ToolType.ToString()}";
    if (((\u0018.\u0001) this).Layer != null)
      str = $"{str} - Layer: {((DevideEventFormVars) ((\u0018.\u0001) this).Layer).Name}";
    if (((\u0018.\u0001) this).Tool != null)
      str = $"{str} - Tool: {((ToolCamData5) ((ToolGeometry5) ((\u0018.\u0001) this).Tool).Data).Name}";
    return str;
  }

  public abstract void m001874();

  public buLineCam()
  {
    ((\u0080.\u0001) this).ShapeName = "";
    ((\u0080.\u0001) this).Defination = (string) null;
    ((\u0080.\u0001) this).Aux = (string) null;
    ((\u0080.\u0001) this).SecondToolName = (string) null;
    ((\u0080.\u0001) this).ID = -1;
    ((\u0080.\u0001) this).Index = -1;
    ((\u0080.\u0001) this).Zone = 0;
    ((\u0012.\u0002) this).Priority = 0;
    ((\u0012.\u0002) this).Depth = 0.0;
    ((\u0012.\u0002) this).OffsetDistance = 0.0;
    ((\u0012.\u0002) this).DepthExtra = 0.0;
    ((\u0081.\u0001) this).feedPlunge = 0.0;
    ((\u0081.\u0001) this).feedCutting = 0.0;
    ((\u0081.\u0001) this).SpindleSpeed = 0.0;
    ((buClipperBase) this).DepthLevel = new List<double>();
    ((buClipperBase) this).Enable = true;
    ((buClipperBase) this).isEngraving = false;
    ((buClipperBase) this).isPocket = false;
    ((buClipperBase) this).planeName = planeBoxNames.Top;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
    ((buClipperBase) this).Corner = CornerLocation.RightTop;
    ((buClipperBase) this).Alignment = ObjectAlignment.MiddleCenter;
    ((buClipperBase) this).ShapeType = ShapeTypes.Rectangle;
    ((buClipperBase) this).Edit = (ShapeEdit) new ColorType();
    ((buClipperBase) this).ItemSize = (ShapeSizeInfo) new GCodeChars5();
    ((buClipper) this).LeadInOut = (ShapeLeadInOut) new GCodeGraphPoint5();
    ((buClipper) this).planeOperation = new Plane();
    ((buClipper) this).CornerPoint = new Point3D(0.0, 0.0, 0.0);
    ((buClipper) this).BasePoint = new Point3D(0.0, 0.0, 0.0);
    ((buClipper) this).Offset = new Point3D(0.0, 0.0, 0.0);
    ((buClipper) this).CalculatedPoint = new Point3D(0.0, 0.0, 0.0);
    ((buClipper) this).dimHorizontal = (buLinearDim) null;
    ((buClipper) this).dimVertical = (buLinearDim) null;
    ((buClipper) this).CornerDirection = new Vector3D(0.0, 0.0, 1.0);
    ((buClipper) this).entitiesShape = new List<buEntity>();
    ((buClipper) this).entitiesCam = new List<buEntity>();
    ((buClipper) this).entitiesDim = (List<buEntity>) null;
    ((buClipper) this).entitiesRef = (List<buEntity>) null;
    ((buClipper) this).entitySolid = new List<Entity>();
    ((buClipper) this).entityWireframe = new List<Entity>();
    ((buClipper) this).Clampers = (List<Clamper>) null;
    ((buClipper) this).multiCenter = (List<ShapeMultiCenterData>) null;
    ((buClipper) this).Cam = (camTp) null;
    ((buClipper) this).CamPar = (camParameters5) null;
    ((buClipper.\u0001) this).Tool = (ToolBase5) null;
    ((buClipper.\u0001) this).ProfileData = (ShapeProfileData) null;
    ((buClipper.\u0001) this).InfoMessages = (List<string>) null;
    ((buClipper.\u0001) this).Codes = (List<string>) null;
    ((ClipperOffset) this).OperationColor = Color.Cyan;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public static buShape Copy(buShape refItem)
  {
    buShape copyItem = (buShape) new buLineCam();
    buLineCam.Copy(refItem, ref copyItem);
    return copyItem;
  }

  public static void Copy(buShape refItem, ref buShape copyItem)
  {
    if (refItem.GetType() == typeof (buShapeRectangle))
      copyItem = (buShape) new buUpperLineEnt(refItem);
    if (refItem.GetType() == typeof (buShapeCircle))
      copyItem = (buShape) new buUpperLineEnt(refItem);
    if (refItem.GetType() == typeof (buShapeEllipse))
      copyItem = (buShape) new buUpperLineEnt(refItem);
    if (refItem.GetType() == typeof (buShapeKeyHole))
      copyItem = (buShape) new buLinearPathArrow(refItem);
    if (refItem.GetType() == typeof (buShapePolygon))
      copyItem = (buShape) new buUpperLineEnt(refItem);
    if (refItem.GetType() == typeof (buShapeSlot))
      copyItem = (buShape) new buUpperLineEnt(refItem);
    if (refItem.GetType() == typeof (buShapeFreeDraw))
      copyItem = (buShape) new buLinearPathArrow(refItem);
    if (refItem.GetType() == typeof (buShapeFreeLines))
      copyItem = (buShape) new buLinearPathArrow(refItem);
    if (refItem.GetType() == typeof (buShapeHole))
      copyItem = (buShape) new buLinearPathArrow(refItem);
    if (refItem.GetType() == typeof (buShapeHoleMulti))
      copyItem = (buShape) new buLinearPathArrow(refItem);
    if (refItem.GetType() == typeof (buShapeHole3))
      copyItem = (buShape) new buSelectionPoint(refItem);
    if (refItem.GetType() == typeof (buShapeCut))
      copyItem = (buShape) new buSelectionPoint(refItem);
    if (refItem.GetType() == typeof (buShapeProfiling))
      copyItem = (buShape) new buSelectionPoint(refItem);
    if (refItem.GetType() == typeof (buShapeEngrave))
      copyItem = (buShape) new buSelectionPoint(refItem);
    if (refItem.GetType() == typeof (buShapeJunction))
      copyItem = (buShape) new buSelectionPoint(refItem);
    if (refItem.GetType() == typeof (buShapeText))
      copyItem = (buShape) new buMaterial(refItem);
    if (refItem.GetType() == typeof (buShapeNotch))
      copyItem = (buShape) new CustomData(refItem);
    if (((buClipper.\u0001) refItem).InfoMessages != null)
    {
      ((buClipper.\u0001) copyItem).InfoMessages = new List<string>();
      for (int index = 0; index <= ((buClipper.\u0001) refItem).InfoMessages.Count - 1; ++index)
        ((buClipper.\u0001) copyItem).InfoMessages.Add(((buClipper.\u0001) refItem).InfoMessages[index]);
    }
    if (((buClipper.\u0001) refItem).Codes != null)
    {
      ((buClipper.\u0001) copyItem).Codes = new List<string>();
      for (int index = 0; index <= ((buClipper.\u0001) refItem).Codes.Count - 1; ++index)
        ((buClipper.\u0001) copyItem).Codes.Add(((buClipper.\u0001) refItem).Codes[index]);
    }
    ((buClipper) copyItem).entitiesShape.Clear();
    ((buClipper) copyItem).entitiesShape = new List<buEntity>();
    ((buClipper) copyItem).entitiesShape.AddRange((IEnumerable<buEntity>) buDiametricDim.Copy(((buClipper) refItem).entitiesShape));
    ((buClipper) copyItem).entitiesCam.Clear();
    ((buClipper) copyItem).entitiesCam = new List<buEntity>();
    ((buClipper) copyItem).entitiesCam.AddRange((IEnumerable<buEntity>) buDiametricDim.Copy(((buClipper) refItem).entitiesCam));
    if (((buClipper) refItem).entitiesRef != null)
    {
      ((buClipper) copyItem).entitiesRef = new List<buEntity>();
      ((buClipper) copyItem).entitiesRef.AddRange((IEnumerable<buEntity>) buDiametricDim.Copy(((buClipper) refItem).entitiesRef));
    }
    if (((buClipper) refItem).entitiesDim != null)
    {
      ((buClipper) copyItem).entitiesDim = new List<buEntity>();
      ((buClipper) copyItem).entitiesDim.AddRange((IEnumerable<buEntity>) buDiametricDim.Copy(((buClipper) refItem).entitiesDim));
    }
    if (((buClipper) refItem).Clampers != null)
    {
      ((buClipper) copyItem).Clampers = new List<Clamper>();
      RoboticSurfacePoint.Copy(((buClipper) refItem).Clampers, ref ((buClipper) copyItem).Clampers);
    }
    if (((buClipper.\u0001) refItem).ProfileData != null)
      ((buClipper.\u0001) copyItem).ProfileData = (ShapeProfileData) new hmiUICommands(((buClipper.\u0001) refItem).ProfileData);
    ((buClipper) copyItem).BasePoint = new Point3D(((buClipper) refItem).BasePoint.X, ((buClipper) refItem).BasePoint.Y, ((buClipper) refItem).BasePoint.Z);
    ((buClipper) copyItem).Offset = new Point3D(((buClipper) refItem).Offset.X, ((buClipper) refItem).Offset.Y, ((buClipper) refItem).Offset.Z);
    ((buClipper) copyItem).CornerPoint = new Point3D(((buClipper) refItem).CornerPoint.X, ((buClipper) refItem).CornerPoint.Y, ((buClipper) refItem).CornerPoint.Z);
    ((buClipper) copyItem).CalculatedPoint = new Point3D(((buClipper) refItem).CalculatedPoint.X, ((buClipper) refItem).CalculatedPoint.Y, ((buClipper) refItem).CalculatedPoint.Z);
    ((buClipper) copyItem).CornerDirection = new Vector3D(((buClipper) refItem).CornerDirection.X, ((buClipper) refItem).CornerDirection.Y, ((buClipper) refItem).CornerDirection.Z);
    ((buClipperBase) copyItem).Edit = (ShapeEdit) new ColorType(((buClipperBase) refItem).Edit);
    ((buClipperBase) copyItem).ItemSize = (ShapeSizeInfo) new GCodeGraphPoint5(((buClipperBase) refItem).ItemSize);
    ((buClipper) copyItem).LeadInOut = (ShapeLeadInOut) new GCodeGraphPoint5(((buClipper) refItem).LeadInOut);
    ((buClipper) copyItem).planeOperation = (Plane) ((buClipper) refItem).planeOperation.Clone();
    if (((buClipper) refItem).multiCenter != null)
    {
      ((buClipper) copyItem).multiCenter = new List<ShapeMultiCenterData>();
      for (int index = 0; index <= ((buClipper) refItem).multiCenter.Count - 1; ++index)
        ((buClipper) copyItem).multiCenter.Add(((buClipper) refItem).multiCenter[index]);
    }
    if (((buClipper) refItem).entitySolid != null)
      buRadialDim.Copy(((buClipper) refItem).entitySolid, ref ((buClipper) copyItem).entitySolid);
    if (((buClipper) refItem).entityWireframe != null)
    {
      ((buClipper) copyItem).entityWireframe = new List<Entity>();
      buRadialDim.Copy(((buClipper) refItem).entityWireframe, ref ((buClipper) copyItem).entityWireframe);
    }
    if (((buClipperBase) refItem).DepthLevel != null)
    {
      ((buClipperBase) copyItem).DepthLevel = new List<double>();
      for (int index = 0; index <= ((buClipperBase) refItem).DepthLevel.Count - 1; ++index)
        ((buClipperBase) copyItem).DepthLevel.Add(((buClipperBase) refItem).DepthLevel[index]);
    }
    if (((buClipper) refItem).Cam != null)
      ((buClipper) copyItem).Cam = new camTp(((buClipper) refItem).Cam);
    if (((buClipper.\u0001) refItem).Tool != null)
      ((buClipper.\u0001) copyItem).Tool = (ToolBase5) new ToolGeometry5(((buClipper.\u0001) refItem).Tool);
    if (((buClipper) refItem).Cam != null)
      ((buClipper) copyItem).Cam = new camTp(((buClipper) refItem).Cam);
    if (((buClipper) refItem).CamPar == null)
      return;
    ((buClipper) copyItem).CamPar = (camParameters5) new camRuntime5(((buClipper) refItem).CamPar);
  }

  public static void Copy(List<buShape> refItem, ref List<buShape> copyItem)
  {
    copyItem = new List<buShape>();
    for (int index = 0; index <= refItem.Count - 1; ++index)
    {
      buShape copyItem1 = (buShape) new buLineCam();
      buLineCam.Copy(refItem[index], ref copyItem1);
      copyItem.Add(copyItem1);
    }
  }

  public static string ToDefination(buShape shape)
  {
    string defination = "None";
    try
    {
      if (AppLanguage.CadCamDynamic.Count > 0)
      {
        if (shape.GetType() == typeof (buShapeCircle))
        {
          buShapeCircle buShapeCircle = shape as buShapeCircle;
          defination = $"{buLangTranslate.preDef.Cirlce} - {buImage5.DefItem(buLangTranslate.preDef.Diameter, (object) (((ClipperOffset) buShapeCircle).Radius * 2.0), SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapeCircle).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeCircle).planeName))}";
        }
        else if (shape.GetType() == typeof (buShapeEllipse))
        {
          buShapeEllipse buShapeEllipse = shape as buShapeEllipse;
          defination = $"{buLangTranslate.preDef.Ellipse} - {buImage5.DefItem(buLangTranslate.preDef.DiaX, (object) (((ClipperOffset) buShapeEllipse).RadiusX * 2.0), SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.DiaY, (object) (((ClipperOffset) buShapeEllipse).RadiusY * 2.0))}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapeEllipse).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeEllipse).planeName))}";
          if (((ClipperOffset) buShapeEllipse).Angle != 0.0)
            defination += buImage5.DefItem(buLangTranslate.preDef.Angle, (object) ((ClipperOffset) buShapeEllipse).Angle);
        }
        else if (shape.GetType() == typeof (buShapeFreeDraw))
        {
          buShapeFreeDraw buShapeFreeDraw = shape as buShapeFreeDraw;
          double num1 = 0.0;
          double num2 = 0.0;
          if (((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Bottom)
          {
            num1 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.X;
            num2 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Y;
          }
          if (((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Front | ((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Back)
          {
            num1 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.X;
            num2 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Z;
          }
          if (((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Bottom)
          {
            num1 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Y;
            num2 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Z;
          }
          defination = $"{buLangTranslate.preDef.FreeDraw} - {buImage5.DefItem(buLangTranslate.preDef.Width, (object) num1, SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.Height, (object) num2)}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapeFreeDraw).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeFreeDraw).planeName))}";
          if (((DiemakerGrindingShapeSettings) buShapeFreeDraw).Angle != 0.0)
            defination += buImage5.DefItem(buLangTranslate.preDef.Angle, (object) ((DiemakerGrindingShapeSettings) buShapeFreeDraw).Angle);
        }
        else if (shape.GetType() == typeof (buShapeFreeLines))
        {
          buShapeFreeLines buShapeFreeLines = shape as buShapeFreeLines;
          double num3 = 0.0;
          double num4 = 0.0;
          if (((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Bottom)
          {
            num3 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.X;
            num4 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Y;
          }
          if (((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Front | ((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Back)
          {
            num3 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.X;
            num4 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Z;
          }
          if (((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Bottom)
          {
            num3 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Y;
            num4 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Z;
          }
          defination = $"{buLangTranslate.preDef.FreeLines} - {buImage5.DefItem(buLangTranslate.preDef.Width, (object) num3, SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.Height, (object) num4)}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapeFreeLines).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeFreeLines).planeName))}";
        }
        else if (shape.GetType() == typeof (buShapeKeyHole))
        {
          buShapeKeyHole buShapeKeyHole = shape as buShapeKeyHole;
          defination = $"{buLangTranslate.preDef.KeyHole} - {buImage5.DefItem(buLangTranslate.preDef.HeadDiameter, (object) ((DiemakerGrindingShapeSettings) buShapeKeyHole).HeadDiameter, SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.Diameter, (object) ((DiemakerGrindingShapeSettings) buShapeKeyHole).Diameter)}{buImage5.DefItem(buLangTranslate.preDef.Length, (object) ((DiemakerGrindingShapeSettings) buShapeKeyHole).Length)}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapeKeyHole).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeKeyHole).planeName))}";
          if (((DiemakerGrindingShapeSettings) buShapeKeyHole).Angle != 0.0)
            defination += buImage5.DefItem(buLangTranslate.preDef.Angle, (object) ((DiemakerGrindingShapeSettings) buShapeKeyHole).Angle);
        }
        else if (shape.GetType() == typeof (buShapePolygon))
        {
          buShapePolygon buShapePolygon = shape as buShapePolygon;
          defination = $"{buLangTranslate.preDef.Polygon} - {buImage5.DefItem(buLangTranslate.preDef.Diameter, (object) (((ClipperOffset) buShapePolygon).Radius * 2.0), SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.Side, (object) ((buFlexoCalc) buShapePolygon).Side)}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapePolygon).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapePolygon).planeName))}";
          if (((buDiamakerCalc) buShapePolygon).Angle != 0.0)
            defination += buImage5.DefItem(buLangTranslate.preDef.Angle, (object) ((buDiamakerCalc) buShapePolygon).Angle);
        }
        else if (shape.GetType() == typeof (buShapeRectangle))
        {
          buShapeRectangle buShapeRectangle = shape as buShapeRectangle;
          defination = $"{buLangTranslate.preDef.Rect} - {buImage5.DefItem(buLangTranslate.preDef.Width, (object) ((ClipperOffset) buShapeRectangle).Width, SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.Height, (object) ((ClipperOffset) buShapeRectangle).Height)}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapeRectangle).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeRectangle).planeName))}";
          if (((ClipperOffset) buShapeRectangle).Radius != 0.0)
            defination += buImage5.DefItem(buLangTranslate.preDef.Radius, (object) ((ClipperOffset) buShapeRectangle).Radius);
          if (((ClipperOffset) buShapeRectangle).Angle != 0.0)
            defination += buImage5.DefItem(buLangTranslate.preDef.Angle, (object) ((ClipperOffset) buShapeRectangle).Angle);
        }
        else if (shape.GetType() == typeof (buShapeSlot))
        {
          buShapeSlot buShapeSlot = shape as buShapeSlot;
          defination = $"{buLangTranslate.preDef.Slot} - {buImage5.DefItem(buLangTranslate.preDef.Diameter, (object) ((DiemakerGrindingShapeSettings) buShapeSlot).Diameter, SeperastorPre: "")}{buImage5.DefItem(buLangTranslate.preDef.Length, (object) ((DiemakerGrindingShapeSettings) buShapeSlot).Length)}{buImage5.DefItem(buLangTranslate.preDef.Depth, (object) ((\u0012.\u0002) buShapeSlot).Depth)}{buImage5.DefItem(buLangTranslate.preDef.Plane, (object) buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeSlot).planeName))}";
          if (((DiemakerGrindingShapeSettings) buShapeSlot).Angle != 0.0)
            defination += buImage5.DefItem(buLangTranslate.preDef.Angle, (object) ((DiemakerGrindingShapeSettings) buShapeSlot).Angle);
        }
      }
      else if (shape.GetType() == typeof (buShapeCircle))
      {
        buShapeCircle buShapeCircle = shape as buShapeCircle;
        defination = $"Circle - Diameter: {(((ClipperOffset) buShapeCircle).Radius * 2.0).ToString("f2")}Depth: {((\u0012.\u0002) buShapeCircle).Depth.ToString("f2")} , Plane: {buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeCircle).planeName)}";
      }
      else if (shape.GetType() == typeof (buShapeEllipse))
      {
        buShapeEllipse buShapeEllipse = shape as buShapeEllipse;
        string[] strArray = new string[8];
        strArray[0] = "Ellipse - DiameterX: ";
        double num = ((ClipperOffset) buShapeEllipse).RadiusX * 2.0;
        strArray[1] = num.ToString("f2");
        strArray[2] = " , DiameterY: ";
        num = ((ClipperOffset) buShapeEllipse).RadiusY * 2.0;
        strArray[3] = num.ToString("f2");
        strArray[4] = "Depth: ";
        strArray[5] = ((\u0012.\u0002) buShapeEllipse).Depth.ToString("f2");
        strArray[6] = " , Plane: ";
        strArray[7] = buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeEllipse).planeName);
        defination = string.Concat(strArray);
        if (((ClipperOffset) buShapeEllipse).Angle != 0.0)
          defination = $"{defination} , Angle: {((ClipperOffset) buShapeEllipse).Angle.ToString("f2")}";
      }
      else if (shape.GetType() == typeof (buShapeFreeDraw))
      {
        buShapeFreeDraw buShapeFreeDraw = shape as buShapeFreeDraw;
        double num5 = 0.0;
        double num6 = 0.0;
        if (((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Bottom)
        {
          num5 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.X;
          num6 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Y;
        }
        if (((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Front | ((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Back)
        {
          num5 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.X;
          num6 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Z;
        }
        if (((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeDraw).planeName == planeBoxNames.Bottom)
        {
          num5 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Y;
          num6 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).ItemSize).MinBox.Z;
        }
        defination = $"Free Draw - Width: {num5.ToString("f2")} , Height: {num6.ToString("f2")}Depth: {((\u0012.\u0002) buShapeFreeDraw).Depth.ToString("f2")} , Plane: {buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeFreeDraw).planeName)}";
        if (((DiemakerGrindingShapeSettings) buShapeFreeDraw).Angle != 0.0)
          defination = $"{defination} , Angle: {((DiemakerGrindingShapeSettings) buShapeFreeDraw).Angle.ToString("f2")}";
      }
      else if (shape.GetType() == typeof (buShapeFreeLines))
      {
        buShapeFreeLines buShapeFreeLines = shape as buShapeFreeLines;
        double num7 = 0.0;
        double num8 = 0.0;
        if (((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Bottom)
        {
          num7 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.X;
          num8 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Y;
        }
        if (((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Front | ((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Back)
        {
          num7 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.X - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.X;
          num8 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Z;
        }
        if (((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Top | ((buClipperBase) buShapeFreeLines).planeName == planeBoxNames.Bottom)
        {
          num7 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Y - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Y;
          num8 = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MaxBox.Z - ((ShapeRuntimeData) ((buClipperBase) buShapeFreeLines).ItemSize).MinBox.Z;
        }
        defination = $"Free Line - Width: {num7.ToString("f2")} , Height: {num8.ToString("f2")}Depth: {((\u0012.\u0002) buShapeFreeLines).Depth.ToString("f2")} , Plane: {buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeFreeLines).planeName)}";
      }
      else if (shape.GetType() == typeof (buShapeKeyHole))
      {
        buShapeKeyHole buShapeKeyHole = shape as buShapeKeyHole;
        defination = $"KeyHole - Head Diameter: {((DiemakerGrindingShapeSettings) buShapeKeyHole).HeadDiameter.ToString("f2")} , Diameter: {((DiemakerGrindingShapeSettings) buShapeKeyHole).Diameter.ToString("f2")} , Length: {((DiemakerGrindingShapeSettings) buShapeKeyHole).Length.ToString("f2")}Depth: {((\u0012.\u0002) buShapeKeyHole).Depth.ToString("f2")} , Plane: {buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeKeyHole).planeName)}";
        if (((DiemakerGrindingShapeSettings) buShapeKeyHole).Angle != 0.0)
          defination = $"{defination} , Angle: {((DiemakerGrindingShapeSettings) buShapeKeyHole).Angle.ToString("f2")}";
      }
      else if (shape.GetType() == typeof (buShapePolygon))
      {
        buShapePolygon buShapePolygon = shape as buShapePolygon;
        defination = $"Polygon - Diameter: {(((ClipperOffset) buShapePolygon).Radius * 2.0).ToString("f2")} , Side: {((buFlexoCalc) buShapePolygon).Side.ToString("f2")}Depth: {((\u0012.\u0002) buShapePolygon).Depth.ToString("f2")} , Plane: {buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapePolygon).planeName)}";
        if (((buDiamakerCalc) buShapePolygon).Angle != 0.0)
          defination = $"{defination} , Angle: {((buDiamakerCalc) buShapePolygon).Angle.ToString("f2")}";
      }
      else if (shape.GetType() == typeof (buShapeRectangle))
      {
        buShapeRectangle buShapeRectangle = shape as buShapeRectangle;
        defination = $"Rectangle - Width: {((ClipperOffset) buShapeRectangle).Width.ToString("f2")} , Height: {((ClipperOffset) buShapeRectangle).Height.ToString("f2")}Depth: {((\u0012.\u0002) buShapeRectangle).Depth.ToString("f2")} , Plane: {buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeRectangle).planeName)}";
        if (((ClipperOffset) buShapeRectangle).Radius > 0.0)
          defination = $"{defination} , Radius: {((ClipperOffset) buShapeRectangle).Radius.ToString("f2")}";
        if (((ClipperOffset) buShapeRectangle).Angle != 0.0)
          defination = $"{defination} , Angle: {((ClipperOffset) buShapeRectangle).Angle.ToString("f2")}";
      }
      else if (shape.GetType() == typeof (buShapeSlot))
      {
        buShapeSlot buShapeSlot = shape as buShapeSlot;
        defination = $"Slot - Diameter: {((DiemakerGrindingShapeSettings) buShapeSlot).Diameter.ToString("f2")} , Length: {((DiemakerGrindingShapeSettings) buShapeSlot).Length.ToString("f2")}Depth: {((\u0012.\u0002) buShapeSlot).Depth.ToString("f2")} , Plane: {buLangTranslate.EnumToLang((Enum) ((buClipperBase) buShapeSlot).planeName)}";
        if (((DiemakerGrindingShapeSettings) buShapeSlot).Angle != 0.0)
          defination = $"{defination} , Angle: {((DiemakerGrindingShapeSettings) buShapeSlot).Angle.ToString("f2")}";
      }
      return defination;
    }
    catch (Exception ex)
    {
      return defination;
    }
  }

  public static int ToImageIndex(buShape shape)
  {
    return !(shape.GetType() == typeof (buShapeCircle)) ? (!(shape.GetType() == typeof (buShapeEllipse)) ? (!(shape.GetType() == typeof (buShapeFreeDraw)) ? (!(shape.GetType() == typeof (buShapeKeyHole)) ? (!(shape.GetType() == typeof (buShapePolygon)) ? (!(shape.GetType() == typeof (buShapeRectangle)) ? (!(shape.GetType() == typeof (buShapeSlot)) ? -1 : 5) : 0) : 4) : 3) : 6) : 2) : 1;
  }

  public double DirArrowDistances
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }

  public CamMoveType MoveType
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }

  public int CamID
  {
    [CompilerGenerated, SpecialName] get => ((CutterNotch) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((CutterNotch) this).\u0001 = value;
  }
}
