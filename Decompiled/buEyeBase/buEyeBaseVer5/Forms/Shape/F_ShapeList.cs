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
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Shape;

public class F_ShapeList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public Design viewportLayout;

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

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

	public bool ClosePageAfterOk = false;

	public List<ToolBase5> Tools = new List<ToolBase5>();

	public ToolBase5 activeTool = null;

	public buShape selectedShape = null;

	public ShapeRuntimeData parShape = new ShapeRuntimeData();

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private int int_0 = -1;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	public Panel pnl_model;

	internal ImageList imageList_0;

	internal ListView listView_0;

	internal ImageList imageList_1;

	internal DataGridView dataGridView_0;

	internal Panel panel_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	public Button btn_front;

	internal Label label_3;

	public Button btn_back;

	internal Label label_4;

	public Button btn_right;

	internal Label label_5;

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

	internal Button button_2;

	internal ImageList imageList_4;

	internal ImageList imageList_5;

	internal Button button_3;

	internal CheckBox checkBox_0;

	public ListBox lst_info;

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

	public F_ShapeList()
	{
		Class186.smethod_688(this);
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
		listView_0.Items.Add(buLangTranslate.preDef.Rect, 0);
		listView_0.Items.Add(buLangTranslate.preDef.Cirlce, 1);
		listView_0.Items.Add(buLangTranslate.preDef.Ellipse, 2);
		listView_0.Items.Add(buLangTranslate.preDef.KeyHole, 3);
		listView_0.Items.Add(buLangTranslate.preDef.Polygon, 4);
		listView_0.Items.Add(buLangTranslate.preDef.Slot, 5);
		listView_0.Items.Add(buLangTranslate.preDef.FreeDraw, 6);
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
		dataGridView_0.Columns.Clear();
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
		listView_0.ForeColor = Color.Red;
		if (!(selectedShape.GetType() == typeof(buShapeRectangle)))
		{
			if (!(selectedShape.GetType() == typeof(buShapeCircle)))
			{
				if (!(selectedShape.GetType() == typeof(buShapeEllipse)))
				{
					if (!(selectedShape.GetType() == typeof(buShapeKeyHole)))
					{
						if (!(selectedShape.GetType() == typeof(buShapePolygon)))
						{
							if (!(selectedShape.GetType() == typeof(buShapeSlot)))
							{
								if (selectedShape.GetType() == typeof(buShapeFreeDraw))
								{
									listView_0.Items[6].Focused = true;
									listView_0.Items[6].Selected = true;
									listView_0.FocusedItem = listView_0.Items[6];
									int_0 = 6;
								}
							}
							else
							{
								listView_0.Items[5].Focused = true;
								listView_0.Items[5].Selected = true;
								listView_0.FocusedItem = listView_0.Items[5];
								int_0 = 5;
							}
						}
						else
						{
							listView_0.Items[4].Focused = true;
							listView_0.Items[4].Selected = true;
							listView_0.FocusedItem = listView_0.Items[4];
							int_0 = 4;
						}
					}
					else
					{
						listView_0.Items[3].Focused = true;
						listView_0.Items[3].Selected = true;
						listView_0.FocusedItem = listView_0.Items[3];
						int_0 = 3;
					}
				}
				else
				{
					listView_0.Items[2].Focused = true;
					listView_0.Items[2].Selected = true;
					listView_0.FocusedItem = listView_0.Items[2];
					int_0 = 2;
				}
			}
			else
			{
				listView_0.Items[1].Focused = true;
				listView_0.Items[1].Selected = true;
				listView_0.FocusedItem = listView_0.Items[1];
				int_0 = 1;
			}
		}
		else
		{
			listView_0.Items[0].Focused = true;
			listView_0.Items[0].Selected = true;
			listView_0.FocusedItem = listView_0.Items[0];
			int_0 = 0;
		}
		ShapeToDataGrid(int_0);
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
			label_3.Width = num - 10;
			btn_bottom.Width = num - 10;
			label_5.Width = num - 10;
			btn_front.Width = num - 10;
			label_4.Width = num - 10;
			btn_left.Width = num - 10;
			label_2.Width = num - 10;
			btn_right.Width = num - 10;
			label_0.Width = num - 10;
			btn_top.Width = num - 10;
			label_1.Width = num - 10;
			label_1.Left = btn_top.Left;
			btn_bottom.Left = btn_top.Left + btn_top.Width + 5;
			label_5.Left = btn_bottom.Left;
			btn_front.Left = btn_bottom.Left + btn_bottom.Width + 5;
			label_4.Left = btn_front.Left;
			btn_back.Left = btn_front.Left + btn_front.Width + 5;
			label_3.Left = btn_back.Left;
			btn_left.Left = btn_back.Left + btn_back.Width + 5;
			label_2.Left = btn_left.Left;
			btn_right.Left = btn_left.Left + btn_left.Width + 5;
			label_0.Left = btn_right.Left;
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

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Class186.smethod_331(this);
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

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			Text = buLangTranslate.preDef.Shape;
			label_1.Text = buLangTranslate.preDef.Top;
			label_3.Text = buLangTranslate.preDef.Back;
			label_5.Text = buLangTranslate.preDef.Bottom;
			label_4.Text = buLangTranslate.preDef.Front;
			label_2.Text = buLangTranslate.preDef.Left;
			label_0.Text = buLangTranslate.preDef.Right;
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
		if (dataGridView_0.Rows.Count < 2 || (ColumnIndex >= 0 && RowIndex >= 0 && !buNumeric5.IsNumeric(dataGridView_0.Rows[RowIndex].Cells[ColumnIndex].Value.ToString())))
		{
			return;
		}
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
		if (selectedShape.GetType() == typeof(buShapeRectangle))
		{
			((buShapeRectangle)selectedShape).Width = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value);
			((buShapeRectangle)selectedShape).Height = Convert.ToDouble(dataGridView_0.Rows[3].Cells[1].Value);
			((buShapeRectangle)selectedShape).Radius = Convert.ToDouble(dataGridView_0.Rows[4].Cells[1].Value);
			((buShapeRectangle)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[5].Cells[1].Value);
			parShape.RectangleWidth = ((buShapeRectangle)selectedShape).Width;
			parShape.RectangleHeight = ((buShapeRectangle)selectedShape).Height;
			parShape.RectangleDepth = ((buShapeRectangle)selectedShape).Depth;
			parShape.RectangleAngle = ((buShapeRectangle)selectedShape).Angle;
			parShape.RectangleRadius = ((buShapeRectangle)selectedShape).Radius;
			parShape.ShapeType = ShapeTypes.Rectangle;
		}
		if (selectedShape.GetType() == typeof(buShapeCircle))
		{
			((buShapeCircle)selectedShape).Radius = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value) / 2.0;
			((buShapeCircle)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[3].Cells[1].Value);
			((buShapeCircle)selectedShape).ShapeType = ShapeTypes.Circle;
			parShape.CircleRadius = ((buShapeCircle)selectedShape).Radius;
			parShape.CircleDepth = ((buShapeCircle)selectedShape).Depth;
			parShape.ShapeType = ShapeTypes.Circle;
		}
		if (selectedShape.GetType() == typeof(buShapeEllipse))
		{
			((buShapeEllipse)selectedShape).RadiusX = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value) / 2.0;
			((buShapeEllipse)selectedShape).RadiusY = Convert.ToDouble(dataGridView_0.Rows[3].Cells[1].Value) / 2.0;
			((buShapeEllipse)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[4].Cells[1].Value);
			parShape.EllipseRadiusX = ((buShapeEllipse)selectedShape).RadiusX;
			parShape.EllipseRadiusY = ((buShapeEllipse)selectedShape).RadiusY;
			parShape.EllipseDepth = ((buShapeEllipse)selectedShape).Depth;
			parShape.EllipseAngle = ((buShapeEllipse)selectedShape).Angle;
			parShape.ShapeType = ShapeTypes.Ellipse;
		}
		if (selectedShape.GetType() == typeof(buShapeKeyHole))
		{
			((buShapeKeyHole)selectedShape).HeadDiameter = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value);
			((buShapeKeyHole)selectedShape).Diameter = Convert.ToDouble(dataGridView_0.Rows[3].Cells[1].Value);
			((buShapeKeyHole)selectedShape).Length = Convert.ToDouble(dataGridView_0.Rows[4].Cells[1].Value);
			((buShapeKeyHole)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[5].Cells[1].Value);
			parShape.KeyHoleHeadDiameter = ((buShapeKeyHole)selectedShape).HeadDiameter;
			parShape.KeyHoleDiameter = ((buShapeKeyHole)selectedShape).Diameter;
			parShape.KeyHoleLength = ((buShapeKeyHole)selectedShape).Length;
			parShape.KeyHoleDepth = ((buShapeKeyHole)selectedShape).Depth;
			parShape.KeyHoleAngle = ((buShapeKeyHole)selectedShape).Angle;
			parShape.ShapeType = ShapeTypes.KeyHole;
		}
		if (selectedShape.GetType() == typeof(buShapePolygon))
		{
			((buShapePolygon)selectedShape).Radius = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value) / 2.0;
			((buShapePolygon)selectedShape).Side = Convert.ToInt32(dataGridView_0.Rows[3].Cells[1].Value);
			((buShapePolygon)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[4].Cells[1].Value);
			parShape.PolygonRadius = ((buShapePolygon)selectedShape).Radius;
			parShape.PolygonSide = ((buShapePolygon)selectedShape).Side;
			parShape.PolygonDepth = ((buShapePolygon)selectedShape).Depth;
			parShape.PolygonAngle = ((buShapePolygon)selectedShape).Angle;
			parShape.ShapeType = ShapeTypes.Polygon;
		}
		if (selectedShape.GetType() == typeof(buShapeSlot))
		{
			((buShapeSlot)selectedShape).Diameter = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value);
			((buShapeSlot)selectedShape).Length = Convert.ToInt32(dataGridView_0.Rows[3].Cells[1].Value);
			((buShapeSlot)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[4].Cells[1].Value);
			parShape.SlotDiameter = ((buShapeSlot)selectedShape).Diameter;
			parShape.SlotLength = ((buShapeSlot)selectedShape).Length;
			parShape.SlotDepth = ((buShapeSlot)selectedShape).Depth;
			parShape.SlotAngle = ((buShapeSlot)selectedShape).Angle;
			parShape.ShapeType = ShapeTypes.Slot;
		}
		if (selectedShape.GetType() == typeof(buShapeFreeDraw))
		{
			((buShapeFreeDraw)selectedShape).Width = Convert.ToDouble(dataGridView_0.Rows[2].Cells[1].Value);
			((buShapeFreeDraw)selectedShape).Height = Convert.ToDouble(dataGridView_0.Rows[3].Cells[1].Value);
			((buShapeFreeDraw)selectedShape).Depth = Convert.ToDouble(dataGridView_0.Rows[4].Cells[1].Value);
			if ((dataGridView_0.Rows.Count >= 6) & (selectedShape.DepthLevel.Count >= 2))
			{
				selectedShape.DepthLevel[1] = Convert.ToDouble(dataGridView_0.Rows[5].Cells[1].Value);
			}
			if ((dataGridView_0.Rows.Count >= 6) & (parShape.DepthLevels.Count >= 2))
			{
				parShape.DepthLevels[1] = Convert.ToDouble(dataGridView_0.Rows[5].Cells[1].Value);
			}
			if ((dataGridView_0.Rows.Count >= 7) & (selectedShape.DepthLevel.Count >= 3))
			{
				selectedShape.DepthLevel[2] = Convert.ToDouble(dataGridView_0.Rows[6].Cells[1].Value);
			}
			if ((dataGridView_0.Rows.Count >= 7) & (parShape.DepthLevels.Count >= 3))
			{
				parShape.DepthLevels[2] = Convert.ToDouble(dataGridView_0.Rows[6].Cells[1].Value);
			}
			parShape.FreeDrawWidth = ((buShapeFreeDraw)selectedShape).Width;
			parShape.FreeDrawHeight = ((buShapeFreeDraw)selectedShape).Height;
			parShape.FreeDrawDepth = ((buShapeFreeDraw)selectedShape).Depth;
			parShape.FreeDrawAngle = ((buShapeFreeDraw)selectedShape).Angle;
			parShape.ShapeType = ShapeTypes.FreeDraw;
		}
		parShape.isShapePocket = checkBox_0.Checked;
		selectedShape.isPocket = parShape.isShapePocket;
		parShape.pntBase.X = selectedShape.BasePoint.X;
		parShape.pntBase.Y = selectedShape.BasePoint.Y;
		parShape.pntBase.Z = selectedShape.BasePoint.Z;
	}

	public void ShapeToDataGrid(int Index)
	{
		dataGridView_0.Rows.Clear();
		if ((parShape.selectedPlane == planeBoxNames.Top) | (parShape.selectedPlane == planeBoxNames.Bottom))
		{
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			string string_ = "X";
			double double_ = parShape.pntBase.X;
			rows.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows2 = dataGridView_0.Rows;
			string_ = "Y";
			double_ = parShape.pntBase.Y;
			rows2.Add(Class186.smethod_797(double_, this, string_));
		}
		if ((parShape.selectedPlane == planeBoxNames.Left) | (parShape.selectedPlane == planeBoxNames.Right))
		{
			DataGridViewRowCollection rows3 = dataGridView_0.Rows;
			string string_ = "Y";
			double double_ = parShape.pntBase.Y;
			rows3.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows4 = dataGridView_0.Rows;
			string_ = "Z";
			double_ = parShape.pntBase.Z;
			rows4.Add(Class186.smethod_797(double_, this, string_));
		}
		if ((parShape.selectedPlane == planeBoxNames.Front) | (parShape.selectedPlane == planeBoxNames.Back))
		{
			DataGridViewRowCollection rows5 = dataGridView_0.Rows;
			string string_ = "X";
			double double_ = parShape.pntBase.X;
			rows5.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows6 = dataGridView_0.Rows;
			string_ = "Z";
			double_ = parShape.pntBase.Z;
			rows6.Add(Class186.smethod_797(double_, this, string_));
		}
		if (Index == 0)
		{
			if (parShape.RectangleDepth <= 0.0)
			{
				parShape.RectangleDepth = 5.0;
			}
			selectedShape = new buShapeRectangle(parShape.RectangleWidth, parShape.RectangleHeight, parShape.RectangleRadius, 0.0, parShape.RectangleDepth, parShape.RectangleAngle);
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows7 = dataGridView_0.Rows;
			string string_ = AppLanguage.CadCamDynamic[15];
			double double_ = ((buShapeRectangle)selectedShape).Width;
			rows7.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows8 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[16];
			double_ = ((buShapeRectangle)selectedShape).Height;
			rows8.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows9 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[19];
			double_ = ((buShapeRectangle)selectedShape).Radius;
			rows9.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows10 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[113];
			double_ = ((buShapeRectangle)selectedShape).Depth;
			rows10.Add(Class186.smethod_797(double_, this, string_));
		}
		if (Index == 1)
		{
			if (parShape.CircleDepth <= 0.0)
			{
				parShape.CircleDepth = 5.0;
			}
			selectedShape = new buShapeCircle(parShape.CircleRadius, parShape.CircleDepth);
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows11 = dataGridView_0.Rows;
			string string_ = AppLanguage.CadCamDynamic[57];
			double double_ = ((buShapeCircle)selectedShape).Radius * 2.0;
			rows11.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows12 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[113];
			double_ = ((buShapeCircle)selectedShape).Depth;
			rows12.Add(Class186.smethod_797(double_, this, string_));
		}
		if (Index == 2)
		{
			if (parShape.EllipseDepth <= 0.0)
			{
				parShape.EllipseDepth = 5.0;
			}
			selectedShape = new buShapeEllipse(parShape.EllipseRadiusX, parShape.EllipseRadiusY, parShape.EllipseDepth, parShape.EllipseAngle);
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows13 = dataGridView_0.Rows;
			string string_ = AppLanguage.CadCamDynamic[20];
			double double_ = ((buShapeEllipse)selectedShape).RadiusX * 2.0;
			rows13.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows14 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[21];
			double_ = ((buShapeEllipse)selectedShape).RadiusY * 2.0;
			rows14.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows15 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[113];
			double_ = ((buShapeEllipse)selectedShape).Depth;
			rows15.Add(Class186.smethod_797(double_, this, string_));
		}
		if (Index == 3)
		{
			if (parShape.KeyHoleDepth <= 0.0)
			{
				parShape.KeyHoleDepth = 5.0;
			}
			selectedShape = new buShapeKeyHole(parShape.KeyHoleHeadDiameter, parShape.KeyHoleDiameter, parShape.KeyHoleLength, parShape.KeyHoleDepth, parShape.KeyHoleAngle);
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows16 = dataGridView_0.Rows;
			string string_ = AppLanguage.CadCamDynamic[128];
			double double_ = ((buShapeKeyHole)selectedShape).HeadDiameter;
			rows16.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows17 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[57];
			double_ = ((buShapeKeyHole)selectedShape).Diameter;
			rows17.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows18 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[0];
			double_ = ((buShapeKeyHole)selectedShape).Length;
			rows18.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows19 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[113];
			double_ = ((buShapeKeyHole)selectedShape).Depth;
			rows19.Add(Class186.smethod_797(double_, this, string_));
		}
		if (Index == 4)
		{
			if (parShape.PolygonDepth <= 0.0)
			{
				parShape.PolygonDepth = 5.0;
			}
			selectedShape = new buShapePolygon(parShape.PolygonRadius, parShape.PolygonSide, parShape.PolygonDepth, parShape.PolygonAngle);
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows20 = dataGridView_0.Rows;
			string string_ = AppLanguage.CadCamDynamic[57];
			double double_ = ((buShapePolygon)selectedShape).Radius * 2.0;
			rows20.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows21 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[71];
			double_ = ((buShapePolygon)selectedShape).Side;
			rows21.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows22 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[113];
			double_ = ((buShapePolygon)selectedShape).Depth;
			rows22.Add(Class186.smethod_797(double_, this, string_));
		}
		if (Index == 5)
		{
			if (parShape.SlotDepth <= 0.0)
			{
				parShape.SlotDepth = 5.0;
			}
			selectedShape = new buShapeSlot(parShape.SlotDiameter, parShape.SlotLength, parShape.SlotDepth, parShape.SlotAngle);
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows23 = dataGridView_0.Rows;
			string string_ = AppLanguage.CadCamDynamic[57];
			double double_ = ((buShapeSlot)selectedShape).Diameter;
			rows23.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows24 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[0];
			double_ = ((buShapeSlot)selectedShape).Length;
			rows24.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows25 = dataGridView_0.Rows;
			string_ = AppLanguage.CadCamDynamic[113];
			double_ = ((buShapeSlot)selectedShape).Depth;
			rows25.Add(Class186.smethod_797(double_, this, string_));
		}
		if (Index == 6)
		{
			if (parShape.FreeDrawDepth <= 0.0)
			{
				parShape.FreeDrawDepth = 5.0;
			}
			selectedShape = new buShapeFreeDraw(parShape.FreeDrawWidth, parShape.FreeDrawHeight, parShape.FreeDrawDepth, parShape.FreeDrawAngle);
			selectedShape.DepthLevel = new List<double>();
			selectedShape.DepthLevel.AddRange(parShape.DepthLevels);
			selectedShape.BasePoint = new Point3D(parShape.pntBase.X, parShape.pntBase.Y, parShape.pntBase.Z);
			selectedShape.planeName = parShape.selectedPlane;
			selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(selectedShape.planeName);
			selectedShape.Corner = parShape.selectedCorner;
			selectedShape.Alignment = parShape.objectAlignment;
			DataGridViewRowCollection rows26 = dataGridView_0.Rows;
			string string_ = buLangTranslate.preDef.Width;
			double double_ = ((buShapeFreeDraw)selectedShape).Width;
			rows26.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows27 = dataGridView_0.Rows;
			string_ = buLangTranslate.preDef.Height;
			double_ = ((buShapeFreeDraw)selectedShape).Height;
			rows27.Add(Class186.smethod_797(double_, this, string_));
			DataGridViewRowCollection rows28 = dataGridView_0.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = ((buShapeFreeDraw)selectedShape).Depth;
			rows28.Add(Class186.smethod_797(double_, this, string_));
			if (selectedShape.DepthLevel.Count >= 2)
			{
				DataGridViewRowCollection rows29 = dataGridView_0.Rows;
				string_ = buLangTranslate.preDef.DepthSecond;
				double_ = ((buShapeFreeDraw)selectedShape).DepthLevel[1];
				rows29.Add(Class186.smethod_797(double_, this, string_));
			}
			if (selectedShape.DepthLevel.Count >= 3)
			{
				DataGridViewRowCollection rows30 = dataGridView_0.Rows;
				string_ = buLangTranslate.preDef.DepthThird;
				double_ = ((buShapeFreeDraw)selectedShape).DepthLevel[2];
				rows30.Add(Class186.smethod_797(double_, this, string_));
			}
		}
		selectedShape.isPocket = parShape.isShapePocket;
		selectedShape.CamPar = new camParameters5(parShape.CamPars);
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
		}
	}

	private void dataGridView_0_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0)))
		{
		}
	}

	internal void method_1(object sender, EventArgs e)
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
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				DataGridValuesToShape(-1, -1);
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(parShape);
				shapeUpdateArg.Finished = true;
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg);
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
		if (control.Name == button_3.Name && selectedShape != null)
		{
			buShape buShape2 = selectedShape;
			if (buShape2.isPocket)
			{
				buShape2.isPocket = false;
			}
			else
			{
				buShape2.isPocket = true;
			}
			checkBox_0.Checked = buShape2.isPocket;
			parShape.isShapePocket = buShape2.isPocket;
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg2 = new ShapeUpdateArg();
				shapeUpdateArg2.Parameters = new ShapeRuntimeData(parShape);
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg2);
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
					ShapeUpdateArg shapeUpdateArg4 = new ShapeUpdateArg(parShape);
					shapeUpdateArg4.Finished = false;
					okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg4);
				}
			}
			Focus();
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
		}
		if (control.Name == button_2.Name)
		{
			F_ShapeEdit f_ShapeEdit = new F_ShapeEdit();
			f_ShapeEdit.Edit = new ShapeEdit(selectedShape.Edit);
			f_ShapeEdit.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_ShapeEdit.refPlane = selectedShape.planeName;
			f_ShapeEdit.Init();
			f_ShapeEdit.ShowDialog(this);
			if (f_ShapeEdit.Properties.Result == DialogResult.OK)
			{
				selectedShape.Edit = new ShapeEdit(f_ShapeEdit.Edit);
				if (okCommandWithTwoDataEventHandler_0 != null)
				{
					DataGridValuesToShape(-1, -1);
					ShapeUpdateArg shapeUpdateArg5 = new ShapeUpdateArg(parShape);
					shapeUpdateArg5.Finished = false;
					okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg5);
				}
			}
			Focus();
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
		}
		if (control.Name == btn_camsettings.Name)
		{
			F_CamSettings1 f_CamSettings = new F_CamSettings1();
			f_CamSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CamSettings.CamPar = new camParameters5(parShape.CamPars);
			f_CamSettings.Init();
			f_CamSettings.ShowDialog(this);
			if (f_CamSettings.Properties.Result == DialogResult.OK)
			{
				selectedShape.CamPar = new camParameters5(f_CamSettings.CamPar);
				parShape.CamPars = new camParameters5(f_CamSettings.CamPar);
			}
			Focus();
		}
		if (control.Name == btn_top.Name)
		{
			parShape.selectedPlane = planeBoxNames.Top;
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
		if (control.Name == btn_bottom.Name)
		{
			parShape.selectedPlane = planeBoxNames.Bottom;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg data2 = new ShapeUpdateArg(parShape);
				selectedShape.planeName = parShape.selectedPlane;
				selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(parShape.selectedPlane);
				selectedShape.Corner = parShape.selectedCorner;
				selectedShape.Alignment = parShape.objectAlignment;
				okCommandWithTwoDataEventHandler_0(selectedShape, data2);
			}
		}
		if (control.Name == btn_left.Name)
		{
			parShape.selectedPlane = planeBoxNames.Left;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg data3 = new ShapeUpdateArg(parShape);
				selectedShape.planeName = parShape.selectedPlane;
				selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(parShape.selectedPlane);
				selectedShape.Corner = parShape.selectedCorner;
				selectedShape.Alignment = parShape.objectAlignment;
				okCommandWithTwoDataEventHandler_0(selectedShape, data3);
			}
		}
		if (control.Name == btn_right.Name)
		{
			parShape.selectedPlane = planeBoxNames.Right;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg data4 = new ShapeUpdateArg(parShape);
				selectedShape.planeName = parShape.selectedPlane;
				selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(parShape.selectedPlane);
				selectedShape.Corner = parShape.selectedCorner;
				selectedShape.Alignment = parShape.objectAlignment;
				okCommandWithTwoDataEventHandler_0(selectedShape, data4);
			}
		}
		if (control.Name == btn_front.Name)
		{
			parShape.selectedPlane = planeBoxNames.Front;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg data5 = new ShapeUpdateArg(parShape);
				selectedShape.planeName = parShape.selectedPlane;
				selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(parShape.selectedPlane);
				selectedShape.Corner = parShape.selectedCorner;
				selectedShape.Alignment = parShape.objectAlignment;
				okCommandWithTwoDataEventHandler_0(selectedShape, data5);
			}
		}
		if (control.Name == btn_back.Name)
		{
			parShape.selectedPlane = planeBoxNames.Back;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg data6 = new ShapeUpdateArg(parShape);
				selectedShape.planeName = parShape.selectedPlane;
				selectedShape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(parShape.selectedPlane);
				selectedShape.Corner = parShape.selectedCorner;
				selectedShape.Alignment = parShape.objectAlignment;
				okCommandWithTwoDataEventHandler_0(selectedShape, data6);
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (!PropertiesForm.Inited)
		{
			return;
		}
		PropertiesForm.Inited = false;
		if (control.Name == checkBox_0.Name && selectedShape != null)
		{
			buShape buShape2 = selectedShape;
			buShape2.isPocket = checkBox_0.Checked;
			parShape.isShapePocket = buShape2.isPocket;
			buShape2.CamPar.Pockets.Enable = buShape2.isPocket;
			parShape.CamPars.Pockets.Enable = buShape2.isPocket;
			ShapeToDataGrid(int_0);
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg);
			}
		}
		Apply();
		PropertiesForm.Inited = true;
		Class186.smethod_662(sender, this, (EventArgs)null);
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && ShowTool && ((cmb_tools.SelectedIndex >= 0) & (cmb_tools.SelectedIndex <= Tools.Count - 1)))
		{
			activeTool = new ToolBase5(Tools[cmb_tools.SelectedIndex]);
		}
	}

	internal void method_4(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ItemIndex >= 0) & e.IsSelected))
		{
			ShapeToDataGrid(e.ItemIndex);
			int_0 = e.ItemIndex;
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				shapeUpdateArg.Parameters = new ShapeRuntimeData(parShape);
				okCommandWithTwoDataEventHandler_0(selectedShape, shapeUpdateArg);
			}
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
