// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolSpindleAndMagazine
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSpindleAndMagazine : Form
{
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_angleC;
  public buSpin spn_lengthVer;
  public buSpin spn_y;
  public buSpin spn_x;
  public buSpin spn_angleA;
  public buButton btn_okVer;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public double AngleValue;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buButton btn_movedown;
  public buSpin spn_move;
  internal buPanel \u0001;
  public buButton btn_rotateccw;
  public buButton btn_moveleft;
  public buButton btn_moveup;
  public buButton btn_rotatecw;
  public buButton btn_moveright;
  public buSpin spn_rotate;
  internal buGround \u0001;
  public buButton btn_close;
  public buButton btn_ok;
  public buButton btn_cancel;
  public static byte f0022F7;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<DiameterDepthPoint> Holes;
  public DiameterDepthPoint Hole;
  public int SelectedRowSheet;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal DataGridView \u0001;
  public buButton btn_delete;
  public buButton btn_remove;
  public buButton btn_add;
  internal buGroup \u0001;
  public buButton btn_closehole;
  public buButton btn_addhole;
  public buSpin spn_depth;
  public buSpin spn_dia;
  public buSpin spn_z;
  public buSpin spn_y;
  public buSpin spn_x;
  public static byte f002310;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleRuntimeSettings varRuntime;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_baseheight;
  public buCheckBox chk_keepratio;
  public buSpin spn_scalewidth;
  public buSpin spn_scaleheight;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public int Language;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox btn_tr;
  public buGround buGround1;
  public buCheckBox btn_bae;
  public buCheckBox btn_cn;
  public buCheckBox btn_it;
  public buCheckBox btn_en;
  public buCheckBox btn_de;
  public buCheckBox btn_es;
  public buCheckBox btn_fr;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleCamPars Settings;
  public MarbleProgramSettings SettingsProgram;
  public List<MarbleOperationSequence> Sequences;
  public int indexMat;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_millinghead;
  public buButton btn_milling;
  public buButton btn_saw;
  public buButton btn_strategy;
  public buTab buTab_Main;
  public TabPage tabPage_mainpage;
  public TabPage tabPage_sawmain;
  public TabPage tabPage_millihmain;
  internal TabPage \u0001;
  internal Panel \u0001;
  internal buLabel \u0001;
  internal RadioButton \u0001;
  internal Panel \u0002;
  internal buLabel \u0002;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;

  static F_MarbleToolSpindleAndMagazine() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleToolSpindleAndMagazine()
  {
    ((F_MarbleCamSettings) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleCamSettings) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleCamSettings) this).PropertiesForm = new FormProperties();
    ((F_MarbleCamSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleShapeAll) this);
  }

  public void Init()
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = false;
    if (((F_MarbleCamSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCamSettings) this).PropertiesForm.Height;
    if (((F_MarbleCamSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCamSettings) this).PropertiesForm.Width;
    this.Width = 585;
    this.Height = 660;
    this.TopMost = ((F_MarbleCamSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCamSettings) this).PropertiesForm.FormPosition;
    ((F_MarbleCamSettings) this).buTab_shape.ItemSize = new Size(1, 1);
    this.LoadLanguage();
    ((F_MarbleCamSettings) this).\u0001.Visible = false;
    ((F_MarbleCamSettings) this).\u0002.Visible = false;
    if (((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayEnable | !buConversion5.EQ(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation, 0.0))
    {
      ((F_MarbleCamSettings) this).\u0002.Visible = true;
      ((F_MarbleCamSettings) this).\u0002.Text = "";
      if (((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayEnable)
        ((F_MarbleCamSettings) this).\u0002.Text = ((F_MarbleCamSettings) this).\u0002.Text + buLangTranslate.preSentencesMarble.LinearCopyEnable + Environment.NewLine;
      if (!buConversion5.EQ(((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation, 0.0))
        ((F_MarbleCamSettings) this).\u0002.Text = ((F_MarbleCamSettings) this).\u0002.Text + buLangTranslate.preSentencesMarble.RotationAngleDifferentThen0;
    }
    ((F_MarbleCamSettings) this).spn_rectwidth.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleWidth;
    ((F_MarbleCamSettings) this).spn_rectheight.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleHeight;
    ((F_MarbleCamSettings) this).spn_recttopangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleTopAngle;
    ((F_MarbleCamSettings) this).spn_rectbottomangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleBottomAngle;
    ((F_MarbleCamSettings) this).spn_rectleftangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleLeftAngle;
    ((F_MarbleCamSettings) this).spn_rectrightangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRightAngle;
    ((F_MarbleCamSettings) this).spn_roundrectwidth.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundWidth;
    ((F_MarbleCamSettings) this).spn_roundrectheight.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundHeight;
    ((F_MarbleCamSettings) this).spn_roundrectrad.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundRadius;
    ((F_MarbleCamSettings) this).spn_roundrectangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundAngle;
    ((F_MarbleCamSettings) this).spn_chamferrectwidth.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferWidth;
    ((F_MarbleCamSettings) this).spn_chamferrectheight.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferHeight;
    ((F_MarbleCamSettings) this).spn_chamferrectlength.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferLength;
    ((F_MarbleCamSettings) this).spn_chamferrectangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferAngle;
    ((F_MarbleCamSettings) this).spn_crossrectwidth.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossWidth;
    ((F_MarbleCamSettings) this).spn_crossrectheight.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossHeight;
    ((F_MarbleCamSettings) this).spn_crossrecttopangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossTopAngle;
    ((F_MarbleCamSettings) this).spn_crossrectbottomangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossBottomAngle;
    ((F_MarbleCamSettings) this).spn_crossrectleftangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossLeftAngle;
    ((F_MarbleCamSettings) this).spn_crossrectrightangl.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossRightAngle;
    ((F_MarbleCamSettings) this).spn_circlediameter.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleDiameter;
    ((F_MarbleCamSettings) this).spn_circleangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleAngle;
    ((F_MarbleCamSettings) this).spn_arcpieradius.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieRadius;
    ((F_MarbleCamSettings) this).spn_arcpieangle.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieAngle;
    ((F_MarbleCamSettings) this).spn_arcpiesweepangle.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieSweepAngle;
    ((F_MarbleCamSettings) this).spn_ellipsewidth.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseWidth;
    ((F_MarbleCamSettings) this).spn_ellipseheight.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseHeight;
    ((F_MarbleCamSettings) this).spn_ellipseangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseAngle;
    ((F_MarbleCamSettings) this).spn_polygondiameter.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonRadius;
    ((F_MarbleCamSettings) this).spn_polygonside.Value = (double) ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonSide;
    ((F_MarbleCamSettings) this).spn_polygonangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonAngle;
    ((F_MarbleCamSettings) this).spn_trianglewidth.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleWidth;
    ((F_MarbleCamSettings) this).spn_triangleheight.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleHeight;
    ((F_MarbleCamSettings) this).spn_triangleleftangle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleLeftAngle;
    ((F_MarbleCamSettings) this).spn_trianglebottomagnle.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleBottomAngle;
    ((F_MarbleCamSettings) this).spn_trianglecrossagnle.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleCrossAngle;
    ((F_MarbleCamSettings) this).spn_trapezlength1.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLength1;
    ((F_MarbleCamSettings) this).spn_trapezlength2.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLength2;
    ((F_MarbleCamSettings) this).spn_trapezheight.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezHeight;
    ((F_MarbleCamSettings) this).spn_trapeztopangle.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezTopAngle;
    ((F_MarbleCamSettings) this).spn_trapezbottomangle.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezBottomAngle;
    ((F_MarbleCamSettings) this).spn_trapezleftangle.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLeftAngle;
    ((F_MarbleCamSettings) this).spn_trapezrightangle.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezRightAngle;
    ((F_MarbleCamSettings) this).spn_slotheight.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotHeight;
    ((F_MarbleCamSettings) this).spn_slotwidth.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotWidth;
    ((F_MarbleCamSettings) this).spn_slotangl.Value = ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotAngle;
    ((F_MarbleCamSettings) this).spn_archeight.Value = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcHeight;
    ((F_MarbleCamSettings) this).spn_arcthickns.Value = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcThickness;
    ((F_MarbleCamSettings) this).spn_arcoutsidelength.Value = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcOutsideLength;
    ((F_MarbleCamSettings) this).spn_shiipnosewidth.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseWidth;
    ((F_MarbleCamSettings) this).spn_shiipnoseheight.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseHeight;
    ((F_MarbleCamSettings) this).spn_shiipnosetopangle.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseTopAngle;
    ((F_MarbleCamSettings) this).spn_shiipnosebottomangl.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseBottomAngle;
    ((F_MarbleCamSettings) this).spn_shiipnoseleftangle.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseLeftAngle;
    ((F_MarbleCamSettings) this).spn_shiipnoserightangle.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRightAngle;
    ((F_MarbleCamSettings) this).spn_shiipnosearcxdis.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcXDistance;
    ((F_MarbleCamSettings) this).spn_shiipnosearcydis.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcYDistance;
    ((F_MarbleCamSettings) this).spn_shiipnoseradius.Value = ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRadius;
    ((F_MarbleCamSettings) this).spn_ellipsearcwidth.Value = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieWidth;
    ((F_MarbleCamSettings) this).spn_ellipsearcheight.Value = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieHeight;
    ((F_MarbleCamSettings) this).spn_ellipsearcangle.Value = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieAngle;
    ((F_MarbleCamSettings) this).spn_ellipsearcsweepangle.Value = ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieSweepAngle;
    ((F_MarbleCamSettings) this).spn_rotation.Value = ((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation;
    ((F_MarbleCamSettings) this).spn_xcount.Value = ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayXCount;
    ((F_MarbleCamSettings) this).spn_xoffset.Value = ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayXDistance;
    ((F_MarbleCamSettings) this).spn_ycount.Value = ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayYCount;
    ((F_MarbleCamSettings) this).spn_yoffset.Value = ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayYDistance;
    ((F_MarbleCamSettings) this).chk_copyenable.Check = ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayEnable;
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCamSettings) this).\u0001.Text = buLangTranslate.preDef.Shape;
      ((F_MarbleCamSettings) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleCamSettings) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleCamSettings) this).tabPage_circle.Text = buLangTranslate.preDef.Cirlce;
      ((F_MarbleCamSettings) this).tabPage_ellipse.Text = buLangTranslate.preDef.Ellipse;
      ((F_MarbleCamSettings) this).tabPage_polygon.Text = buLangTranslate.preDef.Polygon;
      ((F_MarbleCamSettings) this).tabPage_roundrect.Text = buLangTranslate.preDef.RectangleRound;
      ((F_MarbleCamSettings) this).tabPage_slot.Text = buLangTranslate.preDef.Slot;
      ((F_MarbleCamSettings) this).tabPage_trapez.Text = buLangTranslate.preDef.Trapezoid;
      ((F_MarbleCamSettings) this).tabPage_triangle.Text = buLangTranslate.preDef.Triangle;
      ((F_MarbleCamSettings) this).spn_circlediameter.Caption.Caption = buLangTranslate.preDef.Diameter;
      ((F_MarbleCamSettings) this).spn_circleangle.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_ellipseheight.Caption.Caption = buLangTranslate.preDef.Diameter + " X";
      ((F_MarbleCamSettings) this).spn_ellipsewidth.Caption.Caption = buLangTranslate.preDef.Diameter + " Y";
      ((F_MarbleCamSettings) this).spn_ellipseangle.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_polygondiameter.Caption.Caption = buLangTranslate.preDef.Diameter;
      ((F_MarbleCamSettings) this).spn_polygonside.Caption.Caption = buLangTranslate.preDef.Side;
      ((F_MarbleCamSettings) this).spn_polygonangle.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_rectheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_rectwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_rectbottomangle.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_recttopangle.Caption.Caption = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_rectleftangle.Caption.Caption = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_rectrightangle.Caption.Caption = $"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_roundrectheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_roundrectrad.Caption.Caption = buLangTranslate.preDef.Radius;
      ((F_MarbleCamSettings) this).spn_roundrectangle.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_roundrectwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_chamferrectangle.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_chamferrectheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_chamferrectlength.Caption.Caption = buLangTranslate.preDef.Length;
      ((F_MarbleCamSettings) this).spn_chamferrectwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_crossrectheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_crossrectwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_crossrectbottomangle.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_crossrecttopangle.Caption.Caption = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_crossrectleftangle.Caption.Caption = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_crossrectrightangl.Caption.Caption = $"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_slotheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_slotwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_slotangl.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_arcpieangle.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_arcpieradius.Caption.Caption = buLangTranslate.preDef.Radius;
      ((F_MarbleCamSettings) this).spn_arcpiesweepangle.Caption.Caption = buLangTranslate.preDef.SweepAngle;
      ((F_MarbleCamSettings) this).spn_ellipsearcangle.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).spn_ellipsearcheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_ellipsearcsweepangle.Caption.Caption = buLangTranslate.preDef.SweepAngle;
      ((F_MarbleCamSettings) this).spn_ellipsearcwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_shiipnosearcxdis.Caption.Caption = $"{buLangTranslate.preDef.Arc} X {buLangTranslate.preDef.Distance}";
      ((F_MarbleCamSettings) this).spn_shiipnosearcydis.Caption.Caption = $"{buLangTranslate.preDef.Arc} Y {buLangTranslate.preDef.Distance}";
      ((F_MarbleCamSettings) this).spn_shiipnoseheight.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_shiipnosewidth.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_shiipnosebottomangl.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_shiipnoseleftangle.Caption.Caption = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_shiipnoserightangle.Caption.Caption = $"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_shiipnosetopangle.Caption.Caption = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_shiipnoseradius.Caption.Caption = buLangTranslate.preDef.Radius;
      ((F_MarbleCamSettings) this).spn_trapezheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_trapezlength1.Caption.Caption = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Length}";
      ((F_MarbleCamSettings) this).spn_trapezlength2.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Length}";
      ((F_MarbleCamSettings) this).spn_trapezbottomangle.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_trapezleftangle.Caption.Caption = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_trapezrightangle.Caption.Caption = $"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_trapeztopangle.Caption.Caption = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_triangleheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_trianglewidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleCamSettings) this).spn_trianglebottomagnle.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_trianglecrossagnle.Caption.Caption = $"{buLangTranslate.preDef.Cross} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_triangleleftangle.Caption.Caption = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Angle}";
      ((F_MarbleCamSettings) this).spn_rotation.Caption.Caption = buLangTranslate.preDef.Rotate;
      ((F_MarbleCamSettings) this).spn_archeight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleCamSettings) this).spn_arcthickns.Caption.Caption = buLangTranslate.preDef.Thickness;
      ((F_MarbleCamSettings) this).spn_arcoutsidelength.Caption.Caption = buLangTranslate.preDef.Length;
      ((F_MarbleCamSettings) this).chk_copyenable.Text = buLangTranslate.preDef.Copy;
      ((F_MarbleCamSettings) this).\u0001.Text = buLangTranslate.preDef.Rotate;
      ((F_MarbleCamSettings) this).\u0003.Text = "A " + buLangTranslate.preDef.Angle;
      ((F_MarbleCamSettings) this).btn_applyAngleA.Text = buLangTranslate.preDef.Apply;
      ((F_MarbleCamSettings) this).spn_xcount.Caption.Caption = "X " + buLangTranslate.preDef.Count;
      ((F_MarbleCamSettings) this).spn_ycount.Caption.Caption = "Y " + buLangTranslate.preDef.Count;
      ((F_MarbleCamSettings) this).spn_xoffset.Caption.Caption = "X " + buLangTranslate.preDef.Offset;
      ((F_MarbleCamSettings) this).spn_yoffset.Caption.Caption = "Y " + buLangTranslate.preDef.Offset;
      ((F_MarbleCamSettings) this).spn_angleA.Caption.Caption = "A " + buLangTranslate.preDef.Angle;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCamSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
      if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
        return;
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleWidth = ((F_MarbleCamSettings) this).spn_rectwidth.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleHeight = ((F_MarbleCamSettings) this).spn_rectheight.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleTopAngle = ((F_MarbleCamSettings) this).spn_recttopangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleBottomAngle = ((F_MarbleCamSettings) this).spn_rectbottomangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleLeftAngle = ((F_MarbleCamSettings) this).spn_rectleftangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRightAngle = ((F_MarbleCamSettings) this).spn_rectrightangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundWidth = ((F_MarbleCamSettings) this).spn_roundrectwidth.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundHeight = ((F_MarbleCamSettings) this).spn_roundrectheight.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundRadius = ((F_MarbleCamSettings) this).spn_roundrectrad.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleRoundAngle = ((F_MarbleCamSettings) this).spn_roundrectangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferWidth = ((F_MarbleCamSettings) this).spn_chamferrectwidth.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferHeight = ((F_MarbleCamSettings) this).spn_chamferrectheight.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferLength = ((F_MarbleCamSettings) this).spn_chamferrectlength.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleChamferAngle = ((F_MarbleCamSettings) this).spn_chamferrectangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossWidth = ((F_MarbleCamSettings) this).spn_crossrectwidth.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossHeight = ((F_MarbleCamSettings) this).spn_crossrectheight.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossTopAngle = ((F_MarbleCamSettings) this).spn_crossrecttopangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossBottomAngle = ((F_MarbleCamSettings) this).spn_crossrectbottomangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossLeftAngle = ((F_MarbleCamSettings) this).spn_crossrectleftangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRectangleCrossRightAngle = ((F_MarbleCamSettings) this).spn_crossrectrightangl.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleDiameter = ((F_MarbleCamSettings) this).spn_circlediameter.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeCircleAngle = ((F_MarbleCamSettings) this).spn_circleangle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieRadius = ((F_MarbleCamSettings) this).spn_arcpieradius.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieAngle = ((F_MarbleCamSettings) this).spn_arcpieangle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcPieSweepAngle = ((F_MarbleCamSettings) this).spn_arcpiesweepangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseWidth = ((F_MarbleCamSettings) this).spn_ellipsewidth.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseHeight = ((F_MarbleCamSettings) this).spn_ellipseheight.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipseAngle = ((F_MarbleCamSettings) this).spn_ellipseangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonRadius = ((F_MarbleCamSettings) this).spn_polygondiameter.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonSide = (int) ((F_MarbleCamSettings) this).spn_polygonside.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapePolygonAngle = ((F_MarbleCamSettings) this).spn_polygonangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleWidth = ((F_MarbleCamSettings) this).spn_trianglewidth.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleHeight = ((F_MarbleCamSettings) this).spn_triangleheight.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleLeftAngle = ((F_MarbleCamSettings) this).spn_triangleleftangle.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleBottomAngle = ((F_MarbleCamSettings) this).spn_trianglebottomagnle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTriangleCrossAngle = ((F_MarbleCamSettings) this).spn_trianglecrossagnle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLength1 = ((F_MarbleCamSettings) this).spn_trapezlength1.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLength2 = ((F_MarbleCamSettings) this).spn_trapezlength2.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezHeight = ((F_MarbleCamSettings) this).spn_trapezheight.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezTopAngle = ((F_MarbleCamSettings) this).spn_trapeztopangle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezBottomAngle = ((F_MarbleCamSettings) this).spn_trapezbottomangle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezLeftAngle = ((F_MarbleCamSettings) this).spn_trapezleftangle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeTrapezRightAngle = ((F_MarbleCamSettings) this).spn_trapezrightangle.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotHeight = ((F_MarbleCamSettings) this).spn_slotheight.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotWidth = ((F_MarbleCamSettings) this).spn_slotwidth.Value;
    ((marbleOffsetCalculationParameters) MarbleRuntimeSettings.varMarbleRunSettings).ShapeSlotAngle = ((F_MarbleCamSettings) this).spn_slotangl.Value;
    ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcHeight = ((F_MarbleCamSettings) this).spn_archeight.Value;
    ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcThickness = ((F_MarbleCamSettings) this).spn_arcthickns.Value;
    ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeArcOutsideLength = ((F_MarbleCamSettings) this).spn_arcoutsidelength.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseWidth = ((F_MarbleCamSettings) this).spn_shiipnosewidth.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseHeight = ((F_MarbleCamSettings) this).spn_shiipnoseheight.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseTopAngle = ((F_MarbleCamSettings) this).spn_shiipnosetopangle.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseBottomAngle = ((F_MarbleCamSettings) this).spn_shiipnosebottomangl.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseLeftAngle = ((F_MarbleCamSettings) this).spn_shiipnoseleftangle.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRightAngle = ((F_MarbleCamSettings) this).spn_shiipnoserightangle.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcXDistance = ((F_MarbleCamSettings) this).spn_shiipnosearcxdis.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseArcYDistance = ((F_MarbleCamSettings) this).spn_shiipnosearcydis.Value;
    ((marbleConvexConcaveCalculationPars) MarbleRuntimeSettings.varMarbleRunSettings).ShapeShipNoseRadius = ((F_MarbleCamSettings) this).spn_shiipnoseradius.Value;
    ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieWidth = ((F_MarbleCamSettings) this).spn_ellipsearcwidth.Value;
    ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieHeight = ((F_MarbleCamSettings) this).spn_ellipsearcheight.Value;
    ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieAngle = ((F_MarbleCamSettings) this).spn_ellipsearcangle.Value;
    ((marbleCuttingItems) MarbleRuntimeSettings.varMarbleRunSettings).ShapeEllipsePieSweepAngle = ((F_MarbleCamSettings) this).spn_ellipsearcsweepangle.Value;
    ((marbleSetAngle) MarbleRuntimeSettings.varMarbleRunSettings).ShapeRotation = ((F_MarbleCamSettings) this).spn_rotation.Value;
    ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayXCount = ((F_MarbleCamSettings) this).spn_xcount.Value;
    ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayXDistance = ((F_MarbleCamSettings) this).spn_xoffset.Value;
    ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayYCount = ((F_MarbleCamSettings) this).spn_ycount.Value;
    ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayYDistance = ((F_MarbleCamSettings) this).spn_yoffset.Value;
    ((marbleCutRemainMaterial) MarbleRuntimeSettings.varMarbleRunSettings).ShapeLinearArrayEnable = ((F_MarbleCamSettings) this).chk_copyenable.Check;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleCamSettings) this).SpinFocusColor;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleCamSettings) this).SpinBaseColor;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleCamSettings) this).btn_events.Name)
    {
      if (!((F_MarbleCamSettings) this).\u0001.Visible)
        ((F_MarbleCamSettings) this).\u0001.Visible = true;
      else
        ((F_MarbleCamSettings) this).\u0001.Visible = false;
      ((F_MarbleCamSettings) this).\u0002.Visible = false;
      if (((F_MarbleCamSettings) this).chk_copyenable.Check | !buConversion5.EQ(((F_MarbleCamSettings) this).spn_rotation.Value, 0.0))
      {
        ((F_MarbleCamSettings) this).\u0002.Visible = true;
        ((F_MarbleCamSettings) this).\u0002.Text = "";
        if (((F_MarbleCamSettings) this).chk_copyenable.Check)
          ((F_MarbleCamSettings) this).\u0002.Text = ((F_MarbleCamSettings) this).\u0002.Text + buLangTranslate.preSentencesMarble.LinearCopyEnable + Environment.NewLine;
        if (!buConversion5.EQ(((F_MarbleCamSettings) this).spn_rotation.Value, 0.0))
          ((F_MarbleCamSettings) this).\u0002.Text = ((F_MarbleCamSettings) this).\u0002.Text + buLangTranslate.preSentencesMarble.RotationAngleDifferentThen0;
      }
    }
    if (control.Name == ((F_MarbleCamSettings) this).btn_closeevent.Name)
    {
      ((F_MarbleCamSettings) this).\u0001.Visible = false;
      ((F_MarbleCamSettings) this).\u0002.Visible = false;
      if (((F_MarbleCamSettings) this).chk_copyenable.Check | !buConversion5.EQ(((F_MarbleCamSettings) this).spn_rotation.Value, 0.0))
      {
        ((F_MarbleCamSettings) this).\u0002.Visible = true;
        ((F_MarbleCamSettings) this).\u0002.Text = "";
        if (((F_MarbleCamSettings) this).chk_copyenable.Check)
          ((F_MarbleCamSettings) this).\u0002.Text = ((F_MarbleCamSettings) this).\u0002.Text + buLangTranslate.preSentencesMarble.LinearCopyEnable + Environment.NewLine;
        if (!buConversion5.EQ(((F_MarbleCamSettings) this).spn_rotation.Value, 0.0))
          ((F_MarbleCamSettings) this).\u0002.Text = ((F_MarbleCamSettings) this).\u0002.Text + buLangTranslate.preSentencesMarble.RotationAngleDifferentThen0;
      }
    }
    if (!(control.Name == ((F_MarbleCamSettings) this).btn_applyAngleA.Name))
      return;
    if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 0)
    {
      ((F_MarbleCamSettings) this).spn_rectbottomangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_recttopangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_rectleftangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_rectrightangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    }
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 1)
      ((F_MarbleCamSettings) this).spn_roundrectangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 2)
      ((F_MarbleCamSettings) this).spn_chamferrectangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 3)
    {
      ((F_MarbleCamSettings) this).spn_crossrectbottomangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_crossrectleftangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_crossrectrightangl.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_crossrecttopangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    }
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 4)
      ((F_MarbleCamSettings) this).spn_circleangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 5)
      ((F_MarbleCamSettings) this).spn_arcpieangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 6)
      ((F_MarbleCamSettings) this).spn_ellipseangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 7)
      ((F_MarbleCamSettings) this).spn_polygonangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 8)
    {
      ((F_MarbleCamSettings) this).spn_trianglebottomagnle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_trianglecrossagnle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_triangleleftangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    }
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 9)
    {
      ((F_MarbleCamSettings) this).spn_trapezrightangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_trapezleftangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_trapeztopangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      ((F_MarbleCamSettings) this).spn_trapezbottomangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    }
    else if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 10)
    {
      ((F_MarbleCamSettings) this).spn_slotangl.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
    }
    else
    {
      if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 11)
        return;
      if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex == 12)
      {
        ((F_MarbleCamSettings) this).spn_shiipnosebottomangl.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
        ((F_MarbleCamSettings) this).spn_shiipnoseleftangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
        ((F_MarbleCamSettings) this).spn_shiipnoserightangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
        ((F_MarbleCamSettings) this).spn_shiipnosetopangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      }
      else
      {
        if (((F_MarbleCamSettings) this).buTab_shape.SelectedIndex != 13)
          return;
        ((F_MarbleCamSettings) this).spn_ellipsearcangle.Value = ((F_MarbleCamSettings) this).spn_angleA.Value;
      }
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCamSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event OkCommandWithFiveDataEventHandler CommandTool;
}
