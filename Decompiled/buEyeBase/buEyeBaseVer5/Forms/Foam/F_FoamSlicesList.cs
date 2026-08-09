using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamSlicesList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<LengthCount> SliceList = new List<LengthCount>();

	private int int_0 = -1;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	public DataGridView DGV_table;

	public Button btn_remove;

	public Button btn_add;

	public F_FoamSlicesList()
	{
		Class186.smethod_118(this);
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
		DGV_table.Columns.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 200;
		dataGridViewColumn.HeaderText = "Length";
		dataGridViewColumn.Name = "Length";
		dataGridViewColumn.ReadOnly = false;
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		DGV_table.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = 200;
		dataGridViewColumn2.HeaderText = "Count";
		dataGridViewColumn2.Name = "Count";
		dataGridViewColumn2.ReadOnly = false;
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		DGV_table.Columns.Add(dataGridViewColumn2);
		DGV_table.RowHeadersVisible = false;
		DGV_table.AllowUserToAddRows = false;
		DGV_table.AllowUserToResizeColumns = false;
		FillGrid();
		ControlUpdate();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void ControlUpdate()
	{
	}

	public void FillGrid()
	{
		DGV_table.Rows.Clear();
		for (int i = 0; i <= SliceList.Count - 1; i++)
		{
			DataGridViewRowCollection rows = DGV_table.Rows;
			double length = SliceList[i].Length;
			int count = SliceList[i].Count;
			rows.Add(Class186.smethod_227(length, count, this));
		}
	}

	public void Apply()
	{
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
		Control control = new Control();
		control = (Control)sender;
		if (!(control.Name == btn_ok.Name))
		{
			if (!(control.Name == btn_cancel.Name))
			{
				if (!(control.Name == btn_add.Name))
				{
					if (control.Name == btn_remove.Name && ((int_0 >= 0) & (int_0 <= SliceList.Count - 1)))
					{
						SliceList.RemoveAt(int_0);
						DGV_table.Rows.RemoveAt(int_0);
					}
				}
				else if ((numericUpDown_0.Value > 0m) & (numericUpDown_1.Value > 0m))
				{
					SliceList.Add(new LengthCount((double)numericUpDown_0.Value, (int)numericUpDown_1.Value));
					DataGridViewRowCollection rows = DGV_table.Rows;
					double double_ = (double)numericUpDown_0.Value;
					int num = (int)numericUpDown_1.Value;
					rows.Add(Class186.smethod_227(double_, num, this));
				}
			}
			else
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
		}
		else
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
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
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
