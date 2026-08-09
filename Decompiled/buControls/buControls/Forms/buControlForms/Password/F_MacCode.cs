using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.Password;

public class F_MacCode : Form
{
	public List<string> Captions = new List<string>();

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private SetCodeClickEventHandler setCodeClickEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buSpin buSpin_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buButton buButton_4;

	public buLabel lbl_address;

	public event EventHandler GetAddress
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

	public event SetCodeClickEventHandler SetCode
	{
		[CompilerGenerated]
		add
		{
			SetCodeClickEventHandler setCodeClickEventHandler = setCodeClickEventHandler_0;
			SetCodeClickEventHandler setCodeClickEventHandler2;
			do
			{
				setCodeClickEventHandler2 = setCodeClickEventHandler;
				SetCodeClickEventHandler value2 = (SetCodeClickEventHandler)Delegate.Combine(setCodeClickEventHandler2, value);
				setCodeClickEventHandler = Interlocked.CompareExchange(ref setCodeClickEventHandler_0, value2, setCodeClickEventHandler2);
			}
			while ((object)setCodeClickEventHandler != setCodeClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SetCodeClickEventHandler setCodeClickEventHandler = setCodeClickEventHandler_0;
			SetCodeClickEventHandler setCodeClickEventHandler2;
			do
			{
				setCodeClickEventHandler2 = setCodeClickEventHandler;
				SetCodeClickEventHandler value2 = (SetCodeClickEventHandler)Delegate.Remove(setCodeClickEventHandler2, value);
				setCodeClickEventHandler = Interlocked.CompareExchange(ref setCodeClickEventHandler_0, value2, setCodeClickEventHandler2);
			}
			while ((object)setCodeClickEventHandler != setCodeClickEventHandler2);
		}
	}

	public F_MacCode()
	{
		Class76.smethod_224(this);
	}

	public void Init()
	{
		try
		{
			buSpin_0.Value = 0.0;
			LoadLanguage();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 4)
			{
				Text = Captions[0];
				buButton_0.Text = Captions[1];
				buButton_1.Text = Captions[2];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_3.Name) | (control.Name == buButton_1.Name))
			{
				base.Visible = false;
			}
			if (control.Name == buButton_2.Name)
			{
				base.WindowState = FormWindowState.Minimized;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (setCodeClickEventHandler_0 != null)
			{
				setCodeClickEventHandler_0(buSpin_0.Value);
			}
			Dispose();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(sender, e);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
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
