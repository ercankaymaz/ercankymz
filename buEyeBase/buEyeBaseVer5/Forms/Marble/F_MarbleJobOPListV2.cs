// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleJobOPListV2
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Viewer;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.PanelCut;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleJobOPListV2 : Form
{
  public Design viewportLayout;
  public List<Entity> OptionEntity;
  public Entity EntClamper;
  public static List<string> Captions;
  private Timer \u0001;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  public Panel pnl_model;
  public static byte f0019DA;
  public FormProperties PropertiesForm;
  public MaterialBase5 Material;
  public Design viewportLayout;
  public List<Entity> OptionEntity;
  public Entity EntClamper;
  public bool DrawDimension;
  public static List<string> Captions;
  private Timer \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0002;
  internal Label \u0004;
  internal NumericUpDown \u0003;

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
    {
      if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Name = Convert.ToString(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 4 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
      {
        ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Width = Convert.ToDouble(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Area = ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Height * ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Width;
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Used;
        if (((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        buCall.\u0001.DrawSheet(((F_MarbleCamProfile) this).Sheets[obj1.RowIndex], ((F_MarbleCamProfile) this).Settings, ref ((F_MarbleCamProfile) this).\u0001);
      }
      if (obj1.ColumnIndex == 5 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
      {
        ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Height = Convert.ToDouble(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Area = ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Height * ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Width;
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Used;
        if (((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        buCall.\u0001.DrawSheet(((F_MarbleCamProfile) this).Sheets[obj1.RowIndex], ((F_MarbleCamProfile) this).Settings, ref ((F_MarbleCamProfile) this).\u0001);
      }
      if (obj1.ColumnIndex == 6 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
      {
        ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Quantity = Convert.ToInt32(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Remain = ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Used;
      }
      if (obj1.ColumnIndex == 11 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).ItemNo = Convert.ToString(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 12 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Other = Convert.ToString(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 13 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
        ((ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Aux = Convert.ToString(((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    }
    \u0007.\u0001.\u0001((F_PanelCutSheetList) this);
  }

  public void SheetPointsToImage(buNestingSheet Sheet, int Width, int Height, ref Image Img)
  {
    buViewer buViewer = new buViewer();
    buViewer.Width = Width;
    buViewer.Height = Height;
    for (int index = 0; index <= ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities.Count - 1; ++index)
    {
      eEntities buEntity = new eEntities();
      buString5.buEntityToEEntities(((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities[index], ((CustomDataSurrogate) ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities[index]).Color, ref buEntity);
      buViewer.Entities.Add(buEntity);
    }
    buViewer.DrawEntities();
    buViewer.ZoomFit();
    buViewer.ZoomOut();
    Img = (Image) buViewer.Bmp;
  }

  public void CreatPartAsRectanlge(
    double newWidth,
    double newHeight,
    buNestingPart OldPart,
    ref buNestingPart NewPart)
  {
    NewPart = (buNestingPart) new ProfileOperationBarrel(OldPart);
    ((ProfileOperationRectangle) NewPart).Type = nestMaterialType.Rectangle;
    ((ProfileOperation) ((ProfileOperation) NewPart).PartData).Width = newWidth;
    ((ProfileOperation) ((ProfileOperation) NewPart).PartData).Height = newHeight;
    ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) NewPart).PartData).Width, ((ProfileOperation) ((ProfileOperation) NewPart).PartData).Height, ref NewPart);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (!(((F_MarbleCamProfile) this).\u0001 >= 0 & ((F_MarbleCamProfile) this).\u0001 <= ((F_MarbleCamProfile) this).Sheets.Count - 1 & ((F_MarbleCamProfile) this).PropertiesForm.Inited))
      return;
    if (control.Name == ((F_MarbleBottomPanelV1) this).\u0002.Name)
      ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).TrimHeight = (double) ((F_MarbleBottomPanelV1) this).\u0002.Value;
    if (control.Name == ((F_MarbleBottomPanelV1) this).\u0001.Name)
      ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).TrimWidth = (double) ((F_MarbleBottomPanelV1) this).\u0001.Value;
    \u0007.\u0001.\u0001((F_PanelCutSheetList) this);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (!(((F_MarbleCamProfile) this).\u0001 >= 0 & ((F_MarbleCamProfile) this).\u0001 <= ((F_MarbleCamProfile) this).Sheets.Count - 1 & ((F_MarbleCamProfile) this).PropertiesForm.Inited))
      return;
    if (control.Name == ((F_MarbleCam3D) this).\u0003.Name)
      ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).Remarks = ((F_MarbleCam3D) this).\u0003.Text;
    if (control.Name == ((F_MarbleCam3D) this).\u0004.Name)
      ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).Referance = ((F_MarbleCam3D) this).\u0004.Text;
    \u0007.\u0001.\u0001((F_PanelCutSheetList) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCamProfile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamProfile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleJobOPListV2()
  {
    F_MarbleCamProfile.Captions = new List<string>();
    F_MarbleCamProfile.CaptionGrid = new List<string>();
  }

  public F_MarbleJobOPListV2()
  {
    ((F_MarbleBottomPanelV1) this).PropertiesForm = new FormProperties();
    ((F_MarbleBottomPanelV1) this).\u0001 = new Timer();
    ((F_MarbleBottomPanelV1) this).\u0001 = -1;
    ((F_MarbleBottomPanelV1) this).\u0002 = -1;
    ((F_MarbleBottomPanelV1) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_MarbleBottomPanelV1) this).AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_MarbleBottomPanelV1) this).SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_MarbleBottomPanelV1) this).AddPartFromFileExtenderAsCsvType = false;
    ((F_MarbleBottomPanelV1) this).SendToCad = false;
    ((F_MarbleBottomPanelV1) this).AddPartFromFileExtensionIndex = 1;
    ((F_MarbleBottomPanelV1) this).AddSheetFromFileExtensionIndex = 1;
    ((F_MarbleBottomPanelV1) this).SaveFileExtensionIndex = 1;
    ((F_MarbleBottomPanelV1) this).AddPartFromFileFolder = Application.StartupPath;
    ((F_MarbleBottomPanelV1) this).AddSheetFromFileFolder = Application.StartupPath;
    ((F_MarbleBottomPanelV1) this).SaveFileFolder = Application.StartupPath;
    ((F_MarbleBottomPanelV1) this).CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode2_NameWidthHeightCount;
    ((F_MarbleBottomPanelV1) this).PartRotationDefault = nestPartRotateType.Increment90;
    ((F_MarbleBottomPanelV1) this).Materails = new List<buNestingMaterials>();
    ((F_MarbleBottomPanelV1) this).SendToCadEntities = new List<Entity>();
    ((F_MarbleBottomPanelV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_PanelCutMaterials) this);
  }

  public void Init()
  {
    ((F_MarbleBottomPanelV1) this).PropertiesForm.Inited = false;
    string str1 = "No";
    string str2 = "Sel";
    string str3 = "Material";
    string str4 = "Thickness";
    string str5 = "Explanation";
    string str6 = "Cost";
    if (F_MarbleBottomPanelV1.Captions.Count > 46)
      ;
    if (((F_MarbleBottomPanelV1) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = str1;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleBottomPanelV1) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 50;
      dataGridViewColumn2.HeaderText = str2;
      dataGridViewColumn2.Name = "Sel";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_MarbleBottomPanelV1) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 150;
      dataGridViewColumn3.HeaderText = str3;
      dataGridViewColumn3.Name = "Material";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleBottomPanelV1) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 50;
      dataGridViewColumn4.HeaderText = str4;
      dataGridViewColumn4.Name = "Thickness";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleBottomPanelV1) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 150;
      dataGridViewColumn5.HeaderText = str5;
      dataGridViewColumn5.Name = "Exp";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleBottomPanelV1) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 60;
      dataGridViewColumn6.HeaderText = str6;
      dataGridViewColumn6.Name = "Cost";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleBottomPanelV1) this).\u0001.Columns.Add(dataGridViewColumn6);
    }
    ((F_MarbleBottomPanelV1) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleBottomPanelV1) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleBottomPanelV1) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleBottomPanelV1) this).\u0001 = new Timer();
    \u0007.\u0001.\u0001((F_PanelCutMaterials) this);
    ((F_MarbleStartLine) this).LoadLanguage();
    ((F_MarbleBottomPanelV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleBottomPanelV1) this).PropertiesForm.Inited = false;
  }
}
