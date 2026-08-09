using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Variables;
using devDept.Eyeshot.Control;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_NotchList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public Design viewportLayout;

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler_0;

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public bool ShowViewport = true;

	public bool ShowCamSettings = true;

	public bool ShowTool = false;

	public bool ShowObjectPosition = true;

	public bool ShowCornerLocation = true;

	public bool EnableLeftPlane = true;

	public bool EnableRightPlane = true;

	public bool EnableFrontPlane = true;

	public bool EnableBackPlane = true;

	public bool EnableFreePlane = true;

	public bool ClosePageAfterOk = false;

	public List<ToolBase5> Tools = new List<ToolBase5>();

	public ToolBase5 activeTool = null;

	public ShapeRuntimeData parShape = new ShapeRuntimeData();

	public List<SelectedPlaneInfo> selectedPlanes = new List<SelectedPlaneInfo>();

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private int int_0 = -1;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal ImageList imageList_2;

	internal ImageList imageList_3;

	internal ImageList imageList_4;

	internal ImageList imageList_5;

	internal Panel panel_0;

	public Button btn_toolsettings;

	public ComboBox cmb_tools;

	public Panel pnl_model;

	internal ListView listView_0;

	public Button btn_camsettings;

	internal Panel panel_1;

	internal Label label_0;

	public Button btn_front;

	internal Label label_1;

	public Button btn_back;

	internal Label label_2;

	internal Label label_3;

	public Button btn_left;

	public Button btn_right;

	public Button btn_ok;

	public Button btn_cancel;

	public DataGridView dgv_data;

	public RadioButton radio_kertmeLdown;

	public RadioButton radio_kertmeLup;

	internal Label label_4;

	internal Panel panel_2;

	public RadioButton radio_back;

	public RadioButton radio_front;

	internal Panel panel_3;

	public Label lbl_Editing;

	public DataGridView dgv_list;

	public event OkCommandWithThreeDataEventHandler DataOk
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Combine(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Remove(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
	}

	public event OkCommandWithTwoDataEventHandler CommandOk
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler DataCancel
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_NotchList()
	{
		Class186.smethod_291(this);
		timer_0.Interval = 100;
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
		listView_0.Items.Clear();
		listView_0.Items.Add(buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Side, 0);
		listView_0.Items.Add(buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Length, 1);
		listView_0.Items.Add(buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Vertical, 2);
		listView_0.Items.Add(buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Horizontal, 3);
		pnl_model.Visible = ShowViewport;
		cmb_tools.Visible = ShowTool;
		btn_camsettings.Visible = ShowCamSettings;
		btn_toolsettings.Visible = ShowTool;
		btn_back.Enabled = EnableBackPlane;
		btn_front.Enabled = EnableFrontPlane;
		btn_left.Enabled = EnableLeftPlane;
		btn_right.Enabled = EnableRightPlane;
		if (dgv_data.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = Convert.ToInt32((double)dgv_data.Width * 0.65);
			dataGridViewColumn.HeaderText = "Name";
			dataGridViewColumn.Name = "Name";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dgv_data.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = dgv_data.Width - dataGridViewColumn.Width - 20;
			dataGridViewColumn2.HeaderText = "Value";
			dataGridViewColumn2.Name = "Value";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dgv_data.Columns.Add(dataGridViewColumn2);
			dgv_data.CellValueChanged += dgv_data_CellValueChanged;
			dgv_data.CellClick += dgv_data_CellClick;
			dgv_data.CellDoubleClick += dgv_data_CellDoubleClick;
			dgv_data.CellEnter += dgv_data_CellEnter;
			dgv_data.RowHeadersVisible = false;
			dgv_data.ColumnHeadersVisible = false;
			dgv_data.AllowUserToAddRows = false;
			dgv_data.AllowUserToResizeColumns = false;
			dgv_data.AllowUserToResizeRows = false;
			dgv_data.MultiSelect = false;
		}
		if (dgv_list.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 1;
			dataGridViewColumn3.HeaderText = "Name";
			dataGridViewColumn3.Name = "Name";
			dataGridViewColumn3.ReadOnly = true;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dgv_list.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = Convert.ToInt32(dgv_list.Width - 2);
			dataGridViewColumn4.HeaderText = "Name";
			dataGridViewColumn4.Name = "Name";
			dataGridViewColumn4.ReadOnly = true;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dgv_list.Columns.Add(dataGridViewColumn4);
			dgv_list.ScrollBars = ScrollBars.None;
			dgv_list.RowTemplate.Height = 15;
			dgv_list.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
			dgv_list.DefaultCellStyle.Font = new Font("Arial", 9f, FontStyle.Bold);
			dgv_list.DefaultCellStyle.SelectionBackColor = Color.Transparent;
			dgv_list.DefaultCellStyle.SelectionForeColor = Color.Black;
			dgv_list.RowHeadersVisible = false;
			dgv_list.ColumnHeadersVisible = false;
			dgv_list.AllowUserToAddRows = false;
			dgv_list.AllowUserToResizeColumns = false;
			dgv_list.AllowUserToResizeRows = false;
			dgv_list.MultiSelect = false;
		}
		listView_0.ForeColor = Color.Red;
		if (parShape.ShapeType == ShapeTypes.Notch)
		{
			if (parShape.NotchOPType == ProfileNotchOperationType.Side)
			{
				listView_0.Items[0].Focused = true;
				listView_0.Items[0].Selected = true;
				listView_0.FocusedItem = listView_0.Items[0];
				int_0 = 0;
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Length)
			{
				listView_0.Items[1].Focused = true;
				listView_0.Items[1].Selected = true;
				listView_0.FocusedItem = listView_0.Items[1];
				int_0 = 1;
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Vertical)
			{
				listView_0.Items[2].Focused = true;
				listView_0.Items[2].Selected = true;
				listView_0.FocusedItem = listView_0.Items[2];
				int_0 = 2;
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
			{
				listView_0.Items[3].Focused = true;
				listView_0.Items[3].Selected = true;
				listView_0.FocusedItem = listView_0.Items[3];
				int_0 = 3;
			}
		}
		ShapeToDataGrid(int_0);
		cmb_tools.Items.Clear();
		if (ShowTool)
		{
			int num = -1;
			int num2 = -1;
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				string item = buCall.buVector5_0.ToolToString(Tools[i]);
				cmb_tools.Items.Add(item);
				if (Tools[i].Geometry.GeometryType == ToolType.Saw)
				{
					num2 = -1;
				}
				if (activeTool != null && Tools[i].Data.Name == activeTool.Data.Name && Tools[i].Geometry.GeometryType == ToolType.Saw)
				{
					num = i;
				}
			}
			if (cmb_tools.Items.Count <= 0)
			{
				ShowTool = false;
			}
			else if (num < 0)
			{
				if (num2 >= 0)
				{
					cmb_tools.SelectedIndex = num;
				}
			}
			else
			{
				cmb_tools.SelectedIndex = num;
			}
		}
		if (!bool_0)
		{
			if (!(!ShowViewport & !ShowTool))
			{
				if (!(!ShowViewport & ShowTool))
				{
					if (ShowViewport & !ShowTool)
					{
						pnl_model.Height += btn_toolsettings.Height;
					}
				}
				else
				{
					dgv_data.Height += pnl_model.Height;
				}
			}
			else
			{
				dgv_data.Height = dgv_data.Height + pnl_model.Height + btn_toolsettings.Height;
			}
			int num3 = Convert.ToInt32((double)base.Width / 6.0);
			btn_back.Width = num3 - 10;
			label_1.Width = num3 - 10;
			btn_right.Width = num3 - 10;
			label_3.Width = num3 - 10;
			btn_front.Width = num3 - 10;
			label_2.Width = num3 - 10;
			btn_left.Width = num3 - 10;
			label_0.Width = num3 - 10;
			label_0.Left = btn_left.Left;
			btn_right.Left = btn_left.Left + btn_left.Width + 5;
			label_3.Left = btn_right.Left;
			btn_front.Left = btn_right.Left + btn_right.Width + 5;
			label_2.Left = btn_front.Left;
			btn_back.Left = btn_front.Left + btn_front.Width + 5;
			label_1.Left = btn_back.Left;
			bool_0 = true;
		}
		LoadLanguage();
		PlaneColorUpdate();
		PropertiesForm.Inited = false;
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result == DialogResult.OK)
		{
			return;
		}
		e.Cancel = true;
		PropertiesForm.Result = DialogResult.Cancel;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Class186.smethod_157(this);
		btn_ok.Enabled = true;
		timer_0.Enabled = false;
		if (parShape.NotchOPType != ProfileNotchOperationType.Side)
		{
			if (parShape.NotchOPType != ProfileNotchOperationType.Length)
			{
				if (parShape.NotchOPType != ProfileNotchOperationType.Vertical)
				{
					if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
					{
						if (parShape.NotchSideLocation != ProfileNotchLocationType.Left)
						{
							method_2(btn_right, e);
						}
						else
						{
							method_2(btn_left, e);
						}
					}
				}
				else if (parShape.NotchSideLocation != ProfileNotchLocationType.Left)
				{
					method_2(btn_right, e);
				}
				else
				{
					method_2(btn_left, e);
				}
			}
			else if (parShape.NotchLengthLocation != ProfileNotchLocationType.Front)
			{
				method_2(btn_back, e);
			}
			else
			{
				method_2(btn_front, e);
			}
		}
		else if (parShape.NotchSideLocation != ProfileNotchLocationType.Left)
		{
			method_2(btn_right, e);
		}
		else
		{
			method_2(btn_left, e);
		}
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			label_0.Text = buLangTranslate.preDef.Left;
			label_3.Text = buLangTranslate.preDef.Right;
			label_1.Text = buLangTranslate.preDef.Back;
			label_2.Text = buLangTranslate.preDef.Front;
			Text = buLangTranslate.preDef.Notch;
			label_4.Text = buLangTranslate.preDef.Profile;
			radio_kertmeLdown.Text = buLangTranslate.preDef.Down;
			radio_kertmeLup.Text = buLangTranslate.preDef.Up;
			btn_camsettings.Text = buLangTranslate.preDef.Cam;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			radio_front.Text = buLangTranslate.preDef.Front;
			radio_back.Text = buLangTranslate.preDef.Back;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void PlaneColorUpdate()
	{
		if ((parShape.NotchOPType == ProfileNotchOperationType.Side) | (parShape.NotchOPType == ProfileNotchOperationType.Length))
		{
			panel_3.Enabled = true;
			panel_2.Enabled = false;
		}
		if (parShape.NotchOPType == ProfileNotchOperationType.Vertical)
		{
			panel_3.Enabled = false;
			panel_2.Enabled = true;
		}
		if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
		{
			panel_3.Enabled = false;
			panel_2.Enabled = false;
		}
		btn_back.BackColor = Color.Gainsboro;
		btn_right.BackColor = Color.Gainsboro;
		btn_front.BackColor = Color.Gainsboro;
		btn_left.BackColor = Color.Gainsboro;
		if (!((parShape.NotchOPType == ProfileNotchOperationType.Side) | (parShape.NotchOPType == ProfileNotchOperationType.Vertical)))
		{
			if (parShape.NotchOPType != ProfileNotchOperationType.Length)
			{
				if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
				{
					if ((parShape.NotchSideLocation != ProfileNotchLocationType.Left) & (parShape.NotchSideLocation != ProfileNotchLocationType.Right))
					{
						parShape.NotchSideLocation = ProfileNotchLocationType.Left;
					}
					if (parShape.NotchSideLocation != ProfileNotchLocationType.Left)
					{
						btn_right.BackColor = Color.PaleGreen;
					}
					else
					{
						btn_left.BackColor = Color.PaleGreen;
					}
				}
			}
			else
			{
				if ((parShape.NotchSideLocation != ProfileNotchLocationType.Front) & (parShape.NotchSideLocation != ProfileNotchLocationType.Back))
				{
					parShape.NotchSideLocation = ProfileNotchLocationType.Front;
				}
				if (parShape.NotchLengthLocation != ProfileNotchLocationType.Front)
				{
					btn_back.BackColor = Color.PaleGreen;
				}
				else
				{
					btn_front.BackColor = Color.PaleGreen;
				}
			}
		}
		else
		{
			if ((parShape.NotchSideLocation != ProfileNotchLocationType.Left) & (parShape.NotchSideLocation != ProfileNotchLocationType.Right))
			{
				parShape.NotchSideLocation = ProfileNotchLocationType.Left;
			}
			if (parShape.NotchSideLocation != ProfileNotchLocationType.Left)
			{
				btn_right.BackColor = Color.PaleGreen;
			}
			else
			{
				btn_left.BackColor = Color.PaleGreen;
			}
		}
	}

	public void Apply()
	{
	}

	public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
	{
		if (dgv_data.Rows.Count >= 2)
		{
			parShape.ShapeType = ShapeTypes.Notch;
			if (parShape.NotchOPType == ProfileNotchOperationType.Side)
			{
				parShape.NotchStartHeight = Convert.ToDouble(dgv_data.Rows[0].Cells[1].Value);
				parShape.NotchHeight = Convert.ToDouble(dgv_data.Rows[1].Cells[1].Value);
				parShape.NotchDepth = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
				parShape.pntBase.Z = parShape.NotchStartHeight;
				parShape.ShapeGroup = ShapeGroup.Notch;
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Length)
			{
				parShape.pntBase.X = Convert.ToDouble(dgv_data.Rows[0].Cells[1].Value);
				parShape.NotchStartHeight = Convert.ToDouble(dgv_data.Rows[1].Cells[1].Value);
				parShape.NotchWidth = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
				parShape.NotchHeight = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
				parShape.NotchDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
				parShape.pntBase.Z = parShape.NotchStartHeight;
				parShape.ShapeGroup = ShapeGroup.Notch;
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Vertical)
			{
				parShape.NotchStartHeight = Convert.ToDouble(dgv_data.Rows[0].Cells[1].Value);
				parShape.NotchHeight = Convert.ToDouble(dgv_data.Rows[1].Cells[1].Value);
				parShape.NotchDepth = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
				parShape.pntBase.Y = parShape.NotchStartHeight;
				parShape.ShapeGroup = ShapeGroup.Notch;
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
			{
				parShape.pntBase.X = Convert.ToDouble(dgv_data.Rows[0].Cells[1].Value);
				parShape.pntBase.Y = Convert.ToDouble(dgv_data.Rows[1].Cells[1].Value);
				parShape.NotchWidth = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
				parShape.NotchHeight = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
				parShape.NotchDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
				parShape.ShapeGroup = ShapeGroup.Notch;
			}
		}
	}

	public void ShapeToDataGrid(int Index)
	{
		bool inited = PropertiesForm.Inited;
		dgv_data.Rows.Clear();
		if (parShape.NotchOPType == ProfileNotchOperationType.Side)
		{
			DataGridViewRowCollection rows = dgv_data.Rows;
			string string_ = "Z";
			double notchStartHeight = parShape.NotchStartHeight;
			rows.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows2 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Height;
			notchStartHeight = parShape.NotchHeight;
			rows2.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows3 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			notchStartHeight = parShape.NotchDepth;
			rows3.Add(Class186.smethod_425(string_, notchStartHeight, this));
		}
		if (parShape.NotchOPType == ProfileNotchOperationType.Length)
		{
			DataGridViewRowCollection rows4 = dgv_data.Rows;
			string string_ = "X";
			double notchStartHeight = parShape.pntBase.X;
			rows4.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows5 = dgv_data.Rows;
			string_ = "Z";
			notchStartHeight = parShape.NotchStartHeight;
			rows5.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows6 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Width;
			notchStartHeight = parShape.NotchWidth;
			rows6.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows7 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Height;
			notchStartHeight = parShape.NotchHeight;
			rows7.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows8 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			notchStartHeight = parShape.NotchDepth;
			rows8.Add(Class186.smethod_425(string_, notchStartHeight, this));
		}
		if (parShape.NotchOPType == ProfileNotchOperationType.Vertical)
		{
			DataGridViewRowCollection rows9 = dgv_data.Rows;
			string string_ = "Y";
			double notchStartHeight = parShape.NotchStartHeight;
			rows9.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows10 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Height;
			notchStartHeight = parShape.NotchHeight;
			rows10.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows11 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			notchStartHeight = parShape.NotchDepth;
			rows11.Add(Class186.smethod_425(string_, notchStartHeight, this));
		}
		if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
		{
			DataGridViewRowCollection rows12 = dgv_data.Rows;
			string string_ = "X";
			double notchStartHeight = parShape.pntBase.X;
			rows12.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows13 = dgv_data.Rows;
			string_ = "Y";
			notchStartHeight = parShape.pntBase.Y;
			rows13.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows14 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Width;
			notchStartHeight = parShape.NotchWidth;
			rows14.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows15 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Height;
			notchStartHeight = parShape.NotchHeight;
			rows15.Add(Class186.smethod_425(string_, notchStartHeight, this));
			DataGridViewRowCollection rows16 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			notchStartHeight = parShape.NotchDepth;
			rows16.Add(Class186.smethod_425(string_, notchStartHeight, this));
		}
		if (parShape.NotchUpDown == UpDownLocationType.Up)
		{
			radio_kertmeLup.Checked = true;
		}
		if (parShape.NotchUpDown == UpDownLocationType.Down)
		{
			radio_kertmeLdown.Checked = true;
		}
		if (parShape.NotchFrontBack == FrontBackType.Front)
		{
			radio_front.Checked = true;
		}
		if (parShape.NotchFrontBack == FrontBackType.Back)
		{
			radio_back.Checked = true;
		}
		PropertiesForm.Inited = inited;
	}

	private void dgv_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (!PropertiesForm.Inited || !((e.ColumnIndex >= 0) & (e.RowIndex >= 0)))
		{
			return;
		}
		ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
		DataGridValuesToShape(e.ColumnIndex, e.RowIndex);
		if (okCommandWithThreeDataEventHandler_0 != null)
		{
			shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
			if (ProfileTempVars.OperationEditing & parShape.UpdateEditOperationWithoutOk)
			{
				shapeUpdateArg.Finished = true;
			}
			okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
		}
	}

	private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0) & (clsVar5.ShapeTempPar.ValueGridIndex != e.RowIndex)))
		{
			clsVar5.ShapeTempPar.ValueGridIndex = e.RowIndex;
			buCall.buProfileCalc_0.FindNotchDataValueType(parShape, e.RowIndex, ref clsVar5.ShapeTempPar.ValueType);
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(parShape);
				shapeUpdateArg.Command = "DrawDim";
				shapeUpdateArg.ValueType = clsVar5.ShapeTempPar.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
		}
	}

	private void dgv_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0)))
		{
		}
	}

	private void dgv_data_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0) & (clsVar5.ShapeTempPar.ValueGridIndex != e.RowIndex)))
		{
			clsVar5.ShapeTempPar.ValueGridIndex = e.RowIndex;
			buCall.buProfileCalc_0.FindNotchDataValueType(parShape, e.RowIndex, ref clsVar5.ShapeTempPar.ValueType);
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(parShape);
				shapeUpdateArg.Command = "DrawDim";
				shapeUpdateArg.ValueType = clsVar5.ShapeTempPar.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == radio_kertmeLdown.Name)
		{
			if (!radio_kertmeLdown.Checked)
			{
				parShape.NotchUpDown = UpDownLocationType.Up;
			}
			else
			{
				parShape.NotchUpDown = UpDownLocationType.Down;
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(parShape);
				shapeUpdateArg.Parameters.selectedPlane = planeBoxNames.Top;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
		}
		if (control.Name == radio_kertmeLup.Name)
		{
			if (!radio_kertmeLup.Checked)
			{
				parShape.NotchUpDown = UpDownLocationType.Down;
			}
			else
			{
				parShape.NotchUpDown = UpDownLocationType.Up;
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg2 = new ShapeUpdateArg(parShape);
				shapeUpdateArg2.Parameters.selectedPlane = planeBoxNames.Top;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg2, null);
			}
		}
		if (control.Name == radio_front.Name)
		{
			if (!radio_front.Checked)
			{
				parShape.NotchFrontBack = FrontBackType.Back;
			}
			else
			{
				parShape.NotchFrontBack = FrontBackType.Front;
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg3 = new ShapeUpdateArg(parShape);
				shapeUpdateArg3.Parameters.selectedPlane = planeBoxNames.Top;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg3, null);
			}
		}
		if (control.Name == radio_back.Name)
		{
			if (!radio_back.Checked)
			{
				parShape.NotchFrontBack = FrontBackType.Front;
			}
			else
			{
				parShape.NotchFrontBack = FrontBackType.Back;
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg4 = new ShapeUpdateArg(parShape);
				shapeUpdateArg4.Parameters.selectedPlane = planeBoxNames.Top;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg4, null);
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			if (ClosePageAfterOk)
			{
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				DataGridValuesToShape(-1, -1);
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(parShape);
				shapeUpdateArg.Finished = true;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
				if (base.Owner != null)
				{
					base.Owner.Focus();
				}
			}
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
		}
		if (control.Name == btn_camsettings.Name)
		{
			F_NotchCamSettings f_NotchCamSettings = new F_NotchCamSettings();
			f_NotchCamSettings.CamPar = new camParameters5(parShape.CamPars);
			f_NotchCamSettings.StartPosition = FormStartPosition.CenterScreen;
			f_NotchCamSettings.Init();
			f_NotchCamSettings.ShowDialog();
			if (f_NotchCamSettings.Properties.Result == DialogResult.OK && okCommandWithThreeDataEventHandler_0 != null)
			{
				parShape.CamPars = new camParameters5(f_NotchCamSettings.CamPar);
				ShapeUpdateArg data = new ShapeUpdateArg(parShape);
				okCommandWithThreeDataEventHandler_0(null, data, null);
			}
			Focus();
		}
		if (control.Name == btn_toolsettings.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("ToolEdit", "");
		}
		if (control.Name == btn_left.Name)
		{
			if (parShape.NotchOPType == ProfileNotchOperationType.Side)
			{
				int indexRow = -1;
				int indexCol = -1;
				GetRowColIndex(ref indexRow, ref indexCol);
				PropertiesForm.Inited = false;
				parShape.selectedPlane = planeBoxNames.Top;
				parShape.NotchSideLocation = ProfileNotchLocationType.Left;
				PlaneColorUpdate();
				ShapeToDataGrid(int_0);
				PropertiesForm.Inited = true;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					SetRowColIndex(indexRow, indexCol);
					ShapeUpdateArg data2 = new ShapeUpdateArg(parShape);
					okCommandWithThreeDataEventHandler_0(null, data2, null);
				}
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Vertical)
			{
				int indexRow2 = -1;
				int indexCol2 = -1;
				GetRowColIndex(ref indexRow2, ref indexCol2);
				PropertiesForm.Inited = false;
				parShape.selectedPlane = planeBoxNames.Top;
				parShape.NotchSideLocation = ProfileNotchLocationType.Left;
				PlaneColorUpdate();
				ShapeToDataGrid(int_0);
				PropertiesForm.Inited = true;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					SetRowColIndex(indexRow2, indexCol2);
					ShapeUpdateArg data3 = new ShapeUpdateArg(parShape);
					okCommandWithThreeDataEventHandler_0(null, data3, null);
				}
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
			{
				int indexRow3 = -1;
				int indexCol3 = -1;
				GetRowColIndex(ref indexRow3, ref indexCol3);
				PropertiesForm.Inited = false;
				parShape.selectedPlane = planeBoxNames.Top;
				parShape.NotchSideLocation = ProfileNotchLocationType.Left;
				PlaneColorUpdate();
				ShapeToDataGrid(int_0);
				PropertiesForm.Inited = true;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					SetRowColIndex(indexRow3, indexCol3);
					ShapeUpdateArg data4 = new ShapeUpdateArg(parShape);
					okCommandWithThreeDataEventHandler_0(null, data4, null);
				}
			}
		}
		if (control.Name == btn_right.Name)
		{
			if (parShape.NotchOPType == ProfileNotchOperationType.Side)
			{
				int indexRow4 = -1;
				int indexCol4 = -1;
				GetRowColIndex(ref indexRow4, ref indexCol4);
				PropertiesForm.Inited = false;
				parShape.selectedPlane = planeBoxNames.Top;
				parShape.NotchSideLocation = ProfileNotchLocationType.Right;
				PlaneColorUpdate();
				ShapeToDataGrid(int_0);
				PropertiesForm.Inited = true;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					SetRowColIndex(indexRow4, indexCol4);
					ShapeUpdateArg data5 = new ShapeUpdateArg(parShape);
					okCommandWithThreeDataEventHandler_0(null, data5, null);
				}
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Vertical)
			{
				int indexRow5 = -1;
				int indexCol5 = -1;
				GetRowColIndex(ref indexRow5, ref indexCol5);
				PropertiesForm.Inited = false;
				parShape.selectedPlane = planeBoxNames.Top;
				parShape.NotchSideLocation = ProfileNotchLocationType.Right;
				PlaneColorUpdate();
				ShapeToDataGrid(int_0);
				PropertiesForm.Inited = true;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					SetRowColIndex(indexRow5, indexCol5);
					ShapeUpdateArg data6 = new ShapeUpdateArg(parShape);
					okCommandWithThreeDataEventHandler_0(null, data6, null);
				}
			}
			if (parShape.NotchOPType == ProfileNotchOperationType.Horizontal)
			{
				int indexRow6 = -1;
				int indexCol6 = -1;
				GetRowColIndex(ref indexRow6, ref indexCol6);
				PropertiesForm.Inited = false;
				parShape.selectedPlane = planeBoxNames.Top;
				parShape.NotchSideLocation = ProfileNotchLocationType.Right;
				PlaneColorUpdate();
				ShapeToDataGrid(int_0);
				PropertiesForm.Inited = true;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					SetRowColIndex(indexRow6, indexCol6);
					ShapeUpdateArg data7 = new ShapeUpdateArg(parShape);
					okCommandWithThreeDataEventHandler_0(null, data7, null);
				}
			}
		}
		if (control.Name == btn_front.Name && parShape.NotchOPType == ProfileNotchOperationType.Length)
		{
			int indexRow7 = -1;
			int indexCol7 = -1;
			GetRowColIndex(ref indexRow7, ref indexCol7);
			PropertiesForm.Inited = false;
			parShape.selectedPlane = planeBoxNames.Top;
			parShape.NotchLengthLocation = ProfileNotchLocationType.Front;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				SetRowColIndex(indexRow7, indexCol7);
				ShapeUpdateArg data8 = new ShapeUpdateArg(parShape);
				okCommandWithThreeDataEventHandler_0(null, data8, null);
			}
		}
		if (control.Name == btn_back.Name && parShape.NotchOPType == ProfileNotchOperationType.Length)
		{
			int indexRow8 = -1;
			int indexCol8 = -1;
			GetRowColIndex(ref indexRow8, ref indexCol8);
			PropertiesForm.Inited = false;
			parShape.selectedPlane = planeBoxNames.Top;
			parShape.NotchLengthLocation = ProfileNotchLocationType.Back;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				SetRowColIndex(indexRow8, indexCol8);
				ShapeUpdateArg data9 = new ShapeUpdateArg(parShape);
				okCommandWithThreeDataEventHandler_0(null, data9, null);
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			if ((cmb_tools.SelectedIndex >= 0) & (cmb_tools.SelectedIndex <= Tools.Count - 1))
			{
				activeTool = new ToolBase5(Tools[cmb_tools.SelectedIndex]);
			}
			if ((okCommandWithThreeDataEventHandler_0 != null) & (activeTool != null))
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
				shapeUpdateArg.ToolName = activeTool.Data.Name;
				shapeUpdateArg.ToolChangeForced = true;
				shapeUpdateArg.ToolIndex = cmb_tools.SelectedIndex;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
			PropertiesForm.Inited = false;
			Apply();
			PropertiesForm.Inited = true;
		}
	}

	internal void method_4(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ItemIndex >= 0) & e.IsSelected))
		{
			PropertiesForm.Inited = false;
			if (e.ItemIndex == 0)
			{
				parShape.NotchOPType = ProfileNotchOperationType.Side;
			}
			if (e.ItemIndex == 1)
			{
				parShape.NotchOPType = ProfileNotchOperationType.Length;
			}
			if (e.ItemIndex == 2)
			{
				parShape.NotchOPType = ProfileNotchOperationType.Vertical;
			}
			if (e.ItemIndex == 3)
			{
				parShape.NotchOPType = ProfileNotchOperationType.Horizontal;
			}
			PlaneColorUpdate();
			ShapeToDataGrid(e.ItemIndex);
			int_0 = e.ItemIndex;
			PropertiesForm.Inited = true;
			clsVar5.ShapeTempPar.ValueGridIndex = 0;
			buCall.buProfileCalc_0.FindNotchDataValueType(parShape, 0, ref clsVar5.ShapeTempPar.ValueType);
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				parShape.ValueType = clsVar5.ShapeTempPar.ValueType;
				shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
				shapeUpdateArg.ValueType = clsVar5.ShapeTempPar.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
		}
	}

	public void GetRowColIndex(ref int indexRow, ref int indexCol)
	{
		indexCol = -1;
		indexRow = -1;
		if (dgv_data.CurrentCell != null)
		{
			indexRow = dgv_data.CurrentCell.RowIndex;
			indexCol = dgv_data.CurrentCell.ColumnIndex;
		}
	}

	public void SetRowColIndex(int indexRow, int indexCol)
	{
		if (((indexRow >= 0) & (indexRow <= dgv_data.Rows.Count - 1)) && ((indexCol >= 0) & (indexCol <= dgv_data.Columns.Count - 1)))
		{
			dgv_data.CurrentCell = dgv_data.Rows[indexRow].Cells[indexCol];
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
