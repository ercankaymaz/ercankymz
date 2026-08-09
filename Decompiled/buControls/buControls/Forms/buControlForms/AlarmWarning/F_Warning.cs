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

namespace buControls.Forms.buControlForms.AlarmWarning;

public class F_Warning : Form
{
	public List<string> Captions = new List<string>();

	public bool FormTopMost = false;

	public bool ScreenCenter = false;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buListBox lst_warning;

	public buButton btn_warningreset;

	public event EventHandler WarningResetClick
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

	public F_Warning()
	{
		Class76.smethod_286(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	public void Init(List<AppWarning> WarningList)
	{
		try
		{
			base.TopMost = FormTopMost;
			lst_warning.Items.Clear();
			for (int i = 0; i <= WarningList.Count - 1; i++)
			{
				lst_warning.Items.Add(WarningList[i].Text);
			}
			if (ScreenCenter)
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
			LoadLanguage();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void Init(List<string> WarningList)
	{
		try
		{
			base.TopMost = FormTopMost;
			lst_warning.Items.Clear();
			for (int i = 0; i <= WarningList.Count - 1; i++)
			{
				lst_warning.Items.Add(WarningList[i]);
			}
			if (ScreenCenter)
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
			LoadLanguage();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count >= 2)
			{
				Text = Captions[0];
				buButton_0.Text = Captions[1];
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		try
		{
			e.Cancel = true;
			base.Visible = false;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			base.Visible = false;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_3(object sender, EventArgs e)
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
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
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
