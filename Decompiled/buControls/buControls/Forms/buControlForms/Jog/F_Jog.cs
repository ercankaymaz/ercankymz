using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Jog;

public class F_Jog : Form
{
	public int AxisCount = 4;

	public bool ScreenCenter = false;

	public bool FormTopMost = true;

	public int PageWidth = 0;

	public int GroupWidth = 0;

	public double SelectedMolt = 1.0;

	public bool Disablex1000 = false;

	public bool ShowSettingsMenu = true;

	public List<string> AxisChars = new List<string>();

	public List<string> Captions = new List<string>();

	private bool bool_0 = false;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private JogModeChangedEventHandler jogModeChangedEventHandler_0;

	[CompilerGenerated]
	private JogAxisChangedEventHandler jogAxisChangedEventHandler_0;

	[CompilerGenerated]
	private JogMoltChangedEventHandler jogMoltChangedEventHandler_0;

	[CompilerGenerated]
	private JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buLabel buLabel_0;

	public buButton btn_absstop;

	public buButton btn_absgo;

	internal buButton buButton_0;

	public buTab tab_jog;

	public TabPage xtraTabPageSpeed;

	internal buLabel buLabel_1;

	public buButton btn_speedminus;

	public buButton btn_speedplus;

	public buButton btn_speedstop;

	public TabPage xtraTabPagePosition;

	internal buLabel buLabel_2;

	public buButton btn_incminus;

	public buButton btn_incplus;

	public buButton btn_incstop;

	public TabPage xtraTabPageAbsolute;

	public buSpin spn_JogAbsvalue;

	internal buGroup buGroup_0;

	internal buCheckBox buCheckBox_0;

	internal buCheckBox buCheckBox_1;

	internal buCheckBox buCheckBox_2;

	internal buCheckBox buCheckBox_3;

	internal buGround buGround_0;

	public buLabel led_position;

	public buCheckBox btn_ax16;

	public buCheckBox btn_ax15;

	public buCheckBox btn_ax14;

	public buCheckBox btn_ax13;

	public buCheckBox btn_ax12;

	public buCheckBox btn_ax11;

	public buCheckBox btn_ax10;

	public buCheckBox btn_ax9;

	public buCheckBox btn_ax8;

	public buCheckBox btn_ax7;

	public buCheckBox btn_ax6;

	public buCheckBox btn_ax5;

	public buCheckBox btn_ax4;

	public buCheckBox btn_ax3;

	public buCheckBox btn_ax2;

	public buCheckBox btn_ax1;

	internal buButton buButton_1;

	internal buPanel buPanel_0;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buButton buButton_4;

	internal buButton buButton_5;

	internal buButton buButton_6;

	internal buButton buButton_7;

	internal buButton buButton_8;

	public event EventHandler PageClose
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

