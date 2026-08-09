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

namespace buControls.Forms.buControlForms.Test;

public class F_TestAll : Form
{
	public int DigitalInputCount = 32;

	public int DigitalInputColumbs = 4;

	public int DigitalOutputCount = 32;

	public int DigitalOutputColumbs = 4;

	public int AxisCount = 4;

	public int SelectedTab = 0;

	public List<string> AxisCaptions = new List<string>();

	public List<string> InputCaptions = new List<string>();

	public List<string> OutputCaptions = new List<string>();

	public bool AxisTabPageVisible = true;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private JogAxisChangedEventHandler jogAxisChangedEventHandler_0;

	[CompilerGenerated]
	private SetOutputEventHandler setOutputEventHandler_0;

	[CompilerGenerated]
	private JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buTab buTab_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal buPanel buPanel_0;

	internal buPanel buPanel_1;

	internal buPanel buPanel_2;

	internal buSeparator buSeparator_0;

	internal buLabel buLabel_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buPanel buPanel_3;

	internal buButton buButton_3;

	internal buButton buButton_4;

	internal buButton buButton_5;

	internal buButton buButton_6;

	internal buButton buButton_7;

	internal buButton buButton_8;

	internal buButton buButton_9;

	public buCheckBox chk_i31;

	public buCheckBox chk_i23;

	public buCheckBox chk_i15;

	public buCheckBox chk_i7;

	public buCheckBox chk_i30;

	public buCheckBox chk_i22;

	public buCheckBox chk_i14;

	public buCheckBox chk_i6;

	public buCheckBox chk_i29;

	public buCheckBox chk_i21;

	public buCheckBox chk_i13;

	public buCheckBox chk_i5;

	public buCheckBox chk_i28;

	public buCheckBox chk_i20;

	public buCheckBox chk_i12;

	public buCheckBox chk_i4;

	public buCheckBox chk_i27;

	public buCheckBox chk_i19;

	public buCheckBox chk_i11;

	public buCheckBox chk_i3;

	public buCheckBox chk_i26;

	public buCheckBox chk_i18;

	public buCheckBox chk_i10;

	public buCheckBox chk_i2;

	public buCheckBox chk_i25;

	public buCheckBox chk_i17;

	public buCheckBox chk_i9;

	public buCheckBox chk_i1;

	public buCheckBox chk_i24;

	public buCheckBox chk_i16;

	public buCheckBox chk_i8;

	public buCheckBox chk_i0;

	public buCheckBox chk_o31;

	public buCheckBox chk_o23;

	public buCheckBox chk_o15;

	public buCheckBox chk_o7;

	public buCheckBox chk_o30;

	public buCheckBox chk_o22;

	public buCheckBox chk_o14;

	public buCheckBox chk_o6;

	public buCheckBox chk_o29;

	public buCheckBox chk_o21;

	public buCheckBox chk_o13;

	public buCheckBox chk_o5;

	public buCheckBox chk_o28;

	public buCheckBox chk_o20;

	public buCheckBox chk_o12;

	public buCheckBox chk_o4;

	public buCheckBox chk_o27;

	public buCheckBox chk_o19;

	public buCheckBox chk_o11;

	public buCheckBox chk_o3;

	public buCheckBox chk_o26;

	public buCheckBox chk_o18;

	public buCheckBox chk_o10;

	public buCheckBox chk_o2;

	public buCheckBox chk_o25;

	public buCheckBox chk_o17;

	public buCheckBox chk_o9;

	public buCheckBox chk_o1;

	public buCheckBox chk_o24;

	public buCheckBox chk_o16;

	public buCheckBox chk_o8;

	public buCheckBox chk_o0;

	public buListBox lst_axis;

	public buLabel lbl_axis;

	public buLabel lbl_pos;

	public buButton btn_auto;

	public buButton btn_pos1;

	public buButton btn_homing;

	public buButton btn_pos2;

	public buButton btn_stop;

	public buButton btn_fwd;

	public buButton btn_bwd;

	public buButton btn_relative;

	public buButton btn_write;

	public buCheckBox chk_Homing;

	public buCheckBox chk_capture;

	public buCheckBox chk_positive;

	public buCheckBox chk_negative;

	public buSpin spn_pos1;

	public buSpin spn_waittime;

	public buSpin spn_relative;

	public buSpin spn_pos2;

	public event EventHandler PageClosing
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

