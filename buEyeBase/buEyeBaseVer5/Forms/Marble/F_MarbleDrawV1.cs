// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleDrawV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.DialogBox;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
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

public class F_MarbleDrawV1 : Form
{
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0002;
  public Panel pnl_model;
  internal Label \u0003;
  internal NumericUpDown \u0003;
  public static byte f0019C9;
  public FormProperties PropertiesForm;
  public MaterialBase5 Material;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MaterialRect2D) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MaterialRect2D) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleDrawV1()
  {
    F_MaterialRect2D.Captions = new List<string>();
    F_MaterialRect2D.CaptionGrid = new List<string>();
  }

  public F_MarbleDrawV1()
  {
    ((F_MarbleCamProfile) this).PropertiesForm = new FormProperties();
    ((F_MarbleCamProfile) this).\u0001 = new Timer();
    ((F_MarbleCamProfile) this).\u0001 = -1;
    ((F_MarbleCamProfile) this).\u0002 = -1;
    ((F_MarbleCamProfile) this).\u0001 = (Design) null;
    ((F_MarbleCamProfile) this).Settings = (buNestingVar) new buEyeBaseVer5.Apps.ProfileOperationDataBarel();
    ((F_MarbleCamProfile) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Part CSV File (*.csv)|*.csv";
    ((F_MarbleCamProfile) this).AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Sheet CSV File (*.csv)|*.csv";
    ((F_MarbleCamProfile) this).SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_MarbleCamProfile) this).AddPartFromFileExtenderAsCsvType = false;
    ((F_MarbleCamProfile) this).SendToCad = false;
    ((F_MarbleCamProfile) this).AddSheetFromFileExtensionIndex = 1;
    ((F_MarbleCamProfile) this).SaveFileExtensionIndex = 1;
    ((F_MarbleCamProfile) this).AddSheetFromFileFolder = Application.StartupPath;
    ((F_MarbleCamProfile) this).SaveFileFolder = Application.StartupPath;
    ((F_MarbleCamProfile) this).CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
    ((F_MarbleCamProfile) this).PartRotationDefault = nestPartRotateType.Increment90;
    ((F_MarbleCamProfile) this).Sheets = new List<buNestingSheet>();
    ((F_MarbleCamProfile) this).SendToCadEntities = new List<Entity>();
    ((F_MarbleCamProfile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_PanelCutSheetList) this);
  }

  public void Init(int SelectedTab)
  {
    ((F_MarbleCamProfile) this).PropertiesForm.Inited = false;
    ((F_MarbleCamProfile) this).SendToCad = false;
    if (((F_MarbleCamProfile) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_MarbleCamProfile) this).\u0001);
      ((F_MarbleCamProfile) this).\u0001.Dock = DockStyle.Fill;
      ((F_MarbleCam3D) this).\u0003.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamProfile) this).\u0001);
    }
    if (((GProfileOperation) ((ProfileSupportBlock) ((F_MarbleCamProfile) this).Settings).MaterailSettings).UseSmallAreaFirst)
      ((GProfileOperationGroup) buCall.\u0001).SortNestingMaterialFromSmallToBig(true, ref ((F_MarbleCamProfile) this).Sheets);
    ((F_MarbleCamProfile) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    if (((F_MarbleCamProfile) this).AddPartFromFileExtenderAsCsvType)
      ((F_MarbleCamProfile) this).AddPartFromFileExtender = ((F_MarbleCamProfile) this).AddPartFromFileExtender + "|Csv Files (*.csv)|*.csv";
    ((F_MarbleCamProfile) this).AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    string str1 = "No";
    string str2 = "Sel";
    string str3 = "Referance";
    string str4 = "Preview";
    string str5 = "Width";
    string str6 = "Height";
    string str7 = "Thickness";
    string str8 = "Count";
    string str9 = "Used";
    string str10 = "Remain";
    string str11 = "TrimWidth";
    string str12 = "TrimHeight";
    if (F_MarbleCamProfile.Captions.Count > 100)
      ;
    if (((F_MarbleCam3D) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = str1;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 50;
      dataGridViewColumn2.HeaderText = str2;
      dataGridViewColumn2.Name = "Sel";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 200;
      dataGridViewColumn3.HeaderText = str3;
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MarbleCamProfile) this).Settings).Draw).GridPartSheetPreviewWidth;
      dataGridViewColumn4.HeaderText = str4;
      dataGridViewColumn4.Name = "Image";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 100;
      dataGridViewColumn5.HeaderText = str5;
      dataGridViewColumn5.Name = "Width";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 100;
      dataGridViewColumn6.HeaderText = str6;
      dataGridViewColumn6.Name = "Height";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 80 /*0x50*/;
      dataGridViewColumn7.HeaderText = str7;
      dataGridViewColumn7.Name = "Thickness";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 80 /*0x50*/;
      dataGridViewColumn8.HeaderText = str8;
      dataGridViewColumn8.Name = "Count";
      dataGridViewColumn8.ReadOnly = false;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn8);
      DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
      dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn9.Width = 80 /*0x50*/;
      dataGridViewColumn9.HeaderText = str9;
      dataGridViewColumn9.Name = "Used";
      dataGridViewColumn9.ReadOnly = true;
      dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn9);
      DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
      dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn10.Width = 80 /*0x50*/;
      dataGridViewColumn10.HeaderText = str10;
      dataGridViewColumn10.Name = "Remain";
      dataGridViewColumn10.ReadOnly = true;
      dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn10.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn10);
      DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
      dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn11.Width = 100;
      dataGridViewColumn11.HeaderText = str11;
      dataGridViewColumn11.Name = "TrimWidth";
      dataGridViewColumn11.ReadOnly = true;
      dataGridViewColumn11.Visible = true;
      dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn11.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn11);
      DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
      dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn12.Width = 100;
      dataGridViewColumn12.HeaderText = str12;
      dataGridViewColumn12.Name = "TrimHeight";
      dataGridViewColumn12.ReadOnly = false;
      dataGridViewColumn12.Visible = true;
      dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn12.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn12);
      int num = ((F_MarbleCam3D) this).\u0001.Width - (dataGridViewColumn1.Width + dataGridViewColumn2.Width + dataGridViewColumn3.Width + dataGridViewColumn4.Width + dataGridViewColumn5.Width + dataGridViewColumn6.Width + dataGridViewColumn7.Width + dataGridViewColumn8.Width + dataGridViewColumn9.Width + dataGridViewColumn10.Width + dataGridViewColumn11.Width + dataGridViewColumn12.Width);
      if (num < 100)
        num = 100;
      DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
      dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn13.Width = num;
      dataGridViewColumn13.HeaderText = str3;
      dataGridViewColumn13.Name = "Referance";
      dataGridViewColumn13.ReadOnly = false;
      dataGridViewColumn13.Visible = true;
      dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn13.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleCam3D) this).\u0001.Columns.Add(dataGridViewColumn13);
    }
    ((F_MarbleCam3D) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleCam3D) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleCam3D) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleCamProfile) this).SendToCadEntities.Clear();
    ((F_MarbleCamProfile) this).SendToCadEntities = new List<Entity>();
    ((F_MarbleCamProfile) this).\u0001 = new Timer();
    \u0007.\u0001.\u0001((F_PanelCutSheetList) this);
    ((F_MarbleCam3D) this).\u0001.SelectedIndex = 0;
    if (!((F_MarbleCam3D) this).\u0003.Checked & !((F_MarbleCam3D) this).\u0001.Checked & !((F_MarbleCam3D) this).\u0002.Checked)
      ((F_MarbleCam3D) this).\u0002.Checked = true;
    this.LoadLanguage();
    ((F_MarbleCamProfile) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCamProfile) this).PropertiesForm.Inited = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCamProfile) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCamProfile) this).PropertiesForm.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_MarbleCamProfile.Captions.Count < 33)
        return;
      this.Text = F_MarbleCamProfile.Captions[0];
      ((F_MarbleCam3D) this).\u0001.Text = F_MarbleCamProfile.Captions[1];
      ((F_MarbleCam3D) this).\u0003.Text = F_MarbleCamProfile.Captions[1];
      ((F_MarbleCam3D) this).\u0004.Text = F_MarbleCamProfile.Captions[4];
      ((F_MarbleCam3D) this).\u0003.Text = F_MarbleCamProfile.Captions[5];
      ((F_MarbleCam3D) this).\u0002.Text = F_MarbleCamProfile.Captions[10];
      ((F_MarbleCam3D) this).\u0001.Text = F_MarbleCamProfile.Captions[11];
      ((F_MarbleCam3D) this).\u0003.Text = F_MarbleCamProfile.Captions[12];
      ((F_MarbleCam3D) this).\u0002.Text = F_MarbleCamProfile.Captions[13];
      ((F_MarbleCam3D) this).\u0001.Text = F_MarbleCamProfile.Captions[14];
      ((F_MarbleCam3D) this).\u0002.Text = F_MarbleCamProfile.Captions[15];
      ((F_MarbleCam3D) this).\u0001.Text = F_MarbleCamProfile.Captions[16 /*0x10*/];
      ((F_MarbleCam3D) this).chk_preview.Text = F_MarbleCamProfile.Captions[17];
      ((F_MarbleCam3D) this).\u0006.Text = F_MarbleCamProfile.Captions[18];
      ((F_MarbleCam3D) this).\u0005.Text = F_MarbleCamProfile.Captions[19];
      ((F_MarbleCam3D) this).\u0008.Text = F_MarbleCamProfile.Captions[20];
      ((F_MarbleCam3D) this).\u0007.Text = F_MarbleCamProfile.Captions[21];
      ((F_MarbleCam3D) this).\u0004.Text = F_MarbleCamProfile.Captions[22];
      ((F_MarbleCam3D) this).\u0005.Text = F_MarbleCamProfile.Captions[23];
      ((F_MarbleCam3D) this).\u0006.Text = F_MarbleCamProfile.Captions[29];
      ((F_MarbleCam3D) this).\u0007.Text = F_MarbleCamProfile.Captions[31 /*0x1F*/];
      ((F_MarbleCam3D) this).\u0001.Text = F_MarbleCamProfile.Captions[32 /*0x20*/];
      ((F_MarbleCam3D) this).\u0002.Text = F_MarbleCamProfile.Captions[52];
      ((F_MarbleCam3D) this).\u0003.Text = F_MarbleCamProfile.Captions[28];
      ((F_MarbleCam3D) this).\u0008.Text = F_MarbleCamProfile.Captions[29];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    string str1 = "";
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
      str1 = ((System.Windows.Forms.Control) obj0).Name;
    if (obj0.GetType() == typeof (ToolStripMenuItem))
      str1 = ((ToolStripItem) obj0).Name;
    if (str1 == ((F_MarbleCam3D) this).\u0004.Name)
    {
      F_NestSheetAdd fNestSheetAdd = (F_NestSheetAdd) new F_SortingSettings();
      ((F_Layer) fNestSheetAdd).ShowItemNo = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MarbleCamProfile) this).Settings).Draw).ShowSheetItemNoColumb;
      ((F_Layer) fNestSheetAdd).FormCloseMode = FormCloseModeType.Dispose;
      ((F_SortingSettings) fNestSheetAdd).Init();
      fNestSheetAdd.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fNestSheetAdd.ShowDialog();
      if (((F_Layer) fNestSheetAdd).Result == DialogResult.OK)
      {
        buNestingSheet buNestingSheet = (buNestingSheet) new buEyeBaseVer5.Apps.ProfileOperation(((F_Layer) fNestSheetAdd).Sheet);
        buCall.\u0001.SetColorEntity(((ProfileOperationSortItem) ((ProfileMultiply) ((F_MarbleCamProfile) this).Settings).Draw).SheetEntityColor, ref ((\u0084.\u0001) ((ProfileItemCalc) buNestingSheet).EntitiesGroup.Outside).Entities);
        ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingSheetID(((F_MarbleCamProfile) this).Sheets, ref ((ProfileItemCalc) buNestingSheet).ID);
        ((F_MarbleCamProfile) this).Sheets.Add(buNestingSheet);
        Image Img = (Image) null;
        ((F_MarbleJobOPListV2) this).SheetPointsToImage(((F_Layer) fNestSheetAdd).Sheet, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MarbleCamProfile) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MarbleCamProfile) this).Settings).Draw).GridPartSheetHeight, ref Img);
        DataGridViewRowCollection rows = ((F_MarbleCam3D) this).\u0001.Rows;
        int count = ((F_MarbleCamProfile) this).Sheets.Count;
        bool enable = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Enable;
        string referance = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Referance;
        double width = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Width;
        double height = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Height;
        double thickness = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Thickness;
        int quantity = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Quantity;
        int used = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Used;
        int remain = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Remain;
        double trimWidth = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).TrimWidth;
        double trimHeight = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).TrimHeight;
        string remarks = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Remarks;
        object[] objArray = \u0001.\u0002.\u0001(used, Img, (F_PanelCutSheetList) this, count, thickness, trimHeight, quantity, referance, trimWidth, height, width, remarks, remain, enable);
        rows.Add(objArray);
        ((F_MarbleCam3D) this).\u0001.Rows[((F_MarbleCam3D) this).\u0001.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
        ((F_MarbleCam3D) this).\u0001.Rows[((F_MarbleCam3D) this).\u0001.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MarbleCamProfile) this).Settings).Draw).GridPartSheetHeight;
      }
    }
    if (str1 == ((F_MarbleCam3D) this).\u0003.Name)
    {
      if (((F_MarbleCam3D) this).\u0003.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        ((F_MarbleCamProfile) this).Sheets.Clear();
        ((F_MarbleCam3D) this).\u0001.Rows.Clear();
      }
      if (((F_MarbleCam3D) this).\u0002.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        ((F_MarbleCam3D) this).\u0001.Rows.RemoveAt(((F_MarbleCamProfile) this).\u0001);
        ((F_MarbleCamProfile) this).Sheets.RemoveAt(((F_MarbleCamProfile) this).\u0001);
      }
      if (!((F_MarbleCam3D) this).\u0001.Checked || buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) != DialogResult.Yes)
        return;
      for (int index = ((F_MarbleCam3D) this).\u0001.Rows.Count - 1; index >= 0; --index)
      {
        if (Convert.ToBoolean(((F_MarbleCam3D) this).\u0001.Rows[index].Cells[1].Value))
        {
          ((F_MarbleCam3D) this).\u0001.Rows.RemoveAt(index);
          ((F_MarbleCamProfile) this).Sheets.RemoveAt(index);
        }
      }
    }
    else
    {
      if (str1 == ((F_MarbleCam3D) this).\u0002.Name && ((F_MarbleCamProfile) this).\u0001 >= 0 & ((F_MarbleCamProfile) this).\u0001 <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
      {
        ((F_MarbleCam3D) this).\u0001.Rows[((F_MarbleCamProfile) this).\u0001].Cells[7].Value = (object) 0;
        ((F_MarbleCam3D) this).\u0001.Rows[((F_MarbleCamProfile) this).\u0001].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).MaterialData).Quantity;
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).Used = 0;
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).MaterialData).Quantity;
        ((F_MarbleCam3D) this).\u0001.Rows[((F_MarbleCamProfile) this).\u0001].DefaultCellStyle.ForeColor = Color.Black;
      }
      if (str1 == ((F_MarbleCam3D) this).\u0001.Name)
      {
        for (int index = 0; index <= ((F_MarbleCamProfile) this).Sheets.Count - 1; ++index)
        {
          ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index]).Used = 0;
          ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index]).MaterialData).Quantity;
          ((F_MarbleCam3D) this).\u0001.Rows[index].Cells[7].Value = (object) 0;
          ((F_MarbleCam3D) this).\u0001.Rows[index].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index]).MaterialData).Quantity;
          ((F_MarbleCam3D) this).\u0001.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
        }
      }
      if (str1 == ((F_MarbleCam3D) this).\u0001.Name)
      {
        for (int index = ((F_MarbleCam3D) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_MarbleCam3D) this).\u0001.Rows[index].Cells[1].Value = (object) true;
          ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index]).Enable = true;
        }
      }
      if (str1 == ((F_MarbleCam3D) this).\u0002.Name)
      {
        for (int index = ((F_MarbleCam3D) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_MarbleCam3D) this).\u0001.Rows[index].Cells[1].Value = (object) false;
          ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index]).Enable = false;
        }
      }
      if (str1 == ((F_MarbleCam3D) this).\u0003.Name)
      {
        DialogBoxInput dialogBoxInput = new DialogBoxInput();
        dialogBoxInput.ValueCaption = "Count";
        dialogBoxInput.FormCaption = "Set Sheet Count";
        dialogBoxInput.Value = 1.0;
        int num = (int) dialogBoxInput.ShowDialog();
        if (dialogBoxInput.Result == DialogResult.OK)
        {
          for (int index = ((F_MarbleCam3D) this).\u0001.Rows.Count - 1; index >= 0; --index)
          {
            ((F_MarbleCam3D) this).\u0001.Rows[index].Cells[6].Value = (object) Convert.ToInt32(dialogBoxInput.Value);
            ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index]).MaterialData).Quantity = Convert.ToInt32(dialogBoxInput.Value);
          }
        }
      }
      if (str1 == ((F_MarbleCam3D) this).\u0008.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_MarbleCamProfile) this).SaveFileFolder;
        saveFileDialog.Filter = ((F_MarbleCamProfile) this).SaveFileExtender;
        saveFileDialog.FilterIndex = ((F_MarbleCamProfile) this).SaveFileExtensionIndex;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          ((F_MarbleCamProfile) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
          if (fileInfo.Extension == ".dxf")
          {
            for (int index1 = 0; index1 <= ((F_MarbleCamProfile) this).Sheets.Count - 1; ++index1)
            {
              if (((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).Enable)
              {
                string str2 = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).MaterialData).Name.Trim();
                int num;
                if (str2.Length == 0)
                {
                  num = index1 + 1;
                  str2 = "Mat" + num.ToString();
                }
                string[] strArray = new string[10];
                strArray[0] = buFile5.bunesting.GetPath(saveFileDialog.FileName);
                strArray[1] = "\\";
                strArray[2] = buFile5.bunesting.getFileNameWithoutExtension(saveFileDialog.FileName);
                strArray[3] = "_";
                num = index1 + 1;
                strArray[4] = num.ToString();
                strArray[5] = "_";
                strArray[6] = str2;
                strArray[7] = "_";
                strArray[8] = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).MaterialData).Quantity.ToString();
                strArray[9] = fileInfo.Extension;
                string FileName = string.Concat(strArray);
                List<Entity> copiedEntities = new List<Entity>();
                buDiametricDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.Outside).Entities, ref copiedEntities);
                if (((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.Inside != null)
                {
                  for (int index2 = 0; index2 <= ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.Inside.Count - 1; ++index2)
                  {
                    for (int index3 = 0; index3 <= ((\u0084.\u0001) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.Inside[index2]).Entities.Count - 1; ++index3)
                    {
                      Entity copiedEntity = (Entity) null;
                      buAngularDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.Inside[index2]).Entities[index3], ref copiedEntity);
                      copiedEntities.Add(copiedEntity);
                    }
                  }
                }
                if (((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.OpenEntities != null)
                {
                  for (int index4 = 0; index4 <= ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.OpenEntities.Count - 1; ++index4)
                  {
                    for (int index5 = 0; index5 <= ((\u0084.\u0001) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.OpenEntities[index4]).Entities.Count - 1; ++index5)
                    {
                      Entity copiedEntity = (Entity) null;
                      buAngularDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup.OpenEntities[index4]).Entities[index5], ref copiedEntity);
                      copiedEntities.Add(copiedEntity);
                    }
                  }
                }
                if (((DimensionGroup) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup).Text != null)
                {
                  for (int index6 = 0; index6 <= ((\u0084.\u0001) ((DimensionGroup) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup).Text).Entities.Count - 1; ++index6)
                  {
                    Entity copiedEntity = (Entity) null;
                    buAngularDim.Copy(((\u0084.\u0001) ((DimensionGroup) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[index1]).EntitiesGroup).Text).Entities[index6], ref copiedEntity);
                    copiedEntities.Add(copiedEntity);
                  }
                }
                cParameter5.SaveDxfDwg(copiedEntities, FileName);
              }
            }
          }
        }
      }
      if (str1 == ((F_MarbleCam3D) this).\u0005.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_MarbleCamProfile) this).SaveFileFolder;
        saveFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_MarbleCamProfile) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
          new buVector5().SaveNesting(saveFileDialog.FileName, new List<buNestingPart>(), ((F_MarbleCamProfile) this).Sheets, ((F_MarbleCamProfile) this).Settings);
        }
      }
      if (str1 == ((F_MarbleCam3D) this).\u0006.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((F_MarbleCamProfile) this).SaveFileFolder;
        openFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_MarbleCamProfile) this).SaveFileFolder = buFile5.bunesting.GetPath(openFileDialog.FileName);
          buFile5.bunesting bunesting = (buFile5.bunesting) new buVector5();
          List<buNestingPart> Parts = new List<buNestingPart>();
          ((buVector5) bunesting).OpenNesting(openFileDialog.FileName, ref Parts, ref ((F_MarbleCamProfile) this).Sheets);
          this.Init(((F_MarbleCam3D) this).\u0001.SelectedIndex);
        }
      }
      if (str1 == ((F_MarbleCam3D) this).\u0007.Name)
      {
        this.Visible = false;
        ((F_MarbleCamProfile) this).PropertiesForm.Result = DialogResult.Cancel;
      }
      if (!(str1 == ((F_MarbleCam3D) this).\u0008.Name))
        return;
      this.Visible = false;
      ((F_MarbleCamProfile) this).PropertiesForm.Result = DialogResult.OK;
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1))
      return;
    ((F_MarbleCamProfile) this).\u0001 = obj1.RowIndex;
    buCall.\u0001.DrawSheet(((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001], ((F_MarbleCamProfile) this).Settings, ref ((F_MarbleCamProfile) this).\u0001);
    if (!(((F_MarbleCamProfile) this).\u0001 >= 0 & ((F_MarbleCamProfile) this).\u0001 <= ((F_MarbleCamProfile) this).Sheets.Count - 1))
      return;
    ((F_MarbleCamProfile) this).PropertiesForm.Inited = false;
    List<Point3D> Vertices = new List<Point3D>();
    double num1 = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).MaterialData).Width / 1000.0 * (((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).MaterialData).Height / 1000.0);
    buVector5.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).EntitiesGroup.Outside).Points, ref Vertices);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Vertices);
    double num2 = buCall.\u0001.PolygonArea(Vertices, Plane.XY);
    ((F_MarbleCam3D) this).\u0002.Text = num1.ToString("f2");
    ((F_MarbleCam3D) this).\u0001.Text = (num2 / 1000000.0).ToString("f2");
    ((F_MarbleCam3D) this).\u0004.Text = ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).Referance;
    ((F_MarbleCam3D) this).\u0003.Text = ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).Remarks;
    ((F_MarbleBottomPanelV1) this).\u0002.Value = (Decimal) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).TrimHeight;
    ((F_MarbleBottomPanelV1) this).\u0001.Value = (Decimal) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[((F_MarbleCamProfile) this).\u0001]).TrimWidth;
    ((F_MarbleCamProfile) this).PropertiesForm.Inited = true;
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_MarbleCamProfile) this).Sheets.Count - 1)
    {
      buNestingSheetData nestingSheetData = (buNestingSheetData) new buEyeBaseVer5.Apps.ProfileOperation(((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData);
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Width = 300;
      classViewerDialog.Value = (object) nestingSheetData;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData = (buNestingSheetData) new buEyeBaseVer5.Apps.ProfileOperation((buNestingSheetData) classViewerDialog.Value);
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Area = ((buEyeBaseVer5.Apps.ProfileItem) nestingSheetData).Height * ((buEyeBaseVer5.Apps.ProfileItem) nestingSheetData).Width;
        ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Used;
        if (((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Quantity < 0)
          ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Quantity;
        if (((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_MarbleCamProfile) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        \u0007.\u0001.\u0001((F_PanelCutSheetList) this);
        buCall.\u0001.DrawSheet(((F_MarbleCamProfile) this).Sheets[obj1.RowIndex], ((F_MarbleCamProfile) this).Settings, ref ((F_MarbleCamProfile) this).\u0001);
        ((F_MarbleCam3D) this).\u0001.CurrentCell = ((F_MarbleCam3D) this).\u0001.Rows[obj1.RowIndex].Cells[1];
      }
    }
    \u0007.\u0001.\u0001((F_PanelCutSheetList) this);
  }
}