	public event JogModeChangedEventHandler ModeChanged
	{
		[CompilerGenerated]
		add
		{
			JogModeChangedEventHandler jogModeChangedEventHandler = jogModeChangedEventHandler_0;
			JogModeChangedEventHandler jogModeChangedEventHandler2;
			do
			{
				jogModeChangedEventHandler2 = jogModeChangedEventHandler;
				JogModeChangedEventHandler value2 = (JogModeChangedEventHandler)Delegate.Combine(jogModeChangedEventHandler2, value);
				jogModeChangedEventHandler = Interlocked.CompareExchange(ref jogModeChangedEventHandler_0, value2, jogModeChangedEventHandler2);
			}
			while ((object)jogModeChangedEventHandler != jogModeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			JogModeChangedEventHandler jogModeChangedEventHandler = jogModeChangedEventHandler_0;
			JogModeChangedEventHandler jogModeChangedEventHandler2;
			do
			{
				jogModeChangedEventHandler2 = jogModeChangedEventHandler;
				JogModeChangedEventHandler value2 = (JogModeChangedEventHandler)Delegate.Remove(jogModeChangedEventHandler2, value);
				jogModeChangedEventHandler = Interlocked.CompareExchange(ref jogModeChangedEventHandler_0, value2, jogModeChangedEventHandler2);
			}
			while ((object)jogModeChangedEventHandler != jogModeChangedEventHandler2);
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

	public event JogMoltChangedEventHandler MoltChanged
	{
		[CompilerGenerated]
		add
		{
			JogMoltChangedEventHandler jogMoltChangedEventHandler = jogMoltChangedEventHandler_0;
			JogMoltChangedEventHandler jogMoltChangedEventHandler2;
			do
			{
				jogMoltChangedEventHandler2 = jogMoltChangedEventHandler;
				JogMoltChangedEventHandler value2 = (JogMoltChangedEventHandler)Delegate.Combine(jogMoltChangedEventHandler2, value);
				jogMoltChangedEventHandler = Interlocked.CompareExchange(ref jogMoltChangedEventHandler_0, value2, jogMoltChangedEventHandler2);
			}
			while ((object)jogMoltChangedEventHandler != jogMoltChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			JogMoltChangedEventHandler jogMoltChangedEventHandler = jogMoltChangedEventHandler_0;
			JogMoltChangedEventHandler jogMoltChangedEventHandler2;
			do
			{
				jogMoltChangedEventHandler2 = jogMoltChangedEventHandler;
				JogMoltChangedEventHandler value2 = (JogMoltChangedEventHandler)Delegate.Remove(jogMoltChangedEventHandler2, value);
				jogMoltChangedEventHandler = Interlocked.CompareExchange(ref jogMoltChangedEventHandler_0, value2, jogMoltChangedEventHandler2);
			}
			while ((object)jogMoltChangedEventHandler != jogMoltChangedEventHandler2);
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

	public F_Jog()
	{
		Class76.smethod_532(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		try
		{
			e.Cancel = true;
			base.Visible = false;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void Init()
	{
		try
		{
			bool_0 = false;
			buButton_1.Visible = ShowSettingsMenu;
			if (AxisCount <= 4)
			{
				base.Width = 660;
				buGroup_0.Width = 150;
			}
			if ((AxisCount >= 5) & (AxisCount <= 8))
			{
				base.Width = 810;
				buGroup_0.Width = 300;
			}
			if ((AxisCount >= 9) & (AxisCount <= 12))
			{
				base.Width = 830;
				buGroup_0.Width = 332;
			}
			if ((AxisCount >= 13) & (AxisCount <= 16))
			{
				base.Width = 830;
				buGroup_0.Width = 442;
			}
			if ((PageWidth > 10) & (GroupWidth > 10))
			{
				base.Width = PageWidth;
				buGroup_0.Width = GroupWidth;
			}
			if (AppProcess.SelectedAxis < 0)
			{
				AppProcess.SelectedAxis = 0;
			}
			if (ScreenCenter)
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
			base.TopMost = FormTopMost;
			btn_ax1.Visible = false;
			btn_ax2.Visible = false;
			btn_ax3.Visible = false;
			btn_ax4.Visible = false;
			btn_ax5.Visible = false;
			btn_ax6.Visible = false;
			btn_ax7.Visible = false;
			btn_ax8.Visible = false;
			btn_ax9.Visible = false;
			btn_ax10.Visible = false;
			btn_ax11.Visible = false;
			btn_ax12.Visible = false;
			btn_ax13.Visible = false;
			btn_ax14.Visible = false;
			btn_ax15.Visible = false;
			btn_ax16.Visible = false;
			if (AxisCount >= 1)
			{
				btn_ax1.Visible = true;
			}
			if (AxisCount >= 2)
			{
				btn_ax2.Visible = true;
			}
			if (AxisCount >= 3)
			{
				btn_ax3.Visible = true;
			}
			if (AxisCount >= 4)
			{
				btn_ax4.Visible = true;
			}
			if (AxisCount >= 5)
			{
				btn_ax5.Visible = true;
			}
			if (AxisCount >= 6)
			{
				btn_ax6.Visible = true;
			}
			if (AxisCount >= 7)
			{
				btn_ax7.Visible = true;
			}
			if (AxisCount >= 8)
			{
				btn_ax8.Visible = true;
			}
			if (AxisCount >= 9)
			{
				btn_ax9.Visible = true;
			}
			if (AxisCount >= 10)
			{
				btn_ax10.Visible = true;
			}
			if (AxisCount >= 11)
			{
				btn_ax11.Visible = true;
			}
			if (AxisCount >= 12)
			{
				btn_ax12.Visible = true;
			}
			if (AxisCount >= 13)
			{
				btn_ax13.Visible = true;
			}
			if (AxisCount >= 14)
			{
				btn_ax14.Visible = true;
			}
			if (AxisCount >= 15)
			{
				btn_ax15.Visible = true;
			}
			if (AxisCount >= 16)
			{
				btn_ax16.Visible = true;
			}
			buCheckBox_3.Check = false;
			buCheckBox_2.Check = false;
			buCheckBox_2.Check = false;
			buCheckBox_0.Check = false;
			if (SelectedMolt == 0.001)
			{
				buCheckBox_3.Check = true;
			}
			if (SelectedMolt == 0.01)
			{
				buCheckBox_2.Check = true;
			}
			if (SelectedMolt == 0.1)
			{
				buCheckBox_1.Check = true;
			}
			if (SelectedMolt == 1.0)
			{
				buCheckBox_0.Check = true;
			}
			btn_ax1.Check = false;
			btn_ax2.Check = false;
			btn_ax3.Check = false;
			btn_ax4.Check = false;
			btn_ax5.Check = false;
			btn_ax6.Check = false;
			btn_ax7.Check = false;
			btn_ax8.Check = false;
			btn_ax9.Check = false;
			btn_ax10.Check = false;
			btn_ax11.Check = false;
			btn_ax12.Check = false;
			btn_ax13.Check = false;
			btn_ax14.Check = false;
			btn_ax15.Check = false;
			btn_ax16.Check = false;
			if (AppProcess.SelectedAxis == 0)
			{
				btn_ax1.Check = true;
			}
			if (AppProcess.SelectedAxis == 1)
			{
				btn_ax2.Check = true;
			}
			if (AppProcess.SelectedAxis == 2)
			{
				btn_ax3.Check = true;
			}
			if (AppProcess.SelectedAxis == 3)
			{
				btn_ax4.Check = true;
			}
			if (AppProcess.SelectedAxis == 4)
			{
				btn_ax5.Check = true;
			}
			if (AppProcess.SelectedAxis == 5)
			{
				btn_ax6.Check = true;
			}
			if (AppProcess.SelectedAxis == 6)
			{
				btn_ax7.Check = true;
			}
			if (AppProcess.SelectedAxis == 7)
			{
				btn_ax8.Check = true;
			}
			if (AppProcess.SelectedAxis == 8)
			{
				btn_ax9.Check = true;
			}
			if (AppProcess.SelectedAxis == 9)
			{
				btn_ax10.Check = true;
			}
			if (AppProcess.SelectedAxis == 10)
			{
				btn_ax11.Check = true;
			}
			if (AppProcess.SelectedAxis == 11)
			{
				btn_ax12.Check = true;
			}
			if (AppProcess.SelectedAxis == 12)
			{
				btn_ax13.Check = true;
			}
			if (AppProcess.SelectedAxis == 13)
			{
				btn_ax14.Check = true;
			}
			if (AppProcess.SelectedAxis == 14)
			{
				btn_ax15.Check = true;
			}
			if (AppProcess.SelectedAxis == 15)
			{
				btn_ax16.Check = true;
			}
			LoadLanguage();
			if (Disablex1000)
			{
				buCheckBox_0.Enabled = false;
			}
			bool_0 = true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (AxisChars.Count >= 1)
			{
				btn_ax1.Text = AxisChars[0];
			}
			if (AxisChars.Count >= 2)
			{
				btn_ax2.Text = AxisChars[1];
			}
			if (AxisChars.Count >= 3)
			{
				btn_ax3.Text = AxisChars[2];
			}
			if (AxisChars.Count >= 4)
			{
				btn_ax4.Text = AxisChars[3];
			}
			if (AxisChars.Count >= 5)
			{
				btn_ax5.Text = AxisChars[4];
			}
			if (AxisChars.Count >= 6)
			{
				btn_ax6.Text = AxisChars[5];
			}
			if (AxisChars.Count >= 7)
			{
				btn_ax7.Text = AxisChars[6];
			}
			if (AxisChars.Count >= 8)
			{
				btn_ax8.Text = AxisChars[7];
			}
			if (AxisChars.Count >= 9)
			{
				btn_ax9.Text = AxisChars[8];
			}
			if (AxisChars.Count >= 10)
			{
				btn_ax10.Text = AxisChars[9];
			}
			if (AxisChars.Count >= 11)
			{
				btn_ax11.Text = AxisChars[10];
			}
			if (AxisChars.Count >= 12)
			{
				btn_ax12.Text = AxisChars[11];
			}
			if (AxisChars.Count >= 13)
			{
				btn_ax13.Text = AxisChars[12];
			}
			if (AxisChars.Count >= 14)
			{
				btn_ax14.Text = AxisChars[13];
			}
			if (AxisChars.Count >= 15)
			{
				btn_ax15.Text = AxisChars[14];
			}
			if (AxisChars.Count >= 16)
			{
				btn_ax16.Text = AxisChars[15];
			}
			if (Captions.Count >= 12)
			{
				Text = Captions[0];
				buGroup_0.Text = Captions[1];
				xtraTabPageSpeed.Text = Captions[2];
				xtraTabPagePosition.Text = Captions[3];
				xtraTabPageAbsolute.Text = Captions[4];
				buLabel_1.Text = Captions[5];
				buLabel_2.Text = Captions[6];
				buLabel_0.Text = Captions[7];
				btn_speedplus.Text = Captions[8];
				btn_speedminus.Text = Captions[9];
				btn_incplus.Text = Captions[8];
				btn_incminus.Text = Captions[9];
				btn_speedstop.Text = Captions[10];
				btn_absstop.Text = Captions[10];
				btn_incstop.Text = Captions[10];
				btn_absgo.Text = Captions[11];
				buButton_0.Text = Captions[12];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			new Control();
			base.Visible = false;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			bool_0 = false;
			Control control = new Control();
			control = (Control)sender;
			btn_ax1.Check = false;
			btn_ax2.Check = false;
			btn_ax3.Check = false;
			btn_ax4.Check = false;
			btn_ax5.Check = false;
			btn_ax6.Check = false;
			btn_ax7.Check = false;
			btn_ax8.Check = false;
			btn_ax9.Check = false;
			btn_ax10.Check = false;
			btn_ax11.Check = false;
			btn_ax12.Check = false;
			btn_ax13.Check = false;
			btn_ax14.Check = false;
			btn_ax15.Check = false;
			btn_ax16.Check = false;
			if (control.Name == btn_ax1.Name)
			{
				AppProcess.SelectedAxis = 0;
				btn_ax1.Check = true;
			}
			if (control.Name == btn_ax2.Name)
			{
				AppProcess.SelectedAxis = 1;
				btn_ax2.Check = true;
			}
			if (control.Name == btn_ax3.Name)
			{
				AppProcess.SelectedAxis = 2;
				btn_ax3.Check = true;
			}
			if (control.Name == btn_ax4.Name)
			{
				AppProcess.SelectedAxis = 3;
				btn_ax4.Check = true;
			}
			if (control.Name == btn_ax5.Name)
			{
				AppProcess.SelectedAxis = 4;
				btn_ax5.Check = true;
			}
			if (control.Name == btn_ax6.Name)
			{
				AppProcess.SelectedAxis = 5;
				btn_ax6.Check = true;
			}
			if (control.Name == btn_ax7.Name)
			{
				AppProcess.SelectedAxis = 6;
				btn_ax7.Check = true;
			}
			if (control.Name == btn_ax8.Name)
			{
				AppProcess.SelectedAxis = 7;
				btn_ax8.Check = true;
			}
			if (control.Name == btn_ax9.Name)
			{
				AppProcess.SelectedAxis = 8;
				btn_ax9.Check = true;
			}
			if (control.Name == btn_ax10.Name)
			{
				AppProcess.SelectedAxis = 9;
				btn_ax10.Check = true;
			}
			if (control.Name == btn_ax11.Name)
			{
				AppProcess.SelectedAxis = 10;
				btn_ax11.Check = true;
			}
			if (control.Name == btn_ax12.Name)
			{
				AppProcess.SelectedAxis = 11;
				btn_ax12.Check = true;
			}
			if (control.Name == btn_ax13.Name)
			{
				AppProcess.SelectedAxis = 12;
				btn_ax13.Check = true;
			}
			if (control.Name == btn_ax14.Name)
			{
				AppProcess.SelectedAxis = 13;
				btn_ax14.Check = true;
			}
			if (control.Name == btn_ax15.Name)
			{
				AppProcess.SelectedAxis = 14;
				btn_ax15.Check = true;
			}
			if (control.Name == btn_ax16.Name)
			{
				AppProcess.SelectedAxis = 15;
				btn_ax16.Check = true;
			}
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(this, AppProcess.SelectedAxis);
			}
			bool_0 = true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			buCheckBox_3.Check = false;
			buCheckBox_2.Check = false;
			buCheckBox_1.Check = false;
			buCheckBox_0.Check = false;
			if (control.Name == buCheckBox_3.Name)
			{
				SelectedMolt = 0.001;
				buCheckBox_3.Check = true;
			}
			if (control.Name == buCheckBox_2.Name)
			{
				SelectedMolt = 0.01;
				buCheckBox_2.Check = true;
			}
			if (control.Name == buCheckBox_1.Name)
			{
				SelectedMolt = 0.1;
				buCheckBox_1.Check = true;
			}
			if (control.Name == buCheckBox_0.Name)
			{
				SelectedMolt = 1.0;
				buCheckBox_0.Check = true;
			}
			if (jogMoltChangedEventHandler_0 != null)
			{
				jogMoltChangedEventHandler_0(this, SelectedMolt);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			if (jogModeChangedEventHandler_0 != null)
			{
				JogModeType jogModeType = JogModeType.Velocity;
				jogModeType = (JogModeType)buGeneral.EnumValueFromInt(JogModeType.Velocity, tab_jog.SelectedIndex);
				jogModeChangedEventHandler_0(this, jogModeType);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((AppBool.TouchPad & bool_0) && control.Name == spn_JogAbsvalue.Name)
			{
				buControlCommands.ShowKeyPad(this, spn_JogAbsvalue);
				buGround_0.Focus();
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
	}

	internal void method_8(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == buButton_8.Name)
			{
				buPanel_0.Visible = false;
			}
			if (control.Name == buButton_1.Name)
			{
				if (buPanel_0.Visible)
				{
					buPanel_0.Visible = false;
				}
				else
				{
					buPanel_0.Visible = true;
				}
			}
			if (control.Name == buButton_5.Name)
			{
				buPanel_0.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Moves, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_6.Name)
			{
				buPanel_0.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Jog, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_4.Name)
			{
				buPanel_0.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Gain, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_3.Name)
			{
				buPanel_0.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Drive, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_2.Name)
			{
				buPanel_0.Visible = false;
				if (jogSelectedSettingsModeEventHandler_0 != null)
				{
					jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Homing, AppProcess.SelectedAxis);
				}
			}
			if (control.Name == buButton_7.Name)
			{
				buPanel_0.Visible = false;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
