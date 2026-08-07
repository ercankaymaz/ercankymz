// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_ToolList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_ToolList : Form
{
  internal Label \u0006;
  internal Panel \u0004;
  internal NumericUpDown \u0001;
  internal Label \u0007;
  internal ToolStripMenuItem \u0014;
  internal ToolStripMenuItem \u0015;
  internal ToolStripSeparator \u0007;
  internal ToolStripMenuItem \u0016;
  internal Button \u0014;
  public ListBox lst_info;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Layer) this).Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Layer) this).Result = DialogResult.Cancel;
    if (((F_Layer) this).FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Layer) this).FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (((F_Layer) this).FormCloseMode != FormCloseModeType.Close)
      return;
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Layer) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Layer) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ToolList() => F_Layer.Captions = new List<string>();

  public F_ToolList()
  {
    ((F_QuiltingSettings) this).PropertiesForm = new FormProperties();
    ((F_QuiltingSettings) this).\u0001 = new Timer();
    ((F_QuiltingSettings) this).\u0001 = -1;
    ((F_QuiltingSettings) this).SelectedRowPart = -1;
    ((F_QuiltingSettings) this).SelectedColPart = -1;
    ((F_QuiltingSettings) this).PartPreSelectedRow = -1;
    ((F_QuiltingSettings) this).\u0001 = (Design) null;
    ((F_QuiltingSettings) this).Settings = (buNestingVar) new ProfileOperationDataBarel();
    ((F_QuiltingSettings) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Part CSV File (*.csv)|*.csv";
    ((F_QuiltingSettings) this).AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Sheet CSV File (*.csv)|*.csv";
    ((F_QuiltingSettings) this).SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_QuiltingSettings) this).AddPartFromFileExtenderAsCsvType = false;
    ((F_QuiltingSettings) this).SendToCad = false;
    ((F_QuiltingSettings) this).DrawPart = false;
    ((F_QuiltingSettings) this).ShiftPressed = false;
    ((F_RoboticSurfacePoints) this).AddPartFromFileExtensionIndex = 1;
    ((F_RoboticSurfacePoints) this).AddSheetFromFileExtensionIndex = 1;
    ((F_RoboticSurfacePoints) this).SaveFileExtensionIndex = 1;
    ((F_RoboticSurfacePoints) this).AddPartFromFileFolder = Application.StartupPath;
    ((F_RoboticSurfacePoints) this).AddSheetFromFileFolder = Application.StartupPath;
    ((F_RoboticSurfacePoints) this).SaveFileFolder = Application.StartupPath;
    ((F_RoboticSurfacePoints) this).activeTool = (ToolBase5) new ToolGeometry5();
    ((F_RoboticSurfacePoints) this).activeLayer = (LayerBase5) new EntityShapeInfo();
    ((F_RoboticSurfacePoints) this).CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
    ((F_RoboticSurfacePoints) this).PartRotationDefault = nestPartRotateType.Increment90;
    ((F_RoboticSurfacePoints) this).Sheets = new List<buNestingSheet>();
    ((F_RoboticSurfacePoints) this).Parts = new List<buNestingPart>();
    ((F_RoboticSurfacePoints) this).SendToCadEntities = new List<Entity>();
    ((F_RoboticSurfacePoints) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_NestSheetPartList) this);
  }

  public void Init(int SelectedTab)
  {
    ((F_QuiltingSettings) this).PropertiesForm.Inited = false;
    ((F_QuiltingSettings) this).SendToCad = false;
    ((F_QuiltingSettings) this).DrawPart = false;
    if (((F_QuiltingSettings) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_QuiltingSettings) this).\u0001);
      ((F_QuiltingSettings) this).\u0001.Dock = DockStyle.Fill;
      this.\u0004.Controls.Add((System.Windows.Forms.Control) ((F_QuiltingSettings) this).\u0001);
    }
    if (((GProfileOperation) ((ProfileSupportBlock) ((F_QuiltingSettings) this).Settings).MaterailSettings).UseSmallAreaFirst)
      ((GProfileOperationGroup) buCall.\u0001).SortNestingMaterialFromSmallToBig(true, ref ((F_RoboticSurfacePoints) this).Sheets);
    ((F_QuiltingSettings) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    if (((F_QuiltingSettings) this).AddPartFromFileExtenderAsCsvType)
      ((F_QuiltingSettings) this).AddPartFromFileExtender = ((F_QuiltingSettings) this).AddPartFromFileExtender + "|Csv Files (*.csv)|*.csv";
    ((F_QuiltingSettings) this).AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    string str1 = "No";
    string str2 = "Sel";
    string str3 = "Name";
    string str4 = "Preview";
    string str5 = "Width";
    string str6 = "Height";
    string str7 = "Count";
    string str8 = "Used";
    string str9 = "Remain";
    string str10 = "Filename";
    string str11 = "Thickness";
    string str12 = "ItemNo";
    string str13 = "Other";
    string str14 = "Aux";
    string str15 = "Nested";
    string str16 = "Rotation";
    string str17 = "Priority";
    if (F_RoboticSurfacePoints.Captions.Count > 46)
    {
      str1 = F_RoboticSurfacePoints.Captions[35];
      str2 = F_RoboticSurfacePoints.Captions[36];
      str3 = F_RoboticSurfacePoints.Captions[37];
      str4 = F_RoboticSurfacePoints.Captions[38];
      str5 = F_RoboticSurfacePoints.Captions[39];
      str6 = F_RoboticSurfacePoints.Captions[40];
      str7 = F_RoboticSurfacePoints.Captions[41];
      str8 = F_RoboticSurfacePoints.Captions[46];
      str9 = F_RoboticSurfacePoints.Captions[43];
      str10 = F_RoboticSurfacePoints.Captions[47];
      str11 = F_RoboticSurfacePoints.Captions[48 /*0x30*/];
      str12 = F_RoboticSurfacePoints.Captions[51];
      str13 = F_RoboticSurfacePoints.Captions[50];
      str14 = F_RoboticSurfacePoints.Captions[49];
      str15 = F_RoboticSurfacePoints.Captions[42];
      str16 = F_RoboticSurfacePoints.Captions[45];
      str17 = F_RoboticSurfacePoints.Captions[44];
    }
    if (((F_RoboticSurfacePoints) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = str1;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 50;
      dataGridViewColumn2.HeaderText = str2;
      dataGridViewColumn2.Name = "Sel";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 200;
      dataGridViewColumn3.HeaderText = str3;
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetPreviewWidth;
      dataGridViewColumn4.HeaderText = str4;
      dataGridViewColumn4.Name = "Image";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 100;
      dataGridViewColumn5.HeaderText = str5;
      dataGridViewColumn5.Name = "Width";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 100;
      dataGridViewColumn6.HeaderText = str6;
      dataGridViewColumn6.Name = "Height";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 80 /*0x50*/;
      dataGridViewColumn7.HeaderText = str7;
      dataGridViewColumn7.Name = "Count";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 100;
      dataGridViewColumn8.HeaderText = str8;
      dataGridViewColumn8.Name = "Used";
      dataGridViewColumn8.ReadOnly = true;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn8);
      DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
      dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn9.Width = 100;
      dataGridViewColumn9.HeaderText = str9;
      dataGridViewColumn9.Name = "Remain";
      dataGridViewColumn9.ReadOnly = true;
      dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn9);
      DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
      dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn10.Width = 200;
      dataGridViewColumn10.HeaderText = str10;
      dataGridViewColumn10.Name = "FileName";
      dataGridViewColumn10.ReadOnly = true;
      dataGridViewColumn10.Visible = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowSheetFileNameColumb;
      dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn10.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn10);
      DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
      dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn11.Width = 100;
      dataGridViewColumn11.HeaderText = str11;
      dataGridViewColumn11.Name = "Thickness";
      dataGridViewColumn11.ReadOnly = false;
      dataGridViewColumn11.Visible = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowSheetThicknessColumb;
      dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn11.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn11);
      DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
      dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn12.Width = 80 /*0x50*/;
      dataGridViewColumn12.HeaderText = str12;
      dataGridViewColumn12.Name = "ItemNo";
      dataGridViewColumn12.ReadOnly = false;
      dataGridViewColumn12.Visible = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowSheetItemNoColumb;
      dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn12.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn12);
      DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
      dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn13.Width = 80 /*0x50*/;
      dataGridViewColumn13.HeaderText = str13;
      dataGridViewColumn13.Name = "Other";
      dataGridViewColumn13.ReadOnly = false;
      dataGridViewColumn13.Visible = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowSheetOtherColumb;
      dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn13.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn13);
      DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
      dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn14.Width = 80 /*0x50*/;
      dataGridViewColumn14.HeaderText = str14;
      dataGridViewColumn14.Name = "Aux";
      dataGridViewColumn14.ReadOnly = false;
      dataGridViewColumn14.Visible = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowSheetAuxColumb;
      dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn14.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_RoboticSurfacePoints) this).\u0001.Columns.Add(dataGridViewColumn14);
    }
    ((F_RoboticSurfacePoints) this).\u0001.RowHeadersVisible = false;
    ((F_RoboticSurfacePoints) this).\u0001.AllowUserToAddRows = false;
    ((F_RoboticSurfacePoints) this).\u0001.AllowUserToResizeColumns = false;
    if (((F_SettingTreeView) this).\u0002.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
      dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn15.Width = 40;
      dataGridViewColumn15.HeaderText = str1;
      dataGridViewColumn15.Name = "No";
      dataGridViewColumn15.ReadOnly = true;
      dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn15.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn15);
      DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
      dataGridViewColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn16.Width = 50;
      dataGridViewColumn16.HeaderText = str2;
      dataGridViewColumn16.Name = "Sel";
      dataGridViewColumn16.ReadOnly = false;
      dataGridViewColumn16.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn16.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn16);
      DataGridViewColumn dataGridViewColumn17 = new DataGridViewColumn();
      dataGridViewColumn17.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn17.Width = 200;
      dataGridViewColumn17.HeaderText = str3;
      dataGridViewColumn17.Name = "Name";
      dataGridViewColumn17.ReadOnly = false;
      dataGridViewColumn17.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn17.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn17);
      DataGridViewColumn dataGridViewColumn18 = new DataGridViewColumn();
      dataGridViewColumn18.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn18.Width = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetPreviewWidth;
      dataGridViewColumn18.HeaderText = str4;
      dataGridViewColumn18.Name = "Image";
      dataGridViewColumn18.ReadOnly = true;
      dataGridViewColumn18.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn18.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn18);
      DataGridViewColumn dataGridViewColumn19 = new DataGridViewColumn();
      dataGridViewColumn19.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn19.Width = 100;
      dataGridViewColumn19.HeaderText = str5;
      dataGridViewColumn19.Name = "Width";
      dataGridViewColumn19.ReadOnly = false;
      dataGridViewColumn19.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn19.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn19);
      DataGridViewColumn dataGridViewColumn20 = new DataGridViewColumn();
      dataGridViewColumn20.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn20.Width = 100;
      dataGridViewColumn20.HeaderText = str6;
      dataGridViewColumn20.Name = "Height";
      dataGridViewColumn20.ReadOnly = false;
      dataGridViewColumn20.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn20.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn20);
      DataGridViewColumn dataGridViewColumn21 = new DataGridViewColumn();
      dataGridViewColumn21.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn21.Width = 80 /*0x50*/;
      dataGridViewColumn21.HeaderText = str7;
      dataGridViewColumn21.Name = "Count";
      dataGridViewColumn21.ReadOnly = false;
      dataGridViewColumn21.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn21.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn21);
      DataGridViewColumn dataGridViewColumn22 = new DataGridViewColumn();
      dataGridViewColumn22.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn22.Width = 80 /*0x50*/;
      dataGridViewColumn22.HeaderText = str15;
      dataGridViewColumn22.Name = "Nested";
      dataGridViewColumn22.ReadOnly = true;
      dataGridViewColumn22.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn22.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn22);
      DataGridViewColumn dataGridViewColumn23 = new DataGridViewColumn();
      dataGridViewColumn23.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn23.Width = 80 /*0x50*/;
      dataGridViewColumn23.HeaderText = str9;
      dataGridViewColumn23.Name = "Remain";
      dataGridViewColumn23.ReadOnly = true;
      dataGridViewColumn23.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn23.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn23);
      DataGridViewColumn dataGridViewColumn24 = new DataGridViewColumn();
      dataGridViewColumn24.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn24.Width = 80 /*0x50*/;
      dataGridViewColumn24.HeaderText = str17;
      dataGridViewColumn24.Name = "Priority";
      dataGridViewColumn24.ReadOnly = true;
      dataGridViewColumn24.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn24.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn24);
      DataGridViewColumn dataGridViewColumn25 = new DataGridViewColumn();
      dataGridViewColumn25.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn25.Width = 140;
      dataGridViewColumn25.HeaderText = str16;
      dataGridViewColumn25.Name = "Rotation";
      dataGridViewColumn25.ReadOnly = true;
      dataGridViewColumn25.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn25.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn25);
      DataGridViewColumn dataGridViewColumn26 = new DataGridViewColumn();
      dataGridViewColumn26.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn26.Width = 80 /*0x50*/;
      dataGridViewColumn26.HeaderText = buLangTranslate.preDef.Mirror;
      dataGridViewColumn26.Name = buLangTranslate.preDef.Mirror;
      dataGridViewColumn26.ReadOnly = false;
      dataGridViewColumn26.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn26.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      dataGridViewColumn26.Visible = true;
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn26);
      DataGridViewColumn dataGridViewColumn27 = new DataGridViewColumn();
      dataGridViewColumn27.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn27.Width = 200;
      dataGridViewColumn27.HeaderText = str10;
      dataGridViewColumn27.Name = "FileName";
      dataGridViewColumn27.ReadOnly = true;
      dataGridViewColumn27.Visible = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowPartFileNameColumb;
      dataGridViewColumn27.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn27.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn27);
      DataGridViewColumn dataGridViewColumn28 = new DataGridViewColumn();
      dataGridViewColumn28.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn28.Width = 100;
      dataGridViewColumn28.HeaderText = str11;
      dataGridViewColumn28.Name = "Thickness";
      dataGridViewColumn28.ReadOnly = false;
      dataGridViewColumn28.Visible = ((ProfileClamperSettings) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowPartThicknessColumb;
      dataGridViewColumn28.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn28.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn28);
      DataGridViewColumn dataGridViewColumn29 = new DataGridViewColumn();
      dataGridViewColumn29.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn29.Width = 80 /*0x50*/;
      dataGridViewColumn29.HeaderText = str12;
      dataGridViewColumn29.Name = "ItemNo";
      dataGridViewColumn29.ReadOnly = false;
      dataGridViewColumn29.Visible = ((ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowPartItemNoColumb;
      dataGridViewColumn29.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn29.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn29);
      DataGridViewColumn dataGridViewColumn30 = new DataGridViewColumn();
      dataGridViewColumn30.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn30.Width = 80 /*0x50*/;
      dataGridViewColumn30.HeaderText = str13;
      dataGridViewColumn30.Name = "Other";
      dataGridViewColumn30.ReadOnly = false;
      dataGridViewColumn30.Visible = ((ProfileClamperSettings) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowPartOtherColumb;
      dataGridViewColumn30.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn30.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn30);
      DataGridViewColumn dataGridViewColumn31 = new DataGridViewColumn();
      dataGridViewColumn31.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn31.Width = 80 /*0x50*/;
      dataGridViewColumn31.HeaderText = str14;
      dataGridViewColumn31.Name = "Aux";
      dataGridViewColumn31.ReadOnly = false;
      dataGridViewColumn31.Visible = ((ProfileClamperSettings) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowPartAuxColumb;
      dataGridViewColumn31.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn31.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_SettingTreeView) this).\u0002.Columns.Add(dataGridViewColumn31);
    }
    ((F_SettingTreeView) this).\u0002.RowHeadersVisible = false;
    ((F_SettingTreeView) this).\u0002.AllowUserToAddRows = false;
    ((F_SettingTreeView) this).\u0002.AllowUserToResizeColumns = false;
    this.\u0001.Value = (Decimal) ((ProfileOperationSlot) ((ProfileSupportBlock) ((F_QuiltingSettings) this).Settings).PartSettings).Multiply;
    ((F_RoboticSurfacePoints) this).SendToCadEntities.Clear();
    ((F_RoboticSurfacePoints) this).SendToCadEntities = new List<Entity>();
    ((F_QuiltingSettings) this).\u0001 = new Timer();
    \u0007.\u0001.\u0001((F_NestSheetPartList) this);
    if (SelectedTab == 0)
      ((F_RoboticSurfacePoints) this).\u0001.SelectedIndex = 0;
    if (SelectedTab == 1)
      ((F_RoboticSurfacePoints) this).\u0001.SelectedIndex = 1;
    if (!((F_SortingSettings) this).\u0006.Checked & !((F_SortingSettings) this).\u0004.Checked & !((F_SortingSettings) this).\u0005.Checked)
      ((F_SortingSettings) this).\u0005.Checked = true;
    if (!((F_SortingSettings) this).\u0003.Checked & !((F_SortingSettings) this).\u0001.Checked & !((F_SortingSettings) this).\u0002.Checked)
      ((F_SortingSettings) this).\u0002.Checked = true;
    this.LoadLanguage();
    ((F_TuftingImageList) this).GetInfo();
    ((F_QuiltingSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_QuiltingSettings) this).PropertiesForm.Inited = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_QuiltingSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_QuiltingSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_RoboticSurfacePoints.Captions.Count < 33)
        return;
      this.Text = F_RoboticSurfacePoints.Captions[0];
      ((F_RoboticSurfacePoints) this).\u0001.Text = F_RoboticSurfacePoints.Captions[1];
      ((F_SortingSettings) this).\u0005.Text = F_RoboticSurfacePoints.Captions[1];
      ((F_SettingTreeView) this).\u0002.Text = F_RoboticSurfacePoints.Captions[2];
      this.\u0006.Text = F_RoboticSurfacePoints.Captions[2];
      ((F_SettingTreeView) this).\u0001.Text = F_RoboticSurfacePoints.Captions[3];
      ((F_SettingTreeView) this).\u0005.Text = F_RoboticSurfacePoints.Captions[4];
      ((F_SettingTreeView) this).\u0004.Text = F_RoboticSurfacePoints.Captions[5];
      ((F_SettingTreeView) this).\u0006.Text = F_RoboticSurfacePoints.Captions[6];
      ((F_SettingTreeView) this).\u000F.Text = F_RoboticSurfacePoints.Captions[7];
      ((F_SettingTreeView) this).\u000E.Text = F_RoboticSurfacePoints.Captions[8];
      this.\u0007.Text = F_RoboticSurfacePoints.Captions[9];
      ((F_SettingTreeView) this).\u0003.Text = F_RoboticSurfacePoints.Captions[10];
      ((F_SettingTreeView) this).\u0002.Text = F_RoboticSurfacePoints.Captions[11];
      ((F_SettingTreeView) this).\u0008.Text = F_RoboticSurfacePoints.Captions[10];
      ((F_SettingTreeView) this).\u0007.Text = F_RoboticSurfacePoints.Captions[11];
      ((F_SortingSettings) this).\u0003.Text = F_RoboticSurfacePoints.Captions[12];
      ((F_SortingSettings) this).\u0002.Text = F_RoboticSurfacePoints.Captions[13];
      ((F_SortingSettings) this).\u0001.Text = F_RoboticSurfacePoints.Captions[14];
      ((F_SortingSettings) this).\u0006.Text = F_RoboticSurfacePoints.Captions[12];
      ((F_SortingSettings) this).\u0005.Text = F_RoboticSurfacePoints.Captions[13];
      ((F_SortingSettings) this).\u0004.Text = F_RoboticSurfacePoints.Captions[14];
      ((F_SettingTreeView) this).\u0002.Text = F_RoboticSurfacePoints.Captions[15];
      ((F_SettingTreeView) this).\u0001.Text = F_RoboticSurfacePoints.Captions[16 /*0x10*/];
      ((F_SettingTreeView) this).\u0004.Text = F_RoboticSurfacePoints.Captions[15];
      ((F_SettingTreeView) this).\u0003.Text = F_RoboticSurfacePoints.Captions[16 /*0x10*/];
      ((F_SortingSettings) this).chk_preview.Text = F_RoboticSurfacePoints.Captions[17];
      ((F_SortingSettings) this).\u0011.Text = F_RoboticSurfacePoints.Captions[18];
      ((F_SortingSettings) this).\u0010.Text = F_RoboticSurfacePoints.Captions[19];
      ((F_SortingSettings) this).\u0013.Text = F_RoboticSurfacePoints.Captions[20];
      ((F_SortingSettings) this).\u0012.Text = F_RoboticSurfacePoints.Captions[21];
      ((F_SettingTreeView) this).\u0004.Text = F_RoboticSurfacePoints.Captions[22];
      ((DataTableItem) this).\u0005.Text = F_RoboticSurfacePoints.Captions[23];
      ((TreeNodeSettings) this).\u0006.Text = F_RoboticSurfacePoints.Captions[24];
      ((F_SortingSettings) this).\u0007.Text = F_RoboticSurfacePoints.Captions[25];
      ((F_SortingSettings) this).\u0008.Text = F_RoboticSurfacePoints.Captions[26];
      ((F_SortingSettings) this).\u000E.Text = F_RoboticSurfacePoints.Captions[27];
      ((F_SortingSettings) this).\u000F.Text = F_RoboticSurfacePoints.Captions[28];
      ((F_SortingSettings) this).\u0010.Text = F_RoboticSurfacePoints.Captions[29];
      ((F_SortingSettings) this).\u0011.Text = F_RoboticSurfacePoints.Captions[30];
      ((F_SortingSettings) this).\u0012.Text = F_RoboticSurfacePoints.Captions[31 /*0x1F*/];
      ((F_SettingTreeView) this).\u0001.Text = F_RoboticSurfacePoints.Captions[32 /*0x20*/];
      ((F_SettingTreeView) this).\u0002.Text = F_RoboticSurfacePoints.Captions[52];
      ((F_SettingTreeView) this).\u0003.Text = F_RoboticSurfacePoints.Captions[28];
      ((F_SortingSettings) this).\u0013.Text = F_RoboticSurfacePoints.Captions[29];
      this.\u0014.Text = F_RoboticSurfacePoints.Captions[33];
      this.\u0015.Text = F_RoboticSurfacePoints.Captions[34];
      this.\u0016.Text = F_RoboticSurfacePoints.Captions[53];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }
}
