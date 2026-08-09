using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using ns71;

namespace buEyeBaseVer5.Forms.PanelCut;

public class F_PanelCutMaterials : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	internal Timer timer_0 = new Timer();

	private int int_0 = -1;

	private int int_1 = -1;

	public string AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";

	public string AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";

	public string SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";

	public bool AddPartFromFileExtenderAsCsvType = false;

	public bool SendToCad = false;

	public int AddPartFromFileExtensionIndex = 1;

	public int AddSheetFromFileExtensionIndex = 1;

	public int SaveFileExtensionIndex = 1;

	public string AddPartFromFileFolder = Application.StartupPath;

	public string AddSheetFromFileFolder = Application.StartupPath;

	public string SaveFileFolder = Application.StartupPath;

	public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode2_NameWidthHeightCount;

	public nestPartRotateType PartRotationDefault = nestPartRotateType.Increment90;

	public List<buNestingMaterials> Materails = new List<buNestingMaterials>();

	public List<Entity> SendToCadEntities = new List<Entity>();

	public static List<string> Captions = new List<string>();

	public static List<string> CaptionGrid = new List<string>();

	internal IContainer icontainer_0 = null;

	internal DataGridView dataGridView_0;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripSeparator toolStripSeparator_0;

	internal ToolStripSeparator toolStripSeparator_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal Button button_2;

	internal Button button_3;

	internal TextBox textBox_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Label label_3;

	internal TextBox textBox_1;

	public F_PanelCutMaterials()
	{
		buFunctions.CultureSettings();
		Class186.smethod_334(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		string headerText = "No";
		string headerText2 = "Sel";
		string headerText3 = "Material";
		string headerText4 = "Thickness";
		string headerText5 = "Explanation";
		string headerText6 = "Cost";
		if (Captions.Count <= 46)
		{
		}
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 40;
			dataGridViewColumn.HeaderText = headerText;
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 50;
			dataGridViewColumn2.HeaderText = headerText2;
			dataGridViewColumn2.Name = "Sel";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewCheckBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 150;
			dataGridViewColumn3.HeaderText = headerText3;
			dataGridViewColumn3.Name = "Material";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 50;
			dataGridViewColumn4.HeaderText = headerText4;
			dataGridViewColumn4.Name = "Thickness";
			dataGridViewColumn4.ReadOnly = true;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 150;
			dataGridViewColumn5.HeaderText = headerText5;
			dataGridViewColumn5.Name = "Exp";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn6.Width = 60;
			dataGridViewColumn6.HeaderText = headerText6;
			dataGridViewColumn6.Name = "Cost";
			dataGridViewColumn6.ReadOnly = false;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn6);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		timer_0 = new Timer();
		Class186.smethod_67(this);
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = false;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			base.Visible = false;
		}
	}

	public void LoadLanguage()
	{
		string callMethod = "NestSheetPart LoadLanguage";
		try
		{
			if (Captions.Count >= 33)
			{
				Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		string text = "";
		if ((sender.GetType() == typeof(Control)) | (sender.GetType() == typeof(Button)))
		{
			control = (Control)sender;
			text = control.Name;
		}
		if (sender.GetType() == typeof(ToolStripMenuItem))
		{
			text = ((ToolStripMenuItem)sender).Name;
		}
		if (text == button_1.Name)
		{
			buNestingMaterials buNestingMaterials2 = new buNestingMaterials();
			buNestingMaterials2.Cost = (double)numericUpDown_1.Value;
			buNestingMaterials2.Thickness = (double)numericUpDown_0.Value;
			buNestingMaterials2.Material = textBox_0.Text;
			buNestingMaterials2.Explanation = textBox_1.Text;
			buNestingMaterials2.Enable = true;
			Materails.Add(buNestingMaterials2);
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			int count = Materails.Count;
			bool enable = buNestingMaterials2.Enable;
			string material = buNestingMaterials2.Material;
			double thickness = buNestingMaterials2.Thickness;
			string explanation = buNestingMaterials2.Explanation;
			double cost = buNestingMaterials2.Cost;
			rows.Add(Class186.smethod_151(thickness, enable, explanation, cost, count, material, this));
		}
		if (!(text == button_0.Name))
		{
			if (text == toolStripMenuItem_0.Name)
			{
				for (int num = dataGridView_0.Rows.Count - 1; num >= 0; num--)
				{
					dataGridView_0.Rows[num].Cells[1].Value = true;
					Materails[num].Enable = true;
				}
			}
			if (text == toolStripMenuItem_1.Name)
			{
				for (int num2 = dataGridView_0.Rows.Count - 1; num2 >= 0; num2--)
				{
					dataGridView_0.Rows[num2].Cells[1].Value = false;
					Materails[num2].Enable = false;
				}
			}
			if (text == toolStripMenuItem_3.Name && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
			{
				Materails.Clear();
				dataGridView_0.Rows.Clear();
			}
			if (text == toolStripMenuItem_4.Name && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
			{
				for (int num3 = dataGridView_0.Rows.Count - 1; num3 >= 0; num3--)
				{
					if (Convert.ToBoolean(dataGridView_0.Rows[num3].Cells[1].Value))
					{
						dataGridView_0.Rows.RemoveAt(num3);
						Materails.RemoveAt(num3);
					}
				}
			}
			if (text == toolStripMenuItem_2.Name)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = SaveFileFolder;
				saveFileDialog.Filter = "Nesting Material Files (*.bunestmat)|*.bunestmat";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					SaveFileFolder = buFile5.GetPath(saveFileDialog.FileName);
					buFile5.bunesting bunesting = new buFile5.bunesting();
					bunesting.SaveNestingMaterials(saveFileDialog.FileName, Materails);
				}
			}
			if (text == toolStripMenuItem_5.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = SaveFileFolder;
				openFileDialog.Filter = "Nesting Material Files (*.bunestmat)|*.bunestmat";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					SaveFileFolder = buFile5.GetPath(openFileDialog.FileName);
					buFile5.bunesting bunesting2 = new buFile5.bunesting();
					bunesting2.OpenNestingMaterials(openFileDialog.FileName, ref Materails);
					Init();
				}
			}
			if (text == button_3.Name)
			{
				base.Visible = false;
				PropertiesForm.Result = DialogResult.Cancel;
			}
			if (text == button_2.Name)
			{
				base.Visible = false;
				PropertiesForm.Result = DialogResult.OK;
			}
		}
		else if (buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
		{
			dataGridView_0.Rows.RemoveAt(int_0);
			Materails.RemoveAt(int_0);
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= Materails.Count - 1))
		{
			textBox_0.Text = dataGridView_0.Rows[e.RowIndex].Cells[2].Value.ToString();
			numericUpDown_0.Value = (decimal)Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[3].Value.ToString());
			textBox_1.Text = dataGridView_0.Rows[e.RowIndex].Cells[4].Value.ToString();
			numericUpDown_1.Value = (decimal)Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[5].Value.ToString());
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
		{
			if ((e.ColumnIndex == 1) & (e.RowIndex <= Materails.Count - 1))
			{
				Materails[e.RowIndex].Enable = Convert.ToBoolean(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 2) & (e.RowIndex <= Materails.Count - 1))
			{
				Materails[e.RowIndex].Material = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 3) & (e.RowIndex <= Materails.Count - 1))
			{
				Materails[e.RowIndex].Thickness = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 4) & (e.RowIndex <= Materails.Count - 1))
			{
				Materails[e.RowIndex].Explanation = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 5) & (e.RowIndex <= Materails.Count - 1))
			{
				Materails[e.RowIndex].Cost = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
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
