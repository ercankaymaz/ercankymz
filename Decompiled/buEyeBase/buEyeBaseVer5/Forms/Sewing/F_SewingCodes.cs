using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingCodes : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<SewingCode> CodesDefined = new List<SewingCode>();

	public List<SewingCode> Codes = new List<SewingCode>();

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_ok;

	public Button btn_moveup;

	internal ListBox listBox_0;

	internal ListBox listBox_1;

	internal Label label_0;

	internal Label label_1;

	public Button btn_movedown;

	public Button btn_delete;

	public Button btn_clear;

	public Button btn_cancel;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	public Button btn_addcodes;

	public event OkCommandWithTwoDataEventHandler RotateCommad
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

	public F_SewingCodes()
	{
		Class186.smethod_293(this);
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
		listBox_1.Items.Clear();
		for (int i = 0; i <= CodesDefined.Count - 1; i++)
		{
			string item = CodesDefined[i].Codes.ToString() + " = " + Convert.ToInt32(CodesDefined[i].Codes);
			if (CodesDefined[i].Explanation.Trim().Length > 0)
			{
				item = CodesDefined[i].Explanation + " = " + Convert.ToInt32(CodesDefined[i].Codes);
			}
			listBox_1.Items.Add(item);
		}
		FillCodes();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void FillCodes()
	{
		listBox_0.Items.Clear();
		for (int i = 0; i <= Codes.Count - 1; i++)
		{
			string item = Codes[i].Codes.ToString() + " = " + Convert.ToInt32(Codes[i].Codes);
			if (Codes[i].Explanation.Trim().Length > 0)
			{
				item = Codes[i].Explanation + " = " + Convert.ToInt32(Codes[i].Codes);
			}
			listBox_0.Items.Add(item);
		}
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
		if (control.Name == btn_moveup.Name && ((listBox_0.SelectedIndex >= 1) & (listBox_0.SelectedIndex <= Codes.Count - 1)))
		{
			SewingCode item = new SewingCode(Codes[listBox_0.SelectedIndex]);
			Codes.RemoveAt(listBox_0.SelectedIndex);
			Codes.Insert(listBox_0.SelectedIndex - 1, item);
			FillCodes();
		}
		if (control.Name == btn_movedown.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Codes.Count - 2)))
		{
			SewingCode item2 = new SewingCode(Codes[listBox_0.SelectedIndex]);
			Codes.RemoveAt(listBox_0.SelectedIndex);
			Codes.Insert(listBox_0.SelectedIndex + 1, item2);
			FillCodes();
		}
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class186.smethod_400(this);
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_clear.Name)
		{
			Codes.Clear();
			FillCodes();
		}
		if (control.Name == btn_delete.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Codes.Count - 1)))
		{
			Codes.RemoveAt(listBox_0.SelectedIndex);
			FillCodes();
		}
		if (control.Name == btn_addcodes.Name && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= CodesDefined.Count - 1)))
		{
			Codes.Add(new SewingCode(CodesDefined[listBox_1.SelectedIndex]));
			FillCodes();
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, EventArgs e)
	{
		numericUpDown_0.Value = Convert.ToInt32(CodesDefined[listBox_1.SelectedIndex].Codes);
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
