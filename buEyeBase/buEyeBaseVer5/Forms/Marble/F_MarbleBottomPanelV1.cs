// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleBottomPanelV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Foam;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Material;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.PanelCut;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleBottomPanelV1 : Form
{
  internal Label \u0006;
  internal NumericUpDown \u0001;
  internal Label \u0007;
  internal NumericUpDown \u0002;
  public static byte f00195F;
  public FormProperties PropertiesForm;
  internal Timer \u0001;
  private int \u0001;
  private int \u0002;
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
  public List<buNestingMaterials> Materails;
  public List<Entity> SendToCadEntities;
  public static List<string> Captions;
  public static List<string> CaptionGrid;
  internal IContainer \u0001;
  internal DataGridView \u0001;
  internal ImageList \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal ToolStripMenuItem \u0002;
  internal ToolStripSeparator \u0001;
  internal ToolStripSeparator \u0002;
  internal ToolStripMenuItem \u0003;
  internal ToolStripMenuItem \u0004;
  internal ToolStripMenuItem \u0005;
  internal ToolStripMenuItem \u0006;
  internal Button \u0003;
  internal Button \u0004;
  internal TextBox \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal TextBox \u0002;
  public static byte f00198D;
  public FormProperties Properties;
  public static List<string> Captions;
  public double Width;
  public double Diameter;
  public double XPos;
  public double YPos;
  public double SafeDis;
  public double RapidDis;

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    if (obj1.KeyCode == Keys.Escape)
    {
      ((F_MaterialsList) this).Value = ((F_MaterialRect3D) this).\u0001;
      if (((F_MaterialsList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Close();
      if (((F_MaterialsList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (obj1.KeyCode != Keys.Return)
        return;
      ((F_MarbleCam3D) this).\u0001((object) ((F_MaterialRect3D) this).\u0001, (EventArgs) null);
    }
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = (F_KeyPadNumV1) new F_FoamSlicesList();
    ((F_HolesTemp) fKeyPadNumV1).Caption = ((F_MaterialsList) this).Value;
    ((F_HolesTemp) fKeyPadNumV1).textCtrl1.PasswordChar = '*';
    ((F_HolesTemp) fKeyPadNumV1).PasswordChar = '*';
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    ((F_FoamSlicesList) fKeyPadNumV1).ShowDialog(((F_MaterialsList) this).Value, (IWin32Window) this);
    ((F_MaterialRect3D) this).textCtrl1.Text = ((F_HolesTemp) fKeyPadNumV1).Value;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MaterialRect3D) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MaterialRect3D) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m000E0A();

  public F_MarbleBottomPanelV1()
  {
    ((F_MaterialRect3D) this).PropertiesForm = new FormProperties();
    ((F_MaterialRect3D) this).\u0001 = new Timer();
    ((F_MaterialRect3D) this).\u0001 = -1;
    ((F_MaterialRect3D) this).\u0002 = -1;
    ((F_MaterialRect3D) this).\u0001 = (Design) null;
    ((F_MaterialRect3D) this).Settings = (buNestingVar) new buEyeBaseVer5.Apps.ProfileOperationDataBarel();
    ((F_MaterialRect3D) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Part CSV File (*.csv)|*.csv";
    ((F_MaterialRect3D) this).SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";
    ((F_MaterialRect2D) this).AddPartFromFileExtenderAsCsvType = false;
    ((F_MaterialRect2D) this).SendToCad = false;
    ((F_MaterialRect2D) this).AddPartFromFileExtensionIndex = 1;
    ((F_MaterialRect2D) this).SaveFileExtensionIndex = 1;
    ((F_MaterialRect2D) this).AddPartFromFileFolder = Application.StartupPath;
    ((F_MaterialRect2D) this).SaveFileFolder = Application.StartupPath;
    ((F_MaterialRect2D) this).CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
    ((F_MaterialRect2D) this).PartRotationDefault = nestPartRotateType.Increment90;
    ((F_MaterialRect2D) this).Parts = new List<buNestingPart>();
    ((F_MaterialRect2D) this).SendToCadEntities = new List<Entity>();
    ((F_MaterialRect2D) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PanelCutPartList) this);
  }

  public void Init(int SelectedTab)
  {
    ((F_MaterialRect3D) this).PropertiesForm.Inited = false;
    ((F_MaterialRect2D) this).SendToCad = false;
    if (((F_MaterialRect3D) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_MaterialRect3D) this).\u0001);
      ((F_MaterialRect3D) this).\u0001.Dock = DockStyle.Fill;
      ((F_MarbleCam3DEngrave) this).\u0003.Controls.Add((System.Windows.Forms.Control) ((F_MaterialRect3D) this).\u0001);
    }
    ((F_MaterialRect3D) this).AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
    if (((F_MaterialRect2D) this).AddPartFromFileExtenderAsCsvType)
      ((F_MaterialRect3D) this).AddPartFromFileExtender = ((F_MaterialRect3D) this).AddPartFromFileExtender + "|Csv Files (*.csv)|*.csv";
    string str1 = "No";
    string str2 = "Sel";
    string str3 = "Name";
    string str4 = "Preview";
    string str5 = "Width";
    string str6 = "Height";
    string str7 = "Count";
    string str8 = "Remain";
    string str9 = "Precut Width";
    string str10 = "Precut Height";
    string str11 = "Left Edge";
    string str12 = "Right Edge";
    string str13 = "Top Edge";
    string str14 = "Bottom Edge";
    string str15 = "Nested";
    if (F_MaterialRect2D.Captions.Count > 46)
    {
      str1 = F_MaterialRect2D.Captions[35];
      str2 = F_MaterialRect2D.Captions[36];
      str3 = F_MaterialRect2D.Captions[37];
      str4 = F_MaterialRect2D.Captions[38];
      str5 = F_MaterialRect2D.Captions[39];
      str6 = F_MaterialRect2D.Captions[40];
      str7 = F_MaterialRect2D.Captions[41];
      string caption = F_MaterialRect2D.Captions[46];
      str8 = F_MaterialRect2D.Captions[43];
      str9 = F_MaterialRect2D.Captions[47];
      str10 = F_MaterialRect2D.Captions[48 /*0x30*/];
      str11 = F_MaterialRect2D.Captions[51];
      str12 = F_MaterialRect2D.Captions[50];
    }
    if (((F_Material3D) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = str1;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 50;
      dataGridViewColumn2.HeaderText = str2;
      dataGridViewColumn2.Name = "Sel";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewCheckBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 200;
      dataGridViewColumn3.HeaderText = str3;
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetPreviewWidth;
      dataGridViewColumn4.HeaderText = str4;
      dataGridViewColumn4.Name = "Image";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 100;
      dataGridViewColumn5.HeaderText = str5;
      dataGridViewColumn5.Name = "Width";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 100;
      dataGridViewColumn6.HeaderText = str6;
      dataGridViewColumn6.Name = "Height";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 80 /*0x50*/;
      dataGridViewColumn7.HeaderText = str7;
      dataGridViewColumn7.Name = "Count";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 100;
      dataGridViewColumn8.HeaderText = str15;
      dataGridViewColumn8.Name = "Nested";
      dataGridViewColumn8.ReadOnly = true;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn8);
      DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
      dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn9.Width = 100;
      dataGridViewColumn9.HeaderText = str8;
      dataGridViewColumn9.Name = "Remain";
      dataGridViewColumn9.ReadOnly = true;
      dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn9);
      DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
      dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn10.Width = 100;
      dataGridViewColumn10.HeaderText = str9;
      dataGridViewColumn10.Name = "PreCut Width";
      dataGridViewColumn10.ReadOnly = true;
      dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn10.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn10);
      DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
      dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn11.Width = 100;
      dataGridViewColumn11.HeaderText = str10;
      dataGridViewColumn11.Name = "Precut Height";
      dataGridViewColumn11.ReadOnly = true;
      dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn11.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn11);
      DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
      dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn12.Width = 80 /*0x50*/;
      dataGridViewColumn12.HeaderText = str11;
      dataGridViewColumn12.Name = "Left Edge";
      dataGridViewColumn12.ReadOnly = true;
      dataGridViewColumn12.Visible = true;
      dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn12.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn12);
      DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
      dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn13.Width = 80 /*0x50*/;
      dataGridViewColumn13.HeaderText = str12;
      dataGridViewColumn13.Name = "Right Edge";
      dataGridViewColumn13.ReadOnly = false;
      dataGridViewColumn13.Visible = true;
      dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn13.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn13);
      DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
      dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn14.Width = 80 /*0x50*/;
      dataGridViewColumn14.HeaderText = str13;
      dataGridViewColumn14.Name = "Top Edge";
      dataGridViewColumn14.ReadOnly = false;
      dataGridViewColumn14.Visible = true;
      dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn14.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn14);
      DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
      dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn15.Width = 80 /*0x50*/;
      dataGridViewColumn15.HeaderText = str14;
      dataGridViewColumn15.Name = "Bottom Edge";
      dataGridViewColumn15.ReadOnly = false;
      dataGridViewColumn15.Visible = true;
      dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn15.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_Material3D) this).\u0001.Columns.Add(dataGridViewColumn15);
    }
    ((F_Material3D) this).\u0001.RowHeadersVisible = false;
    ((F_Material3D) this).\u0001.AllowUserToAddRows = false;
    ((F_Material3D) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MaterialRect2D) this).SendToCadEntities.Clear();
    ((F_MaterialRect2D) this).SendToCadEntities = new List<Entity>();
    ((F_MaterialRect3D) this).\u0001 = new Timer();
    this.\u0001();
    if (!((F_MarbleCam3DEngrave) this).\u0003.Checked & !((F_MarbleCam3DEngrave) this).\u0001.Checked & !((F_MarbleCam3DEngrave) this).\u0002.Checked)
      ((F_MarbleCam3DEngrave) this).\u0002.Checked = true;
    this.LoadLanguage();
    ((F_MaterialRect3D) this).PropertiesForm.Result = DialogResult.None;
    ((F_MaterialRect3D) this).PropertiesForm.Inited = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MaterialRect3D) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MaterialRect3D) this).PropertiesForm.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_MaterialRect2D.Captions.Count < 100)
        return;
      this.Text = F_MaterialRect2D.Captions[0];
      ((F_Material3D) this).\u0001.Text = F_MaterialRect2D.Captions[2];
      ((F_MarbleCam3DEngrave) this).\u0003.Text = F_MaterialRect2D.Captions[2];
      ((F_Material3D) this).\u0004.Text = F_MaterialRect2D.Captions[7];
      ((F_Material3D) this).\u0003.Text = F_MaterialRect2D.Captions[8];
      ((F_Material3D) this).\u0002.Text = F_MaterialRect2D.Captions[10];
      ((F_Material3D) this).\u0001.Text = F_MaterialRect2D.Captions[11];
      ((F_MarbleCam3DEngrave) this).\u0003.Text = F_MaterialRect2D.Captions[12];
      ((F_MarbleCam3DEngrave) this).\u0002.Text = F_MaterialRect2D.Captions[13];
      ((F_MarbleCam3DEngrave) this).\u0001.Text = F_MaterialRect2D.Captions[14];
      ((F_Material3D) this).\u0002.Text = F_MaterialRect2D.Captions[15];
      ((F_Material3D) this).\u0001.Text = F_MaterialRect2D.Captions[16 /*0x10*/];
      ((F_MarbleCam3DEngrave) this).chk_preview.Text = F_MaterialRect2D.Captions[17];
      ((F_Material3D) this).\u0006.Text = F_MaterialRect2D.Captions[18];
      ((F_Material3D) this).\u0005.Text = F_MaterialRect2D.Captions[19];
      ((F_Material3D) this).\u0008.Text = F_MaterialRect2D.Captions[20];
      ((F_Material3D) this).\u0007.Text = F_MaterialRect2D.Captions[21];
      ((F_Material3D) this).\u0004.Text = F_MaterialRect2D.Captions[22];
      ((F_Material3D) this).\u0005.Text = F_MaterialRect2D.Captions[23];
      ((F_Material3D) this).\u0006.Text = F_MaterialRect2D.Captions[29];
      ((F_MarbleCam3DEngrave) this).\u0007.Text = F_MaterialRect2D.Captions[31 /*0x1F*/];
      ((F_Material3D) this).\u0001.Text = F_MaterialRect2D.Captions[32 /*0x20*/];
      ((F_Material3D) this).\u0002.Text = F_MaterialRect2D.Captions[52];
      ((F_Material3D) this).\u0003.Text = F_MaterialRect2D.Captions[28];
      ((F_MarbleCam3DEngrave) this).\u0008.Text = F_MaterialRect2D.Captions[29];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  private void \u0001()
  {
    ((F_MaterialRect3D) this).\u0001.Enabled = false;
    ((F_Material3D) this).\u0001.Rows.Clear();
    for (int index = 0; index <= ((F_MaterialRect2D) this).Parts.Count - 1; ++index)
    {
      buNestingPart buNestingPart = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_MaterialRect2D) this).Parts[index]);
      Image Img = (Image) new Bitmap(100, 100);
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeLeft)
        str1 = ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeLeftThickness.ToString();
      if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeRight)
        str2 = ((buEyeBaseVer5.Apps.ProfileOperationCircle) buNestingPart).EdgeRightThickness.ToString();
      if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeTop)
        str3 = ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EdgeTopThickness.ToString();
      if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeBottom)
        str4 = ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EdgeBottomThickness.ToString();
      ((F_MarbleCoordinatesV2) this).PartPointsToImage(((F_MaterialRect2D) this).Parts[index], ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetHeight, ref Img);
      DataGridViewRowCollection rows = ((F_Material3D) this).\u0001.Rows;
      bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).Enable;
      string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).PartData).Name;
      double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).PartData).Width;
      double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).PartData).Height;
      int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).PartData).Quantity;
      int nested = ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).Nested;
      int remain = ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).Remain;
      double precutWidth = ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).PrecutWidth;
      double precutHeight = ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).PrecutHeight;
      object[] objArray = \u0007.\u0001.\u0001(remain, quantity, precutHeight, precutWidth, (F_PanelCutPartList) this, str4, str2, width, Img, height, str3, str1, enable, nested, name, index + 1);
      rows.Add(objArray);
      DataGridViewRow row = ((F_Material3D) this).\u0001.Rows[index];
      ((F_Material3D) this).\u0001.Rows[index].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetHeight;
      row.DefaultCellStyle.ForeColor = Color.Black;
      if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).Remain <= 0)
        row.DefaultCellStyle.ForeColor = Color.Red;
    }
    ((F_MaterialRect3D) this).PropertiesForm.Inited = true;
    ((F_MarbleCoordinatesV2) this).\u0002();
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    string str1 = "";
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
      str1 = ((System.Windows.Forms.Control) obj0).Name;
    if (obj0.GetType() == typeof (ToolStripMenuItem))
      str1 = ((ToolStripItem) obj0).Name;
    if (str1 == ((F_Material3D) this).\u0004.Name)
    {
      F_NestRectPartAdd fNestRectPartAdd = (F_NestRectPartAdd) new F_SortingSettings();
      ((F_NestSheetPartList) fNestRectPartAdd).ShowItemNo = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).ShowPartItemNoColumb;
      ((F_NestSheetPartList) fNestRectPartAdd).FormCloseMode = FormCloseModeType.Dispose;
      ((F_SortingSettings) fNestRectPartAdd).Init();
      fNestRectPartAdd.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fNestRectPartAdd.ShowDialog();
      if (((F_NestSheetPartList) fNestRectPartAdd).Result == DialogResult.OK)
      {
        buNestingPart buNestingPart = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_NestSheetPartList) fNestRectPartAdd).Part);
        ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_MaterialRect2D) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).ID);
        ((F_MaterialRect2D) this).Parts.Add(buNestingPart);
        Image Img = (Image) null;
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";
        if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeLeft)
          str2 = ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeLeftThickness.ToString();
        if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeRight)
          str3 = ((buEyeBaseVer5.Apps.ProfileOperationCircle) buNestingPart).EdgeRightThickness.ToString();
        if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeTop)
          str4 = ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EdgeTopThickness.ToString();
        if (((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).EdgeBottom)
          str5 = ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EdgeBottomThickness.ToString();
        ((F_MarbleCoordinatesV2) this).PartPointsToImage(((F_NestSheetPartList) fNestRectPartAdd).Part, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetHeight, ref Img);
        DataGridViewRowCollection rows = ((F_Material3D) this).\u0001.Rows;
        int count = ((F_MaterialRect2D) this).Parts.Count;
        bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Enable;
        string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Name;
        double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Width;
        double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Height;
        int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Quantity;
        int nested = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Nested;
        int remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Remain;
        double precutWidth = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PrecutWidth;
        double precutHeight = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PrecutHeight;
        object[] objArray = \u0007.\u0001.\u0001(remain, quantity, precutHeight, precutWidth, (F_PanelCutPartList) this, str5, str3, width, Img, height, str4, str2, enable, nested, name, count);
        rows.Add(objArray);
        ((F_Material3D) this).\u0001.Rows[((F_Material3D) this).\u0001.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
        ((F_Material3D) this).\u0001.Rows[((F_Material3D) this).\u0001.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_MaterialRect3D) this).Settings).Draw).GridPartSheetHeight;
      }
    }
    if (str1 == ((F_Material3D) this).\u0003.Name)
    {
      if (((F_MarbleCam3DEngrave) this).\u0003.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
      {
        ((F_MaterialRect2D) this).Parts.Clear();
        ((F_Material3D) this).\u0001.Rows.Clear();
      }
      if (((F_MarbleCam3DEngrave) this).\u0001.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
      {
        for (int index = ((F_Material3D) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          if (Convert.ToBoolean(((F_Material3D) this).\u0001.Rows[index].Cells[1].Value))
          {
            ((F_Material3D) this).\u0001.Rows.RemoveAt(index);
            ((F_MaterialRect2D) this).Parts.RemoveAt(index);
          }
        }
      }
      if (!((F_MarbleCam3DEngrave) this).\u0002.Checked || buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) != DialogResult.Yes || !(((F_MaterialRect3D) this).\u0002 >= 0 & ((F_MaterialRect3D) this).\u0002 <= ((F_MaterialRect2D) this).Parts.Count - 1))
        return;
      ((F_Material3D) this).\u0001.Rows.RemoveAt(((F_MaterialRect3D) this).\u0002);
      ((F_MaterialRect2D) this).Parts.RemoveAt(((F_MaterialRect3D) this).\u0002);
    }
    else
    {
      if (str1 == ((F_Material3D) this).\u0002.Name && ((F_MaterialRect3D) this).\u0002 >= 0 & ((F_MaterialRect3D) this).\u0002 <= ((F_MaterialRect2D) this).Parts.Count - 1)
      {
        ((F_Material3D) this).\u0001.Rows[((F_MaterialRect3D) this).\u0002].Cells[7].Value = (object) 0;
        ((F_Material3D) this).\u0001.Rows[((F_MaterialRect3D) this).\u0002].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PartData).Quantity;
        ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).Nested = 0;
        ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[((F_MaterialRect3D) this).\u0002]).PartData).Quantity;
        ((F_Material3D) this).\u0001.Rows[((F_MaterialRect3D) this).\u0002].DefaultCellStyle.ForeColor = Color.Black;
      }
      if (str1 == ((F_Material3D) this).\u0001.Name)
      {
        for (int index = 0; index <= ((F_MaterialRect2D) this).Parts.Count - 1; ++index)
        {
          ((F_Material3D) this).\u0001.Rows[index].Cells[7].Value = (object) 0;
          ((F_Material3D) this).\u0001.Rows[index].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Quantity;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Nested = 0;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Quantity;
          ((F_Material3D) this).\u0001.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
        }
      }
      if (str1 == ((F_MarbleCam3DEngrave) this).\u0007.Name)
      {
        ((F_MaterialRect2D) this).SendToCadEntities.Clear();
        double dy = 0.0;
        double dx = 0.0;
        double num1 = double.MinValue;
        int num2 = 0;
        int num3 = 0;
        for (int index = 0; index <= ((F_MaterialRect2D) this).Parts.Count - 1; ++index)
        {
          if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Enable && ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Width > num1)
            num1 = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Width;
        }
        for (int index1 = 0; index1 <= ((F_MaterialRect2D) this).Parts.Count - 1; ++index1)
        {
          if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index1]).Enable)
          {
            List<Entity> copiedEntity = new List<Entity>();
            buDiametricDim.Copy(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[index1]).EntitiesGroup, ref copiedEntity);
            for (int index2 = 0; index2 <= copiedEntity.Count - 1; ++index2)
            {
              copiedEntity[index2].Translate(dx, dy);
              ((F_MaterialRect2D) this).SendToCadEntities.Add(copiedEntity[index2]);
            }
            dy = dy + ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index1]).PartData).Height + 20.0;
            ++num2;
            if (num2 >= 10)
            {
              num2 = 0;
              ++num3;
              dy = 0.0;
              dx = num1 * (double) num3;
            }
          }
        }
        if (((F_MaterialRect2D) this).SendToCadEntities.Count > 0)
        {
          ((F_MaterialRect2D) this).SendToCad = true;
          this.Visible = false;
          ((F_MaterialRect3D) this).PropertiesForm.Result = DialogResult.OK;
        }
      }
      if (str1 == ((F_Material3D) this).\u0004.Name)
      {
        for (int index = ((F_Material3D) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_Material3D) this).\u0001.Rows[index].Cells[1].Value = (object) true;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Enable = true;
        }
      }
      if (str1 == ((F_Material3D) this).\u0005.Name)
      {
        for (int index = ((F_Material3D) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_Material3D) this).\u0001.Rows[index].Cells[1].Value = (object) false;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Enable = false;
        }
      }
      if (str1 == ((F_Material3D) this).\u0006.Name && ((F_MaterialRect2D) this).Parts.Count > 0)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_MaterialRect2D) this).SaveFileFolder;
        saveFileDialog.Filter = ((F_MaterialRect3D) this).SaveFileExtender;
        saveFileDialog.FilterIndex = ((F_MaterialRect2D) this).SaveFileExtensionIndex;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          ((F_MaterialRect2D) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
          if (fileInfo.Extension == ".dxf")
          {
            for (int index = 0; index <= ((F_MaterialRect2D) this).Parts.Count - 1; ++index)
            {
              if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).Enable)
              {
                string str6 = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Name.Trim();
                int num;
                if (str6.Length == 0)
                {
                  num = index + 1;
                  str6 = "Part" + num.ToString();
                }
                string[] strArray = new string[10];
                strArray[0] = buFile5.bunesting.GetPath(saveFileDialog.FileName);
                strArray[1] = "\\";
                strArray[2] = buFile5.bunesting.getFileNameWithoutExtension(saveFileDialog.FileName);
                strArray[3] = "_";
                num = index + 1;
                strArray[4] = num.ToString();
                strArray[5] = "_";
                strArray[6] = str6;
                strArray[7] = "_";
                strArray[8] = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_MaterialRect2D) this).Parts[index]).PartData).Quantity.ToString();
                strArray[9] = fileInfo.Extension;
                string FileName = string.Concat(strArray);
                List<Entity> copiedEntity = new List<Entity>();
                buDiametricDim.Copy(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_MaterialRect2D) this).Parts[index]).EntitiesGroup, ref copiedEntity);
                cParameter5.SaveDxfDwg(copiedEntity, FileName);
              }
            }
          }
        }
      }
      if (str1 == ((F_Material3D) this).\u0005.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_MaterialRect2D) this).SaveFileFolder;
        saveFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_MaterialRect2D) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
          new buVector5().SaveNesting(saveFileDialog.FileName, ((F_MaterialRect2D) this).Parts, new List<buNestingSheet>(), ((F_MaterialRect3D) this).Settings);
        }
      }
      if (str1 == ((F_Material3D) this).\u0006.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((F_MaterialRect2D) this).SaveFileFolder;
        openFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_MaterialRect2D) this).SaveFileFolder = buFile5.bunesting.GetPath(openFileDialog.FileName);
          buFile5.bunesting bunesting = (buFile5.bunesting) new buVector5();
          List<buNestingSheet> Sheets = new List<buNestingSheet>();
          ((buVector5) bunesting).OpenNesting(openFileDialog.FileName, ref ((F_MaterialRect2D) this).Parts, ref Sheets);
          this.Init(((F_MaterialRect2D) this).\u0001.SelectedIndex);
        }
      }
      if (str1 == ((F_Material3D) this).\u0007.Name)
      {
        this.Visible = false;
        ((F_MaterialRect3D) this).PropertiesForm.Result = DialogResult.Cancel;
      }
      if (!(str1 == ((F_Material3D) this).\u0008.Name))
        return;
      this.Visible = false;
      ((F_MaterialRect3D) this).PropertiesForm.Result = DialogResult.OK;
    }
  }
}
