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
using buCore;
using buCore.AppCalc;
using ns27;

namespace buControls.Forms.buControlForms.Marble;

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

	[CompilerGenerated]
	private MarblePerpendicularModeEventHandler marblePerpendicularModeEventHandler_0;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_0;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public List<marbleCutItems> listItems = new List<marbleCutItems>();

	internal marbleCutItems[] marbleCutItems_0 = new marbleCutItems[100];

	internal int int_0 = 0;

	internal bool bool_0 = false;

	internal bool bool_1 = false;

	private bool bool_2 = false;

	private Pnt6D pnt6D_0 = new Pnt6D();

	private Pnt6D pnt6D_1 = new Pnt6D();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal PictureBox pictureBox_0;

	internal buLabel buLabel_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal PictureBox pictureBox_4;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	internal buLabel buLabel_3;

	internal buLabel buLabel_4;

	internal buLabel buLabel_5;

	internal buLabel buLabel_6;

	internal buLabel buLabel_7;

	internal buLabel buLabel_8;

	internal buLabel buLabel_9;

	internal buButton buButton_4;

	internal buButton buButton_5;

	internal buButton buButton_6;

	internal buButton buButton_7;

	internal buSeparator buSeparator_0;

	internal buButton buButton_8;

	internal buButton buButton_9;

	public buSpin spn_c;

	public buSpin spn_a;

	public buSpin spn_z;

	public buSpin spn_y;

	public buSpin spn_x;

	internal buButton buButton_10;

	public buSpin spn_length;

	public buSpin spn_depth;

	public buSpin spn_itemEA5;

	public buSpin spn_itemSA5;

	public buSpin spn_itemcount5;

	public buSpin spn_itemlen5;

	public buSpin spn_itemEA4;

	public buSpin spn_itemSA4;

	public buSpin spn_itemcount4;

	public buSpin spn_itemlen4;

	public buSpin spn_itemEA3;

	public buSpin spn_itemSA3;

	public buSpin spn_itemcount3;

	public buSpin spn_itemlen3;

	public buSpin spn_itemEA2;

	public buSpin spn_itemSA2;

	public buSpin spn_itemcount2;

	public buSpin spn_itemlen2;

	public buSpin spn_itemEA1;

	public buSpin spn_itemSA1;

	public buSpin spn_itemcount1;

	public buSpin spn_itemlen1;

	internal buButton buButton_11;

	internal buButton buButton_12;

	internal buSeparator buSeparator_1;

	internal buButton buButton_13;

	internal buButton buButton_14;

	internal buSeparator buSeparator_2;

	internal buButton buButton_15;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	internal buLabel buLabel_12;

	internal buButton buButton_16;

	public CheckBox chk_surface;

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
		Class76.smethod_716(this);
		spn_depth.Click += spn_length_Click;
		spn_itemcount1.Click += spn_length_Click;
		spn_itemcount2.Click += spn_length_Click;
		spn_itemcount3.Click += spn_length_Click;
		spn_itemcount4.Click += spn_length_Click;
		spn_itemcount5.Click += spn_length_Click;
		spn_itemEA1.Click += spn_length_Click;
		spn_itemEA2.Click += spn_length_Click;
		spn_itemEA3.Click += spn_length_Click;
		spn_itemEA4.Click += spn_length_Click;
		spn_itemEA5.Click += spn_length_Click;
		spn_itemlen1.Click += spn_length_Click;
		spn_itemlen2.Click += spn_length_Click;
		spn_itemlen3.Click += spn_length_Click;
		spn_itemlen4.Click += spn_length_Click;
		spn_itemlen5.Click += spn_length_Click;
		spn_itemSA1.Click += spn_length_Click;
		spn_itemSA2.Click += spn_length_Click;
		spn_itemSA3.Click += spn_length_Click;
		spn_itemSA4.Click += spn_length_Click;
		spn_itemSA5.Click += spn_length_Click;
		spn_length.Click += spn_length_Click;
	}

	public void Init()
	{
		try
		{
			bool_1 = false;
			bool_2 = false;
			buButton_9.Display.BackColor = Color.Red;
			buButton_8.Display.BackColor = Color.Red;
			for (int i = 0; i <= 99; i++)
			{
				marbleCutItems_0[i] = new marbleCutItems();
			}
			for (int j = 0; j <= listItems.Count - 1; j++)
			{
				marbleCutItems_0[j] = new marbleCutItems(listItems[j]);
			}
			if (!VerticalCut)
			{
				buButton_12.Display.BackColor = Color.Red;
				buButton_12.ButtonOverDisplay.BackColor = Color.Red;
				buButton_12.ButtonDownDisplay.BackColor = Color.Red;
				buButton_11.Display.BackColor = Color.Green;
				buButton_11.ButtonOverDisplay.BackColor = Color.Green;
				buButton_11.ButtonDownDisplay.BackColor = Color.Green;
			}
			else
			{
				buButton_12.Display.BackColor = Color.Green;
				buButton_12.ButtonOverDisplay.BackColor = Color.Green;
				buButton_12.ButtonDownDisplay.BackColor = Color.Green;
				buButton_11.Display.BackColor = Color.Red;
				buButton_11.ButtonOverDisplay.BackColor = Color.Red;
				buButton_11.ButtonDownDisplay.BackColor = Color.Red;
			}
			spn_depth.Value = varOperations.TargetZ;
			spn_length.Value = varOperations.CutLength;
			chk_surface.Checked = varOperations.ApplySurfaceReadData;
			spn_x.Value = varOperations.AxisValues.X;
			spn_y.Value = varOperations.AxisValues.Y;
			spn_z.Value = varOperations.AxisValues.Z;
			spn_a.Value = varOperations.AxisValues.A;
			spn_c.Value = varOperations.AxisValues.C;
			Class76.smethod_480(this);
			LoadLanguage();
			bool_1 = true;
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
			if (Captions.Count > 18)
			{
				buGround_0.Text = Captions[0];
				buButton_9.Text = Captions[1];
				buButton_8.Text = Captions[2];
				spn_length.Caption.Caption = Captions[3];
				buLabel_0.Text = Captions[4];
				buButton_10.Text = Captions[5];
				buButton_2.Text = Captions[6];
				buButton_3.Text = Captions[7];
				buButton_11.Text = Captions[8];
				buButton_12.Text = Captions[9];
				buLabel_1.Text = Captions[10];
				buLabel_9.Text = Captions[11];
				buLabel_8.Text = Captions[12];
				buLabel_7.Text = Captions[13];
				buButton_15.Text = Captions[14];
				buLabel_10.Text = Captions[15];
				buButton_13.Text = Captions[16];
				buButton_14.Text = Captions[17];
				buButton_7.Text = Captions[18];
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
		if ((control.Name == buButton_5.Name) | (control.Name == buButton_3.Name))
		{
			Result = DialogResult.Cancel;
			bool_2 = false;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == buButton_4.Name)
		{
			Result = DialogResult.Cancel;
			base.WindowState = FormWindowState.Minimized;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == buButton_13.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathFiles;
			saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathFiles = buFile.GetPath(saveFileDialog.FileName);
				Class76.smethod_499(this);
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i <= listItems.Count - 1; i++)
				{
					arrayList.AddRange(listItems[i].ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
				}
				buFile.SaveToFile(arrayList, saveFileDialog.FileName);
			}
		}
		if (control.Name == buButton_14.Name)
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
		if (control.Name == buButton_16.Name)
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
		if (control.Name == buButton_15.Name)
		{
			for (int k = 0; k <= 99; k++)
			{
				marbleCutItems_0[k] = new marbleCutItems();
			}
			spn_itemcount1.Value = 0.0;
			spn_itemcount2.Value = 0.0;
			spn_itemcount3.Value = 0.0;
			spn_itemcount4.Value = 0.0;
			spn_itemcount5.Value = 0.0;
			spn_itemEA1.Value = 0.0;
			spn_itemEA2.Value = 0.0;
			spn_itemEA3.Value = 0.0;
			spn_itemEA4.Value = 0.0;
			spn_itemEA5.Value = 0.0;
			spn_itemSA1.Value = 0.0;
			spn_itemSA2.Value = 0.0;
			spn_itemSA3.Value = 0.0;
			spn_itemSA4.Value = 0.0;
			spn_itemSA5.Value = 0.0;
			spn_itemlen1.Value = 0.0;
			spn_itemlen2.Value = 0.0;
			spn_itemlen3.Value = 0.0;
			spn_itemlen4.Value = 0.0;
			spn_itemlen5.Value = 0.0;
		}
		if (control.Name == buButton_11.Name)
		{
			buButton_12.Display.BackColor = Color.Red;
			buButton_12.ButtonOverDisplay.BackColor = Color.Red;
			buButton_12.ButtonDownDisplay.BackColor = Color.Red;
			buButton_11.Display.BackColor = Color.Green;
			buButton_11.ButtonOverDisplay.BackColor = Color.Green;
			buButton_11.ButtonDownDisplay.BackColor = Color.Green;
			VerticalCut = false;
			if (AskTabChangeQuestions && marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(0);
			}
		}
		if (control.Name == buButton_12.Name)
		{
			buButton_12.Display.BackColor = Color.Green;
			buButton_12.ButtonOverDisplay.BackColor = Color.Green;
			buButton_12.ButtonDownDisplay.BackColor = Color.Green;
			buButton_11.Display.BackColor = Color.Red;
			buButton_11.ButtonOverDisplay.BackColor = Color.Red;
			buButton_11.ButtonDownDisplay.BackColor = Color.Red;
			VerticalCut = true;
			if (AskTabChangeQuestions && marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(1);
			}
		}
		if (control.Name == buButton_7.Name)
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
		if (control.Name == buButton_10.Name && eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
		if (control.Name == buButton_2.Name)
		{
			Class76.smethod_499(this);
			if (((Math.Abs(varOperations.AxisValues.C) > 45.0) & (Math.Abs(varOperations.AxisValues.C) < 135.0)) && !VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
			{
				VerticalCut = true;
			}
			if (((Math.Abs(varOperations.AxisValues.C) > 225.0) & (Math.Abs(varOperations.AxisValues.C) < 315.0)) && !VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
			{
				VerticalCut = true;
			}
			Class76.smethod_420(this);
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
			Pnt3D EndPnt = new Pnt3D();
			if (bool_2)
			{
				varOperations.AxisValues.X = pnt6D_0.X;
				varOperations.AxisValues.Y = pnt6D_0.Y;
			}
			buControlCoreClass.cVector.LineWithLengthAndAngle(new Pnt3D(varOperations.AxisValues.X, varOperations.AxisValues.Y, varOperations.AxisValues.Z), varOperations.CutLength, varOperations.AxisValues.C, new WorkPlane(), ref EndPnt);
			Result = DialogResult.OK;
			bool_2 = false;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == buButton_6.Name && buString.MessageBoxQuestion(AppLanguage.SystemMessages[0]) == DialogResult.Yes)
		{
			for (int l = 0; l <= 99; l++)
			{
				marbleCutItems_0[l] = new marbleCutItems();
			}
			int_0 = 0;
			Class76.smethod_480(this);
		}
		if (control.Name == buButton_0.Name)
		{
			buGeneral.ArrayIndexIncrease(ref int_0, 100, 1, 5);
			buLabel_6.Text = (int_0 + 1).ToString();
			buLabel_5.Text = (int_0 + 2).ToString();
			buLabel_4.Text = (int_0 + 3).ToString();
			buLabel_3.Text = (int_0 + 4).ToString();
			buLabel_2.Text = (int_0 + 5).ToString();
			Class76.smethod_480(this);
		}
		if (control.Name == buButton_1.Name)
		{
			buGeneral.ArrayIndexDecrease(ref int_0, 0, 1, 5);
			buLabel_6.Text = (int_0 + 1).ToString();
			buLabel_5.Text = (int_0 + 2).ToString();
			buLabel_4.Text = (int_0 + 3).ToString();
			buLabel_3.Text = (int_0 + 4).ToString();
			buLabel_2.Text = (int_0 + 5).ToString();
			Class76.smethod_480(this);
		}
		if (control.Name == buButton_9.Name)
		{
			buButton_9.Display.BackColor = Color.Green;
			bool_2 = true;
			pnt6D_0 = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			if (marbleSetStartPositionHandler_0 != null)
			{
				marbleSetStartPositionHandler_0(pnt6D_0);
			}
		}
		if (control.Name == buButton_8.Name && bool_2)
		{
			buButton_8.Display.BackColor = Color.Green;
			pnt6D_1 = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			spn_length.Value = buControlCoreClass.cVector.Length3D(pnt6D_0, pnt6D_1);
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_1(pnt6D_1);
			}
		}
	}

	internal void method_3(object object_0, double double_0)
	{
		if (!bool_0)
		{
			buSpin buSpin2 = new buSpin();
			buSpin2 = (buSpin)object_0;
			if (buSpin2.Aux.Explanation == "Len")
			{
				marbleCutItems_0[int_0 + buSpin2.Aux.ValInt].Length = buSpin2.Value;
			}
			if (buSpin2.Aux.Explanation == "Cnt")
			{
				marbleCutItems_0[int_0 + buSpin2.Aux.ValInt].Count = (int)buSpin2.Value;
			}
			if (buSpin2.Aux.Explanation == "SA")
			{
				marbleCutItems_0[int_0 + buSpin2.Aux.ValInt].StartAngle = buSpin2.Value;
			}
			if (buSpin2.Aux.Explanation == "EA")
			{
				marbleCutItems_0[int_0 + buSpin2.Aux.ValInt].EndAngle = buSpin2.Value;
			}
			double num = 0.0;
			int num2 = 0;
			for (int i = 0; i <= marbleCutItems_0.Length - 1; i++)
			{
				num += marbleCutItems_0[i].Length * (double)marbleCutItems_0[i].Count;
				num2 += marbleCutItems_0[i].Count;
			}
			buLabel_12.Text = num.ToString("f1");
			buLabel_11.Text = num2.ToString("f1");
		}
	}

	internal void method_4(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(buGround_0.Controls, result, e.Shift);
		}
	}

	private void spn_length_Click(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
