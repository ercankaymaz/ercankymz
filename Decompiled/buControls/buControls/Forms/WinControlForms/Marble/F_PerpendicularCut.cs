using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.Forms.buControlForms.Marble;
using buCore;
using buCore.AppCalc;
using ns27;

namespace buControls.Forms.WinControlForms.Marble;

public class F_PerpendicularCut : Form
{
	public static List<string> Captions = new List<string>();

	public marblePerpendicularCut varPerpendicularCut = new marblePerpendicularCut();

	public marbleOperation varOperations = new marbleOperation();

	public List<List<eEntities>> CalculatedEntities = new List<List<eEntities>>();

	public List<Quad3D> QualList = new List<Quad3D>();

	public MaterialBase activeMaterial = new MaterialBase();

	public DialogResult Result = DialogResult.No;

	public bool AskTabChangeQuestions = false;

	public bool ReverseAngleA = false;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;

	public string pathFiles = Application.StartupPath;

	public bool OfflineMode = false;

	[CompilerGenerated]
	private MarblePerpendicularModeEventHandler marblePerpendicularModeEventHandler_0;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_0;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_1;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_2;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_3;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public List<marbleCutItems> listItemsHor = new List<marbleCutItems>();

	public List<marbleCutItems> listItemsVer = new List<marbleCutItems>();

	internal bool bool_0 = false;

	private bool bool_1 = false;

	private bool bool_2 = false;

	public Pnt6D StartPosVer = new Pnt6D();

	public Pnt6D EndPosVer = new Pnt6D();

	public Pnt6D StartPosHor = new Pnt6D();

	public Pnt6D EndPosHor = new Pnt6D();

	private int int_0 = -1;

	private int int_1 = -1;

	private int int_2 = -1;

	private int int_3 = -1;

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal ImageList imageList_0;

	internal Panel panel_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal PictureBox pictureBox_0;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal PictureBox pictureBox_1;

	internal Button button_0;

	internal Panel panel_1;

	internal Button button_1;

	internal Button button_2;

	internal CheckBox checkBox_0;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Label label_6;

	internal NumericUpDown numericUpDown_6;

	internal Button button_9;

	internal Button button_10;

	internal Panel panel_2;

	internal Label label_7;

	internal NumericUpDown numericUpDown_7;

	internal Label label_8;

	internal NumericUpDown numericUpDown_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_9;

	internal Label label_10;

	internal NumericUpDown numericUpDown_10;

	internal PictureBox pictureBox_2;

	internal NumericUpDown numericUpDown_11;

	internal NumericUpDown numericUpDown_12;

	internal Button button_11;

	internal Button button_12;

	internal Button button_13;

	internal DataGridView dataGridView_0;

	internal Button button_14;

	internal Label label_11;

	internal NumericUpDown numericUpDown_13;

	internal Button button_15;

	internal Button button_16;

	internal Panel panel_3;

	internal Label label_12;

	internal NumericUpDown numericUpDown_14;

	internal Label label_13;

	internal NumericUpDown numericUpDown_15;

	internal Label label_14;

	internal NumericUpDown numericUpDown_16;

	internal Label label_15;

	internal NumericUpDown numericUpDown_17;

	internal PictureBox pictureBox_3;

	internal NumericUpDown numericUpDown_18;

	internal NumericUpDown numericUpDown_19;

	internal Button button_17;

	internal Button button_18;

	internal Button button_19;

	internal DataGridView dataGridView_1;

	internal CheckBox checkBox_1;

	internal Label label_16;

	internal Label label_17;

