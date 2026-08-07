// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingTable
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Forms.Shape;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingTable : Form
{
  internal NumericUpDown \u0006;
  internal Label \u0007;
  internal NumericUpDown \u0007;
  internal CheckBox \u0003;
  public Button btn_ok;
  internal ImageList \u0002;
  public Button btn_cancel;

  internal void \u0001([In] object obj0, [In] ListViewItemSelectionChangedEventArgs obj1)
  {
    if (!((F_DrillList) this).PropertiesForm.Inited || !(obj1.ItemIndex >= 0 & obj1.IsSelected))
      return;
    ((F_SewingRotate) this).ShapeToDataGrid(obj1.ItemIndex);
    ((F_DrillList) this).\u0001 = obj1.ItemIndex;
    // ISSUE: reference to a compiler-generated field
    if (((F_DrillList) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_DrillList) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_DrillList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_DrillList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SewingTable() => F_DrillList.Captions = new List<string>();

  public F_SewingTable()
  {
    ((F_ShapeList) this).SpinBaseColor = Color.LightGreen;
    ((F_ShapeList) this).SpinFocusColor = Color.MistyRose;
    ((F_ShapeList) this).Data = new ShapeAllData();
    ((F_ShapeList) this).PropertiesForm = new FormProperties();
    ((F_ShapeList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ShapeAll) this);
  }

  public void Init()
  {
    ((F_ShapeList) this).PropertiesForm.Inited = false;
    if (((F_ShapeList) this).PropertiesForm.Height > 10)
      this.Height = ((F_ShapeList) this).PropertiesForm.Height;
    if (((F_ShapeList) this).PropertiesForm.Width > 10)
      this.Width = ((F_ShapeList) this).PropertiesForm.Width;
    this.TopMost = ((F_ShapeList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ShapeList) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_ShapeList) this).spn_rectwidth.Value = ((F_ShapeList) this).Data.RectangleWidth;
    ((F_ShapeList) this).spn_rectheight.Value = ((F_ShapeList) this).Data.RectangleHeight;
    ((F_ShapeList) this).spn_circlediameter.Value = ((F_ShapeList) this).Data.CircleDiameter;
    ((F_ShapeList) this).spn_roundrectwidth.Value = ((F_ShapeList) this).Data.RoundRectangleWidth;
    ((F_ShapeList) this).spn_roundrectheight.Value = ((F_ShapeList) this).Data.RoundRectangleHeight;
    ((F_ShapeList) this).spn_roundrectrad.Value = ((F_ShapeList) this).Data.RoundRectangleRadius;
    ((F_ShapeList) this).spn_ellipsewidth.Value = ((F_ShapeList) this).Data.EllipseWidth;
    ((F_ShapeList) this).spn_ellipseheight.Value = ((F_ShapeList) this).Data.EllipseHeight;
    ((F_SewingCodes) this).spn_polygondiameter.Value = ((F_ShapeList) this).Data.PolygonRadius;
    ((F_SewingCodes) this).spn_polygonside.Value = (double) ((F_ShapeList) this).Data.PolygonSide;
    ((F_SewingCodes) this).spn_trianglewidth.Value = ((F_ShapeList) this).Data.TriangleWidth;
    ((F_SewingCodes) this).spn_triangleheight.Value = ((F_ShapeList) this).Data.TriangleHeight;
    ((F_SewingCodes) this).spn_trapezlength1.Value = ((F_ShapeList) this).Data.TrapezLength1;
    ((F_SewingCodes) this).spn_trapezlength2.Value = ((F_ShapeList) this).Data.TrapezLength2;
    ((F_SewingCodes) this).spn_trapezheight.Value = ((F_ShapeList) this).Data.TrapezHeight;
    ((F_SewingCodes) this).\u0001.Check = ((F_ShapeList) this).Data.DiagonalCut;
    ((F_SewingCodes) this).spn_slotheight.Value = ((F_ShapeList) this).Data.SlotHeight;
    ((F_SewingCodes) this).spn_slotwidth.Value = ((F_ShapeList) this).Data.SlotWidth;
    ((F_SewingSpeed) this).spn_keyholediameter.Value = ((F_ShapeList) this).Data.KeyHoleDiameter;
    ((F_SewingCodes) this).spn_keyholelength.Value = ((F_ShapeList) this).Data.KeyHoleLength;
    ((F_SewingSpeed) this).spn_keyholewidth.Value = ((F_ShapeList) this).Data.KeyHoleWidth;
    ((F_SewingSpeed) this).spn_arcbigradius.Value = ((F_ShapeList) this).Data.ArcBigRadius;
    ((F_SewingSpeed) this).spn_arcsmallradius.Value = ((F_ShapeList) this).Data.ArcSmallRadius;
    ((F_SewingSpeed) this).spn_arcsweeoangle.Value = ((F_ShapeList) this).Data.ArcSweepAngle;
    ((F_ShapeList) this).spn_rotation.Value = ((F_ShapeList) this).Data.Rotation;
    ((F_ShapeList) this).PropertiesForm.Result = DialogResult.None;
    ((F_ShapeList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_ShapeList) this).\u0001.Text = buLangTranslate.preDef.Shape;
      ((F_ShapeList) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_ShapeList) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_ShapeList) this).tabPage_circle.Text = buLangTranslate.preDef.Cirlce;
      ((F_SewingCodes) this).tabPage_ellipse.Text = buLangTranslate.preDef.Ellipse;
      ((F_SewingCodes) this).tabPage_keyhole.Text = buLangTranslate.preDef.KeyHole;
      ((F_SewingCodes) this).tabPage_polygon.Text = buLangTranslate.preDef.Polygon;
      ((F_ShapeList) this).tabPage_rectangle.Text = buLangTranslate.preDef.Rectangle;
      ((F_SewingCodes) this).tabPage_roundrect.Text = buLangTranslate.preDef.RectangleRound;
      ((F_SewingSpeed) this).tabPage_slot.Text = buLangTranslate.preDef.Slot;
      ((F_SewingCodes) this).tabPage_trapez.Text = buLangTranslate.preDef.Trapezoid;
      ((F_SewingCodes) this).tabPage_triangle.Text = buLangTranslate.preDef.Triangle;
      ((F_ShapeList) this).spn_circlediameter.Caption.Caption = buLangTranslate.preDef.Diameter;
      ((F_ShapeList) this).spn_ellipseheight.Caption.Caption = buLangTranslate.preDef.DiamaterX;
      ((F_ShapeList) this).spn_ellipsewidth.Caption.Caption = buLangTranslate.preDef.DiameterY;
      ((F_SewingSpeed) this).spn_keyholediameter.Caption.Caption = buLangTranslate.preDef.Diameter;
      ((F_SewingCodes) this).spn_keyholelength.Caption.Caption = buLangTranslate.preDef.Length;
      ((F_SewingSpeed) this).spn_keyholewidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_SewingCodes) this).spn_polygondiameter.Caption.Caption = buLangTranslate.preDef.Diameter;
      ((F_SewingCodes) this).spn_polygonside.Caption.Caption = buLangTranslate.preDef.Side;
      ((F_ShapeList) this).spn_rectheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_ShapeList) this).spn_rectwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_ShapeList) this).spn_roundrectheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_ShapeList) this).spn_roundrectrad.Caption.Caption = buLangTranslate.preDef.Radius;
      ((F_ShapeList) this).spn_roundrectwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_SewingCodes) this).spn_slotheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_SewingCodes) this).spn_slotwidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_SewingCodes) this).spn_trapezheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_SewingCodes) this).spn_trapezlength1.Caption.Caption = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Length}";
      ((F_SewingCodes) this).spn_trapezlength2.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Length}";
      ((F_SewingCodes) this).spn_triangleheight.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_SewingCodes) this).spn_trianglewidth.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_ShapeList) this).spn_rotation.Caption.Caption = buLangTranslate.preDef.Rotate;
      ((F_SewingSpeed) this).spn_arcbigradius.Caption.Caption = $"{buLangTranslate.preDef.Big} {buLangTranslate.preDef.Radius}";
      ((F_SewingSpeed) this).spn_arcsmallradius.Caption.Caption = $"{buLangTranslate.preDef.Small} {buLangTranslate.preDef.Radius}";
      ((F_SewingSpeed) this).spn_arcsweeoangle.Caption.Caption = buLangTranslate.preDef.SweepAngle;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ShapeList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ShapeList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ShapeList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ShapeList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    ((F_ShapeList) this).Data.RectangleWidth = ((F_ShapeList) this).spn_rectwidth.Value;
    ((F_ShapeList) this).Data.RectangleHeight = ((F_ShapeList) this).spn_rectheight.Value;
    ((F_ShapeList) this).Data.CircleDiameter = ((F_ShapeList) this).spn_circlediameter.Value;
    ((F_ShapeList) this).Data.RoundRectangleWidth = ((F_ShapeList) this).spn_roundrectwidth.Value;
    ((F_ShapeList) this).Data.RoundRectangleHeight = ((F_ShapeList) this).spn_roundrectheight.Value;
    ((F_ShapeList) this).Data.RoundRectangleRadius = ((F_ShapeList) this).spn_roundrectrad.Value;
    ((F_ShapeList) this).Data.EllipseWidth = ((F_ShapeList) this).spn_ellipsewidth.Value;
    ((F_ShapeList) this).Data.EllipseHeight = ((F_ShapeList) this).spn_ellipseheight.Value;
    ((F_ShapeList) this).Data.PolygonRadius = ((F_SewingCodes) this).spn_polygondiameter.Value;
    ((F_ShapeList) this).Data.PolygonSide = (int) ((F_SewingCodes) this).spn_polygonside.Value;
    ((F_ShapeList) this).Data.TriangleWidth = ((F_SewingCodes) this).spn_trianglewidth.Value;
    ((F_ShapeList) this).Data.TriangleHeight = ((F_SewingCodes) this).spn_triangleheight.Value;
    ((F_ShapeList) this).Data.TrapezLength1 = ((F_SewingCodes) this).spn_trapezlength1.Value;
    ((F_ShapeList) this).Data.TrapezLength2 = ((F_SewingCodes) this).spn_trapezlength2.Value;
    ((F_ShapeList) this).Data.TrapezHeight = ((F_SewingCodes) this).spn_trapezheight.Value;
    ((F_ShapeList) this).Data.SlotHeight = ((F_SewingCodes) this).spn_slotheight.Value;
    ((F_ShapeList) this).Data.SlotWidth = ((F_SewingCodes) this).spn_slotwidth.Value;
    ((F_ShapeList) this).Data.KeyHoleDiameter = ((F_SewingSpeed) this).spn_keyholediameter.Value;
    ((F_ShapeList) this).Data.KeyHoleLength = ((F_SewingCodes) this).spn_keyholelength.Value;
    ((F_ShapeList) this).Data.KeyHoleWidth = ((F_SewingSpeed) this).spn_keyholewidth.Value;
    ((F_ShapeList) this).Data.DiagonalCut = ((F_SewingCodes) this).\u0001.Check;
    ((F_ShapeList) this).Data.Rotation = ((F_ShapeList) this).spn_rotation.Value;
    ((F_ShapeList) this).Data.ArcBigRadius = ((F_SewingSpeed) this).spn_arcbigradius.Value;
    ((F_ShapeList) this).Data.ArcSmallRadius = ((F_SewingSpeed) this).spn_arcsmallradius.Value;
    ((F_ShapeList) this).Data.ArcSweepAngle = ((F_SewingSpeed) this).spn_arcsweeoangle.Value;
  }

  public event OkCommandWithTwoDataEventHandler CellClicked;
}
