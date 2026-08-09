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
using buControls.Controls;
using buControls.Forms.buControlForms.Marble;
using buCore;
using buCore.AppCalc;
using ns27;

namespace buControls.Forms.WinControlForms.Marble;

public class F_MultiCut : Form
{
	public static List<string> Captions = new List<string>();

	public marbleMultiCut varMutliCut = new marbleMultiCut();

	public marbleOperation varOperations = new marbleOperation();

	public List<List<eEntities>> CalculatedEntities = new List<List<eEntities>>();

	public List<Quad3D> QualList = new List<Quad3D>();

	public MaterialBase activeMaterial = new MaterialBase();

	public DialogResult Result = DialogResult.No;

	public bool VerticalCut = false;

	public bool ReverseAngleA = false;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;

	public bool AskTabChangeQuestions = false;

	public string pathFiles = Application.StartupPath;

	public bool OfflineMode = false;

	[CompilerGenerated]
	private MarblePerpendicularModeEventHandler marblePerpendicularModeEventHandler_0;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_0;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public List<marbleCutItems> listItems = new List<marbleCutItems>();

	internal bool bool_0 = false;

	private bool bool_1 = false;

	private Pnt6D pnt6D_0 = new Pnt6D();

	private Pnt6D pnt6D_1 = new Pnt6D();

	private int int_0 = -1;

	private int int_1 = -1;

	internal IContainer icontainer_0 = null;

	internal DataGridView dataGridView_0;

	internal Button button_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal ImageList imageList_0;

	internal Panel panel_0;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal CheckBox checkBox_0;

	internal Button button_13;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal Panel panel_1;

	internal NumericUpDown numericUpDown_4;

	internal Label label_2;

	internal NumericUpDown numericUpDown_5;

	internal Label label_3;

	internal NumericUpDown numericUpDown_6;

	internal Label label_4;

	internal NumericUpDown numericUpDown_7;

	internal Label label_5;

	internal NumericUpDown numericUpDown_8;

	internal Label label_6;

	internal PictureBox pictureBox_2;

	internal NumericUpDown numericUpDown_9;

	internal NumericUpDown numericUpDown_10;

	internal NumericUpDown numericUpDown_11;

	internal NumericUpDown numericUpDown_12;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal PictureBox pictureBox_3;

	internal Panel panel_2;

	internal Button button_14;

	internal Button button_15;

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

	public event MarbleSetStartPositionHandler SetStartPosition
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

	public event MarbleSetStartPositionHandler SetEndPosition
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

	public F_MultiCut()
	{
		Class76.smethod_659(this);
	}

