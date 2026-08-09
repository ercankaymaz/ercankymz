using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using ns8;

namespace buCadCamResVer5.Drill;

public class F_Tools : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public Design viewportRight = null;

	public Design viewportLeft = null;

	public Design viewportBottom = null;

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

	private IContainer icontainer_0 = null;

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
		timer_0.Interval = 500;
		timer_0.Tick += timer_0_Tick;
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		LoadLanguage();
		if (viewportRight != null && viewportRight.Entities.Count == 0)
		{
			viewportRight.MouseDown += viewportBottom_MouseDown;
			FileInfo fileInfo = new FileInfo(fileNameRightTools);
			if (fileInfo.Exists)
			{
				clsInit.cVector5.ReadStepFile(fileNameRightTools, ref viewportRight);
				for (int i = 0; i <= viewportRight.Entities.Count - 1; i++)
				{
					viewportRight.Entities[i].Selectable = false;
				}
			}
		}
		if (viewportLeft != null && viewportLeft.Entities.Count == 0)
		{
			viewportLeft.MouseDown += viewportBottom_MouseDown;
			FileInfo fileInfo2 = new FileInfo(fileNameLeftTools);
			if (fileInfo2.Exists)
			{
				clsInit.cVector5.ReadStepFile(fileNameLeftTools, ref viewportLeft);
				for (int j = 0; j <= viewportLeft.Entities.Count - 1; j++)
				{
					viewportLeft.Entities[j].Selectable = false;
				}
			}
		}
		if (viewportBottom != null && viewportBottom.Entities.Count == 0)
		{
			viewportBottom.MouseDown += viewportBottom_MouseDown;
			FileInfo fileInfo3 = new FileInfo(fileNameBottomTools);
			if (fileInfo3.Exists)
			{
				clsInit.cVector5.ReadStepFile(fileNameBottomTools, ref viewportBottom);
				for (int k = 0; k <= viewportBottom.Entities.Count - 1; k++)
				{
					viewportBottom.Entities[k].Selectable = false;
				}
			}
		}
		if (viewportRight != null)
		{
			if (dataGridView_1.Columns.Count == 0)
			{
				DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn.Width = 40;
				dataGridViewColumn.HeaderText = "No";
				dataGridViewColumn.Name = "No";
				dataGridViewColumn.ReadOnly = true;
				dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn);
				DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
				dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn2.Width = 80;
				dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Diameter;
				dataGridViewColumn2.Name = buLangTranslate.preDef.Diameter;
				dataGridViewColumn2.ReadOnly = false;
				dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn2);
				DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
				dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn3.Width = 80;
				dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn3.Name = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn3.ReadOnly = false;
				dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn3);
				DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
				dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn4.Width = 80;
				dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn4.Name = buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn4.ReadOnly = false;
				dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn4);
				DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
				dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn5.Width = 80;
				dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Offset + " X";
				dataGridViewColumn5.Name = buLangTranslate.preDef.Offset + " X";
				dataGridViewColumn5.ReadOnly = false;
				dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn5.Visible = ShowXOffset;
				dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn5);
				DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
				dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn6.Width = 80;
				dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Offset + " Y";
				dataGridViewColumn6.Name = buLangTranslate.preDef.Offset + " Y";
				dataGridViewColumn6.ReadOnly = false;
				dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn6.Visible = ShowYOffset;
				dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn6);
				DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
				dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn7.Width = 80;
				dataGridViewColumn7.HeaderText = buLangTranslate.preDef.Offset + " Z";
				dataGridViewColumn7.Name = buLangTranslate.preDef.Offset + " Z";
				dataGridViewColumn7.ReadOnly = false;
				dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn7.Visible = ShowZOffset;
				dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn7);
				DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
				dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn8.Width = 80;
				dataGridViewColumn8.HeaderText = buLangTranslate.preDef.Limit + " Y";
				dataGridViewColumn8.Name = buLangTranslate.preDef.Limit + " Y";
				dataGridViewColumn8.ReadOnly = false;
				dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn8.Visible = ShowYLimit;
				dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn8);
				DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
				dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn9.Width = 80;
				dataGridViewColumn9.HeaderText = buLangTranslate.preDef.Plunge;
				dataGridViewColumn9.Name = buLangTranslate.preDef.Plunge;
				dataGridViewColumn9.ReadOnly = false;
				dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn9.Visible = ShowPlungeSpeed;
				dataGridViewColumn9.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn9);
				DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
				dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn10.Width = 80;
				dataGridViewColumn10.HeaderText = buLangTranslate.preDef.Wait;
				dataGridViewColumn10.Name = buLangTranslate.preDef.Wait;
				dataGridViewColumn10.ReadOnly = false;
				dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn10.Visible = ShowPlungeSpeed;
				dataGridViewColumn10.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_1.Columns.Add(dataGridViewColumn10);
			}
			dataGridView_1.RowHeadersVisible = false;
			dataGridView_1.AllowUserToAddRows = false;
			dataGridView_1.AllowUserToResizeColumns = false;
			dataGridView_1.AllowUserToResizeRows = false;
		}
		if (viewportLeft != null)
		{
			if (dataGridView_0.Columns.Count == 0)
			{
				DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
				dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn11.Width = 40;
				dataGridViewColumn11.HeaderText = "No";
				dataGridViewColumn11.Name = "No";
				dataGridViewColumn11.ReadOnly = true;
				dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn11.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn11);
				DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
				dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn12.Width = 80;
				dataGridViewColumn12.HeaderText = buLangTranslate.preDef.Diameter;
				dataGridViewColumn12.Name = buLangTranslate.preDef.Diameter;
				dataGridViewColumn12.ReadOnly = false;
				dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn12.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn12);
				DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
				dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn13.Width = 80;
				dataGridViewColumn13.HeaderText = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn13.Name = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn13.ReadOnly = false;
				dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn13.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn13);
				DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
				dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn14.Width = 80;
				dataGridViewColumn14.HeaderText = buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn14.Name = buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn14.ReadOnly = false;
				dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn14.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn14);
				DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
				dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn15.Width = 80;
				dataGridViewColumn15.HeaderText = buLangTranslate.preDef.Offset + " X";
				dataGridViewColumn15.Name = buLangTranslate.preDef.Offset + " X";
				dataGridViewColumn15.ReadOnly = false;
				dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn15.Visible = ShowXOffset;
				dataGridViewColumn15.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn15);
				DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
				dataGridViewColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn16.Width = 80;
				dataGridViewColumn16.HeaderText = buLangTranslate.preDef.Offset + " Y";
				dataGridViewColumn16.Name = buLangTranslate.preDef.Offset + " Y";
				dataGridViewColumn16.ReadOnly = false;
				dataGridViewColumn16.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn16.Visible = ShowYOffset;
				dataGridViewColumn16.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn16);
				DataGridViewColumn dataGridViewColumn17 = new DataGridViewColumn();
				dataGridViewColumn17.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn17.Width = 80;
				dataGridViewColumn17.HeaderText = buLangTranslate.preDef.Offset + " Z";
				dataGridViewColumn17.Name = buLangTranslate.preDef.Offset + " Z";
				dataGridViewColumn17.ReadOnly = false;
				dataGridViewColumn17.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn17.Visible = ShowZOffset;
				dataGridViewColumn17.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn17);
				DataGridViewColumn dataGridViewColumn18 = new DataGridViewColumn();
				dataGridViewColumn18.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn18.Width = 80;
				dataGridViewColumn18.HeaderText = buLangTranslate.preDef.Limit + " Y";
				dataGridViewColumn18.Name = buLangTranslate.preDef.Limit + " Y";
				dataGridViewColumn18.ReadOnly = false;
				dataGridViewColumn18.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn18.Visible = ShowYLimit;
				dataGridViewColumn18.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn18);
				DataGridViewColumn dataGridViewColumn19 = new DataGridViewColumn();
				dataGridViewColumn19.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn19.Width = 80;
				dataGridViewColumn19.HeaderText = buLangTranslate.preDef.Plunge;
				dataGridViewColumn19.Name = buLangTranslate.preDef.Plunge;
				dataGridViewColumn19.ReadOnly = false;
				dataGridViewColumn19.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn19.Visible = ShowPlungeSpeed;
				dataGridViewColumn19.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn19);
				DataGridViewColumn dataGridViewColumn20 = new DataGridViewColumn();
				dataGridViewColumn20.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn20.Width = 80;
				dataGridViewColumn20.HeaderText = buLangTranslate.preDef.Wait;
				dataGridViewColumn20.Name = buLangTranslate.preDef.Wait;
				dataGridViewColumn20.ReadOnly = false;
				dataGridViewColumn20.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn20.Visible = ShowPlungeSpeed;
				dataGridViewColumn20.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_0.Columns.Add(dataGridViewColumn20);
			}
			dataGridView_0.RowHeadersVisible = false;
			dataGridView_0.AllowUserToAddRows = false;
			dataGridView_0.AllowUserToResizeColumns = false;
			dataGridView_0.AllowUserToResizeRows = false;
		}
		if (viewportBottom != null)
		{
			if (dataGridView_2.Columns.Count == 0)
			{
				DataGridViewColumn dataGridViewColumn21 = new DataGridViewColumn();
				dataGridViewColumn21.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn21.Width = 40;
				dataGridViewColumn21.HeaderText = "No";
				dataGridViewColumn21.Name = "No";
				dataGridViewColumn21.ReadOnly = true;
				dataGridViewColumn21.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn21.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn21);
				DataGridViewColumn dataGridViewColumn22 = new DataGridViewColumn();
				dataGridViewColumn22.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn22.Width = 80;
				dataGridViewColumn22.HeaderText = buLangTranslate.preDef.Diameter;
				dataGridViewColumn22.Name = buLangTranslate.preDef.Diameter;
				dataGridViewColumn22.ReadOnly = false;
				dataGridViewColumn22.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn22.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn22);
				DataGridViewColumn dataGridViewColumn23 = new DataGridViewColumn();
				dataGridViewColumn23.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn23.Width = 80;
				dataGridViewColumn23.HeaderText = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn23.Name = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn23.ReadOnly = false;
				dataGridViewColumn23.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn23.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn23);
				DataGridViewColumn dataGridViewColumn24 = new DataGridViewColumn();
				dataGridViewColumn24.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn24.Width = 80;
				dataGridViewColumn24.HeaderText = buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn24.Name = buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Length;
				dataGridViewColumn24.ReadOnly = false;
				dataGridViewColumn24.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn24.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn24);
				DataGridViewColumn dataGridViewColumn25 = new DataGridViewColumn();
				dataGridViewColumn25.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn25.Width = 80;
				dataGridViewColumn25.HeaderText = buLangTranslate.preDef.Offset + " X";
				dataGridViewColumn25.Name = buLangTranslate.preDef.Offset + " X";
				dataGridViewColumn25.ReadOnly = false;
				dataGridViewColumn25.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn25.Visible = ShowXOffset;
				dataGridViewColumn25.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn25);
				DataGridViewColumn dataGridViewColumn26 = new DataGridViewColumn();
				dataGridViewColumn26.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn26.Width = 80;
				dataGridViewColumn26.HeaderText = buLangTranslate.preDef.Offset + " Y";
				dataGridViewColumn26.Name = buLangTranslate.preDef.Offset + " Y";
				dataGridViewColumn26.ReadOnly = false;
				dataGridViewColumn26.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn26.Visible = ShowYOffset;
				dataGridViewColumn26.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn26);
				DataGridViewColumn dataGridViewColumn27 = new DataGridViewColumn();
				dataGridViewColumn27.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn27.Width = 80;
				dataGridViewColumn27.HeaderText = buLangTranslate.preDef.Offset + " Z";
				dataGridViewColumn27.Name = buLangTranslate.preDef.Offset + " Z";
				dataGridViewColumn27.ReadOnly = false;
				dataGridViewColumn27.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn27.Visible = ShowZOffset;
				dataGridViewColumn27.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn27);
				DataGridViewColumn dataGridViewColumn28 = new DataGridViewColumn();
				dataGridViewColumn28.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn28.Width = 80;
				dataGridViewColumn28.HeaderText = buLangTranslate.preDef.Limit + " Y";
				dataGridViewColumn28.Name = buLangTranslate.preDef.Limit + " Y";
				dataGridViewColumn28.ReadOnly = false;
				dataGridViewColumn28.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn28.Visible = ShowYLimit;
				dataGridViewColumn28.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn28);
				DataGridViewColumn dataGridViewColumn29 = new DataGridViewColumn();
				dataGridViewColumn29.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn29.Width = 80;
				dataGridViewColumn29.HeaderText = buLangTranslate.preDef.Plunge;
				dataGridViewColumn29.Name = buLangTranslate.preDef.Plunge;
				dataGridViewColumn29.ReadOnly = false;
				dataGridViewColumn29.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn29.Visible = ShowPlungeSpeed;
				dataGridViewColumn29.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn29);
				DataGridViewColumn dataGridViewColumn30 = new DataGridViewColumn();
				dataGridViewColumn30.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn30.Width = 80;
				dataGridViewColumn30.HeaderText = buLangTranslate.preDef.Wait;
				dataGridViewColumn30.Name = buLangTranslate.preDef.Wait;
				dataGridViewColumn30.ReadOnly = false;
				dataGridViewColumn30.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn30.Visible = ShowPlungeSpeed;
				dataGridViewColumn30.CellTemplate = new DataGridViewTextBoxCell();
				dataGridView_2.Columns.Add(dataGridViewColumn30);
			}
			dataGridView_2.RowHeadersVisible = false;
			dataGridView_2.AllowUserToAddRows = false;
			dataGridView_2.AllowUserToResizeColumns = false;
			dataGridView_2.AllowUserToResizeRows = false;
		}
		if (viewportLeft != null)
		{
			viewportLeft.ActiveViewport.DisplayMode = displayType.Rendered;
			viewportLeft.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		if (viewportRight != null)
		{
			viewportRight.ActiveViewport.DisplayMode = displayType.Rendered;
			viewportRight.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		if (viewportBottom != null)
		{
			viewportBottom.ActiveViewport.DisplayMode = displayType.Rendered;
			viewportBottom.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		checkBox_1.Checked = settingRuntime.ToolExpertMode;
		ExpertMoveView(settingRuntime.ToolExpertMode);
		DrawEntities(ClearGrids: true, -1);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		timer_0.Enabled = true;
	}

	public void LoadLanguage()
	{
		Text = buLangTranslate.preDef.Tools;
		if (!((clsInit.appDrill.MachType == DrillMachineType.GoWithAtc) | (clsInit.appDrill.MachType == DrillMachineType.GoWithNoAtc) | (clsInit.appDrill.MachType == DrillMachineType.Sirius)))
		{
			if (clsInit.appDrill.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				tabPage_0.Text = buLangTranslate.preDef.Top + " Y1 " + buLangTranslate.preDef.Head;
				tabPage_1.Text = buLangTranslate.preDef.Top + " Y2 " + buLangTranslate.preDef.Head;
				tabPage_2.Text = buLangTranslate.preDef.Bottom + " Y3 " + buLangTranslate.preDef.Head;
			}
		}
		else
		{
			tabPage_0.Text = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.Head;
		}
		checkBox_0.Text = buLangTranslate.preDef.Common + " " + buLangTranslate.preDef.Offset;
		checkBox_1.Text = buLangTranslate.preDef.Expert + " " + buLangTranslate.preDef.Mode;
		btn_opentools.Text = buLangTranslate.preDef.Tools + " " + buLangTranslate.preDef.Open;
		btn_savetools.Text = buLangTranslate.preDef.Tools + " " + buLangTranslate.preDef.Save;
		button_0.Text = buLangTranslate.preDef.Ok;
		button_1.Text = buLangTranslate.preDef.Cancel;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (viewportLeft != null && viewportLeft.IsHandleCreated)
		{
			viewportLeft.SetView(viewType.Bottom, fit: true, animate: false);
			viewportLeft.Invalidate();
			timer_0.Enabled = false;
		}
		if (viewportRight != null && viewportRight.IsHandleCreated)
		{
			if (isSirius)
			{
				viewportRight.SetView(viewType.Top, fit: true, animate: false);
				viewportRight.Invalidate();
			}
			else
			{
				viewportRight.SetView(viewType.Bottom, fit: true, animate: false);
				viewportRight.Invalidate();
			}
			timer_0.Enabled = false;
		}
		if (viewportBottom != null && viewportBottom.IsHandleCreated)
		{
			viewportBottom.SetView(viewType.Top, fit: true, animate: false);
			viewportBottom.Invalidate();
			timer_0.Enabled = false;
		}
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == dataGridView_1.Name && ((e.RowIndex >= 0) & (e.ColumnIndex >= 0)))
		{
			string text = dataGridView_1.Rows[e.RowIndex].Cells[0].Value.ToString();
			int toolNo = int.Parse(text);
			int Index = -1;
			FindToolIndexFromToolNo(toolNo, ref Index);
			if (Index >= 0)
			{
				FindToolMeshFromToolNo(text, clsDrill.ToolList[Index].Data.GroupIndex);
			}
		}
		if (control.Name == dataGridView_0.Name && ((e.RowIndex >= 0) & (e.ColumnIndex >= 0)))
		{
			string text2 = dataGridView_0.Rows[e.RowIndex].Cells[0].Value.ToString();
			int toolNo2 = int.Parse(text2);
			int Index2 = -1;
			FindToolIndexFromToolNo(toolNo2, ref Index2);
			if (Index2 >= 0)
			{
				FindToolMeshFromToolNo(text2, clsDrill.ToolList[Index2].Data.GroupIndex);
			}
		}
		if (control.Name == dataGridView_2.Name && ((e.RowIndex >= 0) & (e.ColumnIndex >= 0)))
		{
			string text3 = dataGridView_2.Rows[e.RowIndex].Cells[0].Value.ToString();
			int toolNo3 = int.Parse(text3);
			int Index3 = -1;
			FindToolIndexFromToolNo(toolNo3, ref Index3);
			if (Index3 >= 0)
			{
				FindToolMeshFromToolNo(text3, clsDrill.ToolList[Index3].Data.GroupIndex);
			}
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == dataGridView_1.Name && ((e.RowIndex >= 0) & (e.ColumnIndex >= 0)))
		{
			int result = -1;
			int.TryParse(dataGridView_1.Rows[e.RowIndex].Cells[0].Value.ToString(), out result);
			if (result >= 1)
			{
				int Index = -1;
				FindToolIndexFromToolNo(result, ref Index);
				if (Index >= 0)
				{
					if (e.ColumnIndex == 1)
					{
						clsDrill.ToolList[Index].Geometry.Diameter = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[1].Value);
					}
					if (e.ColumnIndex == 2)
					{
						clsDrill.ToolList[Index].Geometry.Length = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[2].Value);
					}
					if (e.ColumnIndex == 3)
					{
						clsDrill.ToolList[Index].Geometry.CutLength = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[3].Value);
					}
					if (e.ColumnIndex == 4)
					{
						if (CommonOffset)
						{
							clsDrill.ToolList[Index].Positions.CommonOffset.X = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[4].Value);
						}
						else
						{
							clsDrill.ToolList[Index].Positions.Offset.X = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[4].Value);
						}
					}
					if (e.ColumnIndex == 5)
					{
						if (CommonOffset)
						{
							clsDrill.ToolList[Index].Positions.CommonOffset.Y = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[5].Value);
						}
						else
						{
							clsDrill.ToolList[Index].Positions.Offset.Y = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[5].Value);
						}
					}
					if (e.ColumnIndex == 7)
					{
						clsDrill.ToolList[Index].Limits.AxesMinLimits.Y = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[7].Value);
					}
					if (e.ColumnIndex == 8)
					{
						clsDrill.ToolList[Index].CamData.PlungeSpeed = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[8].Value);
					}
					if (e.ColumnIndex == 9)
					{
						clsDrill.ToolList[Index].CamData.WaitTime = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[9].Value);
					}
					int whichViewport = -1;
					if (clsDrill.ToolList[Index].Data.GroupIndex == 0)
					{
						whichViewport = 0;
					}
					if (clsDrill.ToolList[Index].Data.GroupIndex == 1)
					{
						whichViewport = 1;
					}
					if (clsDrill.ToolList[Index].Data.GroupIndex == 20)
					{
						whichViewport = 2;
					}
					DrawEntities(ClearGrids: false, whichViewport);
				}
			}
		}
		if (control.Name == dataGridView_0.Name && ((e.RowIndex >= 0) & (e.ColumnIndex >= 0)))
		{
			int result2 = -1;
			int.TryParse(dataGridView_0.Rows[e.RowIndex].Cells[0].Value.ToString(), out result2);
			if (result2 >= 1)
			{
				int Index2 = -1;
				FindToolIndexFromToolNo(result2, ref Index2);
				if (Index2 >= 0)
				{
					if (e.ColumnIndex == 1)
					{
						clsDrill.ToolList[Index2].Geometry.Diameter = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[1].Value);
					}
					if (e.ColumnIndex == 2)
					{
						clsDrill.ToolList[Index2].Geometry.Length = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[2].Value);
					}
					if (e.ColumnIndex == 3)
					{
						clsDrill.ToolList[Index2].Geometry.CutLength = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[3].Value);
					}
					if (e.ColumnIndex == 7)
					{
						clsDrill.ToolList[Index2].Limits.AxesMinLimits.Y = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[7].Value);
					}
					if (e.ColumnIndex == 4)
					{
						if (CommonOffset)
						{
							clsDrill.ToolList[Index2].Positions.CommonOffset.X = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[4].Value);
						}
						else
						{
							clsDrill.ToolList[Index2].Positions.Offset.X = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[4].Value);
						}
					}
					if (e.ColumnIndex == 5)
					{
						if (CommonOffset)
						{
							clsDrill.ToolList[Index2].Positions.CommonOffset.Y = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[5].Value);
						}
						else
						{
							clsDrill.ToolList[Index2].Positions.Offset.Y = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[5].Value);
						}
					}
					if (e.ColumnIndex == 8)
					{
						clsDrill.ToolList[Index2].CamData.PlungeSpeed = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[8].Value);
					}
					if (e.ColumnIndex == 9)
					{
						clsDrill.ToolList[Index2].CamData.WaitTime = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[9].Value);
					}
					int whichViewport2 = -1;
					if (clsDrill.ToolList[Index2].Data.GroupIndex == 0)
					{
						whichViewport2 = 0;
					}
					if (clsDrill.ToolList[Index2].Data.GroupIndex == 1)
					{
						whichViewport2 = 1;
					}
					if (clsDrill.ToolList[Index2].Data.GroupIndex == 2)
					{
						whichViewport2 = 2;
					}
					DrawEntities(ClearGrids: false, whichViewport2);
				}
			}
		}
		if (!(control.Name == dataGridView_2.Name) || !((e.RowIndex >= 0) & (e.ColumnIndex >= 0)))
		{
			return;
		}
		int result3 = -1;
		int.TryParse(dataGridView_2.Rows[e.RowIndex].Cells[0].Value.ToString(), out result3);
		if (result3 < 1)
		{
			return;
		}
		int Index3 = -1;
		FindToolIndexFromToolNo(result3, ref Index3);
		if (Index3 < 0)
		{
			return;
		}
		if (e.ColumnIndex == 1)
		{
			clsDrill.ToolList[Index3].Geometry.Diameter = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[1].Value);
		}
		if (e.ColumnIndex == 2)
		{
			clsDrill.ToolList[Index3].Geometry.Length = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[2].Value);
		}
		if (e.ColumnIndex == 3)
		{
			clsDrill.ToolList[Index3].Geometry.CutLength = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[3].Value);
		}
		if (e.ColumnIndex == 7)
		{
			clsDrill.ToolList[Index3].Limits.AxesMinLimits.Y = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[7].Value);
		}
		if (e.ColumnIndex == 4)
		{
			if (CommonOffset)
			{
				clsDrill.ToolList[Index3].Positions.CommonOffset.X = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[4].Value);
			}
			else
			{
				clsDrill.ToolList[Index3].Positions.Offset.X = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[4].Value);
			}
		}
		if (e.ColumnIndex == 5)
		{
			if (CommonOffset)
			{
				clsDrill.ToolList[Index3].Positions.CommonOffset.Y = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[5].Value);
			}
			else
			{
				clsDrill.ToolList[Index3].Positions.Offset.Y = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[5].Value);
			}
		}
		if (e.ColumnIndex == 8)
		{
			clsDrill.ToolList[Index3].CamData.PlungeSpeed = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[8].Value);
		}
		if (e.ColumnIndex == 9)
		{
			clsDrill.ToolList[Index3].CamData.WaitTime = Convert.ToDouble(dataGridView_2.Rows[e.RowIndex].Cells[9].Value);
		}
		int whichViewport3 = -1;
		if (clsDrill.ToolList[Index3].Data.GroupIndex == 0)
		{
			whichViewport3 = 0;
		}
		if (clsDrill.ToolList[Index3].Data.GroupIndex == 1)
		{
			whichViewport3 = 1;
		}
		if (clsDrill.ToolList[Index3].Data.GroupIndex == 20)
		{
			whichViewport3 = 2;
		}
		DrawEntities(ClearGrids: false, whichViewport3);
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == checkBox_0.Name && PropertiesForm.Inited)
		{
			CommonOffset = checkBox_0.Checked;
			DrawEntities(ClearGrids: true, -1);
		}
		if (control.Name == checkBox_1.Name && PropertiesForm.Inited)
		{
			settingRuntime.ToolExpertMode = checkBox_1.Checked;
			ExpertMoveView(settingRuntime.ToolExpertMode);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == button_1.Name)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			base.Visible = false;
		}
		if (control.Name == button_0.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			Class5.smethod_95(this);
			clsInit.appDrill.SaveToolConfigFile(clsDrill.fileNameToolSetting);
			base.Visible = false;
		}
		if (control.Name == btn_savetools.Name)
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
		if (control.Name == btn_opentools.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathTool;
			openFileDialog.Filter = "AES Drill Tool File (*.AEStool)|*.AEStool";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				clsDrill.varDrillRunSettings.pathTool = buFile5.GetPath(openFileDialog.FileName);
				clsInit.appDrill.OpenToolConfigFile(openFileDialog.FileName);
				clsInit.appDrill.SaveDrillFile();
				Init();
			}
		}
	}

	private void viewportBottom_MouseDown(object sender, MouseEventArgs e)
	{
		Design design = (Design)sender;
		if (viewportRight != null && design.Name == viewportRight.Name)
		{
			int[] allEntitiesUnderMouseCursor = viewportRight.GetAllEntitiesUnderMouseCursor(e.Location);
			if (((allEntitiesUnderMouseCursor != null) & (e.Button == MouseButtons.Left)) && allEntitiesUnderMouseCursor.Length != 0)
			{
				for (int i = 0; i <= viewportRight.Entities.Count - 1; i++)
				{
					viewportRight.Entities[i].Selected = false;
				}
				viewportRight.Entities[allEntitiesUnderMouseCursor[0]].Selected = true;
				string text = viewportRight.Entities[allEntitiesUnderMouseCursor[0]].EntityData.ToString();
				for (int j = 0; j <= dataGridView_1.Rows.Count - 1; j++)
				{
					dataGridView_1.Rows[j].Selected = false;
					if (dataGridView_1.Rows[j].Cells[0].Value.ToString() == text)
					{
						dataGridView_1.Rows[j].Selected = true;
					}
				}
				FindToolMeshFromToolNo(text, 0);
			}
			viewportRight.Invalidate();
		}
		if (viewportLeft != null && design.Name == viewportLeft.Name)
		{
			int[] allEntitiesUnderMouseCursor2 = viewportLeft.GetAllEntitiesUnderMouseCursor(e.Location);
			if (((allEntitiesUnderMouseCursor2 != null) & (e.Button == MouseButtons.Left)) && allEntitiesUnderMouseCursor2.Length != 0)
			{
				for (int k = 0; k <= viewportLeft.Entities.Count - 1; k++)
				{
					viewportLeft.Entities[k].Selected = false;
				}
				viewportLeft.Entities[allEntitiesUnderMouseCursor2[0]].Selected = true;
				string text2 = viewportLeft.Entities[allEntitiesUnderMouseCursor2[0]].EntityData.ToString();
				for (int l = 0; l <= dataGridView_0.Rows.Count - 1; l++)
				{
					dataGridView_0.Rows[l].Selected = false;
					if (dataGridView_0.Rows[l].Cells[0].Value.ToString() == text2)
					{
						dataGridView_0.Rows[l].Selected = true;
					}
				}
				FindToolMeshFromToolNo(text2, 1);
			}
			viewportLeft.Invalidate();
		}
		if (viewportBottom == null || !(design.Name == viewportBottom.Name))
		{
			return;
		}
		int[] allEntitiesUnderMouseCursor3 = viewportBottom.GetAllEntitiesUnderMouseCursor(e.Location);
		if (((allEntitiesUnderMouseCursor3 != null) & (e.Button == MouseButtons.Left)) && allEntitiesUnderMouseCursor3.Length != 0)
		{
			for (int m = 0; m <= viewportBottom.Entities.Count - 1; m++)
			{
				viewportBottom.Entities[m].Selected = false;
			}
			viewportBottom.Entities[allEntitiesUnderMouseCursor3[0]].Selected = true;
			string text3 = viewportBottom.Entities[allEntitiesUnderMouseCursor3[0]].EntityData.ToString();
			for (int n = 0; n <= dataGridView_2.Rows.Count - 1; n++)
			{
				dataGridView_2.Rows[n].Selected = false;
				if (dataGridView_2.Rows[n].Cells[0].Value.ToString() == text3)
				{
					dataGridView_2.Rows[n].Selected = true;
				}
			}
			FindToolMeshFromToolNo(text3, 2);
		}
		viewportBottom.Invalidate();
	}

	public void ExpertMoveView(bool ExperMode)
	{
		checkBox_0.Visible = ExperMode;
		if (dataGridView_1 != null && dataGridView_1.Columns.Count > 3)
		{
			dataGridView_1.Columns[4].Visible = ExperMode;
			dataGridView_1.Columns[5].Visible = ExperMode;
			dataGridView_1.Columns[6].Visible = ExperMode;
			dataGridView_1.Columns[7].Visible = ExperMode;
		}
		if (dataGridView_0 != null && dataGridView_0.Columns.Count > 3)
		{
			dataGridView_0.Columns[4].Visible = ExperMode;
			dataGridView_0.Columns[5].Visible = ExperMode;
			dataGridView_0.Columns[6].Visible = ExperMode;
			dataGridView_0.Columns[7].Visible = ExperMode;
		}
		if (dataGridView_2 != null && dataGridView_2.Columns.Count > 3)
		{
			dataGridView_2.Columns[4].Visible = ExperMode;
			dataGridView_2.Columns[5].Visible = ExperMode;
			dataGridView_2.Columns[6].Visible = ExperMode;
			dataGridView_2.Columns[7].Visible = ExperMode;
		}
	}

	public void FindToolIndexFromToolNo(int ToolNo, ref int Index)
	{
		for (int i = 0; i <= clsDrill.ToolList.Count - 1; i++)
		{
			if (clsDrill.ToolList[i].Data.No == ToolNo)
			{
				Index = i;
			}
		}
	}

	public void FindToolMeshFromToolNo(string ToolNo, int WhichViewport)
	{
		if ((WhichViewport == 0) & (viewportRight != null))
		{
			for (int i = 0; i <= viewportRight.Entities.Count - 1; i++)
			{
				if (!(viewportRight.Entities[i] is Mesh))
				{
					continue;
				}
				viewportRight.Entities[i].Selected = false;
				if (viewportRight.Entities[i].EntityData != null)
				{
					string text = viewportRight.Entities[i].EntityData.ToString();
					if (text == ToolNo)
					{
						viewportRight.Entities[i].Selected = true;
					}
				}
			}
			viewportRight.Invalidate();
		}
		if ((WhichViewport == 1) & (viewportLeft != null))
		{
			for (int j = 0; j <= viewportLeft.Entities.Count - 1; j++)
			{
				if (!(viewportLeft.Entities[j] is Mesh))
				{
					continue;
				}
				viewportLeft.Entities[j].Selected = false;
				if (viewportLeft.Entities[j].EntityData != null)
				{
					string text2 = viewportLeft.Entities[j].EntityData.ToString();
					if (text2 == ToolNo)
					{
						viewportLeft.Entities[j].Selected = true;
					}
				}
			}
			viewportLeft.Invalidate();
		}
		if (!((WhichViewport == 2) & (viewportBottom != null)))
		{
			return;
		}
		for (int k = 0; k <= viewportBottom.Entities.Count - 1; k++)
		{
			if (!(viewportBottom.Entities[k] is Mesh))
			{
				continue;
			}
			viewportBottom.Entities[k].Selected = false;
			if (viewportBottom.Entities[k].EntityData != null)
			{
				string text3 = viewportBottom.Entities[k].EntityData.ToString();
				if (text3 == ToolNo)
				{
					viewportBottom.Entities[k].Selected = true;
				}
			}
		}
		viewportBottom.Invalidate();
	}

	public void DrawEntities(bool ClearGrids, int WhichViewport)
	{
		if ((WhichViewport == -1 || WhichViewport == 0) & (viewportRight != null))
		{
			for (int i = 0; i <= viewportRight.Entities.Count - 1; i++)
			{
				if (viewportRight.Entities[i] is Mesh)
				{
					viewportRight.Entities[i].Selected = true;
				}
			}
			viewportRight.Entities.DeleteSelected();
		}
		if ((WhichViewport == -1 || WhichViewport == 1) & (viewportLeft != null))
		{
			for (int j = 0; j <= viewportLeft.Entities.Count - 1; j++)
			{
				if (viewportLeft.Entities[j] is Mesh)
				{
					viewportLeft.Entities[j].Selected = true;
				}
			}
			viewportLeft.Entities.DeleteSelected();
		}
		if ((WhichViewport == -1 || WhichViewport == 2) & (viewportBottom != null))
		{
			for (int k = 0; k <= viewportBottom.Entities.Count - 1; k++)
			{
				if (viewportBottom.Entities[k] is Mesh)
				{
					viewportBottom.Entities[k].Selected = true;
				}
			}
			viewportBottom.Entities.DeleteSelected();
		}
		if (ClearGrids)
		{
			dataGridView_0.Rows.Clear();
			dataGridView_1.Rows.Clear();
			dataGridView_2.Rows.Clear();
		}
		for (int l = 0; l <= clsDrill.ToolList.Count - 1; l++)
		{
			if (clsDrill.ToolList[l] == null)
			{
				continue;
			}
			if (ClearGrids)
			{
				if (CommonOffset)
				{
					if ((clsDrill.ToolList[l].Data.GroupIndex == 0) & (viewportRight != null))
					{
						DataGridViewRowCollection rows = dataGridView_1.Rows;
						int no = clsDrill.ToolList[l].Data.No;
						double diameter = clsDrill.ToolList[l].Geometry.Diameter;
						double length = clsDrill.ToolList[l].Geometry.Length;
						double cutLength = clsDrill.ToolList[l].Geometry.CutLength;
						double double_ = clsDrill.ToolList[l].Positions.CommonOffset.X;
						double double_2 = clsDrill.ToolList[l].Positions.CommonOffset.Y;
						double z = clsDrill.ToolList[l].Positions.CommonOffset.Z;
						double double_3 = clsDrill.ToolList[l].Limits.AxesMinLimits.Y;
						double plungeSpeed = clsDrill.ToolList[l].CamData.PlungeSpeed;
						double waitTime = clsDrill.ToolList[l].CamData.WaitTime;
						rows.Add(Class5.smethod_51(double_3, this, waitTime, plungeSpeed, diameter, no, double_2, length, double_, z, cutLength));
					}
					if ((clsDrill.ToolList[l].Data.GroupIndex == 1) & (viewportLeft != null))
					{
						DataGridViewRowCollection rows2 = dataGridView_0.Rows;
						int no = clsDrill.ToolList[l].Data.No;
						double diameter = clsDrill.ToolList[l].Geometry.Diameter;
						double length = clsDrill.ToolList[l].Geometry.Length;
						double cutLength = clsDrill.ToolList[l].Geometry.CutLength;
						double double_ = clsDrill.ToolList[l].Positions.CommonOffset.X;
						double double_2 = clsDrill.ToolList[l].Positions.CommonOffset.Y;
						double z = clsDrill.ToolList[l].Positions.CommonOffset.Z;
						double double_3 = clsDrill.ToolList[l].Limits.AxesMinLimits.Y;
						double plungeSpeed = clsDrill.ToolList[l].CamData.PlungeSpeed;
						double waitTime = clsDrill.ToolList[l].CamData.WaitTime;
						rows2.Add(Class5.smethod_51(double_3, this, waitTime, plungeSpeed, diameter, no, double_2, length, double_, z, cutLength));
					}
					if ((clsDrill.ToolList[l].Data.GroupIndex == 2) & (viewportBottom != null))
					{
						DataGridViewRowCollection rows3 = dataGridView_2.Rows;
						int no = clsDrill.ToolList[l].Data.No;
						double diameter = clsDrill.ToolList[l].Geometry.Diameter;
						double length = clsDrill.ToolList[l].Geometry.Length;
						double cutLength = clsDrill.ToolList[l].Geometry.CutLength;
						double double_ = clsDrill.ToolList[l].Positions.CommonOffset.X;
						double double_2 = clsDrill.ToolList[l].Positions.CommonOffset.Y;
						double z = clsDrill.ToolList[l].Positions.CommonOffset.Z;
						double double_3 = clsDrill.ToolList[l].Limits.AxesMinLimits.Y;
						double plungeSpeed = clsDrill.ToolList[l].CamData.PlungeSpeed;
						double waitTime = clsDrill.ToolList[l].CamData.WaitTime;
						rows3.Add(Class5.smethod_51(double_3, this, waitTime, plungeSpeed, diameter, no, double_2, length, double_, z, cutLength));
					}
				}
				else
				{
					if ((clsDrill.ToolList[l].Data.GroupIndex == 0) & (viewportRight != null))
					{
						DataGridViewRowCollection rows4 = dataGridView_1.Rows;
						int no = clsDrill.ToolList[l].Data.No;
						double diameter = clsDrill.ToolList[l].Geometry.Diameter;
						double length = clsDrill.ToolList[l].Geometry.Length;
						double cutLength = clsDrill.ToolList[l].Geometry.CutLength;
						double double_ = clsDrill.ToolList[l].Positions.Offset.X;
						double double_2 = clsDrill.ToolList[l].Positions.Offset.Y;
						double z = clsDrill.ToolList[l].Positions.Offset.Z;
						double double_3 = clsDrill.ToolList[l].Limits.AxesMinLimits.Y;
						double plungeSpeed = clsDrill.ToolList[l].CamData.PlungeSpeed;
						double waitTime = clsDrill.ToolList[l].CamData.WaitTime;
						rows4.Add(Class5.smethod_51(double_3, this, waitTime, plungeSpeed, diameter, no, double_2, length, double_, z, cutLength));
					}
					if ((clsDrill.ToolList[l].Data.GroupIndex == 1) & (viewportLeft != null))
					{
						DataGridViewRowCollection rows5 = dataGridView_0.Rows;
						int no = clsDrill.ToolList[l].Data.No;
						double diameter = clsDrill.ToolList[l].Geometry.Diameter;
						double length = clsDrill.ToolList[l].Geometry.Length;
						double cutLength = clsDrill.ToolList[l].Geometry.CutLength;
						double double_ = clsDrill.ToolList[l].Positions.Offset.X;
						double double_2 = clsDrill.ToolList[l].Positions.Offset.Y;
						double z = clsDrill.ToolList[l].Positions.Offset.Z;
						double double_3 = clsDrill.ToolList[l].Limits.AxesMinLimits.Y;
						double plungeSpeed = clsDrill.ToolList[l].CamData.PlungeSpeed;
						double waitTime = clsDrill.ToolList[l].CamData.WaitTime;
						rows5.Add(Class5.smethod_51(double_3, this, waitTime, plungeSpeed, diameter, no, double_2, length, double_, z, cutLength));
					}
					if ((clsDrill.ToolList[l].Data.GroupIndex == 2) & (viewportBottom != null))
					{
						DataGridViewRowCollection rows6 = dataGridView_2.Rows;
						int no = clsDrill.ToolList[l].Data.No;
						double diameter = clsDrill.ToolList[l].Geometry.Diameter;
						double length = clsDrill.ToolList[l].Geometry.Length;
						double cutLength = clsDrill.ToolList[l].Geometry.CutLength;
						double double_ = clsDrill.ToolList[l].Positions.Offset.X;
						double double_2 = clsDrill.ToolList[l].Positions.Offset.Y;
						double z = clsDrill.ToolList[l].Positions.Offset.Z;
						double double_3 = clsDrill.ToolList[l].Limits.AxesMinLimits.Y;
						double plungeSpeed = clsDrill.ToolList[l].CamData.PlungeSpeed;
						double waitTime = clsDrill.ToolList[l].CamData.WaitTime;
						rows6.Add(Class5.smethod_51(double_3, this, waitTime, plungeSpeed, diameter, no, double_2, length, double_, z, cutLength));
					}
				}
			}
			List<Mesh> refMeshes = new List<Mesh>();
			clsDrill.ToolList[l].Geometry.LowerRadius = 0.0;
			clsDrill.ToolList[l].Geometry.UpperRadius = 0.0;
			clsDrill.ToolList[l].Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			clsInit.appMW.CreateToolWithToolDirection(clsDrill.ToolList[l], ToolCut: true, ToolBody: true, Arbor: false, Holder: false, ZeroIsMachineSide: true, ref refMeshes);
			for (int m = 0; m <= refMeshes.Count - 1; m++)
			{
				refMeshes[m].Color = Color.FromArgb(255, refMeshes[m].Color);
				if (!isGo)
				{
					if (!isSirius)
					{
						if (UseCommponOffsetToolDrawing)
						{
							if ((clsDrill.ToolList[l].Data.No >= 61) & (clsDrill.ToolList[l].Data.No <= 71) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 72) & (clsDrill.ToolList[l].Data.No <= 79) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No == 80) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No == 85) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 161) & (clsDrill.ToolList[l].Data.No <= 171) & (viewportLeft != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 172) & (clsDrill.ToolList[l].Data.No <= 179) & (viewportLeft != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No == 185) & (viewportLeft != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolSawZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 261) & (clsDrill.ToolList[l].Data.No <= 269) & (viewportBottom != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolVerticalZOffset + 80.0);
							}
							if ((clsDrill.ToolList[l].Data.No == 270) & (viewportBottom != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolMillingZOffset + 150.0);
							}
						}
						else
						{
							if ((clsDrill.ToolList[l].Data.No >= 61) & (clsDrill.ToolList[l].Data.No <= 71) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 72) & (clsDrill.ToolList[l].Data.No <= 79) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No == 80) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No == 85) & (viewportRight != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 161) & (clsDrill.ToolList[l].Data.No <= 171) & (viewportLeft != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolVerticalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 172) & (clsDrill.ToolList[l].Data.No <= 179) & (viewportLeft != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolHorizontalZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No == 185) & (viewportLeft != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y2GroupToolSawZOffset);
							}
							if ((clsDrill.ToolList[l].Data.No >= 261) & (clsDrill.ToolList[l].Data.No <= 269) & (viewportBottom != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolVerticalZOffset + 80.0);
							}
							if ((clsDrill.ToolList[l].Data.No == 270) & (viewportBottom != null))
							{
								refMeshes[m].Translate(clsDrill.ToolList[l].Positions.Offset.X, 0.0 - clsDrill.ToolList[l].Positions.Offset.Y, clsDrill.varDrillCNCSettings.Y3GroupToolMillingZOffset + 150.0);
							}
						}
					}
					else
					{
						if ((clsDrill.ToolList[l].Data.No >= 61) & (clsDrill.ToolList[l].Data.No <= 70) & (viewportRight != null))
						{
							refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
						}
						if ((clsDrill.ToolList[l].Data.No >= 71) & (clsDrill.ToolList[l].Data.No <= 79) & (viewportRight != null))
						{
							refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
						}
						if ((clsDrill.ToolList[l].Data.No == 31) & (viewportRight != null))
						{
							refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
						}
						if ((clsDrill.ToolList[l].Data.No == 95) & (viewportRight != null))
						{
							refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
						}
					}
				}
				else
				{
					if ((clsDrill.ToolList[l].Data.No >= 61) & (clsDrill.ToolList[l].Data.No <= 70) & (viewportRight != null))
					{
						refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolVerticalZOffset);
					}
					if ((clsDrill.ToolList[l].Data.No >= 71) & (clsDrill.ToolList[l].Data.No <= 79) & (viewportRight != null))
					{
						refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolHorizontalZOffset);
					}
					if ((clsDrill.ToolList[l].Data.No == 31) & (viewportRight != null))
					{
						refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolMillingZOffset);
					}
					if ((clsDrill.ToolList[l].Data.No == 95) & (viewportRight != null))
					{
						refMeshes[m].Translate(clsDrill.ToolList[l].Positions.CommonOffset.X, clsDrill.ToolList[l].Positions.CommonOffset.Y, clsDrill.varDrillCNCSettings.Y1GroupToolSawZOffset);
					}
				}
				refMeshes[m].EntityData = clsDrill.ToolList[l].Data.No;
				if ((clsDrill.ToolList[l].Data.GroupIndex == 0 && (WhichViewport == -1 || WhichViewport == 0)) & (viewportRight != null))
				{
					viewportRight.Entities.Add(refMeshes[m]);
				}
				if ((clsDrill.ToolList[l].Data.GroupIndex == 1 && (WhichViewport == -1 || WhichViewport == 1)) & (viewportLeft != null))
				{
					viewportLeft.Entities.Add(refMeshes[m]);
				}
				if ((clsDrill.ToolList[l].Data.GroupIndex == 2 && (WhichViewport == -1 || WhichViewport == 2)) & (viewportBottom != null))
				{
					viewportBottom.Entities.Add(refMeshes[m]);
				}
			}
		}
		if (viewportLeft != null)
		{
			viewportLeft.Invalidate();
		}
		if (viewportRight != null)
		{
			viewportRight.Invalidate();
		}
		if (viewportBottom != null)
		{
			viewportBottom.Invalidate();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
