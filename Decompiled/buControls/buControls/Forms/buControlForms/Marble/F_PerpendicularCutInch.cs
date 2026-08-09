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

public class F_PerpendicularCutInch : Form
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

	internal marbleCutItems[] marbleCutItems_0 = new marbleCutItems[100];

	internal int int_0 = 0;

	public List<marbleCutItems> listItemsVer = new List<marbleCutItems>();

	internal marbleCutItems[] marbleCutItems_1 = new marbleCutItems[100];

	internal int int_1 = 0;

	internal bool bool_0 = false;

	internal bool bool_1 = false;

	private bool bool_2 = false;

	private bool bool_3 = false;

	public Pnt6D StartPosVer = new Pnt6D();

	public Pnt6D EndPosVer = new Pnt6D();

	public Pnt6D StartPosHor = new Pnt6D();

	public Pnt6D EndPosHor = new Pnt6D();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buLabel buLabel_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	internal buLabel buLabel_3;

	internal buLabel buLabel_4;

	internal buLabel buLabel_5;

	internal buLabel buLabel_6;

	internal buLabel buLabel_7;

	internal buLabel buLabel_8;

	internal buLabel buLabel_9;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	internal buButton buButton_4;

	internal PictureBox pictureBox_4;

	internal PictureBox pictureBox_5;

	internal PictureBox pictureBox_6;

	internal PictureBox pictureBox_7;

	internal buLabel buLabel_12;

	internal buLabel buLabel_13;

	internal buLabel buLabel_14;

	internal buLabel buLabel_15;

	internal buLabel buLabel_16;

	internal buLabel buLabel_17;

	internal buLabel buLabel_18;

	internal buLabel buLabel_19;

	internal buLabel buLabel_20;

	internal buButton buButton_5;

	internal buButton buButton_6;

	internal buButton buButton_7;

	internal buButton buButton_8;

	internal buButton buButton_9;

	internal buButton buButton_10;

	internal buLabel buLabel_21;

	internal buLabel buLabel_22;

	internal buLabel buLabel_23;

	internal buLabel buLabel_24;

	internal buLabel buLabel_25;

	internal buLabel buLabel_26;

	internal buSeparator buSeparator_0;

	internal buTab buTab_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal buSeparator buSeparator_1;

	internal buButton buButton_11;

	internal buButton buButton_12;

	internal buSeparator buSeparator_2;

	internal buButton buButton_13;

	internal buButton buButton_14;

	public buSpin spn_c;

	public buSpin spn_a;

	public buSpin spn_z;

	public buSpin spn_y;

	public buSpin spn_x;

	internal buButton buButton_15;

	public buSpin spn_itemEA5_hor;

	public buSpin spn_itemSA5_hor;

	public buSpin spn_itemcount5_hor;

	public buSpin spn_itemEA4_hor;

	public buSpin spn_itemSA4_hor;

	public buSpin spn_itemcount4_hor;

	public buSpin spn_itemEA3_hor;

	public buSpin spn_itemSA3_hor;

	public buSpin spn_itemcount3_hor;

	public buSpin spn_itemEA2_hor;

	public buSpin spn_itemSA2_hor;

	public buSpin spn_itemcount2_hor;

	public buSpin spn_itemEA1_hor;

	public buSpin spn_itemSA1_hor;

	public buSpin spn_itemEA5_ver;

	public buSpin spn_itemSA5_ver;

	public buSpin spn_itemcount5_ver;

	public buSpin spn_itemEA4_ver;

	public buSpin spn_itemSA4_ver;

	public buSpin spn_itemcount4_ver;

	public buSpin spn_itemEA3_ver;

	public buSpin spn_itemSA3_ver;

	public buSpin spn_itemcount3_ver;

	public buSpin spn_itemEA2_ver;

	public buSpin spn_itemSA2_ver;

	public buSpin spn_itemcount2_ver;

	public buSpin spn_itemEA1_ver;

	public buSpin spn_itemSA1_ver;

	public buSpin spn_itemcount1_ver;

	public buSpin spn_itemcount1_hor;

	internal buButton buButton_16;

	internal buButton buButton_17;

	public CheckBox chk_verticalfisrt;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	internal TextBox textBox_2;

	internal buTextBox buTextBox_0;

	internal buTextBox buTextBox_1;

	internal buTextBox buTextBox_2;

	internal buTextBox buTextBox_3;

	internal buTextBox buTextBox_4;

	internal buTextBox buTextBox_5;

	internal buTextBox buTextBox_6;

	internal buTextBox buTextBox_7;

	internal buTextBox buTextBox_8;

	internal buTextBox buTextBox_9;

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

	public F_PerpendicularCutInch()
	{
		Class76.smethod_681(this);
		textBox_1.Click += textBox_2_Click;
		spn_itemcount1_hor.Click += textBox_2_Click;
		spn_itemcount2_hor.Click += textBox_2_Click;
		spn_itemcount3_hor.Click += textBox_2_Click;
		spn_itemcount4_hor.Click += textBox_2_Click;
		spn_itemcount5_hor.Click += textBox_2_Click;
		spn_itemcount1_ver.Click += textBox_2_Click;
		spn_itemcount2_ver.Click += textBox_2_Click;
		spn_itemcount3_ver.Click += textBox_2_Click;
		spn_itemcount4_ver.Click += textBox_2_Click;
		spn_itemcount5_ver.Click += textBox_2_Click;
		spn_itemEA1_hor.Click += textBox_2_Click;
		spn_itemEA2_hor.Click += textBox_2_Click;
		spn_itemEA3_hor.Click += textBox_2_Click;
		spn_itemEA4_hor.Click += textBox_2_Click;
		spn_itemEA5_hor.Click += textBox_2_Click;
		spn_itemEA1_ver.Click += textBox_2_Click;
		spn_itemEA2_ver.Click += textBox_2_Click;
		spn_itemEA3_ver.Click += textBox_2_Click;
		spn_itemEA4_ver.Click += textBox_2_Click;
		spn_itemEA5_ver.Click += textBox_2_Click;
		buTextBox_4.Click += textBox_2_Click;
		buTextBox_3.Click += textBox_2_Click;
		buTextBox_2.Click += textBox_2_Click;
		buTextBox_1.Click += textBox_2_Click;
		buTextBox_0.Click += textBox_2_Click;
		buTextBox_9.Click += textBox_2_Click;
		buTextBox_8.Click += textBox_2_Click;
		buTextBox_7.Click += textBox_2_Click;
		buTextBox_6.Click += textBox_2_Click;
		buTextBox_5.Click += textBox_2_Click;
		spn_itemSA1_hor.Click += textBox_2_Click;
		spn_itemSA2_hor.Click += textBox_2_Click;
		spn_itemSA3_hor.Click += textBox_2_Click;
		spn_itemSA4_hor.Click += textBox_2_Click;
		spn_itemSA5_hor.Click += textBox_2_Click;
		spn_itemSA1_ver.Click += textBox_2_Click;
		spn_itemSA2_ver.Click += textBox_2_Click;
		spn_itemSA3_ver.Click += textBox_2_Click;
		spn_itemSA4_ver.Click += textBox_2_Click;
		spn_itemSA5_ver.Click += textBox_2_Click;
		textBox_0.Click += textBox_2_Click;
		textBox_2.Click += textBox_2_Click;
	}

	public void Init()
	{
		try
		{
			bool_1 = false;
			bool_2 = false;
			bool_3 = false;
			buButton_14.Display.BackColor = Color.Red;
			buButton_13.Display.BackColor = Color.Red;
			buButton_12.Display.BackColor = Color.Red;
			buButton_11.Display.BackColor = Color.Red;
			for (int i = 0; i <= 99; i++)
			{
				marbleCutItems_0[i] = new marbleCutItems();
				marbleCutItems_1[i] = new marbleCutItems();
			}
			for (int j = 0; j <= listItemsHor.Count - 1; j++)
			{
				marbleCutItems_0[j] = new marbleCutItems(listItemsHor[j]);
			}
			for (int k = 0; k <= listItemsVer.Count - 1; k++)
			{
				marbleCutItems_1[k] = new marbleCutItems(listItemsVer[k]);
			}
			chk_verticalfisrt.Checked = varOperations.VerticalFirst;
			textBox_1.Text = buString.InchValueToString(varOperations.TargetZ, 16);
			textBox_0.Text = buString.InchValueToString(varPerpendicularCut.CutHorizontalLength, 16);
			textBox_2.Text = buString.InchValueToString(varPerpendicularCut.CutVerticalLength, 16);
			spn_x.Value = varOperations.AxisValues.X;
			spn_y.Value = varOperations.AxisValues.Y;
			spn_z.Value = varOperations.AxisValues.Z;
			spn_a.Value = varOperations.AxisValues.A;
			spn_c.Value = varOperations.AxisValues.C;
			Class76.smethod_529(this);
			Class76.smethod_613(this);
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
			if (Captions.Count > 20)
			{
				buGround_0.Text = Captions[0];
				buButton_12.Text = Captions[1];
				buButton_14.Text = Captions[1];
				buButton_11.Text = Captions[2];
				buButton_13.Text = Captions[2];
				buLabel_0.Text = Captions[4];
				buButton_15.Text = Captions[5];
				buButton_2.Text = Captions[6];
				buButton_3.Text = Captions[7];
				tabPage_0.Text = Captions[8];
				tabPage_1.Text = Captions[9];
				buLabel_1.Text = Captions[10];
				buLabel_12.Text = Captions[10];
				buLabel_9.Text = Captions[11];
				buLabel_20.Text = Captions[11];
				buLabel_8.Text = Captions[12];
				buLabel_19.Text = Captions[12];
				buLabel_7.Text = Captions[13];
				buLabel_18.Text = Captions[13];
				buButton_6.Text = Captions[14];
				buButton_4.Text = Captions[14];
				buLabel_24.Text = Captions[15];
				buLabel_21.Text = Captions[15];
				buButton_16.Text = Captions[16];
				buButton_17.Text = Captions[17];
				buLabel_10.Text = Captions[18];
				buLabel_11.Text = Captions[19];
				buButton_5.Text = Captions[20];
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
		if ((control.Name == buButton_8.Name) | (control.Name == buButton_3.Name))
		{
			Result = DialogResult.Cancel;
			bool_2 = false;
			bool_3 = false;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == buButton_7.Name)
		{
			Result = DialogResult.Cancel;
			base.WindowState = FormWindowState.Minimized;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == buButton_16.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathFiles;
			saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathFiles = buFile.GetPath(saveFileDialog.FileName);
				Class76.smethod_774(this);
				Class76.smethod_337(this);
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
		if (control.Name == buButton_17.Name)
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
		if (control.Name == buButton_5.Name)
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
		if (control.Name == buButton_15.Name && eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
		if (control.Name == buButton_2.Name)
		{
			Class76.smethod_774(this);
			Class76.smethod_337(this);
			Class76.smethod_402(this);
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
		if (control.Name == buButton_4.Name && buString.MessageBoxQuestion(AppLanguage.SystemMessages[5]) == DialogResult.Yes)
		{
			for (int m = 0; m <= 99; m++)
			{
				marbleCutItems_1[m] = new marbleCutItems();
			}
			int_1 = 0;
			Class76.smethod_613(this);
		}
		if (control.Name == buButton_6.Name && buString.MessageBoxQuestion(AppLanguage.SystemMessages[5]) == DialogResult.Yes)
		{
			for (int n = 0; n <= 99; n++)
			{
				marbleCutItems_0[n] = new marbleCutItems();
			}
			int_0 = 0;
			Class76.smethod_529(this);
		}
		if (control.Name == buButton_0.Name)
		{
			buGeneral.ArrayIndexIncrease(ref int_0, 100, 1, 5);
			buLabel_6.Text = (int_0 + 1).ToString();
			buLabel_5.Text = (int_0 + 2).ToString();
			buLabel_4.Text = (int_0 + 3).ToString();
			buLabel_3.Text = (int_0 + 4).ToString();
			buLabel_2.Text = (int_0 + 5).ToString();
			Class76.smethod_529(this);
		}
		if (control.Name == buButton_1.Name)
		{
			buGeneral.ArrayIndexDecrease(ref int_0, 0, 1, 5);
			buLabel_6.Text = (int_0 + 1).ToString();
			buLabel_5.Text = (int_0 + 2).ToString();
			buLabel_4.Text = (int_0 + 3).ToString();
			buLabel_3.Text = (int_0 + 4).ToString();
			buLabel_2.Text = (int_0 + 5).ToString();
			Class76.smethod_529(this);
		}
		if (control.Name == buButton_12.Name)
		{
			buButton_12.Display.BackColor = Color.Green;
			bool_3 = true;
			StartPosHor = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			if (marbleSetStartPositionHandler_0 != null)
			{
				marbleSetStartPositionHandler_0(StartPosHor);
			}
		}
		if (control.Name == buButton_11.Name && bool_3)
		{
			buButton_11.Display.BackColor = Color.Green;
			EndPosHor = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			textBox_0.Text = buString.InchValueToString(buControlCoreClass.cVector.Length3D(StartPosHor, EndPosHor), 16);
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_1(EndPosHor);
			}
		}
		if (control.Name == buButton_14.Name)
		{
			buButton_14.Display.BackColor = Color.Green;
			bool_2 = true;
			StartPosVer = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			if (marbleSetStartPositionHandler_2 != null)
			{
				marbleSetStartPositionHandler_2(StartPosVer);
			}
		}
		if (control.Name == buButton_13.Name && bool_2)
		{
			buButton_13.Display.BackColor = Color.Green;
			EndPosVer = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			textBox_2.Text = buString.InchValueToString(buControlCoreClass.cVector.Length3D(StartPosVer, EndPosVer), 16);
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_3(EndPosVer);
			}
		}
		if (control.Name == buButton_9.Name)
		{
			buGeneral.ArrayIndexIncrease(ref int_1, 100, 1, 5);
			buLabel_17.Text = (int_1 + 1).ToString();
			buLabel_16.Text = (int_1 + 2).ToString();
			buLabel_15.Text = (int_1 + 3).ToString();
			buLabel_14.Text = (int_1 + 4).ToString();
			buLabel_13.Text = (int_1 + 5).ToString();
			Class76.smethod_613(this);
		}
		if (control.Name == buButton_10.Name)
		{
			buGeneral.ArrayIndexDecrease(ref int_1, 0, 1, 5);
			buLabel_17.Text = (int_1 + 1).ToString();
			buLabel_16.Text = (int_1 + 2).ToString();
			buLabel_15.Text = (int_1 + 3).ToString();
			buLabel_14.Text = (int_1 + 4).ToString();
			buLabel_13.Text = (int_1 + 5).ToString();
			Class76.smethod_613(this);
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
			buLabel_26.Text = num.ToString("f1");
			buLabel_25.Text = num2.ToString("f1");
			Class76.smethod_435(this);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			buTextBox buTextBox2 = new buTextBox();
			buTextBox2 = (buTextBox)sender;
			if (buTextBox2.Aux.Explanation.ToString() == "Len")
			{
				marbleCutItems_0[int_0 + buTextBox2.Aux.ValInt].Length = buString.StringToInchValue(buTextBox2.Text, 16);
			}
			double num = 0.0;
			int num2 = 0;
			for (int i = 0; i <= marbleCutItems_0.Length - 1; i++)
			{
				num += marbleCutItems_0[i].Length * (double)marbleCutItems_0[i].Count;
				num2 += marbleCutItems_0[i].Count;
			}
			buLabel_26.Text = num.ToString("f1");
			buLabel_25.Text = num2.ToString("f1");
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			buTextBox buTextBox2 = new buTextBox();
			buTextBox2 = (buTextBox)sender;
			if (buTextBox2.Aux.Explanation.ToString() == "Len")
			{
				marbleCutItems_1[int_1 + buTextBox2.Aux.ValInt].Length = buString.StringToInchValue(buTextBox2.Text, 16);
			}
			double num = 0.0;
			int num2 = 0;
			for (int i = 0; i <= marbleCutItems_1.Length - 1; i++)
			{
				num += marbleCutItems_1[i].Length * (double)marbleCutItems_1[i].Count;
				num2 += marbleCutItems_1[i].Count;
			}
			buLabel_23.Text = num.ToString("f1");
			buLabel_22.Text = num2.ToString("f1");
		}
	}

	internal void method_6(object object_0, double double_0)
	{
		if (!bool_0)
		{
			buSpin buSpin2 = new buSpin();
			buSpin2 = (buSpin)object_0;
			if (buSpin2.Aux.Explanation == "Len")
			{
				marbleCutItems_1[int_1 + buSpin2.Aux.ValInt].Length = buSpin2.Value;
			}
			if (buSpin2.Aux.Explanation == "Cnt")
			{
				marbleCutItems_1[int_1 + buSpin2.Aux.ValInt].Count = (int)buSpin2.Value;
			}
			if (buSpin2.Aux.Explanation == "SA")
			{
				marbleCutItems_1[int_1 + buSpin2.Aux.ValInt].StartAngle = buSpin2.Value;
			}
			if (buSpin2.Aux.Explanation == "EA")
			{
				marbleCutItems_1[int_1 + buSpin2.Aux.ValInt].EndAngle = buSpin2.Value;
			}
			double num = 0.0;
			int num2 = 0;
			for (int i = 0; i <= marbleCutItems_1.Length - 1; i++)
			{
				num += marbleCutItems_1[i].Length * (double)marbleCutItems_1[i].Count;
				num2 += marbleCutItems_1[i].Count;
			}
			buLabel_23.Text = num.ToString("f1");
			buLabel_22.Text = num2.ToString("f1");
			Class76.smethod_435(this);
		}
	}

	internal void method_7(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(tabPage_0.Controls, result, e.Shift);
		}
	}

	internal void method_8(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(tabPage_1.Controls, result, e.Shift);
		}
	}

	private void textBox_2_Click(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				if (sender.GetType() == typeof(buSpin))
				{
					buSpin buSpin2 = new buSpin();
					buSpin2 = (buSpin)sender;
					buControlCommands.ShowKeyPad(this, buSpin2);
				}
				if (sender.GetType() == typeof(TextBox))
				{
					TextBox textBox = new TextBox();
					textBox = (TextBox)sender;
					buControlCommands.ShowKeyPad(this, textBox);
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

	internal void method_9(object sender, EventArgs e)
	{
		if (AskTabChangeQuestions)
		{
			if (buTab_0.SelectedIndex == 0 && marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(buTab_0.SelectedIndex);
			}
			if (buTab_0.SelectedIndex == 1 && marblePerpendicularModeEventHandler_0 != null)
			{
				marblePerpendicularModeEventHandler_0(buTab_0.SelectedIndex);
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
