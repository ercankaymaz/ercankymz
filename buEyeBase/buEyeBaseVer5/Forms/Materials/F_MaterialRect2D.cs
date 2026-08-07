// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Materials.F_MaterialRect2D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Events;
using buEyeBaseVer5.Forms.Material;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.Forms.Password;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Materials;

public class F_MaterialRect2D : Form
{
  public bool AddPartFromFileExtenderAsCsvType;
  public bool SendToCad;
  public int AddPartFromFileExtensionIndex;
  public int SaveFileExtensionIndex;
  public string AddPartFromFileFolder;
  public string SaveFileFolder;
  public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile;
  public nestPartRotateType PartRotationDefault;
  public List<buNestingPart> Parts;
  public List<Entity> SendToCadEntities;
  public static List<string> Captions;
  public static List<string> CaptionGrid;
  internal IContainer \u0001;
  internal TabControl \u0001;
  internal Panel \u0001;
  internal ImageList \u0001;

  [CompilerGenerated]
  [SpecialName]
  public void add_EditDxf(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PanelCutPartList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PanelCutPartList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_EditDxf(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_PanelCutPartList) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_PanelCutPartList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init(buEyeBaseVer5.Apps.ProfileItem Item, bool boxprofile = false)
  {
    ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
    if (((F_PanelCutPartList) this).PropertiesForm.Height > 10)
      this.Height = ((F_PanelCutPartList) this).PropertiesForm.Height;
    if (((F_PanelCutPartList) this).PropertiesForm.Width > 10)
      this.Width = ((F_PanelCutPartList) this).PropertiesForm.Width;
    this.TopMost = ((F_PanelCutPartList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_PanelCutPartList) this).PropertiesForm.FormPosition;
    ((F_PanelCutPartList) this).\u0001 = Item;
    ((F_PanelCutPartList) this).BoxProfile = boxprofile;
    if (((F_PanelCutPartList) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = true;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_PanelCutPartList) this).\u0001);
      ((F_PanelCutPartList) this).\u0001.Dock = DockStyle.Fill;
      ((F_PanelCutSheetList) this).\u0004.Controls.Add((Control) ((F_PanelCutPartList) this).\u0001);
    }
    ((F_PanelCutPartList) this).\u0001.ActiveViewport.ViewCubeIcon.Visible = false;
    if (!((F_PanelCutPartList) this).RigthProfile)
      ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = LeftRightType.Left;
    ((F_PanelCutSheetList) this).\u0001.Enabled = ((F_PanelCutPartList) this).RigthProfile;
    ((F_PanelCutSheetList) this).grid_files.AllowUserToAddRows = false;
    ((F_PanelCutSheetList) this).grid_files.AllowUserToDeleteRows = false;
    ((F_PanelCutSheetList) this).grid_files.AllowUserToResizeRows = false;
    ((F_PanelCutSheetList) this).grid_files.RowHeadersVisible = false;
    ((F_PanelCutSheetList) this).grid_files.Columns.Clear();
    ((F_PanelCutSheetList) this).grid_files.Rows.Clear();
    ((F_PanelCutSheetList) this).grid_files.Columns.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 60;
    dataGridViewColumn1.HeaderText = "No";
    dataGridViewColumn1.Name = "No";
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_PanelCutSheetList) this).grid_files.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = 250;
    dataGridViewColumn2.HeaderText = "FileName";
    dataGridViewColumn2.Name = "FileName";
    dataGridViewColumn2.ReadOnly = true;
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_PanelCutSheetList) this).grid_files.Columns.Add(dataGridViewColumn2);
    ((F_PanelCutSheetList) this).\u0007.ReadOnly = ((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileAddWidthHeightReadOnly;
    ((F_PanelCutSheetList) this).\u0006.ReadOnly = ((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileAddWidthHeightReadOnly;
    ((F_PanelCutPartList) this).\u0002.Value = (Decimal) ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).MaterialTranspancy;
    ((F_PanelCutSheetList) this).\u0017.BackColor = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileColor;
    ((F_PanelCutSheetList) this).\u0016.BackColor = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).SupportBlockZColor;
    ((F_PanelCutPartList) this).\u0002.Text = nameof (Item);
    ((F_PanelCutSheetList) this).\u0002.Checked = ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileKeepRatio;
    if (Item != null)
    {
      ((F_PanelCutSheetList) this).\u0014.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).MultiplyProfile).ProfileMultiplyCount;
      ((F_PanelCutSheetList) this).\u0013.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).MultiplyProfile).ProfileMultiplySpace;
      ((F_PanelCutSheetList) this).\u0003.Checked = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).MultiplyProfile).ProfileMultiplyMirror;
      ((F_PanelCutSheetList) this).\u0004.Checked = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).MultiplyProfile).ProfileMultiplyEnable;
    }
    ((F_PanelCutPartList) this).\u0002.Items.Clear();
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 100);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 500);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 800);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 1000);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 1200);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 1500);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 2000);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 3000);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 4000);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 5000);
    ((F_PanelCutPartList) this).\u0002.Items.Add((object) 6000);
    ((F_PanelCutPartList) this).\u0002.Text = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileLength.ToString();
    ((F_PanelCutPartList) this).\u0001.Items.Clear();
    ((F_PanelCutSheetList) this).\u0001.Checked = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).TextureEnable;
    for (int index = 0; index <= ((F_PanelCutPartList) this).Materials.Count - 1; ++index)
      ((F_PanelCutPartList) this).\u0001.Items.Add((object) ((F_PanelCutPartList) this).Materials[index].Name);
    if (((F_PanelCutPartList) this).MaterialIndex >= 0 & ((F_PanelCutPartList) this).MaterialIndex <= ((F_PanelCutPartList) this).\u0001.Items.Count - 1)
      ((F_PanelCutPartList) this).\u0001.SelectedIndex = ((F_PanelCutPartList) this).MaterialIndex;
    ((F_PanelCutSheetList) this).\u0003.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height;
    ((F_PanelCutSheetList) this).\u0005.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height;
    ((F_PanelCutSheetList) this).\u0004.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight;
    ((F_PanelCutSheetList) this).\u0010.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Width;
    ((F_PanelCutSheetList) this).\u000E.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width;
    ((F_PanelCutSheetList) this).\u000F.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth;
    ((F_PanelCutSheetList) this).\u0008.Value = (Decimal) ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxClamper;
    ((F_PanelCutSheetList) this).\u0012.Value = (Decimal) ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).LeftAngle;
    ((F_PanelCutSheetList) this).\u0011.Value = (Decimal) ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).RigthAngle;
    ((EntitiesCopySettings) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).AnalyseSettings).SmallGapMaxDistance = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).GapConnectionForProfile;
    ((EntitiesCopySettings) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).AnalyseSettings).SmallGapMinDistance = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileSortResolution;
    if (((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType == LeftRightType.Left)
    {
      ((F_PanelCutSheetList) this).\u0002.Checked = true;
      ((F_PanelCutSheetList) this).\u0001.Checked = false;
    }
    else
    {
      ((F_PanelCutSheetList) this).\u0002.Checked = false;
      ((F_PanelCutSheetList) this).\u0001.Checked = true;
    }
    ((F_PanelCutPartList) this).\u0002 = new List<string>();
    List<string> Files = new List<string>();
    buFile.GetFilesInDirectory(((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles, ".dxf", ref Files);
    for (int index = 0; index <= Files.Count - 1; ++index)
      ((F_PanelCutPartList) this).\u0002.Add(Files[index]);
    Files = new List<string>();
    buFile.GetFilesInDirectory(((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles, ".bucad", ref Files);
    for (int index = 0; index <= Files.Count - 1; ++index)
      ((F_PanelCutPartList) this).\u0002.Add(Files[index]);
    ((F_PanelCutSheetList) this).\u0012.Value = 0M;
    ((F_PanelCutSheetList) this).\u0011.Value = 0M;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileAdd) this);
    if (Item != null)
    {
      ((F_PanelCutSheetList) this).\u0003.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY1FrontHeight;
      ((F_PanelCutSheetList) this).\u0005.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY2BackHeight;
      ((F_PanelCutSheetList) this).\u0004.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockZHeight;
      ((F_PanelCutSheetList) this).\u0010.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY2BackHeight;
      ((F_PanelCutSheetList) this).\u000E.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY2BackWidth;
      ((F_PanelCutSheetList) this).\u000F.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockZWidth;
      ((F_PanelCutSheetList) this).\u0008.Value = (Decimal) ((buEyeBaseVer5.Apps.ProfileSettings) Item).MaxClamperNumber;
      ((F_PanelCutPartList) this).\u0002.Text = ((buEyeBaseVer5.Apps.ProfileSettings) Item).ItemName;
      ((F_PanelCutPartList) this).\u0002.Text = ((buEyeBaseVer5.Apps.ProfileSettings) Item).Length.ToString();
      ((F_PanelCutSheetList) this).\u0017.BackColor = ((buEyeBaseVer5.Apps.ProfileSettings) Item).colorProfile;
      ((F_PanelCutSheetList) this).\u0016.BackColor = ((buEyeBaseVer5.Apps.ProfileSettings) Item).colorSupportBlock;
      ((F_PanelCutSheetList) this).\u0012.Value = (Decimal) ((buEyeBaseVer5.Apps.ProfileSettings) Item).LeftAngle;
      ((F_PanelCutSheetList) this).\u0011.Value = (Decimal) ((buEyeBaseVer5.Apps.ProfileSettings) Item).RightAngle;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY1FrontHeight;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY2BackHeight;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockZHeight;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Width = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY1FrontWidth;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockY2BackWidth;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) Item).SupportBlock).SupportBlockZWidth;
      ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).LeftAngle = ((buEyeBaseVer5.Apps.ProfileSettings) Item).LeftAngle;
      ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).RigthAngle = ((buEyeBaseVer5.Apps.ProfileSettings) Item).RightAngle;
      ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = ((buEyeBaseVer5.Apps.ProfileSettings) Item).XReferanceLocation;
      if (((buEyeBaseVer5.Apps.ProfileSettings) Item).XReferanceLocation == LeftRightType.Left)
      {
        ((F_PanelCutSheetList) this).\u0002.Checked = true;
        ((F_PanelCutSheetList) this).\u0001.Checked = false;
      }
      else
      {
        ((F_PanelCutSheetList) this).\u0002.Checked = false;
        ((F_PanelCutSheetList) this).\u0001.Checked = true;
      }
    }
    ((F_PanelCutPartList) this).PropertiesForm.Result = DialogResult.None;
    ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
    if (Item != null)
    {
      if (((F_PanelCutPartList) this).\u0001 == null)
      {
        ((F_PanelCutPartList) this).\u0001 = new System.Windows.Forms.Timer();
        ((F_PanelCutPartList) this).\u0001.Interval = 20;
        ((F_PanelCutPartList) this).\u0001.Tick += new EventHandler(this.Init_Tick);
      }
      ((F_PanelCutPartList) this).\u0001.Enabled = true;
    }
    else
    {
      if (!boxprofile)
        return;
      if (((F_PanelCutPartList) this).\u0001 == null)
      {
        ((F_PanelCutPartList) this).\u0001 = new System.Windows.Forms.Timer();
        ((F_PanelCutPartList) this).\u0001.Interval = 20;
        ((F_PanelCutPartList) this).\u0001.Tick += new EventHandler(this.Init_Tick);
      }
      ((F_PanelCutPartList) this).\u0001.Enabled = true;
    }
  }

  public void Init_Tick(object sender, EventArgs e)
  {
    if (!((F_PanelCutPartList) this).BoxProfile)
    {
      if (!((F_PanelCutPartList) this).\u0001.IsHandleCreated)
        return;
      ((F_PanelCutPartList) this).\u0001.Enabled = false;
      for (int index = 0; index <= ((F_PanelCutSheetList) this).grid_files.Rows.Count - 1; ++index)
      {
        if (((F_PanelCutSheetList) this).grid_files.Rows[index].Cells[1].Value.ToString() == ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).FileName)
        {
          ((F_PanelCutSheetList) this).grid_files.Rows[index].Selected = true;
          this.\u0001((object) null, new DataGridViewCellEventArgs(1, index));
        }
      }
      if (((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).ProfileTraformations.Count <= 0)
        return;
      List<string> stringList = new List<string>();
      for (int index = 0; index <= ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).ProfileTraformations.Count - 1; ++index)
        stringList.Add(((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).ProfileTraformations[index].ToLower());
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).ProfileTraformations.Clear();
      ((F_PanelCutPartList) this).\u0001.Clear();
      for (int index = 0; index <= stringList.Count - 1; ++index)
      {
        if (stringList[index].ToLower() == "rotateleft")
          this.\u0001((object) ((F_PanelCutPartList) this).\u0004, (EventArgs) null);
        if (stringList[index].ToLower() == "rotateright")
          this.\u0001((object) ((F_PanelCutPartList) this).\u0005, (EventArgs) null);
        if (stringList[index].ToLower() == "mirrorhorizontal")
          this.\u0001((object) ((F_PanelCutPartList) this).\u0006, (EventArgs) null);
        if (stringList[index].ToLower() == "mirrorvertical")
          this.\u0001((object) ((F_PanelCutPartList) this).\u0007, (EventArgs) null);
      }
      for (int index = 0; index <= ((F_PanelCutPartList) this).\u0001.Count - 1; ++index)
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).ProfileTraformations.Add(((F_PanelCutPartList) this).\u0001[index].ToLower());
    }
    else
    {
      ((F_PanelCutPartList) this).\u0001.Enabled = false;
      this.\u0001((object) ((F_PanelCutSheetList) this).\u000E, (EventArgs) null);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_PanelCutPartList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_PanelCutPartList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_PanelCutPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_PanelCutPartList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    this.\u0004(obj0, obj1);
    if (control2.Name == ((F_PanelCutPartList) this).\u0001.Name)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles;
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles = folderBrowserDialog.SelectedPath;
      this.Init((buEyeBaseVer5.Apps.ProfileItem) null);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_PanelCutSheetList) this).\u000F.Name && ((F_PanelCutPartList) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutPartList) this).\u0001((object) $"{((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles}\\{((F_PanelCutPartList) this).\u0001}", (object) null);
    }
    if (control2.Name == ((F_PanelCutSheetList) this).\u0011.Name)
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = "Anaylse";
      classViewerDialog.Value = (object) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).AnalyseSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).AnalyseSettings = (AnalyseEntitiesSetting) new PlaneAngle((AnalyseEntitiesSetting) classViewerDialog.Value);
    }
    if (control2.Name == ((F_PanelCutSheetList) this).\u0012.Name)
    {
      SortResolutionSet sortResolutionSet = (SortResolutionSet) new SelectionEntity();
      ((SortbuMostClosedResult) sortResolutionSet).GapDistance = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).GapConnectionForProfile;
      ((SortbuMostClosedResult) sortResolutionSet).SortResolution = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileSortResolution;
      ((SortbuMostClosedResult) sortResolutionSet).IntersectionRules = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).IntersectionRules;
      ((SortbuMostClosedResult) sortResolutionSet).ConnectSmallGap = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ConnectSmallGap;
      ((SortbuMostClosedResult) sortResolutionSet).MinProfileFilterLength = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).MinProfileFilterLength;
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = "Sort";
      classViewerDialog.Value = (object) sortResolutionSet;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).GapConnectionForProfile = ((SortbuMostClosedResult) classViewerDialog.Value).GapDistance;
        ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileSortResolution = ((SortbuMostClosedResult) classViewerDialog.Value).SortResolution;
        ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).IntersectionRules = ((SortbuMostClosedResult) classViewerDialog.Value).IntersectionRules;
        ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ConnectSmallGap = ((SortbuMostClosedResult) classViewerDialog.Value).ConnectSmallGap;
        ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).MinProfileFilterLength = ((SortbuMostClosedResult) classViewerDialog.Value).MinProfileFilterLength;
        ((EntitiesCopySettings) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).AnalyseSettings).SmallGapMaxDistance = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).GapConnectionForProfile;
        ((EntitiesCopySettings) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).AnalyseSettings).SmallGapMinDistance = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileSortResolution;
      }
    }
    if (control2.Name == ((F_PanelCutSheetList) this).\u0010.Name)
    {
      AnalyseEntitiesResult Result = (AnalyseEntitiesResult) new Pnt6DSimMove();
      buCall.\u0001.AnalyseEntities(((F_PanelCutPartList) this).\u0001.Entities.ToList<Entity>(), ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).AnalyseSettings, ref Result);
      if (((MachineDef) Result).ErrorList.Count > 0)
      {
        F_Preview fPreview = (F_Preview) new F_TuftingSetProps();
        CreateModelProperties Properties = (CreateModelProperties) new ShapeEdit();
        ((MaterialBase5) Properties).CoordinateSystemIconVisible = false;
        ((MaterialBase5) Properties).ViewCubeIconVisible = false;
        ((MaterialBase5) Properties).OrigineCaptionVisible = false;
        ((MaterialBase5) Properties).ToolBorVisible = false;
        ((ViewportDrawOptions) Properties).BottomColor = Color.Gray;
        ((ViewportDrawOptions) Properties).MiddleColor = Color.Gray;
        ((ViewportDrawOptions) Properties).TopColor = Color.Gray;
        ((F_TuftingExchange) fPreview).viewportLayout = ((DrawingFinisedEvent) buCall.\u0001).CreateModelControl("", Properties);
        for (int index = 0; index <= ((F_PanelCutPartList) this).\u0001.Entities.Count - 1; ++index)
        {
          Entity copiedEntity = (Entity) null;
          buRadialDim.Copy(((F_PanelCutPartList) this).\u0001.Entities[index], ref copiedEntity);
          copiedEntity.LayerName = "Default";
          ((F_TuftingExchange) fPreview).viewportLayout.Entities.Add(copiedEntity);
        }
        DialogBoxList dialogBoxList = new DialogBoxList();
        for (int index = 0; index <= ((MachineDef) Result).ErrorList.Count - 1; ++index)
        {
          if (((MachineDefPart) ((MachineDef) Result).ErrorList[index]).IndexEntity >= 0 & ((MachineDefPart) ((MachineDef) Result).ErrorList[index]).IndexEntity <= ((F_TuftingExchange) fPreview).viewportLayout.Entities.Count - 1)
          {
            ((F_TuftingExchange) fPreview).viewportLayout.Entities[((MachineDefPart) ((MachineDef) Result).ErrorList[index]).IndexEntity].Selected = true;
            buEntity copiedEntity = (buEntity) null;
            buAngularDim.Copy(((F_TuftingExchange) fPreview).viewportLayout.Entities[((MachineDefPart) ((MachineDef) Result).ErrorList[index]).IndexEntity], ref copiedEntity);
            string str1 = ((MachineDefPart) ((MachineDef) Result).ErrorList[index]).ErrorType.ToString();
            if (((MachineDefPart) ((MachineDef) Result).ErrorList[index]).ErrorType == AnalyseEntitiesResultErrorType.SmallLength)
              str1 = $"{str1} = {((ICurve) ((F_TuftingExchange) fPreview).viewportLayout.Entities[((MachineDefPart) ((MachineDef) Result).ErrorList[index]).IndexEntity]).Length().ToString("f5")}";
            string str2 = $"{str1} - [ {((MachineDefPart) ((MachineDef) Result).ErrorList[index]).IndexEntity.ToString()} ] {copiedEntity.ToString()}";
            dialogBoxList.Items.Add(str2);
          }
          new devDept.Eyeshot.Entities.Text(Plane.XY, ((MachineDefPart) ((MachineDef) Result).ErrorList[index]).ErrorType.ToString(), 0.1).Translate(((MachineDefPart) ((MachineDef) Result).ErrorList[index]).pntError.X, ((MachineDefPart) ((MachineDef) Result).ErrorList[index]).pntError.Y, ((MachineDefPart) ((MachineDef) Result).ErrorList[index]).pntError.Z);
          devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(((MachineDefPart) ((MachineDef) Result).ErrorList[index]).pntError.X, ((MachineDefPart) ((MachineDef) Result).ErrorList[index]).pntError.Y, ((MachineDefPart) ((MachineDef) Result).ErrorList[index]).pntError.Z);
          point.LineWeight = 5f;
          point.Color = Color.Red;
          if (((MachineDefPart) ((MachineDef) Result).ErrorList[index]).ErrorType == AnalyseEntitiesResultErrorType.SameAvailable)
            point.Color = Color.Blue;
          if (((MachineDefPart) ((MachineDef) Result).ErrorList[index]).ErrorType == AnalyseEntitiesResultErrorType.SmallGap)
            point.Color = Color.Lime;
          point.ColorMethod = colorMethodType.byEntity;
          point.LineWeightMethod = colorMethodType.byEntity;
          ((F_TuftingExchange) fPreview).viewportLayout.Entities.Add((Entity) point);
        }
        dialogBoxList.Init(buLangTranslate.preDef.Error, 0);
        int num = (int) dialogBoxList.ShowDialog();
        fPreview.Controls.Add((Control) ((F_TuftingExchange) fPreview).viewportLayout);
        ((F_TuftingSetProps) fPreview).Init(viewType.Top, true, false);
        fPreview.Show();
      }
      else
        buNumeric5.MessageBoxInfo(AppLanguage.CadCamMessages[89]);
    }
    if (control2.Name == ((F_PanelCutSheetList) this).\u000E.Name)
    {
      if (((F_PanelCutPartList) this).FrmNewProfile == null)
        ((F_PanelCutPartList) this).FrmNewProfile = (F_NewProfile) new F_MaterialsList();
      ((F_PasswordV1) ((F_PanelCutPartList) this).FrmNewProfile).txt_name.Text = AppLanguage.CadCamDynamic[112 /*0x70*/];
      ((F_PasswordV1) ((F_PanelCutPartList) this).FrmNewProfile).cmb_length.Text = ((F_PanelCutPartList) this).\u0002.Text;
      if (((F_PanelCutPartList) this).\u0001 != null)
      {
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_multiplycount.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).MultiplyProfile).ProfileMultiplyCount;
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_multiplyspace.Value = (Decimal) ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).MultiplyProfile).ProfileMultiplySpace;
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).chk_multilymirror.Checked = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).MultiplyProfile).ProfileMultiplyMirror;
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).chk_multiplyprofile.Checked = ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).\u0001).MultiplyProfile).ProfileMultiplyEnable;
      }
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky1H.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height;
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky2H.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height;
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblockzH.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight;
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky1W.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Width;
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky2W.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width;
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblockzW.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth;
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_leftangle.Value = (Decimal) ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).LeftAngle;
      ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_rightangle.Value = (Decimal) ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).RigthAngle;
      if (((F_PanelCutSheetList) this).\u0002.Checked)
        ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = LeftRightType.Left;
      else
        ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = LeftRightType.Right;
      if (((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType == LeftRightType.Left)
      {
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).radio_leftholder.Checked = true;
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).radio_rightholder.Checked = false;
      }
      else
      {
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).radio_leftholder.Checked = false;
        ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).radio_rightholder.Checked = true;
      }
      ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemHeight = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).NewProfileHeight;
      ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemWidth = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).NewProfileWidth;
      ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemThickness = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).NewProfileThickness;
      ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).RightProfile = ((F_PanelCutPartList) this).RigthProfile;
      ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).MaxClamper = (int) ((F_PanelCutSheetList) this).\u0008.Value;
      ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).FormCloseMode = FormCloseModeType.Invisible;
      ((F_MaterialRect3D) ((F_PanelCutPartList) this).FrmNewProfile).Init();
      ((F_PanelCutPartList) this).FrmNewProfile.StartPosition = FormStartPosition.CenterParent;
      int num = (int) ((F_PanelCutPartList) this).FrmNewProfile.ShowDialog();
      if (((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).Result == DialogResult.OK)
      {
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileType = ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).SelectedType;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).NewProfileHeight = ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemHeight;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).NewProfileWidth = ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemWidth;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).NewProfileThickness = ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemThickness;
        ((F_PanelCutPartList) this).\u0002.Text = ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemName;
        if (((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemLength.Length > 0)
          ((F_PanelCutPartList) this).\u0002.Text = ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).ItemLength;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky1H.Value;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky2H.Value;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblockzH.Value;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Width = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky1W.Value;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblocky2W.Value;
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_supportblockzW.Value;
        ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).LeftAngle = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_leftangle.Value;
        ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).RigthAngle = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_rightangle.Value;
        if (((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).radio_leftholder.Checked)
        {
          ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = LeftRightType.Left;
          ((F_PanelCutSheetList) this).\u0002.Checked = true;
          ((F_PanelCutSheetList) this).\u0001.Checked = false;
        }
        else
        {
          ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = LeftRightType.Right;
          ((F_PanelCutSheetList) this).\u0002.Checked = false;
          ((F_PanelCutSheetList) this).\u0001.Checked = true;
        }
        ((F_PanelCutPartList) this).EntitiesTransformed.Clear();
        buOrdinateDim.Copy(((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).PreviewEnts, ref ((F_PanelCutPartList) this).EntitiesTransformed);
        for (int index = 0; index <= ((F_PanelCutPartList) this).EntitiesTransformed.Count - 1; ++index)
        {
          buEntity LinearPathEntity = (buEntity) null;
          buCall.\u0001.EntitiesToLinearPath(((F_PanelCutPartList) this).EntitiesTransformed[index], buSystem.RegenDeviation, ref LinearPathEntity);
          ((F_PanelCutPartList) this).EntitiesTransformed[index] = LinearPathEntity;
        }
        ((F_PanelCutPartList) this).\u0001.Entities.Clear();
        for (int index = 0; index <= ((F_PanelCutPartList) this).EntitiesTransformed.Count - 1; ++index)
        {
          Entity copiedEntity = (Entity) null;
          buAngularDim.Copy(((F_PanelCutPartList) this).EntitiesTransformed[index], ref copiedEntity);
          ((F_PanelCutPartList) this).\u0001.Entities.Add(copiedEntity);
        }
        ((F_PanelCutPartList) this).\u0001.Invalidate();
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(((F_PanelCutPartList) this).EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
        ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
        ((F_PanelCutSheetList) this).\u0006.Value = (Decimal) Math.Round(MaxPoint.X - MinPoint.X, 3);
        ((F_PanelCutSheetList) this).\u0007.Value = (Decimal) Math.Round(MaxPoint.Y - MinPoint.Y, 3);
        ((F_PanelCutSheetList) this).\u0003.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height;
        ((F_PanelCutSheetList) this).\u0005.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height;
        ((F_PanelCutSheetList) this).\u0004.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight;
        ((F_PanelCutSheetList) this).\u0010.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Width;
        ((F_PanelCutSheetList) this).\u000E.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width;
        ((F_PanelCutSheetList) this).\u000F.Value = (Decimal) ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth;
        ((F_PanelCutSheetList) this).\u0008.Value = (Decimal) ((F_OperationList) ((F_PanelCutPartList) this).FrmNewProfile).MaxClamper;
        ((F_PanelCutSheetList) this).\u0012.Value = (Decimal) ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).LeftAngle;
        ((F_PanelCutSheetList) this).\u0011.Value = (Decimal) ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).RigthAngle;
        ((F_PanelCutSheetList) this).\u0014.Value = ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_multiplycount.Value;
        ((F_PanelCutSheetList) this).\u0013.Value = ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_multiplyspace.Value;
        ((F_PanelCutSheetList) this).\u0004.Checked = ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).chk_multiplyprofile.Checked;
        ((F_PanelCutSheetList) this).\u0003.Checked = ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).chk_multilymirror.Checked;
        ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplyCount = (int) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_multiplycount.Value;
        ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplySpace = (double) ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).spn_multiplyspace.Value;
        ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplyEnable = ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).chk_multiplyprofile.Checked;
        ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplyMirror = ((F_PanelCutPartList) ((F_PanelCutPartList) this).FrmNewProfile).chk_multilymirror.Checked;
        ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
        this.\u0001((object) ((F_PanelCutPartList) this).\u0002, obj1);
        return;
      }
    }
    if (control2.Name == ((F_PanelCutPartList) this).\u0008.Name && ((F_PanelCutPartList) this).\u0002 >= 0)
    {
      FileInfo fileInfo = new FileInfo($"{((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles}\\{((F_PanelCutSheetList) this).grid_files.Rows[((F_PanelCutPartList) this).\u0002].Cells[1].Value.ToString()}");
      if (fileInfo.Exists && buString.MessageBoxQuestion($"{((F_PanelCutPartList) this).strDelete} : {buFile.getFileName(fileInfo.FullName)}") == DialogResult.Yes)
      {
        fileInfo.Delete();
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileAdd) this);
      }
    }
    if (control2.Name == ((F_PanelCutPartList) this).\u0005.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      ((F_PanelCutPartList) this).\u0001.Entities.Rotate(buString5.DegreeToRadian((double) ((F_PanelCutPartList) this).\u0001.Value), new Vector3D(0.0, 0.0, 1.0));
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_PanelCutPartList) this).\u0001.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_PanelCutPartList) this).\u0001.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      ((F_PanelCutPartList) this).\u0001.ZoomFit();
      ((F_PanelCutPartList) this).\u0001.Invalidate();
      ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
      ((F_PanelCutSheetList) this).\u0006.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_PanelCutSheetList) this).\u0007.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_PanelCutPartList) this).\u0001.Add("RotateLeft");
      ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_PanelCutPartList) this).\u0004.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      ((F_PanelCutPartList) this).\u0001.Entities.Rotate(buString5.DegreeToRadian(-(double) ((F_PanelCutPartList) this).\u0001.Value), new Vector3D(0.0, 0.0, 1.0));
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_PanelCutPartList) this).\u0001.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_PanelCutPartList) this).\u0001.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      ((F_PanelCutPartList) this).\u0001.ZoomFit();
      ((F_PanelCutPartList) this).\u0001.Invalidate();
      ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
      ((F_PanelCutSheetList) this).\u0006.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_PanelCutSheetList) this).\u0007.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_PanelCutPartList) this).\u0001.Add("RotateRight");
      ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_PanelCutPartList) this).\u0006.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      for (int index = 0; index <= ((F_PanelCutPartList) this).\u0001.Entities.Count - 1; ++index)
      {
        Mirror xform = new Mirror(new Plane(new Point3D(), new Vector3D(new Point3D(), new Point3D(0.0, 10.0, 0.0)), Plane.XY.AxisZ));
        ((F_PanelCutPartList) this).\u0001.Entities[index].TransformBy((Transformation) xform);
      }
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_PanelCutPartList) this).\u0001.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_PanelCutPartList) this).\u0001.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      ((F_PanelCutPartList) this).\u0001.ZoomFit();
      ((F_PanelCutPartList) this).\u0001.Invalidate();
      ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
      ((F_PanelCutSheetList) this).\u0006.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_PanelCutSheetList) this).\u0007.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_PanelCutPartList) this).\u0001.Add("MirrorHorizontal");
      ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_PanelCutPartList) this).\u0007.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      for (int index = 0; index <= ((F_PanelCutPartList) this).\u0001.Entities.Count - 1; ++index)
      {
        Mirror xform = new Mirror(new Plane(new Point3D(), new Vector3D(new Point3D(), new Point3D(10.0, 0.0, 0.0)), Plane.XY.AxisZ));
        ((F_PanelCutPartList) this).\u0001.Entities[index].TransformBy((Transformation) xform);
      }
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_PanelCutPartList) this).\u0001.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_PanelCutPartList) this).\u0001.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved();
      ((F_PanelCutPartList) this).\u0001.ZoomFit();
      ((F_PanelCutPartList) this).\u0001.Invalidate();
      ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
      ((F_PanelCutSheetList) this).\u0006.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_PanelCutSheetList) this).\u0007.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_PanelCutPartList) this).\u0001.Add("MirrorVertical");
      ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_PanelCutSheetList) this).\u0016.Name)
    {
      ColorDialogBox.ShowDialog(((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).SupportBlockZColor);
      if (ColorDialogBox.Result == DialogResult.OK)
      {
        ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).SupportBlockZColor = ColorDialogBox.Color;
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).colorSupportBlock = ColorDialogBox.Color;
        ((F_PanelCutSheetList) this).\u0016.BackColor = ColorDialogBox.Color;
      }
    }
    if (control2.Name == ((F_PanelCutSheetList) this).\u0017.Name)
    {
      ColorDialogBox.ShowDialog(((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).Color);
      if (ColorDialogBox.Result == DialogResult.OK)
      {
        ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileColor = ColorDialogBox.Color;
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).colorProfile = ColorDialogBox.Color;
        ((F_PanelCutSheetList) this).\u0017.BackColor = ColorDialogBox.Color;
        \u000F.\u0001.\u0001($"{((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles}\\{((F_PanelCutSheetList) this).grid_files.Rows[((F_PanelCutPartList) this).\u0002].Cells[1].Value.ToString()}", (F_ProfileAdd) this);
      }
    }
    if (control2.Name == ((F_PanelCutPartList) this).\u0003.Name)
    {
      ((F_PanelCutPartList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_PanelCutPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PanelCutPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_PanelCutPartList) this).\u0002.Name))
      return;
    ((F_PanelCutPartList) this).Profile = (buEyeBaseVer5.Apps.ProfileItem) new PanelCutRuntimeSettings();
    double result = 0.0;
    double.TryParse(((F_PanelCutPartList) this).\u0002.Text, out result);
    if (((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxLength > 0.0 & result > ((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxLength && buNumeric5.MessageBoxQuestion(buProfile.LangProfileMessage[24]) == DialogResult.No)
      return;
    if (((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxWidth > 0.0 & (double) ((F_PanelCutSheetList) this).\u0006.Value > ((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxWidth)
      buNumeric5.MessageBoxWarning(buProfile.LangProfileMessage[25]);
    else if (((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxHeight > 0.0 & (double) ((F_PanelCutSheetList) this).\u0007.Value > ((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxHeight)
      buNumeric5.MessageBoxWarning(buProfile.LangProfileMessage[26]);
    else if (((F_PanelCutSheetList) this).\u0004.Checked & ((F_PanelCutSheetList) this).\u0003.Checked & ((F_PanelCutSheetList) this).\u0014.Value > 2M)
    {
      buNumeric5.MessageBoxWarning(buLangTranslate.preSentencesProfile.YouCanDefineMax2ProfileforMultiplyMirrorMode);
    }
    else
    {
      CreateProfileFromDataOptions Options = (CreateProfileFromDataOptions) new marbleCuttingItems();
      ((MarbleRuntimeSettings) Options).color = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileColor;
      ((MarbleRuntimeSettings) Options).Transparency = (int) ((F_PanelCutPartList) this).\u0002.Value;
      ((MarbleRuntimeSettings) Options).FileName = ((F_PanelCutPartList) this).\u0001;
      ((MarbleRuntimeSettings) Options).FullName = $"{((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles}\\{((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).FileName}";
      ((MarbleRuntimeSettings) Options).Name = ((F_PanelCutPartList) this).\u0002.Text;
      ((MarbleRuntimeSettings) Options).Length = result;
      ((MarbleRuntimeSettings) Options).NeededHeight = (double) ((F_PanelCutSheetList) this).\u0007.Value;
      ((MarbleRuntimeSettings) Options).NeededWidth = (double) ((F_PanelCutSheetList) this).\u0006.Value;
      ((MarbleRuntimeSettings) Options).SupportBlockY1Height = (double) ((F_PanelCutSheetList) this).\u0003.Value;
      ((MarbleRuntimeSettings) Options).SupportBlockY2Height = (double) ((F_PanelCutSheetList) this).\u0005.Value;
      ((MarbleRuntimeSettings) Options).SupportBlockZHeight = (double) ((F_PanelCutSheetList) this).\u0004.Value;
      ((MarbleRuntimeSettings) Options).SupportBlockY1Width = (double) ((F_PanelCutSheetList) this).\u0010.Value;
      ((MarbleRuntimeSettings) Options).SupportBlockY2Width = (double) ((F_PanelCutSheetList) this).\u000E.Value;
      ((MarbleRuntimeSettings) Options).SupportBlockZWidth = (double) ((F_PanelCutSheetList) this).\u000F.Value;
      ((MarbleRuntimeSettings) Options).GapConnection = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).GapConnectionForProfile;
      ((MarbleRuntimeSettings) Options).SortResolituon = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ProfileSortResolution;
      ((MarbleRuntimeSettings) Options).IntersectionRules = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).IntersectionRules;
      ((MarbleRuntimeSettings) Options).ConnectSmallGap = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).ConnectSmallGap;
      ((MarbleRuntimeSettings) Options).MinPointFilterLength = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).MinProfileFilterLength;
      ((MarbleRuntimeSettings) Options).NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;
      ((MarbleRuntimeSettings) Options).MaxClamper = (int) ((F_PanelCutSheetList) this).\u0008.Value;
      List<Entity> Entities = new List<Entity>();
      for (int index1 = 0; index1 <= ((F_PanelCutPartList) this).\u0001.Entities.Count - 1; ++index1)
      {
        if (((F_PanelCutPartList) this).\u0001.Entities[index1] is ICurve)
        {
          if (((F_PanelCutPartList) this).\u0001.Entities[index1].GetType() != typeof (devDept.Eyeshot.Entities.Point) & ((F_PanelCutPartList) this).\u0001.Entities[index1].GetType() != typeof (Curve))
            Entities.Add(buVector5.CopyEntities(((F_PanelCutPartList) this).\u0001.Entities[index1]));
          if (((F_PanelCutPartList) this).\u0001.Entities[index1].GetType() == typeof (Curve))
          {
            ((F_PanelCutPartList) this).\u0001.Entities[index1].Regen(0.1);
            Entities.Add((Entity) new LinearPath(((F_PanelCutPartList) this).\u0001.Entities[index1].Vertices));
          }
        }
        else if (((F_PanelCutPartList) this).\u0001.Entities[index1].GetType() == typeof (BlockReference))
        {
          BlockReference entity1 = ((F_PanelCutPartList) this).\u0001.Entities[index1] as BlockReference;
          for (int index2 = 0; index2 <= ((F_PanelCutPartList) this).\u0001.Blocks.Count - 1; ++index2)
          {
            if (entity1.BlockName == ((F_PanelCutPartList) this).\u0001.Blocks[index2].Name)
            {
              for (int index3 = 0; index3 <= ((F_PanelCutPartList) this).\u0001.Blocks[index2].Entities.Count - 1; ++index3)
              {
                if (((F_PanelCutPartList) this).\u0001.Blocks[index2].Entities[index3] is ICurve)
                {
                  Entity entity2 = buVector5.CopyEntities(((F_PanelCutPartList) this).\u0001.Blocks[index2].Entities[index3]);
                  entity2.TransformBy(entity1.Transformation);
                  entity2.Regen(0.01);
                  Entities.Add(entity2);
                }
              }
            }
          }
        }
        else if (((F_PanelCutPartList) this).\u0001.Entities[index1].GetType() == typeof (BlockReferenceEx))
        {
          BlockReferenceEx entity3 = ((F_PanelCutPartList) this).\u0001.Entities[index1] as BlockReferenceEx;
          for (int index4 = 0; index4 <= ((F_PanelCutPartList) this).\u0001.Blocks.Count - 1; ++index4)
          {
            if (entity3.BlockName == ((F_PanelCutPartList) this).\u0001.Blocks[index4].Name)
            {
              for (int index5 = 0; index5 <= ((F_PanelCutPartList) this).\u0001.Blocks[index4].Entities.Count - 1; ++index5)
              {
                if (((F_PanelCutPartList) this).\u0001.Blocks[index4].Entities[index5] is ICurve)
                {
                  Entity entity4 = buVector5.CopyEntities(((F_PanelCutPartList) this).\u0001.Blocks[index4].Entities[index5]);
                  entity4.TransformBy(entity3.Transformation);
                  entity4.Regen(0.01);
                  Entities.Add(entity4);
                }
              }
            }
          }
        }
      }
      if (((F_PanelCutSheetList) this).\u0004.Checked)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(Entities, ref MinPoint, ref MaxPoint);
        double num = MaxPoint.X - MinPoint.X;
        if (((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxHeight > 0.0 & (num + (double) ((F_PanelCutSheetList) this).\u0013.Value) * ((double) ((F_PanelCutSheetList) this).\u0014.Value - 1.0) + num > ((MarbleItemEntities) ((F_PanelCutPartList) this).ProfileSet).ProfileMaxHeight)
        {
          buNumeric5.MessageBoxWarning(buLangTranslate.preSentencesProfile.ProfileMultiplyWidthIsBiggerThenLimit);
          return;
        }
      }
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).LeftAngle = (double) ((F_PanelCutSheetList) this).\u0012.Value;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).RightAngle = (double) ((F_PanelCutSheetList) this).\u0011.Value;
      buCall.\u0001.CheckEntities(new CheckEntitesOption()
      {
        CompositeCurveToEntities = false
      }, ref Entities);
      ((buEyeBaseVer5.Apps.ProfileArray) buCall.\u0001).CreateProfileFromData(Entities, Options, ref ((F_PanelCutPartList) this).Profile);
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).colorSupportBlock = ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).SupportBlockZColor;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MaxClamperNumber = (int) ((F_PanelCutSheetList) this).\u0008.Value;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).Thickness = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).NewProfileThickness;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).ProfileType = ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileType;
      ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplyCount = (int) ((F_PanelCutSheetList) this).\u0014.Value;
      ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplySpace = (double) ((F_PanelCutSheetList) this).\u0013.Value;
      ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplyEnable = ((F_PanelCutSheetList) this).\u0004.Checked;
      ((MarbleJob) ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).MultiplyProfile).ProfileMultiplyMirror = ((F_PanelCutSheetList) this).\u0003.Checked;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).TextureEnable = ((F_PanelCutSheetList) this).\u0001.Checked;
      ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).LeftAngle = (double) ((F_PanelCutSheetList) this).\u0012.Value;
      ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).RigthAngle = (double) ((F_PanelCutSheetList) this).\u0011.Value;
      if (((F_PanelCutSheetList) this).\u0002.Checked)
      {
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).XReferanceLocation = LeftRightType.Left;
        ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = LeftRightType.Left;
      }
      else
      {
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).XReferanceLocation = LeftRightType.Right;
        ((MarbleItemSettings) ((F_PanelCutPartList) this).ProfileSet).XDirRefType = LeftRightType.Right;
      }
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).MultiplyProfileCount = (int) ((F_PanelCutSheetList) this).\u0014.Value;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).MultiplyProfileSpace = (double) ((F_PanelCutSheetList) this).\u0013.Value;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).MultiplyProfileMirror = ((F_PanelCutSheetList) this).\u0003.Checked;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).MultiplyProfileEnable = ((F_PanelCutSheetList) this).\u0004.Checked;
      ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).MaterialTranspancy = (int) ((F_PanelCutPartList) this).\u0002.Value;
      ((MarbleItemCam) ((F_PanelCutPartList) this).ProfileSet).SupportBlockZColor = ((F_PanelCutSheetList) this).\u0016.BackColor;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).ItemName = ((F_PanelCutPartList) this).\u0002.Text;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).FileName = ((F_PanelCutPartList) this).\u0001;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).FileNameFull = $"{((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles}\\{((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).FileName}";
      for (int index = 0; index <= ((F_PanelCutPartList) this).\u0001.Count - 1; ++index)
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).ProfileTraformations.Add(((F_PanelCutPartList) this).\u0001[index]);
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileLength = result;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height = (double) ((F_PanelCutSheetList) this).\u0003.Value;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height = (double) ((F_PanelCutSheetList) this).\u0005.Value;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight = (double) ((F_PanelCutSheetList) this).\u0004.Value;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Width = (double) ((F_PanelCutSheetList) this).\u0010.Value;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width = (double) ((F_PanelCutSheetList) this).\u000E.Value;
      ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth = (double) ((F_PanelCutSheetList) this).\u000F.Value;
      if (((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height < 0.0)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY1Height = 0.0;
      if (((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height < 0.0)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Height = 0.0;
      if (((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight < 0.0)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZHeight = 0.0;
      if (((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width < 0.0)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width = 0.0;
      if (((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width < 0.0)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockY2Width = 0.0;
      if (((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth < 0.0)
        ((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).SupportBlockZWidth = 0.0;
      ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).Length = result;
      if (((F_PanelCutPartList) this).Materials.Count > 0)
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).Skin = new MaterialSkin(((F_PanelCutPartList) this).Materials[((F_PanelCutPartList) this).\u0001.SelectedIndex]);
      if (((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).TextureEnable)
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).TextureName = ((F_PanelCutPartList) this).\u0001.Text;
      else
        ((buEyeBaseVer5.Apps.ProfileSettings) ((F_PanelCutPartList) this).Profile).TextureName = "";
      ((F_PanelCutPartList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_PanelCutPartList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PanelCutPartList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_PanelCutPartList) this).PropertiesForm.Inited)
      return;
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    double sx = (double) ((F_PanelCutSheetList) this).\u0006.Value / (((F_PanelCutPartList) this).\u0001.Entities.BoxMax.X - ((F_PanelCutPartList) this).\u0001.Entities.BoxMin.X);
    double sy = (double) ((F_PanelCutSheetList) this).\u0007.Value / (((F_PanelCutPartList) this).\u0001.Entities.BoxMax.Y - ((F_PanelCutPartList) this).\u0001.Entities.BoxMin.Y);
    List<Entity> entityList = new List<Entity>();
    if (control2.Name == ((F_PanelCutSheetList) this).\u0006.Name && sx != 0.0 & sy != 0.0)
    {
      if (((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileKeepRatio)
      {
        sy = sx;
        ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
        ((F_PanelCutSheetList) this).\u0007.Value = Math.Round(((F_PanelCutSheetList) this).\u0007.Value * (Decimal) sy);
        ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
      }
      if (!((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileKeepRatio & sx != sy)
      {
        List<Entity> copiedEnt = new List<Entity>();
        List<Entity> devideEntities = new List<Entity>();
        buVector5.CopyEntities(((F_PanelCutPartList) this).\u0001.Entities, ref copiedEnt);
        EntityDevideData Settings = new EntityDevideData();
        Settings.Arc = true;
        Settings.Circle = true;
        Settings.Ellipse = true;
        Settings.ArcLength = 0.1;
        Settings.CircleLength = 0.1;
        Settings.EllipseLength = 0.1;
        Color color = ((F_PanelCutPartList) this).\u0001.Entities[0].Color;
        buCall.\u0001.EntitiesDevideByLengthAsPolyline(copiedEnt, Settings, ref devideEntities);
        ((F_PanelCutPartList) this).\u0001.Entities.Clear();
        for (int index = 0; index <= devideEntities.Count - 1; ++index)
        {
          devideEntities[index].Color = color;
          devideEntities[index].ColorMethod = colorMethodType.byEntity;
          ((F_PanelCutPartList) this).\u0001.Entities.Add(devideEntities[index]);
        }
      }
      ((F_PanelCutPartList) this).\u0001.Entities.Scale(sx, sy);
      ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved(0.01);
      ((F_PanelCutPartList) this).\u0001.ZoomFit();
      ((F_PanelCutPartList) this).\u0001.Invalidate();
    }
    if (!(control2.Name == ((F_PanelCutSheetList) this).\u0007.Name) || !(sx != 0.0 & sy != 0.0))
      return;
    if (((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileKeepRatio)
    {
      sx = sy;
      ((F_PanelCutPartList) this).PropertiesForm.Inited = false;
      ((F_PanelCutSheetList) this).\u0006.Value = Math.Round(((F_PanelCutSheetList) this).\u0006.Value * (Decimal) sx);
      ((F_PanelCutPartList) this).PropertiesForm.Inited = true;
    }
    if (!((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileKeepRatio & sx != sy)
    {
      List<Entity> copiedEnt = new List<Entity>();
      List<Entity> devideEntities = new List<Entity>();
      buVector5.CopyEntities(((F_PanelCutPartList) this).\u0001.Entities, ref copiedEnt);
      EntityDevideData Settings = new EntityDevideData();
      Settings.Arc = true;
      Settings.Circle = true;
      Settings.Ellipse = true;
      Settings.ArcLength = 0.1;
      Settings.CircleLength = 0.1;
      Settings.EllipseLength = 0.1;
      Color color = ((F_PanelCutPartList) this).\u0001.Entities[0].Color;
      buCall.\u0001.EntitiesDevideByLengthAsPolyline(copiedEnt, Settings, ref devideEntities);
      ((F_PanelCutPartList) this).\u0001.Entities.Clear();
      for (int index = 0; index <= devideEntities.Count - 1; ++index)
      {
        devideEntities[index].Color = color;
        devideEntities[index].ColorMethod = colorMethodType.byEntity;
        ((F_PanelCutPartList) this).\u0001.Entities.Add(devideEntities[index]);
      }
    }
    ((F_PanelCutPartList) this).\u0001.Entities.Scale(sx, sy);
    ((F_PanelCutPartList) this).\u0001.Entities.RegenAllCurved(0.01);
    ((F_PanelCutPartList) this).\u0001.ZoomFit();
    ((F_PanelCutPartList) this).\u0001.Invalidate();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      int num = 1;
      if (((F_PanelCutPartList) this).\u0001.Text.Length == 0)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileAdd) this);
      }
      else
      {
        ((F_PanelCutSheetList) this).grid_files.Rows.Clear();
        for (int index = 0; index <= ((F_PanelCutPartList) this).\u0002.Count - 1; ++index)
        {
          string fileName = buFile.getFileName(((F_PanelCutPartList) this).\u0002[index]);
          if (fileName.ToLower().IndexOf(((F_PanelCutPartList) this).\u0001.Text.ToLower()) >= 0)
          {
            ((F_PanelCutSheetList) this).grid_files.Rows.Add((object) num, (object) fileName);
            ++num;
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Tag != null)
    {
      FileInfo fileInfo = (FileInfo) null;
      if (control.Tag.ToString() == "2")
      {
        fileInfo = new FileInfo(AppPath.HelpImages + "\\LeftSupportHeight.png");
        ((F_PanelCutSheetList) this).\u0004.Text = buLangTranslate.preHelpProfile.DefineBackPlaneProfileLeanHeight;
      }
      if (control.Tag.ToString() == "3")
      {
        fileInfo = new FileInfo(AppPath.HelpImages + "\\LeftSupportWidth.png");
        ((F_PanelCutSheetList) this).\u0004.Text = buLangTranslate.preHelpProfile.DefineBackPlaneProfileLeanWidth;
      }
      if (control.Tag.ToString() == "4")
      {
        fileInfo = new FileInfo(AppPath.HelpImages + "\\RigthSupportHeight.png");
        ((F_PanelCutSheetList) this).\u0004.Text = buLangTranslate.preHelpProfile.DefineFrontPlaneProfileLeanHeight;
      }
      if (control.Tag.ToString() == "5")
      {
        fileInfo = new FileInfo(AppPath.HelpImages + "\\RigthSupportWidth.png");
        ((F_PanelCutSheetList) this).\u0004.Text = buLangTranslate.preHelpProfile.DefineFrontPlaneProfileLeanWidth;
      }
      if (control.Tag.ToString() == "6")
      {
        fileInfo = new FileInfo(AppPath.HelpImages + "\\BottomSupportZ.png");
        ((F_PanelCutSheetList) this).\u0004.Text = buLangTranslate.preHelpProfile.DefineBottomPlaneProfileLeanHeight;
      }
      if (control.Tag.ToString() == "7")
      {
        fileInfo = new FileInfo(AppPath.HelpImages + "\\BottomSupportWidth.png");
        ((F_PanelCutSheetList) this).\u0004.Text = buLangTranslate.preHelpProfile.DefineBottomPlaneProfileLeanWidth;
      }
      if (fileInfo != null)
      {
        if (fileInfo.Exists)
        {
          ((F_PanelCutSheetList) this).\u0003.Image = Image.FromFile(fileInfo.FullName);
        }
        else
        {
          ((F_PanelCutSheetList) this).\u0003.Image = (Image) null;
          ((F_PanelCutSheetList) this).\u0004.Text = "";
        }
      }
      else
      {
        ((F_PanelCutSheetList) this).\u0003.Image = (Image) null;
        ((F_PanelCutSheetList) this).\u0004.Text = "";
      }
    }
    else
    {
      ((F_PanelCutSheetList) this).\u0003.Image = (Image) null;
      ((F_PanelCutSheetList) this).\u0004.Text = "";
    }
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_PanelCutPartList) this).PropertiesForm.Inited)
      return;
    ((MarbleRuntimeSettings) ((F_PanelCutPartList) this).ProfileRunTimeSet).ProfileKeepRatio = ((F_PanelCutSheetList) this).\u0002.Checked;
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_PanelCutPartList) this).\u0001 = obj1.ColumnIndex;
    ((F_PanelCutPartList) this).\u0002 = obj1.RowIndex;
    if (((F_PanelCutPartList) this).\u0002 < 0)
      return;
    \u000F.\u0001.\u0001($"{((MarbleTempVars) ((F_PanelCutPartList) this).ProfileRunTimeSet).pathProfiles}\\{((F_PanelCutSheetList) this).grid_files.Rows[((F_PanelCutPartList) this).\u0002].Cells[1].Value.ToString()}", (F_ProfileAdd) this);
    ((F_PanelCutPartList) this).\u0001 = ((F_PanelCutSheetList) this).grid_files.Rows[((F_PanelCutPartList) this).\u0002].Cells[1].Value.ToString();
    ((F_PanelCutPartList) this).\u0002.Text = buFile5.bunesting.getFileNameWithoutExtension(((F_PanelCutPartList) this).\u0001);
    ((F_PanelCutPartList) this).\u0001.Clear();
    ((F_PanelCutPartList) this).\u0001 = new List<string>();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_PanelCutPartList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_PanelCutPartList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