	public event MarblePerpendicularModeEventHandler TabChanged
	{
		[CompilerGenerated]
		add
		{
			MarblePerpendicularModeEventHandler marblePerpendicularModeEventHandler = marblePerpendicularModeEventHandler_0;
			MarblePerpendicularModeEventHandler marblePerpendicularModeEventHandler2;
			do
			{
				marblePerpendicularModeEventHandler2 = marblePerpendicularModeEventHandler;
				MarblePerpendicularModeEventHandler value2 = (MarblePerpendicularModeEventHandler)Delegate.Combine(marblePerpendicularModeEventHandler2, value);
				marblePerpendicularModeEventHandler = Interlocked.CompareExchange(ref marblePerpendicularModeEventHandler_0, value2, marblePerpendicularModeEventHandler2);
			}
			while ((object)marblePerpendicularModeEventHandler != marblePerpendicularModeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MarblePerpendicularModeEventHandler marblePerpendicularModeEventHandler = marblePerpendicularModeEventHandler_0;
			MarblePerpendicularModeEventHandler marblePerpendicularModeEventHandler2;
			do
			{
				marblePerpendicularModeEventHandler2 = marblePerpendicularModeEventHandler;
				MarblePerpendicularModeEventHandler value2 = (MarblePerpendicularModeEventHandler)Delegate.Remove(marblePerpendicularModeEventHandler2, value);
				marblePerpendicularModeEventHandler = Interlocked.CompareExchange(ref marblePerpendicularModeEventHandler_0, value2, marblePerpendicularModeEventHandler2);
			}
			while ((object)marblePerpendicularModeEventHandler != marblePerpendicularModeEventHandler2);
		}
	}

	public event MarbleSetStartPositionHandler SetStartPositionHor
	{
		[CompilerGenerated]
		add
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_0;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Combine(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_0, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_0;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Remove(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_0, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
	}

	public event MarbleSetStartPositionHandler SetEndPositionHor
	{
		[CompilerGenerated]
		add
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_1;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Combine(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_1, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_1;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Remove(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_1, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
	}

	public event MarbleSetStartPositionHandler SetStartPositionVer
	{
		[CompilerGenerated]
		add
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_2;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Combine(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_2, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_2;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Remove(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_2, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
	}

	public event MarbleSetStartPositionHandler SetEndPositionVer
	{
		[CompilerGenerated]
		add
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_3;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Combine(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_3, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MarbleSetStartPositionHandler marbleSetStartPositionHandler = marbleSetStartPositionHandler_3;
			MarbleSetStartPositionHandler marbleSetStartPositionHandler2;
			do
			{
				marbleSetStartPositionHandler2 = marbleSetStartPositionHandler;
				MarbleSetStartPositionHandler value2 = (MarbleSetStartPositionHandler)Delegate.Remove(marbleSetStartPositionHandler2, value);
				marbleSetStartPositionHandler = Interlocked.CompareExchange(ref marbleSetStartPositionHandler_3, value2, marbleSetStartPositionHandler2);
			}
			while ((object)marbleSetStartPositionHandler != marbleSetStartPositionHandler2);
		}
	}

	public event EventHandler ShowJogPage
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public F_PerpendicularCut()
	{
		Class76.smethod_326(this);
	}

	public void Init()
	{
		try
		{
			bool_0 = false;
			bool_1 = false;
			bool_2 = false;
			button_9.BackColor = Color.Red;
			button_8.BackColor = Color.Red;
			button_15.BackColor = Color.Red;
			button_14.BackColor = Color.Red;
			checkBox_1.Checked = varOperations.VerticalFirst;
			checkBox_0.Checked = varOperations.ApplySurfaceReadData;
			numericUpDown_5.Value = (decimal)varOperations.TargetZ;
			numericUpDown_6.Value = (decimal)varPerpendicularCut.CutHorizontalLength;
			numericUpDown_13.Value = (decimal)varPerpendicularCut.CutVerticalLength;
			numericUpDown_4.Value = (decimal)varOperations.AxisValues.X;
			numericUpDown_3.Value = (decimal)varOperations.AxisValues.Y;
			numericUpDown_2.Value = (decimal)varOperations.AxisValues.Z;
			numericUpDown_1.Value = (decimal)varOperations.AxisValues.A;
			numericUpDown_0.Value = (decimal)varOperations.AxisValues.C;
			dataGridView_0.RowHeadersVisible = false;
			dataGridView_0.ColumnHeadersVisible = false;
			dataGridView_0.AllowUserToAddRows = false;
			dataGridView_0.AllowUserToResizeColumns = false;
			dataGridView_0.AllowUserToResizeRows = false;
			dataGridView_0.Columns.Clear();
			dataGridView_0.Rows.Clear();
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.Width = 150;
			dataGridViewColumn.HeaderText = "Length";
			dataGridViewColumn.Name = "Length";
			dataGridViewColumn.ReadOnly = false;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.HeaderText = "Count";
			dataGridViewColumn2.Name = "Count";
			dataGridViewColumn2.Width = 150;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.HeaderText = "Start Angle";
			dataGridViewColumn3.Name = "Start Angle";
			dataGridViewColumn3.Width = 150;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.Width = dataGridView_0.Width - dataGridViewColumn.Width - dataGridViewColumn2.Width - dataGridViewColumn3.Width - 25;
			dataGridViewColumn4.HeaderText = "End Angle";
			dataGridViewColumn4.Name = "End Angle";
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn4.ReadOnly = false;
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			int count = listItemsHor.Count;
			for (int i = 0; i <= count - 1; i++)
			{
				Class76.smethod_442(listItemsHor[i], false, this);
			}
			dataGridView_1.RowHeadersVisible = false;
			dataGridView_1.ColumnHeadersVisible = false;
			dataGridView_1.AllowUserToAddRows = false;
			dataGridView_1.AllowUserToResizeColumns = false;
			dataGridView_1.AllowUserToResizeRows = false;
			dataGridView_1.Columns.Clear();
			dataGridView_1.Rows.Clear();
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.Width = 150;
			dataGridViewColumn5.HeaderText = "Length";
			dataGridViewColumn5.Name = "Length";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.HeaderText = "Count";
			dataGridViewColumn6.Name = "Count";
			dataGridViewColumn6.Width = 150;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			dataGridViewColumn7.HeaderText = "Start Angle";
			dataGridViewColumn7.Name = "Start Angle";
			dataGridViewColumn7.Width = 150;
			dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			dataGridViewColumn8.Width = dataGridView_1.Width - dataGridViewColumn5.Width - dataGridViewColumn6.Width - dataGridViewColumn7.Width - 25;
			dataGridViewColumn8.HeaderText = "End Angle";
			dataGridViewColumn8.Name = "End Angle";
			dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
			dataGridViewColumn8.ReadOnly = false;
			dataGridView_1.Columns.Add(dataGridViewColumn8);
			count = listItemsVer.Count;
			for (int j = 0; j <= count - 1; j++)
			{
				Class76.smethod_261(listItemsVer[j], false, this);
			}
			Class76.smethod_580(this);
			LoadLanguage();
			bool_0 = true;
		}
		catch (Exception mSException)
		{
			string text = "F_MultiCut";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 25)
			{
				Text = Captions[0];
				button_9.Text = Captions[1];
				button_15.Text = Captions[1];
				button_8.Text = Captions[2];
				button_14.Text = Captions[2];
				label_6.Text = Captions[24];
				label_11.Text = Captions[24];
				label_5.Text = Captions[23];
				button_6.Text = Captions[5];
				button_7.Text = Captions[6];
				button_0.Text = Captions[7];
				tabPage_0.Text = Captions[8];
				tabPage_1.Text = Captions[9];
				label_7.Text = Captions[10];
				label_12.Text = Captions[10];
				label_10.Text = Captions[11];
				label_15.Text = Captions[11];
				label_9.Text = Captions[12];
				label_14.Text = Captions[12];
				label_8.Text = Captions[13];
				label_13.Text = Captions[13];
				button_10.Text = Captions[14];
				button_16.Text = Captions[14];
				button_4.Text = Captions[16];
				button_5.Text = Captions[17];
				label_16.Text = Captions[18];
				label_17.Text = Captions[19];
				button_2.Text = Captions[20];
				button_1.Text = Captions[21];
				checkBox_0.Text = Captions[22];
				button_3.Text = Captions[22];
				checkBox_1.Text = Captions[25];
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_4.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathFiles;
			saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathFiles = buFile.GetPath(saveFileDialog.FileName);
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i <= listItemsHor.Count - 1; i++)
				{
					arrayList.AddRange(listItemsHor[i].ToDefAll("Horizontal", 2, SerilizationMode.MultiLine).ToArray());
				}
				for (int j = 0; j <= listItemsVer.Count - 1; j++)
				{
					arrayList.AddRange(listItemsVer[j].ToDefAll("Vertical", 2, SerilizationMode.MultiLine).ToArray());
				}
				buFile.SaveToFile(arrayList, saveFileDialog.FileName);
			}
		}
		if (control.Name == button_5.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = pathFiles;
			openFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
			openFileDialog.FilterIndex = 1;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				ArrayList StringList = new ArrayList();
				pathFiles = buFile.GetPath(openFileDialog.FileName);
				buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
				List<List<string>> CalcList = new List<List<string>>();
				listItemsHor.Clear();
				listItemsHor = new List<marbleCutItems>();
				listItemsVer.Clear();
				listItemsVer = new List<marbleCutItems>();
				buString.ListToSpecificList("<marbleCutItemsHorizontal>", "</marbleCutItemsHorizontal>", AddStartEndKey: true, StringList, ref CalcList);
				for (int k = 0; k <= CalcList.Count - 1; k++)
				{
					marbleCutItems marbleCutItems2 = new marbleCutItems();
					buSerilization.Decode(CalcList[k], "Horizontal", SerilizationMode.MultiLine, marbleCutItems2);
					listItemsHor.Add(marbleCutItems2);
				}
				CalcList = new List<List<string>>();
				buString.ListToSpecificList("<marbleCutItemsVertical>", "</marbleCutItemsVertical>", AddStartEndKey: true, StringList, ref CalcList);
				for (int l = 0; l <= CalcList.Count - 1; l++)
				{
					marbleCutItems marbleCutItems3 = new marbleCutItems();
					buSerilization.Decode(CalcList[l], "Vertical", SerilizationMode.MultiLine, marbleCutItems3);
					listItemsVer.Add(marbleCutItems3);
				}
				Init();
			}
		}
		if (control.Name == button_3.Name)
		{
			OpenFileDialog openFileDialog2 = new OpenFileDialog();
			openFileDialog2.InitialDirectory = pathFiles;
			openFileDialog2.Filter = "Surface Data File (*.csv)|*.csv";
			openFileDialog2.FilterIndex = 1;
			openFileDialog2.Multiselect = false;
			if (openFileDialog2.ShowDialog() == DialogResult.OK)
			{
				List<Pnt3D> pntTeachList = new List<Pnt3D>();
				buFile.OpenSurfaceReadFile(openFileDialog2.FileName, ref pntTeachList);
				if (pntTeachList.Count > 2)
				{
					buCamCalc.pntTeachGrids.Clear();
					SurfaceReadGridData surfaceReadGridData = new SurfaceReadGridData();
					surfaceReadGridData.GridDistance = new Pnt3D(1.0, 1.0);
					buControlCoreClass.cVector.CreateSurfaceGridFromTeachFile(surfaceReadGridData, pntTeachList, ref buCamCalc.pntTeachGrids);
				}
			}
		}
		if (control.Name == button_11.Name && ((int_0 >= 0) & (int_0 <= listItemsHor.Count - 1)) && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[4]) == DialogResult.Yes)
		{
			listItemsHor.RemoveAt(int_0);
			dataGridView_0.Rows.RemoveAt(int_0);
			int_0--;
			if (int_0 < 0)
			{
				int_0 = 0;
			}
			if (dataGridView_0.Rows.Count == 0)
			{
				int_0 = -1;
			}
			Class76.smethod_580(this);
		}
		if (control.Name == button_17.Name && ((int_2 >= 0) & (int_2 <= listItemsVer.Count - 1)) && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[4]) == DialogResult.Yes)
		{
			listItemsVer.RemoveAt(int_2);
			dataGridView_1.Rows.RemoveAt(int_2);
			int_2--;
			if (int_2 < 0)
			{
				int_2 = 0;
			}
			if (dataGridView_1.Rows.Count == 0)
			{
				int_2 = -1;
			}
			Class76.smethod_580(this);
		}
		if (control.Name == button_2.Name)
		{
			F_ItemCutCamParameters f_ItemCutCamParameters = new F_ItemCutCamParameters();
			f_ItemCutCamParameters.Value = new marbleOperation(varOperations);
			f_ItemCutCamParameters.Init();
			f_ItemCutCamParameters.StartPosition = FormStartPosition.CenterParent;
			f_ItemCutCamParameters.ShowDialog(this);
			if (f_ItemCutCamParameters.Result == DialogResult.OK)
			{
				varOperations = new marbleOperation(f_ItemCutCamParameters.Value);
			}
		}
		if (control.Name == button_6.Name && eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
		if (control.Name == button_7.Name)
		{
			Class76.smethod_52(this);
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
			Result = DialogResult.OK;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_16.Name)
		{
			if (buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[5]) == DialogResult.Yes)
			{
				for (int num = dataGridView_1.Rows.Count - 1; num >= 0; num--)
				{
					listItemsVer.RemoveAt(num);
					dataGridView_1.Rows.RemoveAt(num);
				}
			}
			int_2 = -1;
			Class76.smethod_580(this);
		}
		if (control.Name == button_10.Name)
		{
			if (buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[5]) == DialogResult.Yes)
			{
				for (int num2 = dataGridView_0.Rows.Count - 1; num2 >= 0; num2--)
				{
					listItemsHor.RemoveAt(num2);
					dataGridView_0.Rows.RemoveAt(num2);
				}
			}
			int_0 = -1;
			Class76.smethod_580(this);
		}
		if (control.Name == button_12.Name && ((int_0 >= 0) & (int_0 < dataGridView_0.Rows.Count - 1)))
		{
			if (int_1 < 0)
			{
				int_1 = 0;
			}
			int_0++;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[int_0].Cells[int_1];
		}
		if (control.Name == button_18.Name && ((int_2 >= 0) & (int_2 < dataGridView_1.Rows.Count - 1)))
		{
			if (int_3 < 0)
			{
				int_3 = 0;
			}
			int_2++;
			dataGridView_1.CurrentCell = dataGridView_1.Rows[int_2].Cells[int_3];
		}
		if (control.Name == button_13.Name && int_0 > 0)
		{
			if (int_1 < 0)
			{
				int_1 = 0;
			}
			int_0--;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[int_0].Cells[int_1];
		}
		if (control.Name == button_19.Name && int_2 > 0)
		{
			if (int_3 < 0)
			{
				int_3 = 0;
			}
			int_2--;
			dataGridView_1.CurrentCell = dataGridView_1.Rows[int_2].Cells[int_3];
		}
		if (control.Name == button_9.Name)
		{
			button_9.BackColor = Color.Green;
			bool_2 = true;
			StartPosHor = new Pnt6D((double)numericUpDown_4.Value, (double)numericUpDown_3.Value, (double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0, (double)numericUpDown_0.Value);
			if (marbleSetStartPositionHandler_0 != null)
			{
				marbleSetStartPositionHandler_0(StartPosHor);
			}
		}
		if (control.Name == button_15.Name)
		{
			button_15.BackColor = Color.Green;
			bool_1 = true;
			StartPosVer = new Pnt6D((double)numericUpDown_4.Value, (double)numericUpDown_3.Value, (double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0, (double)numericUpDown_0.Value);
			if (marbleSetStartPositionHandler_2 != null)
			{
				marbleSetStartPositionHandler_2(StartPosVer);
			}
		}
		if (control.Name == button_8.Name && bool_2)
		{
			button_8.BackColor = Color.Green;
			EndPosHor = new Pnt6D((double)numericUpDown_4.Value, (double)numericUpDown_3.Value, (double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0, (double)numericUpDown_0.Value);
			numericUpDown_6.Value = (decimal)buControlCoreClass.cVector.Length3D(StartPosHor, EndPosHor);
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_1(EndPosHor);
			}
		}
		if (control.Name == button_14.Name && bool_1)
		{
			button_14.BackColor = Color.Green;
			EndPosVer = new Pnt6D((double)numericUpDown_4.Value, (double)numericUpDown_3.Value, (double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0, (double)numericUpDown_0.Value);
			numericUpDown_13.Value = (decimal)buControlCoreClass.cVector.Length3D(StartPosVer, EndPosVer);
			if (marbleSetStartPositionHandler_3 != null)
			{
				marbleSetStartPositionHandler_3(EndPosVer);
			}
		}
	}

	internal void method_2(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab)))
		{
			return;
		}
		int result = 0;
		int.TryParse(control.Tag.ToString(), out result);
		buControlCommands.FindNextControlByKey(panel_2.Controls, result, e.Shift);
		if (control.Name == numericUpDown_10.Name)
		{
			marbleCutItems marbleCutItems2 = new marbleCutItems();
			marbleCutItems2.Length = (double)numericUpDown_7.Value;
			marbleCutItems2.Count = (int)numericUpDown_8.Value;
			marbleCutItems2.StartAngle = (double)numericUpDown_9.Value;
			marbleCutItems2.EndAngle = (double)numericUpDown_10.Value;
			if ((marbleCutItems2.Length > 0.0) & (marbleCutItems2.Count > 0))
			{
				bool_0 = false;
				Class76.smethod_442(marbleCutItems2, true, this);
				bool_0 = true;
			}
		}
	}

	internal void method_3(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab)))
		{
			return;
		}
		int result = 0;
		int.TryParse(control.Tag.ToString(), out result);
		buControlCommands.FindNextControlByKey(panel_3.Controls, result, e.Shift);
		if (control.Name == numericUpDown_17.Name)
		{
			marbleCutItems marbleCutItems2 = new marbleCutItems();
			marbleCutItems2.Length = (double)numericUpDown_14.Value;
			marbleCutItems2.Count = (int)numericUpDown_15.Value;
			marbleCutItems2.StartAngle = (double)numericUpDown_16.Value;
			marbleCutItems2.EndAngle = (double)numericUpDown_17.Value;
			if ((marbleCutItems2.Length > 0.0) & (marbleCutItems2.Count > 0))
			{
				bool_0 = false;
				Class76.smethod_261(marbleCutItems2, true, this);
				bool_0 = true;
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (!AskTabChangeQuestions)
		{
			return;
		}
		if (tabControl_0.SelectedIndex == 0)
		{
			if (OfflineMode)
			{
				numericUpDown_0.Value = 0m;
			}
			if (marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(tabControl_0.SelectedIndex);
			}
		}
		if (tabControl_0.SelectedIndex == 1)
		{
			if (OfflineMode)
			{
				numericUpDown_0.Value = 90m;
			}
			if (marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(tabControl_0.SelectedIndex);
			}
		}
	}

	internal void method_5(object sender, DrawItemEventArgs e)
	{
		switch (e.Index)
		{
		case 0:
			e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
			break;
		case 1:
			e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
			break;
		}
		Rectangle bounds = e.Bounds;
		bounds.Inflate(-2, -2);
		e.Graphics.DrawString(tabControl_0.TabPages[e.Index].Text, Font, SystemBrushes.HighlightText, bounds);
	}

	internal void method_6(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 && ((int_0 >= 0) & (int_0 <= listItemsHor.Count - 1)))
		{
			listItemsHor[int_0].Length = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[0].Value);
			listItemsHor[int_0].Count = Convert.ToInt32(dataGridView_0.Rows[int_0].Cells[1].Value);
			listItemsHor[int_0].StartAngle = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[2].Value);
			listItemsHor[int_0].EndAngle = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[3].Value);
			Class76.smethod_580(this);
		}
	}

	internal void method_7(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
		int_1 = e.ColumnIndex;
	}

	internal void method_8(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 && ((int_2 >= 0) & (int_2 <= listItemsVer.Count - 1)))
		{
			listItemsVer[int_2].Length = Convert.ToDouble(dataGridView_1.Rows[int_2].Cells[0].Value);
			listItemsVer[int_2].Count = Convert.ToInt32(dataGridView_1.Rows[int_2].Cells[1].Value);
			listItemsVer[int_2].StartAngle = Convert.ToDouble(dataGridView_1.Rows[int_2].Cells[2].Value);
			listItemsVer[int_2].EndAngle = Convert.ToDouble(dataGridView_1.Rows[int_2].Cells[3].Value);
			Class76.smethod_580(this);
		}
	}

	internal void method_9(object sender, DataGridViewCellEventArgs e)
	{
		int_2 = e.RowIndex;
		int_3 = e.ColumnIndex;
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
