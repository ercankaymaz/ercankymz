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

public class F_DebugV2 : Form
{
	public bool PasswordCharEnable = true;

	public FormProperties PropertiesForm = new FormProperties();

	[CompilerGenerated]
	private DebugCommandEventHandler debugCommandEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buTextBox buTextBox_0;

	public buButton btn_close;

	internal buButton buButton_0;

	internal buButton buButton_1;

	public buListBox lst_commands;

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

	public F_DebugV2()
	{
		Class76.smethod_531(this);
	}

	public void Init()
	{
		try
		{
			PropertiesForm.Inited = false;
			if (PropertiesForm.Height > 10)
			{
				base.Height = PropertiesForm.Height;
			}
			if (PropertiesForm.Width > 10)
			{
				base.Width = PropertiesForm.Width;
			}
			base.TopMost = PropertiesForm.TopMost;
			base.StartPosition = PropertiesForm.FormPosition;
			buTextBox_0.Text = "";
			if (!PasswordCharEnable)
			{
				buTextBox_0.PasswordChar = '\0';
			}
			else
			{
				buTextBox_0.PasswordChar = '*';
			}
			lst_commands.Items.Clear();
			LoadLanguage();
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
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
		}
		catch (Exception)
		{
		}
	}

	public void AddToList(string commands)
	{
		try
		{
			lst_commands.Items.Add(commands);
			if (lst_commands.Items.Count > 1)
			{
				lst_commands.SelectedIndex = lst_commands.Items.Count - 1;
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
			lst_commands.Items.Clear();
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

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, KeyEventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == btn_close.Name) | (control.Name == buButton_1.Name))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (control.Name == buButton_0.Name && debugCommandEventHandler_0 != null)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
