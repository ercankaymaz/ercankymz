// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCoordinatesV2
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.ClassViewer;
using buControls.Controls;
using buControls.Viewer;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.PanelCut;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCoordinatesV2 : Form
{
  public double PlungeFeed;
  public double CuttingFeed;
  public CamClosedContourType CamType;
  public int ToolNo;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_slotheight;
  public buSpin spn_slotwidth;
  public buSpin spn_ZPos;
  public buSpin spn_XPos;
  internal buGroup \u0001;
  public buSpin spn_cuttingfeed;
  public buSpin spn_rapiddis;
  public buSpin spn_plungefeed;
  public buSpin spn_safedis;
  public FormProperties PropertiesForm;
  public List<string> MaterialFiles;
  public string selectedMaterialName;
  public string pathString;
  private Timer \u0001;
  private IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ImageList \u0001;
  internal ListBox \u0001;
  internal ImageList \u0002;
  internal Panel \u0001;
  internal PictureBox \u0001;
  public static byte f0019B6;
  public FormProperties PropertiesForm;
  public MaterialBase5 Material;
  public Design viewportLayout;
  public List<Entity> OptionEntity;
  public Entity EntClamper;
  public static List<string> Captions;
  private Timer \u0001;

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1))
      return;
    ((F_MaterialRect3D) this).\u0002 = obj1.RowIndex;
    buCall.\u0001.DrawPart(((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002], ((F_MaterialRect3D) this).Settings, ref ((F_MaterialRect3D) this).\u0001);
    if (!(((F_MaterialRect3D) this).\u0002 >= 0 & ((F_MaterialRect3D) this).\u0002 <= ((F_MaterialRect2D) this).Parts.Count - 1))
      return;
    ((F_MaterialRect3D) this).PropertiesForm.Inited = false;
    double num1 = 0.0;
    double num2 = 0.0;
    List<Point3D> Vertices = new List<Point3D>();
    double num3 = num1 + ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PartData).Width / 1000.0 * (((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PartData).Height / 1000.0) * Convert.ToDouble(((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PartData).Quantity);
    buVector5.Copy(((\u0084.\u0001) ((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EntitiesGroup.Outside).Points, ref Vertices);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Vertices);
    double area = ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).Area;
    double num4 = buCall.\u0001.PolygonArea(Vertices, Plane.XY);
    double num5 = num2 + num4 / 1000000.0 * Convert.ToDouble(((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PartData).Quantity);
    ((F_Material3D) this).\u0002.Text = num3.ToString("f2");
    ((F_Material3D) this).\u0001.Text = num5.ToString("f2");
    ((F_MarbleCam3DEngrave) this).\u0003.Text = ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).Referance;
    ((F_MarbleCamProfile) this).\u0006.Value = (Decimal) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PrecutHeight;
    ((F_MarbleCamProfile) this).\u0005.Value = (Decimal) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PrecutWidth;
    ((F_MarbleCam3DEngrave) this).\u0001.Value = (Decimal) ((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeBottomThickness;
    ((F_MarbleCam3DEngrave) this).\u0002.Value = (Decimal) ((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeTopThickness;
    ((F_MarbleCam3DEngrave) this).\u0004.Value = (Decimal) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeLeftThickness;
    ((F_MarbleCam3DEngrave) this).\u0003.Value = (Decimal) ((ProfileOperationCircle) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeRightThickness;
    ((F_MarbleCam3DEngrave) this).\u0001.Checked = ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeBottom;
    ((F_MarbleCam3DEngrave) this).\u0002.Checked = ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeTop;
    ((F_MarbleCam3DEngrave) this).\u0004.Checked = ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeLeft;
    ((F_MarbleCam3DEngrave) this).\u0003.Checked = ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeRight;
    ((F_MaterialRect3D) this).PropertiesForm.Inited = true;
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
    {
      buNestingPartData buNestingPartData = (buNestingPartData) new ProfileOperationRoundRectangle(((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData);
      ProfileOperationBarrel profileOperationBarrel = new ProfileOperationBarrel();
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Width = 300;
      classViewerDialog.Value = (object) buNestingPartData;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData = (buNestingPartData) new ProfileOperationRoundRectangle((buNestingPartData) classViewerDialog.Value);
        ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).Remain = ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Quantity - ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).Nested;
        if (((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingPart part = ((F_MaterialRect2D) this).Parts[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) part).PartData).Width, ((ProfileOperation) ((ProfileOperation) part).PartData).Height, ref part);
        }
        ((F_MarbleBottomPanelV1) this).\u0001();
        buCall.\u0001.DrawPart(((F_MaterialRect2D) this).Parts[obj1.RowIndex], ((F_MaterialRect3D) this).Settings, ref ((F_MaterialRect3D) this).\u0001);
        ((F_Material3D) this).\u0001.CurrentCell = ((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[1];
      }
    }
    this.\u0002();
  }

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
    {
      if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
        ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Name = Convert.ToString(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 4 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
      {
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Width = Convert.ToDouble(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString());
        buNestingPart part = ((F_MaterialRect2D) this).Parts[obj1.RowIndex];
        ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) part).PartData).Width, ((ProfileOperation) ((ProfileOperation) part).PartData).Height, ref part);
        buCall.\u0001.DrawPart(((F_MaterialRect2D) this).Parts[obj1.RowIndex], ((F_MaterialRect3D) this).Settings, ref ((F_MaterialRect3D) this).\u0001);
      }
      if (obj1.ColumnIndex == 5 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
      {
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Height = Convert.ToDouble(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString());
        buNestingPart part = ((F_MaterialRect2D) this).Parts[obj1.RowIndex];
        ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) part).PartData).Width, ((ProfileOperation) ((ProfileOperation) part).PartData).Height, ref part);
        buCall.\u0001.DrawPart(((F_MaterialRect2D) this).Parts[obj1.RowIndex], ((F_MaterialRect3D) this).Settings, ref ((F_MaterialRect3D) this).\u0001);
      }
      if (obj1.ColumnIndex == 6 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
      {
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Quantity = Convert.ToInt32(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).Remain = ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Quantity - ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).Nested;
      }
      if (obj1.ColumnIndex == 9 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Priority = Convert.ToInt32(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 12 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).ItemNo = Convert.ToString(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 13 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Other = Convert.ToString(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 14 & obj1.RowIndex <= ((F_MaterialRect2D) this).Parts.Count - 1)
        ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[obj1.RowIndex]).PartData).Aux = Convert.ToString(((F_Material3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    }
    this.\u0002();
  }

  public void AddPartFromEntities(List<eEntities> Entities)
  {
  }

  public void AddPartFromCsvFile(nestCsvPartImportType Mode, string FileName)
  {
    if (Mode != nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount)
      return;
    FileInfo fileInfo = new FileInfo(FileName);
    List<string> StringList = new List<string>();
    if (!fileInfo.Exists)
      return;
    buVector5.OpenFromFile(FileName, ref StringList);
    for (int index = 0; index <= StringList.Count - 1; ++index)
    {
      string[] strArray = StringList[index].Split(';');
      buNestingPart buNestingPart1 = (buNestingPart) new ProfileOperationBarrel();
      List<Point3D> point3DList = new List<Point3D>();
      if (strArray != null && strArray.Length >= 3 && buFile5.IsNumeric(strArray[0].Trim()) & buFile5.IsNumeric(strArray[1].Trim()) & buFile5.IsNumeric(strArray[2].Trim()))
      {
        buNestingPart Part = (buNestingPart) new ProfileOperationBarrel();
        ((ProfileOperation) ((ProfileOperation) Part).PartData).Width = Convert.ToDouble(strArray[0].Trim());
        ((ProfileOperation) ((ProfileOperation) Part).PartData).Height = Convert.ToDouble(strArray[1].Trim());
        ((ProfileOperation) ((ProfileOperation) Part).PartData).Quantity = Convert.ToInt32(strArray[2].Trim());
        ((ProfileOperation) Part).Remain = ((ProfileOperation) ((ProfileOperation) Part).PartData).Quantity;
        ((ProfileOperation) ((ProfileOperation) Part).PartData).Priority = 10;
        ((ProfileOperation) ((ProfileOperation) Part).PartData).Name = "Part-" + (index + 1).ToString();
        ((ProfileOperation) ((ProfileOperation) Part).PartData).Rotation = nestPartRotateType.Increment90;
        ((ProfileOperationRectangle) Part).Type = nestMaterialType.Rectangle;
        ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) Part).PartData).Width, ((ProfileOperation) ((ProfileOperation) Part).PartData).Height, ref Part);
        if (((ProfileOperation) ((ProfileOperation) Part).PartData).Quantity > 0 && ((ProfileOperation) ((ProfileOperation) Part).PartData).Width > 0.0 & ((ProfileOperation) ((ProfileOperation) Part).PartData).Height > 0.0)
        {
          buNestingPart buNestingPart2 = (buNestingPart) new ProfileOperationBarrel(Part);
          ((ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_MaterialRect2D) this).Parts, ref ((ProfileOperation) buNestingPart2).ID);
          ((F_MaterialRect2D) this).Parts.Add(buNestingPart2);
          Image Img = (Image) null;
          string str1 = "";
          string str2 = "";
          string str3 = "";
          string str4 = "";
          if (((ProfileOperation) buNestingPart2).EdgeLeft)
            str1 = ((ProfileOperation) buNestingPart2).EdgeLeftThickness.ToString();
          if (((ProfileOperation) buNestingPart2).EdgeRight)
            str2 = ((ProfileOperationCircle) buNestingPart2).EdgeRightThickness.ToString();
          if (((ProfileOperation) buNestingPart2).EdgeLeft)
            str3 = ((ProfileOperationRectangle) buNestingPart2).EdgeTopThickness.ToString();
          if (((ProfileOperation) buNestingPart2).EdgeLeft)
            str4 = ((ProfileOperationRectangle) buNestingPart2).EdgeBottomThickness.ToString();
          this.PartPointsToImage(Part, ((ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetPreviewWidth, ((ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetHeight, ref Img);
          DataGridViewRowCollection rows = ((F_Material3D) this).\u0001.Rows;
          int count = ((F_MaterialRect2D) this).Parts.Count;
          bool enable = ((ProfileOperation) Part).Enable;
          string name = ((ProfileOperation) ((ProfileOperation) Part).PartData).Name;
          double width = ((ProfileOperation) ((ProfileOperation) Part).PartData).Width;
          double height = ((ProfileOperation) ((ProfileOperation) Part).PartData).Height;
          int quantity = ((ProfileOperation) ((ProfileOperation) Part).PartData).Quantity;
          int nested = ((ProfileOperation) Part).Nested;
          int remain = ((ProfileOperation) Part).Remain;
          double precutWidth = ((ProfileOperation) Part).PrecutWidth;
          double precutHeight = ((ProfileOperation) Part).PrecutHeight;
          object[] objArray = \u0007.\u0001.\u0001(remain, quantity, precutHeight, precutWidth, (F_PanelCutPartList) this, str4, str2, width, Img, height, str3, str1, enable, nested, name, count);
          rows.Add(objArray);
        }
      }
    }
  }

  public void PartPointsToImage(buNestingPart Part, int Width, int Height, ref Image Img)
  {
    buViewer buViewer = new buViewer();
    buViewer.Width = Width;
    buViewer.Height = Height;
    List<eEntities> copiedEntity = new List<eEntities>();
    buString5.buEntityGroupToEEntities(((ProfileOperationRectangle) Part).EntitiesGroup, ref copiedEntity);
    buViewer.Entities.Clear();
    buViewer.Entities.AddRange((IEnumerable<eEntities>) copiedEntity);
    buViewer.DrawEntities();
    buViewer.ZoomFit();
    buViewer.ZoomOut();
    Img = (Image) buViewer.Bmp;
  }

  private void \u0002()
  {
    double num1 = 0.0;
    double num2 = 0.0;
    for (int index = 0; index <= ((F_MaterialRect2D) this).Parts.Count - 1; ++index)
    {
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      if (((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).EdgeLeft)
        str1 = ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).EdgeLeftThickness.ToString();
      if (((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).EdgeRight)
        str2 = ((ProfileOperationCircle) ((F_MaterialRect2D) this).Parts[index]).EdgeRightThickness.ToString();
      if (((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).EdgeTop)
        str3 = ((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[index]).EdgeTopThickness.ToString();
      if (((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).EdgeBottom)
        str4 = ((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[index]).EdgeBottomThickness.ToString();
      ((F_Material3D) this).\u0001.Rows[index].Cells[1].Value = (object) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Enable;
      ((F_Material3D) this).\u0001.Rows[index].Cells[2].Value = (object) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Referance;
      ((F_Material3D) this).\u0001.Rows[index].Cells[4].Value = (object) ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Width;
      ((F_Material3D) this).\u0001.Rows[index].Cells[5].Value = (object) ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Height;
      ((F_Material3D) this).\u0001.Rows[index].Cells[6].Value = (object) ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Quantity;
      ((F_Material3D) this).\u0001.Rows[index].Cells[7].Value = (object) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Nested;
      ((F_Material3D) this).\u0001.Rows[index].Cells[8].Value = (object) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Remain;
      ((F_Material3D) this).\u0001.Rows[index].Cells[9].Value = (object) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PrecutWidth;
      ((F_Material3D) this).\u0001.Rows[index].Cells[10].Value = (object) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PrecutHeight;
      ((F_Material3D) this).\u0001.Rows[index].Cells[11].Value = (object) str1;
      ((F_Material3D) this).\u0001.Rows[index].Cells[12].Value = (object) str2;
      ((F_Material3D) this).\u0001.Rows[index].Cells[13].Value = (object) str3;
      ((F_Material3D) this).\u0001.Rows[index].Cells[14].Value = (object) str4;
      if (((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Enable)
      {
        List<Point3D> point3DList = new List<Point3D>();
        num1 += ((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Width / 1000.0 * (((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Height / 1000.0) * Convert.ToDouble(((ProfileOperation) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Quantity);
      }
      if (index <= ((F_Material3D) this).\u0001.Rows.Count - 1)
        ((F_Material3D) this).\u0001.Rows[index].Cells[8].Value = (object) ((ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Remain;
    }
    ((F_Material3D) this).\u0002.Text = num1.ToString("f2");
    ((F_Material3D) this).\u0001.Text = num2.ToString("f2");
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (!(((F_MaterialRect3D) this).\u0002 >= 0 & ((F_MaterialRect3D) this).\u0002 <= ((F_MaterialRect2D) this).Parts.Count - 1 & ((F_MaterialRect3D) this).PropertiesForm.Inited))
      return;
    if (control.Name == ((F_MarbleCamProfile) this).\u0006.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PrecutHeight = (double) ((F_MarbleCamProfile) this).\u0006.Value;
    if (control.Name == ((F_MarbleCamProfile) this).\u0005.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PrecutWidth = (double) ((F_MarbleCamProfile) this).\u0005.Value;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0001.Name)
      ((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeBottomThickness = (double) ((F_MarbleCam3DEngrave) this).\u0001.Value;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0002.Name)
      ((ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeTopThickness = (double) ((F_MarbleCam3DEngrave) this).\u0002.Value;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0004.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeLeftThickness = (double) ((F_MarbleCam3DEngrave) this).\u0004.Value;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0003.Name)
      ((ProfileOperationCircle) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeRightThickness = (double) ((F_MarbleCam3DEngrave) this).\u0003.Value;
    this.\u0002();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (!(((F_MaterialRect3D) this).\u0002 >= 0 & ((F_MaterialRect3D) this).\u0002 <= ((F_MaterialRect2D) this).Parts.Count - 1 & ((F_MaterialRect3D) this).PropertiesForm.Inited))
      return;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0003.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0001]).Referance = ((F_MarbleCam3DEngrave) this).\u0003.Text;
    this.\u0002();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (!(((F_MaterialRect3D) this).\u0002 >= 0 & ((F_MaterialRect3D) this).\u0002 <= ((F_MaterialRect2D) this).Parts.Count - 1 & ((F_MaterialRect3D) this).PropertiesForm.Inited))
      return;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0001.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeBottom = ((F_MarbleCam3DEngrave) this).\u0001.Checked;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0002.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeTop = ((F_MarbleCam3DEngrave) this).\u0002.Checked;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0004.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeLeft = ((F_MarbleCam3DEngrave) this).\u0004.Checked;
    if (control.Name == ((F_MarbleCam3DEngrave) this).\u0003.Name)
      ((ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).EdgeRight = ((F_MarbleCam3DEngrave) this).\u0003.Checked;
    this.\u0002();
  }
}
