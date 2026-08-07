// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Scale
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Variables;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_Scale : Form
{
  internal ToolStripSeparator \u0006;
  internal ToolStripMenuItem \u0013;
  internal ToolStripMenuItem \u0014;
  internal ToolStripMenuItem \u0015;
  internal ToolStripSeparator \u0007;
  internal DataGridView \u0001;
  public Button btn_find;
  public static byte f000AFE;
  public FormProperties Properties;
  public static List<string> Captions;
  public AnalyseEntitiesSetting Settings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  public NumericUpDown spn_entminlen;
  internal Label \u0001;
  internal Label \u0002;
  public NumericUpDown spn_gapminlen;
  internal Label \u0003;
  public NumericUpDown spn_gapmaxlen;
  internal Label \u0004;
  internal CheckBox \u0006;
  internal CheckBox \u0007;

  public abstract void m000963();

  public F_Scale()
  {
    ((F_CutterOffsetEntities) this).TotalTimeAsSec = 0.0;
    ((F_NotchEdit) this).OperationTimeAsSec = 0.0;
    ((F_NotchEdit) this).QuickMoveTimeAsSec = 0.0;
    ((F_NotchEdit) this).TotalMCodeTimeAsSec = 0.0;
    ((F_NotchEdit) this).TotalLengthAsMeter = 0.0;
    ((F_NotchEdit) this).OperationLengthAsMeter = 0.0;
    ((F_NotchEdit) this).QuickMoveLengthAsMeter = 0.0;
    ((F_NotchEdit) this).NumberOfToolChange = 0;
    ((F_NotchEdit) this).NoDefinedMCodes = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public F_Scale(MachineGCodeExecutionResult data)
  {
    ((F_CutterOffsetEntities) this).TotalTimeAsSec = 0.0;
    ((F_NotchEdit) this).OperationTimeAsSec = 0.0;
    ((F_NotchEdit) this).QuickMoveTimeAsSec = 0.0;
    ((F_NotchEdit) this).TotalMCodeTimeAsSec = 0.0;
    ((F_NotchEdit) this).TotalLengthAsMeter = 0.0;
    ((F_NotchEdit) this).OperationLengthAsMeter = 0.0;
    ((F_NotchEdit) this).QuickMoveLengthAsMeter = 0.0;
    ((F_NotchEdit) this).NumberOfToolChange = 0;
    ((F_NotchEdit) this).NoDefinedMCodes = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    return $"TotalTimeAsSec : {((F_CutterOffsetEntities) this).TotalTimeAsSec.ToString("f2")} - TotalLengthAsMeter: {((F_NotchEdit) this).TotalLengthAsMeter.ToString("f2")}";
  }

  public abstract void m000967();

  public F_Scale()
  {
  }

  static F_Scale()
  {
    F_NotchEdit.lastShape = (buShape) null;
    F_NotchEdit.lastCut = (buShape) null;
    F_NotchEdit.lastDrill = (buShape) null;
    F_NotchEdit.lastProfiling = (buShape) null;
    F_NotchEdit.lastEngrave = (buShape) null;
    F_NotchEdit.lastJunction = (buShape) null;
    F_NotchEdit.ShapeSettingsParameters = (ShapeSettingData) new hmiUICommands();
    F_NotchEdit.ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
    F_NotchEdit.ShapeTempPar = (ShapeTempData) new hmiUICommands();
    F_NotchEdit.shapeCreatePar = (ShapeCreateParameters) new ShapeSettingData();
    F_NotchEdit.VarbuShapeVisilation = (buShapeVisualition) new CustomData();
    F_NotchEdit.SimVars = (MachineSimulation) new ShapeSizeInfo();
  }

  public F_Scale()
  {
    ((F_NotchEdit) this).AnalyseEntitySetting = (AnalyseEntitiesSetting) new PlaneAngle();
    ((F_NotchEdit) this).DirectionArrowSettings = (DirectionArrowSetting) new Pnt6DSimMove();
    ((F_NotchEdit) this).copyEventFormVar = (CopyEventFormVars) new SewingInfo();
    ((F_NotchEdit) this).moveEventFormVar = (MoveEventFormVars) new SewingInfo();
    ((F_NotchEdit) this).scaleEventFormVar = (ScaleEventFormVars) new SewingVertex();
    ((F_AnalyseResult) this).mirrorEventFormVar = (MirrorEventFormVars) new SewingCode();
    ((F_AnalyseResult) this).devideEventFormVar = (DevideEventFormVars) new SewingVertex();
    ((F_AnalyseResult) this).deleteTypeEventFormVar = (DeleteTypeEventFormVars) new SewingVertex();
    ((F_AnalyseResult) this).FlatViewSettings = (FlatViewSettings) new ShapeMirror();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public F_Scale(varRuntimePar5 data)
  {
    ((F_NotchEdit) this).AnalyseEntitySetting = (AnalyseEntitiesSetting) new PlaneAngle();
    ((F_NotchEdit) this).DirectionArrowSettings = (DirectionArrowSetting) new Pnt6DSimMove();
    ((F_NotchEdit) this).copyEventFormVar = (CopyEventFormVars) new SewingInfo();
    ((F_NotchEdit) this).moveEventFormVar = (MoveEventFormVars) new SewingInfo();
    ((F_NotchEdit) this).scaleEventFormVar = (ScaleEventFormVars) new SewingVertex();
    ((F_AnalyseResult) this).mirrorEventFormVar = (MirrorEventFormVars) new SewingCode();
    ((F_AnalyseResult) this).devideEventFormVar = (DevideEventFormVars) new SewingVertex();
    ((F_AnalyseResult) this).deleteTypeEventFormVar = (DeleteTypeEventFormVars) new SewingVertex();
    ((F_AnalyseResult) this).FlatViewSettings = (FlatViewSettings) new ShapeMirror();
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
    ((F_NotchEdit) this).AnalyseEntitySetting = (AnalyseEntitiesSetting) new PlaneAngle(((F_NotchEdit) data).AnalyseEntitySetting);
    ((F_NotchEdit) this).DirectionArrowSettings = (DirectionArrowSetting) new Pnt6DSimMove(((F_NotchEdit) data).DirectionArrowSettings);
    ((F_NotchEdit) this).copyEventFormVar = (CopyEventFormVars) new SewingInfo(((F_NotchEdit) data).copyEventFormVar);
    ((F_NotchEdit) this).moveEventFormVar = (MoveEventFormVars) new SewingVertex(((F_NotchEdit) data).moveEventFormVar);
    ((F_NotchEdit) this).scaleEventFormVar = (ScaleEventFormVars) new SewingVertex(((F_NotchEdit) data).scaleEventFormVar);
    ((F_AnalyseResult) this).mirrorEventFormVar = (MirrorEventFormVars) new SewingCode(((F_AnalyseResult) data).mirrorEventFormVar);
    ((F_AnalyseResult) this).devideEventFormVar = (DevideEventFormVars) new SewingVertex(((F_AnalyseResult) data).devideEventFormVar);
    ((F_AnalyseResult) this).deleteTypeEventFormVar = (DeleteTypeEventFormVars) new SewingCode(((F_AnalyseResult) data).deleteTypeEventFormVar);
  }

  public F_Scale()
  {
    ((F_AnalyseResult) this).GridStep = 10.0;
    ((F_AnalyseResult) this).GridMinValue = -500.0;
    ((F_AnalyseResult) this).GridMaxValue = 500.0;
    ((F_AnalyseResult) this).GridMajorLineCount = 10;
    ((F_AnalyseResult) this).snapGridPixel = 5;
    ((F_AnalyseResult) this).snapSymbolSize = 12;
    ((F_AnalyseResult) this).DrawThickness = 2.0;
    ((F_AnalyseResult) this).colorDraw = Color.Black;
    ((F_AnalyseResult) this).colorGridLine = Color.Gray;
    ((F_AnalyseResult) this).colorGridMajorLine = Color.DarkGray;
    ((F_AnalyseResult) this).colorGridAxisX = Color.DarkGray;
    ((F_AnalyseResult) this).colorGridAxisY = Color.DarkGray;
    ((F_AnalyseResult) this).colorEntity = Color.Black;
    ((F_AnalyseResult) this).colorDrawingPoints = Color.LightGreen;
    ((F_AnalyseResult) this).colorSelected = Color.Tomato;
    ((F_AnalyseResult) this).colorDynamic = Color.Black;
    ((F_AnalyseResult) this).colorFirstPart = Color.Lime;
    ((F_AnalyseResult) this).colorSecondPart = Color.Cyan;
    ((F_AnalyseResult) this).colorEvent = Color.Blue;
    ((F_AnalyseResult) this).thicknessDrawingPoints = 2.0;
    ((F_AnalyseResult) this).thicknessEntityPoint = 4.0;
    ((F_AnalyseResult) this).thicknessEntity = 2.0;
    ((F_AnalyseResult) this).BoxSizeOffset = 10.0;
    ((F_AnalyseResult) this).ExpandDrawingTree = true;
    ((F_AnalyseResult) this).ExpandConstraintTree = true;
    ((F_AnalyseResult) this).ShowConstraintTreeItem = true;
    ((F_AnalyseResult) this).ShowPointsAtDrawingTreeItem = true;
    ((F_AnalyseResult) this).DrawDirrectionArrow = true;
    ((F_AnalyseResult) this).EntityMagnetRange = 3;
    ((F_AnalyseResult) this).OffsetByMouse = false;
    ((F_AnalyseResult) this).isRectangleAsLine = true;
    ((F_AnalyseResult) this).OsnapOver = true;
    ((F_AnalyseResult) this).OsnapEntity = true;
    ((F_AnalyseResult) this).OsnapGrid = true;
    ((F_AnalyseResult) this).Ortho = true;
    ((F_AnalyseResult) this).ShowPoints = true;
    ((F_AnalyseResult) this).ShowBoxSize = true;
    ((F_AnalyseSettings) this).DeleteIfSameEntities = true;
    ((F_AnalyseSettings) this).BreakArcIfGreat180Degree = true;
    ((F_AnalyseSettings) this).SortFirstCatchRule = SortingFirstCatchRulesType.FirstDirectionThenAuto;
    ((F_AnalyseSettings) this).SimulationDevideLength = 8.0;
    ((F_AnalyseSettings) this).SimulationStep = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public F_Scale(EditorSettings data)
  {
    ((F_AnalyseResult) this).GridStep = 10.0;
    ((F_AnalyseResult) this).GridMinValue = -500.0;
    ((F_AnalyseResult) this).GridMaxValue = 500.0;
    ((F_AnalyseResult) this).GridMajorLineCount = 10;
    ((F_AnalyseResult) this).snapGridPixel = 5;
    ((F_AnalyseResult) this).snapSymbolSize = 12;
    ((F_AnalyseResult) this).DrawThickness = 2.0;
    ((F_AnalyseResult) this).colorDraw = Color.Black;
    ((F_AnalyseResult) this).colorGridLine = Color.Gray;
    ((F_AnalyseResult) this).colorGridMajorLine = Color.DarkGray;
    ((F_AnalyseResult) this).colorGridAxisX = Color.DarkGray;
    ((F_AnalyseResult) this).colorGridAxisY = Color.DarkGray;
    ((F_AnalyseResult) this).colorEntity = Color.Black;
    ((F_AnalyseResult) this).colorDrawingPoints = Color.LightGreen;
    ((F_AnalyseResult) this).colorSelected = Color.Tomato;
    ((F_AnalyseResult) this).colorDynamic = Color.Black;
    ((F_AnalyseResult) this).colorFirstPart = Color.Lime;
    ((F_AnalyseResult) this).colorSecondPart = Color.Cyan;
    ((F_AnalyseResult) this).colorEvent = Color.Blue;
    ((F_AnalyseResult) this).thicknessDrawingPoints = 2.0;
    ((F_AnalyseResult) this).thicknessEntityPoint = 4.0;
    ((F_AnalyseResult) this).thicknessEntity = 2.0;
    ((F_AnalyseResult) this).BoxSizeOffset = 10.0;
    ((F_AnalyseResult) this).ExpandDrawingTree = true;
    ((F_AnalyseResult) this).ExpandConstraintTree = true;
    ((F_AnalyseResult) this).ShowConstraintTreeItem = true;
    ((F_AnalyseResult) this).ShowPointsAtDrawingTreeItem = true;
    ((F_AnalyseResult) this).DrawDirrectionArrow = true;
    ((F_AnalyseResult) this).EntityMagnetRange = 3;
    ((F_AnalyseResult) this).OffsetByMouse = false;
    ((F_AnalyseResult) this).isRectangleAsLine = true;
    ((F_AnalyseResult) this).OsnapOver = true;
    ((F_AnalyseResult) this).OsnapEntity = true;
    ((F_AnalyseResult) this).OsnapGrid = true;
    ((F_AnalyseResult) this).Ortho = true;
    ((F_AnalyseResult) this).ShowPoints = true;
    ((F_AnalyseResult) this).ShowBoxSize = true;
    ((F_AnalyseSettings) this).DeleteIfSameEntities = true;
    ((F_AnalyseSettings) this).BreakArcIfGreat180Degree = true;
    ((F_AnalyseSettings) this).SortFirstCatchRule = SortingFirstCatchRulesType.FirstDirectionThenAuto;
    ((F_AnalyseSettings) this).SimulationDevideLength = 8.0;
    ((F_AnalyseSettings) this).SimulationStep = 1;
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

  public F_Scale()
  {
    ((F_AnalyseSettings) this).FilletRadius = 5.0;
    ((F_AnalyseSettings) this).ChamferLength = 5.0;
    ((F_AnalyseSettings) this).OffsetValue = 10.0;
    ((F_AnalyseSettings) this).EqualDistance = 20.0;
    ((F_AnalyseSettings) this).RotateAngle = 0.0;
    ((F_AnalyseSettings) this).ScaleRatio = 1.0;
    ((F_AnalyseSettings) this).ExtendLength = 0.0;
    ((F_AnalyseSettings) this).GridMaxValue = 500.0;
    ((F_AnalyseSettings) this).LastRotateAngle = 90.0;
    ((F_AnalyseSettings) this).TurnOverDistance = 10.0;
    ((F_AnalyseSettings) this).PolygonSide = 6;
    ((F_AnalyseSettings) this).KeyHoleLength = 33.0;
    ((F_AnalyseSettings) this).KeyHoleHeadDiameter = 17.0;
    ((F_AnalyseSettings) this).KeyHoleWidth = 10.0;
    ((F_AnalyseSettings) this).KeyHoleAngle = 0.0;
    ((F_AnalyseSettings) this).LastMirrorType = HorizontalVertical.Horizontal;
    ((F_AnalyseSettings) this).ShowDimension = true;
    ((F_AnalyseSettings) this).ShowContrraint = true;
    ((F_EntitiesProps) this).isSketchMode = false;
    ((F_EntitiesProps) this).isSewingMode = false;
    ((F_EntitiesProps) this).isFoamMode = false;
    ((F_EntitiesProps) this).GridEnable = true;
    ((F_EntitiesProps) this).OsnapOverDisable = false;
    ((F_EntitiesProps) this).OsnapEntityDisable = false;
    ((F_EntitiesProps) this).OsnapGridDisable = false;
    ((F_EntitiesProps) this).OsnapPointDisable = false;
    ((F_EntitiesProps) this).FromFileKeepRatio = true;
    ((F_EntitiesProps) this).TurnOverCenter = false;
    ((F_EntitiesProps) this).ExplodeCompositeCurveToEntities = true;
    ((F_EntitiesProps) this).ExplodeCircleToArc = true;
    ((F_DeleteType) this).ExplodeCircleToPolyline = false;
    ((F_DeleteType) this).ExplodeArcToPolyline = false;
    ((F_DeleteType) this).ExplodeEllipseToPolyline = false;
    ((F_DeleteType) this).ExplodeCurveToPolyline = true;
    ((F_DeleteType) this).ExplodePolylineToLine = false;
    ((F_DeleteType) this).pathFromFile = "C:\\";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public F_Scale(EditorRuntimeSettings data)
  {
    ((F_AnalyseSettings) this).FilletRadius = 5.0;
    ((F_AnalyseSettings) this).ChamferLength = 5.0;
    ((F_AnalyseSettings) this).OffsetValue = 10.0;
    ((F_AnalyseSettings) this).EqualDistance = 20.0;
    ((F_AnalyseSettings) this).RotateAngle = 0.0;
    ((F_AnalyseSettings) this).ScaleRatio = 1.0;
    ((F_AnalyseSettings) this).ExtendLength = 0.0;
    ((F_AnalyseSettings) this).GridMaxValue = 500.0;
    ((F_AnalyseSettings) this).LastRotateAngle = 90.0;
    ((F_AnalyseSettings) this).TurnOverDistance = 10.0;
    ((F_AnalyseSettings) this).PolygonSide = 6;
    ((F_AnalyseSettings) this).KeyHoleLength = 33.0;
    ((F_AnalyseSettings) this).KeyHoleHeadDiameter = 17.0;
    ((F_AnalyseSettings) this).KeyHoleWidth = 10.0;
    ((F_AnalyseSettings) this).KeyHoleAngle = 0.0;
    ((F_AnalyseSettings) this).LastMirrorType = HorizontalVertical.Horizontal;
    ((F_AnalyseSettings) this).ShowDimension = true;
    ((F_AnalyseSettings) this).ShowContrraint = true;
    ((F_EntitiesProps) this).isSketchMode = false;
    ((F_EntitiesProps) this).isSewingMode = false;
    ((F_EntitiesProps) this).isFoamMode = false;
    ((F_EntitiesProps) this).GridEnable = true;
    ((F_EntitiesProps) this).OsnapOverDisable = false;
    ((F_EntitiesProps) this).OsnapEntityDisable = false;
    ((F_EntitiesProps) this).OsnapGridDisable = false;
    ((F_EntitiesProps) this).OsnapPointDisable = false;
    ((F_EntitiesProps) this).FromFileKeepRatio = true;
    ((F_EntitiesProps) this).TurnOverCenter = false;
    ((F_EntitiesProps) this).ExplodeCompositeCurveToEntities = true;
    ((F_EntitiesProps) this).ExplodeCircleToArc = true;
    ((F_DeleteType) this).ExplodeCircleToPolyline = false;
    ((F_DeleteType) this).ExplodeArcToPolyline = false;
    ((F_DeleteType) this).ExplodeEllipseToPolyline = false;
    ((F_DeleteType) this).ExplodeCurveToPolyline = true;
    ((F_DeleteType) this).ExplodePolylineToLine = false;
    ((F_DeleteType) this).pathFromFile = "C:\\";
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

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;
}
