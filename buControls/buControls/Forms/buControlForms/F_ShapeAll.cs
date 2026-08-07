// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.F_ShapeAll
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms;

public class F_ShapeAll : Form
{
  public Color SpinBaseColor = Color.LightGreen;
  public Color SpinFocusColor = Color.MistyRose;
  public ShapeAllData Data = new ShapeAllData();
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buTab buTab_shape;
  public TabPage tabPage_rectangle;
  public TabPage tabPage_circle;
  internal PictureBox pictureBox_0;
  internal buLabel buLabel_0;
  public buSpin spn_rotation;
  public buSpin spn_rectheight;
  public buSpin spn_rectwidth;
  public buSpin spn_circlediameter;
  internal PictureBox pictureBox_1;
  public buSpin spn_roundrectrad;
  public buSpin spn_roundrectheight;
  public buSpin spn_roundrectwidth;
  internal PictureBox pictureBox_2;
  public buSpin spn_ellipseheight;
  public buSpin spn_ellipsewidth;
  internal PictureBox pictureBox_3;
  public buSpin spn_polygondiameter;
  public buSpin spn_polygonside;
  internal PictureBox pictureBox_4;
  public buSpin spn_trianglewidth;
  public buSpin spn_triangleheight;
  internal PictureBox pictureBox_5;
  public buSpin spn_trapezlength1;
  public buSpin spn_trapezlength2;
  public buSpin spn_trapezheight;
  internal PictureBox pictureBox_6;
  public TabPage tabPage_roundrect;
  public TabPage tabPage_ellipse;
  public TabPage tabPage_polygon;
  public TabPage tabPage_triangle;
  public TabPage tabPage_trapez;
  internal buCheckBox buCheckBox_0;
  public buSpin spn_slotheight;
  public buSpin spn_slotwidth;
  internal PictureBox pictureBox_7;
  public TabPage tabPage_keyhole;
  public buSpin spn_keyholelength;
  public buSpin spn_keyholediameter;
  public buSpin spn_keyholewidth;
  internal PictureBox pictureBox_8;
  public TabPage tabPage_slot;

  public F_ShapeAll() => Class39.smethod_166(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.spn_rectwidth.Value = this.Data.RectangleWidth;
    this.spn_rectheight.Value = this.Data.RectangleHeight;
    this.spn_circlediameter.Value = this.Data.CircleDiameter;
    this.spn_roundrectwidth.Value = this.Data.RoundRectangleWidth;
    this.spn_roundrectheight.Value = this.Data.RoundRectangleHeight;
    this.spn_roundrectrad.Value = this.Data.RoundRectangleRadius;
    this.spn_ellipsewidth.Value = this.Data.EllipseWidth;
    this.spn_ellipseheight.Value = this.Data.EllipseHeight;
    this.spn_polygondiameter.Value = this.Data.PolygonRadius;
    this.spn_polygonside.Value = (double) this.Data.PolygonSide;
    this.spn_trianglewidth.Value = this.Data.TriangleWidth;
    this.spn_triangleheight.Value = this.Data.TriangleHeight;
    this.spn_trapezlength1.Value = this.Data.TrapezLength1;
    this.spn_trapezlength2.Value = this.Data.TrapezLength2;
    this.spn_trapezheight.Value = this.Data.TrapezHeight;
    this.buCheckBox_0.Check = this.Data.DiagonalCut;
    this.spn_slotheight.Value = this.Data.SlotHeight;
    this.spn_slotwidth.Value = this.Data.SlotWidth;
    this.spn_keyholediameter.Value = this.Data.KeyHoleDiameter;
    this.spn_keyholelength.Value = this.Data.KeyHoleLength;
    this.spn_keyholewidth.Value = this.Data.KeyHoleWidth;
    this.spn_rotation.Value = this.Data.Rotation;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_ShapeAll.Captions.Count <= 14)
        return;
      this.buGround_0.Text = F_ShapeAll.Captions[0];
      this.btn_ok.Text = F_ShapeAll.Captions[13];
      this.btn_cancel.Text = F_ShapeAll.Captions[14];
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = new buSpin();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
    this.Data.RectangleWidth = this.spn_rectwidth.Value;
    this.Data.RectangleHeight = this.spn_rectheight.Value;
    this.Data.CircleDiameter = this.spn_circlediameter.Value;
    this.Data.RoundRectangleWidth = this.spn_roundrectwidth.Value;
    this.Data.RoundRectangleHeight = this.spn_roundrectheight.Value;
    this.Data.RoundRectangleRadius = this.spn_roundrectrad.Value;
    this.Data.EllipseWidth = this.spn_ellipsewidth.Value;
    this.Data.EllipseHeight = this.spn_ellipseheight.Value;
    this.Data.PolygonRadius = this.spn_polygondiameter.Value;
    this.Data.PolygonSide = (int) this.spn_polygonside.Value;
    this.Data.TriangleWidth = this.spn_trianglewidth.Value;
    this.Data.TriangleHeight = this.spn_triangleheight.Value;
    this.Data.TrapezLength1 = this.spn_trapezlength1.Value;
    this.Data.TrapezLength2 = this.spn_trapezlength2.Value;
    this.Data.TrapezHeight = this.spn_trapezheight.Value;
    this.Data.SlotHeight = this.spn_slotheight.Value;
    this.Data.SlotWidth = this.spn_slotwidth.Value;
    this.Data.KeyHoleDiameter = this.spn_keyholediameter.Value;
    this.Data.KeyHoleLength = this.spn_keyholelength.Value;
    this.Data.KeyHoleWidth = this.spn_keyholewidth.Value;
    this.Data.DiagonalCut = this.buCheckBox_0.Check;
    this.Data.Rotation = this.spn_rotation.Value;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Apply();
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_4(object sender, EventArgs e)
  {
    ((buControl) sender).Display.BackColor = this.SpinFocusColor;
  }

  internal void method_5(object sender, EventArgs e)
  {
    ((buControl) sender).Display.BackColor = this.SpinBaseColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
