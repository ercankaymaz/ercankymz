// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIPanel
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Forms.Customer.DincMak;
using buEyeBaseVer5.Forms.File;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIPanel : Form
{
  public Color SpinFocusColor;
  public ShapeAllData Data;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buTab buTab_shape;
  public TabPage tabPage_move;
  public TabPage tabPage_scale;
  internal PictureBox \u0001;
  public buSpin spn_movey;

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_RectangleShape) this).PropertiesForm.Inited || ((F_SlotShape) this).ValueChanging || AppBool.Calculation)
      return;
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_SlotShape) this).spn_blockhorcount.Name && ((F_RectangleShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_RectangleShape) this).\u0002((object) "HorizontalCount", (object) (double) ((F_SlotShape) this).spn_blockhorcount.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_SlotShape) this).spn_blockvercount.Name && ((F_RectangleShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_RectangleShape) this).\u0002((object) "VerticalCount", (object) (double) ((F_SlotShape) this).spn_blockvercount.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_LineShape) this).spn_cutvel.Name && ((F_RectangleShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_RectangleShape) this).\u0002((object) "VelCut", (object) (double) ((F_LineShape) this).spn_cutvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_LineShape) this).spn_leadinvel.Name && ((F_RectangleShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_RectangleShape) this).\u0002((object) "VelLeadIn", (object) (double) ((F_LineShape) this).spn_leadinvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_LineShape) this).spn_leadoutvel.Name && ((F_RectangleShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_RectangleShape) this).\u0002((object) "VelLeadOut", (object) (double) ((F_LineShape) this).spn_leadoutvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control.Name == ((F_LineShape) this).spn_connectionvel.Name) || ((F_RectangleShape) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_RectangleShape) this).\u0002((object) "VelConnection", (object) (double) ((F_LineShape) this).spn_connectionvel.Value);
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    double result = 0.0;
    if (((F_SlotShape) this).lst_idealwidth.SelectedIndex < 0)
      return;
    double.TryParse(((F_SlotShape) this).lst_idealwidth.Items[((F_SlotShape) this).lst_idealwidth.SelectedIndex].ToString(), out result);
    if (result <= 0.0)
      return;
    ((F_SlotShape) this).spn_blocktotalwidth.Value = (Decimal) (result + 0.1);
  }

  internal void \u0008([In] object obj0, [In] EventArgs obj1)
  {
    double result = 0.0;
    if (((F_SlotShape) this).lst_idealheight.SelectedIndex < 0)
      return;
    double.TryParse(((F_SlotShape) this).lst_idealheight.Items[((F_SlotShape) this).lst_idealheight.SelectedIndex].ToString(), out result);
    if (result <= 0.0)
      return;
    ((F_SlotShape) this).spn_blocktotalheight.Value = (Decimal) (result + 0.1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SlotShape) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SlotShape) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m001596();

  public F_ControlUIPanel()
  {
    ((F_VShapePocket) this).PropertiesForm = new FormProperties();
    ((F_VShapePocket) this).refImage = (Image) null;
    ((F_VShapePocket) this).Path = Application.StartupPath;
    ((F_VShapePocket) this).FileName = Application.StartupPath;
    ((F_VShapePocket) this).KeepRatio = true;
    ((F_VShapePocket) this).MoveEntities = true;
    ((F_VShapePocket) this).MoveReverse = false;
    ((F_VShapePocket) this).MoveRef = MinMaxType.Min;
    ((F_VShapePocket) this).ExtensionList = new List<string>();
    ((F_VShapePocket) this).\u0001 = new List<string>();
    ((F_VShapePocket) this).\u0001 = -1;
    ((F_VShapePocket) this).\u0002 = -1;
    ((F_VShapePocket) this).\u0001 = "";
    ((F_VShapePocket) this).\u0001 = false;
    ((F_VShapePocket) this).\u0002 = new List<string>();
    ((F_VShapePocket) this).\u0001 = (System.Windows.Forms.Timer) null;
    ((F_VShapePocket) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_AddImageFromFile) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ReadFile(OkCommandWithTwoDataEventHandler value)
  {
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_VShapePocket) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_VShapePocket) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ReadFile(OkCommandWithTwoDataEventHandler value)
  {
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_VShapePocket) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_VShapePocket) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_VShapePocket) this).PropertiesForm.Inited = false;
    if (((F_VShapePocket) this).PropertiesForm.Height > 10)
      this.Height = ((F_VShapePocket) this).PropertiesForm.Height;
    if (((F_VShapePocket) this).PropertiesForm.Width > 10)
      this.Width = ((F_VShapePocket) this).PropertiesForm.Width;
    this.TopMost = ((F_VShapePocket) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_VShapePocket) this).PropertiesForm.FormPosition;
    ((F_ControlUICheck) this).\u0001.Checked = ((F_VShapePocket) this).KeepRatio;
    this.LoadLanguage();
    ((F_ControlUICheck) this).grid_files.AllowUserToAddRows = false;
    ((F_ControlUICheck) this).grid_files.AllowUserToDeleteRows = false;
    ((F_ControlUICheck) this).grid_files.AllowUserToResizeRows = false;
    ((F_ControlUICheck) this).grid_files.RowHeadersVisible = false;
    ((F_ControlUICheck) this).grid_files.Columns.Clear();
    ((F_ControlUICheck) this).grid_files.Rows.Clear();
    ((F_ControlUICheck) this).grid_files.Columns.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 60;
    dataGridViewColumn1.HeaderText = "No";
    dataGridViewColumn1.Name = "No";
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_ControlUICheck) this).grid_files.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = 250;
    dataGridViewColumn2.HeaderText = "FileName";
    dataGridViewColumn2.Name = "FileName";
    dataGridViewColumn2.ReadOnly = true;
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_ControlUICheck) this).grid_files.Columns.Add(dataGridViewColumn2);
    ((F_VShapePocket) this).\u0001 = false;
    if (((F_VShapePocket) this).ExtensionList.Count == 0)
    {
      ((F_VShapePocket) this).ExtensionList.Add(".png");
      ((F_VShapePocket) this).ExtensionList.Add(".jpeg");
      ((F_VShapePocket) this).ExtensionList.Add(".jpg");
      ((F_VShapePocket) this).ExtensionList.Add(".bmp");
    }
    ((F_VShapePocket) this).\u0002 = new List<string>();
    for (int index1 = 0; index1 <= ((F_VShapePocket) this).ExtensionList.Count - 1; ++index1)
    {
      List<string> Files = new List<string>();
      buFile.GetFilesInDirectory(((F_VShapePocket) this).Path, ((F_VShapePocket) this).ExtensionList[index1], ref Files);
      for (int index2 = 0; index2 <= Files.Count - 1; ++index2)
        ((F_VShapePocket) this).\u0002.Add(Files[index2]);
    }
    \u0007.\u0001.\u0001((F_AddImageFromFile) this);
    if (((F_VShapePocket) this).\u0001 == null)
    {
      ((F_VShapePocket) this).\u0001 = new System.Windows.Forms.Timer();
      ((F_VShapePocket) this).\u0001.Tick += new EventHandler(this.Init_Tick);
      ((F_VShapePocket) this).\u0001.Interval = 100;
    }
    ((F_VShapePocket) this).\u0001.Enabled = true;
    ((F_VShapePocket) this).PropertiesForm.Result = DialogResult.None;
    ((F_VShapePocket) this).PropertiesForm.Inited = true;
  }

  public void Init_Tick(object sender, EventArgs e)
  {
    ((F_VShapePocket) this).\u0001.Enabled = false;
    if (((F_VShapePocket) this).\u0002.Count <= 0)
      return;
    ((F_ControlUICheck) this).grid_files.CurrentCell = ((F_ControlUICheck) this).grid_files.Rows[0].Cells[0];
    ((F_ControlUIListbox) this).\u0001((object) null, new DataGridViewCellEventArgs(0, 0));
  }

  public void LoadLanguage()
  {
    this.Text = $"{buLangTranslate.preDef.File} {buLangTranslate.preDef.Add}";
    ((F_VShapePocket) this).\u0002.Text = buLangTranslate.preDef.Files;
    ((F_ControlUICheck) this).\u0004.Text = buLangTranslate.preDef.Height;
    ((F_VShapePocket) this).\u0001.Text = buLangTranslate.preDef.Search;
    ((F_ControlUICheck) this).\u0003.Text = buLangTranslate.preDef.Width;
    ((F_VShapePocket) this).\u0003.Text = buLangTranslate.preDef.Cancel;
    ((F_VShapePocket) this).\u0001.Text = buLangTranslate.preDef.Folder;
    ((F_VShapePocket) this).\u0002.Text = buLangTranslate.preDef.Ok;
    ((F_ControlUICheck) this).\u000E.Text = $"{buLangTranslate.preDef.Other} {buLangTranslate.preDef.Files}";
    ((F_ControlUICheck) this).\u0008.Text = buLangTranslate.preDef.Delete;
    ((F_ControlUICheck) this).\u0001.Text = buLangTranslate.preDef.KeepRatio;
  }
}