	public event JogAxisChangedEventHandler AxisChanged
	{
		[CompilerGenerated]
		add
		{
			JogAxisChangedEventHandler jogAxisChangedEventHandler = jogAxisChangedEventHandler_0;
			JogAxisChangedEventHandler jogAxisChangedEventHandler2;
			do
			{
				jogAxisChangedEventHandler2 = jogAxisChangedEventHandler;
				JogAxisChangedEventHandler value2 = (JogAxisChangedEventHandler)Delegate.Combine(jogAxisChangedEventHandler2, value);
				jogAxisChangedEventHandler = Interlocked.CompareExchange(ref jogAxisChangedEventHandler_0, value2, jogAxisChangedEventHandler2);
			}
			while ((object)jogAxisChangedEventHandler != jogAxisChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			JogAxisChangedEventHandler jogAxisChangedEventHandler = jogAxisChangedEventHandler_0;
			JogAxisChangedEventHandler jogAxisChangedEventHandler2;
			do
			{
				jogAxisChangedEventHandler2 = jogAxisChangedEventHandler;
				JogAxisChangedEventHandler value2 = (JogAxisChangedEventHandler)Delegate.Remove(jogAxisChangedEventHandler2, value);
				jogAxisChangedEventHandler = Interlocked.CompareExchange(ref jogAxisChangedEventHandler_0, value2, jogAxisChangedEventHandler2);
			}
			while ((object)jogAxisChangedEventHandler != jogAxisChangedEventHandler2);
		}
	}

	public event SetOutputEventHandler SetOutput
	{
		[CompilerGenerated]
		add
		{
			SetOutputEventHandler setOutputEventHandler = setOutputEventHandler_0;
			SetOutputEventHandler setOutputEventHandler2;
			do
			{
				setOutputEventHandler2 = setOutputEventHandler;
				SetOutputEventHandler value2 = (SetOutputEventHandler)Delegate.Combine(setOutputEventHandler2, value);
				setOutputEventHandler = Interlocked.CompareExchange(ref setOutputEventHandler_0, value2, setOutputEventHandler2);
			}
			while ((object)setOutputEventHandler != setOutputEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SetOutputEventHandler setOutputEventHandler = setOutputEventHandler_0;
			SetOutputEventHandler setOutputEventHandler2;
			do
			{
				setOutputEventHandler2 = setOutputEventHandler;
				SetOutputEventHandler value2 = (SetOutputEventHandler)Delegate.Remove(setOutputEventHandler2, value);
				setOutputEventHandler = Interlocked.CompareExchange(ref setOutputEventHandler_0, value2, setOutputEventHandler2);
			}
			while ((object)setOutputEventHandler != setOutputEventHandler2);
		}
	}

	public event JogSelectedSettingsModeEventHandler SettingsClick
	{
		[CompilerGenerated]
		add
		{
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler = jogSelectedSettingsModeEventHandler_0;
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler2;
			do
			{
				jogSelectedSettingsModeEventHandler2 = jogSelectedSettingsModeEventHandler;
				JogSelectedSettingsModeEventHandler value2 = (JogSelectedSettingsModeEventHandler)Delegate.Combine(jogSelectedSettingsModeEventHandler2, value);
				jogSelectedSettingsModeEventHandler = Interlocked.CompareExchange(ref jogSelectedSettingsModeEventHandler_0, value2, jogSelectedSettingsModeEventHandler2);
			}
			while ((object)jogSelectedSettingsModeEventHandler != jogSelectedSettingsModeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler = jogSelectedSettingsModeEventHandler_0;
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler2;
			do
			{
				jogSelectedSettingsModeEventHandler2 = jogSelectedSettingsModeEventHandler;
				JogSelectedSettingsModeEventHandler value2 = (JogSelectedSettingsModeEventHandler)Delegate.Remove(jogSelectedSettingsModeEventHandler2, value);
				jogSelectedSettingsModeEventHandler = Interlocked.CompareExchange(ref jogSelectedSettingsModeEventHandler_0, value2, jogSelectedSettingsModeEventHandler2);
			}
			while ((object)jogSelectedSettingsModeEventHandler != jogSelectedSettingsModeEventHandler2);
		}
	}

	public F_TestAll()
	{
		Class76.smethod_155(this);
	}

	public void Init()
	{
		try
		{
			lst_axis.Items.Clear();
			for (int i = 0; i <= AxisCount - 1; i++)
			{
				if (i > AxisCaptions.Count - 1)
				{
					lst_axis.Items.Add("Axis " + (i + 1));
				}
				else
				{
					lst_axis.Items.Add(AxisCaptions[i]);
				}
			}
			for (int j = 0; j <= 48; j++)
			{
				for (int k = 0; k <= tabPage_0.Controls.Count - 1; k++)
				{
					Control control = new Control();
					control = tabPage_0.Controls[k];
					if (control.Name == "chk_i" + j && ((InputCaptions.Count > 0) & (j <= InputCaptions.Count - 1)))
					{
						((buCheckBox)tabPage_0.Controls[k]).Text = InputCaptions[j];
					}
				}
			}
			for (int l = 0; l <= 48; l++)
			{
				for (int m = 0; m <= tabPage_1.Controls.Count - 1; m++)
				{
					Control control2 = new Control();
					control2 = tabPage_1.Controls[m];
					if (control2.Name == "chk_o" + l && ((OutputCaptions.Count > 0) & (l <= OutputCaptions.Count - 1)))
					{
						((buCheckBox)tabPage_1.Controls[m]).Text = OutputCaptions[l];
					}
				}
			}
			if ((AppProcess.SelectedAxis >= 0) & (AppProcess.SelectedAxis <= lst_axis.Items.Count - 1))
			{
				lst_axis.SelectedIndex = AppProcess.SelectedAxis;
			}
			if (!AxisTabPageVisible && buTab_0.TabPages.Count == 3)
			{
				buTab_0.TabPages.RemoveAt(2);
			}
			if ((buTab_0.SelectedIndex == 0) | (buTab_0.SelectedIndex == 1))
			{
				buPanel_3.Visible = false;
				buButton_2.Visible = false;
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
			if (control.Name == buButton_1.Name)
			{
				base.Visible = false;
			}
			if (control.Name == buButton_0.Name)
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
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == buButton_3.Name)
			{
				buPanel_3.Visible = false;
			}
			if (control.Name == buButton_2.Name)
			{
				if (buPanel_3.Visible)
				{
					buPanel_3.Visible = false;
				}
				else
				{
					buPanel_3.Visible = true;
				}
			}
			if (control.Name == buButton_8.Name)
			{
				buPanel_3.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Moves, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_9.Name)
			{
				buPanel_3.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Jog, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_7.Name)
			{
				buPanel_3.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Gain, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_6.Name)
			{
				buPanel_3.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Drive, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_5.Name)
			{
				buPanel_3.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Homing, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_4.Name)
			{
				buPanel_3.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Sets, AppProcess.SelectedAxis);
				}
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
			if (control.Tag != null && setOutputEventHandler_0 != null)
			{
				int index = int.Parse(control.Tag.ToString());
				setOutputEventHandler_0(index);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			if (jogAxisChangedEventHandler_0 != null && lst_axis.SelectedIndex >= 0)
			{
				jogAxisChangedEventHandler_0(this, lst_axis.SelectedIndex);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == spn_pos1.Name && AppBool.TouchPad)
			{
				buControlCommands.ShowKeyPad(this, spn_pos1);
			}
			if (control.Name == spn_pos2.Name && AppBool.TouchPad)
			{
				buControlCommands.ShowKeyPad(this, spn_pos2);
			}
			if (control.Name == spn_relative.Name && AppBool.TouchPad)
			{
				buControlCommands.ShowKeyPad(this, spn_relative);
			}
			if (control.Name == spn_waittime.Name && AppBool.TouchPad)
			{
				buControlCommands.ShowKeyPad(this, spn_waittime);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_5(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(buPanel_0.Controls, result, e.Shift);
		}
	}

	public void GetInput(int Index, bool State)
	{
		try
		{
			for (int i = 1; i <= tabPage_0.Controls.Count - 1; i++)
			{
				if (tabPage_0.Controls[i].Tag != null)
				{
					int num = int.Parse(tabPage_0.Controls[i].Tag.ToString());
					if (num == Index)
					{
						((buCheckBox)tabPage_0.Controls[i]).Check = State;
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Index: " + Index + " - State: " + State;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void GetOutput(int Index, bool State)
	{
		try
		{
			for (int i = 1; i <= tabPage_1.Controls.Count - 1; i++)
			{
				if (tabPage_1.Controls[i].Tag != null)
				{
					int num = int.Parse(tabPage_1.Controls[i].Tag.ToString());
					if (num == Index)
					{
						((buCheckBox)tabPage_1.Controls[i]).Check = State;
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Index: " + Index + " - State: " + State;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void SetAxisInput(bool Homing, bool PosLim, bool NegLim, bool Capture)
	{
		chk_Homing.Check = Homing;
		chk_negative.Check = NegLim;
		chk_positive.Check = PosLim;
		chk_capture.Check = Capture;
	}

	internal void method_6(object sender, EventArgs e)
	{
		SelectedTab = buTab_0.SelectedIndex;
		if ((buTab_0.SelectedIndex == 0) | (buTab_0.SelectedIndex == 1))
		{
			buPanel_3.Visible = false;
			buButton_2.Visible = false;
		}
		if (buTab_0.SelectedIndex == 2)
		{
			buButton_2.Visible = true;
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
