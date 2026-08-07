// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Drill.F_Tools
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Drill;

public class F_Tools : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public Design viewportRight = (Design) null;
  public Design viewportLeft = (Design) null;
  public Design viewportBottom = (Design) null;
  public DrillRuntimeSettings settingRuntime = new DrillRuntimeSettings();
  public string fileNameLeftTools = Application.StartupPath;
  public string fileNameRightTools = Application.StartupPath;
  public string fileNameBottomTools = Application.StartupPath;
  public bool ShowXOffset = true;
  public bool ShowYOffset = true;
  public bool ShowZOffset = false;
  public bool CommonOffset = false;
  public bool ShowYLimit = true;
  public bool UseCommponOffsetToolDrawing = false;
  public bool ShowPlungeSpeed = false;
  public bool ShowWaitTime = false;
  public bool isGo = false;
  public bool isSirius = false;
  private Timer timer_0 = new Timer();
  private IContainer icontainer_0 = (IContainer) null;
  internal DataGridView dataGridView_0;
  public Panel pnl_viewportbottom;
  internal ImageList imageList_0;
  public Panel pnl_viewportright;
  public Panel pnl_viewportleft;
  internal DataGridView dataGridView_1;
  internal DataGridView dataGridView_2;
  internal CheckBox checkBox_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal Button button_0;
  internal Button button_1;
  public Button button1;
  public Button button2;
  public TabControl tabControl1;
  public Button btn_opentools;
  public Button btn_savetools;
  internal CheckBox checkBox_1;

  public F_Tools()
  {
    Class5.smethod_210(this);
    this.timer_0.Interval = 500;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.LoadLanguage();
    if (this.viewportRight != null && this.viewportRight.Entities.Count == 0)
    {
      this.viewportRight.MouseDown += new MouseEventHandler(this.viewportBottom_MouseDown);
      if (new FileInfo(this.fileNameRightTools).Exists)
      {
        clsInit.cVector5.ReadStepFile(this.fileNameRightTools, ref this.viewportRight);
        for (int index = 0; index <= this.viewportRight.Entities.Count - 1; ++index)
          this.viewportRight.Entities[index].Selectable = false;
      }
    }
    if (this.viewportLeft != null && this.viewportLeft.Entities.Count == 0)
    {
      this.viewportLeft.MouseDown += new MouseEventHandler(this.viewportBottom_MouseDown);
      if (new FileInfo(this.fileNameLeftTools).Exists)
      {
        clsInit.cVector5.ReadStepFile(this.fileNameLeftTools, ref this.viewportLeft);
        for (int index = 0; index <= this.viewportLeft.Entities.Count - 1; ++index)
          this.viewportLeft.Entities[index].Selectable = false;
      }
    }
    if (this.viewportBottom != null && this.viewportBottom.Entities.Count == 0)
    {
      this.viewportBottom.MouseDown += new MouseEventHandler(this.viewportBottom_MouseDown);
      if (new FileInfo(this.fileNameBottomTools).Exists)
      {
        clsInit.cVector5.ReadStepFile(this.fileNameBottomTools, ref this.viewportBottom);
        for (int index = 0; index <= this.viewportBottom.Entities.Count - 1; ++index)
          this.viewportBottom.Entities[index].Selectable = false;
      }
    }
    if (this.viewportRight != null)
    {
      if (this.dataGridView_1.Columns.Count == 0)
      {
        DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
        dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn1.Width = 40;
        dataGridViewColumn1.HeaderText = "No";
        dataGridViewColumn1.Name = "No";
        dataGridViewColumn1.ReadOnly = true;
        dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn1);
        DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
        dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn2.Width = 80 /*0x50*/;
        dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Diameter;
        dataGridViewColumn2.Name = buLangTranslate.preDef.Diameter;
        dataGridViewColumn2.ReadOnly = false;
        dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn2);
        DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
        dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn3.Width = 80 /*0x50*/;
        dataGridViewColumn3.HeaderText = $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length}";
        dataGridViewColumn3.Name = $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length}";
        dataGridViewColumn3.ReadOnly = false;
        dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn3);
        DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
        dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn4.Width = 80 /*0x50*/;
        dataGridViewColumn4.HeaderText = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Length}";
        dataGridViewColumn4.Name = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Length}";
        dataGridViewColumn4.ReadOnly = false;
        dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn4);
        DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
        dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn5.Width = 80 /*0x50*/;
        dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Offset + " X";
        dataGridViewColumn5.Name = buLangTranslate.preDef.Offset + " X";
        dataGridViewColumn5.ReadOnly = false;
        dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn5.Visible = this.ShowXOffset;
        dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn5);
        DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
        dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn6.Width = 80 /*0x50*/;
        dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Offset + " Y";
        dataGridViewColumn6.Name = buLangTranslate.preDef.Offset + " Y";
        dataGridViewColumn6.ReadOnly = false;
        dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn6.Visible = this.ShowYOffset;
        dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn6);
        DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
        dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn7.Width = 80 /*0x50*/;
        dataGridViewColumn7.HeaderText = buLangTranslate.preDef.Offset + " Z";
        dataGridViewColumn7.Name = buLangTranslate.preDef.Offset + " Z";
        dataGridViewColumn7.ReadOnly = false;
        dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn7.Visible = this.ShowZOffset;
        dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn7);
        DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
        dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn8.Width = 80 /*0x50*/;
        dataGridViewColumn8.HeaderText = buLangTranslate.preDef.Limit + " Y";
        dataGridViewColumn8.Name = buLangTranslate.preDef.Limit + " Y";
        dataGridViewColumn8.ReadOnly = false;
        dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn8.Visible = this.ShowYLimit;
        dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn8);
        DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
        dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn9.Width = 80 /*0x50*/;
        dataGridViewColumn9.HeaderText = buLangTranslate.preDef.Plunge;
        dataGridViewColumn9.Name = buLangTranslate.preDef.Plunge;
        dataGridViewColumn9.ReadOnly = false;
        dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn9.Visible = this.ShowPlungeSpeed;
        dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn9);
        DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
        dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn10.Width = 80 /*0x50*/;
        dataGridViewColumn10.HeaderText = buLangTranslate.preDef.Wait;
        dataGridViewColumn10.Name = buLangTranslate.preDef.Wait;
        dataGridViewColumn10.ReadOnly = false;
        dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn10.Visible = this.ShowPlungeSpeed;
        dataGridViewColumn10.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_1.Columns.Add(dataGridViewColumn10);
      }
      this.dataGridView_1.RowHeadersVisible = false;
      this.dataGridView_1.AllowUserToAddRows = false;
      this.dataGridView_1.AllowUserToResizeColumns = false;
      this.dataGridView_1.AllowUserToResizeRows = false;
    }
    if (this.viewportLeft != null)
    {
      if (this.dataGridView_0.Columns.Count == 0)
      {
        DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
        dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn11.Width = 40;
        dataGridViewColumn11.HeaderText = "No";
        dataGridViewColumn11.Name = "No";
        dataGridViewColumn11.ReadOnly = true;
        dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn11.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn11);
        DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
        dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn12.Width = 80 /*0x50*/;
        dataGridViewColumn12.HeaderText = buLangTranslate.preDef.Diameter;
        dataGridViewColumn12.Name = buLangTranslate.preDef.Diameter;
        dataGridViewColumn12.ReadOnly = false;
        dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn12.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn12);
        DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
        dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn13.Width = 80 /*0x50*/;
        dataGridViewColumn13.HeaderText = $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length}";
        dataGridViewColumn13.Name = $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length}";
        dataGridViewColumn13.ReadOnly = false;
        dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn13.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn13);
        DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
        dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn14.Width = 80 /*0x50*/;
        dataGridViewColumn14.HeaderText = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Length}";
        dataGridViewColumn14.Name = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Length}";
        dataGridViewColumn14.ReadOnly = false;
        dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn14.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn14);
        DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
        dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn15.Width = 80 /*0x50*/;
        dataGridViewColumn15.HeaderText = buLangTranslate.preDef.Offset + " X";
        dataGridViewColumn15.Name = buLangTranslate.preDef.Offset + " X";
        dataGridViewColumn15.ReadOnly = false;
        dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn15.Visible = this.ShowXOffset;
        dataGridViewColumn15.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn15);
        DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
        dataGridViewColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn16.Width = 80 /*0x50*/;
        dataGridViewColumn16.HeaderText = buLangTranslate.preDef.Offset + " Y";
        dataGridViewColumn16.Name = buLangTranslate.preDef.Offset + " Y";
        dataGridViewColumn16.ReadOnly = false;
        dataGridViewColumn16.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn16.Visible = this.ShowYOffset;
        dataGridViewColumn16.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn16);
        DataGridViewColumn dataGridViewColumn17 = new DataGridViewColumn();
        dataGridViewColumn17.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn17.Width = 80 /*0x50*/;
        dataGridViewColumn17.HeaderText = buLangTranslate.preDef.Offset + " Z";
        dataGridViewColumn17.Name = buLangTranslate.preDef.Offset + " Z";
        dataGridViewColumn17.ReadOnly = false;
        dataGridViewColumn17.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn17.Visible = this.ShowZOffset;
        dataGridViewColumn17.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn17);
        DataGridViewColumn dataGridViewColumn18 = new DataGridViewColumn();
        dataGridViewColumn18.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn18.Width = 80 /*0x50*/;
        dataGridViewColumn18.HeaderText = buLangTranslate.preDef.Limit + " Y";
        dataGridViewColumn18.Name = buLangTranslate.preDef.Limit + " Y";
        dataGridViewColumn18.ReadOnly = false;
        dataGridViewColumn18.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn18.Visible = this.ShowYLimit;
        dataGridViewColumn18.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn18);
        DataGridViewColumn dataGridViewColumn19 = new DataGridViewColumn();
        dataGridViewColumn19.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn19.Width = 80 /*0x50*/;
        dataGridViewColumn19.HeaderText = buLangTranslate.preDef.Plunge;
        dataGridViewColumn19.Name = buLangTranslate.preDef.Plunge;
        dataGridViewColumn19.ReadOnly = false;
        dataGridViewColumn19.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn19.Visible = this.ShowPlungeSpeed;
        dataGridViewColumn19.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn19);
        DataGridViewColumn dataGridViewColumn20 = new DataGridViewColumn();
        dataGridViewColumn20.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn20.Width = 80 /*0x50*/;
        dataGridViewColumn20.HeaderText = buLangTranslate.preDef.Wait;
        dataGridViewColumn20.Name = buLangTranslate.preDef.Wait;
        dataGridViewColumn20.ReadOnly = false;
        dataGridViewColumn20.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn20.Visible = this.ShowPlungeSpeed;
        dataGridViewColumn20.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_0.Columns.Add(dataGridViewColumn20);
      }
      this.dataGridView_0.RowHeadersVisible = false;
      this.dataGridView_0.AllowUserToAddRows = false;
      this.dataGridView_0.AllowUserToResizeColumns = false;
      this.dataGridView_0.AllowUserToResizeRows = false;
    }
    if (this.viewportBottom != null)
    {
      if (this.dataGridView_2.Columns.Count == 0)
      {
        DataGridViewColumn dataGridViewColumn21 = new DataGridViewColumn();
        dataGridViewColumn21.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn21.Width = 40;
        dataGridViewColumn21.HeaderText = "No";
        dataGridViewColumn21.Name = "No";
        dataGridViewColumn21.ReadOnly = true;
        dataGridViewColumn21.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn21.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn21);
        DataGridViewColumn dataGridViewColumn22 = new DataGridViewColumn();
        dataGridViewColumn22.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn22.Width = 80 /*0x50*/;
        dataGridViewColumn22.HeaderText = buLangTranslate.preDef.Diameter;
        dataGridViewColumn22.Name = buLangTranslate.preDef.Diameter;
        dataGridViewColumn22.ReadOnly = false;
        dataGridViewColumn22.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn22.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn22);
        DataGridViewColumn dataGridViewColumn23 = new DataGridViewColumn();
        dataGridViewColumn23.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn23.Width = 80 /*0x50*/;
        dataGridViewColumn23.HeaderText = $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length}";
        dataGridViewColumn23.Name = $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length}";
        dataGridViewColumn23.ReadOnly = false;
        dataGridViewColumn23.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn23.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn23);
        DataGridViewColumn dataGridViewColumn24 = new DataGridViewColumn();
        dataGridViewColumn24.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn24.Width = 80 /*0x50*/;
        dataGridViewColumn24.HeaderText = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Length}";
        dataGridViewColumn24.Name = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Length}";
        dataGridViewColumn24.ReadOnly = false;
        dataGridViewColumn24.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn24.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn24);
        DataGridViewColumn dataGridViewColumn25 = new DataGridViewColumn();
        dataGridViewColumn25.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn25.Width = 80 /*0x50*/;
        dataGridViewColumn25.HeaderText = buLangTranslate.preDef.Offset + " X";
        dataGridViewColumn25.Name = buLangTranslate.preDef.Offset + " X";
        dataGridViewColumn25.ReadOnly = false;
        dataGridViewColumn25.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn25.Visible = this.ShowXOffset;
        dataGridViewColumn25.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn25);
        DataGridViewColumn dataGridViewColumn26 = new DataGridViewColumn();
        dataGridViewColumn26.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn26.Width = 80 /*0x50*/;
        dataGridViewColumn26.HeaderText = buLangTranslate.preDef.Offset + " Y";
        dataGridViewColumn26.Name = buLangTranslate.preDef.Offset + " Y";
        dataGridViewColumn26.ReadOnly = false;
        dataGridViewColumn26.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn26.Visible = this.ShowYOffset;
        dataGridViewColumn26.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn26);
        DataGridViewColumn dataGridViewColumn27 = new DataGridViewColumn();
        dataGridViewColumn27.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn27.Width = 80 /*0x50*/;
        dataGridViewColumn27.HeaderText = buLangTranslate.preDef.Offset + " Z";
        dataGridViewColumn27.Name = buLangTranslate.preDef.Offset + " Z";
        dataGridViewColumn27.ReadOnly = false;
        dataGridViewColumn27.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn27.Visible = this.ShowZOffset;
        dataGridViewColumn27.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn27);
        DataGridViewColumn dataGridViewColumn28 = new DataGridViewColumn();
        dataGridViewColumn28.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn28.Width = 80 /*0x50*/;
        dataGridViewColumn28.HeaderText = buLangTranslate.preDef.Limit + " Y";
        dataGridViewColumn28.Name = buLangTranslate.preDef.Limit + " Y";
        dataGridViewColumn28.ReadOnly = false;
        dataGridViewColumn28.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn28.Visible = this.ShowYLimit;
        dataGridViewColumn28.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn28);
        DataGridViewColumn dataGridViewColumn29 = new DataGridViewColumn();
        dataGridViewColumn29.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn29.Width = 80 /*0x50*/;
        dataGridViewColumn29.HeaderText = buLangTranslate.preDef.Plunge;
        dataGridViewColumn29.Name = buLangTranslate.preDef.Plunge;
        dataGridViewColumn29.ReadOnly = false;
        dataGridViewColumn29.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn29.Visible = this.ShowPlungeSpeed;
        dataGridViewColumn29.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn29);
        DataGridViewColumn dataGridViewColumn30 = new DataGridViewColumn();
        dataGridViewColumn30.SortMode = DataGridViewColumnSortMode.NotSortable;
        dataGridViewColumn30.Width = 80 /*0x50*/;
        dataGridViewColumn30.HeaderText = buLangTranslate.preDef.Wait;
        dataGridViewColumn30.Name = buLangTranslate.preDef.Wait;
        dataGridViewColumn30.ReadOnly = false;
        dataGridViewColumn30.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
        dataGridViewColumn30.Visible = this.ShowPlungeSpeed;
        dataGridViewColumn30.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
        this.dataGridView_2.Columns.Add(dataGridViewColumn30);
      }
      this.dataGridView_2.RowHeadersVisible = false;
      this.dataGridView_2.AllowUserToAddRows = false;
      this.dataGridView_2.AllowUserToResizeColumns = false;
      this.dataGridView_2.AllowUserToResizeRows = false;
    }
    if (this.viewportLeft != null)
    {
      this.viewportLeft.ActiveViewport.DisplayMode = displayType.Rendered;
      this.viewportLeft.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    if (this.viewportRight != null)
    {
      this.viewportRight.ActiveViewport.DisplayMode = displayType.Rendered;
      this.viewportRight.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    if (this.viewportBottom != null)
    {
      this.viewportBottom.ActiveViewport.DisplayMode = displayType.Rendered;
      this.viewportBottom.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    this.checkBox_1.Checked = this.settingRuntime.ToolExpertMode;
    this.ExpertMoveView(this.settingRuntime.ToolExpertMode);
    this.DrawEntities(true, -1);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    this.timer_0.Enabled = true;
  }

  public void LoadLanguage()
  {
    this.Text = buLangTranslate.preDef.Tools;
    if (clsInit.appDrill.MachType == DrillMachineType.GoWithAtc | clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc | clsInit.appDrill.MachType == DrillMachineType.Sirius)
      this.tabPage_0.Text = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Head}";
    else if (clsInit.appDrill.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
    {
      this.tabPage_0.Text = $"{buLangTranslate.preDef.Top} Y1 {buLangTranslate.preDef.Head}";
      this.tabPage_1.Text = $"{buLangTranslate.preDef.Top} Y2 {buLangTranslate.preDef.Head}";
      this.tabPage_2.Text = $"{buLangTranslate.preDef.Bottom} Y3 {buLangTranslate.preDef.Head}";
    }
    this.checkBox_0.Text = $"{buLangTranslate.preDef.Common} {buLangTranslate.preDef.Offset}";
    this.checkBox_1.Text = $"{buLangTranslate.preDef.Expert} {buLangTranslate.preDef.Mode}";
    this.btn_opentools.Text = $"{buLangTranslate.preDef.Tools} {buLangTranslate.preDef.Open}";
    this.btn_savetools.Text = $"{buLangTranslate.preDef.Tools} {buLangTranslate.preDef.Save}";
    this.button_0.Text = buLangTranslate.preDef.Ok;
    this.button_1.Text = buLangTranslate.preDef.Cancel;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    if (this.viewportLeft != null && this.viewportLeft.IsHandleCreated)
    {
      this.viewportLeft.SetView(viewType.Bottom, true, false);
      this.viewportLeft.Invalidate();
      this.timer_0.Enabled = false;
    }
    if (this.viewportRight != null && this.viewportRight.IsHandleCreated)
    {
      if (!this.isSirius)
      {
        this.viewportRight.SetView(viewType.Bottom, true, false);
        this.viewportRight.Invalidate();
      }
      else
      {
        this.viewportRight.SetView(viewType.Top, true, false);
        this.viewportRight.Invalidate();
      }
      this.timer_0.Enabled = false;
    }
    if (this.viewportBottom == null || !this.viewportBottom.IsHandleCreated)
      return;
    this.viewportBottom.SetView(viewType.Top, true, false);
    this.viewportBottom.Invalidate();
    this.timer_0.Enabled = false;
  }

  internal void method_1(object sender, DataGridViewCellEventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.dataGridView_1.Name && e.RowIndex >= 0 & e.ColumnIndex >= 0)
    {
      string str = this.dataGridView_1.Rows[e.RowIndex].Cells[0].Value.ToString();
      int ToolNo = int.Parse(str);
      int Index = -1;
      this.FindToolIndexFromToolNo(ToolNo, ref Index);
      if (Index >= 0)
        this.FindToolMeshFromToolNo(str, clsDrill.ToolList[Index].Data.GroupIndex);
    }
    if (control2.Name == this.dataGridView_0.Name && e.RowIndex >= 0 & e.ColumnIndex >= 0)
    {
      string str = this.dataGridView_0.Rows[e.RowIndex].Cells[0].Value.ToString();
      int ToolNo = int.Parse(str);
      int Index = -1;
      this.FindToolIndexFromToolNo(ToolNo, ref Index);
      if (Index >= 0)
        this.FindToolMeshFromToolNo(str, clsDrill.ToolList[Index].Data.GroupIndex);
    }
    if (!(control2.Name == this.dataGridView_2.Name) || !(e.RowIndex >= 0 & e.ColumnIndex >= 0))
      return;
    string str1 = this.dataGridView_2.Rows[e.RowIndex].Cells[0].Value.ToString();
    int ToolNo1 = int.Parse(str1);
    int Index1 = -1;
    this.FindToolIndexFromToolNo(ToolNo1, ref Index1);
    if (Index1 < 0)
      return;
    this.FindToolMeshFromToolNo(str1, clsDrill.ToolList[Index1].Data.GroupIndex);
  }

  internal void method_2(object sender, DataGridViewCellEventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.dataGridView_1.Name && e.RowIndex >= 0 & e.ColumnIndex >= 0)
    {
      int result = -1;
      int.TryParse(this.dataGridView_1.Rows[e.RowIndex].Cells[0].Value.ToString(), out result);
      if (result >= 1)
      {
        int Index = -1;
        this.FindToolIndexFromToolNo(result, ref Index);
        if (Index >= 0)
        {
          if (e.ColumnIndex == 1)
            clsDrill.ToolList[Index].Geometry.Diameter = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[1].Value);
          if (e.ColumnIndex == 2)
            clsDrill.ToolList[Index].Geometry.Length = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[2].Value);
          if (e.ColumnIndex == 3)
            clsDrill.ToolList[Index].Geometry.CutLength = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[3].Value);
          if (e.ColumnIndex == 4)
          {
            if (!this.CommonOffset)
              clsDrill.ToolList[Index].Positions.Offset.X = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[4].Value);
            else
              clsDrill.ToolList[Index].Positions.CommonOffset.X = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[4].Value);
          }
          if (e.ColumnIndex == 5)
          {
            if (!this.CommonOffset)
              clsDrill.ToolList[Index].Positions.Offset.Y = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[5].Value);
            else
              clsDrill.ToolList[Index].Positions.CommonOffset.Y = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[5].Value);
          }
          if (e.ColumnIndex == 7)
            clsDrill.ToolList[Index].Limits.AxesMinLimits.Y = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[7].Value);
          if (e.ColumnIndex == 8)
            clsDrill.ToolList[Index].CamData.PlungeSpeed = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[8].Value);
          if (e.ColumnIndex == 9)
            clsDrill.ToolList[Index].CamData.WaitTime = Convert.ToDouble(this.dataGridView_1.Rows[e.RowIndex].Cells[9].Value);
          int WhichViewport = -1;
          if (clsDrill.ToolList[Index].Data.GroupIndex == 0)
            WhichViewport = 0;
          if (clsDrill.ToolList[Index].Data.GroupIndex == 1)
            WhichViewport = 1;
          if (clsDrill.ToolList[Index].Data.GroupIndex == 20)
            WhichViewport = 2;
          this.DrawEntities(false, WhichViewport);
        }
      }
    }
    if (control2.Name == this.dataGridView_0.Name && e.RowIndex >= 0 & e.ColumnIndex >= 0)
    {
      int result = -1;
      int.TryParse(this.dataGridView_0.Rows[e.RowIndex].Cells[0].Value.ToString(), out result);
      if (result >= 1)
      {
        int Index = -1;
        this.FindToolIndexFromToolNo(result, ref Index);
        if (Index >= 0)
        {
          if (e.ColumnIndex == 1)
            clsDrill.ToolList[Index].Geometry.Diameter = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[1].Value);
          if (e.ColumnIndex == 2)
            clsDrill.ToolList[Index].Geometry.Length = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[2].Value);
          if (e.ColumnIndex == 3)
            clsDrill.ToolList[Index].Geometry.CutLength = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[3].Value);
          if (e.ColumnIndex == 7)
            clsDrill.ToolList[Index].Limits.AxesMinLimits.Y = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[7].Value);
          if (e.ColumnIndex == 4)
          {
            if (!this.CommonOffset)
              clsDrill.ToolList[Index].Positions.Offset.X = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[4].Value);
            else
              clsDrill.ToolList[Index].Positions.CommonOffset.X = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[4].Value);
          }
          if (e.ColumnIndex == 5)
          {
            if (!this.CommonOffset)
              clsDrill.ToolList[Index].Positions.Offset.Y = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[5].Value);
            else
              clsDrill.ToolList[Index].Positions.CommonOffset.Y = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[5].Value);
          }
          if (e.ColumnIndex == 8)
            clsDrill.ToolList[Index].CamData.PlungeSpeed = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[8].Value);
          if (e.ColumnIndex == 9)
            clsDrill.ToolList[Index].CamData.WaitTime = Convert.ToDouble(this.dataGridView_0.Rows[e.RowIndex].Cells[9].Value);
          int WhichViewport = -1;
          if (clsDrill.ToolList[Index].Data.GroupIndex == 0)
            WhichViewport = 0;
          if (clsDrill.ToolList[Index].Data.GroupIndex == 1)
            WhichViewport = 1;
          if (clsDrill.ToolList[Index].Data.GroupIndex == 2)
            WhichViewport = 2;
          this.DrawEntities(false, WhichViewport);
        }
      }
    }
    if (!(control2.Name == this.dataGridView_2.Name) || !(e.RowIndex >= 0 & e.ColumnIndex >= 0))
      return;
    int result1 = -1;
    int.TryParse(this.dataGridView_2.Rows[e.RowIndex].Cells[0].Value.ToString(), out result1);
    if (result1 < 1)
      return;
    int Index1 = -1;
    this.FindToolIndexFromToolNo(result1, ref Index1);
    if (Index1 < 0)
      return;
    if (e.ColumnIndex == 1)
      clsDrill.ToolList[Index1].Geometry.Diameter = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[1].Value);
    if (e.ColumnIndex == 2)
      clsDrill.ToolList[Index1].Geometry.Length = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[2].Value);
    if (e.ColumnIndex == 3)
      clsDrill.ToolList[Index1].Geometry.CutLength = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[3].Value);
    if (e.ColumnIndex == 7)
      clsDrill.ToolList[Index1].Limits.AxesMinLimits.Y = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[7].Value);
    if (e.ColumnIndex == 4)
    {
      if (!this.CommonOffset)
        clsDrill.ToolList[Index1].Positions.Offset.X = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[4].Value);
      else
        clsDrill.ToolList[Index1].Positions.CommonOffset.X = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[4].Value);
    }
    if (e.ColumnIndex == 5)
    {
      if (!this.CommonOffset)
        clsDrill.ToolList[Index1].Positions.Offset.Y = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[5].Value);
      else
        clsDrill.ToolList[Index1].Positions.CommonOffset.Y = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[5].Value);
    }
    if (e.ColumnIndex == 8)
      clsDrill.ToolList[Index1].CamData.PlungeSpeed = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[8].Value);
    if (e.ColumnIndex == 9)
      clsDrill.ToolList[Index1].CamData.WaitTime = Convert.ToDouble(this.dataGridView_2.Rows[e.RowIndex].Cells[9].Value);
    int WhichViewport1 = -1;
    if (clsDrill.ToolList[Index1].Data.GroupIndex == 0)
      WhichViewport1 = 0;
    if (clsDrill.ToolList[Index1].Data.GroupIndex == 1)
      WhichViewport1 = 1;
    if (clsDrill.ToolList[Index1].Data.GroupIndex == 20)
      WhichViewport1 = 2;
    this.DrawEntities(false, WhichViewport1);
  }

  internal void method_3(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control.Name == this.checkBox_0.Name && this.PropertiesForm.Inited)
    {
      this.CommonOffset = this.checkBox_0.Checked;
      this.DrawEntities(true, -1);
    }
    if (!(control.Name == this.checkBox_1.Name) || !this.PropertiesForm.Inited)
      return;
    this.settingRuntime.ToolExpertMode = this.checkBox_1.Checked;
    this.ExpertMoveView(this.settingRuntime.ToolExpertMode);
  }

  internal void method_4(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control.Name == this.button_1.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      this.Visible = false;
    }
    if (control.Name == this.button_0.Name)
    {
      this.PropertiesForm.Result = DialogResult.OK;
      Class5.smethod_95(this);
      clsInit.appDrill.SaveToolConfigFile(clsDrill.fileNameToolSetting);
      this.Visible = false;
    }
    if (control.Name == this.btn_savetools.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathTool;
      saveFileDialog.Filter = "AES Drill Tool File (*.AEStool)|*.AEStool";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        clsDrill.varDrillRunSettings.pathTool = buFile5.GetPath(saveFileDialog.FileName);
        clsInit.appDrill.SaveToolConfigFile(saveFileDialog.FileName);
        clsInit.appDrill.SaveDrillFile();
      }
    }
    if (!(control.Name == this.btn_opentools.Name))
      return;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathTool;
    openFileDialog.Filter = "AES Drill Tool File (*.AEStool)|*.AEStool";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    clsDrill.varDrillRunSettings.pathTool = buFile5.GetPath(openFileDialog.FileName);
    clsInit.appDrill.OpenToolConfigFile(openFileDialog.FileName);
    clsInit.appDrill.SaveDrillFile();
    this.Init();
  }

  private void viewportBottom_MouseDown(object sender, MouseEventArgs e)
  {
    Design design = (Design) sender;
    if (this.viewportRight != null && design.Name == this.viewportRight.Name)
    {
      int[] underMouseCursor = this.viewportRight.GetAllEntitiesUnderMouseCursor(e.Location);
      if (underMouseCursor != null & e.Button == MouseButtons.Left && underMouseCursor.Length != 0)
      {
        for (int index = 0; index <= this.viewportRight.Entities.Count - 1; ++index)
          this.viewportRight.Entities[index].Selected = false;
        this.viewportRight.Entities[underMouseCursor[0]].Selected = true;
        string ToolNo = this.viewportRight.Entities[underMouseCursor[0]].EntityData.ToString();
        for (int index = 0; index <= this.dataGridView_1.Rows.Count - 1; ++index)
        {
          this.dataGridView_1.Rows[index].Selected = false;
          if (this.dataGridView_1.Rows[index].Cells[0].Value.ToString() == ToolNo)
            this.dataGridView_1.Rows[index].Selected = true;
        }
        this.FindToolMeshFromToolNo(ToolNo, 0);
      }
      this.viewportRight.Invalidate();
    }
    if (this.viewportLeft != null && design.Name == this.viewportLeft.Name)
    {
      int[] underMouseCursor = this.viewportLeft.GetAllEntitiesUnderMouseCursor(e.Location);
      if (underMouseCursor != null & e.Button == MouseButtons.Left && underMouseCursor.Length != 0)
      {
        for (int index = 0; index <= this.viewportLeft.Entities.Count - 1; ++index)
          this.viewportLeft.Entities[index].Selected = false;
        this.viewportLeft.Entities[underMouseCursor[0]].Selected = true;
        string ToolNo = this.viewportLeft.Entities[underMouseCursor[0]].EntityData.ToString();
        for (int index = 0; index <= this.dataGridView_0.Rows.Count - 1; ++index)
        {
          this.dataGridView_0.Rows[index].Selected = false;
          if (this.dataGridView_0.Rows[index].Cells[0].Value.ToString() == ToolNo)
            this.dataGridView_0.Rows[index].Selected = true;
        }
        this.FindToolMeshFromToolNo(ToolNo, 1);
      }
      this.viewportLeft.Invalidate();
    }
    if (this.viewportBottom == null || !(design.Name == this.viewportBottom.Name))
      return;
    int[] underMouseCursor1 = this.viewportBottom.GetAllEntitiesUnderMouseCursor(e.Location);
    if (underMouseCursor1 != null & e.Button == MouseButtons.Left && underMouseCursor1.Length != 0)
    {
      for (int index = 0; index <= this.viewportBottom.Entities.Count - 1; ++index)
        this.viewportBottom.Entities[index].Selected = false;
      this.viewportBottom.Entities[underMouseCursor1[0]].Selected = true;
      string ToolNo = this.viewportBottom.Entities[underMouseCursor1[0]].EntityData.ToString();
      for (int index = 0; index <= this.dataGridView_2.Rows.Count - 1; ++index)
      {
        this.dataGridView_2.Rows[index].Selected = false;
        if (this.dataGridView_2.Rows[index].Cells[0].Value.ToString() == ToolNo)
          this.dataGridView_2.Rows[index].Selected = true;
      }
      this.FindToolMeshFromToolNo(ToolNo, 2);
    }
    this.viewportBottom.Invalidate();
  }

  public void ExpertMoveView(bool ExperMode)
  {
    this.checkBox_0.Visible = ExperMode;
    if (this.dataGridView_1 != null && this.dataGridView_1.Columns.Count > 3)
    {
      this.dataGridView_1.Columns[4].Visible = ExperMode;
      this.dataGridView_1.Columns[5].Visible = ExperMode;
      this.dataGridView_1.Columns[6].Visible = ExperMode;
      this.dataGridView_1.Columns[7].Visible = ExperMode;
    }
    if (this.dataGridView_0 != null && this.dataGridView_0.Columns.Count > 3)
    {
      this.dataGridView_0.Columns[4].Visible = ExperMode;
      this.dataGridView_0.Columns[5].Visible = ExperMode;
      this.dataGridView_0.Columns[6].Visible = ExperMode;
      this.dataGridView_0.Columns[7].Visible = ExperMode;
    }
    if (this.dataGridView_2 == null || this.dataGridView_2.Columns.Count <= 3)
      return;
    this.dataGridView_2.Columns[4].Visible = ExperMode;
    this.dataGridView_2.Columns[5].Visible = ExperMode;
    this.dataGridView_2.Columns[6].Visible = ExperMode;
    this.dataGridView_2.Columns[7].Visible = ExperMode;
  }

  public void FindToolIndexFromToolNo(int ToolNo, ref int Index)
  {
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == ToolNo)
        Index = index;
    }
  }

  public void FindToolMeshFromToolNo(string ToolNo, int WhichViewport)
  {
    if (WhichViewport == 0 & this.viewportRight != null)
    {
      for (int index = 0; index <= this.viewportRight.Entities.Count - 1; ++index)
      {
        if (this.viewportRight.Entities[index] is Mesh)
        {
          this.viewportRight.Entities[index].Selected = false;
          if (this.viewportRight.Entities[index].EntityData != null && this.viewportRight.Entities[index].EntityData.ToString() == ToolNo)
            this.viewportRight.Entities[index].Selected = true;
        }
      }
      this.viewportRight.Invalidate();
    }
    if (WhichViewport == 1 & this.viewportLeft != null)
    {
      for (int index = 0; index <= this.viewportLeft.Entities.Count - 1; ++index)
      {
        if (this.viewportLeft.Entities[index] is Mesh)
        {
          this.viewportLeft.Entities[index].Selected = false;
          if (this.viewportLeft.Entities[index].EntityData != null && this.viewportLeft.Entities[index].EntityData.ToString() == ToolNo)
            this.viewportLeft.Entities[index].Selected = true;
        }
      }
      this.viewportLeft.Invalidate();
    }
    if (!(WhichViewport == 2 & this.viewportBottom != null))
      return;
    for (int index = 0; index <= this.viewportBottom.Entities.Count - 1; ++index)
    {
      if (this.viewportBottom.Entities[index] is Mesh)
      {
        this.viewportBottom.Entities[index].Selected = false;
        if (this.viewportBottom.Entities[index].EntityData != null && this.viewportBottom.Entities[index].EntityData.ToString() == ToolNo)
          this.viewportBottom.Entities[index].Selected = true;
      }
    }
    this.viewportBottom.Invalidate();
  }

  public void DrawEntities(bool ClearGrids, int WhichViewport)
  {
    if ((WhichViewport == -1 | WhichViewport == 0) & this.viewportRight != null)
    {
      for (int index = 0; index <= this.viewportRight.Entities.Count - 1; ++index)
      {
        if (this.viewportRight.Entities[index] is Mesh)
          this.viewportRight.Entities[index].Selected = true;
      }
      this.viewportRight.Entities.DeleteSelected();
    }
    if ((WhichViewport == -1 | WhichViewport == 1) & this.viewportLeft != null)
    {
      for (int index = 0; index <= this.viewportLeft.Entities.Count - 1; ++index)
      {
        if (this.viewportLeft.Entities[index] is Mesh)
          this.viewportLeft.Entities[index].Selected = true;
      }
      this.viewportLeft.Entities.DeleteSelected();
    }
    if ((WhichViewport == -1 | WhichViewport == 2) & this.viewportBottom != null)
    {
      for (int index = 0; index <= this.viewportBottom.Entities.Count - 1; ++index)
      {
        if (this.viewportBottom.Entities[index] is Mesh)
          this.viewportBottom.Entities[index].Selected = true;
      }
      this.viewportBottom.Entities.DeleteSelected();
    }
    if (ClearGrids)
    {
      this.dataGridView_0.Rows.Clear();
      this.dataGridView_1.Rows.Clear();
      this.dataGridView_2.Rows.Clear();
    }
    for (int index1 = 0; index1 <= clsDrill.ToolList.Count - 1; ++index1)
    {
      if (clsDrill.ToolList[index1] != null)
      {
        if (ClearGrids)
        {
          if (!this.CommonOffset)
          {
            if (clsDrill.ToolList[index1].Data.GroupIndex == 0 & this.viewportRight != null)
            {
              DataGridViewRowCollection rows = this.dataGridView_1.Rows;
              int no = clsDrill.ToolList[index1].Data.No;
              double diameter = clsDrill.ToolList[index1].Geometry.Diameter;
              double length = clsDrill.ToolList[index1].Geometry.Length;
              double cutLength = clsDrill.ToolList[index1].Geometry.CutLength;
              double x = clsDrill.ToolList[index1].Positions.Offset.X;
              double y1 = clsDrill.ToolList[index1].Positions.Offset.Y;
              double z = clsDrill.ToolList[index1].Positions.Offset.Z;
              double y2 = clsDrill.ToolList[index1].Limits.AxesMinLimits.Y;
              double plungeSpeed = clsDrill.ToolList[index1].CamData.PlungeSpeed;
              double waitTime = clsDrill.ToolList[index1].CamData.WaitTime;
              object[] objArray = Class5.smethod_51(y2, this, waitTime, plungeSpeed, diameter, no, y1, length, x, z, cutLength);
              rows.Add(objArray);
            }
            if (clsDrill.ToolList[index1].Data.GroupIndex == 1 & this.viewportLeft != null)
            {
              DataGridViewRowCollection rows = this.dataGridView_0.Rows;
              int no = clsDrill.ToolList[index1].Data.No;
              double diameter = clsDrill.ToolList[index1].Geometry.Diameter;
              double length = clsDrill.ToolList[index1].Geometry.Length;
              double cutLength = clsDrill.ToolList[index1].Geometry.CutLength;
              double x = clsDrill.ToolList[index1].Positions.Offset.X;
              double y3 = clsDrill.ToolList[index1].Positions.Offset.Y;
              double z = clsDrill.ToolList[index1].Positions.Offset.Z;
              double y4 = clsDrill.ToolList[index1].Limits.AxesMinLimits.Y;
              double plungeSpeed = clsDrill.ToolList[index1].CamData.PlungeSpeed;
              double waitTime = clsDrill.ToolList[index1].CamData.WaitTime;
              object[] objArray = Class5.smethod_51(y4, this, waitTime, plungeSpeed, diameter, no, y3, length, x, z, cutLength);
              rows.Add(objArray);
            }
            if (clsDrill.ToolList[index1].Data.GroupIndex == 2 & this.viewportBottom != null)
            {
              DataGridViewRowCollection rows = this.dataGridView_2.Rows;
              int no = clsDrill.ToolList[index1].Data.No;
              double diameter = clsDrill.ToolList[index1].Geometry.Diameter;
              double length = clsDrill.ToolList[index1].Geometry.Length;
              double cutLength = clsDrill.ToolList[index1].Geometry.CutLength;
              double x = clsDrill.ToolList[index1].Positions.Offset.X;
              double y5 = clsDrill.ToolList[index1].Positions.Offset.Y;
              double z = clsDrill.ToolList[index1].Positions.Offset.Z;
              double y6 = clsDrill.ToolList[index1].Limits.AxesMinLimits.Y;
              double plungeSpeed = clsDrill.ToolList[index1].CamData.PlungeSpeed;
              double waitTime = clsDrill.ToolList[index1].CamData.WaitTime;
              object[] objArray = Class5.smethod_51(y6, this, waitTime, plungeSpeed, diameter, no, y5, length, x, z, cutLength);
              rows.Add(objArray);
            }
          }
          else
          {
            if (clsDrill.ToolList[index1].Data.GroupIndex == 0 & this.viewportRight != null)
            {
              DataGridViewRowCollection rows = this.dataGridView_1.Rows;
              int no = clsDrill.ToolList[index1].Data.No;
              double diameter = clsDrill.ToolList[index1].Geometry.Diameter;
              double length = clsDrill.ToolList[index1].Geometry.Length;
              double cutLength = clsDrill.ToolList[index1].Geometry.CutLength;
              double x = clsDrill.ToolList[index1].Positions.CommonOffset.X;
              double y7 = clsDrill.ToolList[index1].Positions.CommonOffset.Y;
              double z = clsDrill.ToolList[index1].Positions.CommonOffset.Z;
              double y8 = clsDrill.ToolList[index1].Limits.AxesMinLimits.Y;
              double plungeSpeed = clsDrill.ToolList[index1].CamData.PlungeSpeed;
              double waitTime = clsDrill.ToolList[index1].CamData.WaitTime;
              object[] objArray = Class5.smethod_51(y8, this, waitTime, plungeSpeed, diameter, no, y7, length, x, z, cutLength);
              rows.Add(objArray);
            }
            if (clsDrill.ToolList[index1].Data.GroupIndex == 1 & this.viewportLeft != null)
            {
              DataGridViewRowCollection rows = this.dataGridView_0.Rows;
              int no = clsDrill.ToolList[index1].Data.No;
              double diameter = clsDrill.ToolList[index1].Geometry.Diameter;
              double length = clsDrill.ToolList[index1].Geometry.Length;
              double cutLength = clsDrill.ToolList[index1].Geometry.CutLength;
              double x = clsDrill.ToolList[index1].Positions.CommonOffset.X;
              double y9 = clsDrill.ToolList[index1].Positions.CommonOffset.Y;
              double z = clsDrill.ToolList[index1].Positions.CommonOffset.Z;
              double y10 = clsDrill.ToolList[index1].Limits.AxesMinLimits.Y;
              double plungeSpeed = clsDrill.ToolList[index1].CamData.PlungeSpeed;
              double waitTime = clsDrill.ToolList[index1].CamData.WaitTime;
              object[] objArray = Class5.smethod_51(y10, this, waitTime, plungeSpeed, diameter, no, y9, length, x, z, cutLength);
              rows.Add(objArray);
            }
            if (clsDrill.ToolList[index1].Data.GroupIndex == 2 & this.viewportBottom != null)
            {
              DataGridViewRowCollection rows = this.dataGridView_2.Rows;
              int no = clsDrill.ToolList[index1].Data.No;
              double diameter = clsDrill.ToolList[index1].Geometry.Diameter;
              double length = clsDrill.ToolList[index1].Geometry.Length;
              double cutLength = clsDrill.ToolList[index1].Geometry.CutLength;
              double x = clsDrill.ToolList[index1].Positions.CommonOffset.X;
              double y11 = clsDrill.ToolList[index1].Positions.CommonOffset.Y;
              double z = clsDrill.ToolList[index1].Positions.CommonOffset.Z;
              double y12 = clsDrill.ToolList[index1].Limits.AxesMinLimits.Y;
              double plungeSpeed = clsDrill.ToolList[index1].CamData.PlungeSpeed;
              double waitTime = clsDrill.ToolList[index1].CamData.WaitTime;
              object[] objArray = Class5.smethod_51(y12, this, waitTime, plungeSpeed, diameter, no, y11, length, x, z, cutLength);
              rows.Add(objArray);
            }
          }
        }
        List<Mesh> refMeshes = new List<Mesh>();
        clsDrill.ToolList[index1].Geometry.LowerRadius = 0.0;
        clsDrill.ToolList[index1].Geometry.UpperRadius = 0.0;
        clsDrill.ToolList[index1].Geometry.CornerRadiusType = ToolCornerRadiusType.None;
        clsInit.appMW.CreateToolWithToolDirection(clsDrill.ToolList[index1], true, true, false, false, true, ref refMeshes);
        for (int index2 = 0; index2 <= refMeshes.Count - 1; ++index2)
        {
          refMeshes[index2].Color = Color.FromArgb((int) byte.MaxValue, refMeshes[index2].Color);
          if (this.isGo)
          {
            if (clsDrill.ToolList[index1].Data.No >= 61 & clsDrill.ToolList[index1].Data.No <= 70 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 71 & clsDrill.ToolList[index1].Data.No <= 79 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
            if (clsDrill.ToolList[index1].Data.No == 31 /*0x1F*/ & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
            if (clsDrill.ToolList[index1].Data.No == 95 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
          }
          else if (this.isSirius)
          {
            if (clsDrill.ToolList[index1].Data.No >= 61 & clsDrill.ToolList[index1].Data.No <= 70 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 71 & clsDrill.ToolList[index1].Data.No <= 79 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
            if (clsDrill.ToolList[index1].Data.No == 31 /*0x1F*/ & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
            if (clsDrill.ToolList[index1].Data.No == 95 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
          }
          else if (!this.UseCommponOffsetToolDrawing)
          {
            if (clsDrill.ToolList[index1].Data.No >= 61 & clsDrill.ToolList[index1].Data.No <= 71 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 72 & clsDrill.ToolList[index1].Data.No <= 79 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
            if (clsDrill.ToolList[index1].Data.No == 80 /*0x50*/ & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
            if (clsDrill.ToolList[index1].Data.No == 85 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 161 & clsDrill.ToolList[index1].Data.No <= 171 & this.viewportLeft != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 172 & clsDrill.ToolList[index1].Data.No <= 179 & this.viewportLeft != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalZOffset);
            if (clsDrill.ToolList[index1].Data.No == 185 & this.viewportLeft != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolSawZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 261 & clsDrill.ToolList[index1].Data.No <= 269 & this.viewportBottom != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolVerticalZOffset + 80.0);
            if (clsDrill.ToolList[index1].Data.No == 270 & this.viewportBottom != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.Offset.X, -clsDrill.ToolList[index1].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolMillingZOffset + 150.0);
          }
          else
          {
            if (clsDrill.ToolList[index1].Data.No >= 61 & clsDrill.ToolList[index1].Data.No <= 71 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 72 & clsDrill.ToolList[index1].Data.No <= 79 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
            if (clsDrill.ToolList[index1].Data.No == 80 /*0x50*/ & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
            if (clsDrill.ToolList[index1].Data.No == 85 & this.viewportRight != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 161 & clsDrill.ToolList[index1].Data.No <= 171 & this.viewportLeft != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 172 & clsDrill.ToolList[index1].Data.No <= 179 & this.viewportLeft != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalZOffset);
            if (clsDrill.ToolList[index1].Data.No == 185 & this.viewportLeft != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolSawZOffset);
            if (clsDrill.ToolList[index1].Data.No >= 261 & clsDrill.ToolList[index1].Data.No <= 269 & this.viewportBottom != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolVerticalZOffset + 80.0);
            if (clsDrill.ToolList[index1].Data.No == 270 & this.viewportBottom != null)
              refMeshes[index2].Translate(clsDrill.ToolList[index1].Positions.CommonOffset.X, clsDrill.ToolList[index1].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolMillingZOffset + 150.0);
          }
          refMeshes[index2].EntityData = (object) clsDrill.ToolList[index1].Data.No;
          if (clsDrill.ToolList[index1].Data.GroupIndex == 0 & (WhichViewport == -1 | WhichViewport == 0) & this.viewportRight != null)
            this.viewportRight.Entities.Add((Entity) refMeshes[index2]);
          if (clsDrill.ToolList[index1].Data.GroupIndex == 1 & (WhichViewport == -1 | WhichViewport == 1) & this.viewportLeft != null)
            this.viewportLeft.Entities.Add((Entity) refMeshes[index2]);
          if (clsDrill.ToolList[index1].Data.GroupIndex == 2 & (WhichViewport == -1 | WhichViewport == 2) & this.viewportBottom != null)
            this.viewportBottom.Entities.Add((Entity) refMeshes[index2]);
        }
      }
    }
    if (this.viewportLeft != null)
      this.viewportLeft.Invalidate();
    if (this.viewportRight != null)
      this.viewportRight.Invalidate();
    if (this.viewportBottom == null)
      return;
    this.viewportBottom.Invalidate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
