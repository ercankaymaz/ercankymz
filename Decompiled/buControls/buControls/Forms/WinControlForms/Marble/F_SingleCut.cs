using System;
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

public class F_SingleCut : Form
{
	public static List<string> Captions = new List<string>();

	public marbleSingleCut varSingleCut = new marbleSingleCut();

	public marbleOperation varOperations = new marbleOperation();

	public MaterialBase activeMaterial = new MaterialBase();

	public DialogResult Result = DialogResult.No;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_0;

	[CompilerGenerated]
	private MarbleSetStartPositionHandler marbleSetStartPositionHandler_1;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	internal bool bool_0 = false;

	private bool bool_1 = false;

	private Pnt6D pnt6D_0 = new Pnt6D();

	private Pnt6D pnt6D_1 = new Pnt6D();

	internal IContainer icontainer_0 = null;

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

	internal PictureBox pictureBox_1;

	internal ImageList imageList_0;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal CheckBox checkBox_0;

	internal Panel panel_1;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Label label_6;

	internal NumericUpDown numericUpDown_6;

	internal Button button_7;

	internal Panel panel_2;

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

	public F_SingleCut()
	{
		Class76.smethod_205(this);
	}

	public void Init()
	{
		try
		{
			bool_0 = false;
			bool_1 = false;
			button_7.BackColor = Color.Red;
			button_6.BackColor = Color.Red;
			numericUpDown_5.Value = (decimal)varOperations.TargetZ;
			numericUpDown_6.Value = (decimal)varOperations.CutLength;
			numericUpDown_4.Value = (decimal)varOperations.AxisValues.X;
			numericUpDown_3.Value = (decimal)varOperations.AxisValues.Y;
			numericUpDown_2.Value = (decimal)varOperations.AxisValues.Z;
			numericUpDown_1.Value = (decimal)varOperations.AxisValues.A;
			numericUpDown_0.Value = (decimal)varOperations.AxisValues.C;
			checkBox_0.Checked = varOperations.ApplySurfaceReadData;
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
			if (Captions.Count > 12)
			{
				Text = Captions[0];
				button_7.Text = Captions[1];
				button_6.Text = Captions[2];
				label_6.Text = Captions[12];
				label_5.Text = Captions[11];
				button_4.Text = Captions[5];
				button_5.Text = Captions[6];
				button_0.Text = Captions[7];
				button_2.Text = Captions[8];
				button_3.Text = Captions[10];
				checkBox_0.Text = Captions[10];
				button_1.Text = Captions[9];
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
		if (control.Name == button_4.Name && eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
		if (control.Name == button_3.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.Filter = "Surface Data File (*.csv)|*.csv";
			openFileDialog.FilterIndex = 1;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				List<Pnt3D> pntTeachList = new List<Pnt3D>();
				buFile.OpenSurfaceReadFile(openFileDialog.FileName, ref pntTeachList);
				if (pntTeachList.Count > 2)
				{
					buCamCalc.pntTeachGrids.Clear();
					SurfaceReadGridData surfaceReadGridData = new SurfaceReadGridData();
					surfaceReadGridData.GridDistance = new Pnt3D(1.0, 1.0);
					buControlCoreClass.cVector.CreateSurfaceGridFromTeachFile(surfaceReadGridData, pntTeachList, ref buCamCalc.pntTeachGrids);
				}
			}
		}
		if (control.Name == button_5.Name)
		{
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
			Class76.smethod_741(this);
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
		if (control.Name == button_7.Name)
		{
			button_7.BackColor = Color.Green;
			bool_1 = true;
			pnt6D_0 = new Pnt6D((double)numericUpDown_4.Value, (double)numericUpDown_3.Value, (double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0, (double)numericUpDown_0.Value);
			if (marbleSetStartPositionHandler_0 != null)
			{
				marbleSetStartPositionHandler_0(pnt6D_0);
			}
		}
		if (control.Name == button_6.Name && bool_1)
		{
			button_6.BackColor = Color.Green;
			pnt6D_1 = new Pnt6D((double)numericUpDown_4.Value, (double)numericUpDown_3.Value, (double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0, (double)numericUpDown_0.Value);
			numericUpDown_6.Value = (decimal)buControlCoreClass.cVector.Length3D(pnt6D_0, pnt6D_1);
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_1(pnt6D_1);
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
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
