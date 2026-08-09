using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Shape;
using buEyeBaseVer5.Variables;
using devDept.Eyeshot.Control;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_OperationList : Form
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

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_1;

	public bool ShowViewport = true;

	public bool ShowCamSettings = true;

	public bool ShowTool = false;

	public bool ShowObjectPosition = true;

	public bool ShowCornerLocation = true;

	public bool EnableTopPlane = true;

	public bool EnableBottomPlane = true;

	public bool EnableFrontPlane = true;

	public bool EnableBackPlane = true;

	public bool EnableFreePlane = true;

	public bool ClosePageAfterOk = false;

	public bool CellFirstSelected = false;

	public List<ToolBase5> Tools = new List<ToolBase5>();

	public ToolBase5 activeTool = null;

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

	internal Button button_0;

	internal Button button_1;

	public ComboBox cmb_tools;

	internal Label label_0;

	internal Button button_2;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal Button button_3;

	internal Button button_4;

	internal CheckBox checkBox_2;

	public Panel pnl_model;

	internal ListView listView_0;

	internal PictureBox pictureBox_0;

	public Button btn_camsettings;

	internal Panel panel_1;

	internal Label label_1;

	public Button btn_free;

	internal Label label_2;

	public Button btn_front;

	internal Label label_3;

	public Button btn_back;

	internal Label label_4;

	internal Label label_5;

	public Button btn_top;

	public Button btn_bottom;

	public Button btn_ok;

	public Button btn_cancel;

	public DataGridView dgv_data;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	public Label lbl_palnedegree;

	internal Label label_9;

	public Label lbl_camcenter;

	public NumericUpDown spn_manuelzstart;

	internal PictureBox pictureBox_1;

	public CheckBox chk_locked;

	public CheckBox chk_manuelmode;

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

	public event OkCommandWithTwoDataEventHandler PlaneEdit
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_1;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_1, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_1;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_1, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public F_OperationList()
	{
		Class186.smethod_36(this);
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
		CellFirstSelected = false;
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		listView_0.Items.Clear();
		listView_0.Items.Add(buLangTranslate.preDef.Rect, 0);
		listView_0.Items.Add(buLangTranslate.preDef.Cirlce, 1);
		listView_0.Items.Add(buLangTranslate.preDef.Ellipse, 2);
		listView_0.Items.Add(buLangTranslate.preDef.KeyHole, 3);
		listView_0.Items.Add(buLangTranslate.preDef.Polygon, 4);
		listView_0.Items.Add(buLangTranslate.preDef.Slot, 5);
		listView_0.Items.Add(buLangTranslate.preDef.Hole, 6);
		listView_0.Items.Add(buLangTranslate.preDef.Cut, 7);
		listView_0.Items.Add(buLangTranslate.preDef.FreeDraw, 8);
		listView_0.Items.Add(buLangTranslate.preDef.Text, 9);
		listView_0.Items.Add(buLangTranslate.preDef.Wireframe + " " + buLangTranslate.preDef.Text, 10);
		listView_0.Items.Add(buLangTranslate.preDef.Tapping, 11);
		pnl_model.Visible = ShowViewport;
		cmb_tools.Visible = ShowTool;
		btn_camsettings.Visible = ShowCamSettings;
		btn_toolsettings.Visible = ShowTool;
		button_1.Visible = ShowObjectPosition;
		button_4.Visible = ShowCornerLocation;
		button_1.ImageIndex = Convert.ToInt32(buProfileCalc.varProfileRunSettings.ShapeDataParameters.objectAlignment);
		button_4.ImageIndex = Convert.ToInt32(buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedCorner);
		btn_back.Enabled = EnableBackPlane;
		btn_front.Enabled = EnableFrontPlane;
		btn_top.Enabled = EnableTopPlane;
		btn_bottom.Enabled = EnableBottomPlane;
		btn_free.Enabled = EnableFreePlane;
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
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.Rectangle)
		{
			if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.Circle)
			{
				if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.Ellipse)
				{
					if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.KeyHole)
					{
						if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.Polygon)
						{
							if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.Slot)
							{
								if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.Hole)
								{
									if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.Cut)
									{
										if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType != ShapeTypes.FreeDraw)
										{
											if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Text)
											{
												if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextIsWire)
												{
													listView_0.Items[10].Focused = true;
													listView_0.Items[10].Selected = true;
													listView_0.FocusedItem = listView_0.Items[10];
													int_0 = 10;
												}
												else
												{
													listView_0.Items[9].Focused = true;
													listView_0.Items[9].Selected = true;
													listView_0.FocusedItem = listView_0.Items[9];
													int_0 = 9;
												}
											}
										}
										else
										{
											listView_0.Items[8].Focused = true;
											listView_0.Items[8].Selected = true;
											listView_0.FocusedItem = listView_0.Items[8];
											int_0 = 8;
										}
									}
									else
									{
										listView_0.Items[7].Focused = true;
										listView_0.Items[7].Selected = true;
										listView_0.FocusedItem = listView_0.Items[7];
										int_0 = 7;
									}
								}
								else if (!buProfileCalc.varProfileRunSettings.ShapeDataParameters.isTapping)
								{
									listView_0.Items[6].Focused = true;
									listView_0.Items[6].Selected = true;
									listView_0.FocusedItem = listView_0.Items[6];
									int_0 = 6;
								}
								else
								{
									int_0 = 11;
									listView_0.Items[11].Focused = true;
									listView_0.Items[11].Selected = true;
									listView_0.FocusedItem = listView_0.Items[11];
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
				string item = buCall.buVector5_0.ToolToString(Tools[i]);
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
					dgv_data.Height += pnl_model.Height;
				}
			}
			else
			{
				dgv_data.Height = dgv_data.Height + pnl_model.Height + btn_toolsettings.Height;
			}
			int num = Convert.ToInt32((double)base.Width / 6.0);
			btn_back.Width = num - 10;
			label_3.Width = num - 10;
			btn_bottom.Width = num - 10;
			label_5.Width = num - 10;
			btn_front.Width = num - 10;
			label_4.Width = num - 10;
			btn_top.Width = num - 10;
			label_2.Width = num - 10;
			label_2.Left = btn_top.Left;
			btn_bottom.Left = btn_top.Left + btn_top.Width + 5;
			label_5.Left = btn_bottom.Left;
			btn_front.Left = btn_bottom.Left + btn_bottom.Width + 5;
			label_4.Left = btn_front.Left;
			btn_back.Left = btn_front.Left + btn_front.Width + 5;
			label_3.Left = btn_back.Left;
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
		Class186.smethod_152(this);
		btn_ok.Enabled = true;
		timer_0.Enabled = false;
		ShapeUpdateArg data = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
		okCommandWithThreeDataEventHandler_0(null, data, null);
		CellFirstSelected = true;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			label_2.Text = buLangTranslate.preDef.Top;
			label_5.Text = buLangTranslate.preDef.Bottom;
			label_3.Text = buLangTranslate.preDef.Back;
			label_4.Text = buLangTranslate.preDef.Front;
			label_1.Text = buLangTranslate.preDef.Free;
			label_0.Text = buLangTranslate.preDef.Plane;
			label_8.Text = buLangTranslate.preDef.Corner;
			label_6.Text = buLangTranslate.preDef.Object;
			label_7.Text = buLangTranslate.preDef.Edit;
			label_9.Text = buLangTranslate.preDef.Cam;
			checkBox_2.Text = buLangTranslate.preDef.Each + " " + buLangTranslate.preDef.Layer;
			checkBox_1.Text = buLangTranslate.preDef.Incremental + " " + buLangTranslate.preDef.Mode;
			chk_manuelmode.Text = buLangTranslate.preDef.Manuel;
			Text = buLangTranslate.preDef.Shape;
			btn_camsettings.Text = buLangTranslate.preDef.Cam + " " + buLangTranslate.preDef.Setting;
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
		btn_free.BackColor = Color.Gainsboro;
		btn_top.BackColor = Color.Gainsboro;
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Top)
		{
			btn_top.BackColor = Color.PaleGreen;
			chk_manuelmode.Text = buLangTranslate.preDef.Manuel + " " + buLangTranslate.preDef.Depth + " Z " + buLangTranslate.preDef.Top + " " + buLangTranslate.preChar.Position;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Bottom)
		{
			btn_bottom.BackColor = Color.PaleGreen;
			chk_manuelmode.Text = buLangTranslate.preDef.Manuel + " " + buLangTranslate.preDef.Depth + " Z " + buLangTranslate.preDef.Bottom + " " + buLangTranslate.preChar.Position;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Front)
		{
			btn_front.BackColor = Color.PaleGreen;
			chk_manuelmode.Text = buLangTranslate.preDef.Manuel + " " + buLangTranslate.preDef.Depth + " Y " + buLangTranslate.preDef.Front + " " + buLangTranslate.preChar.Position;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Back)
		{
			btn_back.BackColor = Color.PaleGreen;
			chk_manuelmode.Text = buLangTranslate.preDef.Manuel + " " + buLangTranslate.preDef.Depth + " Y " + buLangTranslate.preDef.Back + " " + buLangTranslate.preChar.Position;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Free)
		{
			btn_free.BackColor = Color.PaleGreen;
			chk_manuelmode.Text = buLangTranslate.preDef.Manuel + " " + buLangTranslate.preDef.Depth + " Z " + buLangTranslate.preDef.Top + " " + buLangTranslate.preChar.Position;
		}
	}

	public void Apply()
	{
	}

	public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
	{
		if (dgv_data.Rows.Count < 2)
		{
			return;
		}
		if ((buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Top) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Bottom) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Free))
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.X = Convert.ToDouble(dgv_data.Rows[0].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Y = Convert.ToDouble(dgv_data.Rows[1].Cells[1].Value);
		}
		if ((buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Front) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Back))
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.X = Convert.ToDouble(dgv_data.Rows[0].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Z = Convert.ToDouble(dgv_data.Rows[1].Cells[1].Value);
		}
		if ((buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Left) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Right))
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Y = Convert.ToDouble(dgv_data.Rows[0].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Z = Convert.ToDouble(dgv_data.Rows[1].Cells[1].Value);
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Rectangle)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleWidth = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleHeight = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleRadius = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[6].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[7].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Rectangle;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Circle)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.CircleRadius = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value) / 2.0;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.CircleDepth = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Circle;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Ellipse)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.EllipseRadiusX = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value) / 2.0;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.EllipseRadiusY = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value) / 2.0;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.EllipseDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[6].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Ellipse;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.KeyHole)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleHeadDiameter = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleDiameter = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleLength = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[6].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[7].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.KeyHole;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Polygon)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.PolygonRadius = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value) / 2.0;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.PolygonSide = Convert.ToInt32(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.PolygonDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[6].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Polygon;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Slot)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.SlotDiameter = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.SlotLength = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.SlotDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[6].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Slot;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Hole)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.HoleDiameter = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.HoleDepth = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.isTapping = false;
			if (dgv_data.Rows.Count >= 7)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.isTapping = true;
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TappingDiameter = Convert.ToDouble(dgv_data.Rows[6].Cells[1].Value);
			}
			if (dgv_data.Rows.Count >= 8)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TappingDepth = Convert.ToDouble(dgv_data.Rows[7].Cells[1].Value);
			}
			if (dgv_data.Rows.Count >= 9)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TappingPitch = Convert.ToDouble(dgv_data.Rows[8].Cells[1].Value);
			}
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Hole;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Cut)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.CutDiameter = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.CutLength = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.CutDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[6].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Cut;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.FreeDraw)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.FreeDrawWidth = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.FreeDrawHeight = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.FreeDrawDepth = Convert.ToDouble(dgv_data.Rows[4].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[6].Cells[1].Value);
			if ((dgv_data.Rows.Count >= 6) & (buProfileCalc.varProfileRunSettings.ShapeDataParameters.DepthLevels.Count >= 2))
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.DepthLevels[1] = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
			}
			if ((dgv_data.Rows.Count >= 7) & (buProfileCalc.varProfileRunSettings.ShapeDataParameters.DepthLevels.Count >= 3))
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.DepthLevels[2] = Convert.ToDouble(dgv_data.Rows[6].Cells[1].Value);
			}
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
		}
		if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Text)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextWidth = Convert.ToDouble(dgv_data.Rows[2].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextHeight = Convert.ToDouble(dgv_data.Rows[3].Cells[1].Value);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextString = Convert.ToString(dgv_data.Rows[4].Cells[1].Value);
			if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextIsWire)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextDepth = Convert.ToDouble(dgv_data.Rows[5].Cells[1].Value);
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[6].Cells[1].Value);
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[7].Cells[1].Value);
			}
			else
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextFont = buConversion5.StringToFont(dgv_data.Rows[5].Cells[1].Value.ToString());
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextDepth = Convert.ToDouble(dgv_data.Rows[6].Cells[1].Value);
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth = Convert.ToDouble(dgv_data.Rows[7].Cells[1].Value);
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority = Convert.ToInt32(dgv_data.Rows[8].Cells[1].Value);
			}
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Text;
		}
		buProfileCalc.varProfileRunSettings.ShapeDataParameters.EachLayer = checkBox_2.Checked;
		buProfileCalc.varProfileRunSettings.ShapeDataParameters.isIncrementalMode = checkBox_1.Checked;
		buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthEnable = chk_manuelmode.Checked;
		buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket = checkBox_0.Checked;
		buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthStart = (double)spn_manuelzstart.Value;
	}

	public void ShapeToDataGrid(int Index)
	{
		bool inited = PropertiesForm.Inited;
		dgv_data.Rows.Clear();
		if ((buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Top) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Bottom) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Free))
		{
			DataGridViewRowCollection rows = dgv_data.Rows;
			string string_ = "X";
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.X);
			rows.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows2 = dgv_data.Rows;
			string_ = "Y";
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Y);
			rows2.Add(Class186.smethod_346(double_, this, string_));
		}
		if ((buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Left) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Right))
		{
			DataGridViewRowCollection rows3 = dgv_data.Rows;
			string string_ = "Y";
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Y);
			rows3.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows4 = dgv_data.Rows;
			string_ = "Z";
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Z);
			rows4.Add(Class186.smethod_346(double_, this, string_));
		}
		if ((buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Front) | (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane == planeBoxNames.Back))
		{
			DataGridViewRowCollection rows5 = dgv_data.Rows;
			string string_ = "X";
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.X);
			rows5.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows6 = dgv_data.Rows;
			string_ = "Z";
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.pntBase.Z);
			rows6.Add(Class186.smethod_346(double_, this, string_));
		}
		if (Index == 0)
		{
			DataGridViewRowCollection rows7 = dgv_data.Rows;
			string string_ = buLangTranslate.preDef.Width;
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleWidth);
			rows7.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows8 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Height;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleHeight);
			rows8.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows9 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Radius;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleRadius);
			rows9.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows10 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.RectangleDepth);
			rows10.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows11 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows11.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows12 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows12.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Rectangle;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 1)
		{
			DataGridViewRowCollection rows13 = dgv_data.Rows;
			string string_ = AppLanguage.CadCamDynamic[57];
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.CircleRadius * 2.0);
			rows13.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows14 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.CircleDepth);
			rows14.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows15 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows15.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows16 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows16.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Circle;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 2)
		{
			DataGridViewRowCollection rows17 = dgv_data.Rows;
			string string_ = AppLanguage.CadCamDynamic[20];
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.EllipseRadiusX * 2.0);
			rows17.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows18 = dgv_data.Rows;
			string_ = AppLanguage.CadCamDynamic[21];
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.EllipseRadiusY * 2.0);
			rows18.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows19 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.EllipseDepth);
			rows19.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows20 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows20.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows21 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows21.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Ellipse;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 3)
		{
			DataGridViewRowCollection rows22 = dgv_data.Rows;
			string string_ = AppLanguage.CadCamDynamic[128];
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleHeadDiameter);
			rows22.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows23 = dgv_data.Rows;
			string_ = AppLanguage.CadCamDynamic[57];
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleDiameter);
			rows23.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows24 = dgv_data.Rows;
			string_ = AppLanguage.CadCamDynamic[0];
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleLength);
			rows24.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows25 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.KeyHoleDepth);
			rows25.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows26 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows26.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows27 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows27.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.KeyHole;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 4)
		{
			DataGridViewRowCollection rows28 = dgv_data.Rows;
			string string_ = AppLanguage.CadCamDynamic[57];
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.PolygonRadius * 2.0);
			rows28.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows29 = dgv_data.Rows;
			string_ = AppLanguage.CadCamDynamic[71];
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.PolygonSide);
			rows29.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows30 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.PolygonDepth);
			rows30.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows31 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows31.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows32 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows32.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Polygon;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 5)
		{
			DataGridViewRowCollection rows33 = dgv_data.Rows;
			string string_ = AppLanguage.CadCamDynamic[57];
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.SlotDiameter);
			rows33.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows34 = dgv_data.Rows;
			string_ = AppLanguage.CadCamDynamic[0];
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.SlotLength);
			rows34.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows35 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.SlotDepth);
			rows35.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows36 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows36.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows37 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows37.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Slot;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 6 || Index == 11)
		{
			DataGridViewRowCollection rows38 = dgv_data.Rows;
			string string_ = buLangTranslate.preDef.Diameter;
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.HoleDiameter);
			rows38.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows39 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.HoleDepth);
			rows39.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows40 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows40.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows41 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows41.Add(Class186.smethod_346(double_, this, string_));
			if (Index == 11)
			{
				DataGridViewRowCollection rows42 = dgv_data.Rows;
				string_ = buLangTranslate.preDef.Tapping + " " + buLangTranslate.preDef.Diameter;
				double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.TappingDiameter);
				rows42.Add(Class186.smethod_346(double_, this, string_));
				DataGridViewRowCollection rows43 = dgv_data.Rows;
				string_ = buLangTranslate.preDef.Tapping + " " + buLangTranslate.preDef.Depth;
				double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.TappingDepth);
				rows43.Add(Class186.smethod_346(double_, this, string_));
				DataGridViewRowCollection rows44 = dgv_data.Rows;
				string_ = buLangTranslate.preDef.Tapping + " " + buLangTranslate.preDef.Pitch;
				double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.TappingPitch);
				rows44.Add(Class186.smethod_346(double_, this, string_));
			}
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Hole;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 7)
		{
			DataGridViewRowCollection rows45 = dgv_data.Rows;
			string string_ = buLangTranslate.preDef.Width;
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.CutDiameter);
			rows45.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows46 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Length;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.CutLength);
			rows46.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows47 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.CutDepth);
			rows47.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows48 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows48.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows49 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows49.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Cut;
			if (ProfileTempVars.SelectedOperations.Count >= 2)
			{
				UpdateGridsFromMultiSelect(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType);
			}
		}
		if (Index == 8)
		{
			DataGridViewRowCollection rows50 = dgv_data.Rows;
			string string_ = buLangTranslate.preDef.Width;
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.FreeDrawWidth);
			rows50.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows51 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Height;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.FreeDrawHeight);
			rows51.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows52 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.FreeDrawDepth);
			rows52.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows53 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows53.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows54 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows54.Add(Class186.smethod_346(double_, this, string_));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
		}
		if (Index == 9 || Index == 10)
		{
			DataGridViewRowCollection rows55 = dgv_data.Rows;
			string string_ = buLangTranslate.preDef.Width;
			double double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextWidth);
			rows55.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows56 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Height;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextHeight);
			rows56.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows57 = dgv_data.Rows;
			string string_2 = buLangTranslate.preDef.Text;
			string textString = buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextString;
			rows57.Add(Class186.smethod_536(textString, this, string_2));
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType = ShapeTypes.Text;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextIsWire = false;
			if (Index == 9)
			{
				DataGridViewRowCollection rows58 = dgv_data.Rows;
				string_2 = buLangTranslate.preDef.Font;
				textString = buConversion5.FontToString(buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextFont);
				rows58.Add(Class186.smethod_536(textString, this, string_2));
			}
			if (Index == 10)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextIsWire = true;
			}
			DataGridViewRowCollection rows59 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Depth;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextDepth;
			rows59.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows60 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Depth;
			double_ = buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ExtraDepth);
			rows60.Add(Class186.smethod_346(double_, this, string_));
			DataGridViewRowCollection rows61 = dgv_data.Rows;
			string_ = buLangTranslate.preDef.Priority;
			double_ = buProfileCalc.varProfileRunSettings.ShapeDataParameters.Priority;
			rows61.Add(Class186.smethod_346(double_, this, string_));
		}
		spn_manuelzstart.Value = (decimal)buNumeric5.RoundThreeDigit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthStart);
		checkBox_2.Checked = buProfileCalc.varProfileRunSettings.ShapeDataParameters.EachLayer;
		checkBox_1.Checked = buProfileCalc.varProfileRunSettings.ShapeDataParameters.isIncrementalMode;
		chk_manuelmode.Checked = buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthEnable;
		checkBox_0.Checked = buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket;
		PropertiesForm.Inited = inited;
	}

	public void UpdateGridsFromMultiSelect(ShapeTypes OperationType)
	{
		if (OperationType == ShapeTypes.Rectangle)
		{
			dgv_data.Rows[0].Visible = false;
			dgv_data.Rows[1].Visible = false;
			dgv_data.Rows[2].Visible = false;
			dgv_data.Rows[3].Visible = false;
			dgv_data.Rows[4].Visible = false;
			if (ProfileTempVars.MultiSelectedProps.AllSameShape & ProfileTempVars.MultiSelectedProps.AllSameSize)
			{
				dgv_data.Rows[2].Visible = true;
				dgv_data.Rows[3].Visible = true;
				dgv_data.Rows[4].Visible = true;
			}
		}
		if (OperationType == ShapeTypes.Circle)
		{
			dgv_data.Rows[0].Visible = false;
			dgv_data.Rows[1].Visible = false;
			dgv_data.Rows[2].Visible = false;
			if (ProfileTempVars.MultiSelectedProps.AllSameShape & ProfileTempVars.MultiSelectedProps.AllSameSize)
			{
				dgv_data.Rows[2].Visible = true;
			}
		}
		if (OperationType == ShapeTypes.Ellipse)
		{
			dgv_data.Rows[0].Visible = false;
			dgv_data.Rows[1].Visible = false;
			dgv_data.Rows[2].Visible = false;
			dgv_data.Rows[3].Visible = false;
			if (ProfileTempVars.MultiSelectedProps.AllSameShape & ProfileTempVars.MultiSelectedProps.AllSameSize)
			{
				dgv_data.Rows[2].Visible = true;
				dgv_data.Rows[3].Visible = true;
			}
		}
		if (OperationType == ShapeTypes.KeyHole)
		{
			dgv_data.Rows[0].Visible = false;
			dgv_data.Rows[1].Visible = false;
			dgv_data.Rows[2].Visible = false;
			dgv_data.Rows[3].Visible = false;
			dgv_data.Rows[4].Visible = false;
			if (ProfileTempVars.MultiSelectedProps.AllSameShape & ProfileTempVars.MultiSelectedProps.AllSameSize)
			{
				dgv_data.Rows[2].Visible = true;
				dgv_data.Rows[3].Visible = true;
				dgv_data.Rows[4].Visible = true;
			}
		}
		if (OperationType == ShapeTypes.Polygon)
		{
			dgv_data.Rows[0].Visible = false;
			dgv_data.Rows[1].Visible = false;
			dgv_data.Rows[2].Visible = false;
			dgv_data.Rows[3].Visible = false;
			if (ProfileTempVars.MultiSelectedProps.AllSameShape & ProfileTempVars.MultiSelectedProps.AllSameSize)
			{
				dgv_data.Rows[2].Visible = true;
			}
		}
		if (OperationType == ShapeTypes.Hole)
		{
			dgv_data.Rows[0].Visible = false;
			dgv_data.Rows[1].Visible = false;
			dgv_data.Rows[2].Visible = false;
			if (ProfileTempVars.MultiSelectedProps.AllSameShape & ProfileTempVars.MultiSelectedProps.AllSameSize)
			{
				dgv_data.Rows[2].Visible = true;
			}
		}
		if (OperationType == ShapeTypes.Cut)
		{
			dgv_data.Rows[0].Visible = false;
			dgv_data.Rows[1].Visible = false;
			dgv_data.Rows[2].Visible = false;
			dgv_data.Rows[3].Visible = false;
			if (ProfileTempVars.MultiSelectedProps.AllSameShape & ProfileTempVars.MultiSelectedProps.AllSameSize)
			{
				dgv_data.Rows[2].Visible = true;
				dgv_data.Rows[3].Visible = true;
			}
		}
	}

	private void dgv_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (!PropertiesForm.Inited)
			{
				return;
			}
			CellFirstSelected = true;
			if (!((e.ColumnIndex >= 1) & (e.RowIndex >= 0)))
			{
				return;
			}
			ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
			DataGridValuesToShape(e.ColumnIndex, e.RowIndex);
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				shapeUpdateArg.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				if (ProfileTempVars.OperationEditing & buProfileCalc.varProfileRunSettings.ShapeDataParameters.UpdateEditOperationWithoutOk)
				{
					shapeUpdateArg.Finished = true;
				}
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
		}
		catch (Exception)
		{
		}
	}

	private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0) & (clsVar5.ShapeTempPar.ValueGridIndex != e.RowIndex)))
			{
				clsVar5.ShapeTempPar.ValueGridIndex = e.RowIndex;
				buCall.buProfileCalc_0.FindShapeDataValueType(buProfileCalc.varProfileRunSettings.ShapeDataParameters, e.RowIndex, ref clsVar5.ShapeTempPar.ValueType);
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
					shapeUpdateArg.Command = "DrawDim";
					shapeUpdateArg.ValueType = clsVar5.ShapeTempPar.ValueType;
					okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void dgv_data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (PropertiesForm.Inited && ((e.ColumnIndex >= 0) & (e.RowIndex >= 0)) && buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Text && (!buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextIsWire & (e.RowIndex == 5)))
			{
				FontDialog fontDialog = new FontDialog();
				fontDialog.Font = buConversion5.StringToFont(dgv_data.Rows[5].Cells[1].Value.ToString());
				fontDialog.ShowDialog();
				dgv_data.Rows[5].Cells[1].Value = buConversion5.FontToString(fontDialog.Font);
			}
		}
		catch (Exception)
		{
		}
	}

	private void dgv_data_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (!PropertiesForm.Inited)
			{
				return;
			}
			PropertiesForm.Inited = false;
			if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0) & (clsVar5.ShapeTempPar.ValueGridIndex != e.RowIndex))
			{
				clsVar5.ShapeTempPar.ValueGridIndex = e.RowIndex;
				buCall.buProfileCalc_0.FindShapeDataValueType(buProfileCalc.varProfileRunSettings.ShapeDataParameters, e.RowIndex, ref clsVar5.ShapeTempPar.ValueType);
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
					shapeUpdateArg.Command = "DrawDim";
					shapeUpdateArg.ValueType = clsVar5.ShapeTempPar.ValueType;
					okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
				}
			}
			PropertiesForm.Inited = true;
		}
		catch (Exception)
		{
			PropertiesForm.Inited = true;
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
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				DataGridValuesToShape(-1, -1);
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
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
		if (control.Name == button_3.Name)
		{
			PropertiesForm.Inited = false;
			if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket = false;
			}
			else
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket = true;
			}
			checkBox_0.Checked = buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket;
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg2 = new ShapeUpdateArg();
				shapeUpdateArg2.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg2, null);
			}
		}
		if (control.Name == button_4.Name)
		{
			F_CornerLocation f_CornerLocation = new F_CornerLocation();
			f_CornerLocation.Corner = buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedCorner;
			f_CornerLocation.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CornerLocation.Properties.FormPosition = FormStartPosition.Manual;
			f_CornerLocation.Top = 100;
			f_CornerLocation.Left = Screen.PrimaryScreen.Bounds.Width - f_CornerLocation.Width;
			f_CornerLocation.Init();
			f_CornerLocation.ShowDialog(this);
			if (f_CornerLocation.Properties.Result == DialogResult.OK)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedCorner = f_CornerLocation.Corner;
				button_4.ImageIndex = Convert.ToInt32(buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedCorner);
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					DataGridValuesToShape(-1, -1);
					ShapeUpdateArg shapeUpdateArg3 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
					shapeUpdateArg3.Finished = false;
					okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg3, null);
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
			f_ObjectLocation.Alingnment = buProfileCalc.varProfileRunSettings.ShapeDataParameters.objectAlignment;
			f_ObjectLocation.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_ObjectLocation.Properties.FormPosition = FormStartPosition.Manual;
			f_ObjectLocation.Top = 100;
			f_ObjectLocation.Left = Screen.PrimaryScreen.Bounds.Width - f_ObjectLocation.Width;
			f_ObjectLocation.Init();
			f_ObjectLocation.ShowDialog(this);
			if (f_ObjectLocation.Properties.Result == DialogResult.OK)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.objectAlignment = f_ObjectLocation.Alingnment;
				button_1.ImageIndex = Convert.ToInt32(buProfileCalc.varProfileRunSettings.ShapeDataParameters.objectAlignment);
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					DataGridValuesToShape(-1, -1);
					ShapeUpdateArg shapeUpdateArg4 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
					shapeUpdateArg4.Finished = false;
					okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg4, null);
				}
			}
			Focus();
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
		}
		if (control.Name == button_0.Name)
		{
			F_ShapeEdit f_ShapeEdit = new F_ShapeEdit();
			f_ShapeEdit.Edit = new ShapeEdit(buProfileCalc.varProfileRunSettings.ShapeDataParameters.Edit);
			f_ShapeEdit.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_ShapeEdit.Properties.FormPosition = FormStartPosition.Manual;
			f_ShapeEdit.ShowPolar = false;
			f_ShapeEdit.refPlane = buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane;
			f_ShapeEdit.Height = 300;
			f_ShapeEdit.Top = 100;
			f_ShapeEdit.Left = Screen.PrimaryScreen.Bounds.Width - f_ShapeEdit.Width - 100;
			f_ShapeEdit.Init();
			f_ShapeEdit.ShowDialog(this);
			if (f_ShapeEdit.Properties.Result == DialogResult.OK)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.Edit = new ShapeEdit(f_ShapeEdit.Edit);
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					DataGridValuesToShape(-1, -1);
					ShapeUpdateArg shapeUpdateArg5 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
					shapeUpdateArg5.Finished = false;
					okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg5, null);
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
			F_CamSettings f_CamSettings = new F_CamSettings();
			f_CamSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CamSettings.CamPar = new camParameters5(buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars);
			f_CamSettings.Init();
			f_CamSettings.ShowDialog(this);
			if (f_CamSettings.Properties.Result == DialogResult.OK)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars = new camParameters5(f_CamSettings.CamPar);
				ProfileTempVars.CamAssinged = true;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					ShapeUpdateArg data = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
					okCommandWithThreeDataEventHandler_0(null, data, null);
				}
			}
			Focus();
		}
		if (control.Name == btn_toolsettings.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("ToolEdit", "");
		}
		if (control.Name == btn_top.Name)
		{
			int indexRow = -1;
			int indexCol = -1;
			GetRowColIndex(ref indexRow, ref indexCol);
			PropertiesForm.Inited = false;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane = planeBoxNames.Top;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				SetRowColIndex(indexRow, indexCol);
				ShapeUpdateArg shapeUpdateArg6 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				shapeUpdateArg6.Command = "PlaneChanged";
				shapeUpdateArg6.ValueType = clsVar5.ShapeTempPar.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg6, null);
			}
		}
		if (control.Name == btn_bottom.Name)
		{
			int indexRow2 = -1;
			int indexCol2 = -1;
			GetRowColIndex(ref indexRow2, ref indexCol2);
			PropertiesForm.Inited = false;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane = planeBoxNames.Bottom;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				SetRowColIndex(indexRow2, indexCol2);
				ShapeUpdateArg shapeUpdateArg7 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				shapeUpdateArg7.Command = "PlaneChanged";
				shapeUpdateArg7.ValueType = buProfileCalc.varProfileRunSettings.ShapeDataParameters.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg7, null);
			}
		}
		if (control.Name == btn_free.Name)
		{
			int indexRow3 = -1;
			int indexCol3 = -1;
			GetRowColIndex(ref indexRow3, ref indexCol3);
			PropertiesForm.Inited = false;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane = planeBoxNames.Free;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				SetRowColIndex(indexRow3, indexCol3);
				ShapeUpdateArg shapeUpdateArg8 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				shapeUpdateArg8.Command = "PlaneChanged";
				shapeUpdateArg8.ValueType = buProfileCalc.varProfileRunSettings.ShapeDataParameters.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg8, null);
			}
		}
		if (control.Name == btn_front.Name)
		{
			int indexRow4 = -1;
			int indexCol4 = -1;
			GetRowColIndex(ref indexRow4, ref indexCol4);
			PropertiesForm.Inited = false;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane = planeBoxNames.Front;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				SetRowColIndex(indexRow4, indexCol4);
				ShapeUpdateArg shapeUpdateArg9 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				shapeUpdateArg9.Command = "PlaneChanged";
				shapeUpdateArg9.ValueType = buProfileCalc.varProfileRunSettings.ShapeDataParameters.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg9, null);
			}
		}
		if (control.Name == btn_back.Name)
		{
			int indexRow5 = -1;
			int indexCol5 = -1;
			GetRowColIndex(ref indexRow5, ref indexCol5);
			PropertiesForm.Inited = false;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane = planeBoxNames.Back;
			PlaneColorUpdate();
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				SetRowColIndex(indexRow5, indexCol5);
				ShapeUpdateArg shapeUpdateArg10 = new ShapeUpdateArg(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				shapeUpdateArg10.Command = "PlaneChanged";
				shapeUpdateArg10.ValueType = buProfileCalc.varProfileRunSettings.ShapeDataParameters.ValueType;
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg10, null);
			}
		}
		if (control.Name == button_2.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("PlaneSelect", "");
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthStart = (double)spn_manuelzstart.Value;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				shapeUpdateArg.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
			}
			PropertiesForm.Inited = true;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (!PropertiesForm.Inited || AppBool.Started)
		{
			return;
		}
		PropertiesForm.Inited = false;
		if (control.Name == chk_locked.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("Locked", chk_locked.Checked);
			ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
			shapeUpdateArg.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
			okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg, null);
		}
		if (control.Name == checkBox_0.Name)
		{
			PropertiesForm.Inited = false;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket = checkBox_0.Checked;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars.Pockets.Enable = buProfileCalc.varProfileRunSettings.ShapeDataParameters.isShapePocket;
			ShapeToDataGrid(int_0);
			PropertiesForm.Inited = true;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg2 = new ShapeUpdateArg();
				shapeUpdateArg2.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg2, null);
			}
		}
		if (control.Name == checkBox_1.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			ShapeUpdateArg shapeUpdateArg3 = new ShapeUpdateArg();
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.isIncrementalMode = checkBox_1.Checked;
			shapeUpdateArg3.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
			okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg3, null);
		}
		if (control.Name == checkBox_2.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			if (checkBox_2.Checked)
			{
				PropertiesForm.Inited = false;
				chk_manuelmode.Checked = false;
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthEnable = false;
			}
			PropertiesForm.Inited = true;
			ShapeUpdateArg shapeUpdateArg4 = new ShapeUpdateArg();
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.EachLayer = checkBox_2.Checked;
			shapeUpdateArg4.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
			okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg4, null);
		}
		if (control.Name == chk_manuelmode.Name)
		{
			if (chk_manuelmode.Checked)
			{
				PropertiesForm.Inited = false;
				checkBox_2.Checked = false;
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.EachLayer = false;
				PropertiesForm.Inited = true;
				if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane != planeBoxNames.Front)
				{
					if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane != planeBoxNames.Back)
					{
						if (buProfileCalc.varProfileRunSettings.ShapeDataParameters.selectedPlane != planeBoxNames.Bottom)
						{
							if ((double)spn_manuelzstart.Value < buProfileCalc.varProfileRunSettings.ShapeDataParameters.SizeMaterailDepth / 3.0)
							{
								spn_manuelzstart.Value = (decimal)(0.0 - buProfileCalc.varProfileRunSettings.ShapeDataParameters.SizeMaterailDepth);
							}
						}
						else if ((double)spn_manuelzstart.Value > buProfileCalc.varProfileRunSettings.ShapeDataParameters.SizeMaterailDepth / 3.0)
						{
							spn_manuelzstart.Value = 0m;
						}
					}
					else
					{
						if ((double)spn_manuelzstart.Value < (0.0 - buProfileCalc.varProfileRunSettings.ShapeDataParameters.SizeMaterailHeight) / 3.0)
						{
							spn_manuelzstart.Value = 0m;
						}
						if ((double)spn_manuelzstart.Value > 1.0)
						{
							spn_manuelzstart.Value = 0m;
						}
					}
				}
				else if ((double)spn_manuelzstart.Value > (0.0 - buProfileCalc.varProfileRunSettings.ShapeDataParameters.SizeMaterailHeight) / 3.0)
				{
					spn_manuelzstart.Value = (decimal)(0.0 - buProfileCalc.varProfileRunSettings.ShapeDataParameters.SizeMaterailHeight);
				}
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthStart = (double)spn_manuelzstart.Value;
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg5 = new ShapeUpdateArg();
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.ManuelDepthEnable = chk_manuelmode.Checked;
				shapeUpdateArg5.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
				okCommandWithThreeDataEventHandler_0(null, shapeUpdateArg5, null);
			}
		}
		Apply();
		PropertiesForm.Inited = true;
		Class186.smethod_221(sender, (EventArgs)null, this);
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			if ((cmb_tools.SelectedIndex >= 0) & (cmb_tools.SelectedIndex <= Tools.Count - 1))
			{
				activeTool = new ToolBase5(Tools[cmb_tools.SelectedIndex]);
			}
			if ((okCommandWithThreeDataEventHandler_0 != null) & (activeTool != null))
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars.Speeds.Feed = activeTool.CamData.FeedSpeed;
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars.Speeds.Plunge = activeTool.CamData.PlungeSpeed;
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars.Speeds.Leave = activeTool.CamData.LeaveSpeed;
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars.Speeds.Finish = activeTool.CamData.FinishSpeed;
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.CamPars.Speeds.SpindleSpeed = activeTool.CamData.SpindleSpeed;
				ProfileTempVars.CamAssinged = false;
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				shapeUpdateArg.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
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

	internal void method_5(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		if (PropertiesForm.Inited && ((e.ItemIndex >= 0) & e.IsSelected))
		{
			PropertiesForm.Inited = false;
			ShapeToDataGrid(e.ItemIndex);
			int_0 = e.ItemIndex;
			PropertiesForm.Inited = true;
			clsVar5.ShapeTempPar.ValueGridIndex = 0;
			buCall.buProfileCalc_0.FindShapeDataValueType(buProfileCalc.varProfileRunSettings.ShapeDataParameters, 0, ref clsVar5.ShapeTempPar.ValueType);
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.isTapping = false;
			buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextIsWire = false;
			if (e.ItemIndex == 10 && buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Text)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.TextIsWire = true;
			}
			if (e.ItemIndex == 11 && buProfileCalc.varProfileRunSettings.ShapeDataParameters.ShapeType == ShapeTypes.Hole)
			{
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.isTapping = true;
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				buProfileCalc.varProfileRunSettings.ShapeDataParameters.ValueType = clsVar5.ShapeTempPar.ValueType;
				shapeUpdateArg.Parameters = new ShapeRuntimeData(buProfileCalc.varProfileRunSettings.ShapeDataParameters);
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
