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

public class F_MarbleImageThicknessList : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<MarbleImageThicknessData> ImageList = new List<MarbleImageThicknessData>();

	public int indexG54 = -1;

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal DataGridView dataGridView_0;

	internal ImageList imageList_0;

	public buButton btn_g54save;

	public buButton btn_g54open;

	public buButton btn_add;

	public F_MarbleImageThicknessList()
	{
		Class186.smethod_454(this);
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
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 35;
			dataGridViewColumn.HeaderText = buLangTranslate.preDef.Number;
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 90;
			dataGridViewColumn2.HeaderText = buLangTranslate.preChar.X;
			dataGridViewColumn2.Name = "X";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 90;
			dataGridViewColumn3.HeaderText = buLangTranslate.preChar.Y;
			dataGridViewColumn3.Name = "Y";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 90;
			dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Width;
			dataGridViewColumn4.Name = "Width";
			dataGridViewColumn4.ReadOnly = false;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 90;
			dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Height;
			dataGridViewColumn5.Name = "Height";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn6.Width = 90;
			dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Thickness;
			dataGridViewColumn6.Name = "Thickness";
			dataGridViewColumn6.ReadOnly = false;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn7.Width = 200;
			dataGridViewColumn7.HeaderText = buLangTranslate.preDef.Explanation;
			dataGridViewColumn7.Name = "Name";
			dataGridViewColumn7.ReadOnly = false;
			dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn7);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		FillG54();
		indexG54 = -1;
		if (ImageList.Count > 0)
		{
			indexG54 = 0;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_34(this);
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

	public void Apply()
	{
		ImageList.Clear();
		for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
		{
			MarbleImageThicknessData marbleImageThicknessData = new MarbleImageThicknessData();
			marbleImageThicknessData.XOffset = double.Parse(dataGridView_0.Rows[i].Cells[1].Value.ToString());
			marbleImageThicknessData.YOffset = double.Parse(dataGridView_0.Rows[i].Cells[2].Value.ToString());
			marbleImageThicknessData.DeltaWidth = double.Parse(dataGridView_0.Rows[i].Cells[3].Value.ToString());
			marbleImageThicknessData.DeltaHeight = double.Parse(dataGridView_0.Rows[i].Cells[4].Value.ToString());
			marbleImageThicknessData.Thickness = double.Parse(dataGridView_0.Rows[i].Cells[5].Value.ToString());
			marbleImageThicknessData.Explanation = dataGridView_0.Rows[i].Cells[5].Value.ToString();
			ImageList.Add(marbleImageThicknessData);
		}
	}

	public void FillG54()
	{
		dataGridView_0.Rows.Clear();
		for (int i = 0; i <= ImageList.Count - 1; i++)
		{
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			double xOffset = ImageList[i].XOffset;
			double yOffset = ImageList[i].YOffset;
			double deltaWidth = ImageList[i].DeltaWidth;
			double deltaHeight = ImageList[i].DeltaHeight;
			double thickness = ImageList[i].Thickness;
			string explanation = ImageList[i].Explanation;
			rows.Add(Class186.smethod_272(i + 1, explanation, xOffset, deltaWidth, yOffset, this, thickness, deltaHeight));
			dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = 40;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (control.Name == btn_ok.Name)
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
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
			}
			if (control.Name == btn_add.Name)
			{
				DataGridViewRowCollection rows = dataGridView_0.Rows;
				int count = ImageList.Count;
				string string_ = "";
				rows.Add(Class186.smethod_272(count, string_, 0.0, 0.0, 0.0, this, 0.0, 0.0));
			}
			if (!(control.Name == btn_g54open.Name))
			{
			}
			if (!(control.Name == btn_g54save.Name))
			{
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		indexG54 = e.RowIndex;
		if (indexG54 >= 0)
		{
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
