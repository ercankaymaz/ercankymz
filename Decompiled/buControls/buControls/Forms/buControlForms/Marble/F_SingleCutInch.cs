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
using buCore;
using buCore.AppCalc;
using ns27;

namespace buControls.Forms.buControlForms.Marble;

public class F_SingleCutInch : Form
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

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal PictureBox pictureBox_0;

	internal buLabel buLabel_0;

	internal buButton buButton_3;

	internal buButton buButton_4;

	internal buButton buButton_5;

	internal buButton buButton_6;

	internal buSeparator buSeparator_0;

	internal buSeparator buSeparator_1;

	public buSpin spn_c;

	public buSpin spn_a;

	public buSpin spn_z;

	public buSpin spn_y;

	public buSpin spn_x;

	internal buButton buButton_7;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

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

	public F_SingleCutInch()
	{
		Class76.smethod_55(this);
		textBox_1.Click += textBox_0_Click;
		textBox_0.Click += textBox_0_Click;
	}

	public void Init()
	{
		try
		{
			bool_0 = false;
			bool_1 = false;
			buButton_6.Display.BackColor = Color.Red;
			buButton_5.Display.BackColor = Color.Red;
			textBox_1.Text = buString.InchValueToString(varOperations.TargetZ, 16);
			textBox_0.Text = buString.InchValueToString(varOperations.CutLength, 16);
			spn_x.Value = varOperations.AxisValues.X;
			spn_y.Value = varOperations.AxisValues.Y;
			spn_z.Value = varOperations.AxisValues.Z;
			spn_a.Value = varOperations.AxisValues.A;
			spn_c.Value = varOperations.AxisValues.C;
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
			if (Captions.Count > 8)
			{
				buGround_0.Text = Captions[0];
				buButton_6.Text = Captions[1];
				buButton_5.Text = Captions[2];
				buLabel_0.Text = Captions[4];
				buButton_7.Text = Captions[5];
				buButton_3.Text = Captions[6];
				buButton_4.Text = Captions[7];
				buButton_0.Text = Captions[8];
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
		if ((control.Name == buButton_2.Name) | (control.Name == buButton_4.Name))
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
		if (control.Name == buButton_1.Name)
		{
			Result = DialogResult.Cancel;
			base.WindowState = FormWindowState.Minimized;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == buButton_0.Name)
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
		if (control.Name == buButton_7.Name && eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
		if (control.Name == buButton_3.Name)
		{
			if (varOperations.TargetZ >= varOperations.MaterialThickness)
			{
				buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
				return;
			}
			Class76.smethod_803(this);
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
		if (control.Name == buButton_6.Name)
		{
			buButton_6.Display.BackColor = Color.Green;
			bool_1 = true;
			pnt6D_0 = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			if (marbleSetStartPositionHandler_0 != null)
			{
				marbleSetStartPositionHandler_0(pnt6D_0);
			}
		}
		if (control.Name == buButton_5.Name && bool_1)
		{
			buButton_5.Display.BackColor = Color.Green;
			pnt6D_1 = new Pnt6D(spn_x.Value, spn_y.Value, spn_z.Value, spn_a.Value, 0.0, spn_c.Value);
			textBox_0.Text = buString.InchValueToString(buControlCoreClass.cVector.Length3D(pnt6D_0, pnt6D_1), 16);
			if (marbleSetStartPositionHandler_1 != null)
			{
				marbleSetStartPositionHandler_1(pnt6D_1);
			}
		}
	}

	private void textBox_0_Click(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
