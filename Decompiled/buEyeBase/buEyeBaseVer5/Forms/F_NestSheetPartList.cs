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

namespace buEyeBaseVer5.Forms;

public class F_NestSheetPartList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	internal Timer timer_0 = new Timer();

	private int int_0 = -1;

	public int SelectedRowPart = -1;

	public int SelectedColPart = -1;

	public int PartPreSelectedRow = -1;

	private Design design_0 = null;

	public buNestingVar Settings = new buNestingVar();

	public string AddPartFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Part CSV File (*.csv)|*.csv";

	public string AddSheetFromFileExtender = "buCad Cad/Cam Files (*.bucadv5)|*.bucadv5|Autocad Dxf Files (*.dxf)|*.dxf|Rectangle Sheet CSV File (*.csv)|*.csv";

	public string SaveFileExtender = "Autocad Dxf Files (*.dxf)|*.dxf";

	public bool AddPartFromFileExtenderAsCsvType = false;

	public bool SendToCad = false;

	public bool DrawPart = false;

	public bool ShiftPressed = false;

	public int AddPartFromFileExtensionIndex = 1;

	public int AddSheetFromFileExtensionIndex = 1;

	public int SaveFileExtensionIndex = 1;

	public string AddPartFromFileFolder = Application.StartupPath;

	public string AddSheetFromFileFolder = Application.StartupPath;

	public string SaveFileFolder = Application.StartupPath;

	public ToolBase5 activeTool = new ToolBase5();

	public LayerBase5 activeLayer = new LayerBase5();

	public nestCsvPartImportType CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;

	public nestPartRotateType PartRotationDefault = nestPartRotateType.Increment90;

	public List<buNestingSheet> Sheets = new List<buNestingSheet>();

	public List<buNestingPart> Parts = new List<buNestingPart>();

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

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripSeparator toolStripSeparator_0;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal TabPage tabPage_1;

	internal Label label_2;

	internal TextBox textBox_2;

	internal Label label_3;

	internal TextBox textBox_3;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal DataGridView dataGridView_1;

	internal ContextMenuStrip contextMenuStrip_1;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal ToolStripSeparator toolStripSeparator_1;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal ToolStripMenuItem toolStripMenuItem_6;

	internal ToolStripMenuItem toolStripMenuItem_7;

	internal ToolStripMenuItem toolStripMenuItem_8;

	internal ToolStripSeparator toolStripSeparator_2;

	internal ToolStripMenuItem toolStripMenuItem_9;

	internal ToolStripSeparator toolStripSeparator_3;

	internal ToolStripMenuItem toolStripMenuItem_10;

	internal ToolStripMenuItem toolStripMenuItem_11;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal Button button_13;

	internal Panel panel_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal Panel panel_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal ToolStripSeparator toolStripSeparator_4;

	internal ToolStripMenuItem toolStripMenuItem_12;

	public CheckBox chk_preview;

	internal ToolStripSeparator toolStripSeparator_5;

	internal ToolStripMenuItem toolStripMenuItem_13;

	internal Label label_4;

	internal Label label_5;

	internal Panel panel_3;

	internal NumericUpDown numericUpDown_0;

	internal Label label_6;

	internal ToolStripMenuItem toolStripMenuItem_14;

	internal ToolStripMenuItem toolStripMenuItem_15;

	internal ToolStripSeparator toolStripSeparator_6;

	internal ToolStripMenuItem toolStripMenuItem_16;

	internal Button button_14;

	public ListBox lst_info;

	internal Label label_7;

	public F_NestSheetPartList()
	{
		buFunctions.CultureSettings();
		Class186.smethod_813(this);
	}

	public void Init(int SelectedTab)
	{
		PropertiesForm.Inited = false;
		SendToCad = false;
		DrawPart = false;
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			panel_3.Controls.Add(design_0);
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
		string headerText3 = "Name";
		string headerText4 = "Preview";
		string headerText5 = "Width";
		string headerText6 = "Height";
		string headerText7 = "Count";
		string headerText8 = "Used";
		string headerText9 = "Remain";
		string headerText10 = "Filename";
		string headerText11 = "Thickness";
		string headerText12 = "ItemNo";
		string headerText13 = "Other";
		string headerText14 = "Aux";
		string headerText15 = "Nested";
		string headerText16 = "Rotation";
		string headerText17 = "Priority";
		if (Captions.Count > 46)
		{
			headerText = Captions[35];
			headerText2 = Captions[36];
			headerText3 = Captions[37];
			headerText4 = Captions[38];
			headerText5 = Captions[39];
			headerText6 = Captions[40];
			headerText7 = Captions[41];
			headerText8 = Captions[46];
			headerText9 = Captions[43];
			headerText10 = Captions[47];
			headerText11 = Captions[48];
			headerText12 = Captions[51];
			headerText13 = Captions[50];
			headerText14 = Captions[49];
			headerText15 = Captions[42];
			headerText16 = Captions[45];
			headerText17 = Captions[44];
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
			dataGridViewColumn8.HeaderText = headerText8;
			dataGridViewColumn8.Name = "Used";
			dataGridViewColumn8.ReadOnly = true;
			dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn8);
			DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
			dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn9.Width = 100;
			dataGridViewColumn9.HeaderText = headerText9;
			dataGridViewColumn9.Name = "Remain";
			dataGridViewColumn9.ReadOnly = true;
			dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn9.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn9);
			DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
			dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn10.Width = 200;
			dataGridViewColumn10.HeaderText = headerText10;
			dataGridViewColumn10.Name = "FileName";
			dataGridViewColumn10.ReadOnly = true;
			dataGridViewColumn10.Visible = Settings.Draw.ShowSheetFileNameColumb;
			dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn10.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn10);
			DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
			dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn11.Width = 100;
			dataGridViewColumn11.HeaderText = headerText11;
			dataGridViewColumn11.Name = "Thickness";
			dataGridViewColumn11.ReadOnly = false;
			dataGridViewColumn11.Visible = Settings.Draw.ShowSheetThicknessColumb;
			dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn11.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn11);
			DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
			dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn12.Width = 80;
			dataGridViewColumn12.HeaderText = headerText12;
			dataGridViewColumn12.Name = "ItemNo";
			dataGridViewColumn12.ReadOnly = false;
			dataGridViewColumn12.Visible = Settings.Draw.ShowSheetItemNoColumb;
			dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn12.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn12);
			DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
			dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn13.Width = 80;
			dataGridViewColumn13.HeaderText = headerText13;
			dataGridViewColumn13.Name = "Other";
			dataGridViewColumn13.ReadOnly = false;
			dataGridViewColumn13.Visible = Settings.Draw.ShowSheetOtherColumb;
			dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn13.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn13);
			DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
			dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn14.Width = 80;
			dataGridViewColumn14.HeaderText = headerText14;
			dataGridViewColumn14.Name = "Aux";
			dataGridViewColumn14.ReadOnly = false;
			dataGridViewColumn14.Visible = Settings.Draw.ShowSheetAuxColumb;
			dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn14.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn14);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		if (dataGridView_1.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
			dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn15.Width = 40;
			dataGridViewColumn15.HeaderText = headerText;
			dataGridViewColumn15.Name = "No";
			dataGridViewColumn15.ReadOnly = true;
			dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn15.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn15);
			DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
			dataGridViewColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn16.Width = 50;
			dataGridViewColumn16.HeaderText = headerText2;
			dataGridViewColumn16.Name = "Sel";
			dataGridViewColumn16.ReadOnly = false;
			dataGridViewColumn16.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn16.CellTemplate = new DataGridViewCheckBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn16);
			DataGridViewColumn dataGridViewColumn17 = new DataGridViewColumn();
			dataGridViewColumn17.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn17.Width = 200;
			dataGridViewColumn17.HeaderText = headerText3;
			dataGridViewColumn17.Name = "Name";
			dataGridViewColumn17.ReadOnly = false;
			dataGridViewColumn17.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn17.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn17);
			DataGridViewColumn dataGridViewColumn18 = new DataGridViewColumn();
			dataGridViewColumn18.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn18.Width = Settings.Draw.GridPartSheetPreviewWidth;
			dataGridViewColumn18.HeaderText = headerText4;
			dataGridViewColumn18.Name = "Image";
			dataGridViewColumn18.ReadOnly = true;
			dataGridViewColumn18.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn18.CellTemplate = new DataGridViewImageCell();
			dataGridView_1.Columns.Add(dataGridViewColumn18);
			DataGridViewColumn dataGridViewColumn19 = new DataGridViewColumn();
			dataGridViewColumn19.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn19.Width = 100;
			dataGridViewColumn19.HeaderText = headerText5;
			dataGridViewColumn19.Name = "Width";
			dataGridViewColumn19.ReadOnly = false;
			dataGridViewColumn19.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn19.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn19);
			DataGridViewColumn dataGridViewColumn20 = new DataGridViewColumn();
			dataGridViewColumn20.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn20.Width = 100;
			dataGridViewColumn20.HeaderText = headerText6;
			dataGridViewColumn20.Name = "Height";
			dataGridViewColumn20.ReadOnly = false;
			dataGridViewColumn20.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn20.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn20);
			DataGridViewColumn dataGridViewColumn21 = new DataGridViewColumn();
			dataGridViewColumn21.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn21.Width = 80;
			dataGridViewColumn21.HeaderText = headerText7;
			dataGridViewColumn21.Name = "Count";
			dataGridViewColumn21.ReadOnly = false;
			dataGridViewColumn21.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn21.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn21);
			DataGridViewColumn dataGridViewColumn22 = new DataGridViewColumn();
			dataGridViewColumn22.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn22.Width = 80;
			dataGridViewColumn22.HeaderText = headerText15;
			dataGridViewColumn22.Name = "Nested";
			dataGridViewColumn22.ReadOnly = true;
			dataGridViewColumn22.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn22.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn22);
			DataGridViewColumn dataGridViewColumn23 = new DataGridViewColumn();
			dataGridViewColumn23.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn23.Width = 80;
			dataGridViewColumn23.HeaderText = headerText9;
			dataGridViewColumn23.Name = "Remain";
			dataGridViewColumn23.ReadOnly = true;
			dataGridViewColumn23.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn23.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn23);
			DataGridViewColumn dataGridViewColumn24 = new DataGridViewColumn();
			dataGridViewColumn24.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn24.Width = 80;
			dataGridViewColumn24.HeaderText = headerText17;
			dataGridViewColumn24.Name = "Priority";
			dataGridViewColumn24.ReadOnly = true;
			dataGridViewColumn24.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn24.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn24);
			DataGridViewColumn dataGridViewColumn25 = new DataGridViewColumn();
			dataGridViewColumn25.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn25.Width = 140;
			dataGridViewColumn25.HeaderText = headerText16;
			dataGridViewColumn25.Name = "Rotation";
			dataGridViewColumn25.ReadOnly = true;
			dataGridViewColumn25.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn25.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn25);
			DataGridViewColumn dataGridViewColumn26 = new DataGridViewColumn();
			dataGridViewColumn26.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn26.Width = 80;
			dataGridViewColumn26.HeaderText = buLangTranslate.preDef.Mirror;
			dataGridViewColumn26.Name = buLangTranslate.preDef.Mirror;
			dataGridViewColumn26.ReadOnly = false;
			dataGridViewColumn26.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn26.CellTemplate = new DataGridViewCheckBoxCell();
			dataGridViewColumn26.Visible = true;
			dataGridView_1.Columns.Add(dataGridViewColumn26);
			DataGridViewColumn dataGridViewColumn27 = new DataGridViewColumn();
			dataGridViewColumn27.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn27.Width = 200;
			dataGridViewColumn27.HeaderText = headerText10;
			dataGridViewColumn27.Name = "FileName";
			dataGridViewColumn27.ReadOnly = true;
			dataGridViewColumn27.Visible = Settings.Draw.ShowPartFileNameColumb;
			dataGridViewColumn27.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn27.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn27);
			DataGridViewColumn dataGridViewColumn28 = new DataGridViewColumn();
			dataGridViewColumn28.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn28.Width = 100;
			dataGridViewColumn28.HeaderText = headerText11;
			dataGridViewColumn28.Name = "Thickness";
			dataGridViewColumn28.ReadOnly = false;
			dataGridViewColumn28.Visible = Settings.Draw.ShowPartThicknessColumb;
			dataGridViewColumn28.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn28.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn28);
			DataGridViewColumn dataGridViewColumn29 = new DataGridViewColumn();
			dataGridViewColumn29.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn29.Width = 80;
			dataGridViewColumn29.HeaderText = headerText12;
			dataGridViewColumn29.Name = "ItemNo";
			dataGridViewColumn29.ReadOnly = false;
			dataGridViewColumn29.Visible = Settings.Draw.ShowPartItemNoColumb;
			dataGridViewColumn29.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn29.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn29);
			DataGridViewColumn dataGridViewColumn30 = new DataGridViewColumn();
			dataGridViewColumn30.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn30.Width = 80;
			dataGridViewColumn30.HeaderText = headerText13;
			dataGridViewColumn30.Name = "Other";
			dataGridViewColumn30.ReadOnly = false;
			dataGridViewColumn30.Visible = Settings.Draw.ShowPartOtherColumb;
			dataGridViewColumn30.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn30.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn30);
			DataGridViewColumn dataGridViewColumn31 = new DataGridViewColumn();
			dataGridViewColumn31.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn31.Width = 80;
			dataGridViewColumn31.HeaderText = headerText14;
			dataGridViewColumn31.Name = "Aux";
			dataGridViewColumn31.ReadOnly = false;
			dataGridViewColumn31.Visible = Settings.Draw.ShowPartAuxColumb;
			dataGridViewColumn31.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn31.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn31);
		}
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToResizeColumns = false;
		numericUpDown_0.Value = Settings.PartSettings.Multiply;
		SendToCadEntities.Clear();
		SendToCadEntities = new List<Entity>();
		timer_0 = new Timer();
		Class186.smethod_348(this);
		if (SelectedTab == 0)
		{
			tabControl_0.SelectedIndex = 0;
		}
		if (SelectedTab == 1)
		{
			tabControl_0.SelectedIndex = 1;
		}
		if (!radioButton_5.Checked & !radioButton_3.Checked & !radioButton_4.Checked)
		{
			radioButton_4.Checked = true;
		}
		if (!radioButton_2.Checked & !radioButton_0.Checked & !radioButton_1.Checked)
		{
			radioButton_1.Checked = true;
		}
		LoadLanguage();
		GetInfo();
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
				label_4.Text = Captions[1];
				tabPage_1.Text = Captions[2];
				label_5.Text = Captions[2];
				button_0.Text = Captions[3];
				button_4.Text = Captions[4];
				button_3.Text = Captions[5];
				button_5.Text = Captions[6];
				button_9.Text = Captions[7];
				button_8.Text = Captions[8];
				label_6.Text = Captions[9];
				button_2.Text = Captions[10];
				button_1.Text = Captions[11];
				button_7.Text = Captions[10];
				button_6.Text = Captions[11];
				radioButton_2.Text = Captions[12];
				radioButton_1.Text = Captions[13];
				radioButton_0.Text = Captions[14];
				radioButton_5.Text = Captions[12];
				radioButton_4.Text = Captions[13];
				radioButton_3.Text = Captions[14];
				label_1.Text = Captions[15];
				label_0.Text = Captions[16];
				label_3.Text = Captions[15];
				label_2.Text = Captions[16];
				chk_preview.Text = Captions[17];
				button_11.Text = Captions[18];
				button_10.Text = Captions[19];
				button_13.Text = Captions[20];
				button_12.Text = Captions[21];
				toolStripMenuItem_3.Text = Captions[22];
				toolStripMenuItem_4.Text = Captions[23];
				toolStripMenuItem_5.Text = Captions[24];
				toolStripMenuItem_6.Text = Captions[25];
				toolStripMenuItem_7.Text = Captions[26];
				toolStripMenuItem_8.Text = Captions[27];
				toolStripMenuItem_9.Text = Captions[28];
				toolStripMenuItem_10.Text = Captions[29];
				toolStripMenuItem_11.Text = Captions[30];
				toolStripMenuItem_12.Text = Captions[31];
				toolStripMenuItem_0.Text = Captions[32];
				toolStripMenuItem_1.Text = Captions[52];
				toolStripMenuItem_2.Text = Captions[28];
				toolStripMenuItem_13.Text = Captions[29];
				toolStripMenuItem_14.Text = Captions[33];
				toolStripMenuItem_15.Text = Captions[34];
				toolStripMenuItem_16.Text = Captions[53];
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
		if (text == button_14.Name && ((SelectedRowPart >= 0) & (SelectedRowPart <= Parts.Count - 1)))
		{
			DrawPart = true;
			PropertiesForm.Result = DialogResult.OK;
			base.Visible = false;
		}
		if (text == button_4.Name)
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
				dataGridView_0.Rows.Add(Class186.smethod_761(int_2: Sheets.Count, bool_0: f_NestSheetAdd.Sheet.Enable, string_0: f_NestSheetAdd.Sheet.MaterialData.Name, double_0: f_NestSheetAdd.Sheet.MaterialData.Width, double_2: f_NestSheetAdd.Sheet.MaterialData.Height, int_0: f_NestSheetAdd.Sheet.MaterialData.Quantity, int_1: f_NestSheetAdd.Sheet.Used, int_3: f_NestSheetAdd.Sheet.Remain, string_3: f_NestSheetAdd.Sheet.FileName, double_1: f_NestSheetAdd.Sheet.MaterialData.Thickness, string_1: f_NestSheetAdd.Sheet.MaterialData.ItemNo, string_2: f_NestSheetAdd.Sheet.MaterialData.Other, string_4: f_NestSheetAdd.Sheet.MaterialData.Aux, image_0: Img, f_NestSheetPartList_0: this));
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = Settings.Draw.GridPartSheetHeight;
			}
		}
		if (!(text == button_3.Name))
		{
			if (text == button_2.Name && ((int_0 >= 0) & (int_0 <= Parts.Count - 1)))
			{
				dataGridView_0.Rows[int_0].Cells[7].Value = 0;
				dataGridView_0.Rows[int_0].Cells[8].Value = Sheets[int_0].MaterialData.Quantity;
				Sheets[int_0].Used = 0;
				Sheets[int_0].Remain = Sheets[int_0].MaterialData.Quantity;
				dataGridView_0.Rows[int_0].DefaultCellStyle.ForeColor = Color.Black;
			}
			if (text == button_1.Name)
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
			if (text == toolStripMenuItem_13.Name && Parts.Count > 0)
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
			if (text == button_9.Name)
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
					Entity entSurface = null;
					if (Settings.ProgramSettings.View3D)
					{
						buCall.buVector5_0.surfaceFromOutterInner(buNestingPart2.EntitiesGroup, 0.2, ref entSurface);
					}
					if (entSurface != null)
					{
						buNestingPart2.EntitiesGroup.Solid = new buEntityList();
						buEntity copiedEntity4 = null;
						buEntity.Copy(entSurface, ref copiedEntity4);
						if (copiedEntity4 != null)
						{
							buNestingPart2.EntitiesGroup.Solid.Entities.Add(copiedEntity4);
						}
					}
					buCall.buVector5_0.SetLayerNameEntity(activeLayer.Name, ref buNestingPart2.EntitiesGroup.Outside.Entities);
					buCall.buVector5_0.SetColorEntity(activeLayer.LayerColor, ref buNestingPart2.EntitiesGroup.Outside.Entities);
					buCall.buVector5_0.SetToolNameEntity(activeTool.Data.Name, ref buNestingPart2.EntitiesGroup.Outside.Entities);
					buCall.buNestingCalc_0.GetAvailableNestingPartID(Parts, ref buNestingPart2.ID);
					Parts.Add(buNestingPart2);
					Image Img2 = null;
					PartPointsToImage(f_NestRectPartAdd.Part, Settings.Draw.GridPartSheetPreviewWidth, Settings.Draw.GridPartSheetHeight, ref Img2);
					dataGridView_1.Rows.Add(Class186.smethod_486(int_4: Parts.Count, bool_0: f_NestRectPartAdd.Part.Enable, string_1: f_NestRectPartAdd.Part.PartData.Name, double_1: f_NestRectPartAdd.Part.PartData.Width, double_0: f_NestRectPartAdd.Part.PartData.Height, int_0: f_NestRectPartAdd.Part.PartData.Quantity, int_1: f_NestRectPartAdd.Part.Nested, int_2: f_NestRectPartAdd.Part.Remain, int_3: f_NestRectPartAdd.Part.PartData.Priority, enum_0: (Enum)f_NestRectPartAdd.Part.PartData.Rotation, bool_1: f_NestRectPartAdd.Part.PartData.Mirror, string_0: f_NestRectPartAdd.Part.FileName, string_2: f_NestRectPartAdd.Part.PartData.ItemNo, string_4: f_NestRectPartAdd.Part.PartData.Other, string_3: f_NestRectPartAdd.Part.PartData.Aux, image_0: Img2, f_NestSheetPartList_0: this));
					dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
					dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Height = Settings.Draw.GridPartSheetHeight;
					GetInfo();
				}
			}
			if (text == button_5.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = AddPartFromFileFolder;
				openFileDialog.Filter = AddPartFromFileExtender;
				openFileDialog.FilterIndex = AddPartFromFileExtensionIndex;
				openFileDialog.Multiselect = true;
				openFileDialog.FileName = "";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					AddPartFromFileFolder = buFile5.GetPath(openFileDialog.FileName);
					AddPartFromFileExtensionIndex = openFileDialog.FilterIndex;
					if (openFileDialog.FileNames.Length != 0)
					{
						for (int num5 = 0; num5 <= openFileDialog.FileNames.Length - 1; num5++)
						{
							FileInfo fileInfo2 = new FileInfo(openFileDialog.FileNames[num5]);
							if (fileInfo2.Extension == ".bucadv5")
							{
								List<eEntities> Entities = new List<eEntities>();
								buFile5.OpenBuCadCam(fileInfo2.FullName, new buCadFileOpenOptions(), ref Entities);
								AddPartFromEntities(Entities);
							}
							if (fileInfo2.Extension == ".dxf")
							{
								List<eEntities> entities = new List<eEntities>();
								new List<LayerBase>();
								AddPartFromEntities(entities);
							}
							if (fileInfo2.Extension == ".csv")
							{
								AddPartFromCsvFile(CsvOpenTypeForAddNestingFromFile, openFileDialog.FileName);
							}
						}
					}
					GetInfo();
				}
			}
			if (!(text == button_8.Name))
			{
				if (text == button_7.Name && ((SelectedRowPart >= 0) & (SelectedRowPart <= Parts.Count - 1)))
				{
					dataGridView_1.Rows[SelectedRowPart].Cells[7].Value = 0;
					dataGridView_1.Rows[SelectedRowPart].Cells[8].Value = Parts[SelectedRowPart].PartData.Quantity;
					Parts[SelectedRowPart].Nested = 0;
					Parts[SelectedRowPart].Remain = Parts[SelectedRowPart].PartData.Quantity;
					dataGridView_1.Rows[SelectedRowPart].DefaultCellStyle.ForeColor = Color.Black;
				}
				if (text == button_6.Name)
				{
					for (int num6 = 0; num6 <= Parts.Count - 1; num6++)
					{
						dataGridView_1.Rows[num6].Cells[7].Value = 0;
						dataGridView_1.Rows[num6].Cells[8].Value = Parts[num6].PartData.Quantity;
						Parts[num6].Nested = 0;
						Parts[num6].Remain = Parts[num6].PartData.Quantity;
						dataGridView_1.Rows[num6].DefaultCellStyle.ForeColor = Color.Black;
					}
				}
				if (text == toolStripMenuItem_14.Name && SelectedRowPart >= 0)
				{
					buNestingPart buNestingPart3 = new buNestingPart(Parts[SelectedRowPart]);
					buNestingPart3.PartData.Name = buNestingPart3.PartData.Name + "- [Mirror]";
					Point3D mirrorPoint = new Point3D(1.0, 0.0, 0.0);
					buCall.buVector5_0.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buNestingPart3.EntitiesGroup);
					buCall.buNestingCalc_0.GetAvailableNestingPartID(Parts, ref buNestingPart3.ID);
					Parts.Add(buNestingPart3);
					Image Img3 = null;
					PartPointsToImage(buNestingPart3, Settings.Draw.GridPartSheetPreviewWidth, Settings.Draw.GridPartSheetHeight, ref Img3);
					dataGridView_1.Rows.Add(Class186.smethod_486(int_4: Parts.Count, bool_0: buNestingPart3.Enable, string_1: buNestingPart3.PartData.Name, double_1: buNestingPart3.PartData.Width, double_0: buNestingPart3.PartData.Height, int_0: buNestingPart3.PartData.Quantity, int_1: buNestingPart3.Nested, int_2: buNestingPart3.Remain, int_3: buNestingPart3.PartData.Priority, enum_0: (Enum)buNestingPart3.PartData.Rotation, bool_1: buNestingPart3.PartData.Mirror, string_0: buNestingPart3.FileName, string_2: buNestingPart3.PartData.ItemNo, string_4: buNestingPart3.PartData.Other, string_3: buNestingPart3.PartData.Aux, image_0: Img3, f_NestSheetPartList_0: this));
					dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
					dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Height = Settings.Draw.GridPartSheetHeight;
				}
				if (text == toolStripMenuItem_15.Name && SelectedRowPart >= 0)
				{
					buNestingPart buNestingPart4 = new buNestingPart(Parts[SelectedRowPart]);
					buNestingPart4.PartData.Name = buNestingPart4.PartData.Name + "- [Mirror]";
					Point3D mirrorPoint2 = new Point3D(0.0, 1.0, 0.0);
					buCall.buVector5_0.Mirror(new Point3D(), mirrorPoint2, Plane.XY, ref buNestingPart4.EntitiesGroup);
					buCall.buNestingCalc_0.GetAvailableNestingPartID(Parts, ref buNestingPart4.ID);
					Parts.Add(buNestingPart4);
					Image Img4 = null;
					PartPointsToImage(buNestingPart4, Settings.Draw.GridPartSheetPreviewWidth, Settings.Draw.GridPartSheetHeight, ref Img4);
					dataGridView_1.Rows.Add(Class186.smethod_486(int_4: Parts.Count, bool_0: buNestingPart4.Enable, string_1: buNestingPart4.PartData.Name, double_1: buNestingPart4.PartData.Width, double_0: buNestingPart4.PartData.Height, int_0: buNestingPart4.PartData.Quantity, int_1: buNestingPart4.Nested, int_2: buNestingPart4.Remain, int_3: buNestingPart4.PartData.Priority, enum_0: (Enum)buNestingPart4.PartData.Rotation, bool_1: buNestingPart4.PartData.Mirror, string_0: buNestingPart4.FileName, string_2: buNestingPart4.PartData.ItemNo, string_4: buNestingPart4.PartData.Other, string_3: buNestingPart4.PartData.Aux, image_0: Img4, f_NestSheetPartList_0: this));
					dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
					dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Height = Settings.Draw.GridPartSheetHeight;
				}
				if (text == toolStripMenuItem_12.Name)
				{
					SendToCadEntities.Clear();
					double num7 = 0.0;
					double dx = 0.0;
					double num8 = double.MinValue;
					int num9 = 0;
					int num10 = 0;
					for (int num11 = 0; num11 <= Parts.Count - 1; num11++)
					{
						if (Parts[num11].Enable && Parts[num11].PartData.Width > num8)
						{
							num8 = Parts[num11].PartData.Width;
						}
					}
					for (int num12 = 0; num12 <= Parts.Count - 1; num12++)
					{
						if (Parts[num12].Enable)
						{
							List<Entity> copiedEntity5 = new List<Entity>();
							buEntity.Copy(Parts[num12].EntitiesGroup, ref copiedEntity5);
							for (int num13 = 0; num13 <= copiedEntity5.Count - 1; num13++)
							{
								copiedEntity5[num13].Translate(dx, num7);
								SendToCadEntities.Add(copiedEntity5[num13]);
							}
							num7 = num7 + Parts[num12].PartData.Height + 20.0;
							num9++;
							if (num9 >= 10)
							{
								num9 = 0;
								num10++;
								num7 = 0.0;
								dx = num8 * (double)num10;
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
				if (text == toolStripMenuItem_9.Name)
				{
					DialogBoxInput dialogBoxInput2 = new DialogBoxInput();
					dialogBoxInput2.ValueCaption = "Count";
					dialogBoxInput2.FormCaption = "Set Part Count";
					dialogBoxInput2.ShowDialog();
					if (dialogBoxInput2.Result == DialogResult.OK)
					{
						for (int num14 = dataGridView_1.Rows.Count - 1; num14 >= 0; num14--)
						{
							dataGridView_1.Rows[num14].Cells[6].Value = Convert.ToInt32(dialogBoxInput2.Value);
							Parts[num14].PartData.Quantity = Convert.ToInt32(dialogBoxInput2.Value);
						}
					}
				}
				if (text == toolStripMenuItem_16.Name)
				{
					DialogBoxInput dialogBoxInput3 = new DialogBoxInput();
					dialogBoxInput3.ValueCaption = "Addtional Rotation";
					dialogBoxInput3.FormCaption = "Degree";
					dialogBoxInput3.ShowDialog();
					if (dialogBoxInput3.Result == DialogResult.OK)
					{
						for (int num15 = dataGridView_1.Rows.Count - 1; num15 >= 0; num15--)
						{
							Parts[num15].PartData.AdditionalRotation = Convert.ToDouble(dialogBoxInput3.Value);
						}
					}
				}
				if (text == toolStripMenuItem_3.Name)
				{
					for (int num16 = dataGridView_1.Rows.Count - 1; num16 >= 0; num16--)
					{
						dataGridView_1.Rows[num16].Cells[1].Value = true;
						Parts[num16].Enable = true;
					}
				}
				if (text == toolStripMenuItem_4.Name)
				{
					for (int num17 = dataGridView_1.Rows.Count - 1; num17 >= 0; num17--)
					{
						dataGridView_1.Rows[num17].Cells[1].Value = false;
						Parts[num17].Enable = false;
					}
				}
				if (text == toolStripMenuItem_6.Name)
				{
					for (int num18 = 0; num18 <= dataGridView_1.Rows.Count - 1; num18++)
					{
						if (Convert.ToBoolean(dataGridView_1.Rows[num18].Cells[1].Value))
						{
							Parts[num18].PartData.Rotation = nestPartRotateType.Fixed0;
							dataGridView_1.Rows[num18].Cells[10].Value = nestPartRotateType.Fixed0;
						}
					}
				}
				if (text == toolStripMenuItem_5.Name)
				{
					for (int num19 = 0; num19 <= dataGridView_1.Rows.Count - 1; num19++)
					{
						if (Convert.ToBoolean(dataGridView_1.Rows[num19].Cells[0].Value))
						{
							Parts[num19].PartData.Rotation = nestPartRotateType.FreeRotate;
							dataGridView_1.Rows[num19].Cells[10].Value = nestPartRotateType.FreeRotate;
						}
					}
				}
				if (text == toolStripMenuItem_7.Name)
				{
					for (int num20 = 0; num20 <= dataGridView_1.Rows.Count - 1; num20++)
					{
						if (Convert.ToBoolean(dataGridView_1.Rows[num20].Cells[1].Value))
						{
							Parts[num20].PartData.Rotation = nestPartRotateType.Increment90;
							dataGridView_1.Rows[num20].Cells[10].Value = nestPartRotateType.Increment90;
						}
					}
				}
				if (text == toolStripMenuItem_8.Name)
				{
					for (int num21 = 0; num21 <= dataGridView_1.Rows.Count - 1; num21++)
					{
						if (Convert.ToBoolean(dataGridView_1.Rows[num21].Cells[1].Value))
						{
							Parts[num21].PartData.Rotation = nestPartRotateType.Increment180;
							dataGridView_1.Rows[num21].Cells[10].Value = nestPartRotateType.Increment180;
						}
					}
				}
				if (text == toolStripMenuItem_11.Name)
				{
					List<buNestingPart> list = new List<buNestingPart>();
					for (int num22 = 0; num22 <= Parts.Count - 1; num22++)
					{
						buNestingPart NewPart = new buNestingPart();
						Point3D MinPoint = new Point3D();
						Point3D MaxPoint = new Point3D();
						buCall.buVector5_0.BoxSizeCalculate(Parts[num22].EntitiesGroup, ref MinPoint, ref MaxPoint);
						double num23 = MaxPoint.X - MinPoint.X;
						double num24 = MaxPoint.Y - MinPoint.Y;
						if (num23 > 0.0 && num24 > 0.0)
						{
							CreatPartAsRectanlge(num23, num24, Parts[num22], ref NewPart);
							buNestingPart buNestingPart5 = new buNestingPart(NewPart);
							buCall.buNestingCalc_0.GetAvailableNestingPartID(Parts, ref buNestingPart5.ID);
							Parts[num22] = new buNestingPart(buNestingPart5);
							list.Add(buNestingPart5);
						}
					}
					Init(1);
				}
				if (text == toolStripMenuItem_10.Name && Parts.Count > 0)
				{
					SaveFileDialog saveFileDialog2 = new SaveFileDialog();
					saveFileDialog2.InitialDirectory = SaveFileFolder;
					saveFileDialog2.Filter = SaveFileExtender;
					saveFileDialog2.FilterIndex = SaveFileExtensionIndex;
					if (saveFileDialog2.ShowDialog() == DialogResult.OK)
					{
						FileInfo fileInfo3 = new FileInfo(saveFileDialog2.FileName);
						SaveFileFolder = buFile5.GetPath(saveFileDialog2.FileName);
						if (fileInfo3.Extension == ".dxf")
						{
							for (int num25 = 0; num25 <= Parts.Count - 1; num25++)
							{
								if (Parts[num25].Enable)
								{
									string text3 = Parts[num25].PartData.Name.Trim();
									if (text3.Length == 0)
									{
										text3 = "Part" + (num25 + 1);
									}
									string fileName2 = buFile5.GetPath(saveFileDialog2.FileName) + "\\" + buFile5.getFileNameWithoutExtension(saveFileDialog2.FileName) + "_" + (num25 + 1) + "_" + text3 + "_" + Parts[num25].PartData.Quantity + fileInfo3.Extension;
									List<Entity> copiedEntity6 = new List<Entity>();
									buEntity.Copy(Parts[num25].EntitiesGroup, ref copiedEntity6);
									buFile5.SaveDxfDwg(copiedEntity6, fileName2);
								}
							}
						}
					}
				}
				if (text == button_10.Name)
				{
					SaveFileDialog saveFileDialog3 = new SaveFileDialog();
					saveFileDialog3.InitialDirectory = SaveFileFolder;
					saveFileDialog3.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
					saveFileDialog3.FilterIndex = 1;
					if (saveFileDialog3.ShowDialog() == DialogResult.OK)
					{
						SaveFileFolder = buFile5.GetPath(saveFileDialog3.FileName);
						buFile5.bunesting bunesting = new buFile5.bunesting();
						bunesting.SaveNesting(saveFileDialog3.FileName, Parts, Sheets, Settings);
					}
				}
				if (text == button_11.Name)
				{
					OpenFileDialog openFileDialog2 = new OpenFileDialog();
					openFileDialog2.InitialDirectory = SaveFileFolder;
					openFileDialog2.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
					openFileDialog2.FilterIndex = 1;
					if (openFileDialog2.ShowDialog() == DialogResult.OK)
					{
						SaveFileFolder = buFile5.GetPath(openFileDialog2.FileName);
						buFile5.bunesting bunesting2 = new buFile5.bunesting();
						bunesting2.OpenNesting(openFileDialog2.FileName, ref Parts, ref Sheets);
						Init(tabControl_0.SelectedIndex);
					}
				}
				if (text == button_12.Name)
				{
					base.Visible = false;
					PropertiesForm.Result = DialogResult.Cancel;
				}
				if (text == button_13.Name)
				{
					Settings.PartSettings.Multiply = (int)numericUpDown_0.Value;
					base.Visible = false;
					PropertiesForm.Result = DialogResult.OK;
				}
				return;
			}
			if (radioButton_5.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
			{
				Parts.Clear();
				dataGridView_1.Rows.Clear();
			}
			if (radioButton_3.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
			{
				for (int num26 = dataGridView_1.Rows.Count - 1; num26 >= 0; num26--)
				{
					if (Convert.ToBoolean(dataGridView_1.Rows[num26].Cells[1].Value))
					{
						dataGridView_1.Rows.RemoveAt(num26);
						Parts.RemoveAt(num26);
					}
				}
			}
			if (radioButton_4.Checked && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes && ((SelectedRowPart >= 0) & (SelectedRowPart <= Parts.Count - 1)))
			{
				dataGridView_1.Rows.RemoveAt(SelectedRowPart);
				Parts.RemoveAt(SelectedRowPart);
			}
			GetInfo();
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
		for (int num27 = dataGridView_0.Rows.Count - 1; num27 >= 0; num27--)
		{
			if (Convert.ToBoolean(dataGridView_0.Rows[num27].Cells[1].Value))
			{
				dataGridView_0.Rows.RemoveAt(num27);
				Sheets.RemoveAt(num27);
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
				double num = 0.0;
				List<Point3D> copiedPoint = new List<Point3D>();
				num = Sheets[int_0].MaterialData.Width / 1000.0 * (Sheets[int_0].MaterialData.Height / 1000.0);
				buVector5.Copy(Sheets[int_0].EntitiesGroup.Outside.Points, ref copiedPoint);
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
				double num2 = buCall.buVector5_0.PolygonArea(copiedPoint, Plane.XY);
				textBox_1.Text = num.ToString("f2");
				textBox_0.Text = (num2 / 1000000.0).ToString("f2");
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
				Class186.smethod_348(this);
				buCall.buVector5_0.DrawSheet(Sheets[e.RowIndex], Settings, ref design_0);
				dataGridView_0.CurrentCell = dataGridView_0.Rows[e.RowIndex].Cells[1];
			}
		}
		Class186.smethod_180(this);
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
		Class186.smethod_180(this);
	}

	internal void method_5(object sender, DataGridViewCellEventArgs e)
	{
		if (!((e.RowIndex >= 0) & (e.RowIndex <= Parts.Count - 1)))
		{
			return;
		}
		SelectedRowPart = e.RowIndex;
		SelectedColPart = e.ColumnIndex;
		if (((PartPreSelectedRow >= 0) & (SelectedColPart == 1)) && ((SelectedRowPart > PartPreSelectedRow) & ShiftPressed))
		{
			bool flag = Convert.ToBoolean(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			for (int i = PartPreSelectedRow; i <= SelectedRowPart; i++)
			{
				dataGridView_1.Rows[i].Cells[e.ColumnIndex].Value = !flag;
				Parts[e.RowIndex].Enable = flag;
			}
			ShiftPressed = false;
		}
		PartPreSelectedRow = e.RowIndex;
	}

	internal void method_6(object sender, DataGridViewCellEventArgs e)
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
				Class186.smethod_348(this);
				buCall.buVector5_0.DrawPart(Parts[e.RowIndex], Settings, ref design_0);
				dataGridView_1.CurrentCell = dataGridView_1.Rows[e.RowIndex].Cells[1];
			}
		}
		Class186.smethod_180(this);
	}

	internal void method_7(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
		{
			if ((e.ColumnIndex == 1) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].Enable = Convert.ToBoolean(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 2) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Name = Convert.ToString(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 4) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Width = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
				buNestingPart Part = Parts[e.RowIndex];
				buCall.buNestingCalc_0.PartRectangle(Part.PartData.Width, Part.PartData.Height, ref Part);
				buCall.buVector5_0.DrawPart(Parts[e.RowIndex], Settings, ref design_0);
			}
			if ((e.ColumnIndex == 5) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Height = Convert.ToDouble(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
				buNestingPart Part2 = Parts[e.RowIndex];
				buCall.buNestingCalc_0.PartRectangle(Part2.PartData.Width, Part2.PartData.Height, ref Part2);
				buCall.buVector5_0.DrawPart(Parts[e.RowIndex], Settings, ref design_0);
			}
			if ((e.ColumnIndex == 6) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Quantity = Convert.ToInt32(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
				Parts[e.RowIndex].Remain = Parts[e.RowIndex].PartData.Quantity - Parts[e.RowIndex].Nested;
			}
			if ((e.ColumnIndex == 9) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Priority = Convert.ToInt32(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 11) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Mirror = Convert.ToBoolean(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 14) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.ItemNo = Convert.ToString(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 15) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Other = Convert.ToString(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if ((e.ColumnIndex == 16) & (e.RowIndex <= Parts.Count - 1))
			{
				Parts[e.RowIndex].PartData.Aux = Convert.ToString(dataGridView_1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
		}
		Class186.smethod_180(this);
	}

	internal void method_8(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= Parts.Count - 1))
		{
			SelectedRowPart = e.RowIndex;
			buCall.buVector5_0.DrawPart(Parts[SelectedRowPart], Settings, ref design_0);
			if ((SelectedRowPart >= 0) & (SelectedRowPart <= Parts.Count - 1))
			{
				double num = 0.0;
				double num2 = 0.0;
				List<Point3D> copiedPoint = new List<Point3D>();
				num += Parts[SelectedRowPart].PartData.Width / 1000.0 * (Parts[SelectedRowPart].PartData.Height / 1000.0) * Convert.ToDouble(Parts[SelectedRowPart].PartData.Quantity);
				buVector5.Copy(Parts[SelectedRowPart].EntitiesGroup.Outside.Points, ref copiedPoint);
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
				_ = Parts[SelectedRowPart].Area;
				double num3 = buCall.buVector5_0.PolygonArea(copiedPoint, Plane.XY);
				num2 += num3 / 1000000.0 * Convert.ToDouble(Parts[SelectedRowPart].PartData.Quantity);
				textBox_3.Text = num.ToString("f2");
				textBox_2.Text = num2.ToString("f2");
			}
		}
	}

	internal void method_9(object sender, KeyEventArgs e)
	{
		ShiftPressed = e.Shift;
	}

	internal void method_10(object sender, KeyEventArgs e)
	{
		ShiftPressed = false;
	}

	public void AddPartFromEntities(List<eEntities> Entities)
	{
	}

	public void AddPartFromCsvFile(nestCsvPartImportType Mode, string FileName)
	{
		if (Mode == nestCsvPartImportType.Mode1_ItemNo)
		{
			FileInfo fileInfo = new FileInfo(FileName);
			List<string> StringList = new List<string>();
			if (fileInfo.Exists)
			{
				buFile5.OpenFromFile(FileName, ref StringList);
			}
		}
		if (Mode == nestCsvPartImportType.Mode2_NameWidthHeightCount)
		{
			FileInfo fileInfo2 = new FileInfo(FileName);
			List<string> StringList2 = new List<string>();
			if (fileInfo2.Exists)
			{
				buFile5.OpenFromFile(FileName, ref StringList2);
			}
		}
		if (Mode == nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount)
		{
			FileInfo fileInfo3 = new FileInfo(FileName);
			List<string> StringList3 = new List<string>();
			if (fileInfo3.Exists)
			{
				buFile5.OpenFromFile(FileName, ref StringList3);
			}
		}
	}

	public void GetInfo()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i <= Parts.Count - 1; i++)
		{
			if (Parts[i].Enable)
			{
				num2 += Parts[i].PartData.Quantity - Parts[i].Nested;
			}
			num += Parts[i].PartData.Quantity - Parts[i].Nested;
		}
		lst_info.Items.Clear();
		lst_info.Items.Add(buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Count + " : " + num);
		lst_info.Items.Add(buLangTranslate.preDef.Selected + " " + buLangTranslate.preDef.Count + " : " + num2);
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
		if (Sheet.EntitiesGroup.Inside != null)
		{
			for (int j = 0; j <= Sheet.EntitiesGroup.Inside.Count - 1; j++)
			{
				for (int k = 0; k <= Sheet.EntitiesGroup.Inside[j].Entities.Count - 1; k++)
				{
					eEntities item2 = new eEntities();
					buConversion5.buEntityToEEntities(Sheet.EntitiesGroup.Inside[j].Entities[k], Sheet.EntitiesGroup.Inside[j].Entities[k].Color, ref item2);
					buViewer2.Entities.Add(item2);
				}
			}
		}
		if (Sheet.EntitiesGroup.OpenEntities != null)
		{
			for (int l = 0; l <= Sheet.EntitiesGroup.OpenEntities.Count - 1; l++)
			{
				for (int m = 0; m <= Sheet.EntitiesGroup.OpenEntities[l].Entities.Count - 1; m++)
				{
					eEntities item3 = new eEntities();
					buConversion5.buEntityToEEntities(Sheet.EntitiesGroup.OpenEntities[l].Entities[m], Sheet.EntitiesGroup.OpenEntities[l].Entities[m].Color, ref item3);
					buViewer2.Entities.Add(item3);
				}
			}
		}
		buViewer2.DrawEntities();
		buViewer2.ZoomFit();
		buViewer2.ZoomOut();
		Img = buViewer2.Bmp;
	}

	public void PartPointsToImage(buNestingPart Part, int Width, int Height, ref Image Img)
	{
		buViewer buViewer2 = new buViewer();
		buViewer2.Width = Width;
		buViewer2.Height = Height;
		List<eEntities> copiedEntity = new List<eEntities>();
		buConversion5.buEntityGroupToEEntities(Part.EntitiesGroup, ref copiedEntity);
		buViewer2.BackColor = Settings.PartSettings.PartListPreviewBackColor;
		buViewer2.Entities.Clear();
		buViewer2.Entities.AddRange(copiedEntity);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
