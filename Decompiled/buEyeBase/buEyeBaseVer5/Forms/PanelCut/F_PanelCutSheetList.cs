using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Viewer;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.PanelCut;

public class F_PanelCutSheetList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	internal Timer timer_0 = new Timer();

	private int int_0 = -1;

	private int int_1 = -1;

	private Design design_0 = null;

	public buNestingVar Settings = new buNestingVar();

	public string AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Part CSV File (*.csv)|*.csv";

	public string AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Sheet CSV File (*.csv)|*.csv";

	public string SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";

	public bool AddPartFromFileExtenderAsCsvType = false;

	public bool SendToCad = false;

	public int AddSheetFromFileExtensionIndex = 1;

	public int SaveFileExtensionIndex = 1;

	public string AddSheetFromFileFolder = Application.StartupPath;

	public string SaveFileFolder = Application.StartupPath;

	public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;

	public nestPartRotateType PartRotationDefault = nestPartRotateType.Increment90;

	public List<buNestingSheet> Sheets = new List<buNestingSheet>();

	public List<Entity> SendToCadEntities = new List<Entity>();

	public static List<string> Captions = new List<string>();

	public static List<string> CaptionGrid = new List<string>();

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal DataGridView dataGridView_0;

	internal Panel panel_0;

	internal Label label_0;

	internal TextBox textBox_0;

	internal Label label_1;

	internal TextBox textBox_1;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripSeparator toolStripSeparator_0;

	internal ToolStripMenuItem toolStripMenuItem_2;

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

	internal TextBox textBox_2;

	internal Label label_3;

	internal TextBox textBox_3;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_0;

	internal Label label_6;

	internal NumericUpDown numericUpDown_1;

	public F_PanelCutSheetList()
	{
		buFunctions.CultureSettings();
		Class186.smethod_327(this);
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
		if (Settings.MaterailSettings.UseSmallAreaFirst)
		{
			buCall.buNestingCalc_0.SortNestingMaterialFromSmallToBig(FromLowerToBigger: true, ref Sheets);
		}
		AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
		if (AddPartFromFileExtenderAsCsvType)
		{
			AddPartFromFileExtender += "|Csv Files (*.csv)|*.csv";
		}
		AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf";
		string headerText = "No";
		string headerText2 = "Sel";
		string headerText3 = "Referance";
		string headerText4 = "Preview";
		string headerText5 = "Width";
		string headerText6 = "Height";
		string headerText7 = "Thickness";
		string headerText8 = "Count";
		string headerText9 = "Used";
		string headerText10 = "Remain";
		string headerText11 = "TrimWidth";
		string headerText12 = "TrimHeight";
		if (Captions.Count <= 100)
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
			dataGridViewColumn7.Name = "Thickness";
			dataGridViewColumn7.ReadOnly = false;
			dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn8.Width = 80;
			dataGridViewColumn8.HeaderText = headerText8;
			dataGridViewColumn8.Name = "Count";
			dataGridViewColumn8.ReadOnly = false;
			dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn8);
			DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
			dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn9.Width = 80;
			dataGridViewColumn9.HeaderText = headerText9;
			dataGridViewColumn9.Name = "Used";
			dataGridViewColumn9.ReadOnly = true;
			dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn9.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn9);
			DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
			dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn10.Width = 80;
			dataGridViewColumn10.HeaderText = headerText10;
			dataGridViewColumn10.Name = "Remain";
			dataGridViewColumn10.ReadOnly = true;
			dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn10.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn10);
			DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
			dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn11.Width = 100;
			dataGridViewColumn11.HeaderText = headerText11;
			dataGridViewColumn11.Name = "TrimWidth";
			dataGridViewColumn11.ReadOnly = true;
			dataGridViewColumn11.Visible = true;
			dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn11.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn11);
			DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
			dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn12.Width = 100;
			dataGridViewColumn12.HeaderText = headerText12;
			dataGridViewColumn12.Name = "TrimHeight";
			dataGridViewColumn12.ReadOnly = false;
			dataGridViewColumn12.Visible = true;
			dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn12.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn12);
			int num = dataGridViewColumn.Width + dataGridViewColumn2.Width + dataGridViewColumn3.Width + dataGridViewColumn4.Width + dataGridViewColumn5.Width + dataGridViewColumn6.Width + dataGridViewColumn7.Width + dataGridViewColumn8.Width + dataGridViewColumn9.Width + dataGridViewColumn10.Width + dataGridViewColumn11.Width + dataGridViewColumn12.Width;
			int num2 = dataGridView_0.Width - num;
			if (num2 < 100)
			{
				num2 = 100;
			}
			DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
			dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn13.Width = num2;
			dataGridViewColumn13.HeaderText = headerText3;
			dataGridViewColumn13.Name = "Referance";
			dataGridViewColumn13.ReadOnly = false;
			dataGridViewColumn13.Visible = true;
			dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn13.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn13);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		SendToCadEntities.Clear();
		SendToCadEntities = new List<Entity>();
		timer_0 = new Timer();
		Class186.smethod_253(this);
		tabControl_0.SelectedIndex = 0;
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
			if (Captions.Count >= 33)
			{
				Text = Captions[0];
				tabPage_0.Text = Captions[1];
				label_2.Text = Captions[1];
				button_3.Text = Captions[4];
				button_2.Text = Captions[5];
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
		if (text == button_3.Name)
		{
			F_NestSheetAdd f_NestSheetAdd = new F_NestSheetAdd();
			f_NestSheetAdd.ShowItemNo = Settings.Draw.ShowSheetItemNoColumb;
			f_NestSheetAdd.FormCloseMode = FormCloseModeType.Dispose;
			f_NestSheetAdd.Init();
			f_NestSheetAdd.StartPosition = FormStartPosition.CenterParent;
			f_NestSheetAdd.ShowDialog();
			if (f_NestSheetAdd.Result == DialogResult.OK)
			{
				buNestingSheet buNestingSheet2 = new buNestingSheet(f_NestSheetAdd.Sheet);
				buCall.buVector5_0.SetColorEntity(Settings.Draw.SheetEntityColor, ref buNestingSheet2.EntitiesGroup.Outside.Entities);
				buCall.buNestingCalc_0.GetAvailableNestingSheetID(Sheets, ref buNestingSheet2.ID);
				Sheets.Add(buNestingSheet2);
				Image Img = null;
				SheetPointsToImage(f_NestSheetAdd.Sheet, Settings.Draw.GridPartSheetPreviewWidth, Settings.Draw.GridPartSheetHeight, ref Img);
				dataGridView_0.Rows.Add(Class186.smethod_503(int_1: Sheets.Count, bool_0: f_NestSheetAdd.Sheet.Enable, string_0: f_NestSheetAdd.Sheet.Referance, double_4: f_NestSheetAdd.Sheet.MaterialData.Width, double_3: f_NestSheetAdd.Sheet.MaterialData.Height, double_0: f_NestSheetAdd.Sheet.MaterialData.Thickness, int_2: f_NestSheetAdd.Sheet.MaterialData.Quantity, int_0: f_NestSheetAdd.Sheet.Used, int_3: f_NestSheetAdd.Sheet.Remain, double_2: f_NestSheetAdd.Sheet.TrimWidth, double_1: f_NestSheetAdd.Sheet.TrimHeight, string_1: f_NestSheetAdd.Sheet.Remarks, image_0: Img, f_PanelCutSheetList_0: this));
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = Settings.Draw.GridPartSheetHeight;
			}
		}
		if (!(text == button_2.Name))
		{
			if (text == button_1.Name && ((int_0 >= 0) & (int_0 <= Sheets.Count - 1)))
			{
				dataGridView_0.Rows[int_0].Cells[7].Value = 0;
				dataGridView_0.Rows[int_0].Cells[8].Value = Sheets[int_0].MaterialData.Quantity;
				Sheets[int_0].Used = 0;
				Sheets[int_0].Remain = Sheets[int_0].MaterialData.Quantity;
				dataGridView_0.Rows[int_0].DefaultCellStyle.ForeColor = Color.Black;
			}
			if (text == button_0.Name)
			{
				for (int i = 0; i <= Sheets.Count - 1; i++)
				{
					Sheets[i].Used = 0;
					Sheets[i].Remain = Sheets[i].MaterialData.Quantity;
					dataGridView_0.Rows[i].Cells[7].Value = 0;
					dataGridView_0.Rows[i].Cells[8].Value = Sheets[i].MaterialData.Quantity;
					dataGridView_0.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
				}
			}
			if (text == toolStripMenuItem_0.Name)
			{
				for (int num = dataGridView_0.Rows.Count - 1; num >= 0; num--)
				{
					dataGridView_0.Rows[num].Cells[1].Value = true;
					Sheets[num].Enable = true;
				}
			}
			if (text == toolStripMenuItem_1.Name)
			{
				for (int num2 = dataGridView_0.Rows.Count - 1; num2 >= 0; num2--)
				{
					dataGridView_0.Rows[num2].Cells[1].Value = false;
					Sheets[num2].Enable = false;
				}
			}
			if (text == toolStripMenuItem_2.Name)
			{
				DialogBoxInput dialogBoxInput = new DialogBoxInput();
				dialogBoxInput.ValueCaption = "Count";
				dialogBoxInput.FormCaption = "Set Sheet Count";
				dialogBoxInput.Value = 1.0;
				dialogBoxInput.ShowDialog();
				if (dialogBoxInput.Result == DialogResult.OK)
				{
					for (int num3 = dataGridView_0.Rows.Count - 1; num3 >= 0; num3--)
					{
						dataGridView_0.Rows[num3].Cells[6].Value = Convert.ToInt32(dialogBoxInput.Value);
						Sheets[num3].MaterialData.Quantity = Convert.ToInt32(dialogBoxInput.Value);
					}
				}
			}
			if (text == toolStripMenuItem_7.Name)
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
						for (int j = 0; j <= Sheets.Count - 1; j++)
						{
							if (!Sheets[j].Enable)
							{
								continue;
							}
							string text2 = Sheets[j].MaterialData.Name.Trim();
							if (text2.Length == 0)
							{
								text2 = "Mat" + (j + 1);
							}
							string fileName = buFile5.GetPath(saveFileDialog.FileName) + "\\" + buFile5.getFileNameWithoutExtension(saveFileDialog.FileName) + "_" + (j + 1) + "_" + text2 + "_" + Sheets[j].MaterialData.Quantity + fileInfo.Extension;
							List<Entity> copiedEntities = new List<Entity>();
							buEntity.Copy(Sheets[j].EntitiesGroup.Outside.Entities, ref copiedEntities);
							if (Sheets[j].EntitiesGroup.Inside != null)
							{
								for (int k = 0; k <= Sheets[j].EntitiesGroup.Inside.Count - 1; k++)
								{
									for (int l = 0; l <= Sheets[j].EntitiesGroup.Inside[k].Entities.Count - 1; l++)
									{
										Entity copiedEntity = null;
										buEntity.Copy(Sheets[j].EntitiesGroup.Inside[k].Entities[l], ref copiedEntity);
										copiedEntities.Add(copiedEntity);
									}
								}
							}
							if (Sheets[j].EntitiesGroup.OpenEntities != null)
							{
								for (int m = 0; m <= Sheets[j].EntitiesGroup.OpenEntities.Count - 1; m++)
								{
									for (int n = 0; n <= Sheets[j].EntitiesGroup.OpenEntities[m].Entities.Count - 1; n++)
									{
										Entity copiedEntity2 = null;
										buEntity.Copy(Sheets[j].EntitiesGroup.OpenEntities[m].Entities[n], ref copiedEntity2);
										copiedEntities.Add(copiedEntity2);
									}
								}
							}
							if (Sheets[j].EntitiesGroup.Text != null)
							{
								for (int num4 = 0; num4 <= Sheets[j].EntitiesGroup.Text.Entities.Count - 1; num4++)
								{
									Entity copiedEntity3 = null;
									buEntity.Copy(Sheets[j].EntitiesGroup.Text.Entities[num4], ref copiedEntity3);
									copiedEntities.Add(copiedEntity3);
								}
							}
							buFile5.SaveDxfDwg(copiedEntities, fileName);
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
					bunesting.SaveNesting(saveFileDialog2.FileName, new List<buNestingPart>(), Sheets, Settings);
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
					List<buNestingPart> Parts = new List<buNestingPart>();
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
		if (radioButton_2.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
		{
			Sheets.Clear();
			dataGridView_0.Rows.Clear();
		}
		if (radioButton_1.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
		{
			dataGridView_0.Rows.RemoveAt(int_0);
			Sheets.RemoveAt(int_0);
		}
		if (!radioButton_0.Checked || buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) != DialogResult.Yes)
		{
			return;
		}
		for (int num5 = dataGridView_0.Rows.Count - 1; num5 >= 0; num5--)
		{
			if (Convert.ToBoolean(dataGridView_0.Rows[num5].Cells[1].Value))
			{
				dataGridView_0.Rows.RemoveAt(num5);
				Sheets.RemoveAt(num5);
			}
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= Sheets.Count - 1))
		{
			int_0 = e.RowIndex;
			buCall.buVector5_0.DrawSheet(Sheets[int_0], Settings, ref design_0);
			if ((int_0 >= 0) & (int_0 <= Sheets.Count - 1))
			{
				PropertiesForm.Inited = false;
				double num = 0.0;
				List<Point3D> copiedPoint = new List<Point3D>();
				num = Sheets[int_0].MaterialData.Width / 1000.0 * (Sheets[int_0].MaterialData.Height / 1000.0);
				buVector5.Copy(Sheets[int_0].EntitiesGroup.Outside.Points, ref copiedPoint);
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
				double num2 = buCall.buVector5_0.PolygonArea(copiedPoint, Plane.XY);
				textBox_1.Text = num.ToString("f2");
				textBox_0.Text = (num2 / 1000000.0).ToString("f2");
				textBox_3.Text = Sheets[int_0].Referance;
				textBox_2.Text = Sheets[int_0].Remarks;
				numericUpDown_1.Value = (decimal)Sheets[int_0].TrimHeight;
				numericUpDown_0.Value = (decimal)Sheets[int_0].TrimWidth;
				PropertiesForm.Inited = true;
			}
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= Sheets.Count - 1))
		{
			buNestingSheetData buNestingSheetData2 = new buNestingSheetData(Sheets[e.RowIndex].MaterialData);
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.Width = 300;
			f_ClassViewerDialog.Value = buNestingSheetData2;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				Sheets[e.RowIndex].MaterialData = new buNestingSheetData((buNestingSheetData)f_ClassViewerDialog.Value);
				Sheets[e.RowIndex].Area = buNestingSheetData2.Height * buNestingSheetData2.Width;
				Sheets[e.RowIndex].Remain = Sheets[e.RowIndex].MaterialData.Quantity - Sheets[e.RowIndex].Used;
				if (Sheets[e.RowIndex].MaterialData.Quantity < 0)
				{
					Sheets[e.RowIndex].Remain = Sheets[e.RowIndex].MaterialData.Quantity;
				}
				if (Sheets[e.RowIndex].Type == nestMaterialType.Rectangle)
				{
					buNestingSheet Sheet = Sheets[e.RowIndex];
					buCall.buNestingCalc_0.SheetRectangle(Sheets[e.RowIndex].MaterialData.Width, Sheets[e.RowIndex].MaterialData.Height, ref Sheet);
				}
				Class186.smethod_253(this);
				buCall.buVector5_0.DrawSheet(Sheets[e.RowIndex], Settings, ref design_0);
				dataGridView_0.CurrentCell = dataGridView_0.Rows[e.RowIndex].Cells[1];
			}
		}
		Class186.smethod_388(this);
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
		{
			if ((e.ColumnIndex == 1) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].Enable = Convert.ToBoolean(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 2) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].MaterialData.Name = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 4) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].MaterialData.Width = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
				Sheets[e.RowIndex].Area = Sheets[e.RowIndex].MaterialData.Height * Sheets[e.RowIndex].MaterialData.Width;
				Sheets[e.RowIndex].Remain = Sheets[e.RowIndex].MaterialData.Quantity - Sheets[e.RowIndex].Used;
				if (Sheets[e.RowIndex].Type == nestMaterialType.Rectangle)
				{
					buNestingSheet Sheet = Sheets[e.RowIndex];
					buCall.buNestingCalc_0.SheetRectangle(Sheets[e.RowIndex].MaterialData.Width, Sheets[e.RowIndex].MaterialData.Height, ref Sheet);
				}
				buCall.buVector5_0.DrawSheet(Sheets[e.RowIndex], Settings, ref design_0);
			}
			if ((e.ColumnIndex == 5) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].MaterialData.Height = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
				Sheets[e.RowIndex].Area = Sheets[e.RowIndex].MaterialData.Height * Sheets[e.RowIndex].MaterialData.Width;
				Sheets[e.RowIndex].Remain = Sheets[e.RowIndex].MaterialData.Quantity - Sheets[e.RowIndex].Used;
				if (Sheets[e.RowIndex].Type == nestMaterialType.Rectangle)
				{
					buNestingSheet Sheet2 = Sheets[e.RowIndex];
					buCall.buNestingCalc_0.SheetRectangle(Sheets[e.RowIndex].MaterialData.Width, Sheets[e.RowIndex].MaterialData.Height, ref Sheet2);
				}
				buCall.buVector5_0.DrawSheet(Sheets[e.RowIndex], Settings, ref design_0);
			}
			if ((e.ColumnIndex == 6) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].MaterialData.Quantity = Convert.ToInt32(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
				Sheets[e.RowIndex].Remain = Sheets[e.RowIndex].MaterialData.Quantity - Sheets[e.RowIndex].Used;
			}
			if ((e.ColumnIndex == 11) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].MaterialData.ItemNo = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 12) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].MaterialData.Other = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 13) & (e.RowIndex <= Sheets.Count - 1))
			{
				Sheets[e.RowIndex].MaterialData.Aux = Convert.ToString(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
		}
		Class186.smethod_388(this);
	}

	public void SheetPointsToImage(buNestingSheet Sheet, int Width, int Height, ref Image Img)
	{
		buViewer buViewer2 = new buViewer();
		buViewer2.Width = Width;
		buViewer2.Height = Height;
		for (int i = 0; i <= Sheet.EntitiesGroup.Outside.Entities.Count - 1; i++)
		{
			eEntities item = new eEntities();
			buConversion5.buEntityToEEntities(Sheet.EntitiesGroup.Outside.Entities[i], Sheet.EntitiesGroup.Outside.Entities[i].Color, ref item);
			buViewer2.Entities.Add(item);
		}
		buViewer2.DrawEntities();
		buViewer2.ZoomFit();
		buViewer2.ZoomOut();
		Img = buViewer2.Bmp;
	}

	public void CreatPartAsRectanlge(double newWidth, double newHeight, buNestingPart OldPart, ref buNestingPart NewPart)
	{
		NewPart = new buNestingPart(OldPart);
		NewPart.Type = nestMaterialType.Rectangle;
		NewPart.PartData.Width = newWidth;
		NewPart.PartData.Height = newHeight;
		buCall.buNestingCalc_0.PartRectangle(NewPart.PartData.Width, NewPart.PartData.Height, ref NewPart);
	}

	internal void method_5(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if ((int_0 >= 0) & (int_0 <= Sheets.Count - 1) & PropertiesForm.Inited)
		{
			if (control.Name == numericUpDown_1.Name)
			{
				Sheets[int_0].TrimHeight = (double)numericUpDown_1.Value;
			}
			if (control.Name == numericUpDown_0.Name)
			{
				Sheets[int_0].TrimWidth = (double)numericUpDown_0.Value;
			}
			Class186.smethod_388(this);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if ((int_0 >= 0) & (int_0 <= Sheets.Count - 1) & PropertiesForm.Inited)
		{
			if (control.Name == textBox_2.Name)
			{
				Sheets[int_0].Remarks = textBox_2.Text;
			}
			if (control.Name == textBox_3.Name)
			{
				Sheets[int_0].Referance = textBox_3.Text;
			}
			Class186.smethod_388(this);
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
