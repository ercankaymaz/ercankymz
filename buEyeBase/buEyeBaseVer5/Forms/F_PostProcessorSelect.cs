// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_PostProcessorSelect
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.ClassViewer;
using buEyeBaseVer5.Apps;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_PostProcessorSelect : Form
{
  internal NumericUpDown \u0001;
  internal Panel \u0002;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  internal NumericUpDown \u0002;
  internal Panel \u0003;
  internal Label \u0008;
  internal Label \u000E;
  internal Label \u000F;
  internal NumericUpDown \u0003;
  internal Label \u0010;

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1))
      return;
    ((F_BendingLRAList) this).\u0001 = obj1.RowIndex;
    buCall.\u0001.DrawSheet(((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
    if (!(((F_BendingLRAList) this).\u0001 >= 0 & ((F_BendingLRAList) this).\u0001 <= ((F_LaserStartOrder) this).Sheets.Count - 1))
      return;
    List<Point3D> Vertices = new List<Point3D>();
    double num1 = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001]).MaterialData).Width / 1000.0 * (((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001]).MaterialData).Height / 1000.0);
    buVector5.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[((F_BendingLRAList) this).\u0001]).EntitiesGroup.Outside).Points, ref Vertices);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Vertices);
    double num2 = buCall.\u0001.PolygonArea(Vertices, Plane.XY);
    ((F_LaserMaterial) this).\u0002.Text = num1.ToString("f2");
    ((F_LaserMaterial) this).\u0001.Text = (num2 / 1000000.0).ToString("f2");
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
    {
      buNestingSheetData nestingSheetData = (buNestingSheetData) new ProfileOperation(((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData);
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Width = 300;
      classViewerDialog.Value = (object) nestingSheetData;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData = (buNestingSheetData) new ProfileOperation((buNestingSheetData) classViewerDialog.Value);
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Area = ((ProfileItem) nestingSheetData).Height * ((ProfileItem) nestingSheetData).Width;
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Used;
        if (((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Quantity < 0)
          ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Quantity;
        if (((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_LaserStartOrder) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutNestSheetPartList) this);
        buCall.\u0001.DrawSheet(((F_LaserStartOrder) this).Sheets[obj1.RowIndex], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
        ((F_LaserMaterial) this).\u0001.CurrentCell = ((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[1];
      }
    }
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutNestSheetPartList) this);
  }

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
    {
      if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Name = Convert.ToString(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 4 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
      {
        ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Width = Convert.ToDouble(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Area = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Height * ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Width;
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Used;
        if (((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_LaserStartOrder) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        buCall.\u0001.DrawSheet(((F_LaserStartOrder) this).Sheets[obj1.RowIndex], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
      }
      if (obj1.ColumnIndex == 5 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
      {
        ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Height = Convert.ToDouble(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Area = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Height * ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Width;
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Used;
        if (((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_LaserStartOrder) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        buCall.\u0001.DrawSheet(((F_LaserStartOrder) this).Sheets[obj1.RowIndex], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
      }
      if (obj1.ColumnIndex == 6 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
      {
        ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Quantity = Convert.ToInt32(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).Used;
      }
      if (obj1.ColumnIndex == 11 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).ItemNo = Convert.ToString(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 12 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Other = Convert.ToString(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 13 & obj1.RowIndex <= ((F_LaserStartOrder) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_LaserStartOrder) this).Sheets[obj1.RowIndex]).MaterialData).Aux = Convert.ToString(((F_LaserMaterial) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    }
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutNestSheetPartList) this);
  }

  internal void \u0004([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1))
      return;
    ((F_LaserStartOrder) this).\u0002 = obj1.RowIndex;
    buCall.\u0001.DrawPart(((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
    if (!(((F_LaserStartOrder) this).\u0002 >= 0 & ((F_LaserStartOrder) this).\u0002 <= ((F_LaserMaterial) this).Parts.Count - 1))
      return;
    double num1 = 0.0;
    double num2 = 0.0;
    List<Point3D> Vertices = new List<Point3D>();
    double num3 = num1 + ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).PartData).Width / 1000.0 * (((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).PartData).Height / 1000.0) * Convert.ToDouble(((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).PartData).Quantity);
    buVector5.Copy(((\u0084.\u0001) ((ProfileOperationRectangle) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).EntitiesGroup.Outside).Points, ref Vertices);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Vertices);
    double area = ((ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).Area;
    double num4 = buCall.\u0001.PolygonArea(Vertices, Plane.XY);
    double num5 = num2 + num4 / 1000000.0 * Convert.ToDouble(((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[((F_LaserStartOrder) this).\u0002]).PartData).Quantity);
    ((F_LaserMaterial) this).\u0004.Text = num3.ToString("f2");
    ((F_LaserMaterial) this).\u0003.Text = num5.ToString("f2");
  }

  internal void \u0005([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
    {
      buNestingPartData buNestingPartData = (buNestingPartData) new ProfileOperationRoundRectangle(((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData);
      ProfileOperationBarrel profileOperationBarrel = new ProfileOperationBarrel();
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Width = 300;
      classViewerDialog.Value = (object) buNestingPartData;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData = (buNestingPartData) new ProfileOperationRoundRectangle((buNestingPartData) classViewerDialog.Value);
        ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).Remain = ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Quantity - ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).Nested;
        if (((ProfileOperationRectangle) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingPart part = ((F_LaserMaterial) this).Parts[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) part).PartData).Width, ((ProfileOperation) ((ProfileOperation) part).PartData).Height, ref part);
        }
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutNestSheetPartList) this);
        buCall.\u0001.DrawPart(((F_LaserMaterial) this).Parts[obj1.RowIndex], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
        ((F_LaserMaterial) this).\u0002.CurrentCell = ((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[1];
      }
    }
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutNestSheetPartList) this);
  }

  internal void \u0006([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
    {
      if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
        ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Name = Convert.ToString(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 4 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
      {
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Width = Convert.ToDouble(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString());
        buNestingPart part = ((F_LaserMaterial) this).Parts[obj1.RowIndex];
        ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) part).PartData).Width, ((ProfileOperation) ((ProfileOperation) part).PartData).Height, ref part);
        buCall.\u0001.DrawPart(((F_LaserMaterial) this).Parts[obj1.RowIndex], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
      }
      if (obj1.ColumnIndex == 5 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
      {
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Height = Convert.ToDouble(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString());
        buNestingPart part = ((F_LaserMaterial) this).Parts[obj1.RowIndex];
        ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) part).PartData).Width, ((ProfileOperation) ((ProfileOperation) part).PartData).Height, ref part);
        buCall.\u0001.DrawPart(((F_LaserMaterial) this).Parts[obj1.RowIndex], ((F_LaserStartOrder) this).Settings, ref ((F_LaserStartOrder) this).\u0001);
      }
      if (obj1.ColumnIndex == 6 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
      {
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Quantity = Convert.ToInt32(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).Remain = ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Quantity - ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).Nested;
      }
      if (obj1.ColumnIndex == 9 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Priority = Convert.ToInt32(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 12 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).ItemNo = Convert.ToString(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 13 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Other = Convert.ToString(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 14 & obj1.RowIndex <= ((F_LaserMaterial) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_LaserMaterial) this).Parts[obj1.RowIndex]).PartData).Aux = Convert.ToString(((F_LaserMaterial) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    }
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutNestSheetPartList) this);
  }

  public void AddPartFromEntities(List<eEntities> Entities)
  {
  }

  public void AddPartFromCsvFile(nestCsvPartImportType Mode, string FileName)
  {
    if (Mode == nestCsvPartImportType.Mode1_ItemNo)
    {
      FileInfo fileInfo = new FileInfo(FileName);
      List<string> StringList = new List<string>();
      if (fileInfo.Exists)
        buVector5.OpenFromFile(FileName, ref StringList);
    }
    if (Mode != nestCsvPartImportType.Mode2_NameWidthHeightCount)
      return;
    FileInfo fileInfo1 = new FileInfo(FileName);
    List<string> StringList1 = new List<string>();
    if (!fileInfo1.Exists)
      return;
    buVector5.OpenFromFile(FileName, ref StringList1);
  }
}
