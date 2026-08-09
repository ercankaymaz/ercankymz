using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Variables;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Shape;

public class F_EngraveList : Form
{
	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public Design viewportLayout;

	public bool ShowViewport = true;

	public bool ShowCamSettings = true;

	public bool ShowTool = false;

	public bool ShowObjectPosition = true;

	public bool ShowCornerLocation = true;

	public bool EnableTopPlane = true;

	public bool EnableBottomPlane = true;

	public bool EnableLeftPlane = true;

	public bool EnableRightPlane = true;

	public bool EnableFrontPlane = true;

	public bool EnableBacktPlane = true;

	public bool ClosePageAfterOk = true;

	public Entity entMesh = null;

	public List<ToolBase5> Tools = new List<ToolBase5>();

	public ToolBase5 activeTool = null;

	public buShape selectedShape = null;

	public camParameters5 CamPar = null;

	public ShapeRuntimeData parShape = new ShapeRuntimeData();

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private int int_0 = -1;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	public Panel pnl_model;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal DataGridView dataGridView_0;

	internal Panel panel_0;

	public Button btn_front;

	public Button btn_back;

	public Button btn_right;

	public Button btn_left;

	public Button btn_top;

	public Button btn_bottom;

	internal PictureBox pictureBox_0;

	internal Button button_0;

	public Button btn_camsettings;

	public Button btn_toolsettings;

	public ComboBox cmb_tools;

	internal Button button_1;

	internal ImageList imageList_2;

	internal ImageList imageList_3;

	internal ImageList imageList_4;

	internal ImageList imageList_5;

	internal Button button_2;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal CheckBox checkBox_0;

	public event OkCommandWithTwoDataEventHandler DataOk
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

