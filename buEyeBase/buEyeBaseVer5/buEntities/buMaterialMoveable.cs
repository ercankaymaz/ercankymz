// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buMaterialMoveable
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Flexo;
using devDept.Eyeshot.Entities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buMaterialMoveable : BlockReference
{
  public List<string> ParCaptions;
  public DialogResult Result;
  public double ValuePersentage;
  public int DecimalPlace;
  public object Value;
  private object \u0001;
  private IContainer \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal buClassViewerColor5 \u0001;
  public static byte f0037F9;
  public string OkCaption;
  public string CancelCaption;
  public string FormCaption;
  public List<string> ParCaptions;
  public DialogResult Result;
  public double ValuePersentage;

  public ArrayList ToDef(int Space, string Char = "")
  {
    ArrayList def = new ArrayList();
    def.Add((object) $"{buImage5.SpaceChar(Space)}<buShape{Char}>");
    if (this is buShapeRectangle)
    {
      buShapeRectangle buShapeRectangle = this as buShapeRectangle;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeRectangle"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Width: {((ClipperOffset) buShapeRectangle).Width.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((ClipperOffset) buShapeRectangle).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((ClipperOffset) buShapeRectangle).Angle.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((ClipperOffset) buShapeRectangle).Radius.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Chamfer: {((ClipperOffset) buShapeRectangle).Chamfer.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buShapeCircle)
    {
      buShapeCircle buShapeCircle = this as buShapeCircle;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeCircle"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((ClipperOffset) buShapeCircle).Radius.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buShapeEllipse)
    {
      buShapeEllipse buShapeEllipse = this as buShapeEllipse;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeEllipse"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}RadiusX: {((ClipperOffset) buShapeEllipse).RadiusX.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}RadiusY: {((ClipperOffset) buShapeEllipse).RadiusY.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((ClipperOffset) buShapeEllipse).Angle.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buShapePolygon)
    {
      buShapePolygon buShapePolygon = this as buShapePolygon;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapePolygon"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((ClipperOffset) buShapePolygon).Radius.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Side: {((buFlexoCalc) buShapePolygon).Side.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((buDiamakerCalc) buShapePolygon).Angle.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buShapeSlot)
    {
      buShapeSlot buShapeSlot = this as buShapeSlot;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeSlot"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Diameter: {((DiemakerGrindingShapeSettings) buShapeSlot).Diameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Length: {((DiemakerGrindingShapeSettings) buShapeSlot).Length.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((DiemakerGrindingShapeSettings) buShapeSlot).Angle.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buShapeKeyHole)
    {
      buShapeKeyHole buShapeKeyHole = this as buShapeKeyHole;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeKeyHole"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}HeadDiameter: {((DiemakerGrindingShapeSettings) buShapeKeyHole).HeadDiameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Diameter: {((DiemakerGrindingShapeSettings) buShapeKeyHole).Diameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Length: {((DiemakerGrindingShapeSettings) buShapeKeyHole).Length.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((DiemakerGrindingShapeSettings) buShapeKeyHole).Angle.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buShapeFreeDraw)
    {
      buShapeFreeDraw buShapeFreeDraw = this as buShapeFreeDraw;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeFreeDraw"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Width: {((DiemakerGrindingShapeSettings) buShapeFreeDraw).Width.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((DiemakerGrindingShapeSettings) buShapeFreeDraw).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((DiemakerGrindingShapeSettings) buShapeFreeDraw).Angle.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this is buShapeFreeLines)
    {
      buShapeFreeLines buShapeFreeLines = this as buShapeFreeLines;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeFreeLines"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Width: {((DiemakerGrindingShapeSettings) buShapeFreeLines).Width.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((DiemakerGrindingShapeSettings) buShapeFreeLines).Height.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeHole))
    {
      buShapeHole buShapeHole = this as buShapeHole;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeHole"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Diameter: {((DiemakerGrindingShapeSettings) buShapeHole).Diameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DrillType: {((DiemakerGrindingShapeSettings) buShapeHole).DrillType.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}isMilling: {((DiemakerGrindingShapeSettings) buShapeHole).isMilling.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeHoleMulti))
    {
      buShapeHoleMulti buShapeHoleMulti = this as buShapeHoleMulti;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeHoleMulti"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Diameter: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).Diameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DrillType: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).DrillType.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}isMilling: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).isMilling.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Count: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).Count.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Distance: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).Distance.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}StartDistance: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).StartDistance.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}EndDistance: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).EndDistance.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((DiemakerGrindingShapeSettings) buShapeHoleMulti).Angle.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeHole3))
    {
      buShapeHole3 buShapeHole3 = this as buShapeHole3;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeHole3"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Diameter: {((DiemakerGrindingShapeSettings) buShapeHole3).Diameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DrillType: {((DiemakerGrindingShapeSettings) buShapeHole3).DrillType.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}isMilling: {((DiemakerGrindingShapeSettings) buShapeHole3).isMilling.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DiameterOutside: {((DiemakerGrindingShapeSettings) buShapeHole3).DiameterOutside.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Hole3Angle: {((DiemakerGrindingShapeSettings) buShapeHole3).Hole3Angle.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DistanceX: {((DiemakerGrindingShapeSettings) buShapeHole3).DistanceX.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DistanceY: {((DiemakerGrindingShapeSettings) buShapeHole3).DistanceY.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeCut))
    {
      buShapeCut buShapeCut = this as buShapeCut;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeCut"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Diameter: {((DiemakerGrindingShapeSettings) buShapeCut).Diameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Length: {((DiemakerGrindingShapeSettings) buShapeCut).Length.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((DiemakerGrindingShapeSettings) buShapeCut).Angle.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}StartDistance: {((DiemakerGrindingShapeSettings) buShapeCut).StartDistance.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}EndDistance: {((DiemakerGrindingShapeSettings) buShapeCut).EndDistance.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}CutType: {((DiemakerGrindingShapeSettings) buShapeCut).CutType.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}isMilling: {((DiemakerGrindingShapeSettings) buShapeCut).isMilling.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeProfiling))
    {
      buShapeProfiling buShapeProfiling = this as buShapeProfiling;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeProfiling"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Radius: {((buCutter) buShapeProfiling).Radius.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Length: {((CutterIsoEntities) buShapeProfiling).Length.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Width: {((CutterIsoEntities) buShapeProfiling).Width.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((CutterIsoEntities) buShapeProfiling).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}ProfilingType: {((CutterIsoEntities) buShapeProfiling).ProfilingType.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeJunction))
    {
      buShapeJunction buShapeJunction = this as buShapeJunction;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeJunction"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Diameter: {((CutterIsoFileSettings) buShapeJunction).Diameter.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}DiameterOutside: {((CutterIsoFileSettings) buShapeJunction).DiameterOutside.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Distance: {((CutterIsoFileSettings) buShapeJunction).Distance.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}JunctionType: {((CutterIsoFileItems) buShapeJunction).JunctionType.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}isMilling: {((CutterRuntimeSettings) buShapeJunction).isMilling.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeText))
    {
      buShapeText buShapeText = this as buShapeText;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeText"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Width: {((CutterRuntimeSettings) buShapeText).Width.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Height: {((CutterProgramSettings) buShapeText).Height.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}Angle: {((CutterProgramSettings) buShapeText).Angle.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextString: {((CutterProgramSettings) buShapeText).TextString.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextFontName: {((CutterProgramSettings) buShapeText).TextFont.Name.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextFontSize: {((CutterProgramSettings) buShapeText).TextFont.Size.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}TextFontStyle: {((CutterProgramSettings) buShapeText).TextFont.Style.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    if (this.GetType() == typeof (buShapeNotch))
    {
      buShapeNotch buShapeNotch = this as buShapeNotch;
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "buShapeNotch"));
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchWidth: {((CutterProgramSettings) buShapeNotch).NotchWidth.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchHeight: {((CutterProgramSettings) buShapeNotch).NotchHeight.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchStartHeight: {((CutterProgramSettings) buShapeNotch).NotchStartHeight.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchAngle: {((CutterProgramSettings) buShapeNotch).NotchAngle.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchUpDown: {((CutterProgramSettings) buShapeNotch).NotchUpDown.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchFrontBack: {((CutterProgramSettings) buShapeNotch).NotchFrontBack.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchLocation: {((CutterProgramSettings) buShapeNotch).NotchLocation.ToString()}");
      def.Add((object) $"{buImage5.SpaceChar(Space + 2)}NotchOPType: {((CutterProgramSettings) buShapeNotch).NotchOPType.ToString()}");
      def.AddRange((ICollection) this.ToDefCommon(Space + 2));
    }
    def.Add((object) $"{buImage5.SpaceChar(Space)}</buShape{Char}>");
    return def;
  }

  public ArrayList ToDefCommon(int Space)
  {
    ArrayList AL = new ArrayList();
    AL.Add((object) (buImage5.SpaceChar(Space) + "<CommonShape>"));
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}ShapeName: {((\u0080.\u0001) this).ShapeName.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Defination: {((\u0080.\u0001) this).Defination.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Aux: {((\u0080.\u0001) this).Aux.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}ID: {((\u0080.\u0001) this).ID.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Index: {((\u0080.\u0001) this).Index.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Zone: {((\u0080.\u0001) this).Zone.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Depth: {((\u0012.\u0002) this).Depth.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}DepthExtra: {((\u0012.\u0002) this).DepthExtra.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}OffsetDistance: {((\u0012.\u0002) this).OffsetDistance.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}feedCutting: {((\u0081.\u0001) this).feedCutting.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}feedPlunge: {((\u0081.\u0001) this).feedPlunge.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}SpindleSpeed: {((\u0081.\u0001) this).SpindleSpeed.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Enable: {((buClipperBase) this).Enable.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}isEngraving: {((buClipperBase) this).isEngraving.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}isPocket: {((buClipperBase) this).isPocket.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}planeName: {((buClipperBase) this).planeName.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}ShapeGroup: {((buClipperBase) this).ShapeGroup.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Corner: {((buClipperBase) this).Corner.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Alignment: {((buClipperBase) this).Alignment.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}ShapeType: {((buClipperBase) this).ShapeType.ToString()}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Color: {buFile5.ColorToString(((ClipperOffset) this).OperationColor, ColorConvertType.String)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CornerPoint: {buSerilization5.ToDef(((buClipper) this).CornerPoint)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}BasePoint: {buSerilization5.ToDef(((buClipper) this).BasePoint)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Offset: {buSerilization5.ToDef(((buClipper) this).Offset)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CalculatedPoint: {buSerilization5.ToDef(((buClipper) this).CalculatedPoint)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CornerDirection: {buSerilization5.ToDef(((buClipper) this).CornerDirection)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Plane = {buSerilization5.ToDef(((buClipper) this).planeOperation)}");
    if (((buClipper.\u0001) this).Tool != null)
      AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}ToolName: {((ToolCamData5) ((ToolGeometry5) ((buClipper.\u0001) this).Tool).Data).Name.ToString()}");
    else
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "ToolName: "));
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}Edit = {buSerilization5.ClassToString((object) ((buClipperBase) this).Edit)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}EditArray = {buSerilization5.ClassToString((object) ((ShapeRuntimeData) ((buClipperBase) this).Edit).ArrayData)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}EditMirror = {buSerilization5.ClassToString((object) ((ShapeRuntimeData) ((buClipperBase) this).Edit).MirrorData)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}ItemSize = {buSerilization5.ClassToString((object) ((buClipperBase) this).ItemSize)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}LeadInOut = {buSerilization5.ClassToString((object) ((buClipper) this).LeadInOut)}");
    if (((\u0080.\u0001) this).SecondToolName != null)
      AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}SecondToolName: {((\u0080.\u0001) this).SecondToolName.ToString()}");
    else
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "SecondToolName: "));
    if (((buClipperBase) this).DepthLevel.Count > 0)
    {
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<DepthLevel>"));
      for (int index = 0; index <= ((buClipperBase) this).DepthLevel.Count - 1; ++index)
        AL.Add((object) ((buClipperBase) this).DepthLevel[index].ToString());
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</DepthLevel>"));
    }
    if (((buClipper) this).CamPar != null)
      camOffset5.ToDefSingleLine(((buClipper) this).CamPar, ref AL, "", Space + 2);
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<entitiesShape>"));
    AL.AddRange((ICollection) buText.ToDefEntity(((buClipper) this).entitiesShape, Space + 4));
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</entitiesShape>"));
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<entitiesCam>"));
    AL.AddRange((ICollection) buText.ToDefEntity(((buClipper) this).entitiesCam, Space + 4));
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</entitiesCam>"));
    if (((buClipper) this).entitiesRef != null)
    {
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<entitiesRef>"));
      AL.AddRange((ICollection) buText.ToDefEntity(((buClipper) this).entitiesRef, Space + 4));
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</entitiesRef>"));
    }
    if (((buClipper) this).multiCenter != null)
    {
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<multiCenter>"));
      for (int index = 0; index <= ((buClipper) this).multiCenter.Count - 1; ++index)
        AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}multiCenter = {buSerilization5.ClassToString((object) ((buClipper) this).multiCenter[index])}");
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</multiCenter>"));
    }
    AL.Add((object) (buImage5.SpaceChar(Space) + "</CommonShape>"));
    return AL;
  }

  static buMaterialMoveable() => ClipperOffset.ToolList = new List<ToolBase5>();

  public buMaterialMoveable()
  {
    ((ClipperOffset) this).Width = 10.0;
    ((ClipperOffset) this).Height = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
    ((ClipperOffset) this).Radius = 0.0;
    ((ClipperOffset) this).Chamfer = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((buClipperBase) this).ShapeType = ShapeTypes.Rectangle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }

  public buMaterialMoveable(double width, double height)
  {
    ((ClipperOffset) this).Width = 10.0;
    ((ClipperOffset) this).Height = 10.0;
    ((ClipperOffset) this).Angle = 0.0;
    ((ClipperOffset) this).Radius = 0.0;
    ((ClipperOffset) this).Chamfer = 0.0;
    // ISSUE: explicit constructor call
    ((buLineCam) this).\u002Ector();
    ((ClipperOffset) this).Width = width;
    ((ClipperOffset) this).Height = height;
    ((buClipperBase) this).ShapeType = ShapeTypes.Rectangle;
    ((buClipperBase) this).ShapeGroup = ShapeGroup.Shape;
  }
}
