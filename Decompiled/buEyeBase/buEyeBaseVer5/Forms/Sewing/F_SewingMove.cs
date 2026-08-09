using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Forms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingMove : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public double MoveDis = 1.0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_yminus;

	public Button btn_xminus;

	internal NumericUpDown numericUpDown_0;

	public Button btn_yplus;

	public Button btn_xplus;

	public Button btn_anglePlus;

	public Button btn_angleMinus;

	public event OkCommandWithTwoDataEventHandler MoveCommad
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler CancelCommad
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_SewingMove()
	{
		Class186.smethod_401(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		numericUpDown_0.Value = (decimal)MoveDis;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 1)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_xminus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			MoveDis = (double)numericUpDown_0.Value;
			okCommandWithTwoDataEventHandler_0("X", 0.0 - MoveDis);
		}
		if (control.Name == btn_xplus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			MoveDis = (double)numericUpDown_0.Value;
			okCommandWithTwoDataEventHandler_0("X", MoveDis);
		}
		if (control.Name == btn_yminus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			MoveDis = (double)numericUpDown_0.Value;
			okCommandWithTwoDataEventHandler_0("Y", 0.0 - MoveDis);
		}
		if (control.Name == btn_yplus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			MoveDis = (double)numericUpDown_0.Value;
			okCommandWithTwoDataEventHandler_0("Y", MoveDis);
		}
		if (control.Name == btn_anglePlus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			MoveDis = (double)numericUpDown_0.Value;
			okCommandWithTwoDataEventHandler_0("AnglePlus", MoveDis);
		}
		if (control.Name == btn_angleMinus.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			MoveDis = (double)numericUpDown_0.Value;
			okCommandWithTwoDataEventHandler_0("AngleMinus", MoveDis);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		NumericUpDown numericUpDown = sender as NumericUpDown;
		F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
		f_KeyPadNumV.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		f_KeyPadNumV.StartPosition = FormStartPosition.CenterScreen;
		f_KeyPadNumV.Value = numericUpDown.Value.ToString();
		f_KeyPadNumV.ShowDialog(numericUpDown.Value.ToString(), this);
		double result = 0.0;
		double.TryParse(f_KeyPadNumV.Value, out result);
		numericUpDown.Value = (decimal)result;
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
