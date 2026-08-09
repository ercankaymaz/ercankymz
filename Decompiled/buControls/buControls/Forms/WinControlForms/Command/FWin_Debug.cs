using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Command;

public class FWin_Debug : Form
{
	public FormProperties Properties = new FormProperties();

	public bool PasswordCharEnable = true;

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private DebugCommandEventHandler debugCommandEventHandler_0;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal Button button_0;

	internal Button button_1;

	public ListBox lst_commands;

	public TextBox txt_command;

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

	public FWin_Debug()
	{
		Class76.smethod_264(this);
	}

	public void Init()
	{
		try
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
			base.AutoScaleMode = Properties.ScaleFromMode;
			txt_command.Text = "";
			if (!PasswordCharEnable)
			{
				txt_command.PasswordChar = '\0';
			}
			else
			{
				txt_command.PasswordChar = '*';
			}
			lst_commands.Items.Clear();
			Properties.Result = DialogResult.None;
			Properties.Inited = true;
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
		Class76.smethod_650(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
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
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	public void ClearList()
	{
		try
		{
			lst_commands.Items.Clear();
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	public void ClearText()
	{
		try
		{
			txt_command.Text = "";
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	public void ShowChar()
	{
		try
		{
			txt_command.PasswordChar = '\0';
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	public void HideChar()
	{
		try
		{
			txt_command.PasswordChar = '*';
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	internal void method_1(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.KeyCode == Keys.Return && debugCommandEventHandler_0 != null)
			{
				DebugCommandEventArg debugCommandEventArg = new DebugCommandEventArg();
				debugCommandEventArg.DebugCommand = txt_command.Text.Trim();
				debugCommandEventArg.PasswordChar = PasswordCharEnable;
				debugCommandEventHandler_0(this, debugCommandEventArg);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == button_0.Name && Properties.Result != DialogResult.OK)
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
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			method_1(null, new KeyEventArgs(Keys.Return));
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
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
