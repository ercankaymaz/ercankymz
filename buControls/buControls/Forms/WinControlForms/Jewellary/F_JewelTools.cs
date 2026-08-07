// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_JewelTools
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelTools : Form
{
  public DataTable DtSpindle = new DataTable();
  public DataTable DtEngraving = new DataTable();
  public DataTable DtDiamondCut1 = new DataTable();
  public DataTable DtDiamondCut2 = new DataTable();
  public DataTable DtLathe = new DataTable();
  public DataTable DtLaser = new DataTable();
  public DataColumn Col;
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public static List<string> CaptionGrid = new List<string>();
  public bool ShowPositions = false;
  public List<ToolBase> ToolSpindle = new List<ToolBase>();
  public List<ToolBase> ToolEngraving = new List<ToolBase>();
  public List<ToolBase> ToolDiamondCut1 = new List<ToolBase>();
  public List<ToolBase> ToolDiamondCut2 = new List<ToolBase>();
  public List<ToolBase> ToolLathe = new List<ToolBase>();
  public List<ToolBase> ToolLaser = new List<ToolBase>();
  public int selRowSpindle = 0;
  public int selRowEngraving = 0;
  public int selRowDiaCut1 = 0;
  public int selRowDiaCut2 = 0;
  public int selRowLathe = 0;
  public int selRowLaser = 0;
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal TabPage tabPage_3;
  internal TabPage tabPage_4;
  internal TabPage tabPage_5;
  internal ImageList imageList_0;
  public DataGridView DGV_Spindle;
  public DataGridView DGV_Engraving;
  public DataGridView DGV_DiamondCut1;
  public DataGridView DGV_DiamondCut2;
  public DataGridView DGV_Laser;
  public DataGridView DGV_Lathe;
  public Button btn_settoollen;
  public Button btn_setactivetool;
  public Button btn_toolchange;
  public Button btn_toolmeasure;
  public Button btn_addtool;
  public Button btn_removetool;
  public Button btn_save;
  public TabControl tabControl_tools;
  public Button btn_cancel;

  public F_JewelTools() => Class39.smethod_514(this);

  public event OkCommandEventHandler OkPressed;

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    this.DtSpindle = new DataTable();
    if (F_JewelTools.CaptionGrid.Count < 12)
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("Name", System.Type.GetType("System.String"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("Length", System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("XOffset", System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("YOffset", System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("ZOffset", System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("XPosition", System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("YPosition", System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn("ZPosition", System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
    }
    else
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[0], System.Type.GetType("System.String"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[1], System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[2], System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[3], System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[4], System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[5], System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[6], System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[7], System.Type.GetType("System.Double"));
      this.DtSpindle.Columns.Add(this.Col);
    }
    this.DGV_Spindle.DataSource = (object) this.DtSpindle;
    this.DGV_Spindle.RowHeadersVisible = false;
    this.DGV_Spindle.AllowUserToAddRows = false;
    this.DGV_Spindle.AllowUserToResizeColumns = false;
    this.DGV_Spindle.Columns[0].Width = 40;
    this.DGV_Spindle.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[1].Width = 250;
    this.DGV_Spindle.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[2].Width = 100;
    this.DGV_Spindle.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[3].Width = 100;
    this.DGV_Spindle.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[4].Width = 100;
    this.DGV_Spindle.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[5].Width = 100;
    this.DGV_Spindle.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[6].Width = 100;
    this.DGV_Spindle.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[7].Width = 100;
    this.DGV_Spindle.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[8].Width = 100;
    this.DGV_Spindle.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Spindle.Columns[6].Visible = this.ShowPositions;
    this.DGV_Spindle.Columns[7].Visible = this.ShowPositions;
    this.DGV_Spindle.Columns[8].Visible = this.ShowPositions;
    this.DtEngraving = new DataTable();
    if (F_JewelTools.CaptionGrid.Count < 12)
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn("Name", System.Type.GetType("System.String"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn("Length", System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn("XOffset", System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn("YOffset", System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn("ZOffset", System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
    }
    else
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[0], System.Type.GetType("System.String"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[1], System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[2], System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[3], System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[4], System.Type.GetType("System.Double"));
      this.DtEngraving.Columns.Add(this.Col);
    }
    this.DGV_Engraving.DataSource = (object) this.DtEngraving;
    this.DGV_Engraving.RowHeadersVisible = false;
    this.DGV_Engraving.AllowUserToAddRows = false;
    this.DGV_Engraving.AllowUserToResizeColumns = false;
    this.DGV_Engraving.Columns[0].Width = 40;
    this.DGV_Engraving.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Engraving.Columns[1].Width = 250;
    this.DGV_Engraving.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Engraving.Columns[2].Width = 100;
    this.DGV_Engraving.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Engraving.Columns[3].Width = 100;
    this.DGV_Engraving.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Engraving.Columns[4].Width = 100;
    this.DGV_Engraving.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Engraving.Columns[5].Width = 100;
    this.DGV_Engraving.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DtDiamondCut1 = new DataTable();
    if (F_JewelTools.CaptionGrid.Count < 12)
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn("Name", System.Type.GetType("System.String"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn("Length", System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn("XOffset", System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn("YOffset", System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn("ZOffset", System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
    }
    else
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[0], System.Type.GetType("System.String"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[1], System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[2], System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[3], System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[4], System.Type.GetType("System.Double"));
      this.DtDiamondCut1.Columns.Add(this.Col);
    }
    this.DGV_DiamondCut1.DataSource = (object) this.DtDiamondCut1;
    this.DGV_DiamondCut1.RowHeadersVisible = false;
    this.DGV_DiamondCut1.AllowUserToAddRows = false;
    this.DGV_DiamondCut1.AllowUserToResizeColumns = false;
    this.DGV_DiamondCut1.Columns[0].Width = 40;
    this.DGV_DiamondCut1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut1.Columns[1].Width = 250;
    this.DGV_DiamondCut1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut1.Columns[2].Width = 100;
    this.DGV_DiamondCut1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut1.Columns[3].Width = 100;
    this.DGV_DiamondCut1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut1.Columns[4].Width = 100;
    this.DGV_DiamondCut1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut1.Columns[5].Width = 100;
    this.DGV_DiamondCut1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DtDiamondCut2 = new DataTable();
    if (F_JewelTools.CaptionGrid.Count < 12)
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn("Name", System.Type.GetType("System.String"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn("Length", System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn("XOffset", System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn("YOffset", System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn("ZOffset", System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
    }
    else
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[0], System.Type.GetType("System.String"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[1], System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[2], System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[3], System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[4], System.Type.GetType("System.Double"));
      this.DtDiamondCut2.Columns.Add(this.Col);
    }
    this.DGV_DiamondCut2.DataSource = (object) this.DtDiamondCut2;
    this.DGV_DiamondCut2.RowHeadersVisible = false;
    this.DGV_DiamondCut2.AllowUserToAddRows = false;
    this.DGV_DiamondCut2.AllowUserToResizeColumns = false;
    this.DGV_DiamondCut2.Columns[0].Width = 40;
    this.DGV_DiamondCut2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut2.Columns[1].Width = 250;
    this.DGV_DiamondCut2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut2.Columns[2].Width = 100;
    this.DGV_DiamondCut2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut2.Columns[3].Width = 100;
    this.DGV_DiamondCut2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut2.Columns[4].Width = 100;
    this.DGV_DiamondCut2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_DiamondCut2.Columns[5].Width = 100;
    this.DGV_DiamondCut2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DtLathe = new DataTable();
    if (F_JewelTools.CaptionGrid.Count < 12)
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn("Name", System.Type.GetType("System.String"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn("Length", System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn("XOffset", System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn("YOffset", System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn("ZOffset", System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
    }
    else
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[0], System.Type.GetType("System.String"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[1], System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[2], System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[3], System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[4], System.Type.GetType("System.Double"));
      this.DtLathe.Columns.Add(this.Col);
    }
    this.DGV_Lathe.DataSource = (object) this.DtLathe;
    this.DGV_Lathe.RowHeadersVisible = false;
    this.DGV_Lathe.AllowUserToAddRows = false;
    this.DGV_Lathe.AllowUserToResizeColumns = false;
    this.DGV_Lathe.Columns[0].Width = 40;
    this.DGV_Lathe.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Lathe.Columns[1].Width = 250;
    this.DGV_Lathe.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Lathe.Columns[2].Width = 100;
    this.DGV_Lathe.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Lathe.Columns[3].Width = 100;
    this.DGV_Lathe.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Lathe.Columns[4].Width = 100;
    this.DGV_Lathe.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Lathe.Columns[5].Width = 100;
    this.DGV_Lathe.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DtLaser = new DataTable();
    if (F_JewelTools.CaptionGrid.Count < 12)
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn("Name", System.Type.GetType("System.String"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn("Length", System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn("XOffset", System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn("YOffset", System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn("ZOffset", System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
    }
    else
    {
      this.Col = new DataColumn("No", System.Type.GetType("System.Int32"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[0], System.Type.GetType("System.String"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[1], System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[2], System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[3], System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
      this.Col = new DataColumn(F_JewelTools.CaptionGrid[4], System.Type.GetType("System.Double"));
      this.DtLaser.Columns.Add(this.Col);
    }
    this.DGV_Laser.DataSource = (object) this.DtLaser;
    this.DGV_Laser.RowHeadersVisible = false;
    this.DGV_Laser.AllowUserToAddRows = false;
    this.DGV_Laser.AllowUserToResizeColumns = false;
    this.DGV_Laser.Columns[0].Width = 40;
    this.DGV_Laser.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Laser.Columns[1].Width = 250;
    this.DGV_Laser.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Laser.Columns[2].Width = 100;
    this.DGV_Laser.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Laser.Columns[3].Width = 100;
    this.DGV_Laser.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Laser.Columns[4].Width = 100;
    this.DGV_Laser.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    this.DGV_Laser.Columns[5].Width = 100;
    this.DGV_Laser.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    for (int index = 0; index <= this.ToolSpindle.Count - 1; ++index)
      this.DtSpindle.Rows.Add(this.AddNewSpindleToolRow(ref this.DtSpindle, index + 1, this.ToolSpindle[index]));
    for (int index = 0; index <= this.ToolDiamondCut1.Count - 1; ++index)
      this.DtDiamondCut1.Rows.Add(this.AddNewToolRow(ref this.DtDiamondCut1, index + 1, this.ToolDiamondCut1[index]));
    for (int index = 0; index <= this.ToolDiamondCut2.Count - 1; ++index)
      this.DtDiamondCut2.Rows.Add(this.AddNewToolRow(ref this.DtDiamondCut2, index + 1, this.ToolDiamondCut2[index]));
    for (int index = 0; index <= this.ToolEngraving.Count - 1; ++index)
      this.DtEngraving.Rows.Add(this.AddNewToolRow(ref this.DtEngraving, index + 1, this.ToolEngraving[index]));
    for (int index = 0; index <= this.ToolLaser.Count - 1; ++index)
      this.DtLaser.Rows.Add(this.AddNewToolRow(ref this.DtLaser, index + 1, this.ToolLaser[index]));
    for (int index = 0; index <= this.ToolLathe.Count - 1; ++index)
      this.DtLathe.Rows.Add(this.AddNewToolRow(ref this.DtLathe, index + 1, this.ToolLathe[index]));
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, DataGridViewCellEventArgs e)
  {
    DataGridView dataGridView1 = new DataGridView();
    DataGridView dataGridView2 = (DataGridView) sender;
    if (e.RowIndex < 0)
      return;
    if (dataGridView2.Name == this.DGV_Spindle.Name)
      this.selRowSpindle = e.RowIndex;
    if (dataGridView2.Name == this.DGV_Engraving.Name)
      this.selRowEngraving = e.RowIndex;
    if (dataGridView2.Name == this.DGV_DiamondCut1.Name)
      this.selRowDiaCut1 = e.RowIndex;
    if (dataGridView2.Name == this.DGV_DiamondCut2.Name)
      this.selRowDiaCut2 = e.RowIndex;
    if (dataGridView2.Name == this.DGV_Lathe.Name)
      this.selRowLathe = e.RowIndex;
    if (!(dataGridView2.Name == this.DGV_Laser.Name))
      return;
    this.selRowLaser = e.RowIndex;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_save.Name)
    {
      this.SaveTools();
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandEventHandler_0();
      }
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void SaveTools()
  {
    this.ToolSpindle.Clear();
    for (int index = 0; index <= this.DGV_Spindle.Rows.Count - 1; ++index)
      this.ToolSpindle.Add(new ToolBase()
      {
        Data = {
          No = index + 1,
          Name = this.DGV_Spindle.Rows[index].Cells[1].Value.ToString()
        },
        Geometry = {
          Length = Convert.ToDouble(this.DGV_Spindle.Rows[index].Cells[2].Value)
        },
        Positions = {
          Offset = new Pnt6D(Convert.ToDouble(this.DGV_Spindle.Rows[index].Cells[3].Value), Convert.ToDouble(this.DGV_Spindle.Rows[index].Cells[4].Value), Convert.ToDouble(this.DGV_Spindle.Rows[index].Cells[5].Value)),
          Position = new Pnt6D(Convert.ToDouble(this.DGV_Spindle.Rows[index].Cells[6].Value), Convert.ToDouble(this.DGV_Spindle.Rows[index].Cells[7].Value), Convert.ToDouble(this.DGV_Spindle.Rows[index].Cells[8].Value))
        }
      });
    this.ToolDiamondCut1.Clear();
    for (int index = 0; index <= this.DGV_DiamondCut1.Rows.Count - 1; ++index)
      this.ToolDiamondCut1.Add(new ToolBase()
      {
        Data = {
          No = index + 1,
          Name = this.DGV_DiamondCut1.Rows[index].Cells[1].Value.ToString()
        },
        Geometry = {
          Length = Convert.ToDouble(this.DGV_DiamondCut1.Rows[index].Cells[2].Value)
        },
        Positions = {
          Offset = new Pnt6D(Convert.ToDouble(this.DGV_DiamondCut1.Rows[index].Cells[3].Value), Convert.ToDouble(this.DGV_DiamondCut1.Rows[index].Cells[4].Value), Convert.ToDouble(this.DGV_DiamondCut1.Rows[index].Cells[5].Value))
        }
      });
    this.ToolDiamondCut2.Clear();
    for (int index = 0; index <= this.DGV_DiamondCut2.Rows.Count - 1; ++index)
      this.ToolDiamondCut2.Add(new ToolBase()
      {
        Data = {
          No = index + 1,
          Name = this.DGV_DiamondCut2.Rows[index].Cells[1].Value.ToString()
        },
        Geometry = {
          Length = Convert.ToDouble(this.DGV_DiamondCut2.Rows[index].Cells[2].Value)
        },
        Positions = {
          Offset = new Pnt6D(Convert.ToDouble(this.DGV_DiamondCut2.Rows[index].Cells[3].Value), Convert.ToDouble(this.DGV_DiamondCut2.Rows[index].Cells[4].Value), Convert.ToDouble(this.DGV_DiamondCut2.Rows[index].Cells[5].Value))
        }
      });
    this.ToolEngraving.Clear();
    for (int index = 0; index <= this.DGV_Engraving.Rows.Count - 1; ++index)
      this.ToolEngraving.Add(new ToolBase()
      {
        Data = {
          No = index + 1,
          Name = this.DGV_Engraving.Rows[index].Cells[1].Value.ToString()
        },
        Geometry = {
          Length = Convert.ToDouble(this.DGV_Engraving.Rows[index].Cells[2].Value)
        },
        Positions = {
          Offset = new Pnt6D(Convert.ToDouble(this.DGV_Engraving.Rows[index].Cells[3].Value), Convert.ToDouble(this.DGV_Engraving.Rows[index].Cells[4].Value), Convert.ToDouble(this.DGV_Engraving.Rows[index].Cells[5].Value))
        }
      });
    this.ToolLaser.Clear();
    for (int index = 0; index <= this.DGV_Laser.Rows.Count - 1; ++index)
      this.ToolLaser.Add(new ToolBase()
      {
        Data = {
          No = index + 1,
          Name = this.DGV_Laser.Rows[index].Cells[1].Value.ToString()
        },
        Geometry = {
          Length = Convert.ToDouble(this.DGV_Laser.Rows[index].Cells[2].Value)
        },
        Positions = {
          Offset = new Pnt6D(Convert.ToDouble(this.DGV_Laser.Rows[index].Cells[3].Value), Convert.ToDouble(this.DGV_Laser.Rows[index].Cells[4].Value), Convert.ToDouble(this.DGV_Laser.Rows[index].Cells[5].Value))
        }
      });
    this.ToolLathe.Clear();
    for (int index = 0; index <= this.DGV_Lathe.Rows.Count - 1; ++index)
      this.ToolLathe.Add(new ToolBase()
      {
        Data = {
          No = index + 1,
          Name = this.DGV_Lathe.Rows[index].Cells[1].Value.ToString()
        },
        Geometry = {
          Length = Convert.ToDouble(this.DGV_Lathe.Rows[index].Cells[2].Value)
        },
        Positions = {
          Offset = new Pnt6D(Convert.ToDouble(this.DGV_Lathe.Rows[index].Cells[3].Value), Convert.ToDouble(this.DGV_Lathe.Rows[index].Cells[4].Value), Convert.ToDouble(this.DGV_Lathe.Rows[index].Cells[5].Value))
        }
      });
  }

  public DataRow AddNewToolRow(ref DataTable dt, int index, ToolBase tool)
  {
    DataRow dataRow = dt.NewRow();
    dataRow[0] = (object) index;
    dataRow[1] = (object) tool.Data.Name;
    dataRow[2] = (object) Math.Round(tool.Geometry.Length, 2);
    dataRow[3] = (object) Math.Round(tool.Positions.Offset.X, 2);
    dataRow[4] = (object) Math.Round(tool.Positions.Offset.Y, 2);
    dataRow[5] = (object) Math.Round(tool.Positions.Offset.Z, 2);
    return dataRow;
  }

  public DataRow AddNewSpindleToolRow(ref DataTable dt, int index, ToolBase tool)
  {
    DataRow dataRow = dt.NewRow();
    dataRow[0] = (object) index;
    dataRow[1] = (object) tool.Data.Name;
    dataRow[2] = (object) Math.Round(tool.Geometry.Length, 2);
    dataRow[3] = (object) Math.Round(tool.Positions.Offset.X, 2);
    dataRow[4] = (object) Math.Round(tool.Positions.Offset.Y, 2);
    dataRow[5] = (object) Math.Round(tool.Positions.Offset.Z, 2);
    dataRow[6] = (object) Math.Round(tool.Positions.Position.X, 2);
    dataRow[7] = (object) Math.Round(tool.Positions.Position.Y, 2);
    dataRow[8] = (object) Math.Round(tool.Positions.Position.Z, 2);
    return dataRow;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
