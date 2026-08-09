using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCircularShapeResolution : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public int SelectedRow = -1;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	public buButton btn_close;

	internal DataGridView dataGridView_0;

	public buButton btn_remove;

	public buButton btn_add;

	public F_MarbleCircularShapeResolution()
	{
		Class186.smethod_203(this);
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
		if (!PropertiesForm.VisualUpdated)
		{
			InitVisual();
		}
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 40;
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
			dataGridViewColumn2.Width = 130;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Min + " " + buLangTranslate.preDef.Diameter;
			dataGridViewColumn2.Name = "MinDiameter";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 130;
			dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Max + " " + buLangTranslate.preDef.Diameter;
			dataGridViewColumn3.Name = "MaxDiameter";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 140;
			dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Devide + " " + buLangTranslate.preDef.Length;
			dataGridViewColumn4.Name = "Len";
			dataGridViewColumn4.ReadOnly = false;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 180;
			dataGridViewColumn5.HeaderText = buLangTranslate.preSentences.RegenDeviation;
			dataGridViewColumn5.Name = "Regen";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn5);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.ColumnHeadersVisible = true;
		FillInfo();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void InitVisual()
	{
		FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
		if (fileInfo.Exists)
		{
			Control.ControlCollection controlCollection = null;
			controlCollection = buGround_0.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
		}
		PropertiesForm.VisualUpdated = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.Shape + " " + buLangTranslate.preDef.Resolution;
			buButton_0.Text = buLangTranslate.preDef.Ok;
			buButton_1.Text = buLangTranslate.preDef.Cancel;
		}
		catch (Exception)
		{
		}
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

	internal void method_1(object sender, EventArgs e)
	{
		buMarbleCalc.CircularShapeResolutions.Clear();
		for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
		{
			GeometryTableItem geometryTableItem = new GeometryTableItem();
			geometryTableItem.DiameterMin = double.Parse(dataGridView_0.Rows[i].Cells[1].Value.ToString());
			geometryTableItem.DiameterMax = double.Parse(dataGridView_0.Rows[i].Cells[2].Value.ToString());
			geometryTableItem.DevideLength = double.Parse(dataGridView_0.Rows[i].Cells[3].Value.ToString());
			geometryTableItem.RegenDeviation = double.Parse(dataGridView_0.Rows[i].Cells[4].Value.ToString());
			buMarbleCalc.CircularShapeResolutions.Add(geometryTableItem);
		}
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

	internal void method_2(object sender, EventArgs e)
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

	public void FillInfo()
	{
		dataGridView_0.Rows.Clear();
		for (int i = 0; i <= buMarbleCalc.CircularShapeResolutions.Count - 1; i++)
		{
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			double diameterMin = buMarbleCalc.CircularShapeResolutions[i].DiameterMin;
			double diameterMax = buMarbleCalc.CircularShapeResolutions[i].DiameterMax;
			double devideLength = buMarbleCalc.CircularShapeResolutions[i].DevideLength;
			double regenDeviation = buMarbleCalc.CircularShapeResolutions[i].RegenDeviation;
			rows.Add(Class186.smethod_142(regenDeviation, diameterMin, devideLength, i + 1, diameterMax, this));
			dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = 40;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_add.Name)
		{
			dataGridView_0.Rows.Add(Class186.smethod_142(0.0, 0.0, 0.0, dataGridView_0.Rows.Count, 0.0, this));
			dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = 40;
		}
		if (control.Name == btn_remove.Name && ((dataGridView_0.Rows.Count > 0) & (SelectedRow >= 0) & (SelectedRow <= dataGridView_0.Rows.Count - 1)))
		{
			buDialogMessageBoxYesNo buDialogMessageBoxYesNo2 = new buDialogMessageBoxYesNo();
			buDialogMessageBoxYesNo2.StartPosition = FormStartPosition.CenterScreen;
			buDialogMessageBoxYesNo2.Init(buLangTranslate.preDef.Delete, buLangTranslate.preSentences.DoYouWantToDelete);
			buDialogMessageBoxYesNo2.ShowDialog();
			if (buDialogMessageBoxYesNo2.Result == DialogResult.Yes)
			{
				dataGridView_0.Rows.RemoveAt(SelectedRow);
			}
		}
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		SelectedRow = e.RowIndex;
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
