// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_RoboticSurfacePoints
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buCore;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_RoboticSurfacePoints : Form
{
  public int AddPartFromFileExtensionIndex;
  public int AddSheetFromFileExtensionIndex;
  public int SaveFileExtensionIndex;
  public string AddPartFromFileFolder;
  public string AddSheetFromFileFolder;
  public string SaveFileFolder;
  public ToolBase5 activeTool;
  public LayerBase5 activeLayer;
  public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile;
  public nestPartRotateType PartRotationDefault;
  public List<buNestingSheet> Sheets;
  public List<buNestingPart> Parts;
  public List<Entity> SendToCadEntities;
  public static List<string> Captions;
  public static List<string> CaptionGrid;
  internal IContainer \u0001;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal DataGridView \u0001;
  internal Panel \u0001;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_NestPartAdd) this).btn_ok.Name)
    {
      ((F_NestPartAdd) this).btn_ok.Focus();
      for (int index = 0; index <= ((F_NestPartAdd) this).MaterialOrders.Count - 1; ++index)
      {
        if (((F_NestPartAdd) this).\u0001.GetItemCheckState(index) == CheckState.Checked)
          ((F_NestPartAdd) this).MaterialOrders[index].Enable = true;
        else
          ((F_NestPartAdd) this).MaterialOrders[index].Enable = false;
      }
      ((F_NestPartAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_NestPartAdd) this).btn_cancel.Name)
    {
      ((F_NestPartAdd) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_NestPartAdd) this).btn_up.Name && ((F_NestPartAdd) this).\u0001.SelectedIndex > 0 & ((F_NestPartAdd) this).MaterialOrders.Count >= 2)
    {
      int selectedIndex = ((F_NestPartAdd) this).\u0001.SelectedIndex;
      LaserMaterialData laserMaterialData = new LaserMaterialData(((F_NestPartAdd) this).MaterialOrders[((F_NestPartAdd) this).\u0001.SelectedIndex]);
      ((F_NestPartAdd) this).MaterialOrders.RemoveAt(((F_NestPartAdd) this).\u0001.SelectedIndex);
      ((F_NestPartAdd) this).MaterialOrders.Insert(((F_NestPartAdd) this).\u0001.SelectedIndex - 1, laserMaterialData);
      int num = selectedIndex - 1;
      \u0007.\u0001.\u0001((F_LaserStartOrder) this);
      ((F_NestPartAdd) this).\u0001.SelectedIndex = num;
    }
    if (!(control2.Name == ((F_NestPartAdd) this).btn_down.Name) || ((F_NestPartAdd) this).\u0001.SelectedIndex >= ((F_NestPartAdd) this).MaterialOrders.Count - 1)
      return;
    int selectedIndex1 = ((F_NestPartAdd) this).\u0001.SelectedIndex;
    LaserMaterialData laserMaterialData1 = new LaserMaterialData(((F_NestPartAdd) this).MaterialOrders[((F_NestPartAdd) this).\u0001.SelectedIndex]);
    ((F_NestPartAdd) this).MaterialOrders.RemoveAt(selectedIndex1);
    ((F_NestPartAdd) this).MaterialOrders.Insert(selectedIndex1 + 1, laserMaterialData1);
    int num1 = selectedIndex1 + 1;
    \u0007.\u0001.\u0001((F_LaserStartOrder) this);
    ((F_NestPartAdd) this).\u0001.SelectedIndex = num1;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestPartAdd) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestPartAdd) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestPartAdd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestPartAdd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RoboticSurfacePoints() => F_NestPartAdd.Captions = new List<string>();

  public F_RoboticSurfacePoints()
  {
    ((F_NestPartAdd) this).PropertiesForm = new FormProperties();
    ((F_NestPartAdd) this).Materials = new List<LaserMaterial>();
    ((F_NestPartAdd) this).Cf2Properties = new List<Cf2FileProperties>();
    ((F_NestPartAdd) this).pathMaterialFile = Application.StartupPath;
    ((F_NestPartAdd) this).strRemoveCaption = "Do You Want to Remove Item";
    ((F_NestPartAdd) this).SelectedMaterialIndex = -1;
    ((F_NestPartAdd) this).DirType = 0;
    ((F_NestPartAdd) this).EditMode = false;
    ((F_NestPartAdd) this).\u0001 = false;
    ((F_NestPartAdd) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_LaserMaterial) this);
  }

  public void Init()
  {
    ((F_NestPartAdd) this).PropertiesForm.Inited = false;
    if (((F_NestPartAdd) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestPartAdd) this).PropertiesForm.Height;
    if (((F_NestPartAdd) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestPartAdd) this).PropertiesForm.Width;
    this.TopMost = ((F_NestPartAdd) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestPartAdd) this).PropertiesForm.FormPosition;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LaserMaterial) this);
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LaserMaterial) this);
    LaserMaterialData laserMaterialData = new LaserMaterialData();
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) laserMaterialData.Type, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) laserMaterialData.Type), ref ((F_NestRectPartAdd) this).\u0001);
    ((F_NestRectPartAdd) this).\u0002.Items.Clear();
    ((F_NestRectPartAdd) this).\u0003.Items.Clear();
    for (int index = 0; index <= ((F_NestPartAdd) this).Cf2Properties.Count - 1; ++index)
    {
      ((F_NestRectPartAdd) this).\u0002.Items.Add((object) $"Pt: {((F_NestPartAdd) this).Cf2Properties[index].PtIndex.ToString()} - {((F_NestPartAdd) this).Cf2Properties[index].CodeType.ToString()}");
      ((F_NestRectPartAdd) this).\u0003.Items.Add((object) $"Pt: {((F_NestPartAdd) this).Cf2Properties[index].PtIndex.ToString()} - {((F_NestPartAdd) this).Cf2Properties[index].CodeType.ToString()}");
    }
    if (((F_NestRectPartAdd) this).\u0002.Items.Count > 0)
    {
      ((F_NestRectPartAdd) this).\u0002.SelectedIndex = 0;
      ((F_NestRectPartAdd) this).\u0003.SelectedIndex = 0;
    }
    if (((F_NestPartAdd) this).SelectedMaterialIndex >= 0 & ((F_NestPartAdd) this).Materials.Count > 0 & ((F_NestPartAdd) this).SelectedMaterialIndex <= ((F_NestPartAdd) this).Materials.Count - 1)
      ((F_NestPartAdd) this).\u0001.SelectedIndex = ((F_NestPartAdd) this).SelectedMaterialIndex;
    ((F_NestRectPartAdd) this).\u0003.Visible = false;
    ((F_NestRectPartAdd) this).\u0002.Visible = false;
    ((F_NestSheetAdd) this).\u0004.Visible = false;
    ((F_NestPartAdd) this).PropertiesForm.Result = DialogResult.None;
    ((F_NestPartAdd) this).PropertiesForm.Inited = true;
    if (((F_NestPartAdd) this).Materials.Count <= 0)
      return;
    \u0001.\u0002.\u0001(((F_NestPartAdd) this).\u0001.SelectedIndex, (F_LaserMaterial) this);
    if (((F_NestRectPartAdd) this).\u0002.Items.Count <= 0)
      return;
    for (int index1 = 0; index1 <= ((F_NestPartAdd) this).Cf2Properties.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count - 1; ++index2)
      {
        if (((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[index2].PtRealValue == ((F_NestPartAdd) this).Cf2Properties[index1].PtRealValue & ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[index2].CodeType == ((F_NestPartAdd) this).Cf2Properties[index1].CodeType)
        {
          ((F_NestRectPartAdd) this).\u0002.SelectedIndex = index1;
          ((F_NestRectPartAdd) this).\u0003.SelectedIndex = index1;
        }
      }
    }
    ((F_NestRectPartAdd) this).\u0002.SelectedIndex = 0;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_NestRectPartAdd) this).btn_ok.Name)
    {
      ((F_NestPartAdd) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_NestPartAdd) this).SelectedMaterialIndex = ((F_NestPartAdd) this).\u0001.SelectedIndex;
    }
    if (control2.Name == ((F_NestPartAdd) this).btn_cancel.Name)
    {
      ((F_NestPartAdd) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_NestSheetAdd) this).btn_dirfeed.Name)
    {
      ((F_NestPartAdd) this).DirType = 1;
      ((F_NestSheetAdd) this).\u0018.Text = "Feed Direction";
      if (((F_NestPartAdd) this).\u0001.SelectedIndex >= 0 & ((F_NestPartAdd) this).\u0001.SelectedIndex <= ((F_NestPartAdd) this).Materials.Count - 1 && ((F_NestRectPartAdd) this).\u0002.SelectedIndex >= 0 & ((F_NestRectPartAdd) this).\u0002.SelectedIndex <= ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count - 1)
      {
        ((F_NestSheetAdd) this).\u000E.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXMinus;
        ((F_NestSheetAdd) this).\u0008.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXPlus;
        ((F_NestSheetAdd) this).\u0007.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedYMinus;
        ((F_NestSheetAdd) this).\u000F.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedYPlus;
        ((F_NestSheetAdd) this).\u0011.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXY;
        ((F_NestSheetAdd) this).\u0004.Visible = true;
      }
    }
    if (control2.Name == ((F_NestSheetAdd) this).btn_dirfocus.Name)
    {
      ((F_NestPartAdd) this).DirType = 2;
      ((F_NestSheetAdd) this).\u0018.Text = "Focus Direction";
      if (((F_NestPartAdd) this).\u0001.SelectedIndex >= 0 & ((F_NestPartAdd) this).\u0001.SelectedIndex <= ((F_NestPartAdd) this).Materials.Count - 1 && ((F_NestRectPartAdd) this).\u0002.SelectedIndex >= 0 & ((F_NestRectPartAdd) this).\u0002.SelectedIndex <= ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count - 1)
      {
        ((F_NestSheetAdd) this).\u000E.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXMinus;
        ((F_NestSheetAdd) this).\u0008.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXPlus;
        ((F_NestSheetAdd) this).\u0007.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusYMinus;
        ((F_NestSheetAdd) this).\u000F.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusYPlus;
        ((F_NestSheetAdd) this).\u0011.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXY;
        ((F_NestSheetAdd) this).\u0004.Visible = true;
      }
    }
    if (control2.Name == ((F_NestSheetAdd) this).btn_dirpower.Name)
    {
      ((F_NestPartAdd) this).DirType = 3;
      ((F_NestSheetAdd) this).\u0018.Text = "Power Direction";
      if (((F_NestPartAdd) this).\u0001.SelectedIndex >= 0 & ((F_NestPartAdd) this).\u0001.SelectedIndex <= ((F_NestPartAdd) this).Materials.Count - 1 && ((F_NestRectPartAdd) this).\u0002.SelectedIndex >= 0 & ((F_NestRectPartAdd) this).\u0002.SelectedIndex <= ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count - 1)
      {
        ((F_NestSheetAdd) this).\u000E.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerXMinus;
        ((F_NestSheetAdd) this).\u0008.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerXPlus;
        ((F_NestSheetAdd) this).\u0007.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerYMinus;
        ((F_NestSheetAdd) this).\u000F.Value = (Decimal) ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerYPlus;
        ((F_NestSheetAdd) this).\u0004.Visible = true;
      }
    }
    if (control2.Name == ((F_NestSheetAdd) this).btn_dircancel.Name)
      ((F_NestSheetAdd) this).\u0004.Visible = false;
    if (control2.Name == ((F_NestSheetAdd) this).btn_dirok.Name)
    {
      if (((F_NestPartAdd) this).DirType == 1)
      {
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXMinus = (double) ((F_NestSheetAdd) this).\u000E.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXPlus = (double) ((F_NestSheetAdd) this).\u0008.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedYMinus = (double) ((F_NestSheetAdd) this).\u0007.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedYPlus = (double) ((F_NestSheetAdd) this).\u000F.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXY = (double) ((F_NestSheetAdd) this).\u0011.Value;
      }
      if (((F_NestPartAdd) this).DirType == 2)
      {
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXMinus = (double) ((F_NestSheetAdd) this).\u000E.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXPlus = (double) ((F_NestSheetAdd) this).\u0008.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusYMinus = (double) ((F_NestSheetAdd) this).\u0007.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusYPlus = (double) ((F_NestSheetAdd) this).\u000F.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXY = (double) ((F_NestSheetAdd) this).\u0011.Value;
      }
      if (((F_NestPartAdd) this).DirType == 3)
      {
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerXMinus = (double) ((F_NestSheetAdd) this).\u000E.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerXPlus = (double) ((F_NestSheetAdd) this).\u0008.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerYMinus = (double) ((F_NestSheetAdd) this).\u0007.Value;
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerYPlus = (double) ((F_NestSheetAdd) this).\u000F.Value;
      }
      ((F_NestSheetAdd) this).\u0004.Visible = false;
    }
    if (control2.Name == ((F_NestSheetAdd) this).btn_edit.Name)
    {
      ((F_NestRectPartAdd) this).\u0001.Text = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Name;
      ((F_NestRectPartAdd) this).\u0002.Visible = true;
      ((F_NestPartAdd) this).EditMode = true;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_add.Name)
    {
      ((F_NestRectPartAdd) this).\u0002.Visible = true;
      ((F_NestPartAdd) this).EditMode = false;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_remove.Name && ((F_NestPartAdd) this).\u0001.SelectedIndex >= 0 && buString.MessageBoxQuestion($"{((F_NestPartAdd) this).strRemoveCaption}  {((F_NestPartAdd) this).\u0001.Text}") == DialogResult.Yes)
    {
      ((F_NestPartAdd) this).Materials.RemoveAt(((F_NestPartAdd) this).\u0001.SelectedIndex);
      ((F_NestPartAdd) this).\u0001.Items.RemoveAt(((F_NestPartAdd) this).\u0001.SelectedIndex);
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_nameok.Name)
    {
      if (!((F_NestPartAdd) this).EditMode)
      {
        LaserMaterial laserMaterial = new LaserMaterial();
        laserMaterial.Name = ((F_NestRectPartAdd) this).\u0001.Text;
        ((F_NestPartAdd) this).Materials.Add(laserMaterial);
        ((F_NestPartAdd) this).\u0001.Items.Add((object) laserMaterial.Name);
        ((F_NestPartAdd) this).\u0001.SelectedIndex = ((F_NestPartAdd) this).\u0001.Items.Count - 1;
      }
      else
      {
        ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Name = ((F_NestRectPartAdd) this).\u0001.Text;
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LaserMaterial) this);
      }
      ((F_NestRectPartAdd) this).\u0002.Visible = false;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_namecancel.Name)
    {
      ((F_NestRectPartAdd) this).\u0002.Visible = false;
      ((F_NestPartAdd) this).EditMode = false;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_copy.Name)
    {
      LaserMaterial laserMaterial = new LaserMaterial(((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex]);
      laserMaterial.Name += " - Copy";
      ((F_NestPartAdd) this).Materials.Add(laserMaterial);
      ((F_NestPartAdd) this).\u0001.Items.Add((object) laserMaterial.Name);
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_up.Name && ((F_NestPartAdd) this).\u0001.SelectedIndex > 0 & ((F_NestPartAdd) this).Materials.Count >= 2)
    {
      int selectedIndex = ((F_NestPartAdd) this).\u0001.SelectedIndex;
      LaserMaterial laserMaterial = new LaserMaterial(((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex]);
      ((F_NestPartAdd) this).Materials.RemoveAt(((F_NestPartAdd) this).\u0001.SelectedIndex);
      ((F_NestPartAdd) this).Materials.Insert(((F_NestPartAdd) this).\u0001.SelectedIndex - 1, laserMaterial);
      int num = selectedIndex - 1;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LaserMaterial) this);
      ((F_NestPartAdd) this).\u0001.SelectedIndex = num;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_down.Name && ((F_NestPartAdd) this).\u0001.SelectedIndex < ((F_NestPartAdd) this).Materials.Count - 1)
    {
      int selectedIndex = ((F_NestPartAdd) this).\u0001.SelectedIndex;
      LaserMaterial laserMaterial = new LaserMaterial(((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex]);
      ((F_NestPartAdd) this).Materials.RemoveAt(selectedIndex);
      ((F_NestPartAdd) this).Materials.Insert(selectedIndex + 1, laserMaterial);
      int num = selectedIndex + 1;
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LaserMaterial) this);
      ((F_NestPartAdd) this).\u0001.SelectedIndex = num;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_orderadd.Name)
      ((F_NestRectPartAdd) this).\u0003.Visible = true;
    if (control2.Name == ((F_NestRectPartAdd) this).btn_orderremove.Name && ((F_NestRectPartAdd) this).\u0002.SelectedIndex >= 0 && buString.MessageBoxQuestion($"{((F_NestPartAdd) this).strRemoveCaption}  {((F_NestRectPartAdd) this).\u0002.Text}") == DialogResult.Yes)
    {
      ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.RemoveAt(((F_NestRectPartAdd) this).\u0002.SelectedIndex);
      ((F_NestRectPartAdd) this).\u0002.Items.RemoveAt(((F_NestRectPartAdd) this).\u0002.SelectedIndex);
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_codetypeok.Name && ((F_NestPartAdd) this).\u0001.SelectedIndex >= 0 & ((F_NestPartAdd) this).\u0001.SelectedIndex <= ((F_NestPartAdd) this).Materials.Count - 1)
    {
      LaserMaterialData props = new LaserMaterialData();
      props.DefineationName = ((F_NestRectPartAdd) this).\u0001.Text;
      if (((F_NestPartAdd) this).Cf2Properties.Count > 0)
      {
        props.PtRealValue = ((F_NestPartAdd) this).Cf2Properties[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PtRealValue;
        props.CodeType = ((F_NestPartAdd) this).Cf2Properties[((F_NestRectPartAdd) this).\u0002.SelectedIndex].CodeType;
      }
      props.ApplyAll = ((F_NestRectPartAdd) this).\u0001.Checked;
      ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Add(props);
      \u0001.\u0002.\u0001(((F_NestPartAdd) this).\u0001.SelectedIndex, (F_LaserMaterial) this);
      this.ValueToControls(props);
      ((F_NestRectPartAdd) this).\u0003.Visible = false;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_codetypecancel.Name)
      ((F_NestRectPartAdd) this).\u0003.Visible = false;
    if (control2.Name == ((F_NestSheetAdd) this).btn_ordermoveup.Name && ((F_NestRectPartAdd) this).\u0002.SelectedIndex > 0 & ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count >= 2)
    {
      int selectedIndex = ((F_NestRectPartAdd) this).\u0002.SelectedIndex;
      LaserMaterialData laserMaterialData = new LaserMaterialData(((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex]);
      ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.RemoveAt(((F_NestRectPartAdd) this).\u0002.SelectedIndex);
      ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Insert(((F_NestRectPartAdd) this).\u0002.SelectedIndex - 1, laserMaterialData);
      int num = selectedIndex - 1;
      \u0001.\u0002.\u0001(((F_NestPartAdd) this).\u0001.SelectedIndex, (F_LaserMaterial) this);
      ((F_NestRectPartAdd) this).\u0002.SelectedIndex = num;
    }
    if (control2.Name == ((F_NestSheetAdd) this).btn_ordermovedown.Name && ((F_NestRectPartAdd) this).\u0002.SelectedIndex < ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count - 1)
    {
      int selectedIndex = ((F_NestRectPartAdd) this).\u0002.SelectedIndex;
      LaserMaterialData laserMaterialData = new LaserMaterialData(((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex]);
      ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.RemoveAt(selectedIndex);
      ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Insert(selectedIndex + 1, laserMaterialData);
      int num = selectedIndex + 1;
      \u0001.\u0002.\u0001(((F_NestPartAdd) this).\u0001.SelectedIndex, (F_LaserMaterial) this);
      ((F_NestRectPartAdd) this).\u0002.SelectedIndex = num;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_update.Name && ((F_NestPartAdd) this).PropertiesForm.Inited && ((F_NestPartAdd) this).\u0001.SelectedIndex >= 0 & ((F_NestPartAdd) this).\u0001.SelectedIndex <= ((F_NestPartAdd) this).Materials.Count - 1 && ((F_NestRectPartAdd) this).\u0002.SelectedIndex >= 0 & ((F_NestRectPartAdd) this).\u0002.SelectedIndex <= ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count - 1)
    {
      LaserMaterialData laserMaterialData = new LaserMaterialData(((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex]);
      \u0007.\u0001.\u0001((F_LaserMaterial) this, ref laserMaterialData);
      ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex] = laserMaterialData;
    }
    if (control2.Name == ((F_NestRectPartAdd) this).btn_save.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = ((F_NestPartAdd) this).pathMaterialFile;
      saveFileDialog.Filter = "Laser MaterialsSettings File (*.bulasmat)|*.bulasmat";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        ((F_NestPartAdd) this).pathMaterialFile = buFile.GetPath(saveFileDialog.FileName);
        ArrayList StringList = new ArrayList();
        StringList.Add((object) "<LaserMaterials>");
        for (int index1 = 0; index1 <= ((F_NestPartAdd) this).Materials.Count - 1; ++index1)
        {
          StringList.Add((object) "  <LaserMaterial>");
          StringList.Add((object) ("    " + ((F_NestPartAdd) this).Materials[index1].Name));
          for (int index2 = 0; index2 <= ((F_NestPartAdd) this).Materials[index1].Orders.Count - 1; ++index2)
            StringList.AddRange((ICollection) ((F_NestPartAdd) this).Materials[index1].Orders[index2].ToDefAll("", 4, SerilizationMode.MultiLine));
          StringList.Add((object) "  </LaserMaterial>");
        }
        StringList.Add((object) "</LaserMaterials>");
        buFile.SaveToFile(StringList, saveFileDialog.FileName);
      }
    }
    if (!(control2.Name == ((F_NestRectPartAdd) this).btn_open.Name))
      return;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = ((F_NestPartAdd) this).pathMaterialFile;
    openFileDialog.Filter = "Laser MaterialsSettings File (*.bulasmat)|*.bulasmat";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    ((F_NestPartAdd) this).Materials.Clear();
    ArrayList StringList1 = new ArrayList();
    buFile.OpenFromFile(openFileDialog.FileName, ref StringList1);
    List<List<string>> CalcList1 = new List<List<string>>();
    buString.ListToSpecificList("<LaserMaterial>", "</LaserMaterial>", true, StringList1, ref CalcList1);
    if (CalcList1.Count <= 0)
      return;
    for (int index3 = 0; index3 <= CalcList1.Count - 1; ++index3)
    {
      LaserMaterial laserMaterial = new LaserMaterial();
      laserMaterial.Name = CalcList1[index3][1];
      buSerilization.Decode(CalcList1[index3], "", SerilizationMode.MultiLine, (object) laserMaterial);
      List<List<string>> CalcList2 = new List<List<string>>();
      buString.ListToSpecificList("<LaserMaterialData>", "</LaserMaterialData>", true, CalcList1[index3], ref CalcList2);
      for (int index4 = 0; index4 <= CalcList2.Count - 1; ++index4)
      {
        LaserMaterialData laserMaterialData = new LaserMaterialData();
        buSerilization.Decode(CalcList2[index4], "", SerilizationMode.MultiLine, (object) laserMaterialData);
        laserMaterial.Orders.Add(laserMaterialData);
      }
      ((F_NestPartAdd) this).Materials.Add(laserMaterial);
    }
  }

  public void ChangeMinusPlusData(ref LaserMaterialData data)
  {
    data.FeedXMinus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXMinus;
    data.FeedXPlus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXPlus;
    data.FeedYMinus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedYMinus;
    data.FeedYPlus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedYPlus;
    data.FeedXY = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FeedXY;
    data.PowerXMinus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerXMinus;
    data.PowerXPlus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerXPlus;
    data.PowerYMinus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerYMinus;
    data.PowerYPlus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].PowerYPlus;
    data.FocusXMinus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXMinus;
    data.FocusXPlus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXPlus;
    data.FocusYMinus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusYMinus;
    data.FocusYPlus = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusYPlus;
    data.FocusXY = ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex].FocusXY;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestPartAdd) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestPartAdd) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestPartAdd) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_NestPartAdd) this).PropertiesForm.Inited || !(((F_NestPartAdd) this).\u0001.SelectedIndex >= 0 & ((F_NestPartAdd) this).\u0001.SelectedIndex <= ((F_NestPartAdd) this).Materials.Count - 1))
      return;
    \u0001.\u0002.\u0001(((F_NestPartAdd) this).\u0001.SelectedIndex, (F_LaserMaterial) this);
    if (((F_NestRectPartAdd) this).\u0002.Items.Count <= 0)
      return;
    ((F_NestRectPartAdd) this).\u0002.SelectedIndex = 0;
  }

  public void ValueToControls(LaserMaterialData props)
  {
    ((F_NestSheetAdd) this).\u0012.Value = (Decimal) props.Height;
    ((F_NestRectPartAdd) this).\u0002.Value = (Decimal) props.Acceleration;
    ((F_NestSheetAdd) this).\u0010.Value = (Decimal) props.Jerk;
    ((F_NestRectPartAdd) this).\u0001.Value = (Decimal) props.CuttingPower;
    ((F_NestRectPartAdd) this).\u0003.Value = (Decimal) props.EndPower;
    ((F_NestRectPartAdd) this).\u0002.Text = props.DefineationName;
    ((F_NestRectPartAdd) this).\u0005.Value = (Decimal) props.PowerDelayTime;
    ((F_NestRectPartAdd) this).\u0006.Value = (Decimal) props.PowerStopTime;
    ((F_NestRectPartAdd) this).\u0004.Value = (Decimal) props.StartPower;
    ((F_NestRectPartAdd) this).\u0002.Checked = props.ApplyAll;
    if (props.LaserSelect == LaserSelection.Laser1)
      ((F_NestSheetAdd) this).\u0003.Checked = true;
    if (props.LaserSelect == LaserSelection.Laser2)
      ((F_NestSheetAdd) this).\u0002.Checked = true;
    if (props.LaserSelect == LaserSelection.Laser3)
      ((F_NestSheetAdd) this).\u0001.Checked = true;
    for (int index = 0; index <= ((F_NestPartAdd) this).Cf2Properties.Count - 1; ++index)
    {
      if (props.PtRealValue == ((F_NestPartAdd) this).Cf2Properties[index].PtRealValue & props.CodeType == ((F_NestPartAdd) this).Cf2Properties[index].CodeType)
        ((F_NestRectPartAdd) this).\u0003.SelectedIndex = index;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_NestPartAdd) this).PropertiesForm.Inited || !(((F_NestRectPartAdd) this).\u0002.SelectedIndex >= 0 & ((F_NestRectPartAdd) this).\u0002.SelectedIndex <= ((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders.Count - 1))
      return;
    this.ValueToControls(new LaserMaterialData(((F_NestPartAdd) this).Materials[((F_NestPartAdd) this).\u0001.SelectedIndex].Orders[((F_NestRectPartAdd) this).\u0002.SelectedIndex]));
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestPartAdd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestPartAdd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event ApplyCommandWithDataEventHandler DataValueChanged;

  public event ApplyCommandWithDataEventHandler SelectedIndexChanged;
}
