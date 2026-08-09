using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.Commands;

public class F_Debug : Form
{
	public bool PasswordCharEnable = true;

	[CompilerGenerated]
	private DebugCommandEventHandler debugCommandEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buListBox buListBox_0;

	internal buButton buButton_0;

	internal buTextBox buTextBox_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	public event DebugCommandEventHandler DebugCommandExecuted
	{
		[CompilerGenerated]
		add
		{
			DebugCommandEventHandler debugCommandEventHandler = debugCommandEventHandler_0;
			DebugCommandEventHandler debugCommandEventHandler2;
			do
			{
				debugCommandEventHandler2 = debugCommandEventHandler;
				DebugCommandEventHandler value2 = (DebugCommandEventHandler)Delegate.Combine(debugCommandEventHandler2, value);
				debugCommandEventHandler = Interlocked.CompareExchange(ref debugCommandEventHandler_0, value2, debugCommandEventHandler2);
			}
			while ((object)debugCommandEventHandler != debugCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DebugCommandEventHandler debugCommandEventHandler = debugCommandEventHandler_0;
			DebugCommandEventHandler debugCommandEventHandler2;
			do
			{
				debugCommandEventHandler2 = debugCommandEventHandler;
				DebugCommandEventHandler value2 = (DebugCommandEventHandler)Delegate.Remove(debugCommandEventHandler2, value);
				debugCommandEventHandler = Interlocked.CompareExchange(ref debugCommandEventHandler_0, value2, debugCommandEventHandler2);
			}
			while ((object)debugCommandEventHandler != debugCommandEventHandler2);
		}
	}

	public F_Debug()
	{
		Class76.smethod_563(this);
	}

	public void Init()
	{
		try
		{
			buTextBox_0.Text = "";
			if (!PasswordCharEnable)
			{
				buTextBox_0.PasswordChar = '\0';
			}
			else
			{
				buTextBox_0.PasswordChar = '*';
			}
			buListBox_0.Items.Clear();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void AddToList(string commands)
	{
		try
		{
			buListBox_0.Items.Add(commands);
			if (buListBox_0.Items.Count > 1)
			{
				buListBox_0.SelectedIndex = buListBox_0.Items.Count - 1;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void ClearList()
	{
		try
		{
			buListBox_0.Items.Clear();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void ClearText()
	{
		try
		{
			buTextBox_0.Text = "";
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.KeyCode == Keys.Return && debugCommandEventHandler_0 != null)
			{
				DebugCommandEventArg debugCommandEventArg = new DebugCommandEventArg();
				debugCommandEventArg.DebugCommand = buTextBox_0.Text.Trim();
				debugCommandEventHandler_0(this, debugCommandEventArg);
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
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_2.Name) | (control.Name == buButton_0.Name))
			{
				base.Visible = false;
			}
			if (control.Name == buButton_1.Name)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