	public F_EngraveList()
	{
		Class186.smethod_238(this);
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
		int_0 = 0;
		pnl_model.Visible = ShowViewport;
		cmb_tools.Visible = ShowTool;
		btn_camsettings.Visible = ShowCamSettings;
		btn_toolsettings.Visible = ShowTool;
		button_1.Visible = ShowObjectPosition;
		button_0.Visible = ShowCornerLocation;
		button_1.ImageIndex = Convert.ToInt32(parShape.objectAlignment);
		button_0.ImageIndex = Convert.ToInt32(parShape.selectedCorner);
		btn_back.Enabled = EnableBacktPlane;
		btn_front.Enabled = EnableFrontPlane;
		btn_top.Enabled = EnableTopPlane;
		btn_bottom.Enabled = EnableBottomPlane;
		btn_left.Enabled = EnableLeftPlane;
		btn_right.Enabled = EnableRightPlane;
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = Convert.ToInt32((double)dataGridView_0.Width * 0.65);
			dataGridViewColumn.HeaderText = "Name";
			dataGridViewColumn.Name = "Name";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = dataGridView_0.Width - dataGridViewColumn.Width - 20;
			dataGridViewColumn2.HeaderText = "Value";
			dataGridViewColumn2.Name = "Value";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
			dataGridView_0.CellClick += dataGridView_0_CellClick;
			dataGridView_0.CellEnter += dataGridView_0_CellEnter;
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.ColumnHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		cmb_tools.Items.Clear();
		if (ShowTool)
		{
			int selectedIndex = -1;
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				string item = Tools[i].Data.Name + " - T" + Tools[i].Data.No + " - D: " + Tools[i].Geometry.Diameter.ToString("f1");
				cmb_tools.Items.Add(item);
				if (activeTool != null && Tools[i].Data.Name == activeTool.Data.Name)
				{
					selectedIndex = i;
				}
			}
			if (cmb_tools.Items.Count <= 0)
			{
				ShowTool = false;
			}
			else
			{
				cmb_tools.SelectedIndex = selectedIndex;
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
					dataGridView_0.Height += pnl_model.Height;
				}
			}
			else
			{
				dataGridView_0.Height = dataGridView_0.Height + pnl_model.Height + btn_toolsettings.Height;
			}
			int num = Convert.ToInt32((double)base.Width / 6.0);
			btn_back.Width = num - 10;
			label_4.Width = num - 10;
			btn_bottom.Width = num - 10;
			label_6.Width = num - 10;
			btn_front.Width = num - 10;
			label_5.Width = num - 10;
			btn_left.Width = num - 10;
			label_3.Width = num - 10;
			btn_right.Width = num - 10;
			label_1.Width = num - 10;
			btn_top.Width = num - 10;
			label_2.Width = num - 10;
			label_2.Left = btn_top.Left;
			btn_bottom.Left = btn_top.Left + btn_top.Width + 5;
			label_6.Left = btn_bottom.Left;
			btn_front.Left = btn_bottom.Left + btn_bottom.Width + 5;
			label_5.Left = btn_front.Left;
			btn_back.Left = btn_front.Left + btn_front.Width + 5;
			label_4.Left = btn_back.Left;
			btn_left.Left = btn_back.Left + btn_back.Width + 5;
			label_3.Left = btn_left.Left;
			btn_right.Left = btn_left.Left + btn_left.Width + 5;
			label_1.Left = btn_right.Left;
			bool_0 = true;
		}
		LoadLanguage();
		PlaneColorUpdate();
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Class186.smethod_83(this);
		btn_ok.Enabled = true;
		timer_0.Enabled = false;
		if (parShape.selectedPlane == planeBoxNames.Top)
		{
			method_1(btn_top, e);
		}
		if (parShape.selectedPlane == planeBoxNames.Bottom)
		{
			method_1(btn_bottom, e);
		}
		if (parShape.selectedPlane == planeBoxNames.Front)
		{
			method_1(btn_front, e);
		}
		if (parShape.selectedPlane == planeBoxNames.Back)
		{
			method_1(btn_back, e);
		}
		if (parShape.selectedPlane == planeBoxNames.Left)
		{
			method_1(btn_left, e);
		}
		if (parShape.selectedPlane == planeBoxNames.Right)
		{
			method_1(btn_right, e);
		}
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
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

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			Text = buLangTranslate.preDef.Engraving;
			label_2.Text = buLangTranslate.preDef.Top;
			label_4.Text = buLangTranslate.preDef.Back;
			label_6.Text = buLangTranslate.preDef.Bottom;
			label_0.Text = buLangTranslate.preDef.Command;
			label_5.Text = buLangTranslate.preDef.Front;
			label_3.Text = buLangTranslate.preDef.Left;
			label_1.Text = buLangTranslate.preDef.Right;
			btn_camsettings.Text = buLangTranslate.preDef.Cam;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
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
		btn_back.BackColor = Color.Gainsboro;
		btn_bottom.BackColor = Color.Gainsboro;
		btn_front.BackColor = Color.Gainsboro;
		btn_left.BackColor = Color.Gainsboro;
		btn_right.BackColor = Color.Gainsboro;
		btn_top.BackColor = Color.Gainsboro;
		if (parShape.selectedPlane == planeBoxNames.Top)
		{
			btn_top.BackColor = Color.PaleGreen;
		}
		if (parShape.selectedPlane == planeBoxNames.Bottom)
		{
			btn_bottom.BackColor = Color.PaleGreen;
		}
		if (parShape.selectedPlane == planeBoxNames.Front)
		{
			btn_front.BackColor = Color.PaleGreen;
		}
		if (parShape.selectedPlane == planeBoxNames.Back)
		{
			btn_back.BackColor = Color.PaleGreen;
		}
		if (parShape.selectedPlane == planeBoxNames.Left)
		{
			btn_left.BackColor = Color.PaleGreen;
		}
		if (parShape.selectedPlane == planeBoxNames.Right)
		{
			btn_right.BackColor = Color.PaleGreen;
		}
	}

	public void Apply()
	{
	}

	public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
	{
		if (dataGridView_0.Rows.Count >= 2)
		{
			if ((parShape.selectedPlane == planeBoxNames.Top) | (parShape.selectedPlane == planeBoxNames.Bottom))
			{
				selectedShape.BasePoint.X = Convert.ToDouble(dataGridView_0.Rows[0].Cells[1].Value);
				selectedShape.BasePoint.Y = Convert.ToDouble(dataGridView_0.Rows[1].Cells[1].Value);
			}
			if ((parShape.selectedPlane == planeBoxNames.Front) | (parShape.selectedPlane == planeBoxNames.Back))
			{
				selectedShape.BasePoint.X = Convert.ToDouble(dataGridView_0.Rows[0].Cells[1].Value);
				selectedShape.BasePoint.Z = Convert.ToDouble(dataGridView_0.Rows[1].Cells[1].Value);
			}
			if ((parShape.selectedPlane == planeBoxNames.Left) | (parShape.selectedPlane == planeBoxNames.Right))
			{
				selectedShape.BasePoint.Y = Convert.ToDouble(dataGridView_0.Rows[0].Cells[1].Value);
				selectedShape.BasePoint.Z = Convert.ToDouble(dataGridView_0.Rows[1].Cells[1].Value);
			}
			((buShapeEngrave)selectedShape).Width = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value);
			((buShapeEngrave)selectedShape).Height = Convert.ToDouble(dataGridView_0.Rows[3].Cells[1].Value);
			((buShapeEngrave)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[4].Cells[1].Value);
			((buShapeEngrave)selectedShape).Offset.Z = Convert.ToDouble(dataGridView_0.Rows[5].Cells[1].Value);
			((buShapeEngrave)selectedShape).isPocket = checkBox_0.Checked;
			parShape.EngravingWidth = ((buShapeEngrave)selectedShape).Width;
			parShape.EngravingHeight = ((buShapeEngrave)selectedShape).Height;
			parShape.EngravingDepth = ((buShapeEngrave)selectedShape).Depth;
			parShape.EngravingOffsetZ = ((buShapeEngrave)selectedShape).Offset.Z;
			parShape.isEngravePocket = ((buShapeEngrave)selectedShape).isPocket;
			parShape.pntBase.X = selectedShape.BasePoint.X;
			parShape.pntBase.Y = selectedShape.BasePoint.Y;
			parShape.pntBase.Z = selectedShape.BasePoint.Z;
		}
	}

	public void ShapeToDataGrid(int Index)
	{
		dataGridView_0.Rows.Clear();
		if ((parShape.selectedPlane == planeBoxNames.Top) | (parShape.selectedPlane == planeBoxNames.Bottom))
		{
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			string string_ = "X";
			double double_ = parShape.pntBase.X;
			rows.Add(Class186.smethod_472(string_, double_, this));
			DataGridViewRowCollection rows2 = dataGridView_0.Rows;
			string_ = "Y";
			double_ = parShape.pntBase.Y;
			rows2.Add(Class186.smethod_472(string_, double_, this));
		}
		if ((parShape.selectedPlane == planeBoxNames.Left) | (parShape.selectedPlane == planeBoxNames.Right))
		{
			DataGridViewRowCollection rows3 = dataGridView_0.Rows;
			string string_ = "Y";
			double double_ = parShape.pntBase.Y;
			rows3.Add(Class186.smethod_472(string_, double_, this));
			DataGridViewRowCollection rows4 = dataGridView_0.Rows;
			string_ = "Z";
			double_ = parShape.pntBase.Z;
			rows4.Add(Class186.smethod_472(string_, double_, this));
		}
		if ((parShape.selectedPlane == planeBoxNames.Front) | (parShape.selectedPlane == planeBoxNames.Back))
		{
			DataGridViewRowCollection rows5 = dataGridView_0.Rows;
			string string_ = "X";
			double double_ = parShape.pntBase.X;
			rows5.Add(Class186.smethod_472(string_, double_, this));
			DataGridViewRowCollection rows6 = dataGridView_0.Rows;
			string_ = "Z";
			double_ = parShape.pntBase.Z;
			rows6.Add(Class186.smethod_472(string_, double_, this));
		}
		if (Index == 0)
		{
			selectedShape = new buShapeEngrave(parShape.EngravingDepth, parShape.EngravingWidth, parShape.EngravingHeight, entMesh);
			((buShapeEngrave)selectedShape).isPocket = parShape.isEngravePocket;
			((buShapeEngrave)selectedShape).Offset.Z = parShape.EngravingOffsetZ;
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows7 = dataGridView_0.Rows;
			string string_ = buLangTranslate.preDef.Width;
			double double_ = ((buShapeEngrave)selectedShape).Width;
			rows7.Add(Class186.smethod_472(string_, double_, this));
			DataGridViewRowCollection rows8 = dataGridView_0.Rows;
			string_ = buLangTranslate.preDef.Height;
			double_ = ((buShapeEngrave)selectedShape).Height;
			rows8.Add(Class186.smethod_472(string_, double_, this));
			DataGridViewRowCollection rows9 = dataGridView_0.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = ((buShapeEngrave)selectedShape).Depth;
			rows9.Add(Class186.smethod_472(string_, double_, this));
			DataGridViewRowCollection rows10 = dataGridView_0.Rows;
			string_ = "Z " + buLangTranslate.preDef.Offset;
			double_ = ((buShapeEngrave)selectedShape).Offset.Z;
			rows10.Add(Class186.smethod_472(string_, double_, this));
		}
		checkBox_0.Checked = parShape.isEngravePocket;
		selectedShape.CamPar = new camParameters5(CamPar);
		label_0.Text = buCall.buDrillCalc_0.JobItemCommandToString(selectedShape);
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0)))
		{
			ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
			DataGridValuesToShape(e.ColumnIndex, e.RowIndex);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg);
			}
		}
	}

	private void dataGridView_0_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0)))
		{
			ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
			DataGridValuesToShape(e.ColumnIndex, e.RowIndex);
			clsVar5.ShapeTempPar.ValueGridIndex = e.RowIndex;
			buCall.buVector5_0.FindShapeDataValueType(selectedShape, e.RowIndex, ref clsVar5.ShapeTempPar.ValueType);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg);
			}
		}
	}

	private void dataGridView_0_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0)))
		{
			ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
			DataGridValuesToShape(e.ColumnIndex, e.RowIndex);
			clsVar5.ShapeTempPar.ValueGridIndex = e.RowIndex;
			buCall.buVector5_0.FindShapeDataValueType(selectedShape, e.RowIndex, ref clsVar5.ShapeTempPar.ValueType);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg);
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
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
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				DataGridValuesToShape(-1, -1);
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(parShape);
				shapeUpdateArg.Finished = true;
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg);
			}
			if (base.Owner != null)
			{
				base.Owner.Focus();
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
			}
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
		}
		if (control.Name == button_0.Name)
		{
			F_CornerLocation f_CornerLocation = new F_CornerLocation();
			f_CornerLocation.Corner = parShape.selectedCorner;
			f_CornerLocation.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CornerLocation.Init();
			f_CornerLocation.ShowDialog(this);
			if (f_CornerLocation.Properties.Result == DialogResult.OK)
			{
				selectedShape.Corner = f_CornerLocation.Corner;
				parShape.selectedCorner = f_CornerLocation.Corner;
				button_0.ImageIndex = Convert.ToInt32(parShape.selectedCorner);
				if (okCommandWithTwoDataEventHandler_0 != null)
				{
					DataGridValuesToShape(-1, -1);
					ShapeUpdateArg shapeUpdateArg2 = new ShapeUpdateArg(parShape);
					shapeUpdateArg2.Finished = false;
					okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg2);
				}
			}
			Focus();
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
		}
		if (control.Name == button_1.Name)
		{
			F_ObjectLocation f_ObjectLocation = new F_ObjectLocation();
			f_ObjectLocation.Alingnment = parShape.objectAlignment;
			f_ObjectLocation.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_ObjectLocation.Init();
			f_ObjectLocation.ShowDialog(this);
			if (f_ObjectLocation.Properties.Result == DialogResult.OK)
			{
				selectedShape.Alignment = f_ObjectLocation.Alingnment;
				parShape.objectAlignment = f_ObjectLocation.Alingnment;
				button_1.ImageIndex = Convert.ToInt32(parShape.objectAlignment);
				if (okCommandWithTwoDataEventHandler_0 != null)
				{
					DataGridValuesToShape(-1, -1);
					ShapeUpdateArg shapeUpdateArg3 = new ShapeUpdateArg(parShape);
					shapeUpdateArg3.Finished = false;
					okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg3);
				}
			}
			Focus();
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
		}
		if (control.Name == button_2.Name && selectedShape is buShapeEngrave)
		{
			buShapeEngrave buShapeEngrave2 = selectedShape as buShapeEngrave;
			if (buShapeEngrave2.isPocket)
			{
				buShapeEngrave2.isPocket = false;
			}
			else
			{
				buShapeEngrave2.isPocket = true;
			}
			checkBox_0.Checked = buShapeEngrave2.isPocket;
			parShape.isEngravePocket = buShapeEngrave2.isPocket;
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg4 = new ShapeUpdateArg();
				shapeUpdateArg4.Parameters = new ShapeRuntimeData(parShape);
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg4);
			}
		}
		if (control.Name == btn_camsettings.Name)
		{
			F_CamSettings1 f_CamSettings = new F_CamSettings1();
			f_CamSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CamSettings.CamPar = new camParameters5(CamPar);
			f_CamSettings.Init();
			f_CamSettings.ShowDialog(this);
			if (f_CamSettings.Properties.Result == DialogResult.OK)
			{
				selectedShape.CamPar = new camParameters5(f_CamSettings.CamPar);
				CamPar = new camParameters5(f_CamSettings.CamPar);
			}
			Focus();
		}
		if (!((control.Name == btn_top.Name) | (control.Name == btn_bottom.Name) | (control.Name == btn_left.Name) | (control.Name == btn_right.Name) | (control.Name == btn_front.Name) | (control.Name == btn_back.Name)))
		{
			return;
		}
		if (control.Name == btn_top.Name)
		{
			parShape.selectedPlane = planeBoxNames.Top;
		}
		if (control.Name == btn_bottom.Name)
		{
			parShape.selectedPlane = planeBoxNames.Bottom;
		}
		if (control.Name == btn_left.Name)
		{
			parShape.selectedPlane = planeBoxNames.Left;
		}
		if (control.Name == btn_right.Name)
		{
			parShape.selectedPlane = planeBoxNames.Right;
		}
		if (control.Name == btn_front.Name)
		{
			parShape.selectedPlane = planeBoxNames.Front;
		}
		if (control.Name == btn_back.Name)
		{
			parShape.selectedPlane = planeBoxNames.Back;
		}
		PlaneColorUpdate();
		int valueGridIndex = clsVar5.ShapeTempPar.ValueGridIndex;
		if ((valueGridIndex >= 0) & (valueGridIndex <= dataGridView_0.Rows.Count - 1))
		{
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			ShapeToDataGrid(int_0);
			clsVar5.ShapeTempPar.ValueGridIndex = valueGridIndex;
			for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
			{
				dataGridView_0.Rows[i].Cells[0].Selected = false;
				dataGridView_0.Rows[i].Cells[1].Selected = false;
			}
			dataGridView_0.Rows[valueGridIndex].Cells[0].Selected = true;
		}
		if (okCommandWithTwoDataEventHandler_0 != null)
		{
			ShapeUpdateArg data = new ShapeUpdateArg(parShape);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(parShape.selectedPlane);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			okCommandWithTwoDataEventHandler_0(selectedShape, data);
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
