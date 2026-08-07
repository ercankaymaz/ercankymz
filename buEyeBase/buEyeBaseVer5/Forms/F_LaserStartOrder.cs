// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_LaserStartOrder
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_LaserStartOrder : Form
{
  private int \u0002;
  private Design \u0001;
  public buNestingVar Settings;
  public string AddPartFromFileExtender;
  public string AddSheetFromFileExtender;
  public string SaveFileExtender;
  public bool AddPartFromFileExtenderAsCsvType;
  public bool SendToCad;
  public int AddPartFromFileExtensionIndex;
  public int AddSheetFromFileExtensionIndex;
  public int SaveFileExtensionIndex;
  public string AddPartFromFileFolder;
  public string AddSheetFromFileFolder;
  public string SaveFileFolder;
  public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile;
  public nestPartRotateType PartRotationDefault;
  public List<buNestingSheet> Sheets;

  static F_LaserStartOrder() => F_NestOldResult.Captions = new List<string>();

  public F_LaserStartOrder()
  {
    ((F_NestOnlineCalc) this).Properties = new FormProperties();
    ((F_NestOnlineCalc) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((F_NestOnlineCalc) this).pathTool = Application.StartupPath;
    ((F_NestOnlineCalc) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Material) this);
  }

  public void Init()
  {
    ((F_NestOnlineCalc) this).\u0002.Value = (Decimal) ((SortResult) ((F_NestOnlineCalc) this).Material).Size.Width;
    ((F_NestOnlineCalc) this).\u0001.Value = (Decimal) ((SortResult) ((F_NestOnlineCalc) this).Material).Size.Height;
    ((F_NestOnlineCalc) this).\u0003.Value = (Decimal) ((SortAskMe) ((F_NestOnlineCalc) this).Material).Radius;
    ((F_NestOnlineCalc) this).\u0005.Value = (Decimal) ((SortAskMe) ((F_NestOnlineCalc) this).Material).MajorRadius;
    ((F_NestOnlineCalc) this).\u0004.Value = (Decimal) ((SortAskMe) ((F_NestOnlineCalc) this).Material).MinorRadius;
    ((F_NestOnlineCalc) this).\u0007.Value = (Decimal) ((SortResult) ((F_NestOnlineCalc) this).Material).Size.Depth;
    ((F_NestOnlineCalc) this).\u0006.Value = (Decimal) ((SortAskMe) ((F_NestOnlineCalc) this).Material).Angle;
    ((F_NestPartAddV2) this).\u0011.Value = (Decimal) ((SortOptions) ((F_NestOnlineCalc) this).Material).StartPoint.X;
    ((F_NestPartAddV2) this).\u0010.Value = (Decimal) ((SortOptions) ((F_NestOnlineCalc) this).Material).StartPoint.Y;
    ((F_NestPartAddV2) this).\u000F.Value = (Decimal) ((SortOptions) ((F_NestOnlineCalc) this).Material).StartPoint.Z;
    ((F_NestPartAddV2) this).\u0001.BackColor = ((SortOptions) ((F_NestOnlineCalc) this).Material).Display.SkinColor;
    ((F_NestPartAddV2) this).\u0012.Value = (Decimal) ((SortOptions) ((F_NestOnlineCalc) this).Material).Display.SkinTransperancy;
    ((F_NestPartAddV2) this).\u0001.Text = ((SortOptions) ((F_NestOnlineCalc) this).Material).Name;
    if (((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes == MaterialShapes.Rectangle)
      ((F_NestOnlineCalc) this).\u0001.SelectedIndex = 0;
    if (((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes == MaterialShapes.Circle)
      ((F_NestOnlineCalc) this).\u0001.SelectedIndex = 1;
    if (((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes == MaterialShapes.Ellipse)
      ((F_NestOnlineCalc) this).\u0001.SelectedIndex = 2;
    if (((SortAskMe) ((F_NestOnlineCalc) this).Material).Shapes == MaterialShapes.Irregular)
      ((F_NestOnlineCalc) this).\u0001.SelectedIndex = 3;
    ((F_NestOnlineCalc) this).Properties.Result = DialogResult.None;
    ((F_NestPartAddV2) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((SortOptions) ((F_NestOnlineCalc) this).Material).Points.Count - 1; ++index)
      ((F_NestPartAddV2) this).\u0001.Items.Add((object) $"{((SortOptions) ((F_NestOnlineCalc) this).Material).Points[index].X.ToString("f1")} , {((SortOptions) ((F_NestOnlineCalc) this).Material).Points[index].Y.ToString("f1")}");
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Material) this);
    \u0007.\u0001.\u0001((F_Material) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_Material) this);
    ((F_NestOnlineCalc) this).Properties.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_NestOnlineCalc) this).Properties.Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((SortOptions) ((F_NestOnlineCalc) this).Material).Points.Add(new Point3D((double) ((F_NestPartAddV2) this).\u000E.Value, (double) ((F_NestPartAddV2) this).\u0008.Value));
    ((F_NestPartAddV2) this).\u0001.Items.Add((object) $"{((SortOptions) ((F_NestOnlineCalc) this).Material).Points[((SortOptions) ((F_NestOnlineCalc) this).Material).Points.Count - 1].X.ToString("f1")} , {((SortOptions) ((F_NestOnlineCalc) this).Material).Points[((SortOptions) ((F_NestOnlineCalc) this).Material).Points.Count - 1].Y.ToString("f1")}");
    \u0007.\u0001.\u0001((F_Material) this);
  }
}
