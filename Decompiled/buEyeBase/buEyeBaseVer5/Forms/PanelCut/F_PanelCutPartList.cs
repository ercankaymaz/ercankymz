using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.Viewer;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.PanelCut;

public class F_PanelCutPartList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	private Timer timer_0 = new Timer();

	private int int_0 = -1;

	private int int_1 = -1;

	private Design design_0 = null;

	public buNestingVar Settings = new buNestingVar();

	public string AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Part CSV File (*.csv)|*.csv";

	public string SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";

	public bool AddPartFromFileExtenderAsCsvType = false;

	public bool SendToCad = false;

	public int AddPartFromFileExtensionIndex = 1;

	public int SaveFileExtensionIndex = 1;

	public string AddPartFromFileFolder = Application.StartupPath;

	public string SaveFileFolder = Application.StartupPath;

	public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;

	public nestPartRotateType PartRotationDefault = nestPartRotateType.Increment90;

	public List<buNestingPart> Parts = new List<buNestingPart>();

	public List<Entity> SendToCadEntities = new List<Entity>();

	public static List<string> Captions = new List<string>();

	public static List<string> CaptionGrid = new List<string>();

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal Panel panel_0;

	internal ImageList imageList_0;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripSeparator toolStripSeparator_0;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal TabPage tabPage_0;

	internal Label label_0;

	internal TextBox textBox_0;

	internal Label label_1;

	internal TextBox textBox_1;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal DataGridView dataGridView_0;

	internal ContextMenuStrip contextMenuStrip_1;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal ToolStripSeparator toolStripSeparator_1;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Panel panel_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal ToolStripMenuItem toolStripMenuItem_6;

	public CheckBox chk_preview;

	internal ToolStripSeparator toolStripSeparator_2;

	internal ToolStripMenuItem toolStripMenuItem_7;

	internal Label label_2;

	internal Panel panel_2;

	internal ToolStripSeparator toolStripSeparator_3;

	internal Panel panel_3;

	internal NumericUpDown numericUpDown_0;

	internal CheckBox checkBox_0;

	internal NumericUpDown numericUpDown_1;

	internal CheckBox checkBox_1;

	internal NumericUpDown numericUpDown_2;

	internal CheckBox checkBox_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal CheckBox checkBox_3;

	internal TextBox textBox_2;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	internal Label label_6;

	internal NumericUpDown numericUpDown_5;

	public F_PanelCutPartList()
	{
		buFunctions.CultureSettings();
		Class186.smethod_795(this);
	}

	public void Init(int SelectedTab)
	{
		PropertiesForm.Inited = false;
		SendToCad = false;
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			panel_2.Controls.Add(design_0);
		}
		AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
		if (AddPartFromFileExtenderAsCsvType)
		{
			AddPartFromFileExtender += "|Csv Files (*.csv)|*.csv";
		}
		string headerText = "No";
		string headerText2 = "Sel";
		string headerText3 = "Name";
		string headerText4 = "Preview";
		string headerText5 = "Width";
		string headerText6 = "Height";
		string headerText7 = "Count";
		string headerText8 = "Remain";
		string headerText9 = "Precut Width";
		string headerText10 = "Precut Height";
		string headerText11 = "Left Edge";
		string headerText12 = "Right Edge";
		string headerText13 = "Top Edge";
		string headerText14 = "Bottom Edge";
		string headerText15 = "Nested";
		if (Captions.Count > 46)
		{
			headerText = Captions[35];
			headerText2 = Captions[36];
			headerText3 = Captions[37];
			headerText4 = Captions[38];
			headerText5 = Captions[39];
			headerText6 = Captions[40];
			headerText7 = Captions[41];
			_ = Captions[46];
			headerText8 = Captions[43];
			headerText9 = Captions[47];
			headerText10 = Captions[48];
			headerText11 = Captions[51];
			headerText12 = Captions[50];
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
			dataGridViewColumn3.Width = 200;
			dataGridViewColumn3.HeaderText = headerText3;
			dataGridViewColumn3.Name = "Name";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = Settings.Draw.GridPartSheetPreviewWidth;
			dataGridViewColumn4.HeaderText = headerText4;
			dataGridViewColumn4.Name = "Image";
			dataGridViewColumn4.ReadOnly = true;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.CellTemplate = new DataGridViewImageCell();
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 100;
			dataGridViewColumn5.HeaderText = headerText5;
			dataGridViewColumn5.Name = "Width";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn6.Width = 100;
			dataGridViewColumn6.HeaderText = headerText6;
			dataGridViewColumn6.Name = "Height";
			dataGridViewColumn6.ReadOnly = false;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn7.Width = 80;
			dataGridViewColumn7.HeaderText = headerText7;
			dataGridViewColumn7.Name = "Count";
			dataGridViewColumn7.ReadOnly = false;
			dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn8.Width = 100;
			dataGridViewColumn8.HeaderText = headerText15;
			dataGridViewColumn8.Name = "Nested";
			dataGridViewColumn8.ReadOnly = true;
			dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn8);
			DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
			dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn9.Width = 100;
			dataGridViewColumn9.HeaderText = headerText8;
			dataGridViewColumn9.Name = "Remain";
			dataGridViewColumn9.ReadOnly = true;
			dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn9.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn9);
			DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
			dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn10.Width = 100;
			dataGridViewColumn10.HeaderText = headerText9;
			dataGridViewColumn10.Name = "PreCut Width";
			dataGridViewColumn10.ReadOnly = true;
			dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn10.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn10);
			DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
			dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn11.Width = 100;
			dataGridViewColumn11.HeaderText = headerText10;
			dataGridViewColumn11.Name = "Precut Height";
			dataGridViewColumn11.ReadOnly = true;
			dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn11.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn11);
			DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
			dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn12.Width = 80;
			dataGridViewColumn12.HeaderText = headerText11;
			dataGridViewColumn12.Name = "Left Edge";
			dataGridViewColumn12.ReadOnly = true;
			dataGridViewColumn12.Visible = true;
			dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn12.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn12);
			DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
			dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn13.Width = 80;
			dataGridViewColumn13.HeaderText = headerText12;
			dataGridViewColumn13.Name = "Right Edge";
			dataGridViewColumn13.ReadOnly = false;
			dataGridViewColumn13.Visible = true;
			dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn13.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn13);
			DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
			dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn14.Width = 80;
			dataGridViewColumn14.HeaderText = headerText13;
			dataGridViewColumn14.Name = "Top Edge";
			dataGridViewColumn14.ReadOnly = false;
			dataGridViewColumn14.Visible = true;
			dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn14.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn14);
			DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
			dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn15.Width = 80;
			dataGridViewColumn15.HeaderText = headerText14;
			dataGridViewColumn15.Name = "Bottom Edge";
			dataGridViewColumn15.ReadOnly = false;
			dataGridViewColumn15.Visible = true;
			dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn15.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn15);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		SendToCadEntities.Clear();
		SendToCadEntities = new List<Entity>();
		timer_0 = new Timer();
		method_1();
		if (!radioButton_2.Checked & !radioButton_0.Checked & !radioButton_1.Checked)
		{
			radioButton_1.Checked = true;
		}
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
			if (Captions.Count >= 100)
			{
				Text = Captions[0];
				tabPage_0.Text = Captions[2];
				label_2.Text = Captions[2];
				button_3.Text = Captions[7];
				button_2.Text = Captions[8];
				button_1.Text = Captions[10];
				button_0.Text = Captions[11];
				radioButton_2.Text = Captions[12];
				radioButton_1.Text = Captions[13];
				radioButton_0.Text = Captions[14];
				label_1.Text = Captions[15];
				label_0.Text = Captions[16];
				chk_preview.Text = Captions[17];
				button_5.Text = Captions[18];
				button_4.Text = Captions[19];
				button_7.Text = Captions[20];
				button_6.Text = Captions[21];
				toolStripMenuItem_3.Text = Captions[22];
				toolStripMenuItem_4.Text = Captions[23];
				toolStripMenuItem_5.Text = Captions[29];
				toolStripMenuItem_6.Text = Captions[31];
				toolStripMenuItem_0.Text = Captions[32];
				toolStripMenuItem_1.Text = Captions[52];
				toolStripMenuItem_2.Text = Captions[28];
				toolStripMenuItem_7.Text = Captions[29];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	private void method_1()
	{
		timer_0.Enabled = false;
		dataGridView_0.Rows.Clear();
		for (int i = 0; i <= Parts.Count - 1; i++)
		{
			buNestingPart buNestingPart2 = new buNestingPart(Parts[i]);
			Image Img = new Bitmap(100, 100);
			string string_ = "";
			string string_2 = "";
			string string_3 = "";
			string string_4 = "";
			if (buNestingPart2.EdgeLeft)
			{
				string_ = buNestingPart2.EdgeLeftThickness.ToString();
			}
			if (buNestingPart2.EdgeRight)
			{
				string_2 = buNestingPart2.EdgeRightThickness.ToString();
			}
			if (buNestingPart2.EdgeTop)
			{
				string_3 = buNestingPart2.EdgeTopThickness.ToString();
			}
			if (buNestingPart2.EdgeBottom)
			{
				string_4 = buNestingPart2.EdgeBottomThickness.ToString();
			}
			PartPointsToImage(Parts[i], Settings.Draw.GridPartSheetPreviewWidth, Settings.Draw.GridPartSheetHeight, ref Img);
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			bool enable = buNestingPart2.Enable;
			string name = buNestingPart2.PartData.Name;
			double double_ = buNestingPart2.PartData.Width;
			double double_2 = buNestingPart2.PartData.Height;
			int quantity = buNestingPart2.PartData.Quantity;
			int nested = buNestingPart2.Nested;
			int remain = buNestingPart2.Remain;
			double precutWidth = buNestingPart2.PrecutWidth;
			double precutHeight = buNestingPart2.PrecutHeight;
			rows.Add(Class186.smethod_306(remain, quantity, precutHeight, precutWidth, this, string_4, string_2, double_, Img, double_2, string_3, string_, enable, nested, name, i + 1));
			DataGridViewRow dataGridViewRow = dataGridView_0.Rows[i];
			dataGridView_0.Rows[i].Height = Settings.Draw.GridPartSheetHeight;
			dataGridViewRow.DefaultCellStyle.ForeColor = Color.Black;
			if (buNestingPart2.Remain <= 0)
			{
				dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
			}
		}
		PropertiesForm.Inited = true;
		method_6();
	}

	internal void method_2(object sender, EventArgs e)
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
		if (text == button_3.Name)
		{
			F_NestRectPartAdd f_NestRectPartAdd = new F_NestRectPartAdd();
			f_NestRectPartAdd.ShowItemNo = Settings.Draw.ShowPartItemNoColumb;
			f_NestRectPartAdd.FormCloseMode = FormCloseModeType.Dispose;
			f_NestRectPartAdd.Init();
			f_NestRectPartAdd.StartPosition = FormStartPosition.CenterParent;
			f_NestRectPartAdd.ShowDialog();
			if (f_NestRectPartAdd.Result == DialogResult.OK)
			{
				buNestingPart buNestingPart2 = new buNestingPart(f_NestRectPartAdd.Part);
				buCall.buNestingCalc_0.GetAvailableNestingPartID(Parts, ref buNestingPart2.ID);
				Parts.Add(buNestingPart2);
				Image Img = null;
				string string_ = "";
				string string_2 = "";
				string string_3 = "";
				string string_4 = "";
				if (buNestingPart2.EdgeLeft)
				{
					string_ = buNestingPart2.EdgeLeftThickness.ToString();
				}
				if (buNestingPart2.EdgeRight)
				{
					string_2 = buNestingPart2.EdgeRightThickness.ToString();
				}
				if (buNestingPart2.EdgeTop)
				{
					string_3 = buNestingPart2.EdgeTopThickness.ToString();
				}
				if (buNestingPart2.EdgeBottom)
				{
					string_4 = buNestingPart2.EdgeBottomThickness.ToString();
				}
				PartPointsToImage(f_NestRectPartAdd.Part, Settings.Draw.GridPartSheetPreviewWidth, Settings.Draw.GridPartSheetHeight, ref Img);
				DataGridViewRowCollection rows = dataGridView_0.Rows;
				int count = Parts.Count;
				bool enable = f_NestRectPartAdd.Part.Enable;
				string name = f_NestRectPartAdd.Part.PartData.Name;
				double double_ = f_NestRectPartAdd.Part.PartData.Width;
				double double_2 = f_NestRectPartAdd.Part.PartData.Height;
				int quantity = f_NestRectPartAdd.Part.PartData.Quantity;
				int nested = f_NestRectPartAdd.Part.Nested;
				int remain = f_NestRectPartAdd.Part.Remain;
				double precutWidth = f_NestRectPartAdd.Part.PrecutWidth;
				double precutHeight = f_NestRectPartAdd.Part.PrecutHeight;
				rows.Add(Class186.smethod_306(remain, quantity, precutHeight, precutWidth, this, string_4, string_2, double_, Img, double_2, string_3, string_, enable, nested, name, count));
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = Settings.Draw.GridPartSheetHeight;
			}
		}
		if (!(text == button_2.Name))
		{
			if (text == button_1.Name && ((int_1 >= 0) & (int_1 <= Parts.Count - 1)))
			{
				dataGridView_0.Rows[int_1].Cells[7].Value = 0;
				dataGridView_0.Rows[int_1].Cells[8].Value = Parts[int_1].PartData.Quantity;
				Parts[int_1].Nested = 0;
				Parts[int_1].Remain = Parts[int_1].PartData.Quantity;
				dataGridView_0.Rows[int_1].DefaultCellStyle.ForeColor = Color.Black;
			}
			if (text == button_0.Name)
			{
				for (int i = 0; i <= Parts.Count - 1; i++)
				{
					dataGridView_0.Rows[i].Cells[7].Value = 0;
					dataGridView_0.Rows[i].Cells[8].Value = Parts[i].PartData.Quantity;
					Parts[i].Nested = 0;
					Parts[i].Remain = Parts[i].PartData.Quantity;
					dataGridView_0.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
				}
			}
			if (text == toolStripMenuItem_6.Name)
			{
				SendToCadEntities.Clear();
				double num = 0.0;
				double dx = 0.0;
				double num2 = double.MinValue;
				int num3 = 0;
				int num4 = 0;
				for (int j = 0; j <= Parts.Count - 1; j++)
				{
					if (Parts[j].Enable && Parts[j].PartData.Width > num2)
					{
						num2 = Parts[j].PartData.Width;
					}
				}
				for (int k = 0; k <= Parts.Count - 1; k++)
				{
					if (Parts[k].Enable)
					{
						List<Entity> copiedEntity = new List<Entity>();
						buEntity.Copy(Parts[k].EntitiesGroup, ref copiedEntity);
						for (int l = 0; l <= copiedEntity.Count - 1; l++)
						{
							copiedEntity[l].Translate(dx, num);
							SendToCadEntities.Add(copiedEntity[l]);
						}
						num = num + Parts[k].PartData.Height + 20.0;
						num3++;
						if (num3 >= 10)
						{
							num3 = 0;
							num4++;
							num = 0.0;
							dx = num2 * (double)num4;
						}
					}
				}
				if (SendToCadEntities.Count > 0)
				{
					SendToCad = true;
					base.Visible = false;
					PropertiesForm.Result = DialogResult.OK;
				}
			}
			if (text == toolStripMenuItem_3.Name)
			{
				for (int num5 = dataGridView_0.Rows.Count - 1; num5 >= 0; num5--)
				{
					dataGridView_0.Rows[num5].Cells[1].Value = true;
					Parts[num5].Enable = true;
				}
			}
			if (text == toolStripMenuItem_4.Name)
			{
				for (int num6 = dataGridView_0.Rows.Count - 1; num6 >= 0; num6--)
				{
					dataGridView_0.Rows[num6].Cells[1].Value = false;
					Parts[num6].Enable = false;
				}
			}
			if (text == toolStripMenuItem_5.Name && Parts.Count > 0)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = SaveFileFolder;
				saveFileDialog.Filter = SaveFileExtender;
				saveFileDialog.FilterIndex = SaveFileExtensionIndex;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
					SaveFileFolder = buFile5.GetPath(saveFileDialog.FileName);
					if (fileInfo.Extension == ".dxf")
					{
						for (int m = 0; m <= Parts.Count - 1; m++)
						{
							if (Parts[m].Enable)
							{
								string text2 = Parts[m].PartData.Name.Trim();
								if (text2.Length == 0)
								{
									text2 = "Part" + (m + 1);
								}
								string fileName = buFile5.GetPath(saveFileDialog.FileName) + "\\" + buFile5.getFileNameWithoutExtension(saveFileDialog.FileName) + "_" + (m + 1) + "_" + text2 + "_" + Parts[m].PartData.Quantity + fileInfo.Extension;
								List<Entity> copiedEntity2 = new List<Entity>();
								buEntity.Copy(Parts[m].EntitiesGroup, ref copiedEntity2);
								buFile5.SaveDxfDwg(copiedEntity2, fileName);
							}
						}
					}
				}
			}
			if (text == button_4.Name)
			{
				SaveFileDialog saveFileDialog2 = new SaveFileDialog();
				saveFileDialog2.InitialDirectory = SaveFileFolder;
				saveFileDialog2.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
				saveFileDialog2.FilterIndex = 1;
				if (saveFileDialog2.ShowDialog() == DialogResult.OK)
				{
					SaveFileFolder = buFile5.GetPath(saveFileDialog2.FileName);
					buFile5.bunesting bunesting = new buFile5.bunesting();
					bunesting.SaveNesting(saveFileDialog2.FileName, Parts, new List<buNestingSheet>(), Settings);
				}
			}
			if (text == button_5.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = SaveFileFolder;
				openFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					SaveFileFolder = buFile5.GetPath(openFileDialog.FileName);
					buFile5.bunesting bunesting2 = new buFile5.bunesting();
					List<buNestingSheet> Sheets = new List<buNestingSheet>();
					bunesting2.OpenNesting(openFileDialog.FileName, ref Parts, ref Sheets);
					Init(tabControl_0.SelectedIndex);
				}
			}
			if (text == button_6.Name)
			{
				base.Visible = false;
				PropertiesForm.Result = DialogResult.Cancel;
			}
			if (text == button_7.Name)
			{
				base.Visible = false;
				PropertiesForm.Result = DialogResult.OK;
			}
			return;
		}
		if (radioButton_2.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
		{
			Parts.Clear();
			dataGridView_0.Rows.Clear();
		}
		if (radioButton_0.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
		{
			for (int num7 = dataGridView_0.Rows.Count - 1; num7 >= 0; num7--)
			{
				if (Convert.ToBoolean(dataGridView_0.Rows[num7].Cells[1].Value))
				{
					dataGridView_0.Rows.RemoveAt(num7);
					Parts.RemoveAt(num7);
				}
			}
		}
		if (radioButton_1.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes && ((int_1 >= 0) & (int_1 <= Parts.Count - 1)))
		{
			dataGridView_0.Rows.RemoveAt(int_1);
			Parts.RemoveAt(int_1);
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= Parts.Count - 1))
		{
			int_1 = e.RowIndex;
			buCall.buVector5_0.DrawPart(Parts[int_1], Settings, ref design_0);
			if ((int_1 >= 0) & (int_1 <= Parts.Count - 1))
			{
				PropertiesForm.Inited = false;
				double num = 0.0;
				double num2 = 0.0;
				List<Point3D> copiedPoint = new List<Point3D>();
				num += Parts[int_1].PartData.Width / 1000.0 * (Parts[int_1].PartData.Height / 1000.0) * Convert.ToDouble(Parts[int_1].PartData.Quantity);
				buVector5.Copy(Parts[int_1].EntitiesGroup.Outside.Points, ref copiedPoint);
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
				_ = Parts[int_1].Area;
				double num3 = buCall.buVector5_0.PolygonArea(copiedPoint, Plane.XY);
				num2 += num3 / 1000000.0 * Convert.ToDouble(Parts[int_1].PartData.Quantity);
				textBox_1.Text = num.ToString("f2");
				textBox_0.Text = num2.ToString("f2");
				textBox_2.Text = Parts[int_1].Referance;
				numericUpDown_5.Value = (decimal)Parts[int_1].PrecutHeight;
				numericUpDown_4.Value = (decimal)Parts[int_1].PrecutWidth;
				numericUpDown_0.Value = (decimal)Parts[int_1].EdgeBottomThickness;
				numericUpDown_1.Value = (decimal)Parts[int_1].EdgeTopThickness;
				numericUpDown_3.Value = (decimal)Parts[int_1].EdgeLeftThickness;
				numericUpDown_2.Value = (decimal)Parts[int_1].EdgeRightThickness;
				checkBox_0.Checked = Parts[int_1].EdgeBottom;
				checkBox_1.Checked = Parts[int_1].EdgeTop;
				checkBox_3.Checked = Parts[int_1].EdgeLeft;
				checkBox_2.Checked = Parts[int_1].EdgeRight;
				PropertiesForm.Inited = true;
			}
		}
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= Parts.Count - 1))
		{
			buNestingPartData value = new buNestingPartData(Parts[e.RowIndex].PartData);
			new buNestingPart();
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.Width = 300;
			f_ClassViewerDialog.Value = value;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				Parts[e.RowIndex].PartData = new buNestingPartData((buNestingPartData)f_ClassViewerDialog.Value);
				Parts[e.RowIndex].Remain = Parts[e.RowIndex].PartData.Quantity - Parts[e.RowIndex].Nested;
				if (Parts[e.RowIndex].Type == nestMaterialType.Rectangle)
				{
					buNestingPart Part = Parts[e.RowIndex];
					buCall.buNestingCalc_0.PartRectangle(Part.PartData.Width, Part.PartData.Height, ref Part);
				}
				method_1();
				buCall.buVector5_0.DrawPart(Parts[e.RowIndex], Settings, ref design_0);
				dataGridView_0.CurrentCell = dataGridView_0.Rows[e.RowIndex].Cells[1];
			}
		}
		method_6();
	}

	internal void method_5(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
		{
			if ((e.ColumnIndex == 1) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].Enable = Convert.ToBoolean(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 2) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Name = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 4) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Width = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
				buNestingPart Part = Parts[e.RowIndex];
				buCall.buNestingCalc_0.PartRectangle(Part.PartData.Width, Part.PartData.Height, ref Part);
				buCall.buVector5_0.DrawPart(Parts[e.RowIndex], Settings, ref design_0);
			}
			if ((e.ColumnIndex == 5) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Height = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
				buNestingPart Part2 = Parts[e.RowIndex];
				buCall.buNestingCalc_0.PartRectangle(Part2.PartData.Width, Part2.PartData.Height, ref Part2);
				buCall.buVector5_0.DrawPart(Parts[e.RowIndex], Settings, ref design_0);
			}
			if ((e.ColumnIndex == 6) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Quantity = Convert.ToInt32(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
				Parts[e.RowIndex].Remain = Parts[e.RowIndex].PartData.Quantity - Parts[e.RowIndex].Nested;
			}
			if ((e.ColumnIndex == 9) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Priority = Convert.ToInt32(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 12) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.ItemNo = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 13) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Other = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 14) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Aux = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
		}
		method_6();
	}

	public void AddPartFromEntities(List<eEntities> Entities)
	{
	}

	public void AddPartFromCsvFile(nestCsvPartImportType Mode, string FileName)
	{
		if (Mode != nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(FileName);
		List<string> StringList = new List<string>();
		if (!fileInfo.Exists)
		{
			return;
		}
		buFile5.OpenFromFile(FileName, ref StringList);
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			string[] array = null;
			array = StringList[i].Split(';');
			buNestingPart buNestingPart2 = new buNestingPart();
			new List<Point3D>();
			if (array == null || array.Length < 3 || !(buNumeric5.IsNumeric(array[0].Trim()) & buNumeric5.IsNumeric(array[1].Trim()) & buNumeric5.IsNumeric(array[2].Trim())))
			{
				continue;
			}
			buNestingPart2 = new buNestingPart();
			buNestingPart2.PartData.Width = Convert.ToDouble(array[0].Trim());
			buNestingPart2.PartData.Height = Convert.ToDouble(array[1].Trim());
			buNestingPart2.PartData.Quantity = Convert.ToInt32(array[2].Trim());
			buNestingPart2.Remain = buNestingPart2.PartData.Quantity;
			buNestingPart2.PartData.Priority = 10;
			buNestingPart2.PartData.Name = "Part-" + (i + 1);
			buNestingPart2.PartData.Rotation = nestPartRotateType.Increment90;
			buNestingPart2.Type = nestMaterialType.Rectangle;
			buCall.buNestingCalc_0.PartRectangle(buNestingPart2.PartData.Width, buNestingPart2.PartData.Height, ref buNestingPart2);
			if (buNestingPart2.PartData.Quantity > 0 && ((buNestingPart2.PartData.Width > 0.0) & (buNestingPart2.PartData.Height > 0.0)))
			{
				buNestingPart buNestingPart3 = new buNestingPart(buNestingPart2);
				buCall.buNestingCalc_0.GetAvailableNestingPartID(Parts, ref buNestingPart3.ID);
				Parts.Add(buNestingPart3);
				Image Img = null;
				string string_ = "";
				string string_2 = "";
				string string_3 = "";
				string string_4 = "";
				if (buNestingPart3.EdgeLeft)
				{
					string_ = buNestingPart3.EdgeLeftThickness.ToString();
				}
				if (buNestingPart3.EdgeRight)
				{
					string_2 = buNestingPart3.EdgeRightThickness.ToString();
				}
				if (buNestingPart3.EdgeLeft)
				{
					string_3 = buNestingPart3.EdgeTopThickness.ToString();
				}
				if (buNestingPart3.EdgeLeft)
				{
					string_4 = buNestingPart3.EdgeBottomThickness.ToString();
				}
				PartPointsToImage(buNestingPart2, Settings.Draw.GridPartSheetPreviewWidth, Settings.Draw.GridPartSheetHeight, ref Img);
				DataGridViewRowCollection rows = dataGridView_0.Rows;
				int count = Parts.Count;
				bool enable = buNestingPart2.Enable;
				string name = buNestingPart2.PartData.Name;
				double double_ = buNestingPart2.PartData.Width;
				double double_2 = buNestingPart2.PartData.Height;
				int quantity = buNestingPart2.PartData.Quantity;
				int nested = buNestingPart2.Nested;
				int remain = buNestingPart2.Remain;
				double precutWidth = buNestingPart2.PrecutWidth;
				double precutHeight = buNestingPart2.PrecutHeight;
				rows.Add(Class186.smethod_306(remain, quantity, precutHeight, precutWidth, this, string_4, string_2, double_, Img, double_2, string_3, string_, enable, nested, name, count));
			}
		}
	}

	public void PartPointsToImage(buNestingPart Part, int Width, int Height, ref Image Img)
	{
		buViewer buViewer2 = new buViewer();
		buViewer2.Width = Width;
		buViewer2.Height = Height;
		List<eEntities> copiedEntity = new List<eEntities>();
		buConversion5.buEntityGroupToEEntities(Part.EntitiesGroup, ref copiedEntity);
		buViewer2.Entities.Clear();
		buViewer2.Entities.AddRange(copiedEntity);
		buViewer2.DrawEntities();
		buViewer2.ZoomFit();
		buViewer2.ZoomOut();
		Img = buViewer2.Bmp;
	}

	private void method_6()
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i <= Parts.Count - 1; i++)
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			if (Parts[i].EdgeLeft)
			{
				value = Parts[i].EdgeLeftThickness.ToString();
			}
			if (Parts[i].EdgeRight)
			{
				value2 = Parts[i].EdgeRightThickness.ToString();
			}
			if (Parts[i].EdgeTop)
			{
				value3 = Parts[i].EdgeTopThickness.ToString();
			}
			if (Parts[i].EdgeBottom)
			{
				value4 = Parts[i].EdgeBottomThickness.ToString();
			}
			dataGridView_0.Rows[i].Cells[1].Value = Parts[i].Enable;
			dataGridView_0.Rows[i].Cells[2].Value = Parts[i].Referance;
			dataGridView_0.Rows[i].Cells[4].Value = Parts[i].PartData.Width;
			dataGridView_0.Rows[i].Cells[5].Value = Parts[i].PartData.Height;
			dataGridView_0.Rows[i].Cells[6].Value = Parts[i].PartData.Quantity;
			dataGridView_0.Rows[i].Cells[7].Value = Parts[i].Nested;
			dataGridView_0.Rows[i].Cells[8].Value = Parts[i].Remain;
			dataGridView_0.Rows[i].Cells[9].Value = Parts[i].PrecutWidth;
			dataGridView_0.Rows[i].Cells[10].Value = Parts[i].PrecutHeight;
			dataGridView_0.Rows[i].Cells[11].Value = value;
			dataGridView_0.Rows[i].Cells[12].Value = value2;
			dataGridView_0.Rows[i].Cells[13].Value = value3;
			dataGridView_0.Rows[i].Cells[14].Value = value4;
			if (Parts[i].Enable)
			{
				new List<Point3D>();
				num += Parts[i].PartData.Width / 1000.0 * (Parts[i].PartData.Height / 1000.0) * Convert.ToDouble(Parts[i].PartData.Quantity);
			}
			if (i <= dataGridView_0.Rows.Count - 1)
			{
				dataGridView_0.Rows[i].Cells[8].Value = Parts[i].Remain;
			}
		}
		textBox_1.Text = num.ToString("f2");
		textBox_0.Text = num2.ToString("f2");
	}

	internal void method_7(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if ((int_1 >= 0) & (int_1 <= Parts.Count - 1) & PropertiesForm.Inited)
		{
			if (control.Name == numericUpDown_5.Name)
			{
				Parts[int_1].PrecutHeight = (double)numericUpDown_5.Value;
			}
			if (control.Name == numericUpDown_4.Name)
			{
				Parts[int_1].PrecutWidth = (double)numericUpDown_4.Value;
			}
			if (control.Name == numericUpDown_0.Name)
			{
				Parts[int_1].EdgeBottomThickness = (double)numericUpDown_0.Value;
			}
			if (control.Name == numericUpDown_1.Name)
			{
				Parts[int_1].EdgeTopThickness = (double)numericUpDown_1.Value;
			}
			if (control.Name == numericUpDown_3.Name)
			{
				Parts[int_1].EdgeLeftThickness = (double)numericUpDown_3.Value;
			}
			if (control.Name == numericUpDown_2.Name)
			{
				Parts[int_1].EdgeRightThickness = (double)numericUpDown_2.Value;
			}
			method_6();
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if ((int_1 >= 0) & (int_1 <= Parts.Count - 1) & PropertiesForm.Inited)
		{
			if (control.Name == textBox_2.Name)
			{
				Parts[int_0].Referance = textBox_2.Text;
			}
			method_6();
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if ((int_1 >= 0) & (int_1 <= Parts.Count - 1) & PropertiesForm.Inited)
		{
			if (control.Name == checkBox_0.Name)
			{
				Parts[int_1].EdgeBottom = checkBox_0.Checked;
			}
			if (control.Name == checkBox_1.Name)
			{
				Parts[int_1].EdgeTop = checkBox_1.Checked;
			}
			if (control.Name == checkBox_3.Name)
			{
				Parts[int_1].EdgeLeft = checkBox_3.Checked;
			}
			if (control.Name == checkBox_2.Name)
			{
				Parts[int_1].EdgeRight = checkBox_2.Checked;
			}
			method_6();
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