	public void Init()
	{
		try
		{
			bool_0 = false;
			bool_1 = false;
			button_0.BackColor = Color.Red;
			button_1.BackColor = Color.Red;
			if (varOperations.isVertical)
			{
				VerticalCut = true;
			}
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
			if (!VerticalCut)
			{
				button_2.BackColor = Color.Red;
				button_3.BackColor = Color.PaleTurquoise;
			}
			else
			{
				button_2.BackColor = Color.PaleTurquoise;
				button_3.BackColor = Color.Red;
			}
			numericUpDown_1.Value = (decimal)varOperations.TargetZ;
			numericUpDown_0.Value = (decimal)varOperations.CutLength;
			checkBox_0.Checked = varOperations.ApplySurfaceReadData;
			numericUpDown_8.Value = (decimal)varOperations.AxisValues.X;
			numericUpDown_7.Value = (decimal)varOperations.AxisValues.Y;
			numericUpDown_6.Value = (decimal)varOperations.AxisValues.Z;
			numericUpDown_5.Value = (decimal)varOperations.AxisValues.A;
			numericUpDown_4.Value = (decimal)varOperations.AxisValues.C;
			int count = listItems.Count;
			for (int i = 0; i <= count - 1; i++)
			{
				Class76.smethod_616(false, listItems[i], this);
			}
			Class76.smethod_262(this);
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
			if (Captions.Count > 22)
			{
				Text = Captions[0];
				button_0.Text = Captions[1];
				button_1.Text = Captions[2];
				label_0.Text = Captions[22];
				label_1.Text = Captions[21];
				button_9.Text = Captions[5];
				button_8.Text = Captions[6];
				button_12.Text = Captions[7];
				button_3.Text = Captions[8];
				button_2.Text = Captions[9];
				label_7.Text = Captions[10];
				label_8.Text = Captions[11];
				label_9.Text = Captions[12];
				label_10.Text = Captions[13];
				button_6.Text = Captions[14];
				button_11.Text = Captions[16];
				button_7.Text = Captions[17];
				button_13.Text = Captions[18];
				button_15.Text = Captions[19];
				button_10.Text = Captions[20];
				checkBox_0.Text = Captions[20];
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
		if (control.Name == button_11.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathFiles;
			saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathFiles = buFile.GetPath(saveFileDialog.FileName);
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i <= listItems.Count - 1; i++)
				{
					arrayList.AddRange(listItems[i].ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
				}
				buFile.SaveToFile(arrayList, saveFileDialog.FileName);
			}
		}
		if (control.Name == button_7.Name)
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
				listItems.Clear();
				listItems = new List<marbleCutItems>();
				buString.ListToSpecificList("<marbleCutItems>", "</marbleCutItems>", AddStartEndKey: true, StringList, ref CalcList);
				for (int j = 0; j <= CalcList.Count - 1; j++)
				{
					marbleCutItems marbleCutItems2 = new marbleCutItems();
					buSerilization.Decode(CalcList[j], "", SerilizationMode.MultiLine, marbleCutItems2);
					listItems.Add(marbleCutItems2);
				}
				Init();
			}
		}
		if (control.Name == button_10.Name)
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
		if (control.Name == button_6.Name && ((int_0 >= 0) & (int_0 <= listItems.Count - 1)) && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[4]) == DialogResult.Yes)
		{
			listItems.RemoveAt(int_0);
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
			Class76.smethod_262(this);
		}
		if (control.Name == button_3.Name)
		{
			button_2.BackColor = Color.Red;
			button_3.BackColor = Color.PaleTurquoise;
			VerticalCut = false;
			if (OfflineMode)
			{
				numericUpDown_4.Value = 0m;
			}
			if (AskTabChangeQuestions && marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(0);
			}
		}
		if (control.Name == button_2.Name)
		{
			button_2.BackColor = Color.PaleTurquoise;
			button_3.BackColor = Color.Red;
			VerticalCut = true;
			if (OfflineMode)
			{
				numericUpDown_4.Value = 90m;
			}
			if (AskTabChangeQuestions && marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(1);
			}
		}
		if (control.Name == button_13.Name)
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
		if (control.Name == button_9.Name && eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
		if (!(control.Name == button_15.Name))
		{
		}
		if (control.Name == button_8.Name)
		{
			if (OfflineMode)
			{
				varOperations.AxisValues = new Pnt6D((double)numericUpDown_8.Value, (double)numericUpDown_7.Value, (double)numericUpDown_6.Value, (double)numericUpDown_5.Value, 0.0, (double)numericUpDown_4.Value);
			}
			if (((Math.Abs(varOperations.AxisValues.C) > 45.0) & (Math.Abs(varOperations.AxisValues.C) < 135.0)) && !VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
			{
				VerticalCut = true;
			}
			if (((Math.Abs(varOperations.AxisValues.C) > 225.0) & (Math.Abs(varOperations.AxisValues.C) < 315.0)) && !VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
			{
				VerticalCut = true;
			}
			Class76.smethod_121(this);
			varOperations.isVertical = VerticalCut;
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
			Pnt3D EndPnt = new Pnt3D();
			if (bool_1)
			{
				varOperations.AxisValues.X = pnt6D_0.X;
				varOperations.AxisValues.Y = pnt6D_0.Y;
			}
			buControlCoreClass.cVector.LineWithLengthAndAngle(new Pnt3D(varOperations.AxisValues.X, varOperations.AxisValues.Y, varOperations.AxisValues.Z), varOperations.CutLength, varOperations.AxisValues.C, new WorkPlane(), ref EndPnt);
			Result = DialogResult.OK;
			bool_1 = false;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_12.Name)
		{
			Result = DialogResult.Cancel;
			bool_1 = false;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_14.Name)
		{
			if (buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[5]) == DialogResult.Yes)
			{
				for (int num = dataGridView_0.Rows.Count - 1; num >= 0; num--)
				{
					listItems.RemoveAt(num);
					dataGridView_0.Rows.RemoveAt(num);
				}
			}
			int_0 = -1;
			Class76.smethod_262(this);
		}
		if (control.Name == button_5.Name && ((int_0 >= 0) & (int_0 < dataGridView_0.Rows.Count - 1)))
		{
			if (int_1 < 0)
			{
				int_1 = 0;
			}
			int_0++;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[int_0].Cells[int_1];
		}
		if (control.Name == button_4.Name && int_0 > 0)
		{
			if (int_1 < 0)
			{
				int_1 = 0;
			}
			int_0--;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[int_0].Cells[int_1];
		}
		if (control.Name == button_0.Name)
		{
			button_0.BackColor = Color.Green;
			bool_1 = true;
			pnt6D_0 = new Pnt6D((double)numericUpDown_8.Value, (double)numericUpDown_7.Value, (double)numericUpDown_6.Value, (double)numericUpDown_5.Value, 0.0, (double)numericUpDown_4.Value);
			if (marbleSetStartPositionHandler_0 != null)
			{
				marbleSetStartPositionHandler_0(pnt6D_0);
			}
		}
		if (control.Name == button_1.Name && bool_1)
		{
			button_1.BackColor = Color.Green;
			pnt6D_1 = new Pnt6D((double)numericUpDown_8.Value, (double)numericUpDown_7.Value, (double)numericUpDown_6.Value, (double)numericUpDown_5.Value, 0.0, (double)numericUpDown_4.Value);
			numericUpDown_0.Value = (decimal)buControlCoreClass.cVector.Length3D(pnt6D_0, pnt6D_1);
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_1(pnt6D_1);
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
		if (control.Name == numericUpDown_12.Name)
		{
			marbleCutItems marbleCutItems2 = new marbleCutItems();
			marbleCutItems2.Length = (double)numericUpDown_9.Value;
			marbleCutItems2.Count = (int)numericUpDown_10.Value;
			marbleCutItems2.StartAngle = (double)numericUpDown_11.Value;
			marbleCutItems2.EndAngle = (double)numericUpDown_12.Value;
			if ((marbleCutItems2.Length > 0.0) & (marbleCutItems2.Count > 0))
			{
				bool_0 = false;
				Class76.smethod_616(true, marbleCutItems2, this);
				bool_0 = true;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)sender;
				buControlCommands.ShowKeyPad(this, buSpin2);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 && ((int_0 >= 0) & (int_0 <= listItems.Count - 1)))
		{
			listItems[int_0].Length = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[0].Value);
			listItems[int_0].Count = Convert.ToInt32(dataGridView_0.Rows[int_0].Cells[1].Value);
			listItems[int_0].StartAngle = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[2].Value);
			listItems[int_0].EndAngle = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[3].Value);
			Class76.smethod_262(this);
		}
	}

	internal void method_5(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
		int_1 = e.ColumnIndex;
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
