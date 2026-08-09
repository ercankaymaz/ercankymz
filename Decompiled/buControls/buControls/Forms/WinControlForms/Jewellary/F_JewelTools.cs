using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

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

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	public int selRowSpindle = 0;

	public int selRowEngraving = 0;

	public int selRowDiaCut1 = 0;

	public int selRowDiaCut2 = 0;

	public int selRowLathe = 0;

	public int selRowLaser = 0;

	internal IContainer icontainer_0 = null;

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

	public event OkCommandEventHandler OkPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Combine(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Remove(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
	}

	public F_JewelTools()
	{
		Class76.smethod_514(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		DtSpindle = new DataTable();
		if (CaptionGrid.Count >= 12)
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[0], Type.GetType("System.String"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[1], Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[2], Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[3], Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[4], Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[5], Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[6], Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[7], Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
		}
		else
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("Name", Type.GetType("System.String"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("Length", Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("XOffset", Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("YOffset", Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("ZOffset", Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("XPosition", Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("YPosition", Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
			Col = new DataColumn("ZPosition", Type.GetType("System.Double"));
			DtSpindle.Columns.Add(Col);
		}
		DGV_Spindle.DataSource = DtSpindle;
		DGV_Spindle.RowHeadersVisible = false;
		DGV_Spindle.AllowUserToAddRows = false;
		DGV_Spindle.AllowUserToResizeColumns = false;
		DGV_Spindle.Columns[0].Width = 40;
		DGV_Spindle.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[1].Width = 250;
		DGV_Spindle.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[2].Width = 100;
		DGV_Spindle.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[3].Width = 100;
		DGV_Spindle.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[4].Width = 100;
		DGV_Spindle.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[5].Width = 100;
		DGV_Spindle.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[6].Width = 100;
		DGV_Spindle.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[7].Width = 100;
		DGV_Spindle.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[8].Width = 100;
		DGV_Spindle.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Spindle.Columns[6].Visible = ShowPositions;
		DGV_Spindle.Columns[7].Visible = ShowPositions;
		DGV_Spindle.Columns[8].Visible = ShowPositions;
		DtEngraving = new DataTable();
		if (CaptionGrid.Count >= 12)
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[0], Type.GetType("System.String"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[1], Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[2], Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[3], Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[4], Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
		}
		else
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn("Name", Type.GetType("System.String"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn("Length", Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn("XOffset", Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn("YOffset", Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
			Col = new DataColumn("ZOffset", Type.GetType("System.Double"));
			DtEngraving.Columns.Add(Col);
		}
		DGV_Engraving.DataSource = DtEngraving;
		DGV_Engraving.RowHeadersVisible = false;
		DGV_Engraving.AllowUserToAddRows = false;
		DGV_Engraving.AllowUserToResizeColumns = false;
		DGV_Engraving.Columns[0].Width = 40;
		DGV_Engraving.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Engraving.Columns[1].Width = 250;
		DGV_Engraving.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Engraving.Columns[2].Width = 100;
		DGV_Engraving.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Engraving.Columns[3].Width = 100;
		DGV_Engraving.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Engraving.Columns[4].Width = 100;
		DGV_Engraving.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Engraving.Columns[5].Width = 100;
		DGV_Engraving.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
		DtDiamondCut1 = new DataTable();
		if (CaptionGrid.Count >= 12)
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[0], Type.GetType("System.String"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[1], Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[2], Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[3], Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[4], Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
		}
		else
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn("Name", Type.GetType("System.String"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn("Length", Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn("XOffset", Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn("YOffset", Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
			Col = new DataColumn("ZOffset", Type.GetType("System.Double"));
			DtDiamondCut1.Columns.Add(Col);
		}
		DGV_DiamondCut1.DataSource = DtDiamondCut1;
		DGV_DiamondCut1.RowHeadersVisible = false;
		DGV_DiamondCut1.AllowUserToAddRows = false;
		DGV_DiamondCut1.AllowUserToResizeColumns = false;
		DGV_DiamondCut1.Columns[0].Width = 40;
		DGV_DiamondCut1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut1.Columns[1].Width = 250;
		DGV_DiamondCut1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut1.Columns[2].Width = 100;
		DGV_DiamondCut1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut1.Columns[3].Width = 100;
		DGV_DiamondCut1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut1.Columns[4].Width = 100;
		DGV_DiamondCut1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut1.Columns[5].Width = 100;
		DGV_DiamondCut1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
		DtDiamondCut2 = new DataTable();
		if (CaptionGrid.Count >= 12)
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[0], Type.GetType("System.String"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[1], Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[2], Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[3], Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[4], Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
		}
		else
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn("Name", Type.GetType("System.String"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn("Length", Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn("XOffset", Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn("YOffset", Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
			Col = new DataColumn("ZOffset", Type.GetType("System.Double"));
			DtDiamondCut2.Columns.Add(Col);
		}
		DGV_DiamondCut2.DataSource = DtDiamondCut2;
		DGV_DiamondCut2.RowHeadersVisible = false;
		DGV_DiamondCut2.AllowUserToAddRows = false;
		DGV_DiamondCut2.AllowUserToResizeColumns = false;
		DGV_DiamondCut2.Columns[0].Width = 40;
		DGV_DiamondCut2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut2.Columns[1].Width = 250;
		DGV_DiamondCut2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut2.Columns[2].Width = 100;
		DGV_DiamondCut2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut2.Columns[3].Width = 100;
		DGV_DiamondCut2.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut2.Columns[4].Width = 100;
		DGV_DiamondCut2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_DiamondCut2.Columns[5].Width = 100;
		DGV_DiamondCut2.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
		DtLathe = new DataTable();
		if (CaptionGrid.Count >= 12)
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[0], Type.GetType("System.String"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[1], Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[2], Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[3], Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[4], Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
		}
		else
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn("Name", Type.GetType("System.String"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn("Length", Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn("XOffset", Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn("YOffset", Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
			Col = new DataColumn("ZOffset", Type.GetType("System.Double"));
			DtLathe.Columns.Add(Col);
		}
		DGV_Lathe.DataSource = DtLathe;
		DGV_Lathe.RowHeadersVisible = false;
		DGV_Lathe.AllowUserToAddRows = false;
		DGV_Lathe.AllowUserToResizeColumns = false;
		DGV_Lathe.Columns[0].Width = 40;
		DGV_Lathe.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Lathe.Columns[1].Width = 250;
		DGV_Lathe.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Lathe.Columns[2].Width = 100;
		DGV_Lathe.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Lathe.Columns[3].Width = 100;
		DGV_Lathe.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Lathe.Columns[4].Width = 100;
		DGV_Lathe.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Lathe.Columns[5].Width = 100;
		DGV_Lathe.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
		DtLaser = new DataTable();
		if (CaptionGrid.Count >= 12)
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[0], Type.GetType("System.String"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[1], Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[2], Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[3], Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn(CaptionGrid[4], Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
		}
		else
		{
			Col = new DataColumn("No", Type.GetType("System.Int32"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn("Name", Type.GetType("System.String"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn("Length", Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn("XOffset", Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn("YOffset", Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
			Col = new DataColumn("ZOffset", Type.GetType("System.Double"));
			DtLaser.Columns.Add(Col);
		}
		DGV_Laser.DataSource = DtLaser;
		DGV_Laser.RowHeadersVisible = false;
		DGV_Laser.AllowUserToAddRows = false;
		DGV_Laser.AllowUserToResizeColumns = false;
		DGV_Laser.Columns[0].Width = 40;
		DGV_Laser.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Laser.Columns[1].Width = 250;
		DGV_Laser.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Laser.Columns[2].Width = 100;
		DGV_Laser.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Laser.Columns[3].Width = 100;
		DGV_Laser.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Laser.Columns[4].Width = 100;
		DGV_Laser.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV_Laser.Columns[5].Width = 100;
		DGV_Laser.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
		for (int i = 0; i <= ToolSpindle.Count - 1; i++)
		{
			DtSpindle.Rows.Add(AddNewSpindleToolRow(ref DtSpindle, i + 1, ToolSpindle[i]));
		}
		for (int j = 0; j <= ToolDiamondCut1.Count - 1; j++)
		{
			DtDiamondCut1.Rows.Add(AddNewToolRow(ref DtDiamondCut1, j + 1, ToolDiamondCut1[j]));
		}
		for (int k = 0; k <= ToolDiamondCut2.Count - 1; k++)
		{
			DtDiamondCut2.Rows.Add(AddNewToolRow(ref DtDiamondCut2, k + 1, ToolDiamondCut2[k]));
		}
		for (int l = 0; l <= ToolEngraving.Count - 1; l++)
		{
			DtEngraving.Rows.Add(AddNewToolRow(ref DtEngraving, l + 1, ToolEngraving[l]));
		}
		for (int m = 0; m <= ToolLaser.Count - 1; m++)
		{
			DtLaser.Rows.Add(AddNewToolRow(ref DtLaser, m + 1, ToolLaser[m]));
		}
		for (int n = 0; n <= ToolLathe.Count - 1; n++)
		{
			DtLathe.Rows.Add(AddNewToolRow(ref DtLathe, n + 1, ToolLathe[n]));
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = (DataGridView)sender;
		if (e.RowIndex >= 0)
		{
			if (dataGridView.Name == DGV_Spindle.Name)
			{
				selRowSpindle = e.RowIndex;
			}
			if (dataGridView.Name == DGV_Engraving.Name)
			{
				selRowEngraving = e.RowIndex;
			}
			if (dataGridView.Name == DGV_DiamondCut1.Name)
			{
				selRowDiaCut1 = e.RowIndex;
			}
			if (dataGridView.Name == DGV_DiamondCut2.Name)
			{
				selRowDiaCut2 = e.RowIndex;
			}
			if (dataGridView.Name == DGV_Lathe.Name)
			{
				selRowLathe = e.RowIndex;
			}
			if (dataGridView.Name == DGV_Laser.Name)
			{
				selRowLaser = e.RowIndex;
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_save.Name)
		{
			SaveTools();
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			if (okCommandEventHandler_0 != null)
			{
				okCommandEventHandler_0();
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void SaveTools()
	{
		ToolSpindle.Clear();
		for (int i = 0; i <= DGV_Spindle.Rows.Count - 1; i++)
		{
			ToolBase toolBase = new ToolBase();
			toolBase.Data.No = i + 1;
			toolBase.Data.Name = DGV_Spindle.Rows[i].Cells[1].Value.ToString();
			toolBase.Geometry.Length = Convert.ToDouble(DGV_Spindle.Rows[i].Cells[2].Value);
			toolBase.Positions.Offset = new Pnt6D(Convert.ToDouble(DGV_Spindle.Rows[i].Cells[3].Value), Convert.ToDouble(DGV_Spindle.Rows[i].Cells[4].Value), Convert.ToDouble(DGV_Spindle.Rows[i].Cells[5].Value));
			toolBase.Positions.Position = new Pnt6D(Convert.ToDouble(DGV_Spindle.Rows[i].Cells[6].Value), Convert.ToDouble(DGV_Spindle.Rows[i].Cells[7].Value), Convert.ToDouble(DGV_Spindle.Rows[i].Cells[8].Value));
			ToolSpindle.Add(toolBase);
		}
		ToolDiamondCut1.Clear();
		for (int j = 0; j <= DGV_DiamondCut1.Rows.Count - 1; j++)
		{
			ToolBase toolBase2 = new ToolBase();
			toolBase2.Data.No = j + 1;
			toolBase2.Data.Name = DGV_DiamondCut1.Rows[j].Cells[1].Value.ToString();
			toolBase2.Geometry.Length = Convert.ToDouble(DGV_DiamondCut1.Rows[j].Cells[2].Value);
			toolBase2.Positions.Offset = new Pnt6D(Convert.ToDouble(DGV_DiamondCut1.Rows[j].Cells[3].Value), Convert.ToDouble(DGV_DiamondCut1.Rows[j].Cells[4].Value), Convert.ToDouble(DGV_DiamondCut1.Rows[j].Cells[5].Value));
			ToolDiamondCut1.Add(toolBase2);
		}
		ToolDiamondCut2.Clear();
		for (int k = 0; k <= DGV_DiamondCut2.Rows.Count - 1; k++)
		{
			ToolBase toolBase3 = new ToolBase();
			toolBase3.Data.No = k + 1;
			toolBase3.Data.Name = DGV_DiamondCut2.Rows[k].Cells[1].Value.ToString();
			toolBase3.Geometry.Length = Convert.ToDouble(DGV_DiamondCut2.Rows[k].Cells[2].Value);
			toolBase3.Positions.Offset = new Pnt6D(Convert.ToDouble(DGV_DiamondCut2.Rows[k].Cells[3].Value), Convert.ToDouble(DGV_DiamondCut2.Rows[k].Cells[4].Value), Convert.ToDouble(DGV_DiamondCut2.Rows[k].Cells[5].Value));
			ToolDiamondCut2.Add(toolBase3);
		}
		ToolEngraving.Clear();
		for (int l = 0; l <= DGV_Engraving.Rows.Count - 1; l++)
		{
			ToolBase toolBase4 = new ToolBase();
			toolBase4.Data.No = l + 1;
			toolBase4.Data.Name = DGV_Engraving.Rows[l].Cells[1].Value.ToString();
			toolBase4.Geometry.Length = Convert.ToDouble(DGV_Engraving.Rows[l].Cells[2].Value);
			toolBase4.Positions.Offset = new Pnt6D(Convert.ToDouble(DGV_Engraving.Rows[l].Cells[3].Value), Convert.ToDouble(DGV_Engraving.Rows[l].Cells[4].Value), Convert.ToDouble(DGV_Engraving.Rows[l].Cells[5].Value));
			ToolEngraving.Add(toolBase4);
		}
		ToolLaser.Clear();
		for (int m = 0; m <= DGV_Laser.Rows.Count - 1; m++)
		{
			ToolBase toolBase5 = new ToolBase();
			toolBase5.Data.No = m + 1;
			toolBase5.Data.Name = DGV_Laser.Rows[m].Cells[1].Value.ToString();
			toolBase5.Geometry.Length = Convert.ToDouble(DGV_Laser.Rows[m].Cells[2].Value);
			toolBase5.Positions.Offset = new Pnt6D(Convert.ToDouble(DGV_Laser.Rows[m].Cells[3].Value), Convert.ToDouble(DGV_Laser.Rows[m].Cells[4].Value), Convert.ToDouble(DGV_Laser.Rows[m].Cells[5].Value));
			ToolLaser.Add(toolBase5);
		}
		ToolLathe.Clear();
		for (int n = 0; n <= DGV_Lathe.Rows.Count - 1; n++)
		{
			ToolBase toolBase6 = new ToolBase();
			toolBase6.Data.No = n + 1;
			toolBase6.Data.Name = DGV_Lathe.Rows[n].Cells[1].Value.ToString();
			toolBase6.Geometry.Length = Convert.ToDouble(DGV_Lathe.Rows[n].Cells[2].Value);
			toolBase6.Positions.Offset = new Pnt6D(Convert.ToDouble(DGV_Lathe.Rows[n].Cells[3].Value), Convert.ToDouble(DGV_Lathe.Rows[n].Cells[4].Value), Convert.ToDouble(DGV_Lathe.Rows[n].Cells[5].Value));
			ToolLathe.Add(toolBase6);
		}
	}

	public DataRow AddNewToolRow(ref DataTable dt, int index, ToolBase tool)
	{
		DataRow dataRow = dt.NewRow();
		dataRow[0] = index;
		dataRow[1] = tool.Data.Name;
		dataRow[2] = Math.Round(tool.Geometry.Length, 2);
		dataRow[3] = Math.Round(tool.Positions.Offset.X, 2);
		dataRow[4] = Math.Round(tool.Positions.Offset.Y, 2);
		dataRow[5] = Math.Round(tool.Positions.Offset.Z, 2);
		return dataRow;
	}

	public DataRow AddNewSpindleToolRow(ref DataTable dt, int index, ToolBase tool)
	{
		DataRow dataRow = dt.NewRow();
		dataRow[0] = index;
		dataRow[1] = tool.Data.Name;
		dataRow[2] = Math.Round(tool.Geometry.Length, 2);
		dataRow[3] = Math.Round(tool.Positions.Offset.X, 2);
		dataRow[4] = Math.Round(tool.Positions.Offset.Y, 2);
		dataRow[5] = Math.Round(tool.Positions.Offset.Z, 2);
		dataRow[6] = Math.Round(tool.Positions.Position.X, 2);
		dataRow[7] = Math.Round(tool.Positions.Position.Y, 2);
		dataRow[8] = Math.Round(tool.Positions.Position.Z, 2);
		return dataRow;
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
