using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHoleTable : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<DiameterDepthPoint> Holes = new List<DiameterDepthPoint>();

	public DiameterDepthPoint Hole = new DiameterDepthPoint();

	public int SelectedRowSheet = -1;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal DataGridView dataGridView_0;

	public buButton btn_delete;

	public buButton btn_remove;

	public buButton btn_add;

	internal buGroup buGroup_0;

	public buButton btn_closehole;

	public buButton btn_addhole;

	public buSpin spn_depth;

	public buSpin spn_dia;

	public buSpin spn_z;

	public buSpin spn_y;

	public buSpin spn_x;

	public F_MarbleHoleTable()
	{
		Class186.smethod_37(this);
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
		spn_depth.Value = Hole.Depth;
		spn_dia.Value = Hole.Diameter;
		spn_x.Value = Hole.Position.X;
		spn_y.Value = Hole.Position.Y;
		spn_z.Value = Hole.Position.Z;
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 40;
			dataGridViewColumn.HeaderText = buLangTranslate.preDef.No;
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 100;
			dataGridViewColumn2.HeaderText = "X";
			dataGridViewColumn2.Name = "X";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 100;
			dataGridViewColumn3.HeaderText = "Y";
			dataGridViewColumn3.Name = "Y";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 100;
			dataGridViewColumn4.HeaderText = "Z";
			dataGridViewColumn4.Name = "Z";
			dataGridViewColumn4.ReadOnly = false;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 100;
			dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Diameter;
			dataGridViewColumn5.Name = "Diameter";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn6.Width = 100;
			dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Depth;
			dataGridViewColumn6.Name = "Depth";
			dataGridViewColumn6.ReadOnly = false;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn6);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		for (int i = 0; i <= Holes.Count - 1; i++)
		{
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			double double_ = Holes[i].Position.X;
			double double_2 = Holes[i].Position.Y;
			double z = Holes[i].Position.Z;
			double diameter = Holes[i].Diameter;
			double depth = Holes[i].Depth;
			rows.Add(Class186.smethod_467(double_, z, double_2, diameter, i + 1, this, depth));
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 14)
			{
				buGround_0.Text = Captions[0];
				btn_ok.Text = Captions[13];
				btn_cancel.Text = Captions[14];
			}
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
		try
		{
			buSpin buSpin2 = sender as buSpin;
			if (AppBool.TouchPad)
			{
				F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
				f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
				f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
				f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
				if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
				{
					buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
				}
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		if (!((e.RowIndex >= 0) & (e.RowIndex <= dataGridView_0.Rows.Count - 1)))
		{
			return;
		}
		SelectedRowSheet = e.RowIndex;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.ShowDialog(dataGridView_0.Rows[SelectedRowSheet].Cells[e.ColumnIndex].Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				dataGridView_0.Rows[SelectedRowSheet].Cells[e.ColumnIndex].Value = f_KeyPadNumV.Value.ToString();
			}
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= dataGridView_0.Rows.Count - 1))
		{
		}
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		if (((e.ColumnIndex >= 0) & (e.RowIndex >= 0)) && ((e.ColumnIndex == 1) & (e.RowIndex <= dataGridView_0.Rows.Count - 1)))
		{
		}
	}

	public void Apply()
	{
		Hole.Depth = spn_depth.Value;
		Hole.Diameter = spn_dia.Value;
		Hole.Position.X = spn_x.Value;
		Hole.Position.Y = spn_y.Value;
		Hole.Position.Z = spn_z.Value;
		for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
		{
			if (i <= Holes.Count - 1)
			{
				if (buNumeric5.IsNumeric(dataGridView_0.Rows[i].Cells[1].Value.ToString()))
				{
					Holes[i].Position.X = Convert.ToDouble(dataGridView_0.Rows[i].Cells[1].Value.ToString());
				}
				if (buNumeric5.IsNumeric(dataGridView_0.Rows[i].Cells[2].Value.ToString()))
				{
					Holes[i].Position.Y = Convert.ToDouble(dataGridView_0.Rows[i].Cells[2].Value.ToString());
				}
				if (buNumeric5.IsNumeric(dataGridView_0.Rows[i].Cells[3].Value.ToString()))
				{
					Holes[i].Position.Z = Convert.ToDouble(dataGridView_0.Rows[i].Cells[3].Value.ToString());
				}
				if (buNumeric5.IsNumeric(dataGridView_0.Rows[i].Cells[4].Value.ToString()))
				{
					Holes[i].Diameter = Convert.ToDouble(dataGridView_0.Rows[i].Cells[4].Value.ToString());
				}
				if (buNumeric5.IsNumeric(dataGridView_0.Rows[i].Cells[5].Value.ToString()))
				{
					Holes[i].Depth = Convert.ToDouble(dataGridView_0.Rows[i].Cells[5].Value.ToString());
				}
			}
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_add.Name)
		{
			buGroup_0.Visible = true;
		}
		if (control.Name == btn_closehole.Name)
		{
			buGroup_0.Visible = false;
		}
		if (control.Name == btn_addhole.Name)
		{
			DiameterDepthPoint diameterDepthPoint = new DiameterDepthPoint();
			diameterDepthPoint.Diameter = spn_dia.Value;
			diameterDepthPoint.Depth = spn_depth.Value;
			diameterDepthPoint.Position.X = spn_x.Value;
			diameterDepthPoint.Position.Y = spn_y.Value;
			diameterDepthPoint.Position.Z = spn_z.Value;
			Holes.Add(diameterDepthPoint);
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			int count = Holes.Count;
			double double_ = diameterDepthPoint.Position.X;
			double double_2 = diameterDepthPoint.Position.Y;
			double z = diameterDepthPoint.Position.Z;
			double diameter = diameterDepthPoint.Diameter;
			double depth = diameterDepthPoint.Depth;
			rows.Add(Class186.smethod_467(double_, z, double_2, diameter, count, this, depth));
			buGroup_0.Visible = false;
		}
		if (control.Name == btn_remove.Name && ((SelectedRowSheet >= 0) & (SelectedRowSheet <= dataGridView_0.Rows.Count - 1)))
		{
			dataGridView_0.Rows.RemoveAt(SelectedRowSheet);
		}
		if (control.Name == btn_delete.Name)
		{
			dataGridView_0.Rows.Clear();
		}
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
	}

	internal void method_6(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
