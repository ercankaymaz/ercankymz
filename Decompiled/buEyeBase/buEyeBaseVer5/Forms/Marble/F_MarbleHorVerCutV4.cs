using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorVerCutV4 : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties Properties = new FormProperties();

	public bool isHorizontal = false;

	public bool isDialog = false;

	private IContainer icontainer_0 = null;

	public buButton btn_minimise;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_cancel;

	public Panel pnl_base;

	public Panel pnl_data;

	public buButton btn_save;

	public buButton btn_open;

	public buButton btn_itemok;

	public buCheckBox chk_cutend;

	public buButton btn_remove;

	public buCheckBox chk_cutstart;

	public buButton btn_add;

	public buButton btn_itemendpos;

	public buButton btn_itemstartpos;

	public buButton btn_itemclearall;

	public buButton btn_itemup;

	public buButton btn_itemdown;

	public buSpin spn_angle;

	public DataGridView DGV_items;

	public buSpin spn_length;

	public buCheckBox chk_lefttop;

	public buCheckBox chk_leftbottom;

	public buLabel lbl_width;

	public buLabel lbl_endangle;

	public buSpin spn_itemEA1;

	public buLabel lbl_startangle;

	public buSpin spn_itemlen1;

	public buSpin spn_itemSA1;

	public buSpin spn_itemcount1;

	public buLabel lbl_count;

	public F_MarbleHorVerCutV4()
	{
		Class186.smethod_385(this);
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
		if (DGV_items.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 50;
			dataGridViewColumn.HeaderText = buLangTranslate.preDef.Number;
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			DGV_items.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 120;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Width;
			dataGridViewColumn2.Name = "X";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			DGV_items.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 70;
			dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Count;
			dataGridViewColumn3.Name = "Y";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			DGV_items.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 110;
			dataGridViewColumn4.HeaderText = buLangTranslate.preDef.StartAngle;
			dataGridViewColumn4.Name = "Z";
			dataGridViewColumn4.ReadOnly = true;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			DGV_items.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 110;
			dataGridViewColumn5.HeaderText = buLangTranslate.preDef.EndAngle;
			dataGridViewColumn5.Name = "C";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			DGV_items.Columns.Add(dataGridViewColumn5);
		}
		DGV_items.RowHeadersVisible = false;
		DGV_items.AllowUserToAddRows = false;
		DGV_items.AllowUserToResizeColumns = false;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLanguage();
	}

	public void LoadLanguage()
	{
		lbl_count.Text = buLangTranslate.preDef.Count;
		lbl_endangle.Text = buLangTranslate.preDef.EndAngle;
		lbl_width.Text = buLangTranslate.preDef.Width;
		lbl_startangle.Text = buLangTranslate.preDef.StartAngle;
		btn_cancel.Text = buLangTranslate.preDef.Cancel;
		btn_itemendpos.Text = buLangTranslate.preDef.EndPoint;
		btn_itemok.Text = buLangTranslate.preDef.Ok;
		btn_itemstartpos.Text = buLangTranslate.preDef.StartPoint;
		spn_angle.Caption.Caption = buLangTranslate.preDef.Angle;
		spn_length.Caption.Caption = buLangTranslate.preDef.Length;
		chk_cutend.Text = buLangTranslate.preDef.End + " " + buLangTranslate.preDef.Cutting;
		chk_cutstart.Text = buLangTranslate.preDef.Start + " " + buLangTranslate.preDef.Cutting;
		Text = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Cutting;
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

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (!isDialog)
			{
				return;
			}
			if (control.Name == btn_itemok.Name)
			{
				Properties.Result = DialogResult.OK;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (Properties.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (control.Name == btn_close.Name)
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
			if (control.Name == btn_maximize.Name)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			if (control.Name == btn_minimise.Name)
			{
				base.WindowState = FormWindowState.Normal;
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		Control control = sender as Control;
		if (control.Tag != null)
		{
			if (control.Tag.ToString() == "Hor")
			{
				MarbleTempVars.HorizontalItemSelectedRowIndex = e.RowIndex;
				MarbleTempVars.HorizontalItemSelectedColIndex = e.ColumnIndex;
			}
			if (control.Tag.ToString() == "Ver")
			{
				MarbleTempVars.VerticalItemSelectedRowIndex = e.RowIndex;
				MarbleTempVars.VerticalItemSelectedColIndex = e.ColumnIndex;
			}
			if (control.Tag.ToString() == "HorVerHor")
			{
				MarbleTempVars.HorVerHorizontalItemSelectedRowIndex = e.RowIndex;
				MarbleTempVars.HorVerHorizontalItemSelectedColIndex = e.ColumnIndex;
			}
			if (control.Tag.ToString() == "HorVerVer")
			{
				MarbleTempVars.HorVerVerticalItemSelectedRowIndex = e.RowIndex;
				MarbleTempVars.HorVerVerticalItemSelectedColIndex = e.ColumnIndex;
			}
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		if (AppBool.TouchPad)
		{
			string Value = DGV_items.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
			buFunctions.ShowKeyPad(this, null, ref Value, DGV_items.Columns[e.ColumnIndex].HeaderText);
			DGV_items.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Value;
			DGV_items.Rows[e.RowIndex].Cells[e.ColumnIndex].DataGridView.EndEdit();
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
